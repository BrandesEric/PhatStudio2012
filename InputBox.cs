using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PhatStudio
{
	public class InputBox : Form
	{
		private TextBox textBox;
		private Button buttonOK;
		private Button buttonCancel;
		private System.ComponentModel.Container components = null;

		public InputBox(string caption)
		{
			InitializeComponent();

			Text = caption;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.textBox = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox
			// 
			this.textBox.Location = new System.Drawing.Point(16, 16);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(256, 20);
			this.textBox.TabIndex = 0;
			this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Image = global::PhatStudio.Properties.Resources.ok;
			this.buttonOK.Location = new System.Drawing.Point(278, 15);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(20, 20);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Image = global::PhatStudio.Properties.Resources.cross;
			this.buttonCancel.Location = new System.Drawing.Point(304, 15);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(20, 20);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// InputBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(334, 53);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.textBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InputBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "<Caption>";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void textBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				DialogResult = DialogResult.OK;
				Close();
			}

			if (e.KeyCode == Keys.Escape)
			{
				DialogResult = DialogResult.Abort;
				Close();
			}
		}

		public string GetInputString()
		{
			return textBox.Text;
		}
	}
}
