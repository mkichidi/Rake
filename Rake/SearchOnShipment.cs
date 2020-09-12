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

namespace Rake
{
    public partial class SearchOnShipment : Form
    {

        public SearchOnShipment()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.P))
            {
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                byte[] bytes = reportViewer1.LocalReport.Render(
                   "PDF", null, out mimeType, out encoding, out extension,
                   out streamids, out warnings);

                FileStream fs = new FileStream(@"d:\output.pdf", FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();

                ProcessStartInfo info = new ProcessStartInfo();
                info.Verb = "print";
                info.FileName = @"d:\output.pdf";
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                Process p = new Process();
                p.StartInfo = info;
                p.Start();

                p.WaitForInputIdle();
                System.Threading.Thread.Sleep(3000);
                if (false == p.CloseMainWindow())
                    p.Kill();

                System.IO.FileInfo pdf = new System.IO.FileInfo(@"d:\output.pdf");

                if (pdf.Exists)
                {
                    pdf.Delete();
                }
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public DataTable BindGrid()
        {
            SqlDataReader reader;
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("SearchOnRakeShipmentDate", con);
            cmd.CommandTimeout = 1000000000;
            cmd.Parameters.AddWithValue("@From", DtFrom.Value.Date.Date);
            cmd.Parameters.AddWithValue("@to", dtTo.Value.Date.Date);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            return dataTable;
        }

        void checkedComboBoxEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((DevExpress.XtraEditors.CheckedComboBoxEdit)sender).IsPopupOpen)
                ((DevExpress.XtraEditors.CheckedComboBoxEdit)sender).ShowPopup();
        }

        private void TSxtSearch_Click(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("Search", BindGrid());
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
                System.IO.Directory.CreateDirectory("D:\\Rake\\Search\\");
                System.IO.FileInfo excels = new System.IO.FileInfo(@"D:\\Rake\\Search\\" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + ".xlsx"); 
                if (excels.Exists)
                {
                    excels.Delete();
                }
                using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Rake\\Search\\" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + ".xlsx")))
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
                    DialogResult ans = MessageBox.Show("File Downloaded at " + "D:\\Rake\\Search\\" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + ".xlsx" + Environment.NewLine + "Do you want to open?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ans == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("D:\\Rake\\Search\\" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + ".xlsx");
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
