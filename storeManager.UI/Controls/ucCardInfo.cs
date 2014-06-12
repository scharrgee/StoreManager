using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.UI.EventHub;

namespace storeManager.UI.Controls
{
    public partial class ucCardInfo : UserControl
    {
        private ICustomerService _customer;
        private ISupplierService _supplier;
        private IEmployeeService _employee;
        IErrorService _logger;

        string _state = "";
        int _customerID = 0;
        int _supplierID = 0;
        int _employeeID = 0;

        public ucCardInfo()
        {
            InitializeComponent();
            PopulateCardTypeCombo();
            PopulateSexCombo();
            InitEvents();
            GetEntityState = EntityState.New;

            _supplier = new SupplierService();
            _customer = new CustomerService();
            _employee = new EmployeeService();
            _logger = new ErrorLogService();
        }

        //EntityState state = EntityState.New;

        public EntityState GetEntityState { get; set; }


        void InitEvents()
        {
            Hub.GenericInfo += new EventHandler<EventHubAgs>(Hub_GenericInfo);
        }

        void Hub_GenericInfo(object sender, EventHubAgs e)
        {
            try
            {
                TextBox txt = this.Controls.Find(e.ControlName, true).FirstOrDefault() as TextBox;

                if (txt == null) return;

                txt.Text = e.Data;
                txt.Tag = e.ID;

                if (txt.Tag == null || txt.Tag.ToString() == "0") return;

                ConfigureForm("Update");

                switch (cmbCardType.Text)
                {
                    case "Customer":
                        _customerID = txt.Tag.ToInt();
                        ConfigureFormForCustomerUpdate(_customerID);
                        break;
                    case "Supplier":
                        _supplierID = txt.Tag.ToInt();
                        ConfigureFormForSupplierUpdate(_supplierID);
                        break;
                    case "Employee":
                        _employeeID = txt.Tag.ToInt();
                        ConfigureFormForEmployeeUpdate(_employeeID);
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "ucCardInfo", "");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        enum Sex
        {
            Male,
            Female
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Helper.ValidateTexBox(txtName))
                return;

            if (!Helper.ValidateTexBox(txtContact))
                return;

            switch (cmbCardType.Text)
            {
                case "Customer":

                    Customer cust = new Customer();

                    try
                    {
                        //cust.CardID = int.Parse(cmbCardType.SelectedValue.ToString());
                        cust.ContactPerson = txtContact.Text;
                        //cust.SupplierNum = txtCardID.Text;
                        cust.PostalAddress = txtAddress.Text;
                        cust.CustomerSince = dtpSupplierSince.Value;
                        //cust.DesignationID = int.Parse(cmbDesignation.SelectedValue.ToString());
                        cust.LocationAdress = txtLocation.Text;
                        cust.EmailAddress = txtEmail.Text.Trim();
                        cust.CustomerName = txtName.Text.Trim();
                        cust.PhoneNumber1 = txtPhone1.Text.Trim();
                        cust.PhoneNumber2 = txtPhone2.Text.Trim();
                        cust.PhoneNumber3 = txtPhone3.Text.Trim();
                        cust.Salutation = txtSalutation.Text; ;
                        cust.City = txtCity.Text.Trim();
                        cust.Website = txtWebsite.Text.Trim();
                        cust.DateAdded = DateTime.Now;

                        switch (GetEntityState)
                        {
                            case EntityState.New:
                                _customer.Add(cust);
                                Helper.ShowMessage("Customer " + OperationStatus.SUCCESS_ADD, "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case EntityState.Dirty:
                                cust.CustomerID = _customerID;
                                _customer.Update(cust, c => c.CustomerID == _customerID);
                                Helper.ShowMessage("Customer " + OperationStatus.SUCCESS_UPDATE, "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                                ConfigureForm("Save");
                                break;
                        }

                        Helper.ClearForm(this);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred", "ucCardInfo", "btnSave|Customer");
                        Helper.ShowMessage(OperationStatus.FAILURE + "\n" + ex.Message, "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Supplier":

                    Supplier supplier = new Supplier();

                    try
                    {
                        //supplier.CardID = int.Parse(cmbCardType.SelectedValue.ToString());
                        supplier.ContactPerson = txtContact.Text;
                        //supplier.SupplierNum = txtCardID.Text;
                        supplier.PostalAddress = txtAddress.Text;
                        supplier.SupplierSince = dtpSupplierSince.Value;
                        //supplier.DesignationID = int.Parse(cmbDesignation.SelectedValue.ToString());
                        supplier.LocationAdress = txtLocation.Text;
                        supplier.Email = txtEmail.Text.Trim();
                        supplier.Name = txtName.Text.Trim();
                        supplier.PhoneNumber1 = txtPhone1.Text.Trim();
                        supplier.PhoneNumber2 = txtPhone2.Text.Trim();
                        supplier.PhoneNumber3 = txtPhone3.Text.Trim();
                        supplier.Salutation = txtSalutation.Text; ;
                        supplier.City = txtCity.Text.Trim();
                        supplier.Website = txtWebsite.Text.Trim();

                        switch (GetEntityState)
                        {
                            case EntityState.New:
                                _supplier.Add(supplier);
                                Helper.ShowMessage("Supplier " + OperationStatus.SUCCESS_ADD, "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case EntityState.Dirty:
                                supplier.SupplierID = _supplierID;
                                _supplier.Update(supplier, s => s.SupplierID == _supplierID);
                                Helper.ShowMessage(OperationStatus.SUCCESS_UPDATE, "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                ConfigureForm("Save");
                                break;
                        }

                        Helper.ClearForm(this);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred", "ucCardInfo", "btnSave|Supplier");
                        Helper.ShowMessage(OperationStatus.FAILURE + "\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    break;
                case "Employee":

                    Employee employee = new Employee();

                    try
                    {
                        //supplier.CardID = int.Parse(cmbCardType.SelectedValue.ToString());
                        employee.ContactPerson = txtContact.Text;
                        //supplier.SupplierNum = txtCardID.Text;
                        employee.OtherNames = txtOnames.Text;
                        employee.Sex = cmbSex.Text;
                        employee.FisrtName = txtName.Text;
                        //employee.LocationAdress = txtLocation.Text;
                        employee.Email = txtEmail.Text.Trim();
                        employee.Address = txtAddress.Text.Trim();
                        employee.PhoneNumber1 = txtPhone1.Text.Trim();
                        employee.PhoneNumber2 = txtPhone2.Text.Trim();
                        employee.PhoneNumber3 = txtPhone3.Text.Trim();
                        //employee.Salutation = txtSalutation.Text; ;
                        //employee.City = txtCity.Text.Trim();
                        employee.EmployeeSince = dtpSupplierSince.Value;

                        switch (GetEntityState)
                        {
                            case EntityState.New:
                                _employee.Add(employee);
                                Helper.ShowMessage("Employee " + OperationStatus.SUCCESS_ADD, "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case EntityState.Dirty:
                                employee.EmployeeID = _employeeID;
                                _employee.Update(employee, em => em.EmployeeID == _employeeID);
                                Helper.ShowMessage(OperationStatus.SUCCESS_UPDATE, "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                ConfigureForm("Save");
                                break;
                            default:
                                break;
                        }

                        Helper.ClearForm(this);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred", "ucCardInfo", "btnSave|Employee");
                        Helper.ShowMessage(OperationStatus.FAILURE + "\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "Personal":
                    break;
            }
        }

        private void PopulateCardTypeCombo()
        {
            cmbCardType.DataSource = new GenericService<CardInformation>().GetAll();
            cmbCardType.ValueMember = "CardID";
            cmbCardType.DisplayMember = "CardType";
            cmbCardType.Select("Employee");
        }

        private void PopulateSexCombo()
        {
            cmbSex.DataSource = Enum.GetNames(typeof(Sex));
        }

        private void cmbCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbCardType.Text)
            {
                case "Customer":
                case "Supplier":
                    ConfigureUI("Name :", false, lblName.Left);
                    break;
                case "Employee":
                case "Personal":
                    ConfigureUI("First Name :", true, lblName.Left - 25);
                    break;
                default:
                    ConfigureUI("Name :", false, lblName.Left);
                    break;
            }
        }

        private void ConfigureUI(string name, bool show, int lblOffset)
        {
            lblFirstName.Text = name;
            lblOnames.Visible = show;
            lblSex.Visible = show;

            txtOnames.Visible = show;
            cmbSex.Visible = show;

            lblFirstName.Left = lblOffset;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ((Form)this.Parent).Close();
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            new frmDescription("txtDescription", txtDescription.Text).ShowDialog();
        }

        void SetTitle()
        {
            //((Form)this.Parent).Text = "Card Information Management";
        }

        private void ucCardInfo_Load(object sender, EventArgs e)
        {
            SetTitle();
        }

        void DisableControls()
        {
            txtLocation.Enabled = false;
        }

        private void btnSave_TextChanged(object sender, EventArgs e)
        {
            switch (_state)
            {
                case "Save":
                    GetEntityState = EntityState.New;
                    cmbCardType.Enabled = true;
                    break;
                case "Update":
                    GetEntityState = EntityState.Dirty;
                    cmbCardType.Enabled = false;
                    break;
            }
        }

        private void btnSelectCard_Click(object sender, EventArgs e)
        {
            switch (cmbCardType.Text)
            {
                case "Customer":
                    new frmChooseCustomer(false,"txtName").ShowDialog();
                    break;
                case "Supplier":
                    new frmChooseSupplier(false).ShowDialog();
                    break;
                case "Employee":
                    new frmChooseEmployee(false).ShowDialog();
                    break;
            }
        }

        public void ConfigureForm(string state)
        {
            _state = state;
            btnSave.Text = state;
        }

        void ConfigureFormForCustomerUpdate(int custID)
        {
            Customer cust = _customer.GetSingle(c => c.CustomerID == custID);

            txtContact.Text = cust.ContactPerson;
            txtAddress.Text = cust.PostalAddress;
            dtpSupplierSince.Value = cust.CustomerSince ?? DateTime.Now;
            txtLocation.Text = cust.LocationAdress;
            txtEmail.Text = cust.EmailAddress;
            txtName.Text = cust.CustomerName;
            txtPhone1.Text = cust.PhoneNumber1;
            txtPhone2.Text = cust.PhoneNumber2;
            txtPhone3.Text = cust.PhoneNumber3;
            txtSalutation.Text = cust.Salutation;
            txtCity.Text = cust.City;
            txtWebsite.Text = cust.Website;
        }

        void ConfigureFormForSupplierUpdate(int supplierID)
        {
            Supplier supplier = _supplier.GetSingle(s => s.SupplierID == supplierID);

            txtContact.Text = supplier.ContactPerson;
            txtAddress.Text = supplier.PostalAddress;
            dtpSupplierSince.Value = supplier.SupplierSince ?? DateTime.Now;
            txtLocation.Text = supplier.LocationAdress;
            txtEmail.Text = supplier.Email;
            txtName.Text = supplier.Name;
            txtPhone1.Text = supplier.PhoneNumber1;
            txtPhone2.Text = supplier.PhoneNumber2;
            txtPhone3.Text = supplier.PhoneNumber3;
            txtSalutation.Text = supplier.Salutation;
            txtCity.Text = supplier.City;
            txtWebsite.Text = supplier.Website;
        }

        void ConfigureFormForEmployeeUpdate(int employeeID)
        {
            Employee employee = _employee.GetSingle(e => e.EmployeeID == _employeeID);

            if (employee == null) return;

            txtOnames.Text = employee.OtherNames;
            cmbSex.Text = employee.Sex;
            txtName.Text = employee.FisrtName;
            txtEmail.Text = employee.Email;
            txtAddress.Text = employee.Address;
            txtPhone1.Text = employee.PhoneNumber1;
            txtPhone2.Text = employee.PhoneNumber2;
            txtPhone3.Text = employee.PhoneNumber3;
            dtpSupplierSince.Value = employee.EmployeeSince ?? DateTime.Now;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Helper.ClearForm(this);
            ConfigureForm("Save");
            txtName.Focus();
        }
    }
}
