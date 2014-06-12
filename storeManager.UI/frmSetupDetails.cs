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

namespace storeManager.UI
{
    public partial class frmSetupDetails : Telerik.WinControls.UI.RadForm
    {
        object ListType = null;

        public frmSetupDetails()
        {
            InitializeComponent();
        }

        public string SetGroupBoxTitle { set { grpList.Text = value; } }
        public string SetFormTitle { set { this.Text += " - " + value; } }

        public void LoadGridWithDataDatasource<T>(Func<IEnumerable<T>> datasource) where T : new()
        {
            dgvList.DataSource = datasource();
            ListType = new T();

            ConfigureGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count == 0)
                return;

            ResolveType("Modify");
        }

        private void ResolveType(string operation)
        {
            storeManager.Entities.Location location = ListType as storeManager.Entities.Location;
            Brand brand = ListType as Brand;
            Category category = ListType as Category;
            Measurement measurement = ListType as Measurement;
            //Tax tax = ListType as Tax;

            if (location != null)
            {
                PerformLocationOperation(location, operation);
                return;
            }

            if (brand != null)
            {
                PerformBrandOperation(brand, operation);
                return;
            }

            if (category != null)
            {
                PerformCategoryOperation(category, operation);
                return;
            }

            if (measurement != null)
            {
                PerformMeasurementOperation(measurement, operation);
                return;
            }
        }

        void PerformLocationOperation(storeManager.Entities.Location location, string operation)
        {
            frmAddLocation frmlocation = new frmAddLocation(EntityState.Dirty);
            int locationID = dgvList.SelectedRows[0].Cells["id"].Value.ToInt();

            switch (operation)
            {
                case "Modify":
                    frmlocation.LocationID = locationID;
                    frmlocation.ShowDialog();
                    break;
                case "Add":
                    frmlocation = new frmAddLocation();
                    frmlocation.ShowDialog();
                    break;
                case "Delete":
                    if (!(DialogResult.Yes == Helper.ShowMessage("Are you sure you want to delete this location?",
                       "Delete Seleted Location", MessageBoxButtons.YesNo, MessageBoxIcon.Question))) return;

                    new GenericService<Entities.Location>().Delete(new Location { Id = locationID });
                    LoadGridWithDataDatasource(() => new BusinessLayer.GenericService<Entities.Location>().GetAll());
                    break;
            }
        }

        void PerformBrandOperation(Brand brand, string operation)
        {
            frmAddBrand frmBrand = new frmAddBrand(EntityState.Dirty);
             int brandID = dgvList.SelectedRows[0].Cells["BrandID"].Value.ToInt();
            switch (operation)
            {
                case "Modify":
                    frmBrand.BrandID = brandID;
                    frmBrand.ShowDialog();
                    break;
                case "Add":
                    frmBrand = new frmAddBrand();
                    frmBrand.ShowDialog();
                    break;
                case "Delete":
                    if (!(DialogResult.Yes == Helper.ShowMessage("Are you sure you want to delete this brand?",
                       "Delete Seleted Brand", MessageBoxButtons.YesNo, MessageBoxIcon.Question))) return;

                    new GenericService<Entities.Brand>().Delete(new Brand { BrandID = brandID });
                    LoadGridWithDataDatasource(() => new BusinessLayer.GenericService<Entities.Brand>().GetAll());
                    break;
            }
        }

