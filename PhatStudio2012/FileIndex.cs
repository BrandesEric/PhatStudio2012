//
// FILEINDEX.CS 
//
// Copyright (c) 2009 PhatStudio development team (Jeremy Stone et al)
// 
// This file is part of PhatStudio.
//
// PhatStudio is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// PhatStudio is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with PhatStudio. If not, see <http://www.gnu.org/licenses/>.
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using System.Diagnostics;
using System.Globalization;

namespace PhatStudio
{
    public class FileIndex
    {
        // for performance, we split up a file path into "phrases" where slash-separated component of the file path --
        // every subdirectory and file name -- is a phrase

        // The trie of phrases.  This allows us to quickly find the set of phrases that match a particular substring
        SuffixTrie triePhrases;

        // A hash table that does a quick lookup from a particular phrase to find the list of things (files and directories)
        // that include that phrase
        Dictionary<string, List<IndexData>> phraseDictionary;

        // A hash table to look up from full directory name to index data
        Dictionary<string, DirIndexData> dirDictionary;

        // A hash table to look up from full directory+file name to index data
        Dictionary<string, FileIndexData> fileDictionary;

        char[] pathSplitter = new char[] { '\\' };

        public event EventHandler FileListChanged;

        public int Count { get { return fileDictionary.Count; } }

		private string solutionDir;

        private Timer timer;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public FileIndex()
        {
            Init();
        }

        /// <summary>
        /// Initializer
        /// </summary>
        private void Init()
        {
            triePhrases = new SuffixTrie();
            phraseDictionary = new Dictionary<string, List<IndexData>>();
            dirDictionary = new Dictionary<string, DirIndexData>();
            fileDictionary = new Dictionary<string, FileIndexData>();
            timer = new Timer(500);
            timer.AutoReset = false;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        /// <summary>
        /// Adds a filepath to the index
        /// </summary>
        /// <param name="filePath"></param>
        public void AddFile(string filePath)
        {
            string absoluteDirOrig = "";

            // split the path so that each subdirectory and the file name become individual phrases
            string[] phrases = filePath.Split(pathSplitter);
            DirIndexData currentDirItem = null;
            int nameStartIndex = 0;

            // put each phrase into the trie for quick lookup later
            for (int i = 0; i < phrases.Length; i++)
            {
                string phraseOrig = phrases[i];
                string phraseLowered = phraseOrig.ToLower(CultureInfo.InvariantCulture);

                absoluteDirOrig = Path.Combine(absoluteDirOrig, phraseOrig);
                if (absoluteDirOrig.EndsWith(":"))
                {
                    absoluteDirOrig += '\\';
                }
                string absoluteDirLowered = absoluteDirOrig.ToLower(CultureInfo.InvariantCulture);

                // have we encountered this phrase before?
                List<IndexData> phraseMatches;
                phraseDictionary.TryGetValue(phraseLowered, out phraseMatches);
                if (phraseMatches == null)
                {
                    // no, add this phrase to the trie (for substring->phrase lookup) and the hash table
                    // (for phrase->matching items lookup)
                    triePhrases.AddString(phraseLowered);
                    phraseMatches = new List<IndexData>();
                    phraseDictionary[phraseLowered] = phraseMatches;
                }
                
                if (i < phrases.Length - 1)
                {
                    // if this is any phrase except the last, this is a directory

                    // add this directory to the dictionary if it's not already there
                    DirIndexData dirItem;
                    dirDictionary.TryGetValue(absoluteDirLowered, out dirItem);
                    if (dirItem == null)
                    {
                        dirItem = new DirIndexData(phraseOrig, absoluteDirOrig,nameStartIndex);
                        dirDictionary[absoluteDirLowered] = dirItem;
                        phraseMatches.Add(dirItem);
                        if (currentDirItem != null)
                        {
                            currentDirItem.subdirs.Add(dirItem);
                        }
                    }

                    currentDirItem = dirItem;
                    nameStartIndex += phraseLowered.Length + 1;
                }
                else
                {
                    // this is the last phrase in the file path, this is a file
                    string fullName = Path.Combine(currentDirItem.FullName, phraseOrig);

                    // avoid duplicates: if we have already added this exact path under the phrase for its
                    // file name, don't add it again
                    bool shouldAdd = true;
                    if (phraseMatches.Count > 0)
					{ 
						FileIndexData fid = (phraseMatches[phraseMatches.Count - 1]) as FileIndexData;
						if (fid != null)
						{
							if (fid.FullName == fullName)
							{
								shouldAdd = false;
							}
						}
                    }

                    if (shouldAdd)
                    {
                        // add this file to the dictionary if it's not already there
                        FileIndexData fileItem;
                        fileDictionary.TryGetValue(fullName, out fileItem);
                        if (fileItem == null)
                        {
                            fileItem = new FileIndexData(phraseOrig, fullName, nameStartIndex);
                            fileDictionary[fullName] = fileItem;
                            phraseMatches.Add(fileItem);
                            currentDirItem.files.Add(fileItem);
                        }
                        // Schedule a file list changed event to occur in a little bit.  This will get further delayed if other
                        // files are added, so if you add a bunch of files in rapid succession the event will only get fired at once after
                        // the last file is added.
                        ScheduleFileListChangedEvent();
                    }
                }
            }            
        }

        /// <summary>
        /// Removes all files from the index
        /// </summary>
        public void RemoveAll()
        {
            Init();
            ScheduleFileListChangedEvent();
        }

        /// <summary>
        /// Schedules a FileListChanged event to fire in the future, and cancels any pending events.
        /// </summary>
        private void ScheduleFileListChangedEvent()
        {
            // cancel the timer if it's running
            timer.Stop();
            // start over
            timer.Start();
        }

        /// <summary>
        /// Called when timer elapses
        /// </summary>
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // send a FileListChanged event
            OnFileListChanged();    
        }

