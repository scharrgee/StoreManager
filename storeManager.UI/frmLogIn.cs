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

namespace storeManager.UI
{
    public partial class frmLogIn : Telerik.WinControls.UI.RadForm
    {
        string _option = "Options >>";
        IErrorService _logger;

        public frmLogIn()
        {
            InitializeComponent();
            this.Height = 174;

            _logger = new ErrorLogService();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            switch (_option)
            {
                case "Options >>":
                    ConfigureForm("Options <<", 370);
                    break;
                case "Options <<":
                    ConfigureForm("Options >>", 174);
                    break;
            }
        }

        void ConfigureForm(string option, int height)
        {
            this.Height = height;
            _option = option;
            btnOption.Text = _option;

            int btnHeight = height - 60;
        }

        private void frmLogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CurrentUser.LogInSuccessful = false;
            Application.Exit();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            User user = new GenericService<User>().GetSingle(u => u.UserName.ToLower() == txtUserName.Text.ToLower() && u.UserPassword == txtPassword.Text);

            if (user == null)
            {
                Helper.ShowMessage("Invalid username or password", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CurrentUser.User = user;
            CurrentUser.LogInSuccessful = true;

            frmMain main = Helper.CreateInstanceFor<frmMain>("frmMain") as frmMain;

            if (main != null)
            {
                main.SetUserName();
            }

            this.Close();
        }

        private void btnModifyPass_Click(object sender, EventArgs e)
        {
            User user = new GenericService<User>().GetSingle(u => u.UserName.ToLower() == txtUserName.Text.ToLower() && u.UserPassword == txtOldPassword.Text);

            if (user == null)
            {
                Helper.ShowMessage("Invalid username or password", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                user.UserPassword = txtNewPassword.Text;
                new GenericService<User>().Update(user, u => u.UserID == user.UserID);

                Helper.ShowMessage("Credentials have been updated successfully", "Credentials Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNewPassword.Text = "";
                txtOldPassword.Text = "";
                txtConfirmPassword.Text = "";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "frmLogin", "btnModifyPass_Click");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
