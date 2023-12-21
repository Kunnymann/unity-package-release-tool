using System;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PackageManager;
using System.Diagnostics;
using PackageManager.Models;
using System.IO;
using System.Threading;

namespace PackageTool
{
    public partial class PackageTool : Form
    {
        private static PackageTool instance;
        public static PackageTool Instance => instance;

        private PackageController packageController;
        private Task packagingTask;
        private CancellationTokenSource tokenSource;
        private bool isPackageRunning = false;
        private bool IsPackageRunning
        {
            get => isPackageRunning;
            set
            {
                if (value)
                {
                    this.AddNewContentButton.Enabled = false;
                    this.RemoveContentButton.Enabled = false;
                    this.UnityEditorDirectoryButton.Enabled = false;
                    this.PackageProjectDirectoryButton.Enabled = false;
                    this.PackageDirectoryButton.Enabled = false;
                    this.SimulationProjectDirectoryButton.Enabled = false;
                    this.PackageDirectoryButton.Enabled = false;
                    this.StartPackagingButton.Enabled = false;
                    this.LoadSettingButton.Enabled = false;
                    this.SaveSettingButton.Enabled = false;
                }
                else
                {
                    this.AddNewContentButton.Enabled = true;
                    this.RemoveContentButton.Enabled = true;
                    this.UnityEditorDirectoryButton.Enabled = true;
                    this.PackageProjectDirectoryButton.Enabled = true;
                    this.PackageDirectoryButton.Enabled = true;
                    this.SimulationProjectDirectoryButton.Enabled = true;
                    this.PackageDirectoryButton.Enabled = true;
                    this.StartPackagingButton.Enabled = true;
                    this.LoadSettingButton.Enabled = true;
                    this.SaveSettingButton.Enabled = true;
                }
                isPackageRunning = value;
            }
        }

        public PackageTool()
        {
            InitializeComponent();
            instance = this;
        }

        public void Update()
        {
            UpdateContentListBox(true);
        }

        private void PackageTool_Load(object sender, EventArgs e)
        {

        }

        #region Unity process setting

        // TextField

        private void UnityEditorDirectoryField_TextChanged(object sender, EventArgs e)
        {

        }

        private void PackageProjectDirectoryField_TextChanged(object sender, EventArgs e)
        {

        }

        private void PackageDirectoryField_TextChanged(object sender, EventArgs e)
        {

        }

        private void SimulationProjectDirectoryField_TextChanged(object sender, EventArgs e)
        {

        }

        // Button

        private void UnityEditorDirectoryButton_Click(object sender, EventArgs e)
        {
            string unityEditorPath = null;

            OpenFileDialog dialog = new OpenFileDialog()
            {
                InitialDirectory = this.UnityEditorDirectoryField.Text,
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                unityEditorPath = dialog.FileName;
                UnityEditorDirectoryField.Text = unityEditorPath;
                this.packageController.PackageResourceContainer.UnityEditorDirectory = unityEditorPath;
            }
        }

        private void PackageProjectDirectoryButton_Click(object sender, EventArgs e)
        {
            string packageProjectPath = null;

            CommonOpenFileDialog dialog = new CommonOpenFileDialog()
            {
                InitialDirectory = this.PackageProjectDirectoryField.Text,
                IsFolderPicker = true,
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                packageProjectPath = dialog.FileName;
                this.PackageProjectDirectoryField.Text = packageProjectPath;
                this.packageController.PackageResourceContainer.PackageProjectDirectory = packageProjectPath;
            }
        }

        private void PackageDirectoryButton_Click(object sender, EventArgs e)
        {
            string packagePath = null;

            CommonOpenFileDialog dialog = new CommonOpenFileDialog()
            {
                InitialDirectory = this.PackageDirectoryField.Text,
                IsFolderPicker = true,
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                packagePath = dialog.FileName;
                this.PackageDirectoryField.Text = packagePath;
                this.packageController.PackageResourceContainer.PackageDirectory = packagePath;
            }
        }

        private void SimulationProjectDirectoryButton_Click(object sender, EventArgs e)
        {
            string simulationProjectPath = null;

            CommonOpenFileDialog dialog = new CommonOpenFileDialog()
            {
                InitialDirectory = this.SimulationProjectDirectoryField.Text,
                IsFolderPicker = true,
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                simulationProjectPath = dialog.FileName;
                this.SimulationProjectDirectoryField.Text = simulationProjectPath;
                this.packageController.PackageResourceContainer.SimulationProjectDirectory = simulationProjectPath;
            }
        }