        /// <summary>
        /// Causes a FileListChanged event to be fired
        /// </summary>
        private void OnFileListChanged()
        {
            if (FileListChanged != null)
            {
                // Debug.WriteLine("PhatStudio: Firing OnFileListChanged");
                FileListChanged(this, new EventArgs());
            }

            timer.Stop();
        }

        /// <summary>
        /// Returns list of all filepaths that contain the specified substring
        /// </summary>
        public List<FileMatch> FindSubstringMatches(string searchStr)
        {
            Dictionary<string, FileMatch> searchResults = new Dictionary<string, FileMatch>();

            if (searchStr != string.Empty)
            {
                // filepaths are stored in lowercase, lowercase the search substring as well
				searchStr = searchStr.ToLower(CultureInfo.InvariantCulture);

                // if the last character is a '\', then for this to match anything
                // it must be the the trailing edge of a directory name.  (e.g. "debug\" or "ug\" will
                // match a directory called "debug")
                bool mustBeDirSuffix = false;
                if (searchStr[searchStr.Length - 1] == Path.DirectorySeparatorChar)
                {
                    // trim the '\' so we can do phrase matching but remember that only directory suffixes may match
                    searchStr = searchStr.Remove(searchStr.Length - 1);
                    mustBeDirSuffix = true;
                }
                
                // decide the phrase we're going to search on.  If the search string has multiple path components,
                // we're going to take the final path component and use that as the phrase.  If the search string
                // doesn't contain multiple path components, then the the whole search string is the phrase.
                string searchPhrase;
                int separatorIndex = searchStr.LastIndexOf(Path.DirectorySeparatorChar);
                bool mustBePrefix = false;
                if (separatorIndex >= 0)
                {
                    // yes.  We will just search on the last phrase (e.g. ("proj\debug\obj" means
                    // we just search on "obj") and then filter any of those phrase matches
                    // against the earlier part of the substring
                    searchPhrase = searchStr.Substring(separatorIndex + 1);                    
                    mustBePrefix = true;
                }
                else
                {
                    // no, search string does not contain multiple path components, use the whole thing as the phrase
                    searchPhrase = searchStr;
                }

                // get the list of matches for the search phrase
                List<SubstringMatch> nameMatches = triePhrases.FindSubstringMatches(searchPhrase);

                foreach (SubstringMatch nameMatch in nameMatches)
                {
                    // if the search phrase must be the prefix of a file or directory name, then discard
                    // any matches that don't occur at the 0th index of a phrase
                    if (mustBePrefix && nameMatch.startIndex != 0)
                        continue;

                    List<IndexData> matches = phraseDictionary[nameMatch.Value];

                    foreach (IndexData item in matches)
                    {
                        if (mustBePrefix)
                        {                                
                            IndexData IndexData = item as IndexData;
                            int startIndex = (IndexData.NameStartIndex - (searchStr.Length - searchPhrase.Length));
                            if ((startIndex < 0) ||
                                (String.Compare(IndexData.FullName.Substring(startIndex, searchStr.Length), searchStr, true) !=0 ))
                            {
                                // doesn't match the whole search string, discard it
                                continue;
                            }
                        }

                        DirIndexData dirItem = item as DirIndexData;
                        if (dirItem != null)
                        {
                            // this item that matches the search string is a directory

                            // is the search string is a directory suffix? (e.g. "ebug\")
                            if (mustBeDirSuffix)
                            {
                                // yes. discard any matches whose full directory paths don't end in the search string
                                if (!dirItem.FullName.EndsWith(searchStr, StringComparison.OrdinalIgnoreCase))
                                    continue;
                            }

                            // Files with this directory anywhere in their path match the search string.  So 
                            // add all files in this directory and all subdirectories to the search results.
                            AddAllFilesInSubtreeToSearchResults(dirItem, nameMatch.startIndex, ref searchResults);
                        }
                        else
                        {
                            // this item is a file

                            // if the search string is a directory suffix, then a file won't match it
                            if (mustBeDirSuffix)
                                continue;
                            
                            // Add this file to the search results
                            FileIndexData fileItem = item as FileIndexData;
                            AddFileToSearchResults(fileItem, nameMatch.startIndex, true, ref searchResults);
                        }
                    }
                }
            }
            else
            {
                // special-case handling for an empty string: add all files in the index to search results
                foreach (FileIndexData fileItem in fileDictionary.Values)
                {
                    AddFileToSearchResults(fileItem, 0, false, ref searchResults);
                }
            }

            // get a list of the files in search results
            List<FileMatch> matchList = new List<FileMatch>(searchResults.Values);

            // sort the search results
            matchList.Sort();

            return matchList;
        }
        
