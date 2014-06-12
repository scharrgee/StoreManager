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

namespace storeManager.UI
{
    public partial class frmAddTax : Telerik.WinControls.UI.RadForm
    {
        string _status = "";
        IErrorService _logger;

        public frmAddTax()
        {
            InitializeComponent();
            _logger = new ErrorLogService();

            Hub.TaxInfo += new EventHandler<EventHubAgs>(Hub_GenericInfo);
        }

        void Hub_GenericInfo(object sender, EventHubAgs e)
        {
            TextBox txt = this.Controls.Find(e.ControlName, true).FirstOrDefault() as TextBox;

            if (txt == null) return;

            string[] data = e.Data.Split(",".ToCharArray());

            txt.Text = data[0];
            txtRate.Text = data[1];
            txt.Tag = e.ID;

            ConfigureButton("Update");
        }

        private EntityState _state = EntityState.New;

        public EntityState GetProductState
        {
            get { return _state; }
            set { _state = value; }
        }

        void ConfigureButton(string status)
        {
            _status = status;
            btnSave.Text = status;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ITaxService taxservice = new TaxService();
            Tax tax = new Tax { TaxName = txtSalTax.Text, TaxRate = Math.Round(txtRate.Text.ToDecimal(), 2) };

            try
            {
                switch (_state)
                {
                    case EntityState.New:
                        taxservice.Add(tax);
                        break;
                    case EntityState.Dirty:
                        tax.TaxID = txtSalTax.Tag.ToInt();
                        taxservice.Update(tax, t => t.ID == tax.ID);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "frmAddTax", "btnSave");
                Helper.ShowMessage("Tax was not saved successfully \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtSalTax.Tag = null;
            Helper.ClearForm(this);
            _state = EntityState.New;
            Helper.ShowMessage("Tax saved successfully", "Tax Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ConfigureButton("Save");
        }

        private void btnSave_TextChanged(object sender, EventArgs e)
        {
            switch (_status)
            {
                case "Save":
                    _state = EntityState.New;
                    break;
                case "Update":
                    _state = EntityState.Dirty;
                    break;
            }
        }

        private void btnAddTax_Click(object sender, EventArgs e)
        {
            new frmChooseTax(false).ShowDialog();
        }
    }
}
