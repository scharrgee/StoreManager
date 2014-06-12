namespace storeManager.UI
{
    partial class frmDatabaseRestore
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvBackups = new Telerik.WinControls.UI.RadGridView();
            this.pbProgress = new Telerik.WinControls.UI.RadProgressBar();
            this.btnRestore = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.dgvBackups);
            this.radGroupBox1.HeaderText = "Back up files";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 21);
            this.radGroupBox1.Name = "radGroupBox1";
            // 
            // 
            // 
            this.radGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox1.Size = new System.Drawing.Size(550, 212);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Back up files";
            this.radGroupBox1.ThemeName = "Breeze";
            // 
            // dgvBackups
            // 
            this.dgvBackups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBackups.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvBackups
            // 
            this.dgvBackups.MasterTemplate.AllowAddNewRow = false;
            this.dgvBackups.MasterTemplate.AllowColumnReorder = false;
            this.dgvBackups.Name = "dgvBackups";
            this.dgvBackups.ReadOnly = true;
            this.dgvBackups.ShowGroupPanel = false;
            this.dgvBackups.Size = new System.Drawing.Size(546, 192);
            this.dgvBackups.TabIndex = 0;
            this.dgvBackups.ThemeName = "Breeze";
            this.dgvBackups.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgvBackups_CellClick);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(12, 234);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(550, 24);
            this.pbProgress.TabIndex = 1;
            this.pbProgress.ThemeName = "Breeze";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(568, 30);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(110, 24);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "Restore";
            this.btnRestore.ThemeName = "Breeze";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(568, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.ThemeName = "Breeze";
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmDatabaseRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 270);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.radGroupBox1);
            this.MaximizeBox = false;
            this.Name = "frmDatabaseRestore";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Restore";
            this.ThemeName = "Breeze";
            this.Load += new System.EventHandler(this.frmDatabaseRestore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView dgvBackups;
        private Telerik.WinControls.UI.RadProgressBar pbProgress;
        private Telerik.WinControls.UI.RadButton btnRestore;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}
