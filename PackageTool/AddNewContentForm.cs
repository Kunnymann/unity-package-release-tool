using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackageTool
{
    public partial class AddNewContentForm : Form
    {
        private PackageResourceContainer packageResourceContainer;

        public AddNewContentForm(PackageResourceContainer container)
        {
            this.packageResourceContainer = container;
            InitializeComponent();
        }

        private void AddNewContentForm_Load(object sender, EventArgs e)
        {
            this.ContentTypeComboBox.Items.AddRange(Enum.GetNames(typeof(PackageManager.Enums.ContentType)));
        }

        private void ContentTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ContentNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContentCopyForceCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ContentValueTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.ContentNameField.Text))
            {
                MessageBox.Show("Content name is empty.");
                return;
            }

            if (string.IsNullOrEmpty(this.ContentValueField.Text))
            {
                MessageBox.Show("Content value is empty.");
                return;
            }

            string contentName = this.ContentNameField.Text;

            if (this.packageResourceContainer.PackageContent.Any(element => element.Name.Equals(contentName)))
            {
                MessageBox.Show($"Already use {contentName} name.");
                return;
            }

            Content content = new Content()
            {
                Name = this.ContentNameField.Text,
                Targets = this.ContentValueField.Text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries),
                CopyForce = this.ContentCopyForceCheckBox.Checked,
                ContentType = (PackageManager.Enums.ContentType)Enum.Parse(typeof(PackageManager.Enums.ContentType), this.ContentTypeComboBox.SelectedItem.ToString())
            };

            this.packageResourceContainer.PackageContent.Add(content);
            PackageTool.Instance.UpdatePackageToolContent();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
