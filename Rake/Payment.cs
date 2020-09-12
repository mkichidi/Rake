using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using OfficeOpenXml;
namespace Rake
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void DownloadFile_Click(object sender, EventArgs e)
        {
            string[] bills;
List<int> blanck = new List<int>();

            if (string.IsNullOrEmpty(TxtBillNo.Text))
            {
                MessageBox.Show("Please enter Bill No");
                TxtBillNo.Focus();
                return;
            }
            else
            {
                bills = TxtBillNo.Text.Split(',');
                 decimal dec=0M;
                foreach (string bill in bills)
                {
                   if( !decimal.TryParse(bill,out dec))
                   {
                       MessageBox.Show("Please enter correct Bill No");
                       TxtBillNo.Focus();
                       return;
                   }
                }
            }

            string filename = "D:\\RAke\\PaymentDetails\\PaymentDetails_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_');
            System.IO.Directory.CreateDirectory("D:\\RAke\\PaymentDetails");
            System.IO.FileInfo excel = new System.IO.FileInfo(filename + ".xlsx");

            if (excel.Exists)
            {
                excel.Delete();
            }
            using (var xls = new ExcelPackage(excel))
            {
                var sheet = xls.Workbook.Worksheets.Add("PaymentDetails");
                sheet.Cells["A1"].Value = "AP DOC NO";
                sheet.Cells["B1"].Value = "BRANCH";
                sheet.Cells["C1"].Value = "AP-CODE";
                sheet.Cells["D1"].Value = "PARTY";
                sheet.Cells["E1"].Value = "RAKE NO";
                sheet.Cells["F1"].Value = "BILL-NO";
                sheet.Cells["G1"].Value = "BILL-DT";
                sheet.Cells["H1"].Value = "BILL AMT";
                sheet.Cells["I1"].Value = "BILL AMT AFTER LESS TDS";
                sheet.Cells["J1"].Value = "MANDYA AMT";
                sheet.Cells["K1"].Value = "I-J-O AMOUNT";
                sheet.Cells["L1"].Value = "K-P SHORT";
                sheet.Cells["M1"].Value = "Gross";
                sheet.Cells["N1"].Value = "TDS";

                sheet.Cells["O1"].Value = "Debit memo/advance";
                sheet.Cells["P1"].Value = "RECD AMT";
                sheet.Cells["Q1"].Value = "Work-Type";
                sheet.Cells["R1"].Value = "BANK";
                sheet.Cells["S1"].Value = "CH NO";
                sheet.Cells["T1"].Value = "DATE";
                sheet.Cells["U1"].Value = "Paid Month";
                sheet.Cells["V1"].Value = "Remarks";

                sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                //sheet.Column(1).Width = 20;
                //sheet.Column(2).Width = 20;
                //sheet.Column(3).Width = 20;
                //sheet.Column(4).Width = 20;
                //sheet.Column(5).Width = 20;
                //sheet.Column(6).Width = 20;
                //sheet.Column(7).Width = 15;
                //sheet.Column(8).Width = 20;
                //sheet.Column(9).Width = 20;
                //sheet.Column(10).Width = 20;
                //sheet.Column(11).Width = 20;
                //sheet.Column(12).Width = 20;
                //sheet.Column(13).Width = 20;
                //sheet.Column(14).Width = 20;


                //Get the final row for the column in the worksheet
                int finalrows = sheet.Dimension.End.Row;


                sheet.Cells["A1:V" + finalrows.ToString()].Style.WrapText = true;
                sheet.Cells["A1:1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["A1:V1"].Style.Font.Size = 12;

                sheet.Cells["A1:V1"].Style.Font.Bold = true;
                sheet.Cells["A1:V1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                sheet.Cells["A1:V1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);

                //sheet.Cells["H1:P" + finalrows.ToString()].Style.Numberformat.Format = "#,##0.00";



                for (int i = 0; i < bills.Count(); i++)
                {
                    SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                    SqlCommand cmd = new SqlCommand("GetRakeBillDetailsForPayment", con);
                    cmd.Parameters.AddWithValue("@Bill", bills[i]);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    con.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        sheet.Cells["E" + (i + 2)].Value = ds.Tables[0].Rows[0]["Rake"];
                        sheet.Cells["F" + (i + 2)].Value = ds.Tables[0].Rows[0]["Bill"];
                        sheet.Cells["G" + (i + 2)].Value = ds.Tables[0].Rows[0]["SubmittedOn"];
                        sheet.Cells["H" + (i + 2)].Value = ds.Tables[0].Rows[0]["BillAmount"];
                        sheet.Cells["N" + (i + 2)].Value = ds.Tables[0].Rows[0]["TDS"];
                        sheet.Cells["I" + (i + 2)].Value = ds.Tables[0].Rows[0]["AMTAFTERTDS"];
                        sheet.Cells["M" + (i + 2)].Value = ds.Tables[0].Rows[0]["BillAmount"];
                        sheet.Cells["Q" + (i + 2)].Value = ds.Tables[0].Rows[0]["WorkType"];
                    }
                    else
                    {
                        blanck.Add(Convert.ToInt32(i));
                    }
                }

                for (int row = 0; row < blanck.Count(); row++)
                {
                    sheet.DeleteRow((blanck[row]+2) - row);
                }

                xls.Save();

                DialogResult ans = MessageBox.Show("File Downloaded at " + filename + Environment.NewLine + "Do you want to open?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(filename + ".xlsx");
                }
            }
        }


    }
}
