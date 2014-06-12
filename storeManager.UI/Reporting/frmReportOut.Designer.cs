namespace storeManager.UI.Reporting
{
    partial class frmReportOutput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportOutput));
            this.crystalReportViewerRep = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerRep
            // 
            this.crystalReportViewerRep.ActiveViewIndex = -1;
            this.crystalReportViewerRep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerRep.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerRep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerRep.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerRep.Name = "crystalReportViewerRep";
            this.crystalReportViewerRep.SelectionFormula = "";
            this.crystalReportViewerRep.ShowGroupTreeButton = false;
            this.crystalReportViewerRep.ShowParameterPanelButton = false;
            this.crystalReportViewerRep.ShowTextSearchButton = false;
            this.crystalReportViewerRep.Size = new System.Drawing.Size(968, 508);
            this.crystalReportViewerRep.TabIndex = 0;
            this.crystalReportViewerRep.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewerRep.ViewTimeSelectionFormula = "";
            // 
            // frmReportOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 508);
            this.Controls.Add(this.crystalReportViewerRep);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportOutput";
            this.Text = "Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerRep;
    }
}