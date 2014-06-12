namespace storeManager.UI.Controls
{
    partial class ucSalesList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.dtTo = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtFrom = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInvNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvSalesList = new Telerik.WinControls.UI.RadGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesList.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.radPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(929, 681);
            this.splitContainer1.SplitterDistance = 143;
            this.splitContainer1.TabIndex = 1;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.label6);
            this.radPanel1.Controls.Add(this.dtTo);
            this.radPanel1.Controls.Add(this.label5);
            this.radPanel1.Controls.Add(this.dtFrom);
            this.radPanel1.Controls.Add(this.btnSearch);
            this.radPanel1.Controls.Add(this.btnRefresh);
            this.radPanel1.Controls.Add(this.cmbStatus);
            this.radPanel1.Controls.Add(this.label4);
            this.radPanel1.Controls.Add(this.label3);
            this.radPanel1.Controls.Add(this.label2);
            this.radPanel1.Controls.Add(this.txtInvNo);
            this.radPanel1.Controls.Add(this.label1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(929, 143);
            this.radPanel1.TabIndex = 0;
            this.radPanel1.ThemeName = "Breeze";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "To";
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(297, 69);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(126, 18);
            this.dtTo.TabIndex = 11;
            this.dtTo.TabStop = false;
            this.dtTo.Text = "2/25/2013";
            this.dtTo.ThemeName = "Breeze";
            this.dtTo.Value = new System.DateTime(2013, 2, 25, 22, 7, 55, 28);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "From";
            // 
            // dtFrom
            // 
            this.dtFrom.Checked = true;
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(132, 69);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.ShowCheckBox = true;
            this.dtFrom.Size = new System.Drawing.Size(126, 18);
            this.dtFrom.TabIndex = 9;
            this.dtFrom.TabStop = false;
            this.dtFrom.Text = "2/25/2013";
            this.dtFrom.ThemeName = "Breeze";
            this.dtFrom.Value = new System.DateTime(2013, 2, 25, 22, 7, 55, 28);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(623, 93);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 24);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.ThemeName = "Breeze";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(732, 93);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(103, 24);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.ThemeName = "Breeze";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(93, 96);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(330, 21);
            this.cmbStatus.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sale Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(26, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search";
            // 
            // txtInvNo
            // 
            this.txtInvNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvNo.Location = new System.Drawing.Point(93, 42);
            this.txtInvNo.Name = "txtInvNo";
            this.txtInvNo.Size = new System.Drawing.Size(742, 20);
            this.txtInvNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice No.";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvSalesList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.LightBlue;
            this.splitContainer2.Panel2.Controls.Add(this.lblStatus);
            this.splitContainer2.Size = new System.Drawing.Size(929, 534);
            this.splitContainer2.SplitterDistance = 491;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvSalesList
            // 
            this.dgvSalesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesList.Location = new System.Drawing.Point(0, 0);
            // 
            // dgvSalesList
            // 
            this.dgvSalesList.MasterTemplate.AllowAddNewRow = false;
            this.dgvSalesList.Name = "dgvSalesList";
            this.dgvSalesList.ReadOnly = true;
            this.dgvSalesList.Size = new System.Drawing.Size(929, 491);
            this.dgvSalesList.TabIndex = 0;
            this.dgvSalesList.Text = "radGridView1";
            this.dgvSalesList.ThemeName = "Breeze";
            this.dgvSalesList.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgvSalesList_CellDoubleClick);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(8, 14);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(11, 14);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "-";
            // 
            // ucSalesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucSalesList";
            this.Size = new System.Drawing.Size(929, 681);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private Telerik.WinControls.UI.RadButton btnRefresh;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInvNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Telerik.WinControls.UI.RadGridView dgvSalesList;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadDateTimePicker dtTo;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadDateTimePicker dtFrom;
    }
}
