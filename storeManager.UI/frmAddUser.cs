using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;

using storeManager.UI.EventHub;
using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.UI.ViewModels;
using Telerik.WinControls.UI;


namespace storeManager.UI
{
    public partial class frmAddUser : Telerik.WinControls.UI.RadForm
    {
        GenericService<AccessRight> _accessRightService = new GenericService<AccessRight>();
        AccessRight _right = new AccessRight();
        List<AccessRight> _rights;
        User _user;
        IErrorService _logger;
        EntityState _state = EntityState.New;

        int _userID = 0;

        public frmAddUser()
        {
            InitializeComponent();

            LoadCopyFromButton();
            _logger = new ErrorLogService();
        }

        public frmAddUser(List<AccessRight> rights, int userID)
        {
            InitializeComponent();

            _logger = new ErrorLogService();
            _rights = rights;
            _state = EntityState.Dirty;
            _userID = userID;
        }

        public EntityState State
        {
            get { return _state; }
            set { _state = value; }
        }

        public List<AccessRight> Rights
        {
            get { return _rights; }
            set { _rights = value; }
        }

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            //SetUpFormForUpdate();
        }

        public void SetUpFormForUpdate(int userID = 0)
        {
            if (!(_state == EntityState.Dirty)) return;

            _user = new GenericService<User>().GetSingle(u => u.UserID == _userID);

            txtUserName.Text = _user.UserName;
            txtPassword.Text = _user.UserPassword;
            chkActive.Checked = _user.Active.Value;
            chkIsAdmin.Checked = _user.IsAdmin.Value;

            LoadAccessRights();
        }

