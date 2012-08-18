//
// OPENFILECONTROL.CS 
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
using System.Reflection;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;
using System.ComponentModel;

namespace PhatStudio
{
    public partial class OpenFileControl : UserControl
    {
        DTE2 vsAppObject;           // Visual Studio application object
        FileIndex fileIndex;        // file index of files in the solution
        bool isModal;               // is this control hosted in a modal dialog or in a tool window

        static private string lastFilter = "";

        /// <summary>
        /// Constructor
        /// </summary>
        public OpenFileControl()
        {
            InitializeComponent();
            GridView.AutoGenerateColumns = false;
            GridView.AutoResizeColumns();

            AutoUpdate.OnFeatureUsed();

			Properties.Settings.Default.PropertyChanged += new PropertyChangedEventHandler(SettingsPropertyChanged);
        }

        /// <summary>
        /// Initializer
        /// </summary>
        public void Init(DTE2 theVsAppObject,FileIndex theFileIndex,bool theIsModal)
        {
            vsAppObject = theVsAppObject;
            fileIndex = theFileIndex;
            isModal = theIsModal;

            NewVersionHyperlink.Visible = false;
            NewVersionHyperlink.LinkClicked += new LinkLabelLinkClickedEventHandler(NewVersionHyperlink_LinkClicked);            
            if (!isModal)
            {                
                CloseBtn.Visible = false;
                TableLayoutPanel.ColumnStyles[4].Width = 0;
            }

            // set the filter string to whatever it was the last time the window was open
            SetFilter(lastFilter);
            TextBoxFilter.Text = lastFilter;
            TextBoxFilter.SelectAll();

            fileIndex.FileListChanged += new EventHandler(OnFileListChanged_Thread);

            // do we have downloaded information on latest available version?
            if (!String.IsNullOrEmpty(AutoUpdate.LatestVersion) && !String.IsNullOrEmpty(AutoUpdate.DownloadUrl))
            {
                try
                {
                    // compare the running version we are to the latest available version
                    Version versionLatest = new Version(AutoUpdate.LatestVersion);
                    Version versionRunning = Assembly.GetExecutingAssembly().GetName().Version;
                    if (versionLatest > versionRunning)
                    {
                        // if latest version is more recent, show hyperlink to get it
                        NewVersionHyperlink.Visible = true;
                    }
                }
                catch { }
            }

            if (isModal)
            {
                // if we're modal (and thus have a close button), set our parent's cancel button action to be our close button
                ((Form)Parent).CancelButton = CloseBtn;
            }

			UpdateDirectoryVisibility();
			UpdateGridViewContent();
			UpdateFacebookLinkVisibility();

            // give search string text box input focus
            ActiveControl = TextBoxFilter;
        }

        /// <summary>
        /// Called when the text in the search string text box changes
        /// </summary>
        private void TextBoxFilter_TextChanged(object sender, EventArgs e)
        {
            // change the filter for the filename search results
            SetFilter(TextBoxFilter.Text);
        }

        /// <summary>
        /// Called when a file in the list is double-clicked
        /// </summary>
        private void GridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // open file corresponding to grid view selection
            OpenSelectedFiles();
        }

