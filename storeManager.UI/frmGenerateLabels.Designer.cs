namespace storeManager.UI
{
    partial class frmGenerateLabels
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
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkShowChecksum = new System.Windows.Forms.CheckBox();
            this.chkShowBorder = new System.Windows.Forms.CheckBox();
            this.chkShowText = new System.Windows.Forms.CheckBox();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.cmbFont = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBorderType = new System.Windows.Forms.ComboBox();
            this.cmbLabelType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnGenerate = new Telerik.WinControls.UI.RadButton();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnCreateSeq = new Telerik.WinControls.UI.RadButton();
            this.btnCreateRan = new Telerik.WinControls.UI.RadButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnReset = new Telerik.WinControls.UI.RadButton();
            this.lblListTotal = new System.Windows.Forms.Label();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.lbSeries = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.rdRandom = new Telerik.WinControls.UI.RadRadioButton();
            this.rdSequential = new Telerik.WinControls.UI.RadRadioButton();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateSeq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateRan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdRandom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdSequential)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(114, 118);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(62, 20);
            this.txtHeight.TabIndex = 37;
            this.txtHeight.Text = "15";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Bar Height:";
            // 
            // chkShowChecksum
            // 
            this.chkShowChecksum.AutoSize = true;
            this.chkShowChecksum.Checked = true;
            this.chkShowChecksum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowChecksum.Location = new System.Drawing.Point(372, 158);
            this.chkShowChecksum.Name = "chkShowChecksum";
            this.chkShowChecksum.Size = new System.Drawing.Size(108, 17);
            this.chkShowChecksum.TabIndex = 35;
            this.chkShowChecksum.Text = "Show CheckSum";
            this.chkShowChecksum.UseVisualStyleBackColor = true;
            // 
            // chkShowBorder
            // 
            this.chkShowBorder.AutoSize = true;
            this.chkShowBorder.Location = new System.Drawing.Point(210, 158);
            this.chkShowBorder.Name = "chkShowBorder";
            this.chkShowBorder.Size = new System.Drawing.Size(87, 17);
            this.chkShowBorder.TabIndex = 34;
            this.chkShowBorder.Text = "Show Border";
            this.chkShowBorder.UseVisualStyleBackColor = true;
            // 
            // chkShowText
            // 
            this.chkShowText.AutoSize = true;
            this.chkShowText.Checked = true;
            this.chkShowText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowText.Location = new System.Drawing.Point(28, 158);
            this.chkShowText.Name = "chkShowText";
            this.chkShowText.Size = new System.Drawing.Size(77, 17);
            this.chkShowText.TabIndex = 33;
            this.chkShowText.Text = "Show Text";
            this.chkShowText.UseVisualStyleBackColor = true;
            // 
            // cmbColor
            // 
            this.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbColor.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Items.AddRange(new object[] {
            "AliceBlue",
            "AntiqueWhite",
            "Aqua",
            "Aquamarine",
            "Azure",
            "Beige",
            "Bisque",
            "Black",
            "BlanchedAlmond",
            "Blue",
            "BlueViolet",
            "Brown",
            "BurlyWood",
            "CadetBlue",
            "Chocolate",
            "Coral",
            "DarkBlue",
            "DarkGreen",
            "Goldenrod",
            "GreenYellow",
            "SteelBlue"});
            this.cmbColor.Location = new System.Drawing.Point(390, 76);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(121, 21);
            this.cmbColor.TabIndex = 32;
            // 
            // cmbFont
            // 
            this.cmbFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFont.FormattingEnabled = true;
            this.cmbFont.Items.AddRange(new object[] {
            "Cambria",
            "Calibri",
            "Arial",
            "Verdana",
            "Arial Black",
            "Arial Narrow",
            "SimSun",
            "Corbel",
            ""});
            this.cmbFont.Location = new System.Drawing.Point(114, 76);
            this.cmbFont.Name = "cmbFont";
            this.cmbFont.Size = new System.Drawing.Size(153, 21);
            this.cmbFont.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(306, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Fore Color:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Font Family:";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(260, 118);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(73, 20);
            this.txtSize.TabIndex = 28;
            this.txtSize.Text = "8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Font Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Border Type:";
            // 
            // cmbBorderType
            // 
            this.cmbBorderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBorderType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBorderType.FormattingEnabled = true;
            this.cmbBorderType.Location = new System.Drawing.Point(390, 32);
            this.cmbBorderType.Name = "cmbBorderType";
            this.cmbBorderType.Size = new System.Drawing.Size(121, 21);
            this.cmbBorderType.TabIndex = 24;
            // 
            // cmbLabelType
            // 
            this.cmbLabelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLabelType.FormattingEnabled = true;
            this.cmbLabelType.Location = new System.Drawing.Point(114, 35);
            this.cmbLabelType.Name = "cmbLabelType";
            this.cmbLabelType.Size = new System.Drawing.Size(153, 21);
            this.cmbLabelType.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Barcode Type:";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.cmbBorderType);
            this.radGroupBox1.Controls.Add(this.txtHeight);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.label7);
            this.radGroupBox1.Controls.Add(this.cmbLabelType);
            this.radGroupBox1.Controls.Add(this.chkShowChecksum);
            this.radGroupBox1.Controls.Add(this.chkShowBorder);
            this.radGroupBox1.Controls.Add(this.chkShowText);
            this.radGroupBox1.Controls.Add(this.label3);
            this.radGroupBox1.Controls.Add(this.cmbColor);
            this.radGroupBox1.Controls.Add(this.label4);
            this.radGroupBox1.Controls.Add(this.cmbFont);
            this.radGroupBox1.Controls.Add(this.txtSize);
            this.radGroupBox1.Controls.Add(this.label6);
            this.radGroupBox1.Controls.Add(this.label5);
            this.radGroupBox1.HeaderText = "Apperance";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 310);
            this.radGroupBox1.Name = "radGroupBox1";
            // 
            // 
            // 
            this.radGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox1.Size = new System.Drawing.Size(615, 219);
            this.radGroupBox1.TabIndex = 38;
            this.radGroupBox1.Text = "Apperance";
            this.radGroupBox1.ThemeName = "Breeze";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(443, 535);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(89, 24);
            this.btnGenerate.TabIndex = 37;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.ThemeName = "Breeze";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(538, 535);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 24);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "Close";
            this.btnClose.ThemeName = "Breeze";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btnCreateSeq);
            this.radGroupBox2.Controls.Add(this.btnCreateRan);
            this.radGroupBox2.Controls.Add(this.label12);
            this.radGroupBox2.Controls.Add(this.label2);
            this.radGroupBox2.Controls.Add(this.label14);
            this.radGroupBox2.Controls.Add(this.txtQuantity);
            this.radGroupBox2.Controls.Add(this.label13);
            this.radGroupBox2.Controls.Add(this.btnReset);
            this.radGroupBox2.Controls.Add(this.lblListTotal);
            this.radGroupBox2.Controls.Add(this.radGroupBox3);
            this.radGroupBox2.Controls.Add(this.label11);
            this.radGroupBox2.Controls.Add(this.txtLength);
            this.radGroupBox2.Controls.Add(this.label10);
            this.radGroupBox2.Controls.Add(this.txtTotal);
            this.radGroupBox2.Controls.Add(this.label9);
            this.radGroupBox2.Controls.Add(this.txtEnd);
            this.radGroupBox2.Controls.Add(this.label8);
            this.radGroupBox2.Controls.Add(this.txtStart);
            this.radGroupBox2.Controls.Add(this.rdRandom);
            this.radGroupBox2.Controls.Add(this.rdSequential);
            this.radGroupBox2.HeaderText = "Generate Barcode Series";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox2.Name = "radGroupBox2";
            // 
            // 
            // 
            this.radGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox2.Size = new System.Drawing.Size(615, 292);
            this.radGroupBox2.TabIndex = 40;
            this.radGroupBox2.Text = "Generate Barcode Series";
            this.radGroupBox2.ThemeName = "Breeze";
            // 
            // btnCreateSeq
            // 
            this.btnCreateSeq.Location = new System.Drawing.Point(225, 96);
            this.btnCreateSeq.Name = "btnCreateSeq";
            this.btnCreateSeq.Size = new System.Drawing.Size(56, 24);
            this.btnCreateSeq.TabIndex = 37;
            this.btnCreateSeq.Text = "Create";
            this.btnCreateSeq.ThemeName = "Breeze";
            this.btnCreateSeq.Click += new System.EventHandler(this.btnCreateSeq_Click);
            // 
            // btnCreateRan
            // 
            this.btnCreateRan.Enabled = false;
            this.btnCreateRan.Location = new System.Drawing.Point(225, 158);
            this.btnCreateRan.Name = "btnCreateRan";
            this.btnCreateRan.Size = new System.Drawing.Size(56, 24);
            this.btnCreateRan.TabIndex = 37;
            this.btnCreateRan.Text = "Create";
            this.btnCreateRan.ThemeName = "Breeze";
            this.btnCreateRan.Click += new System.EventHandler(this.btnCreateRan_Click);
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(123, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 1);
            this.label12.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(113, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 1);
            this.label2.TabIndex = 40;
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Location = new System.Drawing.Point(33, 191);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(185, 1);
            this.label14.TabIndex = 39;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(114, 263);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(82, 20);
            this.txtQuantity.TabIndex = 38;
            this.txtQuantity.Text = "1";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(30, 239);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 44);
            this.label13.TabIndex = 37;
            this.label13.Text = "Quabtity of each label to print";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(544, 249);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(56, 24);
            this.btnReset.TabIndex = 36;
            this.btnReset.Text = "Reset";
            this.btnReset.ThemeName = "Breeze";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblListTotal
            // 
            this.lblListTotal.AutoSize = true;
            this.lblListTotal.Location = new System.Drawing.Point(399, 34);
            this.lblListTotal.Name = "lblListTotal";
            this.lblListTotal.Size = new System.Drawing.Size(71, 13);
            this.lblListTotal.TabIndex = 35;
            this.lblListTotal.Text = "Total Labels :";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.lbSeries);
            this.radGroupBox3.HeaderText = "Series Preview";
            this.radGroupBox3.Location = new System.Drawing.Point(402, 59);
            this.radGroupBox3.Name = "radGroupBox3";
            // 
            // 
            // 
            this.radGroupBox3.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox3.Size = new System.Drawing.Size(200, 184);
            this.radGroupBox3.TabIndex = 34;
            this.radGroupBox3.Text = "Series Preview";
            this.radGroupBox3.ThemeName = "Breeze";
            // 
            // lbSeries
            // 
            this.lbSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSeries.FormattingEnabled = true;
            this.lbSeries.Location = new System.Drawing.Point(2, 18);
            this.lbSeries.Name = "lbSeries";
            this.lbSeries.Size = new System.Drawing.Size(196, 164);
            this.lbSeries.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Label Length";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(113, 205);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(82, 20);
            this.txtLength.TabIndex = 33;
            this.txtLength.Text = "8";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(51, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Total Lables";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(137, 162);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(82, 20);
            this.txtTotal.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "List Ending";
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(137, 100);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(82, 20);
            this.txtEnd.TabIndex = 29;
            this.txtEnd.Text = "10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "List Starting";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(137, 68);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(82, 20);
            this.txtStart.TabIndex = 27;
            this.txtStart.Text = "1";
            // 
            // rdRandom
            // 
            this.rdRandom.Location = new System.Drawing.Point(28, 132);
            this.rdRandom.Name = "rdRandom";
            this.rdRandom.Size = new System.Drawing.Size(84, 16);
            this.rdRandom.TabIndex = 1;
            this.rdRandom.Text = "Random List";
            this.rdRandom.ThemeName = "Breeze";
            this.rdRandom.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.rdRandom_ToggleStateChanged);
            // 
            // rdSequential
            // 
            this.rdSequential.Location = new System.Drawing.Point(28, 34);
            this.rdSequential.Name = "rdSequential";
            this.rdSequential.Size = new System.Drawing.Size(95, 16);
            this.rdSequential.TabIndex = 0;
            this.rdSequential.Text = "Sequential List";
            this.rdSequential.ThemeName = "Breeze";
            this.rdSequential.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.rdSequential_ToggleStateChanged);
            // 
            // frmGenerateLabels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 565);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmGenerateLabels";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generate Labels";
            this.ThemeName = "Breeze";
            this.Load += new System.EventHandler(this.frmGenerateLabels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateSeq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateRan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdRandom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdSequential)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkShowChecksum;
        private System.Windows.Forms.CheckBox chkShowBorder;
        private System.Windows.Forms.CheckBox chkShowText;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.ComboBox cmbFont;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBorderType;
        private System.Windows.Forms.ComboBox cmbLabelType;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnGenerate;
        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label13;
        private Telerik.WinControls.UI.RadButton btnReset;
        private System.Windows.Forms.Label lblListTotal;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private System.Windows.Forms.ListBox lbSeries;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStart;
        private Telerik.WinControls.UI.RadRadioButton rdRandom;
        private Telerik.WinControls.UI.RadRadioButton rdSequential;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadButton btnCreateSeq;
        private Telerik.WinControls.UI.RadButton btnCreateRan;
    }
}
