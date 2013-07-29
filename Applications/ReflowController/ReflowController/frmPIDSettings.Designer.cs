namespace ReflowController
{
    partial class frmPIDSettings
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.createProfileCancelButton = new System.Windows.Forms.Button();
            this.createProfileSaveButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.createProfileCycleTimeComboBox = new System.Windows.Forms.ComboBox();
            this.createProfileCycleTimeLabel = new System.Windows.Forms.Label();
            this.createProfileNameLabel = new System.Windows.Forms.Label();
            this.createProfileKdLabel = new System.Windows.Forms.Label();
            this.createProfileKdComboBox = new System.Windows.Forms.ComboBox();
            this.createProfileKiLabel = new System.Windows.Forms.Label();
            this.createProfileKiComboBox = new System.Windows.Forms.ComboBox();
            this.createProfileKpLabel = new System.Windows.Forms.Label();
            this.createProfileKpComboBox = new System.Windows.Forms.ComboBox();
            this.createProfileTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.editProfileCancelButton = new System.Windows.Forms.Button();
            this.editProfileDeleteButton = new System.Windows.Forms.Button();
            this.editProfileSaveButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.editProfileCycleTimeLabel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxProfileName = new System.Windows.Forms.ComboBox();
            this.editProfileNamelabel = new System.Windows.Forms.Label();
            this.editProfileKdLabel = new System.Windows.Forms.Label();
            this.editProfileComboBoxKd = new System.Windows.Forms.ComboBox();
            this.editProfileKiLabel = new System.Windows.Forms.Label();
            this.editProfileComboBoxKi = new System.Windows.Forms.ComboBox();
            this.editProfileKpLabel = new System.Windows.Forms.Label();
            this.editProfileComboBoxKp = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(8, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(279, 324);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(271, 298);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Create Profile";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.createProfileCancelButton);
            this.flowLayoutPanel1.Controls.Add(this.createProfileSaveButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 249);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(259, 43);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // createProfileCancelButton
            // 
            this.createProfileCancelButton.Location = new System.Drawing.Point(176, 3);
            this.createProfileCancelButton.Name = "createProfileCancelButton";
            this.createProfileCancelButton.Size = new System.Drawing.Size(80, 38);
            this.createProfileCancelButton.TabIndex = 1;
            this.createProfileCancelButton.Text = "Cancel";
            this.createProfileCancelButton.UseVisualStyleBackColor = true;
            this.createProfileCancelButton.Click += new System.EventHandler(this.createProfileCancelButton_Click);
            // 
            // createProfileSaveButton
            // 
            this.createProfileSaveButton.Location = new System.Drawing.Point(90, 3);
            this.createProfileSaveButton.Name = "createProfileSaveButton";
            this.createProfileSaveButton.Size = new System.Drawing.Size(80, 38);
            this.createProfileSaveButton.TabIndex = 0;
            this.createProfileSaveButton.Text = "Save";
            this.createProfileSaveButton.UseVisualStyleBackColor = true;
            this.createProfileSaveButton.Click += new System.EventHandler(this.createProfileSaveButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.06564F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.93436F));
            this.tableLayoutPanel1.Controls.Add(this.createProfileCycleTimeComboBox, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.createProfileCycleTimeLabel, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.createProfileNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.createProfileKdLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.createProfileKdComboBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.createProfileKiLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.createProfileKiComboBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.createProfileKpLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.createProfileKpComboBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.createProfileTextBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.6134F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.594119F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.75126F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.594119F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.75126F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.594119F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.75126F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.595779F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.75468F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 237);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // createProfileCycleTimeComboBox
            // 
            this.createProfileCycleTimeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.createProfileCycleTimeComboBox.FormattingEnabled = true;
            this.createProfileCycleTimeComboBox.Location = new System.Drawing.Point(99, 205);
            this.createProfileCycleTimeComboBox.Name = "createProfileCycleTimeComboBox";
            this.createProfileCycleTimeComboBox.Size = new System.Drawing.Size(157, 21);
            this.createProfileCycleTimeComboBox.TabIndex = 4;
            this.createProfileCycleTimeComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.createProfileCycleTimeComboBox_KeyDown);
            // 
            // createProfileCycleTimeLabel
            // 
            this.createProfileCycleTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.createProfileCycleTimeLabel.AutoSize = true;
            this.createProfileCycleTimeLabel.Location = new System.Drawing.Point(3, 209);
            this.createProfileCycleTimeLabel.Name = "createProfileCycleTimeLabel";
            this.createProfileCycleTimeLabel.Size = new System.Drawing.Size(90, 13);
            this.createProfileCycleTimeLabel.TabIndex = 2;
            this.createProfileCycleTimeLabel.Text = "Cycle Time";
            this.createProfileCycleTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createProfileNameLabel
            // 
            this.createProfileNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.createProfileNameLabel.AutoSize = true;
            this.createProfileNameLabel.Location = new System.Drawing.Point(3, 15);
            this.createProfileNameLabel.Name = "createProfileNameLabel";
            this.createProfileNameLabel.Size = new System.Drawing.Size(90, 13);
            this.createProfileNameLabel.TabIndex = 1;
            this.createProfileNameLabel.Text = "Profile Name:";
            this.createProfileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createProfileKdLabel
            // 
            this.createProfileKdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.createProfileKdLabel.AutoSize = true;
            this.createProfileKdLabel.Location = new System.Drawing.Point(3, 160);
            this.createProfileKdLabel.Name = "createProfileKdLabel";
            this.createProfileKdLabel.Size = new System.Drawing.Size(90, 13);
            this.createProfileKdLabel.TabIndex = 1;
            this.createProfileKdLabel.Text = "Kd";
            this.createProfileKdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createProfileKdComboBox
            // 
            this.createProfileKdComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.createProfileKdComboBox.FormattingEnabled = true;
            this.createProfileKdComboBox.Location = new System.Drawing.Point(99, 156);
            this.createProfileKdComboBox.Name = "createProfileKdComboBox";
            this.createProfileKdComboBox.Size = new System.Drawing.Size(157, 21);
            this.createProfileKdComboBox.TabIndex = 3;
            this.createProfileKdComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.createProfileKdComboBox_KeyDown);
            // 
            // createProfileKiLabel
            // 
            this.createProfileKiLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.createProfileKiLabel.AutoSize = true;
            this.createProfileKiLabel.Location = new System.Drawing.Point(3, 113);
            this.createProfileKiLabel.Name = "createProfileKiLabel";
            this.createProfileKiLabel.Size = new System.Drawing.Size(90, 13);
            this.createProfileKiLabel.TabIndex = 1;
            this.createProfileKiLabel.Text = "Ki";
            this.createProfileKiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createProfileKiComboBox
            // 
            this.createProfileKiComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.createProfileKiComboBox.FormattingEnabled = true;
            this.createProfileKiComboBox.Location = new System.Drawing.Point(99, 109);
            this.createProfileKiComboBox.Name = "createProfileKiComboBox";
            this.createProfileKiComboBox.Size = new System.Drawing.Size(157, 21);
            this.createProfileKiComboBox.TabIndex = 3;
            this.createProfileKiComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.createProfileKiComboBox_KeyDown);
            // 
            // createProfileKpLabel
            // 
            this.createProfileKpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.createProfileKpLabel.AutoSize = true;
            this.createProfileKpLabel.Location = new System.Drawing.Point(3, 66);
            this.createProfileKpLabel.Name = "createProfileKpLabel";
            this.createProfileKpLabel.Size = new System.Drawing.Size(90, 13);
            this.createProfileKpLabel.TabIndex = 0;
            this.createProfileKpLabel.Text = "Kp";
            this.createProfileKpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createProfileKpComboBox
            // 
            this.createProfileKpComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.createProfileKpComboBox.FormattingEnabled = true;
            this.createProfileKpComboBox.Location = new System.Drawing.Point(99, 62);
            this.createProfileKpComboBox.Name = "createProfileKpComboBox";
            this.createProfileKpComboBox.Size = new System.Drawing.Size(157, 21);
            this.createProfileKpComboBox.TabIndex = 2;
            this.createProfileKpComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.createProfileKpComboBox_KeyDown);
            // 
            // createProfileTextBox
            // 
            this.createProfileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.createProfileTextBox.Location = new System.Drawing.Point(99, 12);
            this.createProfileTextBox.Name = "createProfileTextBox";
            this.createProfileTextBox.Size = new System.Drawing.Size(157, 20);
            this.createProfileTextBox.TabIndex = 4;
            this.createProfileTextBox.Text = "PIDsettings";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowLayoutPanel2);
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(271, 298);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edit Profile";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.editProfileCancelButton);
            this.flowLayoutPanel2.Controls.Add(this.editProfileDeleteButton);
            this.flowLayoutPanel2.Controls.Add(this.editProfileSaveButton);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 249);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(259, 43);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // editProfileCancelButton
            // 
            this.editProfileCancelButton.Location = new System.Drawing.Point(176, 3);
            this.editProfileCancelButton.Name = "editProfileCancelButton";
            this.editProfileCancelButton.Size = new System.Drawing.Size(80, 38);
            this.editProfileCancelButton.TabIndex = 1;
            this.editProfileCancelButton.Text = "Cancel";
            this.editProfileCancelButton.UseVisualStyleBackColor = true;
            this.editProfileCancelButton.Click += new System.EventHandler(this.editProfileCancelButton_Click);
            // 
            // editProfileDeleteButton
            // 
            this.editProfileDeleteButton.Location = new System.Drawing.Point(90, 3);
            this.editProfileDeleteButton.Name = "editProfileDeleteButton";
            this.editProfileDeleteButton.Size = new System.Drawing.Size(80, 38);
            this.editProfileDeleteButton.TabIndex = 4;
            this.editProfileDeleteButton.Text = "Delete";
            this.editProfileDeleteButton.UseVisualStyleBackColor = true;
            this.editProfileDeleteButton.Click += new System.EventHandler(this.editProfileDeleteButton_Click);
            // 
            // editProfileSaveButton
            // 
            this.editProfileSaveButton.Location = new System.Drawing.Point(4, 3);
            this.editProfileSaveButton.Name = "editProfileSaveButton";
            this.editProfileSaveButton.Size = new System.Drawing.Size(80, 38);
            this.editProfileSaveButton.TabIndex = 0;
            this.editProfileSaveButton.Text = "Save";
            this.editProfileSaveButton.UseVisualStyleBackColor = true;
            this.editProfileSaveButton.Click += new System.EventHandler(this.editProfileSaveButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.06564F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.93436F));
            this.tableLayoutPanel2.Controls.Add(this.editProfileCycleTimeLabel, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxProfileName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.editProfileNamelabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.editProfileKdLabel, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.editProfileComboBoxKd, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.editProfileKiLabel, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.editProfileComboBoxKi, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.editProfileKpLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.editProfileComboBoxKp, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.6134F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.594119F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.75126F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.594119F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.75126F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.594119F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.75126F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.595779F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.75468F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(259, 237);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // editProfileCycleTimeLabel
            // 
            this.editProfileCycleTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.editProfileCycleTimeLabel.FormattingEnabled = true;
            this.editProfileCycleTimeLabel.Location = new System.Drawing.Point(99, 205);
            this.editProfileCycleTimeLabel.Name = "editProfileCycleTimeLabel";
            this.editProfileCycleTimeLabel.Size = new System.Drawing.Size(157, 21);
            this.editProfileCycleTimeLabel.TabIndex = 4;
            this.editProfileCycleTimeLabel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editProfileCycleTimeLabel_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cycle Time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxProfileName
            // 
            this.comboBoxProfileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxProfileName.FormattingEnabled = true;
            this.comboBoxProfileName.Location = new System.Drawing.Point(99, 11);
            this.comboBoxProfileName.Name = "comboBoxProfileName";
            this.comboBoxProfileName.Size = new System.Drawing.Size(157, 21);
            this.comboBoxProfileName.TabIndex = 3;
            this.comboBoxProfileName.SelectedIndexChanged += new System.EventHandler(this.comboBoxProfileName_SelectedIndexChanged);
            this.comboBoxProfileName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxProfileName_KeyDown);
            // 
            // editProfileNamelabel
            // 
            this.editProfileNamelabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.editProfileNamelabel.AutoSize = true;
            this.editProfileNamelabel.Location = new System.Drawing.Point(3, 15);
            this.editProfileNamelabel.Name = "editProfileNamelabel";
            this.editProfileNamelabel.Size = new System.Drawing.Size(90, 13);
            this.editProfileNamelabel.TabIndex = 1;
            this.editProfileNamelabel.Text = "Profile Name:";
            this.editProfileNamelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editProfileKdLabel
            // 
            this.editProfileKdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.editProfileKdLabel.AutoSize = true;
            this.editProfileKdLabel.Location = new System.Drawing.Point(3, 160);
            this.editProfileKdLabel.Name = "editProfileKdLabel";
            this.editProfileKdLabel.Size = new System.Drawing.Size(90, 13);
            this.editProfileKdLabel.TabIndex = 1;
            this.editProfileKdLabel.Text = "Kd";
            this.editProfileKdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editProfileComboBoxKd
            // 
            this.editProfileComboBoxKd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.editProfileComboBoxKd.FormattingEnabled = true;
            this.editProfileComboBoxKd.Location = new System.Drawing.Point(99, 156);
            this.editProfileComboBoxKd.Name = "editProfileComboBoxKd";
            this.editProfileComboBoxKd.Size = new System.Drawing.Size(157, 21);
            this.editProfileComboBoxKd.TabIndex = 3;
            this.editProfileComboBoxKd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editProfileComboBoxKd_KeyDown);
            // 
            // editProfileKiLabel
            // 
            this.editProfileKiLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.editProfileKiLabel.AutoSize = true;
            this.editProfileKiLabel.Location = new System.Drawing.Point(3, 113);
            this.editProfileKiLabel.Name = "editProfileKiLabel";
            this.editProfileKiLabel.Size = new System.Drawing.Size(90, 13);
            this.editProfileKiLabel.TabIndex = 1;
            this.editProfileKiLabel.Text = "Ki";
            this.editProfileKiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editProfileComboBoxKi
            // 
            this.editProfileComboBoxKi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.editProfileComboBoxKi.FormattingEnabled = true;
            this.editProfileComboBoxKi.Location = new System.Drawing.Point(99, 109);
            this.editProfileComboBoxKi.Name = "editProfileComboBoxKi";
            this.editProfileComboBoxKi.Size = new System.Drawing.Size(157, 21);
            this.editProfileComboBoxKi.TabIndex = 3;
            this.editProfileComboBoxKi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editProfileComboBoxKi_KeyDown);
            // 
            // editProfileKpLabel
            // 
            this.editProfileKpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.editProfileKpLabel.AutoSize = true;
            this.editProfileKpLabel.Location = new System.Drawing.Point(3, 66);
            this.editProfileKpLabel.Name = "editProfileKpLabel";
            this.editProfileKpLabel.Size = new System.Drawing.Size(90, 13);
            this.editProfileKpLabel.TabIndex = 0;
            this.editProfileKpLabel.Text = "Kp";
            this.editProfileKpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editProfileComboBoxKp
            // 
            this.editProfileComboBoxKp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.editProfileComboBoxKp.FormattingEnabled = true;
            this.editProfileComboBoxKp.Location = new System.Drawing.Point(99, 62);
            this.editProfileComboBoxKp.Name = "editProfileComboBoxKp";
            this.editProfileComboBoxKp.Size = new System.Drawing.Size(157, 21);
            this.editProfileComboBoxKp.TabIndex = 2;
            this.editProfileComboBoxKp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editProfileComboBoxKp_KeyDown);
            // 
            // frmPIDSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 337);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPIDSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PID Gains";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button createProfileCancelButton;
        private System.Windows.Forms.Button createProfileSaveButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox createProfileKdComboBox;
        private System.Windows.Forms.ComboBox createProfileKiComboBox;
        private System.Windows.Forms.Label createProfileKdLabel;
        private System.Windows.Forms.Label createProfileKpLabel;
        private System.Windows.Forms.Label createProfileKiLabel;
        private System.Windows.Forms.ComboBox createProfileKpComboBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label createProfileNameLabel;
        private System.Windows.Forms.TextBox createProfileTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button editProfileCancelButton;
        private System.Windows.Forms.Button editProfileSaveButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox comboBoxProfileName;
        private System.Windows.Forms.Label editProfileNamelabel;
        private System.Windows.Forms.Label editProfileKdLabel;
        private System.Windows.Forms.ComboBox editProfileComboBoxKd;
        private System.Windows.Forms.Label editProfileKiLabel;
        private System.Windows.Forms.ComboBox editProfileComboBoxKi;
        private System.Windows.Forms.Label editProfileKpLabel;
        private System.Windows.Forms.ComboBox editProfileComboBoxKp;
        private System.Windows.Forms.ComboBox createProfileCycleTimeComboBox;
        private System.Windows.Forms.Label createProfileCycleTimeLabel;
        private System.Windows.Forms.ComboBox editProfileCycleTimeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editProfileDeleteButton;

    }
}