        /// <summary>
        /// Called when a key is pressed in the text box
        /// </summary>
        private void TextBoxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // open files (usually just one) 
                OpenSelectedFiles();
            }
            else if (ShouldForwardKeyEvent(e))
            {
                // send arrow key etc events to grid view
                GridView.MyOnKeyDown(e);
            }
        }

        /// <summary>
        /// Called when a grid view cell is being formatted
        /// </summary>
        private void GridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = GridView.Rows[e.RowIndex];
            // set the tooltip
            row.Cells[e.ColumnIndex].ToolTipText = (string)row.Cells["FullName"].Value;

			if (Properties.Settings.Default.HighlightOpenFiles)
			{
				// change background color if file is already open
				if (vsAppObject.ItemOperations.IsFileOpen((string) row.Cells["FullName"].Value, Constants.vsViewKindAny))
				{
					row.Cells[e.ColumnIndex].Style.BackColor = System.Drawing.Color.LightGreen;
					row.Cells[e.ColumnIndex].Style.SelectionBackColor = System.Drawing.Color.Black; 
				}
				else
				{
					row.Cells[e.ColumnIndex].Style.BackColor = System.Drawing.Color.Empty;
					row.Cells[e.ColumnIndex].Style.SelectionBackColor = System.Drawing.Color.Empty;
				}
			}
		}

        /// <summary>
        /// Called when the "new version available" hyperlink is clicked
        /// </summary>
        void NewVersionHyperlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!String.IsNullOrEmpty(AutoUpdate.DownloadUrl))
            {
                // shell exec the URL, which will launch the default browser
                System.Diagnostics.Process.Start(AutoUpdate.DownloadUrl);
            }
        }

        /// <summary>
        /// Called when the close button is pressed
        /// </summary>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Sets the search string filter and updates the filename search results
        /// </summary>
        private void SetFilter(string filter)
        {
            // get the list of file names that contain the search string anywhere in their filename or path
            List<FileMatch> fileMatches = fileIndex.FindSubstringMatches(filter);

            // bind that list to the grid view
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = fileMatches;
            GridView.DataSource = bindingSource;

            // set the status label text appropriately
            StatusLabel.Text = fileMatches.Count == 1 ? "1 file" : String.Format("{0} files", fileMatches.Count);

            // remember the most recent filter string for next time this window is opened
            lastFilter = filter;
        }

        /// <summary>
        /// Opens the file in the IDE corresponding to the currently selected grid view item
        /// </summary>
		private void OpenSelectedFiles()
		{
            AutoUpdate.OnFeatureUsed();
			foreach (DataGridViewRow row in GridView.SelectedRows)
			{
				// open file in IDE
				vsAppObject.ItemOperations.OpenFile((string)row.Cells["FullName"].Value, Constants.vsViewKindAny);
			}

			// if we're a modal dialog, we've done our job, dismiss ourselves
			if (GridView.SelectedRows.Count > 0 && isModal)
			{
				Close();
			}
		}

        /// <summary>
        /// Closes the window we're in.  Valid only when running inside modal dialog.
        /// </summary>
        private void Close()
        {
            ((Form)Parent).Close();
        }

        /// <summary>
        /// Returns if key event should be forwarded from text box to grid view
        /// </summary>
        bool ShouldForwardKeyEvent(KeyEventArgs e)
        {
            // forward vertical scrolling keys, which are useless in the textbox anyway
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.PageUp:
                case Keys.PageDown:
                    return true;
                default:
                    return false;
            }            
        }

        /// <summary>
        /// Called when the file list changes
        /// </summary>
        private void OnFileListChanged(object source, EventArgs e)
        {
            // refresh contents of grid view
            SetFilter(TextBoxFilter.Text);
        }

        private void OnFileListChanged_Thread(object source, EventArgs e)
        {
            if (Visible)
            {
                Invoke(new EventHandler(OnFileListChanged));
            }            
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

		private void GridView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				// open files 
				OpenSelectedFiles();
			}
		}

        private void FacebookBtn_Click(object sender, EventArgs e)
        {
            const string facebookUrl = "http://www.facebook.com/pages/PhatStudio/104277482962256?v=app_4949752878";
            // shell exec the URL, which will launch the default browser
            System.Diagnostics.Process.Start(facebookUrl);            
        }

		private void SettingsPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			UpdateDirectoryVisibility();
			UpdateGridViewContent();
			UpdateFacebookLinkVisibility();
		}

		private void UpdateGridViewContent()
		{
			if (Properties.Settings.Default.RelativePaths == true)
			{
				Directory.DataPropertyName = "RelativePath";
			}
			else
			{
				Directory.DataPropertyName = "Directory";
			}
		}

		private void UpdateFacebookLinkVisibility()
		{
			FacebookBtn.Visible = Properties.Settings.Default.ShowFacebookLink;
		}

		private void UpdateDirectoryVisibility()
		{
			bool visible = Properties.Settings.Default.ShowDirectory;

			Directory.Visible = visible;
			GridView.AllowUserToResizeColumns = visible;
		}
    }

    /// <summary>
    /// Inherited class from DataGridView to expose a member to be able to send it key events
    /// </summary>
    public class CustomDataGridView : DataGridView
    {
		public void MyOnKeyDown(KeyEventArgs e)
		{
			OnKeyDown(e);
		}
	}
}