        private void LoadAccessRights()
        {
            try
            {
                chkSaleEdit.Checked = _rights.Where(r => r.FormID == ApplicationFroms.ucSale.ToString() && r.UserID == _userID).FirstOrDefault().CanEdit.Value;
                chkSaleView.Checked = _rights.Where(r => r.FormID == ApplicationFroms.ucSale.ToString() && r.UserID == _userID).FirstOrDefault().CanView.Value;

                chkOrderEdit.Checked = _rights.Where(r => r.FormID == ApplicationFroms.ucOrder.ToString() && r.UserID == _userID).FirstOrDefault().CanEdit.Value;
                chkOrderView.Checked = _rights.Where(r => r.FormID == ApplicationFroms.ucOrder.ToString() && r.UserID == _userID).FirstOrDefault().CanView.Value;

                chkQuoteEdit.Checked = _rights.Where(r => r.FormID == ApplicationFroms.ucQuote.ToString() && r.UserID == _userID).FirstOrDefault().CanEdit.Value;
                chkQuoteView.Checked = _rights.Where(r => r.FormID == ApplicationFroms.ucQuote.ToString() && r.UserID == _userID).FirstOrDefault().CanView.Value;

                chkAdjustStockEdit.Checked = _rights.Where(r => r.FormID == ApplicationFroms.ucAdjustStock.ToString() && r.UserID == _userID).FirstOrDefault().CanEdit.Value;

                chkAddProductEdit.Checked = _rights.Where(r => r.FormID == ApplicationFroms.ucNewProduct.ToString() && r.UserID == _userID).FirstOrDefault().CanEdit.Value;

                chkProductListEdit.Checked = _rights.Where(r => r.FormID == ApplicationFroms.ucProductList.ToString() && r.UserID == _userID).FirstOrDefault().CanEdit.Value;
                chkProductListView.Checked = _rights.Where(r => r.FormID == ApplicationFroms.ucProductList.ToString() && r.UserID == _userID).FirstOrDefault().CanView.Value;

                chkProductPricing.Checked = _rights.Where(r => r.FormID == ApplicationFroms.ucProductPricing.ToString() && r.UserID == _userID).FirstOrDefault().CanEdit.Value;

                chkTransferStockEdit.Checked = _rights.Where(r => r.FormID == ApplicationFroms.ucTransferStocks.ToString() && r.UserID == _userID).FirstOrDefault().CanEdit.Value;
                chkCurrentStockView.Checked = _rights.Where(r => r.FormID == ApplicationFroms.ucCurrentStock.ToString() && r.UserID == _userID).FirstOrDefault().CanView.Value;

                chkCompanyEdit.Checked = _rights.Where(r => r.FormID == ApplicationFroms.frmAddCompany.ToString() && r.UserID == _userID).FirstOrDefault().CanEdit.Value;
                chkCompanyView.Checked = _rights.Where(r => r.FormID == ApplicationFroms.frmAddCompany.ToString() && r.UserID == _userID).FirstOrDefault().CanView.Value;

                chkReportsView.Checked = _rights.Where(r => r.FormID == ApplicationFroms.frmReportParameters.ToString() && r.UserID == _userID).FirstOrDefault().CanView.Value;
            }
            catch
            {

            }
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                Helper.ShowMessage("Please enter a user name, user name is required", "User Name Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtPassword.Text == "")
            {
                Helper.ShowMessage("Please enter a password, password is required", "Password Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }        

            switch (_state)
            {
                case EntityState.New:
                    try
                    {
                        if (txtPassword.Text != txtConfirmPassword.Text)
                        {
                            Helper.ShowMessage("Passwords must match", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }     

                        if (lblEmployeeDetail.Tag == null)
                        {
                            Helper.ShowMessage("A user must be associated with an employee", "Invalid Employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        SaveUserInfo();
                        AddSaleAccessRights();
                        AddInventoryAccessRights();
                        AddCompanyAccessRights();
                        AddReportAccessRights();

                        Helper.ShowMessage("User info saved successfully", "User Info Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred", "frmAddUser", "btnSave");
                        Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
                case EntityState.Dirty:
                    try
                    {
                        UpdateUserInfo();
                        UpdateSaleAccessRights();
                        UpdateInventoryAccessRights();
                        UpdateCompanyAccessRights();
                        UpdateReportAccessRights();

                        Helper.ShowMessage("User info saved successfully", "User Info Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred", "frmAddUser", "UpdateUser");
                        Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
            }

        }

        void AddSaleAccessRights()
        {
            _right = new AccessRight
             {
                 CanEdit = chkSaleEdit.Checked,
                 CanView = chkSaleView.Checked,
                 UserID = _userID,
                 FormID = ApplicationFroms.ucSale.ToString()
             };

            AddAccessRight(_right);

            _right = new AccessRight
            {
                CanEdit = chkOrderEdit.Checked,
                CanView = chkOrderView.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucOrder.ToString()
            };

            AddAccessRight(_right);

            _right = new AccessRight
            {
                CanEdit = chkQuoteEdit.Checked,
                CanView = chkQuoteView.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucQuote.ToString()
            };

            AddAccessRight(_right);
        }

        void AddInventoryAccessRights()
        {
            _right = new AccessRight
            {
                CanEdit = chkAddProductEdit.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucNewProduct.ToString()
            };

            AddAccessRight(_right);

            _right = new AccessRight
            {
                CanEdit = chkAdjustStockEdit.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucAdjustStock.ToString()
            };

            AddAccessRight(_right);

            _right = new AccessRight
            {
                CanEdit = chkAdjustStockEdit.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucAdjustStock.ToString()
            };

            AddAccessRight(_right);

            _right = new AccessRight
            {
                CanEdit = chkProductListEdit.Checked,
                CanView = chkProductListView.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucProductList.ToString()
            };

            AddAccessRight(_right);

            _right = new AccessRight
            {
                CanEdit = chkProductPricing.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucProductPricing.ToString()
            };

            AddAccessRight(_right);

            _right = new AccessRight
            {
                CanEdit = chkTransferStockEdit.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucTransferStocks.ToString()
            };

            AddAccessRight(_right);

            _right = new AccessRight
            {
                CanView = chkCurrentStockView.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucCurrentStock.ToString()
            };

            AddAccessRight(_right);
        }

        void AddCompanyAccessRights()
        {
            _right = new AccessRight
            {
                CanEdit = chkCompanyEdit.Checked,
                CanView = chkCompanyView.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.frmAddCompany.ToString()
            };

            AddAccessRight(_right);
        }

        void AddReportAccessRights()
        {
            _right = new AccessRight
            {
                CanView = chkReportsView.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.frmReportParameters.ToString()
            };

            AddAccessRight(_right);
        }

        void UpdateSaleAccessRights()
        {
            _right = new AccessRight
            {
                CanEdit = chkSaleEdit.Checked,
                CanView = chkSaleView.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucSale.ToString(),
                Id = _rights.Where(r => r.FormID == ApplicationFroms.ucSale.ToString() && r.UserID == _userID).FirstOrDefault().Id
            };

            UpdateAccessRight(_right, ApplicationFroms.ucSale);

            _right = new AccessRight
            {
                CanEdit = chkOrderEdit.Checked,
                CanView = chkOrderView.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucOrder.ToString(),
                Id = _rights.Where(r => r.FormID == ApplicationFroms.ucOrder.ToString() && r.UserID == _userID).FirstOrDefault().Id
            };

            UpdateAccessRight(_right, ApplicationFroms.ucOrder);

            _right = new AccessRight
            {
                CanEdit = chkQuoteEdit.Checked,
                CanView = chkQuoteView.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucQuote.ToString(),
                Id = _rights.Where(r => r.FormID == ApplicationFroms.ucQuote.ToString() && r.UserID == _userID).FirstOrDefault().Id
            };

            UpdateAccessRight(_right, ApplicationFroms.ucQuote);
        }

        void UpdateInventoryAccessRights()
        {
            _right = new AccessRight
            {
                CanEdit = chkAddProductEdit.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucNewProduct.ToString(),
                Id = _rights.Where(r => r.FormID == ApplicationFroms.ucNewProduct.ToString() && r.UserID == _userID).FirstOrDefault().Id
            };

            UpdateAccessRight(_right, ApplicationFroms.ucNewProduct);

            _right = new AccessRight
            {
                CanEdit = chkAdjustStockEdit.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucAdjustStock.ToString(),
                Id = _rights.Where(r => r.FormID == ApplicationFroms.ucAdjustStock.ToString() && r.UserID == _userID).FirstOrDefault().Id
            };

            UpdateAccessRight(_right, ApplicationFroms.ucAdjustStock);

            _right = new AccessRight
            {
                CanEdit = chkProductListEdit.Checked,
                CanView = chkProductListView.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucProductList.ToString(),
                Id = _rights.Where(r => r.FormID == ApplicationFroms.ucProductList.ToString() && r.UserID == _userID).FirstOrDefault().Id
            };

            UpdateAccessRight(_right, ApplicationFroms.ucProductList);

            _right = new AccessRight
            {
                CanEdit = chkProductPricing.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucProductPricing.ToString(),
                Id = _rights.Where(r => r.FormID == ApplicationFroms.ucProductPricing.ToString() && r.UserID == _userID).FirstOrDefault().Id
            };

            UpdateAccessRight(_right, ApplicationFroms.ucProductPricing);

            _right = new AccessRight
            {
                CanEdit = chkTransferStockEdit.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucTransferStocks.ToString(),
                Id = _rights.Where(r => r.FormID == ApplicationFroms.ucTransferStocks.ToString() && r.UserID == _userID).FirstOrDefault().Id
            };

            UpdateAccessRight(_right, ApplicationFroms.ucCurrentStock);

            _right = new AccessRight
            {
                CanView = chkCurrentStockView.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.ucCurrentStock.ToString(),
                Id = _rights.Where(r => r.FormID == ApplicationFroms.ucCurrentStock.ToString() && r.UserID == _userID).FirstOrDefault().Id
            };

            UpdateAccessRight(_right, ApplicationFroms.ucCurrentStock);
        }

        void UpdateCompanyAccessRights()
        {
            _right = new AccessRight
            {
                CanEdit = chkCompanyEdit.Checked,
                CanView = chkCompanyView.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.frmAddCompany.ToString(),
                Id = _rights.Where(r => r.FormID == ApplicationFroms.frmAddCompany.ToString() && r.UserID == _userID).FirstOrDefault().Id
            };

            UpdateAccessRight(_right, ApplicationFroms.frmAddCompany);
        }

        void UpdateReportAccessRights()
        {
            _right = new AccessRight
            {
                CanView = chkReportsView.Checked,
                UserID = _userID,
                FormID = ApplicationFroms.frmReportParameters.ToString(),
                Id = _rights.Where(r => r.FormID == ApplicationFroms.frmReportParameters.ToString() && r.UserID == _userID).FirstOrDefault().Id
            };

            UpdateAccessRight(_right, ApplicationFroms.frmReportParameters);
        }

        void AddAccessRight(AccessRight rights)
        {
            _accessRightService.Add(rights);
        }

        void UpdateAccessRight(AccessRight rights, ApplicationFroms form)
        {
            _accessRightService.Update(rights, r => r.UserID == _userID && r.FormID == form.ToString());
        }

        void SaveUserInfo()
        {
            if (!(txtPassword.Text == txtConfirmPassword.Text))
                throw new Exception("Both passwords must match");

            _user = new GenericService<User>().Add(new User
              {
                  Active = chkActive.Checked,
                  DateCreated = DateTime.Now,
                  UserName = txtUserName.Text,
                  IsAdmin = chkIsAdmin.Checked,
                  UserPassword = txtPassword.Text,
                  EmployeeID = lblEmployeeDetail.Tag.ToInt()
              });

            _userID = _user.UserID;
        }

        void UpdateUserInfo()
        {
            new GenericService<User>().Update(new User
            {
                Active = chkActive.Checked,
                UserName = txtUserName.Text,
                UserPassword = txtPassword.Text,
                IsAdmin = chkIsAdmin.Checked,
                UserID = _userID
            }, u => u.UserID == _userID);
        }

        private void btnShowUsers_Click(object sender, EventArgs e)
        {
            SetUpCheckBoxes(true);
        }

        private void lblShowUsers_Click(object sender, EventArgs e)
        {
            new frmUsers().ShowDialog();
        }

        void ClearForm()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";

            chkActive.Checked = false;
            chkIsAdmin.Checked = false;

            SetUpCheckBoxes(false);
        }

        private void SetUpCheckBoxes(bool status)
        {
            chkSaleEdit.Checked = status;
            chkSaleView.Checked = status;

            chkOrderEdit.Checked = status;
            chkOrderView.Checked = status;

            chkQuoteEdit.Checked = status;
            chkQuoteView.Checked = status;

            chkAdjustStockEdit.Checked = status;

            chkAddProductEdit.Checked = status;

            chkProductListEdit.Checked = status;
            chkProductListView.Checked = status;

            chkProductPricing.Checked = status;

            chkTransferStockEdit.Checked = status;
            chkCurrentStockView.Checked = status;

            chkCompanyEdit.Checked = status;
            chkCompanyView.Checked = status;

            chkReportsView.Checked = status;
        }

        void LoadCopyFromButton()
        {
            new GenericService<User>().GetAll().ToList().ForEach(u =>
            {
                RadMenuItem item = new RadMenuItem();
                item.Text = u.UserName;
                item.Tag = u.UserID;
                btnCopyFrom.Items.Add(item);
                item.Click += new EventHandler(btnCopyFromitem_Click);
            });
        }

        void btnCopyFromitem_Click(object sender, EventArgs e)
        {
            RadMenuItem item = (RadMenuItem)sender;
            _userID = item.Tag.ToInt();

            _rights = new GenericService<AccessRight>().Query(u => u.UserID == _userID).ToList();

            LoadAccessRights();
        }

        public void SetEmployeeDetails(string employeeName, string id)
        {
            lblEmployeeDetail.Text = employeeName;
            lblEmployeeDetail.Tag = id;
        }

        private void lblEmployee_Click(object sender, EventArgs e)
        {
            new frmChooseEmployee().ShowDialog();
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            SetUpCheckBoxes(false);
        }
    }
}
