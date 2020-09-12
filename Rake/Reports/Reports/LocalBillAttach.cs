using System.Diagnostics;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;

namespace Rake.Reports.Reports
{
    public partial class LocalBillAttach : Form
    {
        public LocalBillAttach()
        {
            InitializeComponent();
        }

        private void LocalBillAttach_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtDetails = new DataTable();
            dt = RakeDatatable.dt;
            ReportParameter[] parms = new ReportParameter[2];
            decimal totalNet = 0M;
            decimal totalAmount = 0M;
            foreach (DataRow dr in RakeDatatable.dtSummary.Rows)
            {
                totalNet += Convert.ToDecimal(dr["NetWt"]);
                totalAmount += Convert.ToDecimal(dr["Amount"]);
            }

            parms[0] = new ReportParameter("TotalNet", Convert.ToString(totalNet));
            parms[1] = new ReportParameter("TotaLAmount", Convert.ToString(totalAmount));
            //parms[2] = new ReportParameter("RailHandling", Convert.ToString(dt.Rows[0]["RakeHandling/Ton"]));
            this.reportViewer1.LocalReport.SetParameters(parms);

            ReportDataSource rds = new ReportDataSource("AttachBill", dt);
            ReportDataSource rds1 = new ReportDataSource("AttachSummary", RakeDatatable.dtSummary);
            //ReportDataSource rds2 = new ReportDataSource("Tax", RakeDatatable.dtTax);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            //this.reportViewer1.LocalReport.DataSources.Add(rds2);
            this.reportViewer1.RefreshReport();

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = reportViewer1.LocalReport.Render(
               "EXCELOPENXML", null, out mimeType, out encoding, out extension,
               out streamids, out warnings);

            FileStream fs = new FileStream(@"d:\output.xlsx", FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(@"d:\output.xlsx")))
            {
                var worksheet = package.Workbook.Worksheets[1];
                String month = Convert.ToDateTime(RakeDatatable.submitDate.Date).ToString("MMM");
                string year = Convert.ToDateTime(RakeDatatable.submitDate.Date).ToString("yyyy");
                System.IO.Directory.CreateDirectory("D:\\Local\\Reports\\" + month + "-" + year);
                using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Local\\Reports\\" + month + "-" + year + "\\Local_" + month + "-" + year + ".xlsx")))
                {
                    var worksheetCheck = pac.Workbook.Worksheets["Details_" + RakeDatatable.bill];

                    if (worksheetCheck == null)
                    {

                        pac.Workbook.Worksheets.Add("Details_" + RakeDatatable.bill, worksheet);
                        pac.Save();
                    }
                    else
                    {
                        pac.Workbook.Worksheets.Delete(worksheetCheck);
                        pac.Workbook.Worksheets.Add("Details_" + RakeDatatable.bill, worksheet);
                        pac.Save();
                    }
                }
            }
            System.IO.FileInfo excel = new System.IO.FileInfo(@"d:\output.xlsx");

            if (excel.Exists)
            {
                excel.Delete();
            }
        }
    }
}
