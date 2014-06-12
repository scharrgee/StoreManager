namespace storeManager.UI
{
    partial class frmHardwareSetup
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
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnPrintTest = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRceiptFooter = new System.Windows.Forms.TextBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.pbPrintersWait = new System.Windows.Forms.PictureBox();
            this.lbPrinterDevs = new System.Windows.Forms.ListBox();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnTestConnection = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.pbBarcodeWait = new System.Windows.Forms.PictureBox();
            this.lbBarcodeDevs = new System.Windows.Forms.ListBox();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrintersWait)).BeginInit();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTestConnection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarcodeWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.radPageView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(637, 526);
            this.splitContainer1.SplitterDistance = 475;
            this.splitContainer1.TabIndex = 0;
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Controls.Add(this.radPageViewPage2);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Location = new System.Drawing.Point(0, 0);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(637, 475);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "radPageView1";
            this.radPageView1.ThemeName = "Breeze";
            // 
            // radPageViewPage1
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.radPageViewPage1.Controls.Add(this.radGroupBox2);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(616, 427);
            this.radPageViewPage1.Text = "POS Printer";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btnPrintTest);
            this.radGroupBox2.Controls.Add(this.label1);
            this.radGroupBox2.Controls.Add(this.txtRceiptFooter);
            this.radGroupBox2.Controls.Add(this.radGroupBox1);
            this.radGroupBox2.HeaderText = "POS Printer Settings";
            this.radGroupBox2.Location = new System.Drawing.Point(14, 20);
            this.radGroupBox2.Name = "radGroupBox2";
            // 
            // 
            // 
            this.radGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox2.Size = new System.Drawing.Size(599, 419);
            this.radGroupBox2.TabIndex = 3;
            this.radGroupBox2.Text = "POS Printer Settings";
            this.radGroupBox2.ThemeName = "Breeze";
            // 
            // btnPrintTest
            // 
            this.btnPrintTest.Location = new System.Drawing.Point(236, 380);
            this.btnPrintTest.Name = "btnPrintTest";
            this.btnPrintTest.Size = new System.Drawing.Size(110, 24);
            this.btnPrintTest.TabIndex = 3;
            this.btnPrintTest.Text = "Test Connection";
            this.btnPrintTest.ThemeName = "Breeze";
            this.btnPrintTest.Click += new System.EventHandler(this.btnPrintTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Receipt Footer Text";
            // 
            // txtRceiptFooter
            // 
            this.txtRceiptFooter.Location = new System.Drawing.Point(269, 63);
            this.txtRceiptFooter.Multiline = true;
            this.txtRceiptFooter.Name = "txtRceiptFooter";
            this.txtRceiptFooter.Size = new System.Drawing.Size(315, 61);
            this.txtRceiptFooter.TabIndex = 1;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.pbPrintersWait);
            this.radGroupBox1.Controls.Add(this.lbPrinterDevs);
            this.radGroupBox1.HeaderText = "Found Print Devices";
            this.radGroupBox1.Location = new System.Drawing.Point(15, 28);
            this.radGroupBox1.Name = "radGroupBox1";
            // 
            // 
            // 
            this.radGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox1.Size = new System.Drawing.Size(215, 376);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Found Print Devices";
            this.radGroupBox1.ThemeName = "Breeze";
            // 
            // pbPrintersWait
            // 
            this.pbPrintersWait.Image = global::storeManager.UI.Properties.Resources.loading3;
            this.pbPrintersWait.Location = new System.Drawing.Point(87, 178);
            this.pbPrintersWait.Name = "pbPrintersWait";
            this.pbPrintersWait.Size = new System.Drawing.Size(44, 39);
            this.pbPrintersWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPrintersWait.TabIndex = 1;
            this.pbPrintersWait.TabStop = false;
            // 
            // lbPrinterDevs
            // 
            this.lbPrinterDevs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPrinterDevs.FormattingEnabled = true;
            this.lbPrinterDevs.HorizontalScrollbar = true;
            this.lbPrinterDevs.Location = new System.Drawing.Point(2, 18);
            this.lbPrinterDevs.Name = "lbPrinterDevs";
            this.lbPrinterDevs.Size = new System.Drawing.Size(211, 356);
            this.lbPrinterDevs.TabIndex = 0;
            this.lbPrinterDevs.SelectedIndexChanged += new System.EventHandler(this.lbPrinterDevs_SelectedIndexChanged);
            // 
            // radPageViewPage2
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.radPageViewPage2.Controls.Add(this.radGroupBox3);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(616, 427);
            this.radPageViewPage2.Text = "Barcode Device";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.btnTestConnection);
            this.radGroupBox3.Controls.Add(this.radGroupBox4);
            this.radGroupBox3.HeaderText = "Barcode Scanner Settings";
            this.radGroupBox3.Location = new System.Drawing.Point(15, 16);
            this.radGroupBox3.Name = "radGroupBox3";
            // 
            // 
            // 
            this.radGroupBox3.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox3.Size = new System.Drawing.Size(598, 415);
            this.radGroupBox3.TabIndex = 5;
            this.radGroupBox3.Text = "Barcode Scanner Settings";
            this.radGroupBox3.ThemeName = "Breeze";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(224, 371);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(110, 24);
            this.btnTestConnection.TabIndex = 1;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.ThemeName = "Breeze";
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.Controls.Add(this.pbBarcodeWait);
            this.radGroupBox4.Controls.Add(this.lbBarcodeDevs);
            this.radGroupBox4.HeaderText = "Found Barcode Devices";
            this.radGroupBox4.Location = new System.Drawing.Point(15, 28);
            this.radGroupBox4.Name = "radGroupBox4";
            // 
            // 
            // 
            this.radGroupBox4.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox4.Size = new System.Drawing.Size(203, 369);
            this.radGroupBox4.TabIndex = 0;
            this.radGroupBox4.Text = "Found Barcode Devices";
            this.radGroupBox4.ThemeName = "Breeze";
            // 
            // pbBarcodeWait
            // 
            this.pbBarcodeWait.Image = global::storeManager.UI.Properties.Resources.loading3;
            this.pbBarcodeWait.Location = new System.Drawing.Point(71, 160);
            this.pbBarcodeWait.Name = "pbBarcodeWait";
            this.pbBarcodeWait.Size = new System.Drawing.Size(44, 39);
            this.pbBarcodeWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbBarcodeWait.TabIndex = 2;
            this.pbBarcodeWait.TabStop = false;
            // 
            // lbBarcodeDevs
            // 
            this.lbBarcodeDevs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbBarcodeDevs.FormattingEnabled = true;
            this.lbBarcodeDevs.HorizontalScrollbar = true;
            this.lbBarcodeDevs.Location = new System.Drawing.Point(2, 18);
            this.lbBarcodeDevs.Name = "lbBarcodeDevs";
            this.lbBarcodeDevs.Size = new System.Drawing.Size(199, 349);
            this.lbBarcodeDevs.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(514, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 24);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.ThemeName = "Breeze";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(398, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save Settings";
            this.btnSave.ThemeName = "Breeze";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmHardwareSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 526);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "frmHardwareSetup";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hardware Setup";
            this.ThemeName = "Breeze";
            this.Load += new System.EventHandler(this.frmHardwareSetup_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPrintersWait)).EndInit();
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnTestConnection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBarcodeWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.ListBox lbPrinterDevs;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private System.Windows.Forms.ListBox lbBarcodeDevs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRceiptFooter;
        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadButton btnSave;
        private System.Windows.Forms.PictureBox pbPrintersWait;
        private System.Windows.Forms.PictureBox pbBarcodeWait;
        private Telerik.WinControls.UI.RadButton btnTestConnection;
        private Telerik.WinControls.UI.RadButton btnPrintTest;

    }
}
