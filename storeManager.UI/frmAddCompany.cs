using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;

using storeManager.Entities;
using BusinessLayer;
using BusinessLayer.Interfaces;

namespace storeManager.UI
{
    public partial class frmAddCompany : Telerik.WinControls.UI.RadForm
    {
        int _companyID = 0;
        IGenericService<Company> _companyService;
        Company _company;
        IErrorService _logger;

        public frmAddCompany()
        {
            InitializeComponent();
            _companyService = new GenericService<Company>();
            _logger = new ErrorLogService();

            LoadLocations();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FirstUse) return;

            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Helper.HasWriteAccess(ApplicationFroms.frmAddCompany)) return;

            if (txtCompanyName.Text == "")
            {
                Helper.ShowMessage("Please specify a company name", "Company Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cmbLocation.SelectedIndex == -1)
            {
                Helper.ShowMessage("Please select your default location", "Select Default Location", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Company company = new Company();
            company.Address1 = txtAddress.Text;
            company.Address2 = txtAddress2.Text;
            company.Address3 = txtAddress3.Text;
            company.CompanyName = txtCompanyName.Text;
            company.Email = txtEmail.Text;
            company.FaxNumber = txtFax.Text;
            company.Location = txtLocation.Text;
            company.Logo = pbLogo.Image == null ? null : Helper.ImageToByteArray(pbLogo.Image);
            company.Misc = txtMisc.Text;
            company.Motto = txtMotto.Text;
            company.PhoneLine1 = txtPhone.Text;
            company.PhoneLine2 = txtPhone2.Text;
            company.PhoneLine3 = txtPhone3.Text;
            company.WebSite = txtWebsite.Text;
            company.City = txtCity.Text;
            company.Country = txtCountry.Text;
            company.DefaultLocation = cmbLocation.SelectedValue.ToInt();

            try
            {
                if (_companyID == 0)
                    _companyService.Add(company);
                else
                {
                    company.CompanyID = _companyID;
                    _companyService.Update(company, c => c.CompanyID == _companyID);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "frmAddCustomer", "btnSave");
                Helper.ShowMessage("An error occured " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmAddCompany_Load(object sender, EventArgs e)
        {
            _company = _companyService.GetAll().FirstOrDefault();
            _companyID = _company == null ? 0 : _company.CompanyID;

            PopulateForm();
        }

        private void PopulateForm()
        {
            if (_companyID != 0)
            {
                txtAddress.Text = _company.Address1;
                txtAddress2.Text = _company.Address2;
                txtAddress3.Text = _company.Address3;
                txtCompanyName.Text = _company.CompanyName;
                txtEmail.Text = _company.Email;
                txtFax.Text = _company.FaxNumber;
                txtLocation.Text = _company.Location;
                pbLogo.Image = _company.Logo == null ? null : Helper.ByteArrayToImage(_company.Logo);
                txtMisc.Text = _company.Misc;
                txtPhone.Text = _company.PhoneLine1;
                txtPhone2.Text = _company.PhoneLine2;
                txtPhone3.Text = _company.PhoneLine3;
                txtWebsite.Text = _company.WebSite;
                txtCity.Text = _company.City;
                txtCountry.Text = _company.Country;
                txtMotto.Text = _company.Motto;
                cmbLocation.SelectedValue = _company.DefaultLocation;
            }
        }

        void LoadLocations()
        {
            cmbLocation.DataSource = new GenericService<Location>().GetAll();
            cmbLocation.DisplayMember = "Name";
            cmbLocation.ValueMember = "id";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pbLogo.Image = null;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.JPEG)|*.BMP;*.JPG;*.GIF;*.JPEG";
            dlg.CheckFileExists = true;
            dlg.InitialDirectory = Application.StartupPath;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbLogo.Image = Image.FromFile(dlg.FileName);
            }
        }

        private void btnLocations_Click(object sender, EventArgs e)
        {
            Helper.WaitCursor(this);

            frmSetupDetails frm = new frmSetupDetails();
            frm.LoadGridWithDataDatasource<Entities.Location>(() =>
            {
                return new BusinessLayer.GenericService<Entities.Location>().GetAll();
            });

            frm.ShowDialog();

            Helper.DefaultCursor(this);
        }

        private void frmAddCompany_Activated(object sender, EventArgs e)
        {
            LoadLocations();
        }

    }
}
