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
using OfficeOpenXml;

namespace Rake.Reports.Reports
{
    public partial class BillsAttach : Form
    {
        public BillsAttach()
        {
            InitializeComponent();
        }

        private void BillsAttach_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtDetails = new DataTable();
            dt = RakeDatatable.dt;
            ReportParameter[] parms = new ReportParameter[4];
            decimal totalNet = 0M;
            int totalAmount = 0;
            foreach (DataRow dr in RakeDatatable.dtSummary.Rows)
            {
                totalNet += Convert.ToDecimal(dr["NetWt"]);
                totalAmount += Convert.ToInt32(dr["Amount"]);
            }

            parms[0] = new ReportParameter("TotalNet", Convert.ToString(totalNet));
            parms[1] = new ReportParameter("TotaLAmount", Convert.ToString(totalAmount));
            parms[2] = new ReportParameter("RailHandling", Convert.ToString(dt.Rows[0]["RakeHandling/Ton"]));
            parms[3] = new ReportParameter("ShipmentNo", RakeDatatable.shipmentNo);
            this.reportViewer1.LocalReport.SetParameters(parms);

            ReportDataSource rds = new ReportDataSource("AttachBill", dt);
            ReportDataSource rds1 = new ReportDataSource("AttachDetailsSummary", RakeDatatable.dtSummary);
            ReportDataSource rds2 = new ReportDataSource("Tax", RakeDatatable.dtTax);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.LocalReport.DataSources.Add(rds2);
            this.reportViewer1.RefreshReport();

            ExportExcel();

            //Warning[] warnings;
            //string[] streamids;
            //string mimeType;
            //string encoding;
            //string extension;

            //byte[] bytes = reportViewer1.LocalReport.Render(
            //   "EXCELOPENXML", null, out mimeType, out encoding, out extension,
            //   out streamids, out warnings);

            //FileStream fs = new FileStream(@"d:\output.xlsx", FileMode.Create);
            //fs.Write(bytes, 0, bytes.Length);
            //fs.Close();

            //using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(@"d:\output.xlsx")))
            //{
            //    var worksheet = package.Workbook.Worksheets[1];
            //    String month = Convert.ToDateTime(RakeDatatable.submitDate.Date).ToString("MMM");
            //    string year = Convert.ToDateTime(RakeDatatable.submitDate.Date).ToString("yyyy");
            //    System.IO.Directory.CreateDirectory("D:\\Rake\\Reports\\" + month + "-" + year);
            //    using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Rake\\Reports\\" + month + "-" + year + "\\Rake_" + month + "-" + year + ".xlsx")))
            //    {
            //        var worksheetCheck = pac.Workbook.Worksheets["Details_" + RakeDatatable.bill];

            //        if (worksheetCheck == null)
            //        {

            //            pac.Workbook.Worksheets.Add("Details_" + RakeDatatable.bill, worksheet);
            //            pac.Save();
            //        }
            //        else
            //        {
            //            pac.Workbook.Worksheets.Delete(worksheetCheck);
            //            pac.Workbook.Worksheets.Add("Details_" + RakeDatatable.bill, worksheet);
            //            pac.Save();
            //        }
            //    }
            //}
            //System.IO.FileInfo excel = new System.IO.FileInfo(@"d:\output.xlsx");

            //if (excel.Exists)
            //{
            //    excel.Delete();
            //}

            this.rv.RefreshReport();
        }

