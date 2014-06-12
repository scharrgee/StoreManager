using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using BusinessLayer.Interfaces;
using BusinessLayer;

namespace storeManager.UI
{
    public partial class frmAddBrand : Telerik.WinControls.UI.RadForm
    {
        EntityState _entityState = EntityState.New;
        IErrorService _logger;

        public frmAddBrand()
        {
            InitializeComponent();
            _logger = new ErrorLogService();

            EventHub.Hub.GenericInfo += new EventHandler<EventHub.EventHubAgs>(Hub_GenericInfo);
        }

        public frmAddBrand(EntityState entityState)
        {
            InitializeComponent();

            _entityState = entityState;
            btnSave.Text = "Update";
            EventHub.Hub.GenericInfo += new EventHandler<EventHub.EventHubAgs>(Hub_GenericInfo);
        }

        public EntityState State
        {
            get
            {
                return _entityState;
            }
            set
            {
                value = _entityState;
            }
        }

        public int BrandID { get; set; }

        void Hub_GenericInfo(object sender, EventHub.EventHubAgs e)
        {
            txtComment.Text = e.Data;
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            new frmDescription("frmBrand",txtComment.Text).ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_entityState)
                {
                    case EntityState.New:
                        new BusinessLayer.BrandService().Add(new Entities.Brand { BrandName = txtName.Text, Description = txtComment.Text });
                        break;
                    case EntityState.Dirty:
                        Entities.Brand brand = new Entities.Brand { BrandID = BrandID, BrandName = txtName.Text, Description = txtComment.Text };
                        new BusinessLayer.GenericService<Entities.Brand>().Update(brand, b => b.BrandID == brand.BrandID);
                        break;
                    default:
                        break;
                }

                Helper.ClearForm(this);
                btnSave.Text = "Save";
                _entityState = EntityState.New;
                Helper.ShowMessage("Brand saved successfully", "Brand Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmSetupDetails frmSetup = Helper.CreateInstanceFor<frmSetupDetails>("frmSetupDetails");
                if (frmSetup != null)
                {
                    frmSetup.LoadGridWithDataDatasource(() => new BusinessLayer.GenericService<Entities.Brand>().GetAll());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "frmAddBrand", "btnSave");
                Helper.ShowMessage("Brand was not saved successfully \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddBrand_Load(object sender, EventArgs e)
        {
            if (_entityState == EntityState.Dirty)
            {
                Entities.Brand brand = new BusinessLayer.GenericService<Entities.Brand>().GetSingle(b => b.BrandID == BrandID);
                txtComment.Text = brand.Description;
                txtName.Text = brand.BrandName;
            }
        }
    }
}
