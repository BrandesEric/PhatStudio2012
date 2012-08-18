using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace PhatStudio
{
	public partial class ConfigDlg : Form
	{
		Dictionary<string, List<string>> Dict = new Dictionary<string, List<string>>();

		public ConfigDlg()
		{
			InitializeComponent();
		}

		private void ConfigDlg_Load(object sender, EventArgs e)
		{
			// if the entry is empty then the settings object is null
			if (Properties.Settings.Default.RelatedExtensions == null)
				Properties.Settings.Default.RelatedExtensions = new System.Collections.Specialized.StringCollection();

			// Read in strings of the form "LEFT|RIGHT" and add them to the config dialogs dictionary
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
						listBoxRelLeft.Items.Add(key);
					}

					list.Add(value);
				}
			}

			// if the entry is empty then the settings object is null
			if (Properties.Settings.Default.ExcludedExtensions == null)
				Properties.Settings.Default.ExcludedExtensions = new System.Collections.Specialized.StringCollection();

			foreach (string str in Properties.Settings.Default.ExcludedExtensions)
			{
				listBoxExclude.Items.Add(str.ToLower(CultureInfo.InvariantCulture));
			}

		}

		// listBoxRelLeft related Events
		private void listBoxRelLeft_SelectedValueChanged(object sender, EventArgs e)
		{
			listBoxRelRight.Items.Clear();

			// For some reason SelectedValueChanged is not executed if Clear() is called
			// Thus, we deactivate the "Remove" button manually
			buttonRelRightRem.Enabled = false;

			// We can add items to a list only if a list is selected
			buttonRelRightAdd.Enabled = (listBoxRelLeft.SelectedItem != null);

			if (listBoxRelLeft.SelectedItem == null)
				return;

			foreach (string str in Dict[listBoxRelLeft.SelectedItem.ToString()])
			{
				listBoxRelRight.Items.Add(str);
			}
			
			buttonRelLeftRem.Enabled = (listBoxRelLeft.SelectedItem != null);
		}

		private void buttonRelLeftAdd_Click(object sender, EventArgs e)
		{
			InputBox box = new InputBox("Extension to add");
			if (box.ShowDialog() == DialogResult.OK)
			{
				string str = box.GetInputString();
				if (str.StartsWith(".", StringComparison.OrdinalIgnoreCase))
					str = str.Substring(1);			// Skip the '.'

				str = str.ToLower(CultureInfo.InvariantCulture);

				if (!listBoxRelLeft.Items.Contains(str))
				{				
					listBoxRelLeft.Items.Add(str);
					Dict.Add(str, new List<string>());
				}
			
				listBoxRelLeft.SelectedItem = str;
			}
		}

		private void buttonRelLeftRem_Click(object sender, EventArgs e)
		{
			// just in case
			if (listBoxRelLeft.SelectedItem == null)
				return;

			string key = listBoxRelLeft.SelectedItem.ToString();

			Dict.Remove(key);
			listBoxRelLeft.Items.Remove(key);
		}

		// listBoxRelRight related Events
		private void buttonRelRightRem_Click(object sender, EventArgs e)
		{
			// just in case
			if (listBoxRelLeft.SelectedItem == null || listBoxRelRight.SelectedItem == null)
				return;

			string key = listBoxRelLeft.SelectedItem.ToString();
			string val = listBoxRelRight.SelectedItem.ToString();

			Dict[key].Remove(val);
			listBoxRelRight.Items.Remove(val);
		}

		private void buttonRelRightAdd_Click(object sender, EventArgs e)
		{
			if (listBoxRelLeft.SelectedItem == null)
				return;

			InputBox box = new InputBox("Extension to add");
			if (box.ShowDialog() == DialogResult.OK)
			{
				string str = box.GetInputString();
				if (str.StartsWith(".", StringComparison.OrdinalIgnoreCase))
					str = str.Substring(1);			// Skip the '.'

				str = str.ToLower(CultureInfo.InvariantCulture);

				if (!listBoxRelRight.Items.Contains(str))
				{
					Dict[listBoxRelLeft.SelectedItem.ToString()].Add(str);
					listBoxRelRight.Items.Add(str);
				}

				listBoxRelRight.SelectedItem = str;
			}
		}

		private void listBoxRelRight_SelectedValueChanged(object sender, EventArgs e)
		{
			// We can remove an item from a list only if it is selected
			buttonRelRightRem.Enabled = (listBoxRelRight.SelectedItem != null);
		}

		// listBoxExclude related Events
		private void buttonExcAdd_Click(object sender, EventArgs e)
		{
			InputBox box = new InputBox("Extension to exclude");
			if (box.ShowDialog() == DialogResult.OK)
			{
				string str = box.GetInputString();
				if (str.StartsWith(".", StringComparison.OrdinalIgnoreCase))
					str = str.Substring(1);			// Skip the '.'
				
				str = str.ToLower(CultureInfo.InvariantCulture);

				if (!listBoxExclude.Items.Contains(str))
					listBoxExclude.Items.Add(str);

				listBoxExclude.SelectedItem = str;
			}
		}

		private void buttonExcRem_Click(object sender, EventArgs e)
		{
			listBoxExclude.Items.Remove(listBoxExclude.SelectedItem);
		}

		private void listBoxExclude_SelectedValueChanged(object sender, EventArgs e)
		{
			// We can remove an item from a list only if it is selected
			buttonExcRem.Enabled = (listBoxExclude.SelectedItem != null);
		}

		private void buttonAbout_Click(object sender, EventArgs e)
		{
			AboutBox aboutBox = new AboutBox();
			aboutBox.ShowDialog();
		}

		// the OK button has DialogResult.OK so the dialog is closed automatically
		// but we need to copy the settings from the dialog GUI back to Properties.Settings.Default
		private void buttonOK_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.ExcludedExtensions.Clear();
			foreach (string str in listBoxExclude.Items)
			{
				Properties.Settings.Default.ExcludedExtensions.Add(str);
			}

			// Add Related-Extension-Strings in the Format "LEFT|RIGHT" to the StringCollection in "Settings"
			Properties.Settings.Default.RelatedExtensions.Clear();
			foreach (KeyValuePair<string, List<string>> kvp in Dict)
			{
				foreach (string value in kvp.Value)
				{
					Properties.Settings.Default.RelatedExtensions.Add(kvp.Key + "|" + value);
				}
			}

			Properties.Settings.Default.Save();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.Reload();
		}
	}
}
