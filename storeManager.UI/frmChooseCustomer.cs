using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using storeManager.Entities;
using BusinessLayer;
using storeManager.UI.Controls;

namespace storeManager.UI
{
    public partial class frmChooseCustomer : Form
    {
        IEnumerable<Customer> customers;
        string _controlName = "";

        public frmChooseCustomer()
        {
            InitializeComponent();

            CenterToScreen();
            LoadListView();
        }

        public frmChooseCustomer(bool enable,string controlName)
        {
            InitializeComponent();

            CenterToScreen();
            LoadListView();

            btnNewCusromer.Enabled = enable;
            _controlName = controlName;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            SetCustomerName();

            this.Close();
        }

        private void SetCustomerName()
        {
            if (lvCustomers.SelectedItems.Count == 0) return;

            EventHub.Hub.OnGenericInfoCall(lvCustomers.SelectedItems[0].SubItems[0].Text,
               lvCustomers.SelectedItems[0].SubItems[1].Text, _controlName);
        }

        private void lvCustomers_DoubleClick(object sender, EventArgs e)
        {
            btnOK.PerformClick();
        }

        private void txtLookForCustomer_TextChanged(object sender, EventArgs e)
        {
            //DataTable dtCat;// = Customer.GetCustomer();

            //string expression = string.Format("Name like '{0}*'", txtLookForCustomer.Text);

            //DataRow[] matches = dtCat.Select(expression);

            //lvCustomers.Items.Clear();
            //foreach (DataRow dr in matches)
            //{
            //    ListViewItem lvi = lvCustomers.Items.Add(dr["CustomerID"].ToString());
            //    lvi.SubItems.Add(dr["Name"].ToString());
            //}      

            Helper.WaitCursor(this);
            lvCustomers.PopulateListView(customers.Where(c => c.CustomerName.ToLower().Contains(txtLookForCustomer.Text.ToLower())));
            Helper.DefaultCursor(this);
        }

        private void LoadListView()
        {
            Helper.WaitCursor(this);
            customers = new CustomerService().GetAll();

            lvCustomers.PopulateListView(customers);
            Helper.DefaultCursor(this);
        }

        private void frmChooseCustomer_Activated(object sender, EventArgs e)
        {          
            LoadListView();           
        }
    }
}
