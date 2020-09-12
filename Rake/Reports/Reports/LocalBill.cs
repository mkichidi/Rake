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
    public partial class LocalBill : Form
    {
        public LocalBill()
        {
            InitializeComponent();
        }

        private void LocalBill_Load(object sender, EventArgs e)
        {

            ReportParameter[] parms = new ReportParameter[5];
            parms[0] = new ReportParameter("MainLI_Addressed", System.Configuration.ConfigurationManager.AppSettings["MainLI_Addressed"].ToString());
            parms[1] = new ReportParameter("Address", System.Configuration.ConfigurationManager.AppSettings["Address1"].ToString());
            parms[2] = new ReportParameter("SubmitDate", RakeDatatable.submitDate.Date.ToString().Substring(0, 10));
            int Total = 0;
            foreach (DataRow dr in RakeDatatable.dt.Rows)
            {
                Total += Convert.ToInt32(dr["Amount"]);
            }
            parms[3] = new ReportParameter("InWords", "In Rupees:" + RakeDatatable.ConvertNumbertoWords(Total));
            parms[4] = new ReportParameter("BillNo", RakeDatatable.bill);
            //parms[5] = new ReportParameter("RailHandling", Convert.ToString(RakeDatatable.dt.Rows[0]["RakeHandling/Ton"]));

            this.reportViewer1.LocalReport.SetParameters(parms);


            ReportDataSource rds = new ReportDataSource("Bill", RakeDatatable.dt);


            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
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
                    var worksheetCheck = pac.Workbook.Worksheets[ RakeDatatable.bill];

                    if (worksheetCheck == null)
                    {

                        pac.Workbook.Worksheets.Add( RakeDatatable.bill, worksheet);
                        pac.Save();
                    }
                    else
                    {
                        pac.Workbook.Worksheets.Delete(worksheetCheck);
                        pac.Workbook.Worksheets.Add(  RakeDatatable.bill, worksheet);
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