        #endregion

        #region Package properties

        private void PackageTitleField_TextChanged(object sender, EventArgs e)
        {
            this.packageController.PackageResourceContainer.PackageTitle = this.PackageTitleField.Text;
        }

        private void BuildSourceMethodField_TextChanged(object sender, EventArgs e)
        {
            this.packageController.PackageResourceContainer.BuildSourceMethod = this.BuildSourceMethodField.Text;
        }

        private void SyncGUIDMethodField_TextChanged(object sender, EventArgs e)
        {
            this.packageController.PackageResourceContainer.SyncGUIDMethod = this.SyncGUIDMethodField.Text;
        }

        private void ContentTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ContentNameComboBox.DataSource = packageController.PackageResourceContainer.PackageContent
                .Where(content => content.ContentType == (PackageManager.Enums.ContentType) this.ContentTypeComboBox.SelectedItem)
                .Select(content => content.Name).ToList();

            UpdateContentListBox();
        }

        private void ContentNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateContentListBox();
        }

        private void ContentCopyForceCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ContentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddNewContentButton_Click(object sender, EventArgs e)
        {
            if (this.packageController == null || this.packageController.PackageResourceContainer == null)
            {
                MessageBox.Show("Please load package setting first.");
                return;
            }

            AddNewContentForm form = new AddNewContentForm(this.packageController.PackageResourceContainer);
            form.ShowDialog();
        }

        private void RemoveContentButton_Click(object sender, EventArgs e)
        {
            if (this.packageController == null || this.packageController.PackageResourceContainer == null)
            {
                MessageBox.Show("Please load package setting first.");
                return;
            }

            if (this.ContentNameComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select content name first.");
                return;
            }

            var selectedContentType = (PackageManager.Enums.ContentType)this.ContentTypeComboBox.SelectedItem;
            var selectedContentName = (string)this.ContentNameComboBox.SelectedItem;

            var confirmBox = MessageBox.Show($"Are you sure to remove this content ({selectedContentName})?", "Confirm", MessageBoxButtons.YesNo);
            
            if (confirmBox == DialogResult.Yes)
            {
                this.packageController.PackageResourceContainer.PackageContent.RemoveAll(content => content.ContentType == selectedContentType && content.Name == selectedContentName);
                UpdateContentListBox(true);
                return;
            }
            else
            {
                return;
            }
        }

        private void CreateNewSettingButton_Click(object sender, EventArgs e)
        {
            this.packageController = new PackageController();
            LoadPackageControllerProperties();
        }

        private void LoadSettingButton_Click(object sender, EventArgs e)
        {
            string jsonPath = null;

            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "JSON File (*.json)|*.json",
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                jsonPath = dialog.FileName;
                try
                {
                    packageController = new PackageController(jsonPath);
                }
                catch(Exception exception)
                {
                    AddErrorLog(this, $"Fail to generate PackageController ({exception.Message})");
                    packageController = null;
                    return;
                }
                
                LoadPackageControllerProperties();
                AddLog(this, "Success to generate PackageController");
            }
        }

        private void SaveSettingButton_Click(object sender, EventArgs e)
        {
            if (this.packageController == null || this.packageController.PackageResourceContainer == null)
            {
                MessageBox.Show("Please load package setting first.");
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "JSON File (*.json)|*.json",
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                packageController.SaveResourceContainer(dialog.FileName);
            }
        }

        private void LogViewer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void StopPackagingButton_Click(object sender, EventArgs e)
        {
            if (this.packageController == null || this.packageController.PackageResourceContainer == null)
            {
                MessageBox.Show("Please load package setting first.");
                return;
            }

            if (!isPackageRunning)
            {
                MessageBox.Show("Package is not running.");
                
            }
            else
            {
                StopPackaging();
                //this.packageController.LogEvent -= AddLog;
                //this.packageController.LogErrorEvent -= AddErrorLog;
                IsPackageRunning = false;
            }
        }

        private void StartPackagingButton_Click(object sender, EventArgs e)
        {
            if (this.packageController == null || this.packageController.PackageResourceContainer == null)
            {
                MessageBox.Show("Please load package setting first.");
                return;
            }

            tokenSource = new CancellationTokenSource();
            StartPackaging(tokenSource.Token);
        }

        #endregion

        #region Functional

        private void LoadPackageControllerProperties()
        {
            this.UnityEditorDirectoryField.Text = packageController.PackageResourceContainer.UnityEditorDirectory;
            this.PackageProjectDirectoryField.Text = packageController.PackageResourceContainer.PackageProjectDirectory;
            this.PackageDirectoryField.Text = packageController.PackageResourceContainer.PackageDirectory;
            this.SimulationProjectDirectoryField.Text = packageController.PackageResourceContainer.SimulationProjectDirectory;

            this.PackageTitleField.Text = packageController.PackageResourceContainer.PackageTitle;
            this.BuildSourceMethodField.Text = packageController.PackageResourceContainer.BuildSourceMethod;
            this.SyncGUIDMethodField.Text = packageController.PackageResourceContainer.SyncGUIDMethod;

            this.ContentTypeComboBox.DataSource = Enum.GetValues(typeof(PackageManager.Enums.ContentType));

            UpdateContentListBox(true);
        }

        private void UpdateContentListBox(bool withContentName = false)
        {
            if (withContentName)
            {
                this.ContentNameComboBox.DataSource = packageController.PackageResourceContainer.PackageContent
                .Where(content => content.ContentType == (PackageManager.Enums.ContentType)this.ContentTypeComboBox.SelectedItem)
                .Select(content => content.Name).ToList();
            }

            this.ContentCopyForceCheckBox.Checked = packageController.PackageResourceContainer.PackageContent
                .Where(content => content.ContentType == (PackageManager.Enums.ContentType) this.ContentTypeComboBox.SelectedItem)
                .Where(content => content.Name == (string) this.ContentNameComboBox.SelectedItem)
                .Select(content => content.CopyForce).FirstOrDefault();

            this.ContentListBox.DataSource = packageController.PackageResourceContainer.PackageContent
                .Where(content => content.ContentType == (PackageManager.Enums.ContentType) this.ContentTypeComboBox.SelectedItem)
                .Where(content => content.Name == (string) this.ContentNameComboBox.SelectedItem)
                .SelectMany(content => content.Targets).ToList();
        }

        private void StopPackaging()
        {
            tokenSource.Cancel();
        }

        private async void StartPackaging(CancellationToken token)
        {
            this.packageController.LogEvent += AddLog;
            this.packageController.LogErrorEvent += AddErrorLog;

            IsPackageRunning = true;

            await Task.Run(() => this.packageController.StartPackageAsync(token));

            this.packageController.LogEvent -= AddLog;
            this.packageController.LogErrorEvent -= AddErrorLog;
            IsPackageRunning = false;
        }

        private void AddLog(object sender, string log)
        {
            ListViewItem item = new ListViewItem();
            item.Text = DateTime.Now.ToString("HH:mm:ss");
            item.SubItems.Add(log);
            if (this.LogViewer.InvokeRequired)
            {
                this.LogViewer.Invoke(new MethodInvoker(() => this.LogViewer.Items.Add(item)));
                this.LogViewer.Invoke(new MethodInvoker(() => this.LogViewer.EnsureVisible(this.LogViewer.Items.Count - 1)));
            }
            else
            {
                this.LogViewer.Items.Add(item);
                this.LogViewer.EnsureVisible(this.LogViewer.Items.Count - 1);
            }
        }

        private void AddErrorLog(object sender, string log)
        {
            ListViewItem item = new ListViewItem();
            item.ForeColor = Color.Red;
            item.Text = DateTime.Now.ToString("HH:mm:ss");
            item.SubItems.Add(log);
            if (this.LogViewer.InvokeRequired)
            {
                this.LogViewer.Invoke(new MethodInvoker(() => this.LogViewer.Items.Add(item)));
                this.LogViewer.Invoke(new MethodInvoker(() => this.LogViewer.EnsureVisible(this.LogViewer.Items.Count - 1)));
            }
            else
            {
                this.LogViewer.Items.Add(item);
                this.LogViewer.EnsureVisible(this.LogViewer.Items.Count - 1);
            }
        }

        #endregion
    }
}
