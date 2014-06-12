using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;

using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.UI.ViewModels;

namespace storeManager.UI
{
    public partial class frmUsers : Telerik.WinControls.UI.RadForm
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            LoadUsersGrid();
        }

        private void LoadUsersGrid()
        {
            var users = new GenericService<User>().GetAll().Select(u => new { userID = u.UserID, userName = u.UserName });
            dgvUsers.DataSource = users;

            if (users.ToList().Count == 0) return;

            dgvUsers.Columns["userID"].IsVisible = false;

            dgvUsers.Columns["userName"].Width = 400;
            dgvUsers.Columns["userName"].HeaderText = "Name";
            dgvUsers.Columns["userName"].HeaderTextAlignment = ContentAlignment.MiddleLeft;
        }

        private void dgvUsers_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int userID = e.Row.Cells["userID"].Value.ToInt();

            frmAddUser frmadduser = Helper.CreateInstanceFor<frmAddUser>("frmAddUser");
            frmadduser.Rights = new GenericService<AccessRight>().Query(a => a.UserID == userID).ToList();
            frmadduser.UserID = userID;
            frmadduser.State = EntityState.Dirty;
            frmadduser.SetUpFormForUpdate();

            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;

            int userID = dgvUsers.Rows[dgvUsers.CurrentCell.RowIndex].Cells[0].Value.ToInt();

            new GenericService<User>().Delete(new User { UserID = userID }); 

            LoadUsersGrid();
        }
    }
}
