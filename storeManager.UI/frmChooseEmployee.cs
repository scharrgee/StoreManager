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
    public partial class frmChooseEmployee : Form
    {
        IEnumerable<Employee> employees;

        public frmChooseEmployee()
        {
            InitializeComponent();
            LoadListView();
        }

        public frmChooseEmployee(bool enable)
        {
            InitializeComponent();
            LoadListView();

            btnNewEmployee.Enabled = enable;
        }

        private void LoadListView()
        {
            Helper.WaitCursor(this);
            employees = new EmployeeService().GetAll();

            lvEmployee.PopulateListView(employees);
            Helper.DefaultCursor(this);
        }

        private void SetEmployeeName()
        {
            if (lvEmployee.SelectedItems.Count == 0) return;

            EventHub.Hub.OnGenericInfoCall(lvEmployee.SelectedItems[0].SubItems[0].Text,
               lvEmployee.SelectedItems[0].SubItems[1].Text, "txtName");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChooseEmployee_Activated(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvEmployee.Items.Count == 0) return;

            SetEmployeeName();
            SetEmployeeDetails();

            this.Close();
        }

        private void SetEmployeeDetails()
        {
            frmAddUser frmuser = Helper.CreateInstanceFor<frmAddUser>("frmAddUser") as frmAddUser;

            if (frmuser != null)
            {
                frmuser.SetEmployeeDetails(lvEmployee.SelectedItems[0].SubItems[1].Text, lvEmployee.SelectedItems[0].SubItems[0].Text);
            }
        }

        private void lvEmployee_DoubleClick(object sender, EventArgs e)
        {
            btnOK.PerformClick();
        }

        private void txtLookForEmployee_TextChanged(object sender, EventArgs e)
        {
            Helper.WaitCursor(this);
            lvEmployee.PopulateListView(employees.Where(em=>(em.FisrtName + " " + em.OtherNames).ToLower().Contains(txtLookForEmployee.Text.ToLower())));
            Helper.DefaultCursor(this);
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            if (!Helper.IsAdmin()) return;

            frmControlHost host = new frmControlHost();
            ucCardInfo info = new ucCardInfo();

            info.Dock = DockStyle.Fill;

            host.Controls.Add(info);

            host.ShowDialog();
        }
    }
}
