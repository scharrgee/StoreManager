using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using BusinessLayer;

namespace storeManager.UI
{
    public partial class frmSellingPriceCalculate : Telerik.WinControls.UI.RadForm
    {
        public frmSellingPriceCalculate()
        {
            InitializeComponent();
        }

        decimal _purchasePrice;
        public frmSellingPriceCalculate(decimal purchasePrice)
        {
            InitializeComponent();

            _purchasePrice = purchasePrice;
            
        }

        private void txtPercentage_TextChanged(object sender, EventArgs e)
        {
            if (txtPercentage.Text == string.Empty)
            {
                txtSellPrice.Text = string.Empty;
                txtProfitMargin.Text = string.Empty;
                return;
            }

            decimal percent = decimal.Parse(txtPercentage.Text);

            decimal sellPrice;
            decimal profitMargin;
            new ProductService().CalculateSellingPrice(percent, _purchasePrice, out sellPrice, out profitMargin);

            txtSellPrice.Text = sellPrice.ToString();
            txtProfitMargin.Text = profitMargin.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EventHub.Hub.OnGenericInfoCall("", txtSellPrice.Text, "txtSalePrice");
            EventHub.Hub.OnGenericInfoCall("", txtProfitMargin.Text, "txtProfitMargin");

            this.Close();
        }
    }
}
