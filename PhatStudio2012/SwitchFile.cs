
using System.Collections.Generic;
using System.IO;
using EnvDTE;
using System;
using System.Globalization;

namespace PhatStudio
{
	static class SwitchFile
	{
		static Dictionary<string, List<string>> Dict = new Dictionary<string, List<string>>();

		static SwitchFile()
		{
			// This static contructor might be called after settings have been loaded
			// so load them now
			ReloadDictionary();

			Properties.Settings.Default.SettingsLoaded += SettingsLoadedEventHandler;
			Properties.Settings.Default.SettingsSaving += SettingsSavingEventHandler;
		}

		public static void SettingsLoadedEventHandler(object sender, System.Configuration.SettingsLoadedEventArgs e)
		{
			ReloadDictionary();
		}

		public static void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ReloadDictionary();
		}

		/// <summary>
		/// Read in strings of the form "LEFT|RIGHT" and add them to the config dialogs dictionary
		/// This code exists almost identically in ConfigDlg
		/// It is called from Settings.OnLoaded/OnSaving
		/// </summary>
		public static void ReloadDictionary()
		{
			Dict.Clear();

			foreach (string str in Properties.Settings.Default.RelatedExtensions)
			{
				String[] split = str.Split(new char[] { '|' });

				if (split.Length == 2)
				{
					string key = split[0].ToLower(CultureInfo.InvariantCulture);
					string value = split[1].ToLower(CultureInfo.InvariantCulture);

					List<string> list;
					if (!Dict.TryGetValue(key, out list))	// if this is the first entry where (LEFT == key)
					{
						list = new List<string>();
						Dict.Add(key, list);
					}

					list.Add(value);
				}
			}
		}

		/// <summary>
		/// returns string in lower case after first point
		/// Path.GetExtension() returns the string after the last point including the point
		/// </summary>
		private static string GetExtensionExt(string fname)
		{
			int index = fname.IndexOf('.');				// returns -1 if not found

			if (index <= 0)
				return null;

			string ext = fname.Substring(index + 1);	// do not include the point

			return ext.ToLower(CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Change string after the first point
		/// Path.ChangeExtension() changes the string after the last point
		/// </summary>
		private static string ChangeExtensionExt(string fname, string ext_new)
		{
			int index = fname.IndexOf('.');				// returns -1 if not found

			if (index <= 0)
				return null;

			return fname.Substring(0, index + 1) + ext_new;
		}
		
		/// <summary>
		/// See if there is a related file we can switch to
		/// 
		/// We are happy if the file has a supported ending
		/// There's no check whether there are any related files we can switch to or not
		/// </summary>
		public static bool SwitchPossible(EnvDTE.Document document)
		{
			// We need an open file to be able to switch
			if (document == null)
				return false;

			string ext = GetExtensionExt(document.Name);

			return (Dict.ContainsKey(ext));
		}


		/// <summary>
		/// Find corresponding file and open it
		/// 
		/// First, get the list of possible file endings
		/// Then, look in same folder
		/// Then, look in project folder and use the first match
		/// </summary>
		public static void SwitchToRelated(EnvDTE.Document document)
		{
            AutoUpdate.OnFeatureUsed();

			// This should never occur, but let's make sure it doesn't crash
			if (document == null)
				return; 
			
			string path = document.Path;
			string name = document.Name;
			string ext = GetExtensionExt(name);
			string name_new = null;

			List<string> list;

			// If the following fails, we don't know what we're looking for
			// There is (surprisingly!) no entry in the dictionary for that ending
			if (!Dict.TryGetValue(ext, out list))
				return;

			// First, look in the same folder and try all the endings we have
			foreach (string ext_new in list)
			{
				name_new = ChangeExtensionExt(name, ext_new);

				if (File.Exists(path + name_new))
				{
					document.DTE.ItemOperations.OpenFile(path + name_new, Constants.vsViewKindAny);
					return;
				}
			}

			Project prj = document.ProjectItem.ContainingProject;

			// If the file does not belong to a project, we don't know where to look
			if (prj == null)
				return;

			// Then, look in project folder and use the first match
			foreach (string ext_new in list)
			{
				name_new = Path.ChangeExtension(name, ext_new);

				foreach (ProjectItem projectItem in prj.ProjectItems)
				{
					foreach (ProjectItem subProjectItem in projectItem.ProjectItems)
					{
						if (subProjectItem.Name == name_new)
						{
							// Use the first file with equal name
							subProjectItem.Open(Constants.vsViewKindCode);
							return;
						}
					}
				}
			}
		}
	}
}
