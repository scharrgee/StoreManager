namespace storeManager.UI
{
    partial class frmCalculateDiscount
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDisc = new System.Windows.Forms.TextBox();
            this.txtAmt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new Telerik.WinControls.UI.RadButton();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-7, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter percentage for discount";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDisc
            // 
            this.txtDisc.Location = new System.Drawing.Point(96, 41);
            this.txtDisc.Name = "txtDisc";
            this.txtDisc.Size = new System.Drawing.Size(58, 20);
            this.txtDisc.TabIndex = 1;
            this.txtDisc.TextChanged += new System.EventHandler(this.txtDisc_TextChanged);
            // 
            // txtAmt
            // 
            this.txtAmt.Location = new System.Drawing.Point(182, 41);
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.ReadOnly = true;
            this.txtAmt.Size = new System.Drawing.Size(73, 20);
            this.txtAmt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Discount :";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(90, 77);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(61, 24);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.ThemeName = "Breeze";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(157, 77);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 24);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.ThemeName = "Breeze";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCalculateDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 105);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAmt);
            this.Controls.Add(this.txtDisc);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmCalculateDiscount";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calculate Discount";
            this.ThemeName = "Breeze";
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDisc;
        private System.Windows.Forms.TextBox txtAmt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadButton btnOK;
        private Telerik.WinControls.UI.RadButton btnClose;
    }
}
