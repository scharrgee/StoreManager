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
    public partial class frmAddMeasurement : Telerik.WinControls.UI.RadForm
    {
        EntityState _entityState = EntityState.New;
        IErrorService _logger;

        public frmAddMeasurement()
        {
            InitializeComponent();
            _logger = new ErrorLogService();

            EventHub.Hub.GenericInfo += new EventHandler<EventHub.EventHubAgs>(Hub_GenericInfo);
        }

        public frmAddMeasurement(EntityState entityState)
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

        public int MeasurementID { get; set; }

        void Hub_GenericInfo(object sender, EventHub.EventHubAgs e)
        {
            txtComment.Text = e.Data;
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            new frmDescription("frmAddMeasurement", txtComment.Text).ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_entityState)
                {
                    case EntityState.New:
                        new BusinessLayer.GenericService<Entities.Measurement>().Add(new Entities.Measurement { Description = txtComment.Text,Name=txtName.Text });
                        break;
                    case EntityState.Dirty:
                        Entities.Measurement measurement = new Entities.Measurement { Id = MeasurementID, Description = txtComment.Text, Name = txtName.Text };
                        new BusinessLayer.GenericService<Entities.Measurement>().Update(measurement, b => b.Id == measurement.Id);
                        break;
                    default:
                        break;
                }

                Helper.ClearForm(this);
                btnSave.Text = "Save";
                _entityState = EntityState.New;
                Helper.ShowMessage("Measurment saved successfully", "Measurement Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmSetupDetails frmSetup = Helper.CreateInstanceFor<frmSetupDetails>("frmSetupDetails");
                if (frmSetup != null)
                {
                    frmSetup.LoadGridWithDataDatasource(() => new BusinessLayer.GenericService<Entities.Measurement>().GetAll());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "frmAddMeasurement", "btnSave");
                Helper.ShowMessage("Measurement was not saved successfully \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Entities.Measurement measurement = new BusinessLayer.GenericService<Entities.Measurement>().GetSingle(b => b.Id == MeasurementID);
                txtComment.Text = measurement.Description;
                txtName.Text = measurement.Name;
            }
        }
    }
}
