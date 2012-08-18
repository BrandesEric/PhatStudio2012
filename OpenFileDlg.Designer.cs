namespace PhatStudio
{
    partial class OpenFileDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenFileDlg));
            this.OpenFileCtrl = new OpenFileControl();
            this.SuspendLayout();
            // 
            // OpenFileCtrl
            // 
            this.OpenFileCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenFileCtrl.Location = new System.Drawing.Point(0, 0);
            this.OpenFileCtrl.Name = "OpenFileCtrl";
            this.OpenFileCtrl.Size = new System.Drawing.Size(652, 337);
            this.OpenFileCtrl.TabIndex = 0;
            // 
            // OpenFileDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 337);
            this.Controls.Add(this.OpenFileCtrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "OpenFileDlg";
            this.Text = "PhatStudio Open File";
            this.Load += new System.EventHandler(this.OpenFileDlg_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OpenFileDlg_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private OpenFileControl OpenFileCtrl;

    }
}