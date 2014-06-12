namespace CreditFinance
{
    partial class frmRestoreDatabase
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtGridViewList = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtGridViewList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(691, 267);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Last Seven Backups";
            // 
            // dtGridViewList
            // 
            this.dtGridViewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridViewList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGridViewList.Location = new System.Drawing.Point(3, 16);
            this.dtGridViewList.Name = "dtGridViewList";
            this.dtGridViewList.Size = new System.Drawing.Size(685, 248);
            this.dtGridViewList.TabIndex = 0;
            this.dtGridViewList.Click += new System.EventHandler(this.dtGridViewList_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(717, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(717, 41);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(15, 282);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(688, 23);
            this.pbProgress.TabIndex = 3;
            // 
            // frmRestoreDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 312);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRestoreDatabase";
            this.Text = "Restore Database";
            this.Load += new System.EventHandler(this.frmRestoreDatabase_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtGridViewList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.ProgressBar pbProgress;
    }
}