        /// <summary>
        /// Adds specified file to search results
        /// </summary>
        private void AddFileToSearchResults(FileIndexData fileItem, int startIndex, bool matchedFileName, ref Dictionary<string, FileMatch> searchResults)
        {
			string relPath;

			if (!String.IsNullOrEmpty(solutionDir) &&
				fileItem.FullName.StartsWith(solutionDir, StringComparison.OrdinalIgnoreCase))
			{
				relPath = "." + fileItem.FullName.Substring(solutionDir.Length);
			}
			else
			{
				relPath = fileItem.FullName;
			}

            FileMatch fileMatch = new FileMatch(fileItem.FullName, relPath, startIndex, matchedFileName);
            FileMatch fileMatchPrev;
            // see if we already have an entry for this file
            searchResults.TryGetValue(fileItem.FullName, out fileMatchPrev);
            bool shouldAdd = true;
            if (fileMatchPrev != null)
            {
                // we could get multiple substring hits on the file.  e.g: search for "foo" in "c:\foo\bar\foo\foofoo.txt",
                // which will find that file 4 times.  We want to keep the metadata for the "best" (most relevant)
                // hit.  Add this hit with corresponding metadata if this is a more relevant match than we previously
                // had for the file, otherwise leave the other one in place
                if (fileMatch.Compare(fileMatchPrev) >= 0)
                {
                    shouldAdd = false;
                }
            }

            if (shouldAdd)
            {
                // store the match for this file
                searchResults[fileItem.FullName] = fileMatch;
            }
        }

