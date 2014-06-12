namespace storeManager.UI
{
    partial class frmAddTax
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddTax));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddTax = new System.Windows.Forms.Button();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSalTax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddTax);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSalTax);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tax Details";
            // 
            // btnAddTax
            // 
            this.btnAddTax.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddTax.BackgroundImage")));
            this.btnAddTax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddTax.FlatAppearance.BorderSize = 0;
            this.btnAddTax.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnAddTax.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAddTax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTax.Location = new System.Drawing.Point(301, 62);
            this.btnAddTax.Name = "btnAddTax";
            this.btnAddTax.Size = new System.Drawing.Size(22, 19);
            this.btnAddTax.TabIndex = 92;
            this.btnAddTax.UseVisualStyleBackColor = true;
            this.btnAddTax.Click += new System.EventHandler(this.btnAddTax_Click);
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(88, 98);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(235, 20);
            this.txtRate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tax Rate :";
            // 
            // txtSalTax
            // 
            this.txtSalTax.Location = new System.Drawing.Point(88, 61);
            this.txtSalTax.Name = "txtSalTax";
            this.txtSalTax.Size = new System.Drawing.Size(217, 20);
            this.txtSalTax.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tax Name :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(207, 216);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.ThemeName = "Breeze";
            this.btnSave.TextChanged += new System.EventHandler(this.btnSave_TextChanged);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(303, 216);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 24);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.ThemeName = "Breeze";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddTax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 252);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmAddTax";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Tax";
            this.ThemeName = "Breeze";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSalTax;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnClose;
        public System.Windows.Forms.Button btnAddTax;
    }
}
