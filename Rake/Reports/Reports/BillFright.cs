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
            ReportParameter[] parms = new ReportParameter[13];
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



            ReportDataSource rds = new ReportDataSource("Bill", RakeDatatable.dt);

            var totalAmountWithGST =Convert.ToInt64(Total);

            if (RakeDatatable.submitDate >= Convert.ToDateTime("01-Apr-2021"))
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Rake.Reports.ReportForms.BillGST.rdlc";

                var sgstPer = RakeDatatable.dtGSTTax.AsEnumerable().Where(r => r.Field<string>("RakeTaxName") == "SGST").First()["RakeTax"];
                var cgstPer=RakeDatatable.dtGSTTax.AsEnumerable().Where(r => r.Field<string>("RakeTaxName") == "CGST").First()["RakeTax"];
                var sgst = Convert.ToInt64( Total * Convert.ToDecimal(sgstPer) / 100);
                var cgst = Convert.ToInt64(Total * Convert.ToDecimal(cgstPer) / 100);
                totalAmountWithGST = sgst + cgst + Total;

                //cons = new SqlConnection(Connection.InvAdminConn());
                //cmds = new SqlCommand("InsertJSWTaxDetails", cons);
                //cmds.CommandType = CommandType.StoredProcedure;
                //cmds.Parameters.AddWithValue("@SGST", Convert.ToString(dataTable.Rows[0]["SGST"]));
                //cmds.Parameters.AddWithValue("@CGST", Convert.ToString(dataTable.Rows[0]["CGST"]));
                //cmds.Parameters.AddWithValue("@SGSTAmount", sgst);
                //cmds.Parameters.AddWithValue("@CGSTAmount", cgst);
                //cmds.Parameters.AddWithValue("@AmountBeforeGST", Total);
                //cmds.Parameters.AddWithValue("@AmountWithGST", totalAmountWithGST);
                //cmds.Parameters.AddWithValue("@SubmittedOn", JswDatatable.submitDate);
                //cmds.Parameters.AddWithValue("@Bill", bill);
                //cmds.Parameters.AddWithValue("@SplBill", 1);
                //cmds.Parameters.AddWithValue("@JSWWorkOrderID", jswOrderId);
                //cons.Open();
                //cmds.ExecuteNonQuery();
                //cons.Close();

                parms[8] = new ReportParameter("SGSTAmount", Convert.ToString(sgst));
                parms[9] = new ReportParameter("CGSTAmount", Convert.ToString(cgst));
                parms[10] = new ReportParameter("SGST", Convert.ToString(sgstPer));
                parms[11] = new ReportParameter("CGST", Convert.ToString(cgstPer));
            }
            else
            {
                parms[8] = new ReportParameter("SGST", "Empty");
                parms[9] = new ReportParameter("CGST", "Empty");
                parms[10] = new ReportParameter("SGSTAmount", "Empty");
                parms[11] = new ReportParameter("CGSTAmount", "Empty");
            }
            parms[3] = new ReportParameter("InWords", "In Rupees:" + RakeDatatable.ConvertNumbertoWords(totalAmountWithGST));
            parms[12] = new ReportParameter("TotalAmountWithGST", Convert.ToString(totalAmountWithGST));

            this.reportViewer1.LocalReport.SetParameters(parms);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();

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
            //    String month = RakeDatatable.dt.Rows[0]["ShipmentMonth"].ToString().Split('-')[0];
            //    String year = RakeDatatable.dt.Rows[0]["ShipmentMonth"].ToString().Split('-')[1];
            //    //String month = Convert.ToDateTime(RakeDatatable.submitDate.Date).ToString("MMM");
            //    //string year = Convert.ToDateTime(RakeDatatable.submitDate.Date).ToString("yyyy");
            //    System.IO.Directory.CreateDirectory("D:\\Rake\\" + RakeDatatable.financialYear + "\\" + "Reports\\" + month + "-" + year + "\\Bills");
            //    using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Rake\\" + RakeDatatable.financialYear + "\\" + "Reports\\" + month + "-" + year + "\\Bills\\Rake_" + month + "-" + year + ".xlsx")))
            //    {
            //        var worksheetCheck = pac.Workbook.Worksheets[RakeDatatable.bill];

            //        if (worksheetCheck == null)
            //        {

            //            pac.Workbook.Worksheets.Add( RakeDatatable.bill, worksheet);
            //            pac.Save();
            //        }
            //        else
            //        {
            //            pac.Workbook.Worksheets.Delete(worksheetCheck);
            //            pac.Workbook.Worksheets.Add( RakeDatatable.bill, worksheet);
            //            pac.Save();
            //        }
            //    }

            //    System.IO.Directory.CreateDirectory("D:\\Rake\\" + RakeDatatable.financialYear + "\\" + "AllBills");
            //    using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Rake\\" + RakeDatatable.financialYear + "\\" + "AllBills\\All.xlsx")))
            //    {
            //        var worksheetCheck = pac.Workbook.Worksheets[RakeDatatable.bill];

            //        if (worksheetCheck == null)
            //        {

            //            pac.Workbook.Worksheets.Add(RakeDatatable.bill, worksheet);
            //            pac.Save();
            //        }
            //        else
            //        {
            //            pac.Workbook.Worksheets.Delete(worksheetCheck);
            //            pac.Workbook.Worksheets.Add(RakeDatatable.bill, worksheet);
            //            pac.Save();
            //        }
            //    }

            //}
            System.IO.FileInfo excel = new System.IO.FileInfo(@"d:\output.xlsx");

            if (excel.Exists)
            {
                excel.Delete();
            }
        }
    }
}