        private void ExportExcel()
        {
            //ReportViewer rv = new ReportViewer();
     //       rv.ProcessingMode = ProcessingMode.Local;
     //       string exeFolder = Application.StartupPath;
     //       string reportPath = @"Rake\Reports\ReportForms\BillAttachNoBreak.rdlc";
     //rv.LocalReport.ReportPath = reportPath;
            rv.LocalReport.DataSources.Clear();

             DataTable dt = new DataTable();
            DataTable dtDetails = new DataTable();
            dt = RakeDatatable.dt;
            ReportParameter[] parms = new ReportParameter[4];
            decimal totalNet = 0M;
            int totalAmount = 0;
            foreach (DataRow dr in RakeDatatable.dtSummary.Rows)
            {
                totalNet += Convert.ToDecimal(dr["NetWt"]);
                totalAmount += Convert.ToInt32(dr["Amount"]);
            }

            parms[0] = new ReportParameter("TotalNet", Convert.ToString(totalNet));
            parms[1] = new ReportParameter("TotaLAmount", Convert.ToString(totalAmount));
            parms[3] = new ReportParameter("ShipmentNo", RakeDatatable.shipmentNo);
            parms[2] = new ReportParameter("RailHandling", Convert.ToString(dt.Rows[0]["RakeHandling/Ton"]));
            rv.LocalReport.SetParameters(parms);

            ReportDataSource rds = new ReportDataSource("AttachBill", dt);
            ReportDataSource rds1 = new ReportDataSource("AttachDetailsSummary", RakeDatatable.dtSummary);
            ReportDataSource rds2 = new ReportDataSource("Tax", RakeDatatable.dtTax);
            rv.LocalReport.DataSources.Clear();
            rv.LocalReport.DataSources.Add(rds);
            rv.LocalReport.DataSources.Add(rds1);
            rv.LocalReport.DataSources.Add(rds2);
            rv.RefreshReport();

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = rv.LocalReport.Render(
               "EXCELOPENXML", null, out mimeType, out encoding, out extension,
               out streamids, out warnings);

            FileStream fs = new FileStream(@"d:\output.xlsx", FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(@"d:\output.xlsx")))
            {
                var worksheet = package.Workbook.Worksheets[1];
                String month = dt.Rows[0]["ShipmentMonth"].ToString().Split('-')[0];
                String year = dt.Rows[0]["ShipmentMonth"].ToString().Split('-')[1];
                //Convert.ToDateTime(dt RakeDatatable.submitDate.Date).ToString("MMM");
                //string year = Convert.ToDateTime(RakeDatatable.submitDate.Date).ToString("yyyy");
                System.IO.Directory.CreateDirectory("D:\\Rake\\" + RakeDatatable.financialYear + "\\" + "Reports\\" + month + "-" + year + "\\Summary");
                using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Rake\\" + RakeDatatable.financialYear + "\\" + "Reports\\" + month + "-" + year + "\\Summary\\Rake_" + month + "-" + year + ".xlsx")))
                {
                    if (dt.Rows[0]["Rake"].ToString().Contains("HSSG") && dt.Rows[0]["From"].ToString() == "Hosur Railway Sliding")
                    {
                        var worksheetCheck = pac.Workbook.Worksheets[dt.Rows[0]["Rake"].ToString() + " Hosur"];

                        if (worksheetCheck == null)
                        {

                            pac.Workbook.Worksheets.Add(dt.Rows[0]["Rake"].ToString()+" Hosur" , worksheet);
                            pac.Save();
                        }
                        else
                        {
                            pac.Workbook.Worksheets.Delete(worksheetCheck);
                            pac.Workbook.Worksheets.Add(dt.Rows[0]["Rake"].ToString() + " Hosur", worksheet);
                            pac.Save();
                        }
                    }
                    else
                    {
                        var worksheetCheck = pac.Workbook.Worksheets[dt.Rows[0]["Rake"].ToString()];

                        if (worksheetCheck == null)
                        {

                            pac.Workbook.Worksheets.Add(dt.Rows[0]["Rake"].ToString(), worksheet);
                            pac.Save();
                        }
                        else
                        {
                            pac.Workbook.Worksheets.Delete(worksheetCheck);
                            pac.Workbook.Worksheets.Add(dt.Rows[0]["Rake"].ToString(), worksheet);
                            pac.Save();
                        }
                    }
                }
            }
            System.IO.FileInfo excel = new System.IO.FileInfo(@"d:\output.xlsx");

            if (excel.Exists)
            {
                excel.Delete();
            }
        }

        int GetLastUsedRow(ExcelWorksheet sheet)
        {
            var row = sheet.Dimension.End.Row;
            while (row >= 1)
            {
                var range = sheet.Cells[row, 1, row, sheet.Dimension.End.Column];
                if (range.Any(c => !string.IsNullOrEmpty(c.Text)))
                {
                    break;
                }
                row--;
            }
            return row;
        }

    }
}