        /// <summary>
        /// Adds all the files in this directory, and all files in all subdirectories, to the search results
        /// </summary>
        private void AddAllFilesInSubtreeToSearchResults(DirIndexData dirItem, int startIndex, ref Dictionary<string, FileMatch> searchResults)
        {
            // add all files in this directory
            foreach (FileIndexData fileItem in dirItem.files)
            {
                AddFileToSearchResults(fileItem, startIndex, false, ref searchResults);
            }

            // recursively process all subdirectories
            foreach (DirIndexData subdir in dirItem.subdirs)
            {
                AddAllFilesInSubtreeToSearchResults(subdir, startIndex, ref searchResults);
            }
        }


		public void SetSolutionDir(string pSolutionDir)
		{
			solutionDir = pSolutionDir;
		}
	}

    /// <summary>
    /// Class to hold an individual search result from a substring match on a set of files
    /// </summary>
    public class FileMatch : IComparable<FileMatch>
    {
        public string FileName { get; set; }            // unqualified file name
        public string Directory { get; set; }           // full directory 
		public string RelativePath { get; set; }		// relative path to solution dir
        public string FullName {get;set;}               // full directory + file name
        bool MatchedFileName;                           // true if the search matched the file name, false if it matched a directory
        public int startIndex { get; set; }             // start index within path component at which match begins

        public FileMatch(string theFullName, string relPath, int theStartIndex, bool theMatchedFileName)
        {
            FullName = theFullName;
            FileName = Path.GetFileName(FullName);
			RelativePath = relPath;
            Directory = Path.GetDirectoryName(FullName);
            startIndex = theStartIndex;
            MatchedFileName = theMatchedFileName;
        }

        /// <summary>
        /// Compares the metadata for two matches against substring.  Returns -1 if this object has a more relevant
        /// match, 0 if they're the same, or 1 if the other object has a more relevant match
        /// </summary>
        public int Compare(FileMatch other)
        {
            // were both matches in file name?
            if (MatchedFileName && other.MatchedFileName)
            {
                // if one object started matching at an earlier character in the name, that one should sort first
                if (startIndex != other.startIndex)
                {
                    return (startIndex < other.startIndex ? -1 : 1);
                }

                // sort based on file name
                int ret = String.Compare(FileName, other.FileName, true);
                if (ret != 0)
                    return ret;

                // sort based on full name
                return String.Compare(FullName, other.FullName, true);
            }

            // if one object matched on file name and the other matched
            // on a directory name, whichever matched on file name is more relevant
            if (MatchedFileName && !other.MatchedFileName)
                return -1;
            if (!MatchedFileName && other.MatchedFileName)
                return 1;

            // sort based on full name
            return String.Compare(FullName, other.FullName, true);
        }

        int IComparable<FileMatch>.CompareTo(FileMatch other)
        {
            return Compare(other);
        }
    }

    /// <summary>
    /// Abstract base class for file & directory data to store in index
    /// </summary>
    public abstract class IndexData
    {   
        // Note: Name & FullName contain redundant data (you can compute Name from FullName) but we need to reference Name often enough
        // that it's a perf win to cache it separately
        public string FullName;             // full name of file or directory
        public string Name;                 // name of leaf path component: unqualified file name if it's a file, or leaf directory name if directory
        public int NameStartIndex;          // index within FullName where Name begins

        public IndexData(string theName, string theFullName, int theNameStartIndex)
        {
            Name = theName;
            FullName = theFullName;
            NameStartIndex = theNameStartIndex;
        }
    }

    /// <summary>
    /// Index data about a directory
    /// </summary>
    public class DirIndexData : IndexData
    {
        public List<DirIndexData> subdirs;  // list of immediate subdirectories
        public List<FileIndexData> files;   // list of files in this directory
        public DirIndexData(string theName, string theFullName, int theNameStartIndex) :
            base(theName, theFullName, theNameStartIndex)
        {
            subdirs = new List<DirIndexData>();
            files = new List<FileIndexData>();           
        }
    }

    /// <summary>
    /// Index data about a file
    /// </summary>
    public class FileIndexData : IndexData 
    {
        public FileIndexData(string theName,string theFullName, int theNameStartIndex) :
            base(theName, theFullName, theNameStartIndex)
        {            
        }
    }
}
