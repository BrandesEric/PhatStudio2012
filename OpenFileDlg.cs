//
// OPENFILEDLG.CS 
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
using System.Windows.Forms;

namespace PhatStudio
{
    public partial class OpenFileDlg : Form
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public OpenFileDlg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializer
        /// </summary>
        public void Init(EnvDTE80.DTE2 theVsAppObject, FileIndex theFileIndex)
        {
            // Initialize the control we host that does the actual work
            OpenFileCtrl.Init(theVsAppObject, theFileIndex, true);
        }

        /// <summary>
        /// Called when the dialog loads
        /// </summary>
        private void OpenFileDlg_Load(object sender, EventArgs e)
        {    
            // initialize ourself from stored settings
            this.Size = Properties.Settings.Default.MySize;
            if (Properties.Settings.Default["MyLoc"] != null)
            {
                this.Location = Properties.Settings.Default.MyLoc;
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterParent;
            }            
            this.WindowState = Properties.Settings.Default.MyState;
        }

        /// <summary>
        /// Called when the dialog closes
        /// </summary>
        private void OpenFileDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save ourself to stored settings
            Properties.Settings.Default.MyState = this.WindowState;

			if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.MySize = this.Size;
                Properties.Settings.Default.MyLoc = this.Location;
            }
            else
            {
                Properties.Settings.Default.MySize = this.RestoreBounds.Size;
                Properties.Settings.Default.MyLoc = this.RestoreBounds.Location;
            }
        }
    }
}
