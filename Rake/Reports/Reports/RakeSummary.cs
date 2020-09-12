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
    public partial class RakeSummary : Form
    {
        public RakeSummary()
        {
            InitializeComponent();
        }

        private void RakeSummary_Load(object sender, EventArgs e)
        {
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;

            ReportDataSource rds = new ReportDataSource("RakeSummary", RakeDatatable.dt);


            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            
            this.reportViewer1.RefreshReport();

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = this.reportViewer1.LocalReport.Render(
               "EXCELOPENXML", null, out mimeType, out encoding, out extension,
               out streamids, out warnings);

            FileStream fs = new FileStream(@"d:\output.xlsx", FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(@"d:\output.xlsx")))
            {
                var worksheet = package.Workbook.Worksheets[1];
                String month = RakeDatatable.dt.Rows[0]["RakeMonth"].ToString().Split(' ')[0].Split('-')[1];
                String year = RakeDatatable.dt.Rows[0]["RakeMonth"].ToString().Split(' ')[0].Split('-')[0];
                //Convert.ToDateTime(dt RakeDatatable.submitDate.Date).ToString("MMM");
                //string year = Convert.ToDateTime(RakeDatatable.submitDate.Date).ToString("yyyy");
                System.IO.Directory.CreateDirectory("D:\\Rake\\" + RakeDatatable.financialYear + "\\" + "Reports\\" + month + "-" + year + "\\Summary");
                using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Rake\\" + RakeDatatable.financialYear + "\\" + "Reports\\" + month + "-" + year + "\\Summary\\Rake_" + month + "-" + year + ".xlsx")))
                {
                    DataTable dt = RakeDatatable.dt.DefaultView.ToTable(true, "Rake");
                    string str = string.Empty;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            str += dt.Rows[i]["Rake"];
                        }
                        else
                        {
                            str += ","+dt.Rows[i]["Rake"].ToString().Split('-')[1];
                        }
                    }
                    var worksheetCheck = pac.Workbook.Worksheets["RakeSummary-" + str];

                        if (worksheetCheck == null)
                        {

                            pac.Workbook.Worksheets.Add("RakeSummary-" + str, worksheet);
                            pac.Save();
                        }
                        else
                        {
                            pac.Workbook.Worksheets.Delete(worksheetCheck);
                            pac.Workbook.Worksheets.Add("RakeSummary-" + str, worksheet);
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
