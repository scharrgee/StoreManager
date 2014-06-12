using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using storeManager.UI;
using storeManager.UI.EventHub;
using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;

using Microsoft.PointOfService;

namespace storeManager.UI.Controls
{
    public partial class ucSalesList : UserControl
    {
        int saleID = 0;
        PosPrinter m_Printer = null;

        public ucSalesList()
        {
            InitializeComponent();
            LoadStatuses();

            dtFrom.Checked = false;
        }

        public PosPrinter ReceiptPrinter
        {
            get { return m_Printer; }
            set { m_Printer = value; }
        }

        void LoadStatuses()
        {
            List<SaleStatus> statuses = new GenericService<SaleStatus>().GetAll().ToList();

            statuses.Insert(0, new SaleStatus { Id = 0, Status = "<<Select Status>>" });

            cmbStatus.DataSource = statuses;
            cmbStatus.DisplayMember = "Status";
            cmbStatus.ValueMember = "id";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!dtFrom.CompareTo(dtTo))
            {
                Helper.ShowMessage("From date cannot be later than To date", "Date Not Valid", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            dgvSalesList.DataSource = new StoredProcedureGatewayService()
                                        .GetSaleList(dtFrom.GetValue(true), dtTo.GetValue(false), 
                                        cmbStatus.SelectedValue.ToInt(), txtInvNo.Text);

            ConfigureGrid();
        }

        void ConfigureGrid()
        {
            dgvSalesList.Columns["InvoiceNumber"].HeaderText = "Invoice Number";
            dgvSalesList.Columns["InvoiceDate"].HeaderText = "Invoice Date";
            dgvSalesList.Columns["SaleStatus"].HeaderText = "Status";
            dgvSalesList.Columns["CustomerName"].HeaderText = "Customer";
            dgvSalesList.Columns["Amount"].HeaderText = "Amount";
            dgvSalesList.Columns["AmountPaid"].HeaderText = "Amount Paid";
            dgvSalesList.Columns["Balance"].HeaderText = "Balance";

            dgvSalesList.Columns["InvoiceNumber"].Width = 150;
            dgvSalesList.Columns["InvoiceDate"].Width = 150;
            dgvSalesList.Columns["SaleStatus"].Width = 100;
            dgvSalesList.Columns["CustomerName"].Width = 200;
            dgvSalesList.Columns["Amount"].Width = 150;
            dgvSalesList.Columns["AmountPaid"].Width = 150;
            dgvSalesList.Columns["Balance"].Width = 150;

            dgvSalesList.Columns["SaleStatusID"].IsVisible = false;
            dgvSalesList.Columns["CustomerID"].IsVisible = false;
            dgvSalesList.Columns["SaleID"].IsVisible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvSalesList.DataSource = null;
            txtInvNo.Clear();

            dtFrom.Reset();
            dtTo.Reset();

            cmbStatus.DetermineSelectedIndex();
        }

        private void dgvSalesList_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            saleID = e.Row.Cells["SaleID"].Value.ToInt();

            frmControlHost host = new frmControlHost();

            ucSale sale = new ucSale();
            sale.Dock = DockStyle.Fill;
            sale.ReceiptPrinter = m_Printer;

            host.Controls.Add(sale);

            Hub.OnSaleEdit(saleID);
            host.ShowDialog();
        }
    }
}
