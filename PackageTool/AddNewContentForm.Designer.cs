namespace PackageTool
{
    partial class AddNewContentForm
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
            this.ContentTypeLabel = new System.Windows.Forms.Label();
            this.ContentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ContentNameLabel = new System.Windows.Forms.Label();
            this.ContentNameField = new System.Windows.Forms.TextBox();
            this.ContentValueLabel = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ContentValueField = new System.Windows.Forms.RichTextBox();
            this.ContentCopyForceCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ContentTypeLabel
            // 
            this.ContentTypeLabel.AutoSize = true;
            this.ContentTypeLabel.Location = new System.Drawing.Point(13, 13);
            this.ContentTypeLabel.Name = "ContentTypeLabel";
            this.ContentTypeLabel.Size = new System.Drawing.Size(81, 12);
            this.ContentTypeLabel.TabIndex = 0;
            this.ContentTypeLabel.Text = "Content Type";
            // 
            // ContentTypeComboBox
            // 
            this.ContentTypeComboBox.FormattingEnabled = true;
            this.ContentTypeComboBox.Location = new System.Drawing.Point(157, 10);
            this.ContentTypeComboBox.Name = "ContentTypeComboBox";
            this.ContentTypeComboBox.Size = new System.Drawing.Size(173, 20);
            this.ContentTypeComboBox.TabIndex = 1;
            this.ContentTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ContentTypeComboBox_SelectedIndexChanged);
            // 
            // ContentNameLabel
            // 
            this.ContentNameLabel.AutoSize = true;
            this.ContentNameLabel.Location = new System.Drawing.Point(13, 41);
            this.ContentNameLabel.Name = "ContentNameLabel";
            this.ContentNameLabel.Size = new System.Drawing.Size(86, 12);
            this.ContentNameLabel.TabIndex = 2;
            this.ContentNameLabel.Text = "Content Name";
            // 
            // ContentNameField
            // 
            this.ContentNameField.Location = new System.Drawing.Point(157, 38);
            this.ContentNameField.Name = "ContentNameField";
            this.ContentNameField.Size = new System.Drawing.Size(173, 21);
            this.ContentNameField.TabIndex = 3;
            this.ContentNameField.TextChanged += new System.EventHandler(this.ContentNameTextBox_TextChanged);
            // 
            // ContentValueLabel
            // 
            this.ContentValueLabel.AutoSize = true;
            this.ContentValueLabel.Location = new System.Drawing.Point(13, 101);
            this.ContentValueLabel.Name = "ContentValueLabel";
            this.ContentValueLabel.Size = new System.Drawing.Size(84, 12);
            this.ContentValueLabel.TabIndex = 5;
            this.ContentValueLabel.Text = "Content Value";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(174, 252);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 6;
            this.ConfirmButton.Text = "Ok";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(255, 252);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ContentValueField
            // 
            this.ContentValueField.Location = new System.Drawing.Point(15, 125);
            this.ContentValueField.Name = "ContentValueField";
            this.ContentValueField.Size = new System.Drawing.Size(315, 121);
            this.ContentValueField.TabIndex = 8;
            this.ContentValueField.Text = "";
            // 
            // ContentCopyForceCheckBox
            // 
            this.ContentCopyForceCheckBox.AutoSize = true;
            this.ContentCopyForceCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ContentCopyForceCheckBox.Location = new System.Drawing.Point(193, 65);
            this.ContentCopyForceCheckBox.Name = "ContentCopyForceCheckBox";
            this.ContentCopyForceCheckBox.Size = new System.Drawing.Size(137, 16);
            this.ContentCopyForceCheckBox.TabIndex = 9;
            this.ContentCopyForceCheckBox.Text = "Content Copy Force";
            this.ContentCopyForceCheckBox.UseVisualStyleBackColor = true;
            this.ContentCopyForceCheckBox.CheckedChanged += new System.EventHandler(this.ContentCopyForceCheckBox_CheckedChanged);
            // 
            // AddNewContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 287);
            this.Controls.Add(this.ContentCopyForceCheckBox);
            this.Controls.Add(this.ContentValueField);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.ContentValueLabel);
            this.Controls.Add(this.ContentNameField);
            this.Controls.Add(this.ContentNameLabel);
            this.Controls.Add(this.ContentTypeComboBox);
            this.Controls.Add(this.ContentTypeLabel);
            this.Name = "AddNewContentForm";
            this.Text = "AddNewContentForm";
            this.Load += new System.EventHandler(this.AddNewContentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ContentTypeLabel;
        private System.Windows.Forms.ComboBox ContentTypeComboBox;
        private System.Windows.Forms.Label ContentNameLabel;
        private System.Windows.Forms.TextBox ContentNameField;
        private System.Windows.Forms.Label ContentValueLabel;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.RichTextBox ContentValueField;
        private System.Windows.Forms.CheckBox ContentCopyForceCheckBox;
    }
}