namespace PhatStudio
{
	partial class ConfigDlg
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigDlg));
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageRelated = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.listBoxRelLeft = new System.Windows.Forms.ListBox();
			this.listBoxRelRight = new System.Windows.Forms.ListBox();
			this.pictureBoxArrow = new System.Windows.Forms.PictureBox();
			this.buttonRelRightRem = new System.Windows.Forms.Button();
			this.buttonRelRightAdd = new System.Windows.Forms.Button();
			this.buttonRelLeftRem = new System.Windows.Forms.Button();
			this.buttonRelLeftAdd = new System.Windows.Forms.Button();
			this.tabPageMisc = new System.Windows.Forms.TabPage();
			this.checkBoxDirectory = new System.Windows.Forms.CheckBox();
			this.checkBoxFacebook = new System.Windows.Forms.CheckBox();
			this.checkBoxRelPaths = new System.Windows.Forms.CheckBox();
			this.buttonAbout = new System.Windows.Forms.Button();
			this.groupBoxMisc = new System.Windows.Forms.GroupBox();
			this.buttonExcRem = new System.Windows.Forms.Button();
			this.buttonExcAdd = new System.Windows.Forms.Button();
			this.listBoxExclude = new System.Windows.Forms.ListBox();
			this.checkBoxHighlight = new System.Windows.Forms.CheckBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.tabPageRelated.SuspendLayout();
			this.tableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrow)).BeginInit();
			this.tabPageMisc.SuspendLayout();
			this.groupBoxMisc.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			resources.ApplyResources(this.tabControl, "tabControl");
			this.tabControl.Controls.Add(this.tabPageRelated);
			this.tabControl.Controls.Add(this.tabPageMisc);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			// 
			// tabPageRelated
			// 
			this.tabPageRelated.Controls.Add(this.tableLayoutPanel);
			resources.ApplyResources(this.tabPageRelated, "tabPageRelated");
			this.tabPageRelated.Name = "tabPageRelated";
			this.tabPageRelated.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel
			// 
			resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
			this.tableLayoutPanel.Controls.Add(this.listBoxRelLeft, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.listBoxRelRight, 3, 0);
			this.tableLayoutPanel.Controls.Add(this.pictureBoxArrow, 2, 0);
			this.tableLayoutPanel.Controls.Add(this.buttonRelRightRem, 4, 1);
			this.tableLayoutPanel.Controls.Add(this.buttonRelRightAdd, 3, 1);
			this.tableLayoutPanel.Controls.Add(this.buttonRelLeftRem, 1, 1);
			this.tableLayoutPanel.Controls.Add(this.buttonRelLeftAdd, 0, 1);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			// 
			// listBoxRelLeft
			// 
			this.tableLayoutPanel.SetColumnSpan(this.listBoxRelLeft, 2);
			resources.ApplyResources(this.listBoxRelLeft, "listBoxRelLeft");
			this.listBoxRelLeft.FormattingEnabled = true;
			this.listBoxRelLeft.Name = "listBoxRelLeft";
			this.listBoxRelLeft.Sorted = true;
			this.listBoxRelLeft.SelectedValueChanged += new System.EventHandler(this.listBoxRelLeft_SelectedValueChanged);
			// 
			// listBoxRelRight
			// 
			this.tableLayoutPanel.SetColumnSpan(this.listBoxRelRight, 2);
			resources.ApplyResources(this.listBoxRelRight, "listBoxRelRight");
			this.listBoxRelRight.FormattingEnabled = true;
			this.listBoxRelRight.Name = "listBoxRelRight";
			this.listBoxRelRight.Sorted = true;
			this.listBoxRelRight.SelectedValueChanged += new System.EventHandler(this.listBoxRelRight_SelectedValueChanged);
			// 
			// pictureBoxArrow
			// 
			resources.ApplyResources(this.pictureBoxArrow, "pictureBoxArrow");
			this.pictureBoxArrow.Image = global::PhatStudio2012.Properties.Resources.arrow;
			this.pictureBoxArrow.Name = "pictureBoxArrow";
			this.pictureBoxArrow.TabStop = false;
			// 
			// buttonRelRightRem
			// 
			resources.ApplyResources(this.buttonRelRightRem, "buttonRelRightRem");
			this.buttonRelRightRem.Image = global::PhatStudio2012.Properties.Resources.DeleteHS;
			this.buttonRelRightRem.Name = "buttonRelRightRem";
			this.buttonRelRightRem.UseVisualStyleBackColor = true;
			this.buttonRelRightRem.Click += new System.EventHandler(this.buttonRelRightRem_Click);
			// 
			// buttonRelRightAdd
			// 
			resources.ApplyResources(this.buttonRelRightAdd, "buttonRelRightAdd");
			this.buttonRelRightAdd.Image = global::PhatStudio2012.Properties.Resources.NewCardHS2;
			this.buttonRelRightAdd.Name = "buttonRelRightAdd";
			this.buttonRelRightAdd.UseVisualStyleBackColor = true;
			this.buttonRelRightAdd.Click += new System.EventHandler(this.buttonRelRightAdd_Click);
			// 
			// buttonRelLeftRem
			// 
			resources.ApplyResources(this.buttonRelLeftRem, "buttonRelLeftRem");
			this.buttonRelLeftRem.Image = global::PhatStudio2012.Properties.Resources.DeleteHS;
			this.buttonRelLeftRem.Name = "buttonRelLeftRem";
			this.buttonRelLeftRem.UseVisualStyleBackColor = true;
			this.buttonRelLeftRem.Click += new System.EventHandler(this.buttonRelLeftRem_Click);
			// 
			// buttonRelLeftAdd
			// 
			this.buttonRelLeftAdd.Image = global::PhatStudio2012.Properties.Resources.NewCardHS2;
			resources.ApplyResources(this.buttonRelLeftAdd, "buttonRelLeftAdd");
			this.buttonRelLeftAdd.Name = "buttonRelLeftAdd";
			this.buttonRelLeftAdd.UseVisualStyleBackColor = true;
			this.buttonRelLeftAdd.Click += new System.EventHandler(this.buttonRelLeftAdd_Click);
			// 
			// tabPageMisc
			// 
			this.tabPageMisc.Controls.Add(this.checkBoxDirectory);
			this.tabPageMisc.Controls.Add(this.checkBoxFacebook);
			this.tabPageMisc.Controls.Add(this.checkBoxRelPaths);
			this.tabPageMisc.Controls.Add(this.buttonAbout);
			this.tabPageMisc.Controls.Add(this.groupBoxMisc);
			this.tabPageMisc.Controls.Add(this.checkBoxHighlight);
			resources.ApplyResources(this.tabPageMisc, "tabPageMisc");
			this.tabPageMisc.Name = "tabPageMisc";
			this.tabPageMisc.UseVisualStyleBackColor = true;
			// 
			// checkBoxDirectory
			// 
			resources.ApplyResources(this.checkBoxDirectory, "checkBoxDirectory");
			this.checkBoxDirectory.Checked = global::PhatStudio.Properties.Settings.Default.ShowDirectory;
			this.checkBoxDirectory.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxDirectory.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PhatStudio.Properties.Settings.Default, "ShowDirectory", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.checkBoxDirectory.Name = "checkBoxDirectory";
			this.checkBoxDirectory.UseVisualStyleBackColor = true;
			// 
			// checkBoxFacebook
			// 
			resources.ApplyResources(this.checkBoxFacebook, "checkBoxFacebook");
			this.checkBoxFacebook.Checked = global::PhatStudio.Properties.Settings.Default.ShowFacebookLink;
			this.checkBoxFacebook.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxFacebook.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PhatStudio.Properties.Settings.Default, "ShowFacebookLink", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.checkBoxFacebook.Name = "checkBoxFacebook";
			this.checkBoxFacebook.UseVisualStyleBackColor = true;
			// 
			// checkBoxRelPaths
			// 
			resources.ApplyResources(this.checkBoxRelPaths, "checkBoxRelPaths");
			this.checkBoxRelPaths.Checked = global::PhatStudio.Properties.Settings.Default.RelativePaths;
			this.checkBoxRelPaths.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PhatStudio.Properties.Settings.Default, "RelativePaths", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.checkBoxRelPaths.Name = "checkBoxRelPaths";
			this.checkBoxRelPaths.UseVisualStyleBackColor = true;
			// 
			// buttonAbout
			// 
			resources.ApplyResources(this.buttonAbout, "buttonAbout");
			this.buttonAbout.Name = "buttonAbout";
			this.buttonAbout.UseVisualStyleBackColor = true;
			this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
			// 
			// groupBoxMisc
			// 
			resources.ApplyResources(this.groupBoxMisc, "groupBoxMisc");
			this.groupBoxMisc.Controls.Add(this.buttonExcRem);
			this.groupBoxMisc.Controls.Add(this.buttonExcAdd);
			this.groupBoxMisc.Controls.Add(this.listBoxExclude);
			this.groupBoxMisc.Name = "groupBoxMisc";
			this.groupBoxMisc.TabStop = false;
			// 
			// buttonExcRem
			// 
			resources.ApplyResources(this.buttonExcRem, "buttonExcRem");
			this.buttonExcRem.Image = global::PhatStudio2012.Properties.Resources.DeleteHS;
			this.buttonExcRem.Name = "buttonExcRem";
			this.buttonExcRem.UseVisualStyleBackColor = true;
			this.buttonExcRem.Click += new System.EventHandler(this.buttonExcRem_Click);
			// 
			// buttonExcAdd
			// 
			resources.ApplyResources(this.buttonExcAdd, "buttonExcAdd");
			this.buttonExcAdd.Image = global::PhatStudio2012.Properties.Resources.NewCardHS2;
			this.buttonExcAdd.Name = "buttonExcAdd";
			this.buttonExcAdd.UseVisualStyleBackColor = true;
			this.buttonExcAdd.Click += new System.EventHandler(this.buttonExcAdd_Click);
			// 
			// listBoxExclude
			// 
			resources.ApplyResources(this.listBoxExclude, "listBoxExclude");
			this.listBoxExclude.FormattingEnabled = true;
			this.listBoxExclude.Name = "listBoxExclude";
			this.listBoxExclude.Sorted = true;
			this.listBoxExclude.SelectedValueChanged += new System.EventHandler(this.listBoxExclude_SelectedValueChanged);
			// 
			// checkBoxHighlight
			// 
			resources.ApplyResources(this.checkBoxHighlight, "checkBoxHighlight");
			this.checkBoxHighlight.Checked = global::PhatStudio.Properties.Settings.Default.HighlightOpenFiles;
			this.checkBoxHighlight.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PhatStudio.Properties.Settings.Default, "highlightOpenFiles", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.checkBoxHighlight.Name = "checkBoxHighlight";
			this.checkBoxHighlight.UseVisualStyleBackColor = true;
			// 
			// buttonOK
			// 
			resources.ApplyResources(this.buttonOK, "buttonOK");
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Image = global::PhatStudio2012.Properties.Resources.ok;
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			resources.ApplyResources(this.buttonCancel, "buttonCancel");
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Image = global::PhatStudio2012.Properties.Resources.cross;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// ConfigDlg
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConfigDlg";
			this.Load += new System.EventHandler(this.ConfigDlg_Load);
			this.tabControl.ResumeLayout(false);
			this.tabPageRelated.ResumeLayout(false);
			this.tableLayoutPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrow)).EndInit();
			this.tabPageMisc.ResumeLayout(false);
			this.tabPageMisc.PerformLayout();
			this.groupBoxMisc.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageRelated;
		private System.Windows.Forms.PictureBox pictureBoxArrow;
		private System.Windows.Forms.ListBox listBoxRelRight;
		private System.Windows.Forms.ListBox listBoxRelLeft;
		private System.Windows.Forms.TabPage tabPageMisc;
		private System.Windows.Forms.Button buttonRelRightAdd;
		private System.Windows.Forms.Button buttonRelRightRem;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Button buttonRelLeftRem;
		private System.Windows.Forms.Button buttonRelLeftAdd;
		private System.Windows.Forms.CheckBox checkBoxHighlight;
		private System.Windows.Forms.GroupBox groupBoxMisc;
		private System.Windows.Forms.Button buttonExcRem;
		private System.Windows.Forms.Button buttonExcAdd;
		private System.Windows.Forms.ListBox listBoxExclude;
		private System.Windows.Forms.Button buttonAbout;
		private System.Windows.Forms.CheckBox checkBoxRelPaths;
        private System.Windows.Forms.CheckBox checkBoxFacebook;
		private System.Windows.Forms.CheckBox checkBoxDirectory;
	}
}