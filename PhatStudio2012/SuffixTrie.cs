//
// SUFFIXTRIE.CS 
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
using System.Diagnostics;
using System.Collections;

namespace PhatStudio
{
    public class SuffixTrie
    {
        SuffixTrieNode root;        // root of the node tree

        /// <summary>
        /// Constructor
        /// </summary>
        public SuffixTrie()
        {
            root = new SuffixTrieNode(' ');
        }
       
        /// <summary>
        /// Adds a string to the trie to be indexed
        /// </summary>
        public void AddString(string value)
        {
            // Add every possible suffix of the value to the trie.
            // (e.g. for "dwarf", we add: "dwarf", "warf", "arf", "rf", and "f")
            for (int i=0; i < value.Length; i++)
            {
                AddSuffix(value, i);
            }
        }

        /// <summary>
        /// Returns all matches for specified substring
        /// </summary>
        public List<SubstringMatch> FindSubstringMatches(string substr)
        {
            SuffixTrieNode cur = root;

            // for each letter in the substring, walk down the tree to find corresponding nodes to this letter sequence,
            // if the corresponding nodes exist
            for (int i = 0; i < substr.Length && cur != null; i++)
            {
                cur = cur.FindChild(substr[i]);
            }

            // if we found a node that represents the final character in the letter sequence, the values at that node
            // are the strings that contain this substring.  Return that set of values.
            if (cur != null)
            {
                return new List<SubstringMatch>(cur.Values.Values);
            }

            // there is not a sequence in the node tree that corresponds to the sequence of letter in the substring;
            // thus there are no values in the trie that contain this substring.  Return an empty list.
            return new List<SubstringMatch>();
        }

        /// <summary>
        /// Adds suffix of specified value, starting at specified start index
        /// </summary>
        private void AddSuffix(string value, int startIndex)
        {
            SuffixTrieNode cur = root;
            for (int i = startIndex; i < value.Length; i++)
            {
                cur = cur.GetOrCreateChild(value[i],value,startIndex);
            }
        }

        /// <summary>
        /// Render the entire trie: for debugging purposes
        /// </summary>
        internal void Render()
        {
            RenderNode(root, String.Empty);
        }

        /// <summary>
        /// Render a node: for debugging purposes
        /// </summary>
        internal void RenderNode(SuffixTrieNode node, string ancestors)
        {
            List<SubstringMatch> values = new List<SubstringMatch>(node.Values.Values);
            if (values.Count > 0)
            {
                Debug.WriteLine(ancestors + ":");
                foreach (SubstringMatch match in values)
                {
                    Debug.WriteLine("   " + match.Value);
                }
            }

            List<char> keys = new List<char>(node.children.Keys);
            keys.Sort();

            foreach (char c in keys)
            {
                SuffixTrieNode child = node.children[c];
                string ancestorsNext = ancestors;
                if (ancestorsNext != String.Empty)
                {
                    ancestorsNext += '-';
                }
                RenderNode(child, ancestorsNext + c);
            }
        }
    }
        
    public class SubstringMatch : IComparable<SubstringMatch>
    {
        public string Value;
        public int startIndex;

        public SubstringMatch(string theValue, int theStartIndex)
        {
            Value = theValue;
            startIndex = theStartIndex;
        }

        int IComparable<SubstringMatch>.CompareTo(SubstringMatch other)
        {
            return Value.CompareTo(other.Value);
        }
    }

    /// <summary>
    /// A node in a suffix trie
    /// </summary>
    class SuffixTrieNode
    {
        // all children of this node
        public Dictionary<char,SuffixTrieNode> children;                

        // values which contain the sequence of characters composed by travelling from the root to this node
        public Dictionary<string,SubstringMatch> Values { get; private set; }        

        /// <summary>
        /// Constructor
        /// </summary>
        public SuffixTrieNode(char theC)
        {
            children = new Dictionary<char,SuffixTrieNode>();
            Values = new Dictionary<string, SubstringMatch>();
        }

        /// <summary>
        /// Returns a child node with the specified character, containing a match with specified value and start index.  
        /// Returns an existing node if there is one, otherwise it creates it.
        /// </summary>
        public SuffixTrieNode GetOrCreateChild(char c, string value, int startIndex)
        {
            // do we already have a child for this character?
            SuffixTrieNode node = FindChild(c);            
            if (node == null)
            {
                node = new SuffixTrieNode(c);
                children.Add(c, node);
            }

            // does this value exist in this node already?
            SubstringMatch existing;
            if (!node.Values.TryGetValue(value, out existing))
            {
                node.Values.Add(value, new SubstringMatch(value, startIndex));
            }

            return node;
        }

        /// <summary>
        /// Returns child node matching specified character, or null if it does not exist.
        /// </summary>
        public SuffixTrieNode FindChild(char c)
        {
            SuffixTrieNode ret;
            children.TryGetValue(c, out ret);
            return ret;
        }
    }
}
