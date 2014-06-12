namespace storeManager.UI
{
    partial class frmUsers
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvUsers = new Telerik.WinControls.UI.RadGridView();
            this.btnRemove = new Telerik.WinControls.UI.RadButton();
            this.btnAddUser = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dgvUsers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnRemove);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddUser);
            this.splitContainer1.Size = new System.Drawing.Size(424, 315);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvUsers
            // 
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(0, 0);
            // 
            // dgvUsers
            // 
            this.dgvUsers.MasterTemplate.AllowAddNewRow = false;
            this.dgvUsers.MasterTemplate.ShowFilteringRow = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgvUsers.ReadOnly = true;
            // 
            // 
            // 
            this.dgvUsers.RootElement.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgvUsers.ShowGroupPanel = false;
            this.dgvUsers.Size = new System.Drawing.Size(424, 261);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.Text = "radGridView1";
            this.dgvUsers.ThemeName = "Windows7";
            this.dgvUsers.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgvUsers_CellDoubleClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(334, 14);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(82, 24);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "Remove";
            this.btnRemove.ThemeName = "Breeze";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(244, 14);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(82, 24);
            this.btnAddUser.TabIndex = 11;
            this.btnAddUser.Text = "Add";
            this.btnAddUser.ThemeName = "Breeze";
            this.btnAddUser.Visible = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 315);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "frmUsers";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users";
            this.ThemeName = "Breeze";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadGridView dgvUsers;
        private Telerik.WinControls.UI.RadButton btnRemove;
        private Telerik.WinControls.UI.RadButton btnAddUser;
    }
}
