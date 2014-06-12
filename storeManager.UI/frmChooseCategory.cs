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
    public partial class frmChooseCategory : Form
    {
        IEnumerable<Category> categories;
        string _controlName;

        public frmChooseCategory()
        {
            InitializeComponent();

            LoadListView();
        }

        public frmChooseCategory(string controlName)
        {
            InitializeComponent();

            LoadListView();
            _controlName = controlName;
        }

        private void btnNewCusromer_Click(object sender, EventArgs e)
        {
            if (!Helper.IsAdmin()) return;

            frmAddCategory cat = new frmAddCategory();
            cat.ShowDialog();
        }

        private void lvCategory_DoubleClick(object sender, EventArgs e)
        {
            btnOK.PerformClick();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count == 0) return;

            EventHub.Hub.OnGenericInfoCall(lvCategory.SelectedItems[0].SubItems[0].Text,
                lvCategory.SelectedItems[0].SubItems[1].Text, string.IsNullOrEmpty(_controlName) ? "txtCategory" : _controlName);

            this.Close();
        }

        private void LoadListView()
        {           
            Helper.WaitCursor(this);
            categories = new CategoryService().GetAll();

            lvCategory.PopulateListView(categories);
            Helper.DefaultCursor(this);
        }

        private void frmChooseCategory_Activated(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void txtLookForCategory_TextChanged(object sender, EventArgs e)
        {
            Helper.WaitCursor(this);
            lvCategory.PopulateListView(categories.Where(c=>c.Name.ToLower().Contains(txtLookForCategory.Text.ToLower())));
            Helper.DefaultCursor(this);
        }
    }
}
