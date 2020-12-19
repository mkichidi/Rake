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
    public partial class BillFright : Form
    {
        public BillFright()
        {
            InitializeComponent();
        }

        private void BillFright_Load(object sender, EventArgs e)
        {
            ReportParameter[] parms = new ReportParameter[8];
            string MainLI_Addressed;
            if (Convert.ToDateTime(RakeDatatable.dt.Rows[0]["ShipmentMonth"]) < new DateTime(2020, 4, 1))
            {

                 MainLI_Addressed = "FROM," + Environment.NewLine + "BALAJI TRANSPORTS PROP - G.N RAMAKRISHNA" + Environment.NewLine + "#14, SATHYAMANGALA INDUSTRIAL AREA" + Environment.NewLine + "TUMKUR";
            }
            else
            {
                MainLI_Addressed = "FROM," + Environment.NewLine + "BALAJI TRANSPORTS" + Environment.NewLine + "#14, SATHYAMANGALA INDUSTRIAL AREA" + Environment.NewLine + "TUMKUR. Mob:9448275233";
            }

            string JSWaDDRESS = "TO," + Environment.NewLine + "JSW STEEL LIMITED" + Environment.NewLine + "PO - VIDYANAGAR" + Environment.NewLine + "TORNAGALLU" + Environment.NewLine + "BELLARY DIST";
            parms[0] = new ReportParameter("MainLI_Addressed", MainLI_Addressed);
            parms[1] = new ReportParameter("Address", JSWaDDRESS);
            parms[2] = new ReportParameter("SubmitDate", RakeDatatable.submitDate.Date.ToString().Substring(0, 10));
            int Total = 0;
            foreach (DataRow dr in RakeDatatable.dt.Rows)
            {
                Total += Convert.ToInt32(dr["Amount"]);
            }
            parms[3] = new ReportParameter("InWords", "In Rupees:" + RakeDatatable.ConvertNumbertoWords(Total));
            parms[4] = new ReportParameter("BillNo", RakeDatatable.bill);
            parms[5] = new ReportParameter("Month",Convert.ToString( RakeDatatable.dt.Rows [0]["ShipmentMonth"]).Split('-')[0]+" ");
            parms[6] = new ReportParameter("ShipmentNo", RakeDatatable.shipmentNo);

            SqlConnection cons = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmds = new SqlCommand("GetRakeWorkOrderOnDateAndPlace", cons);
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.Parameters.AddWithValue("@Date", RakeDatatable.dt.Rows[0]["ShipmentDate"]);
            string place=string.Empty;
            cmds.Parameters.AddWithValue("@Place", Convert.ToInt32(RakeDatatable.dt.Rows[0]["FromID"]));
            cons.Open();

            SqlDataReader reader;
            reader = cmds.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            cons.Close();
            if (dataTable.Rows.Count > 0)
            {
                //if (Convert.ToString(RakeDatatable.dt.Rows[0]["From"]) == "White field Goods Shed,Bangalore")
                //{
                    parms[7] = new ReportParameter("WorkOrder", Convert.ToString(dataTable.Rows[0]["WorkOrder"]));
                //}
                //else
                //{
                //    parms[7] = new ReportParameter("WorkOrder", Convert.ToString(dataTable.Rows[0]["HosurOrderNo"]));
                //}
            }
            else
            {
                parms[7] = new ReportParameter("WorkOrder", " ");
            }

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
                String month = RakeDatatable.dt.Rows[0]["ShipmentMonth"].ToString().Split('-')[0];
                String year = RakeDatatable.dt.Rows[0]["ShipmentMonth"].ToString().Split('-')[1];
                //String month = Convert.ToDateTime(RakeDatatable.submitDate.Date).ToString("MMM");
                //string year = Convert.ToDateTime(RakeDatatable.submitDate.Date).ToString("yyyy");
                System.IO.Directory.CreateDirectory("D:\\Rake\\" + RakeDatatable.financialYear + "\\" + "Reports\\" + month + "-" + year + "\\Bills");
                using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Rake\\" + RakeDatatable.financialYear + "\\" + "Reports\\" + month + "-" + year + "\\Bills\\Rake_" + month + "-" + year + ".xlsx")))
                {
                    var worksheetCheck = pac.Workbook.Worksheets[RakeDatatable.bill];

                    if (worksheetCheck == null)
                    {

                        pac.Workbook.Worksheets.Add( RakeDatatable.bill, worksheet);
                        pac.Save();
                    }
                    else
                    {
                        pac.Workbook.Worksheets.Delete(worksheetCheck);
                        pac.Workbook.Worksheets.Add( RakeDatatable.bill, worksheet);
                        pac.Save();
                    }
                }

                System.IO.Directory.CreateDirectory("D:\\Rake\\" + RakeDatatable.financialYear + "\\" + "AllBills");
                using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Rake\\" + RakeDatatable.financialYear + "\\" + "AllBills\\All.xlsx")))
                {
                    var worksheetCheck = pac.Workbook.Worksheets[RakeDatatable.bill];

                    if (worksheetCheck == null)
                    {

                        pac.Workbook.Worksheets.Add(RakeDatatable.bill, worksheet);
                        pac.Save();
                    }
                    else
                    {
                        pac.Workbook.Worksheets.Delete(worksheetCheck);
                        pac.Workbook.Worksheets.Add(RakeDatatable.bill, worksheet);
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
