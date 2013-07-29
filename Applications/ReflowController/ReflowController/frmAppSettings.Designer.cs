namespace ReflowController
{
    partial class frmAppSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FirmwareLoaderPathLabel = new System.Windows.Forms.Label();
            this.BrowseFirmwarePathButton = new System.Windows.Forms.Button();
            this.FirmwareLoaderStatusLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ProgrammerStatusLabel = new System.Windows.Forms.Label();
            this.ProgrammerLoaderPathLabel = new System.Windows.Forms.Label();
            this.BrowseProgrammerButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.EditorStatusLabel = new System.Windows.Forms.Label();
            this.EditorLoaderPathLabel = new System.Windows.Forms.Label();
            this.BrowseEditorButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Firmware Loader Path: ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.FirmwareLoaderPathLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.FirmwareLoaderStatusLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BrowseFirmwarePathButton, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(363, 67);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // FirmwareLoaderPathLabel
            // 
            this.FirmwareLoaderPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FirmwareLoaderPathLabel.AutoEllipsis = true;
            this.FirmwareLoaderPathLabel.BackColor = System.Drawing.Color.White;
            this.FirmwareLoaderPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.FirmwareLoaderPathLabel, 4);
            this.FirmwareLoaderPathLabel.Location = new System.Drawing.Point(3, 4);
            this.FirmwareLoaderPathLabel.Name = "FirmwareLoaderPathLabel";
            this.FirmwareLoaderPathLabel.Size = new System.Drawing.Size(357, 23);
            this.FirmwareLoaderPathLabel.TabIndex = 12;
            this.FirmwareLoaderPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BrowseFirmwarePathButton
            // 
            this.BrowseFirmwarePathButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BrowseFirmwarePathButton.Location = new System.Drawing.Point(276, 38);
            this.BrowseFirmwarePathButton.Name = "BrowseFirmwarePathButton";
            this.BrowseFirmwarePathButton.Size = new System.Drawing.Size(81, 23);
            this.BrowseFirmwarePathButton.TabIndex = 0;
            this.BrowseFirmwarePathButton.Text = "Browse";
            this.BrowseFirmwarePathButton.UseVisualStyleBackColor = true;
            this.BrowseFirmwarePathButton.Click += new System.EventHandler(this.BrowseFirmwarePathButton_Click);
            // 
            // FirmwareLoaderStatusLabel
            // 
            this.FirmwareLoaderStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FirmwareLoaderStatusLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.FirmwareLoaderStatusLabel, 3);
            this.FirmwareLoaderStatusLabel.Location = new System.Drawing.Point(3, 43);
            this.FirmwareLoaderStatusLabel.Name = "FirmwareLoaderStatusLabel";
            this.FirmwareLoaderStatusLabel.Size = new System.Drawing.Size(264, 13);
            this.FirmwareLoaderStatusLabel.TabIndex = 13;
            this.FirmwareLoaderStatusLabel.Text = "Status:";
            this.FirmwareLoaderStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OkButton.Location = new System.Drawing.Point(291, 3);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(81, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(12, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 92);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Programmer Path: ";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.ProgrammerStatusLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ProgrammerLoaderPathLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BrowseProgrammerButton, 3, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(363, 67);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ProgrammerStatusLabel
            // 
            this.ProgrammerStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgrammerStatusLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.ProgrammerStatusLabel, 3);
            this.ProgrammerStatusLabel.Location = new System.Drawing.Point(3, 43);
            this.ProgrammerStatusLabel.Name = "ProgrammerStatusLabel";
            this.ProgrammerStatusLabel.Size = new System.Drawing.Size(264, 13);
            this.ProgrammerStatusLabel.TabIndex = 14;
            this.ProgrammerStatusLabel.Text = "Status:";
            this.ProgrammerStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProgrammerLoaderPathLabel
            // 
            this.ProgrammerLoaderPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgrammerLoaderPathLabel.AutoEllipsis = true;
            this.ProgrammerLoaderPathLabel.BackColor = System.Drawing.Color.White;
            this.ProgrammerLoaderPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel2.SetColumnSpan(this.ProgrammerLoaderPathLabel, 4);
            this.ProgrammerLoaderPathLabel.Location = new System.Drawing.Point(3, 4);
            this.ProgrammerLoaderPathLabel.Name = "ProgrammerLoaderPathLabel";
            this.ProgrammerLoaderPathLabel.Size = new System.Drawing.Size(357, 23);
            this.ProgrammerLoaderPathLabel.TabIndex = 12;
            this.ProgrammerLoaderPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BrowseProgrammerButton
            // 
            this.BrowseProgrammerButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BrowseProgrammerButton.Location = new System.Drawing.Point(276, 38);
            this.BrowseProgrammerButton.Name = "BrowseProgrammerButton";
            this.BrowseProgrammerButton.Size = new System.Drawing.Size(81, 23);
            this.BrowseProgrammerButton.TabIndex = 0;
            this.BrowseProgrammerButton.Text = "Browse";
            this.BrowseProgrammerButton.UseVisualStyleBackColor = true;
            this.BrowseProgrammerButton.Click += new System.EventHandler(this.BrowseProgrammerButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Location = new System.Drawing.Point(12, 206);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(375, 92);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Editor Path: ";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.EditorStatusLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.EditorLoaderPathLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.BrowseEditorButton, 3, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(363, 67);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // EditorStatusLabel
            // 
            this.EditorStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorStatusLabel.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.EditorStatusLabel, 3);
            this.EditorStatusLabel.Location = new System.Drawing.Point(3, 43);
            this.EditorStatusLabel.Name = "EditorStatusLabel";
            this.EditorStatusLabel.Size = new System.Drawing.Size(264, 13);
            this.EditorStatusLabel.TabIndex = 14;
            this.EditorStatusLabel.Text = "Status:";
            this.EditorStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EditorLoaderPathLabel
            // 
            this.EditorLoaderPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorLoaderPathLabel.AutoEllipsis = true;
            this.EditorLoaderPathLabel.BackColor = System.Drawing.Color.White;
            this.EditorLoaderPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel3.SetColumnSpan(this.EditorLoaderPathLabel, 4);
            this.EditorLoaderPathLabel.Location = new System.Drawing.Point(3, 4);
            this.EditorLoaderPathLabel.Name = "EditorLoaderPathLabel";
            this.EditorLoaderPathLabel.Size = new System.Drawing.Size(357, 23);
            this.EditorLoaderPathLabel.TabIndex = 12;
            this.EditorLoaderPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BrowseEditorButton
            // 
            this.BrowseEditorButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BrowseEditorButton.Location = new System.Drawing.Point(276, 38);
            this.BrowseEditorButton.Name = "BrowseEditorButton";
            this.BrowseEditorButton.Size = new System.Drawing.Size(81, 23);
            this.BrowseEditorButton.TabIndex = 0;
            this.BrowseEditorButton.Text = "Browse";
            this.BrowseEditorButton.UseVisualStyleBackColor = true;
            this.BrowseEditorButton.Click += new System.EventHandler(this.BrowseEditorButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.OkButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 304);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(375, 31);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // frmAppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 338);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAppSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Application Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BrowseFirmwarePathButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label FirmwareLoaderPathLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label ProgrammerLoaderPathLabel;
        private System.Windows.Forms.Button BrowseProgrammerButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label EditorLoaderPathLabel;
        private System.Windows.Forms.Button BrowseEditorButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label FirmwareLoaderStatusLabel;
        private System.Windows.Forms.Label ProgrammerStatusLabel;
        private System.Windows.Forms.Label EditorStatusLabel;
    }
}