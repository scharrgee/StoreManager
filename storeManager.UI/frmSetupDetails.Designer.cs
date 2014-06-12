namespace storeManager.UI
{
    partial class frmSetupDetails
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpList = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvList = new Telerik.WinControls.UI.RadGridView();
            this.btnDelete = new Telerik.WinControls.UI.RadButton();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.btnModify = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpList)).BeginInit();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnModify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grpList
            // 
            this.grpList.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.grpList.Controls.Add(this.dgvList);
            this.grpList.HeaderText = "List";
            this.grpList.Location = new System.Drawing.Point(12, 8);
            this.grpList.Name = "grpList";
            // 
            // 
            // 
            this.grpList.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.grpList.Size = new System.Drawing.Size(463, 227);
            this.grpList.TabIndex = 0;
            this.grpList.Text = "List";
            this.grpList.ThemeName = "Breeze";
            // 
            // dgvList
            // 
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvList
            // 
            this.dgvList.MasterTemplate.AllowAddNewRow = false;
            this.dgvList.MasterTemplate.AllowColumnReorder = false;
            this.dgvList.MasterTemplate.ShowRowHeaderColumn = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.ShowGroupPanel = false;
            this.dgvList.Size = new System.Drawing.Size(459, 207);
            this.dgvList.TabIndex = 0;
            this.dgvList.Text = "radGridView1";
            this.dgvList.ThemeName = "Breeze";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(249, 241);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 24);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.ThemeName = "Breeze";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(365, 241);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 24);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.ThemeName = "Breeze";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(133, 241);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 24);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.ThemeName = "Breeze";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(17, 241);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(110, 24);
            this.btnModify.TabIndex = 2;
            this.btnModify.Text = "Modify";
            this.btnModify.ThemeName = "Breeze";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // frmSetupDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 279);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grpList);
            this.MaximizeBox = false;
            this.Name = "frmSetupDetails";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup Details";
            this.ThemeName = "Breeze";
            this.Activated += new System.EventHandler(this.frmSetupDetails_Activated);
            this.Load += new System.EventHandler(this.frmSetupDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpList)).EndInit();
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnModify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox grpList;
        private Telerik.WinControls.UI.RadButton btnDelete;
        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadButton btnModify;
        private Telerik.WinControls.UI.RadGridView dgvList;
    }
}
