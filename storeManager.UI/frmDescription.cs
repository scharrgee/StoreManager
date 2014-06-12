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
    public partial class frmDescription : Telerik.WinControls.UI.RadForm
    {
        public frmDescription()
        {
            InitializeComponent();
        }

        string _frmName;
        //string _data;

        public frmDescription(string frmName,string data)
        {
            InitializeComponent();
            _frmName = frmName;
            txtDesc.Text = data;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //frmAddCategory frm = UtilityClass.CreateInstanceFor<frmAddCategory>("frmAddCategory");
            //frm.Desc = txtDesc.Text;


            EventHub.Hub.OnGenericInfoCall("0", txtDesc.Text, _frmName);
            this.Close();
        }
    }
}
