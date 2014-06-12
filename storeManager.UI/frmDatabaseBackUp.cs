using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using SqlServerUtility;
using System.Configuration;

using storeManager.UI.EventHub;
using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.UI.ViewModels;
using Telerik.WinControls.UI;

namespace storeManager.UI
{
    public partial class frmDatabaseBackUp : Telerik.WinControls.UI.RadForm
    {
        private string connString = ConfigurationManager.ConnectionStrings["StoreManagerConnString"].ConnectionString;
        //private string lastBackupKey = "LastBackUpFileName";
        //private string lastBackupPathKey = "LastBackUpFilePath";
        private string defaulFileName = Properties.Settings.Default.DefaultBackupFileName;
        string filePath = "";
        delegate void RunTaskAsync(String connString, String destinationPath, bool differential);

        delegate void UpdateUI();
        private bool exitLoop = false;
        private Timer timer = new Timer();
        int counter = 1;
        private string startTime = "";
        private string endTime = "";
        string backupFile = "";
        string lastBackupPath = "";

        public frmDatabaseBackUp()
        {
            InitializeComponent();

            chkDefault.Checked = true;
            CheckDifferentialChkStatus();
        }

        private void CheckDifferentialChkStatus()
        {
            chkDifferential.Enabled = EnableDifferentialChk(txtPath.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRunTask_Click(object sender, EventArgs e)
        {
            try
            {
                exitLoop = false;
                lblProgress.Text = "";

                if (chkDefault.Checked)
                {
                    startTime = DateTime.Now.ToShortTimeString();
                    BackUp();
                }
                else
                {
                    btnBrowse.PerformClick();
                    startTime = DateTime.Now.ToShortTimeString();
                    BackUp();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TaskPath(string path)
        {

            lblTaskPath.Text = "Backup Path : ";
            lblCurrntTask.Text = "Backing Up Database";
            txtPath.Text = path;
        }

        private string FormatDate()
        {
            string day = DateTime.Now.Day.ToString().Length == 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();

            return string.Concat(day, month, year);
        }

        private void CallBack(IAsyncResult results)
        {
            try
            {
                RunTaskAsync backupDB = results.AsyncState as RunTaskAsync;
                backupDB.EndInvoke(results);

                exitLoop = true;
                endTime = DateTime.Now.ToShortTimeString();

                SaveBackupDetails();

                UpdateDefaultFileName();
                MessageBox.Show("Operation completed successfully", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UIUpdate()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateUI(UIUpdate), null);
            }

            lblPercentageComplete.Text = BackupHelper.PercentageComplete.ToString() + "% Complete";

            if (exitLoop)
            {
                btnRunTask.Enabled = true;
                btnClose.Enabled = true;
                timer.Enabled = false;
                lblProgress.Text = "";
                counter = 1;
            }
            else
            {
                if (counter > 3)
                {
                    lblProgress.Text = "";
                    counter = 1;
                }
                else
                {
                    lblProgress.Text += ".";
                    counter++;
                }
            }
        }

        private void SetUpTimer()
        {
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (timer.Enabled)
                UIUpdate();
        }

        private void SelectFilePath(string title)
        {
            filePath = "";

            FolderBrowserDialog fDiag = new FolderBrowserDialog();

            if (fDiag.ShowDialog() == DialogResult.OK)
            {
                filePath = fDiag.SelectedPath;
                filePath += "\\" + defaulFileName + ".bak";

                TaskPath(filePath);
            }
        }

        private void PrepareForm()
        {
            exitLoop = false;
            btnClose.Enabled = false;
            btnRunTask.Enabled = false;
            SetUpTimer();
        }

        private void BackUp()
        {
            RunTaskAsync backup = new RunTaskAsync(BackupHelper.BackupDatabase);
            IAsyncResult result = backup.BeginInvoke(connString, filePath, chkDifferential.Checked, CallBack, backup);
            PrepareForm();
        }

        private string GetDefaultPath()
        {
            string tempPath = PathUtility.GetBackupPath(connString);
            string fileName = defaulFileName + FormatDate() + ".bak";
            string path = tempPath + fileName;

            backupFile = fileName;
            lastBackupPath = path;

            return path;
        }

        private void SaveBackupDetails()
        {
            BackupDetail backupDetail = new BackupDetail();
            backupDetail.BackupFolder = txtPath.Text;
            backupDetail.Comments = txtComment.Text;
            backupDetail.EndTime = endTime;
            backupDetail.StartTime = startTime;
            backupDetail.BackupDate = DateTime.Now;

            new GenericService<BackupDetail>().Add(backupDetail);
        }

        private void UpdateDefaultFileName()
        {
            try
            {
                Properties.Settings.Default.LastBackUpFilePath = lastBackupPath;
                Properties.Settings.Default.LastBackUpFileName = backupFile;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LastBackUpFileName()
        {
            try
            {
                backupFile = txtPath.Text.Substring(txtPath.Text.LastIndexOf('\\') + 1, txtPath.Text.LastIndexOf('.') - (txtPath.Text.LastIndexOf('\\') + 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            LastBackUpFileName();

            CheckDifferentialChkStatus();
        }

        private bool EnableDifferentialChk(string path)
        {
            try
            {
                return File.Exists(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private void frmDatabaseBackUp_Load(object sender, EventArgs e)
        {
            try
            {
                lastBackupPath = Properties.Settings.Default.LastBackUpFilePath;

                if (string.IsNullOrWhiteSpace(lastBackupPath))
                {
                    filePath = GetDefaultPath();
                    txtPath.Text = filePath;
                }
                else
                {
                    filePath = lastBackupPath;
                    txtPath.Text = filePath;
                }

                LastBackUpFileName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //txtPath.Text = Properties.Settings.Default.LastBackUpFilePath;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SelectFilePath("Backup");
        }
    }
}
