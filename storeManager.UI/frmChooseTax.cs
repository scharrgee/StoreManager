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

namespace storeManager.UI
{
    public partial class frmChooseTax : Form
    {
        IEnumerable<Tax> taxes;

        public frmChooseTax()
        {
            InitializeComponent();
            LoadListView();
        }

        public frmChooseTax(bool enable)
        {
            InitializeComponent();
            LoadListView();
            btnNewTax.Enabled = enable;
        }

        private void lvTax_DoubleClick(object sender, EventArgs e)
        {
            btnOK.PerformClick();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvTax.SelectedItems.Count == 0) return;

            EventHub.Hub.OnTaxInfoCall(lvTax.SelectedItems[0].SubItems[0].Text,
                lvTax.SelectedItems[0].SubItems[1].Text + "," + lvTax.SelectedItems[0].SubItems[2].Text, "txtSalTax");

            this.Close();
        }

        private void LoadListView()
        {
            Helper.WaitCursor(this);
            taxes = new TaxService().GetAll();

            lvTax.PopulateListView(taxes);
            Helper.DefaultCursor(this);
        }

        private void frmChooseTax_Activated(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void btnNewTax_Click(object sender, EventArgs e)
        {
            if (!Helper.IsAdmin()) return;
            new frmAddTax().ShowDialog();  
        }

        private void txtLookForTax_TextChanged(object sender, EventArgs e)
        {
            Helper.WaitCursor(this);
            lvTax.PopulateListView(taxes.Where(t => t.TaxName.ToLower().Contains(txtLookForTax.Text.ToLower())));
            Helper.DefaultCursor(this);
        }
    }
}
