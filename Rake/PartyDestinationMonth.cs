using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using OfficeOpenXml;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace Rake
{
    public partial class PartyDestinationMonth : Form
    {
        public PartyDestinationMonth()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeFrom", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

           DataRow row = dataTable.NewRow();
            row["From"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);

            DdlFrom.DataSource = new DataView(dataTable);
            DdlFrom.DisplayMember = "From";
            DdlFrom.SelectedIndex = 0;
            DdlFrom.ValueMember = "ID";
        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("PartyDestinationMonth", con);

            cmd.Parameters.AddWithValue("@dtFrom", DtPaidDateFrom.Value.Date  );
            cmd.Parameters.AddWithValue("@dtTo", DtPaidDateTo.Value.Date);

            if (DdlFrom.SelectedIndex > 0)
            {
                cmd.Parameters.AddWithValue("@From", DdlFrom.SelectedValue);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            GvRakeBill.DataSource = dataTable;
            this.GvRakeBill.AllowUserToAddRows = false;

            this.GvRakeBill.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.GvRakeBill.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DdlFrom.SelectedIndex < 1)
            {
                MessageBox.Show("Please select From");
                DdlFrom.Focus();
                return;
            }
            else if (Convert.ToDateTime(DtPaidDateFrom.Text).Date > Convert.ToDateTime(DtPaidDateTo.Text).Date)
            {
                MessageBox.Show("Please select To Date Grater than From Date");
                DtPaidDateFrom.Focus();
                return;
            }
            BindGrid();
        }

        private void CtrlBtnPrintBill_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)GvRakeBill.DataSource;

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel File (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 1;
            
            System.IO.Directory.CreateDirectory("D:\\Rake\\Sum On Destination\\");
            using (ExcelPackage pck = new ExcelPackage(new System.IO.FileInfo("D:\\Rake\\Sum On Destination\\" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + ".xlsx")))
            {
                {

                    var worksheetCheck = pck.Workbook.Worksheets[Convert.ToString("Sum On Destination")];

                    if (worksheetCheck != null)
                    {
                        pck.Workbook.Worksheets.Delete(worksheetCheck);
                    }

                    // Add a new worksheet to the empty workbook
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sum On Destination");
                    // Load data from DataTable to the worksheet
                    ws.Cells["A1"].LoadFromDataTable(((DataTable)GvRakeBill.DataSource), true);
                    ws.Cells.AutoFitColumns();

                    // Add some styling
                    using (ExcelRange rng = ws.Cells[1, 1, 1, GvRakeBill.Columns.Count])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                        rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    }

                    // Save the workbook to file
                    pck.Save();
                }
                DialogResult ans = MessageBox.Show("File Downloaded at " + "D:\\Rake\\Sum On Destination\\" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + ".xlsx" + Environment.NewLine + "Do you want to open?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("D:\\Rake\\Sum On Destination\\" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + ".xlsx");
                }
            }
        }
    }
}
