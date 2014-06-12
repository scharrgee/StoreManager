namespace storeManager.UI
{
    partial class frmDatabaseBackUp
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
            this.lblPercentageComplete = new System.Windows.Forms.Label();
            this.chkDifferential = new System.Windows.Forms.CheckBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkDefault = new System.Windows.Forms.CheckBox();
            this.lblCurrntTask = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTaskPath = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.btnRunTask = new Telerik.WinControls.UI.RadButton();
            this.btnBrowse = new Telerik.WinControls.UI.RadButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRunTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.lblPercentageComplete);
            this.groupBox1.Controls.Add(this.chkDifferential);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkDefault);
            this.groupBox1.Controls.Add(this.lblCurrntTask);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblTaskPath);
            this.groupBox1.Controls.Add(this.lblProgress);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 160);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backup Database";
            // 
            // lblPercentageComplete
            // 
            this.lblPercentageComplete.AutoSize = true;
            this.lblPercentageComplete.Location = new System.Drawing.Point(149, 32);
            this.lblPercentageComplete.Name = "lblPercentageComplete";
            this.lblPercentageComplete.Size = new System.Drawing.Size(0, 13);
            this.lblPercentageComplete.TabIndex = 12;
            // 
            // chkDifferential
            // 
            this.chkDifferential.AutoSize = true;
            this.chkDifferential.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDifferential.Location = new System.Drawing.Point(178, 53);
            this.chkDifferential.Name = "chkDifferential";
            this.chkDifferential.Size = new System.Drawing.Size(76, 17);
            this.chkDifferential.TabIndex = 11;
            this.chkDifferential.Text = "Differential";
            this.chkDifferential.UseVisualStyleBackColor = true;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(114, 101);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(188, 52);
            this.txtComment.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Comments :";
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            this.chkDefault.Location = new System.Drawing.Point(114, 53);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(15, 14);
            this.chkDefault.TabIndex = 6;
            this.chkDefault.UseVisualStyleBackColor = true;
            // 
            // lblCurrntTask
            // 
            this.lblCurrntTask.AutoSize = true;
            this.lblCurrntTask.Location = new System.Drawing.Point(8, 31);
            this.lblCurrntTask.Name = "lblCurrntTask";
            this.lblCurrntTask.Size = new System.Drawing.Size(68, 13);
            this.lblCurrntTask.TabIndex = 3;
            this.lblCurrntTask.Text = "Current Task";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Use Default Path  :";
            // 
            // lblTaskPath
            // 
            this.lblTaskPath.AutoSize = true;
            this.lblTaskPath.Location = new System.Drawing.Point(8, 78);
            this.lblTaskPath.Name = "lblTaskPath";
            this.lblTaskPath.Size = new System.Drawing.Size(69, 13);
            this.lblTaskPath.TabIndex = 1;
            this.lblTaskPath.Text = "Backup Path";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(117, 27);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 20);
            this.lblProgress.TabIndex = 4;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(114, 73);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(229, 20);
            this.txtPath.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(403, 53);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 24);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Cancel";
            this.btnClose.ThemeName = "Breeze";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRunTask
            // 
            this.btnRunTask.Location = new System.Drawing.Point(403, 18);
            this.btnRunTask.Name = "btnRunTask";
            this.btnRunTask.Size = new System.Drawing.Size(110, 24);
            this.btnRunTask.TabIndex = 8;
            this.btnRunTask.Text = "Run Task";
            this.btnRunTask.ThemeName = "Breeze";
            this.btnRunTask.Click += new System.EventHandler(this.btnRunTask_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(345, 71);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(22, 24);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "...";
            this.btnBrowse.ThemeName = "Breeze";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // frmDatabaseBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 213);
            this.Controls.Add(this.btnRunTask);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmDatabaseBackUp";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database BackUp";
            this.ThemeName = "Breeze";
            this.Load += new System.EventHandler(this.frmDatabaseBackUp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRunTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPercentageComplete;
        private System.Windows.Forms.CheckBox chkDifferential;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkDefault;
        private System.Windows.Forms.Label lblCurrntTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTaskPath;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TextBox txtPath;
        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadButton btnRunTask;
        private Telerik.WinControls.UI.RadButton btnBrowse;
    }
}
