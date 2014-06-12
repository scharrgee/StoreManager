using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace storeManager.UI
{
    public partial class frmCalculateDiscount : Telerik.WinControls.UI.RadForm
    {
        decimal _amt = 0;
        public frmCalculateDiscount()
        {
            InitializeComponent();
        }

        public frmCalculateDiscount(decimal amt)
        {
            InitializeComponent();
            _amt = amt;
        }

        private void txtDisc_TextChanged(object sender, EventArgs e)
        {
            if (txtDisc.Text == "") return;

            txtAmt.Text = Math.Round(((txtDisc.Text.ToDecimal() / 100) * _amt),2).ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EventHub.Hub.OnSetDiscountAmount("", txtAmt.Text, "");
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
