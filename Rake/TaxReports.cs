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
using System.Diagnostics;
using DevExpress.XtraEditors.Repository;
using OfficeOpenXml.Style;

namespace Rake
{
    public partial class TaxReports : Form
    {
        DataTable backup = new DataTable();
        public TaxReports()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            DdlRakeType.Properties.DataSource = dataTable;
            DdlRakeType.Properties.DisplayMember = "RakeTypeName";
            DdlRakeType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            DdlRakeType.Properties.IncrementalSearch = true;
            DdlRakeType.KeyDown += new KeyEventHandler(checkedComboBoxEdit1_KeyDown);

            DtFrom.Format = DateTimePickerFormat.Custom;
            DtFrom.CustomFormat = "MMMM/yyyy";

        }

        void checkedComboBoxEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((DevExpress.XtraEditors.CheckedComboBoxEdit)sender).IsPopupOpen)
                ((DevExpress.XtraEditors.CheckedComboBoxEdit)sender).ShowPopup();
        }

        public DataTable BindGrid()
        {
            SqlDataReader reader;
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("RakeTaxReports", con);

            cmd.Parameters.AddWithValue("@From", DtFrom.Value.Date.Date);
            //cmd.Parameters.AddWithValue("@to", dtTo.Value.Date.Date);
            cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.Text.Replace(", ", ","));
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            backup = dataTable;
            con.Close();
            return dataTable;
        }

        private void TSxtSearch_Click(object sender, EventArgs e)
        {
            ReportParameter[] parms = new ReportParameter[2];
            if ( DateTime.Now>=Convert.ToDateTime("01/04/"+DateTime.Now.Year))
            {
                parms[0] = new ReportParameter("Year", DateTime.Now.Year + "-" + DateTime.Now.ToString("yy"));
            }
            else
            {
                parms[0] = new ReportParameter("Year", (DateTime.Now.Year-1).ToString("yy") + "-" + DateTime.Now.Year);
            }


            ReportDataSource rds = new ReportDataSource("TaxReport", BindGrid());
            parms[1] = new ReportParameter("Date", DtFrom.Value.ToString("dd-MMM-yyyy")+" to "+dtTo.Value.ToString("dd-MMM-yyyy"));
            this.reportViewer1.LocalReport.SetParameters(parms);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                System.IO.Directory.CreateDirectory("D:\\Bank\\Reports\\");

                string filename = DateTime.Today.ToString().Substring(0, 10).Replace('/', '_') + " (" + DateTime.Now.ToString("h.mm.ss") + ")";

                System.IO.FileInfo excels = new System.IO.FileInfo(@"D:\\BankBank\\Reports\\" + filename + ".xlsx");
                if (excels.Exists)
                {
                    excels.Delete();
                }
                using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Bank\\Reports\\" + filename + ".xlsx")))
                {
                    var worksheetCheck = pac.Workbook.Worksheets[Convert.ToString("SearchOnAll")];

                    if (worksheetCheck == null)
                    {

                        pac.Workbook.Worksheets.Add((Convert.ToString("SearchOnAll")), worksheet);
                        pac.Save();
                    }
                    else
                    {
                        pac.Workbook.Worksheets.Delete(worksheetCheck);
                        pac.Workbook.Worksheets.Add((Convert.ToString("SearchOnAll")), worksheet);
                    }
                    DialogResult ans = MessageBox.Show("File Downloaded at " + "D:\\Bank\\Reports\\" + filename + Environment.NewLine + "Do you want to open?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ans == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("D:\\Bank\\Reports\\" + filename + ".xlsx");
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
