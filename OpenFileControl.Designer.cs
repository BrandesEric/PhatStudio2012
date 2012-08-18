namespace PhatStudio
{
    partial class OpenFileControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenFileControl));
            this.TextBoxFilter = new TextBoxEx();
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.GridView = new CustomDataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Directory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewVersionHyperlink = new System.Windows.Forms.LinkLabel();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.AboutButton = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.FacebookBtn = new System.Windows.Forms.Button();
            this.TableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxFilter
            // 
            this.TableLayoutPanel.SetColumnSpan(this.TextBoxFilter, 5);
            this.TextBoxFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxFilter.Location = new System.Drawing.Point(3, 3);
            this.TextBoxFilter.Name = "TextBoxFilter";
            this.TextBoxFilter.Size = new System.Drawing.Size(431, 20);
            this.TextBoxFilter.TabIndex = 1;
            this.TextBoxFilter.TextChanged += new System.EventHandler(this.TextBoxFilter_TextChanged);
            this.TextBoxFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxFilter_KeyDown);
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.AutoSize = true;
            this.TableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel.ColumnCount = 5;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.TableLayoutPanel.Controls.Add(this.TextBoxFilter, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.GridView, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.NewVersionHyperlink, 1, 2);
            this.TableLayoutPanel.Controls.Add(this.StatusLabel, 0, 2);
            this.TableLayoutPanel.Controls.Add(this.AboutButton, 3, 2);
            this.TableLayoutPanel.Controls.Add(this.CloseBtn, 4, 2);
            this.TableLayoutPanel.Controls.Add(this.FacebookBtn, 2, 2);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 3;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.Size = new System.Drawing.Size(437, 431);
            this.TableLayoutPanel.TabIndex = 2;
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.AllowUserToResizeRows = false;
            this.GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.Directory,
            this.FullName});
            this.TableLayoutPanel.SetColumnSpan(this.GridView, 5);
            this.GridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridView.Location = new System.Drawing.Point(3, 29);
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.RowHeadersVisible = false;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(431, 370);
            this.GridView.TabIndex = 0;
            this.GridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellDoubleClick);
            this.GridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridView_CellFormatting);
            this.GridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridView_KeyDown);
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // Directory
            // 
            this.Directory.DataPropertyName = "Directory";
            this.Directory.HeaderText = "Directory";
            this.Directory.Name = "Directory";
            this.Directory.ReadOnly = true;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Full Name";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Visible = false;
            // 
            // NewVersionHyperlink
            // 
            this.NewVersionHyperlink.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NewVersionHyperlink.AutoSize = true;
            this.NewVersionHyperlink.Location = new System.Drawing.Point(121, 405);
            this.NewVersionHyperlink.Name = "NewVersionHyperlink";
            this.NewVersionHyperlink.Padding = new System.Windows.Forms.Padding(5);
            this.NewVersionHyperlink.Size = new System.Drawing.Size(121, 23);
            this.NewVersionHyperlink.TabIndex = 3;
            this.NewVersionHyperlink.TabStop = true;
            this.NewVersionHyperlink.Text = "New version available";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(3, 410);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(66, 13);
            this.StatusLabel.TabIndex = 4;
            this.StatusLabel.Text = "Status Label";
            // 
            // AboutButton
            // 
            this.AboutButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutButton.Image")));
            this.AboutButton.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.AboutButton.Location = new System.Drawing.Point(329, 405);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(23, 23);
            this.AboutButton.TabIndex = 5;
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.Location = new System.Drawing.Point(360, 405);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(74, 23);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // FacebookBtn
            // 
            this.FacebookBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FacebookBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FacebookBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FacebookBtn.Image = ((System.Drawing.Image)(resources.GetObject("FacebookBtn.Image")));
            this.FacebookBtn.Location = new System.Drawing.Point(248, 405);
            this.FacebookBtn.Name = "FacebookBtn";
            this.FacebookBtn.Size = new System.Drawing.Size(74, 23);
            this.FacebookBtn.TabIndex = 6;
            this.FacebookBtn.UseVisualStyleBackColor = true;
            this.FacebookBtn.Click += new System.EventHandler(this.FacebookBtn_Click);
            // 
            // OpenFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPanel);
            this.Name = "OpenFileControl";
            this.Size = new System.Drawing.Size(437, 431);
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBoxEx TextBoxFilter;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        private CustomDataGridView GridView;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.LinkLabel NewVersionHyperlink;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Directory;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Button FacebookBtn;

    }
}
