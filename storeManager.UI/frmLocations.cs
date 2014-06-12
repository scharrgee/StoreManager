using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.UI.ViewModels;
using storeManager.UI.EventHub;
using Telerik.WinControls.UI;

namespace storeManager.UI
{
    public partial class frmLocations : Telerik.WinControls.UI.RadForm
    {
        public frmLocations()
        {
            InitializeComponent();

            LoadLocations();
        }

        private void frmLocations_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<int> locationids = new List<int>();

            foreach (DataGridViewRow row in dgvLocations.SelectedRows)
            {
                locationids.Add(row.Cells[0].Value.ToInt());
            }

            Hub.OnProductTransfer(locationids);

            this.Close();
        }


        void LoadLocations()
        {
            dgvLocations.DataSource = new GenericService<Location>().GetAll();

            dgvLocations.Columns[0].Visible = false;
            dgvLocations.Columns["IsDefault"].Visible = false;
            dgvLocations.Columns["ProductLocations"].Visible = false;
            dgvLocations.Columns["Comment"].Visible = false;

            dgvLocations.Columns[1].Width = 360;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