        void PerformCategoryOperation(Category category, string operation)
        {
            frmAddCategory frmCategory = new frmAddCategory(EntityState.Dirty);
            int CategoryID = dgvList.SelectedRows[0].Cells["CategoryID"].Value.ToInt();

            switch (operation)
            {
                case "Modify":
                    frmCategory.CategoryID = CategoryID;
                    frmCategory.ShowDialog();
                    break;
                case "Add":
                    frmCategory = new frmAddCategory();
                    frmCategory.ShowDialog();
                    break;
                case "Delete":

                    if (!(DialogResult.Yes == Helper.ShowMessage("Are you sure you want to delete this category?",
                        "Delete Seleted Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question))) return;

                    new GenericService<Entities.Category>().Delete(new Category { CategoryID = CategoryID });
                    LoadGridWithDataDatasource(() => new BusinessLayer.GenericService<Entities.Category>().GetAll());
                    break;
            }
        }

        void PerformMeasurementOperation(Measurement measurement, string operation)
        {
            frmAddMeasurement frmmeasurement = new frmAddMeasurement(EntityState.Dirty);
            int measurementID = dgvList.SelectedRows[0].Cells["id"].Value.ToInt();

            switch (operation)
            {
                case "Modify":
                    frmmeasurement.MeasurementID = measurementID;
                    frmmeasurement.ShowDialog();
                    break;
                case "Add":
                    frmmeasurement = new frmAddMeasurement();
                    frmmeasurement.ShowDialog();
                    break;
                case "Delete":

                    if (!(DialogResult.Yes == Helper.ShowMessage("Are you sure you want to delete this category?",
                        "Delete Seleted Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question))) return;

                    new GenericService<Entities.Measurement>().Delete(new Measurement { Id = measurementID });
                    LoadGridWithDataDatasource(() => new BusinessLayer.GenericService<Entities.Measurement>().GetAll());
                    break;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResolveType("Add");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count == 0)
                return;

            ResolveType("Delete");
        }

        private void frmSetupDetails_Load(object sender, EventArgs e)
        {

        }

        void ConfigureGrid()
        {
            storeManager.Entities.Location location = ListType as storeManager.Entities.Location;
            Brand brand = ListType as Brand;
            Category category = ListType as Category;
            Tax tax = ListType as Tax;
            Measurement measurement = ListType as Measurement;

            if (location != null)
            {
                dgvList.Columns["Name"].Width = 300;
                dgvList.Columns["Comment"].Width = 350;
                
                dgvList.Columns["id"].IsVisible = false;
                dgvList.Columns["IsDefault"].IsVisible = false;
                dgvList.Columns["ProductLocations"].IsVisible = false;
                return;
            }

            if (brand != null)
            {
                dgvList.Columns["BrandName"].HeaderText = "Brand Name";

                dgvList.Columns["BrandName"].Width = 300;
                dgvList.Columns["Description"].Width = 350;

                dgvList.Columns["BrandID"].IsVisible = false;
                dgvList.Columns["ID"].IsVisible = false;
                dgvList.Columns["DisplayName"].IsVisible = false;
                dgvList.Columns["Products"].IsVisible = false;
                return;
            }

            if (category != null)
            {
                dgvList.Columns["Name"].Width = 300;
                dgvList.Columns["Comment"].Width = 350;

                dgvList.Columns["CategoryID"].IsVisible = false;
                dgvList.Columns["ID"].IsVisible = false;
                dgvList.Columns["DisplayName"].IsVisible = false;
                dgvList.Columns["Products"].IsVisible = false;
                return;
            }

            if (tax != null)
            {
                dgvList.Columns["TaxName"].HeaderText = "Tax Name";
                dgvList.Columns["TaxRate"].HeaderText = "Tax Rate";
                dgvList.Columns["TaxNumber"].HeaderText = "Tax Number";

                dgvList.Columns["TaxName"].Width = 300;
                dgvList.Columns["TaxRate"].Width = 120;
                dgvList.Columns["TaxNumber"].Width = 120;

                dgvList.Columns["TaxID"].IsVisible = false;
                dgvList.Columns["ID"].IsVisible = false;
                dgvList.Columns["DisplayName"].IsVisible = false;
                return;
            }

            if (measurement != null)
            {
                dgvList.Columns["Name"].Width = 300;
                dgvList.Columns["Description"].Width = 350;

                dgvList.Columns["id"].IsVisible = false;
                dgvList.Columns["Products"].IsVisible = false;
                return;
            }
        }

        private void frmSetupDetails_Activated(object sender, EventArgs e)
        {

        }
    }
}
