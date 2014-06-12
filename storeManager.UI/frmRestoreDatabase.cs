using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using SqlServerUtility;


namespace CreditFinance
{
    public partial class frmRestoreDatabase : Form
    {
        string connString = ConfigurationManager.AppSettings["DBSqlstring"].ToString();
        delegate void RunTaskAsync(String connString, String destinationPath);
        delegate void UpdateUI();
        string filePath = "";
        //BackupDetails backups = new BackupDetails();
        private Timer timer = new Timer();
        bool complete = false;

        public frmRestoreDatabase()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            CenterToScreen();
            ListBackups();

            pbProgress.Visible = false;
            Cursor.Current = Cursors.Default;
        }
        private void ListBackups()
        {
            try
            {
                //DataSet dats = backups.Get();
                //dtGridViewList.DataSource = dats.Tables[0];

                //dtGridViewList.Columns[0].HeaderText = "BackupID";
                //dtGridViewList.Columns[1].HeaderText = "Backup Date";
                //dtGridViewList.Columns[2].HeaderText = "Backup Path";
                //dtGridViewList.Columns[3].HeaderText = "Start Time";
                //dtGridViewList.Columns[4].HeaderText = "End Time";
                //dtGridViewList.Columns[5].HeaderText = "Comments";

                //dtGridViewList.Columns[0].Visible = false;
                //dtGridViewList.Columns[6].Visible = false;

                //dtGridViewList.Columns[1].Width = 100;
                //dtGridViewList.Columns[2].Width = 250;
                //dtGridViewList.Columns[5].Width = 200;

                //dtGridViewList.RowHeadersVisible = true;
                //dtGridViewList.AllowUserToAddRows = false;
                //dtGridViewList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //dtGridViewList.MultiSelect = false;
                //dtGridViewList.AllowUserToDeleteRows = false;
                //dtGridViewList.ReadOnly = true;
                //dtGridViewList.RowsDefaultCellStyle.BackColor = Color.AntiqueWhite;
                //dtGridViewList.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                //dats.Dispose();
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

        private void dtGridViewList_Click(object sender, EventArgs e)
        {
            if (dtGridViewList.SelectedRows.Count == 0)
                return;

            try
            {
                filePath = dtGridViewList[2, dtGridViewList.CurrentCell.RowIndex].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Restore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrepareForm()
        {
            btnClose.Enabled = false;
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
                btnClose.Enabled = true;
                complete = false;
            }

            if (pbProgress.Value > 100)
                pbProgress.Value = 0;
            else
                pbProgress.Value = RestoreHelper.PercentageComplete;
        }

        private void frmRestoreDatabase_Load(object sender, EventArgs e)
        {

        }
    }
}
