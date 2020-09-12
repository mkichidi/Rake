namespace Rake.Reports.Reports
{
    partial class BillsAttach
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rv = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Rake.Reports.ReportForms.BillAttach.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(800, 673);
            this.reportViewer1.TabIndex = 0;
            // 
            // rv
            // 
            this.rv.LocalReport.ReportEmbeddedResource = "Rake.Reports.ReportForms.BillAttachNoBreak.rdlc";
            this.rv.Location = new System.Drawing.Point(401, 181);
            this.rv.Name = "rv";
            this.rv.Size = new System.Drawing.Size(396, 246);
            this.rv.TabIndex = 1;
            this.rv.Visible = false;
            // 
            // BillsAttach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 680);
            this.Controls.Add(this.rv);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BillsAttach";
            this.Text = "BillsAttach";
            this.Load += new System.EventHandler(this.BillsAttach_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer rv;
    }
}