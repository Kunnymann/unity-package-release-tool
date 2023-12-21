namespace PackageTool
{
    partial class PackageTool
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.UnityEditorDirectoryButton = new System.Windows.Forms.Button();
            this.UnityProcessSettingGroup = new System.Windows.Forms.GroupBox();
            this.SimulationProjectDirectoryLabel = new System.Windows.Forms.Label();
            this.PackageDirectoryLabel = new System.Windows.Forms.Label();
            this.PackageProjectDirectoryLabel = new System.Windows.Forms.Label();
            this.UnityEditorDirectoryLabel = new System.Windows.Forms.Label();
            this.SimulationProjectDirectoryField = new System.Windows.Forms.TextBox();
            this.PackageDirectoryField = new System.Windows.Forms.TextBox();
            this.SimulationProjectDirectoryButton = new System.Windows.Forms.Button();
            this.PackageProjectDirectoryField = new System.Windows.Forms.TextBox();
            this.PackageDirectoryButton = new System.Windows.Forms.Button();
            this.UnityEditorDirectoryField = new System.Windows.Forms.TextBox();
            this.PackageProjectDirectoryButton = new System.Windows.Forms.Button();
            this.PackagePropertyGroup = new System.Windows.Forms.GroupBox();
            this.ContentListBox = new System.Windows.Forms.ListBox();
            this.LoadSettingButton = new System.Windows.Forms.Button();
            this.SaveSettingButton = new System.Windows.Forms.Button();
            this.RemoveContentButton = new System.Windows.Forms.Button();
            this.AddNewContentButton = new System.Windows.Forms.Button();
            this.ContentCopyForceCheckBox = new System.Windows.Forms.CheckBox();
            this.ContentNameComboBox = new System.Windows.Forms.ComboBox();
            this.ContentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ContentNameLabel = new System.Windows.Forms.Label();
            this.ContentTypeLabel = new System.Windows.Forms.Label();
            this.ContentLabel = new System.Windows.Forms.Label();
            this.SyncGUIDMethodLabel = new System.Windows.Forms.Label();
            this.BuildSourceMethodLabel = new System.Windows.Forms.Label();
            this.PackageTitleLabel = new System.Windows.Forms.Label();
            this.SyncGUIDMethodField = new System.Windows.Forms.TextBox();
            this.BuildSourceMethodField = new System.Windows.Forms.TextBox();
            this.PackageTitleField = new System.Windows.Forms.TextBox();
            this.LogViewer = new System.Windows.Forms.ListView();
            this.columnTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLogHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartPackagingButton = new System.Windows.Forms.Button();
            this.StopPackagingButton = new System.Windows.Forms.Button();
            this.CreateNewSettingButton = new System.Windows.Forms.Button();
            this.UnityProcessSettingGroup.SuspendLayout();
            this.PackagePropertyGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // UnityEditorDirectoryButton
            // 
            this.UnityEditorDirectoryButton.Location = new System.Drawing.Point(635, 16);
            this.UnityEditorDirectoryButton.Name = "UnityEditorDirectoryButton";
            this.UnityEditorDirectoryButton.Size = new System.Drawing.Size(46, 23);
            this.UnityEditorDirectoryButton.TabIndex = 0;
            this.UnityEditorDirectoryButton.Text = "...";
            this.UnityEditorDirectoryButton.UseVisualStyleBackColor = true;
            this.UnityEditorDirectoryButton.Click += new System.EventHandler(this.UnityEditorDirectoryButton_Click);
            // 
            // UnityProcessSettingGroup
            // 
            this.UnityProcessSettingGroup.Controls.Add(this.SimulationProjectDirectoryLabel);
            this.UnityProcessSettingGroup.Controls.Add(this.PackageDirectoryLabel);
            this.UnityProcessSettingGroup.Controls.Add(this.PackageProjectDirectoryLabel);
            this.UnityProcessSettingGroup.Controls.Add(this.UnityEditorDirectoryLabel);
            this.UnityProcessSettingGroup.Controls.Add(this.SimulationProjectDirectoryField);
            this.UnityProcessSettingGroup.Controls.Add(this.PackageDirectoryField);
            this.UnityProcessSettingGroup.Controls.Add(this.SimulationProjectDirectoryButton);
            this.UnityProcessSettingGroup.Controls.Add(this.PackageProjectDirectoryField);
            this.UnityProcessSettingGroup.Controls.Add(this.PackageDirectoryButton);
            this.UnityProcessSettingGroup.Controls.Add(this.UnityEditorDirectoryField);
            this.UnityProcessSettingGroup.Controls.Add(this.PackageProjectDirectoryButton);
            this.UnityProcessSettingGroup.Controls.Add(this.UnityEditorDirectoryButton);
            this.UnityProcessSettingGroup.Location = new System.Drawing.Point(12, 12);
            this.UnityProcessSettingGroup.Name = "UnityProcessSettingGroup";
            this.UnityProcessSettingGroup.Size = new System.Drawing.Size(691, 133);
            this.UnityProcessSettingGroup.TabIndex = 1;
            this.UnityProcessSettingGroup.TabStop = false;
            this.UnityProcessSettingGroup.Text = "Unity process setting";
            // 
            // SimulationProjectDirectoryLabel
            // 
            this.SimulationProjectDirectoryLabel.AutoSize = true;
            this.SimulationProjectDirectoryLabel.Location = new System.Drawing.Point(6, 104);
            this.SimulationProjectDirectoryLabel.Name = "SimulationProjectDirectoryLabel";
            this.SimulationProjectDirectoryLabel.Size = new System.Drawing.Size(161, 12);
            this.SimulationProjectDirectoryLabel.TabIndex = 3;
            this.SimulationProjectDirectoryLabel.Text = "Simulation Project Directory";
            // 
            // PackageDirectoryLabel
            // 
            this.PackageDirectoryLabel.AutoSize = true;
            this.PackageDirectoryLabel.Location = new System.Drawing.Point(6, 77);
            this.PackageDirectoryLabel.Name = "PackageDirectoryLabel";
            this.PackageDirectoryLabel.Size = new System.Drawing.Size(108, 12);
            this.PackageDirectoryLabel.TabIndex = 3;
            this.PackageDirectoryLabel.Text = "Package Directory";
            // 
            // PackageProjectDirectoryLabel
            // 
            this.PackageProjectDirectoryLabel.AutoSize = true;
            this.PackageProjectDirectoryLabel.Location = new System.Drawing.Point(6, 50);
            this.PackageProjectDirectoryLabel.Name = "PackageProjectDirectoryLabel";
            this.PackageProjectDirectoryLabel.Size = new System.Drawing.Size(151, 12);
            this.PackageProjectDirectoryLabel.TabIndex = 3;
            this.PackageProjectDirectoryLabel.Text = "Package Project Directory";
            // 
            // UnityEditorDirectoryLabel
            // 
            this.UnityEditorDirectoryLabel.AutoSize = true;
            this.UnityEditorDirectoryLabel.Location = new System.Drawing.Point(6, 23);
            this.UnityEditorDirectoryLabel.Name = "UnityEditorDirectoryLabel";
            this.UnityEditorDirectoryLabel.Size = new System.Drawing.Size(123, 12);
            this.UnityEditorDirectoryLabel.TabIndex = 3;
            this.UnityEditorDirectoryLabel.Text = "Unity Editor Directory";
            // 
            // SimulationProjectDirectoryField
            // 
            this.SimulationProjectDirectoryField.Location = new System.Drawing.Point(268, 99);
            this.SimulationProjectDirectoryField.Name = "SimulationProjectDirectoryField";
            this.SimulationProjectDirectoryField.Size = new System.Drawing.Size(361, 21);
            this.SimulationProjectDirectoryField.TabIndex = 2;
            this.SimulationProjectDirectoryField.TextChanged += new System.EventHandler(this.SimulationProjectDirectoryField_TextChanged);
            // 
            // PackageDirectoryField
            // 
            this.PackageDirectoryField.Location = new System.Drawing.Point(268, 72);
            this.PackageDirectoryField.Name = "PackageDirectoryField";
            this.PackageDirectoryField.Size = new System.Drawing.Size(361, 21);
            this.PackageDirectoryField.TabIndex = 2;
            this.PackageDirectoryField.TextChanged += new System.EventHandler(this.PackageDirectoryField_TextChanged);
            // 
            // SimulationProjectDirectoryButton
            // 
            this.SimulationProjectDirectoryButton.Location = new System.Drawing.Point(635, 99);
            this.SimulationProjectDirectoryButton.Name = "SimulationProjectDirectoryButton";
            this.SimulationProjectDirectoryButton.Size = new System.Drawing.Size(46, 23);
            this.SimulationProjectDirectoryButton.TabIndex = 1;
            this.SimulationProjectDirectoryButton.Text = "...";
            this.SimulationProjectDirectoryButton.UseVisualStyleBackColor = true;
            this.SimulationProjectDirectoryButton.Click += new System.EventHandler(this.SimulationProjectDirectoryButton_Click);
            // 
            // PackageProjectDirectoryField
            // 
            this.PackageProjectDirectoryField.Location = new System.Drawing.Point(268, 45);
            this.PackageProjectDirectoryField.Name = "PackageProjectDirectoryField";
            this.PackageProjectDirectoryField.Size = new System.Drawing.Size(361, 21);
            this.PackageProjectDirectoryField.TabIndex = 2;
            this.PackageProjectDirectoryField.TextChanged += new System.EventHandler(this.PackageProjectDirectoryField_TextChanged);
            // 
            // PackageDirectoryButton
            // 
            this.PackageDirectoryButton.Location = new System.Drawing.Point(635, 72);
            this.PackageDirectoryButton.Name = "PackageDirectoryButton";
            this.PackageDirectoryButton.Size = new System.Drawing.Size(46, 23);
            this.PackageDirectoryButton.TabIndex = 1;
            this.PackageDirectoryButton.Text = "...";
            this.PackageDirectoryButton.UseVisualStyleBackColor = true;
            this.PackageDirectoryButton.Click += new System.EventHandler(this.PackageDirectoryButton_Click);
            // 
            // UnityEditorDirectoryField
            // 
            this.UnityEditorDirectoryField.Location = new System.Drawing.Point(268, 18);
            this.UnityEditorDirectoryField.Name = "UnityEditorDirectoryField";
            this.UnityEditorDirectoryField.Size = new System.Drawing.Size(361, 21);
            this.UnityEditorDirectoryField.TabIndex = 2;
            this.UnityEditorDirectoryField.TextChanged += new System.EventHandler(this.UnityEditorDirectoryField_TextChanged);
            // 
            // PackageProjectDirectoryButton
            // 
            this.PackageProjectDirectoryButton.Location = new System.Drawing.Point(635, 45);
            this.PackageProjectDirectoryButton.Name = "PackageProjectDirectoryButton";
            this.PackageProjectDirectoryButton.Size = new System.Drawing.Size(46, 23);
            this.PackageProjectDirectoryButton.TabIndex = 1;
            this.PackageProjectDirectoryButton.Text = "...";
            this.PackageProjectDirectoryButton.UseVisualStyleBackColor = true;
            this.PackageProjectDirectoryButton.Click += new System.EventHandler(this.PackageProjectDirectoryButton_Click);
            // 
            // PackagePropertyGroup
            // 
            this.PackagePropertyGroup.Controls.Add(this.CreateNewSettingButton);
            this.PackagePropertyGroup.Controls.Add(this.ContentListBox);
            this.PackagePropertyGroup.Controls.Add(this.LoadSettingButton);
            this.PackagePropertyGroup.Controls.Add(this.SaveSettingButton);
            this.PackagePropertyGroup.Controls.Add(this.RemoveContentButton);
            this.PackagePropertyGroup.Controls.Add(this.AddNewContentButton);
            this.PackagePropertyGroup.Controls.Add(this.ContentCopyForceCheckBox);
            this.PackagePropertyGroup.Controls.Add(this.ContentNameComboBox);
            this.PackagePropertyGroup.Controls.Add(this.ContentTypeComboBox);
            this.PackagePropertyGroup.Controls.Add(this.ContentNameLabel);
            this.PackagePropertyGroup.Controls.Add(this.ContentTypeLabel);
            this.PackagePropertyGroup.Controls.Add(this.ContentLabel);
            this.PackagePropertyGroup.Controls.Add(this.SyncGUIDMethodLabel);
            this.PackagePropertyGroup.Controls.Add(this.BuildSourceMethodLabel);
            this.PackagePropertyGroup.Controls.Add(this.PackageTitleLabel);
            this.PackagePropertyGroup.Controls.Add(this.SyncGUIDMethodField);
            this.PackagePropertyGroup.Controls.Add(this.BuildSourceMethodField);
            this.PackagePropertyGroup.Controls.Add(this.PackageTitleField);
            this.PackagePropertyGroup.Location = new System.Drawing.Point(12, 151);
            this.PackagePropertyGroup.Name = "PackagePropertyGroup";
            this.PackagePropertyGroup.Size = new System.Drawing.Size(691, 357);
            this.PackagePropertyGroup.TabIndex = 1;
            this.PackagePropertyGroup.TabStop = false;
            this.PackagePropertyGroup.Text = "Package properties";
            // 
            // ContentListBox
            // 
            this.ContentListBox.FormattingEnabled = true;
            this.ContentListBox.ItemHeight = 12;
            this.ContentListBox.Location = new System.Drawing.Point(8, 201);
            this.ContentListBox.Name = "ContentListBox";
            this.ContentListBox.Size = new System.Drawing.Size(674, 112);
            this.ContentListBox.TabIndex = 6;
            this.ContentListBox.SelectedIndexChanged += new System.EventHandler(this.ContentListBox_SelectedIndexChanged);
            // 
            // LoadSettingButton
            // 
            this.LoadSettingButton.Location = new System.Drawing.Point(466, 328);
            this.LoadSettingButton.Name = "LoadSettingButton";
            this.LoadSettingButton.Size = new System.Drawing.Size(107, 23);
            this.LoadSettingButton.TabIndex = 3;
            this.LoadSettingButton.Text = "Load setting";
            this.LoadSettingButton.UseVisualStyleBackColor = true;
            this.LoadSettingButton.Click += new System.EventHandler(this.LoadSettingButton_Click);
            // 
            // SaveSettingButton
            // 
            this.SaveSettingButton.Location = new System.Drawing.Point(579, 328);
            this.SaveSettingButton.Name = "SaveSettingButton";
            this.SaveSettingButton.Size = new System.Drawing.Size(103, 23);
            this.SaveSettingButton.TabIndex = 3;
            this.SaveSettingButton.Text = "Save setting";
            this.SaveSettingButton.UseVisualStyleBackColor = true;
            this.SaveSettingButton.Click += new System.EventHandler(this.SaveSettingButton_Click);
            // 
            // RemoveContentButton
            // 
            this.RemoveContentButton.Location = new System.Drawing.Point(98, 328);
            this.RemoveContentButton.Name = "RemoveContentButton";
            this.RemoveContentButton.Size = new System.Drawing.Size(88, 23);
            this.RemoveContentButton.TabIndex = 3;
            this.RemoveContentButton.Text = "Remove";
            this.RemoveContentButton.UseVisualStyleBackColor = true;
            this.RemoveContentButton.Click += new System.EventHandler(this.RemoveContentButton_Click);
            // 
            // AddNewContentButton
            // 
            this.AddNewContentButton.Location = new System.Drawing.Point(8, 328);
            this.AddNewContentButton.Name = "AddNewContentButton";
            this.AddNewContentButton.Size = new System.Drawing.Size(84, 23);
            this.AddNewContentButton.TabIndex = 3;
            this.AddNewContentButton.Text = "Add";
            this.AddNewContentButton.UseVisualStyleBackColor = true;
            this.AddNewContentButton.Click += new System.EventHandler(this.AddNewContentButton_Click);
            // 
            // ContentCopyForceCheckBox
            // 
            this.ContentCopyForceCheckBox.AutoCheck = false;
            this.ContentCopyForceCheckBox.AutoSize = true;
            this.ContentCopyForceCheckBox.Location = new System.Drawing.Point(545, 178);
            this.ContentCopyForceCheckBox.Name = "ContentCopyForceCheckBox";
            this.ContentCopyForceCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ContentCopyForceCheckBox.Size = new System.Drawing.Size(137, 16);
            this.ContentCopyForceCheckBox.TabIndex = 5;
            this.ContentCopyForceCheckBox.Text = "Content Copy Force";
            this.ContentCopyForceCheckBox.UseVisualStyleBackColor = true;
            this.ContentCopyForceCheckBox.CheckedChanged += new System.EventHandler(this.ContentCopyForceCheckBox_CheckedChanged);
            // 
            // ContentNameComboBox
            // 
            this.ContentNameComboBox.FormattingEnabled = true;
            this.ContentNameComboBox.Location = new System.Drawing.Point(450, 152);
            this.ContentNameComboBox.Name = "ContentNameComboBox";
            this.ContentNameComboBox.Size = new System.Drawing.Size(232, 20);
            this.ContentNameComboBox.TabIndex = 4;
            this.ContentNameComboBox.SelectedIndexChanged += new System.EventHandler(this.ContentNameComboBox_SelectedIndexChanged);
            // 
            // ContentTypeComboBox
            // 
            this.ContentTypeComboBox.FormattingEnabled = true;
            this.ContentTypeComboBox.Location = new System.Drawing.Point(450, 128);
            this.ContentTypeComboBox.Name = "ContentTypeComboBox";
            this.ContentTypeComboBox.Size = new System.Drawing.Size(232, 20);
            this.ContentTypeComboBox.TabIndex = 4;
            this.ContentTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ContentTypeComboBox_SelectedIndexChanged);
            // 
            // ContentNameLabel
            // 
            this.ContentNameLabel.AutoSize = true;
            this.ContentNameLabel.Location = new System.Drawing.Point(6, 160);
            this.ContentNameLabel.Name = "ContentNameLabel";
            this.ContentNameLabel.Size = new System.Drawing.Size(86, 12);
            this.ContentNameLabel.TabIndex = 3;
            this.ContentNameLabel.Text = "Content Name";
            // 
            // ContentTypeLabel
            // 
            this.ContentTypeLabel.AutoSize = true;
            this.ContentTypeLabel.Location = new System.Drawing.Point(6, 136);
            this.ContentTypeLabel.Name = "ContentTypeLabel";
            this.ContentTypeLabel.Size = new System.Drawing.Size(81, 12);
            this.ContentTypeLabel.TabIndex = 3;
            this.ContentTypeLabel.Text = "Content Type";
            // 
            // ContentLabel
            // 
            this.ContentLabel.AutoSize = true;
            this.ContentLabel.Location = new System.Drawing.Point(6, 112);
            this.ContentLabel.Name = "ContentLabel";
            this.ContentLabel.Size = new System.Drawing.Size(48, 12);
            this.ContentLabel.TabIndex = 3;
            this.ContentLabel.Text = "Content";
            // 
            // SyncGUIDMethodLabel
            // 
            this.SyncGUIDMethodLabel.AutoSize = true;
            this.SyncGUIDMethodLabel.Location = new System.Drawing.Point(6, 77);
            this.SyncGUIDMethodLabel.Name = "SyncGUIDMethodLabel";
            this.SyncGUIDMethodLabel.Size = new System.Drawing.Size(112, 12);
            this.SyncGUIDMethodLabel.TabIndex = 3;
            this.SyncGUIDMethodLabel.Text = "Sync GUID Method";
            // 
            // BuildSourceMethodLabel
            // 
            this.BuildSourceMethodLabel.AutoSize = true;
            this.BuildSourceMethodLabel.Location = new System.Drawing.Point(6, 50);
            this.BuildSourceMethodLabel.Name = "BuildSourceMethodLabel";
            this.BuildSourceMethodLabel.Size = new System.Drawing.Size(123, 12);
            this.BuildSourceMethodLabel.TabIndex = 3;
            this.BuildSourceMethodLabel.Text = "Build Source Method";
            // 
            // PackageTitleLabel
            // 
            this.PackageTitleLabel.AutoSize = true;
            this.PackageTitleLabel.Location = new System.Drawing.Point(6, 23);
            this.PackageTitleLabel.Name = "PackageTitleLabel";
            this.PackageTitleLabel.Size = new System.Drawing.Size(82, 12);
            this.PackageTitleLabel.TabIndex = 3;
            this.PackageTitleLabel.Text = "Package Title";
            // 
            // SyncGUIDMethodField
            // 
            this.SyncGUIDMethodField.Location = new System.Drawing.Point(450, 74);
            this.SyncGUIDMethodField.Name = "SyncGUIDMethodField";
            this.SyncGUIDMethodField.Size = new System.Drawing.Size(232, 21);
            this.SyncGUIDMethodField.TabIndex = 2;
            this.SyncGUIDMethodField.TextChanged += new System.EventHandler(this.SyncGUIDMethodField_TextChanged);
            // 
            // BuildSourceMethodField
            // 
            this.BuildSourceMethodField.Location = new System.Drawing.Point(450, 47);
            this.BuildSourceMethodField.Name = "BuildSourceMethodField";
            this.BuildSourceMethodField.Size = new System.Drawing.Size(232, 21);
            this.BuildSourceMethodField.TabIndex = 2;
            this.BuildSourceMethodField.TextChanged += new System.EventHandler(this.BuildSourceMethodField_TextChanged);
            // 
            // PackageTitleField
            // 
            this.PackageTitleField.Location = new System.Drawing.Point(450, 20);
            this.PackageTitleField.Name = "PackageTitleField";
            this.PackageTitleField.Size = new System.Drawing.Size(232, 21);
            this.PackageTitleField.TabIndex = 2;
            this.PackageTitleField.TextChanged += new System.EventHandler(this.PackageTitleField_TextChanged);
            // 
            // LogViewer
            // 
            this.LogViewer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTimeHeader,
            this.columnLogHeader});
            this.LogViewer.FullRowSelect = true;
            this.LogViewer.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LogViewer.HideSelection = false;
            this.LogViewer.Location = new System.Drawing.Point(12, 515);
            this.LogViewer.Name = "LogViewer";
            this.LogViewer.Size = new System.Drawing.Size(691, 114);
            this.LogViewer.TabIndex = 2;
            this.LogViewer.UseCompatibleStateImageBehavior = false;
            this.LogViewer.View = System.Windows.Forms.View.Details;
            this.LogViewer.SelectedIndexChanged += new System.EventHandler(this.LogViewer_SelectedIndexChanged);
            // 
            // columnTimeHeader
            // 
            this.columnTimeHeader.Text = "Time";
            this.columnTimeHeader.Width = 100;
            // 
            // columnLogHeader
            // 
            this.columnLogHeader.Text = "Log";
            this.columnLogHeader.Width = 1000;
            // 
            // StartPackagingButton
            // 
            this.StartPackagingButton.Location = new System.Drawing.Point(503, 637);
            this.StartPackagingButton.Name = "StartPackagingButton";
            this.StartPackagingButton.Size = new System.Drawing.Size(191, 23);
            this.StartPackagingButton.TabIndex = 3;
            this.StartPackagingButton.Text = "Start packaging";
            this.StartPackagingButton.UseVisualStyleBackColor = true;
            this.StartPackagingButton.Click += new System.EventHandler(this.StartPackagingButton_Click);
            // 
            // StopPackagingButton
            // 
            this.StopPackagingButton.Location = new System.Drawing.Point(348, 637);
            this.StopPackagingButton.Name = "StopPackagingButton";
            this.StopPackagingButton.Size = new System.Drawing.Size(149, 23);
            this.StopPackagingButton.TabIndex = 4;
            this.StopPackagingButton.Text = "Stop packaging";
            this.StopPackagingButton.UseVisualStyleBackColor = true;
            this.StopPackagingButton.Click += new System.EventHandler(this.StopPackagingButton_Click);
            // 
            // CreateNewSettingButton
            // 
            this.CreateNewSettingButton.Location = new System.Drawing.Point(336, 328);
            this.CreateNewSettingButton.Name = "CreateNewSettingButton";
            this.CreateNewSettingButton.Size = new System.Drawing.Size(124, 23);
            this.CreateNewSettingButton.TabIndex = 7;
            this.CreateNewSettingButton.Text = "Create new setting";
            this.CreateNewSettingButton.UseVisualStyleBackColor = true;
            this.CreateNewSettingButton.Click += new System.EventHandler(this.CreateNewSettingButton_Click);
            // 
            // PackageTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 672);
            this.Controls.Add(this.StopPackagingButton);
            this.Controls.Add(this.StartPackagingButton);
            this.Controls.Add(this.LogViewer);
            this.Controls.Add(this.PackagePropertyGroup);
            this.Controls.Add(this.UnityProcessSettingGroup);
            this.Name = "PackageTool";
            this.Text = "Unity package tool";
            this.Load += new System.EventHandler(this.PackageTool_Load);
            this.UnityProcessSettingGroup.ResumeLayout(false);
            this.UnityProcessSettingGroup.PerformLayout();
            this.PackagePropertyGroup.ResumeLayout(false);
            this.PackagePropertyGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UnityEditorDirectoryButton;
        private System.Windows.Forms.GroupBox UnityProcessSettingGroup;
        private System.Windows.Forms.Button PackageProjectDirectoryButton;
        private System.Windows.Forms.Label UnityEditorDirectoryLabel;
        private System.Windows.Forms.TextBox PackageProjectDirectoryField;
        private System.Windows.Forms.TextBox UnityEditorDirectoryField;
        private System.Windows.Forms.Label PackageProjectDirectoryLabel;
        private System.Windows.Forms.Label PackageDirectoryLabel;
        private System.Windows.Forms.TextBox PackageDirectoryField;
        private System.Windows.Forms.Button PackageDirectoryButton;
        private System.Windows.Forms.Label SimulationProjectDirectoryLabel;
        private System.Windows.Forms.TextBox SimulationProjectDirectoryField;
        private System.Windows.Forms.Button SimulationProjectDirectoryButton;
        private System.Windows.Forms.GroupBox PackagePropertyGroup;
        private System.Windows.Forms.Label SyncGUIDMethodLabel;
        private System.Windows.Forms.Label BuildSourceMethodLabel;
        private System.Windows.Forms.Label PackageTitleLabel;
        private System.Windows.Forms.TextBox SyncGUIDMethodField;
        private System.Windows.Forms.TextBox BuildSourceMethodField;
        private System.Windows.Forms.TextBox PackageTitleField;
        private System.Windows.Forms.Label ContentLabel;
        private System.Windows.Forms.ComboBox ContentTypeComboBox;
        private System.Windows.Forms.Label ContentTypeLabel;
        private System.Windows.Forms.ComboBox ContentNameComboBox;
        private System.Windows.Forms.Label ContentNameLabel;
        private System.Windows.Forms.CheckBox ContentCopyForceCheckBox;
        private System.Windows.Forms.Button RemoveContentButton;
        private System.Windows.Forms.Button AddNewContentButton;
        private System.Windows.Forms.Button LoadSettingButton;
        private System.Windows.Forms.Button SaveSettingButton;
        private System.Windows.Forms.ListBox ContentListBox;
        private System.Windows.Forms.ListView LogViewer;
        private System.Windows.Forms.ColumnHeader columnTimeHeader;
        private System.Windows.Forms.ColumnHeader columnLogHeader;
        private System.Windows.Forms.Button StartPackagingButton;
        private System.Windows.Forms.Button StopPackagingButton;
        private System.Windows.Forms.Button CreateNewSettingButton;
    }
}

