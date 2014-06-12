using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using storeManager.UI.EventHub;
using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.UI.ViewModels;
using Telerik.WinControls.UI;
using System.Configuration;
using SqlServerUtility;
using System.IO;

namespace storeManager.UI
{
    public partial class frmDatabaseRestore : Telerik.WinControls.UI.RadForm
    {
        private string connString = ConfigurationManager.ConnectionStrings["StoreManagerConnString"].ConnectionString;
        delegate void RunTaskAsync(String connString, String destinationPath);
        delegate void UpdateUI();
        string filePath = "";
        BackupDetail backups = new BackupDetail();
        private Timer timer = new Timer();
        bool complete = false;

        public frmDatabaseRestore()
        {
            InitializeComponent();
            ListBackups();

            pbProgress.Visible = false;
        }

        private void ListBackups()
        {
            try
            {
                dgvBackups.DataSource = new GenericService<BackupDetail>().GetAll();

                dgvBackups.Columns["BackupID"].HeaderText = "BackupID";
                dgvBackups.Columns["BackupDate"].HeaderText = "Backup Date";
                dgvBackups.Columns["BackupFolder"].HeaderText = "Backup Path";
                dgvBackups.Columns["StartTime"].HeaderText = "Start Time";
                dgvBackups.Columns["EndTime"].HeaderText = "End Time";
                dgvBackups.Columns["Comments"].HeaderText = "Comments";

                dgvBackups.Columns[0].IsVisible = false;
                dgvBackups.Columns[6].IsVisible = false;

                dgvBackups.Columns["BackupDate"].Width = 200;
                dgvBackups.Columns["BackupFolder"].Width = 400;
                dgvBackups.Columns["Comments"].Width = 200;
                dgvBackups.Columns["StartTime"].Width = 120;
                dgvBackups.Columns["EndTime"].Width = 120;
                
                dgvBackups.MultiSelect = false;

                dgvBackups.ReadOnly = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Restore()
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("No file name specified, Please select a valid path", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RunTaskAsync restore = new RunTaskAsync(RestoreHelper.RestoreDatabase);
            IAsyncResult result = restore.BeginInvoke(connString, filePath, CallBack, restore);
            PrepareForm();
        }

        private void CallBack(IAsyncResult results)
        {
            RunTaskAsync restoreDB = results.AsyncState as RunTaskAsync;
            restoreDB.EndInvoke(results);

            try
            {
                MessageBox.Show("Operation completed successfully", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                complete = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Restore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    MessageBox.Show("Please select a backup record to restore", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Restore();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Restore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrepareForm()
        {
            btnCancel.Enabled = false;
            btnRestore.Enabled = false;
            pbProgress.Visible = true;
            pbProgress.Maximum = 100;

            SetUpTimer();
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

        private void UIUpdate()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateUI(UIUpdate), null);
            }

            if (complete)
            {
                pbProgress.Visible = false;
                timer.Enabled = false;
                btnRestore.Enabled = true;
                btnCancel.Enabled = true;
                complete = false;
            }

            if (pbProgress.Value1 > 100)
                pbProgress.Value1 = 0;
            else
                pbProgress.Value1 = RestoreHelper.PercentageComplete;
        }

        private void frmDatabaseRestore_Load(object sender, EventArgs e)
        {

        }

        private void dgvBackups_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (dgvBackups.SelectedRows.Count == 0)
                return;

            try
            {
                //filePath = dgvBackups[2, dgvBackups.CurrentCell.RowIndex].Value.ToString();
                //filePath = dgvBackups.Rows[dgvBackups.CurrentCell.RowIndex].Cells[2].Value.ToString();
                filePath = e.Row.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Restore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
