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
    public partial class frmChooseBrand : Form
    {
        IEnumerable<Brand> brands;
        string _controlName;

        public frmChooseBrand()
        {
            InitializeComponent();
            LoadListView();
        }

        public frmChooseBrand(string controlName)
        {
            InitializeComponent();
            LoadListView();

            _controlName = controlName;
        }

        private void btnNewBrand_Click(object sender, EventArgs e)
        {
            if (!Helper.IsAdmin()) return;

            new frmAddBrand().ShowDialog();          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvBrands_DoubleClick(object sender, EventArgs e)
        {
            btnOK.PerformClick(); 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvBrands.SelectedItems.Count == 0) return;

            EventHub.Hub.OnGenericInfoCall(lvBrands.SelectedItems[0].SubItems[0].Text,
              lvBrands.SelectedItems[0].SubItems[1].Text, string.IsNullOrEmpty(_controlName) ? "txtBrand" : _controlName);

            this.Close();
        }

        private void LoadListView()
        {         
            Helper.WaitCursor(this);
            brands = new BrandService().GetAll();

            lvBrands.PopulateListView(brands);
            Helper.DefaultCursor(this);
        }

        private void frmChooseBrand_Activated(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void txtLookForBrand_TextChanged(object sender, EventArgs e)
        {
            Helper.WaitCursor(this);
            lvBrands.PopulateListView(brands.Where(b => b.BrandName.ToLower().Contains(txtLookForBrand.Text.ToLower())));
            Helper.DefaultCursor(this);
        }
    }
}
