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
    public partial class frmAddCategory : Telerik.WinControls.UI.RadForm
    {
        EntityState _entityState = EntityState.New;
        IErrorService _logger;

        public frmAddCategory()
        {
            InitializeComponent();
            _logger = new ErrorLogService();

            EventHub.Hub.GenericInfo += new EventHandler<EventHub.EventHubAgs>(Hub_GenericInfo);
        }

        public frmAddCategory(EntityState entityState)
        {
            InitializeComponent();

            _entityState = entityState;
            btnSave.Text = "Update";
            EventHub.Hub.GenericInfo += new EventHandler<EventHub.EventHubAgs>(Hub_GenericInfo);
        }

        void Hub_GenericInfo(object sender, EventHub.EventHubAgs e)
        {
            txtComment.Text = e.Data;
        }

        public string Desc
        {
            get { return txtComment.Text; }
            set { txtComment.Text = value; }
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

        public int CategoryID { get; set; }

        //public string Desc { private get; 
        //    set {txtComment.Text = value}

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_entityState)
                {
                    case EntityState.New:
                         new BusinessLayer.CategoryService().Add(new Entities.Category { Comment = txtComment.Text, Name = txtName.Text });
                
                        break;
                    case EntityState.Dirty:

                        Entities.Category category = new Entities.Category { Comment = txtComment.Text, Name = txtName.Text, CategoryID = CategoryID };
                        new BusinessLayer.GenericService<Entities.Category>().Update(category, c => c.CategoryID == category.CategoryID);
                        break;
                    default:
                        break;
                }

                Helper.ClearForm(this);
                btnSave.Text = "Save";
                _entityState = EntityState.New;
                Helper.ShowMessage("Category saved successfully", "Category Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmSetupDetails frmSetup = Helper.CreateInstanceFor<frmSetupDetails>("frmSetupDetails");
                if (frmSetup != null)
                {
                    frmSetup.LoadGridWithDataDatasource(() => new BusinessLayer.GenericService<Entities.Category>().GetAll());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "frmAddCategory", "btnSave");
                Helper.ShowMessage("Category was not saved successfully \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            new frmDescription("frmCategory",txtComment.Text).ShowDialog();
        }

        private void frmAddCategory_Load(object sender, EventArgs e)
        {
            if (_entityState == EntityState.Dirty)
            {
                Entities.Category category = new BusinessLayer.GenericService<Entities.Category>().GetSingle(c => c.CategoryID == CategoryID);
                txtComment.Text = category.Comment;
                txtName.Text = category.Name;
            }
        }
    }
}
