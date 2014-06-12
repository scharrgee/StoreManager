using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BusinessLayer;
using storeManager.Entities;

using storeManager.UI.Controls;

namespace storeManager.UI
{
    public partial class frmChooseSupplier : Form
    {
        IEnumerable<Supplier> suppliers;

        public frmChooseSupplier()
        {
            InitializeComponent();
            LoadListView();
            
        }

        public frmChooseSupplier(bool enable)
        {
            InitializeComponent();
            LoadListView();
            btnNewSupplier.Enabled = enable;
        }

        private void btnNewCusromer_Click(object sender, EventArgs e)
        {
            if (!Helper.IsAdmin()) return;

            frmControlHost host = new frmControlHost();
            ucCardInfo info = new ucCardInfo();

            info.Dock = DockStyle.Fill;

            host.Controls.Add(info);

            host.ShowDialog();
        }

        private void lvSuppliers_DoubleClick(object sender, EventArgs e)
        {
            btnOK.PerformClick();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvSuppliers.SelectedItems.Count == 0) return; 

            EventHub.Hub.OnGenericInfoCall(lvSuppliers.SelectedItems[0].SubItems[0].Text,
                lvSuppliers.SelectedItems[0].SubItems[1].Text, "txtSupplier");

            this.Close();
        }

        private void LoadListView()
        {   
            Helper.WaitCursor(this);
            suppliers = new SupplierService().GetAll();

            lvSuppliers.PopulateListView(suppliers);
            Helper.DefaultCursor(this);
        }

        private void frmChooseSupplier_Activated(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void txtLookForSupplier_TextChanged(object sender, EventArgs e)
        {
            Helper.WaitCursor(this);
            lvSuppliers.PopulateListView(suppliers.Where(s=>s.Name.ToLower().Contains(txtLookForSupplier.Text.ToLower())));
            Helper.DefaultCursor(this);
        }
    }
}
