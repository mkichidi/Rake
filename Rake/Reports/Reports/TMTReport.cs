using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rake.Reports.Reports
{
    public partial class TMTReport : Form
    {
        public TMTReport()
        {
            InitializeComponent();

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("0", "-Select-");
            comboSource.Add("1", "Jan");
            comboSource.Add("2", "Feb");
            comboSource.Add("3", "Mar");
            comboSource.Add("4", "Apr");
            comboSource.Add("5", "May");
            comboSource.Add("6", "Jun");
            comboSource.Add("7", "Jul");
            comboSource.Add("8", "Aug");
            comboSource.Add("9", "Sep");
            comboSource.Add("10", "Oct");
            comboSource.Add("11", "Nov");
            comboSource.Add("12", "Dec");
            DDLMonth.DataSource = new BindingSource(comboSource, null);
            DDLMonth.DisplayMember = "Value";
            DDLMonth.ValueMember = "Key";

            DDLYear.SelectedIndex = 0;
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            DataRow row = dataTable.NewRow();
            row["RakeTypeName"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);

            DdlRakeType.DataSource = new DataView(dataTable);
            DdlRakeType.DisplayMember = "RakeTypeName";
            DdlRakeType.SelectedIndex = 0;
            DdlRakeType.ValueMember = "RakeTypeID";
        }

        private void DdlRakeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlRakeType.SelectedIndex > 0)
            {
                DdlRakeNo.Enabled = true;
            }
            else
            {
                DdlRakeNo.Enabled = false;
                return;
            }
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", DDLYear.Text);
            cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
            cmd.CommandTimeout = 1000000;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            DdlRakeNo.DataSource = new DataView(dataTable);
            DdlRakeNo.DisplayMember = "Rakeno";
        }


        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeTMTDetails", con);
            cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", DDLYear.Text);
            cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
            cmd.Parameters.AddWithValue("@RakeNo", DdlRakeNo.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 1000000;
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();

            var newSort =

                (from row in ds.Tables[0].AsEnumerable()
                 group row by new
                 {
                     Customer = row.Field<string>("Customer"),
                     WagonNo = row.Field<string>("WagonNo"),
                     InvoiceNo = row.Field<string>("InvoiceNo"),
                     VehicleNo = row.Field<string>("VehicleNo")
                 } into grp
                 select new
                 {
                     Customer = grp.Key.Customer,
                     WagonNo = grp.Key.WagonNo,
                     InvoiceNo = grp.Key.InvoiceNo,
                     VehicleNo = grp.Key.VehicleNo,
                     GC = grp.Max(r => r.Field<string>("GC")),
                     NtWt = grp.Sum(r => r.Field<Decimal>("NtWt")),
                 }).ToList();

            var objList = from s in newSort orderby s.Customer, s.WagonNo, s.InvoiceNo, s.VehicleNo select new { s.Customer, s.WagonNo, s.InvoiceNo,s.VehicleNo, s.GC, s.NtWt };

                //from row in ds.Tables[0].AsEnumerable()
                //          group row by new { Customer = row.Field<string>("Customer"), WagonNo = row.Field<string>("WagonNo"), InvoiceNo = row.Field<string>("InvoiceNo"), VehicleNo = row.Field<string>("VehicleNo") } into grp
                //          orderby grp.Key
                //          select new
                //          {
                //              Customer = grp.Key.Customer,
                //              WagonNo = grp.Key.WagonNo,
                //              InvoiceNo = grp.Key.InvoiceNo,
                //              VehicleNo = grp.Key.VehicleNo,
                //              Sum = grp.Max(r => Convert.ToDecimal(r.ItemArray[4])),
                //              Sum2 = grp.Sum(r => Convert.ToDecimal(r.ItemArray[5]))
                //          };



            GvDetails.DataSource = objList.ToList() ;
        }

        private void BtnGetBills_Click(object sender, EventArgs e)
        {
            if (DDLMonth.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Month");
                DDLMonth.Focus();
                return;
            }
            else if (DDLYear.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Year");
                DDLYear.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(DdlRakeType.Text) || DdlRakeType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Rake Type");
                DdlRakeType.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(DdlRakeNo.Text))
            {
                MessageBox.Show("Please select Rake No");
                DdlRakeNo.Focus();
                return;
            }

            BindGrid();
        }

        private void DDLMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLMonth.SelectedIndex > 0)
            {
                DDLYear.Enabled = true;
            }
            else
            {
                DDLYear.Enabled = false;
                DDLYear.SelectedIndex = 0;

                DdlRakeType.Enabled = false;
                DdlRakeNo.Enabled = false;
                return;
            }
        }

        private void DDLYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLYear.SelectedIndex > 0)
            {
                DdlRakeType.Enabled = true;
            }
            else
            {
                DdlRakeType.Enabled = false;
                DdlRakeType.Enabled = false;
                DdlRakeNo.Enabled = false;
                return;
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            string filename = "D:\\JSW\\Bills_" + DateTime.Now.Date.ToString().Substring(0, 10).Replace('/', '-') + ".xlsx";
            System.IO.FileInfo excel = new System.IO.FileInfo(filename);

            System.IO.Directory.CreateDirectory("D:\\JSW\\");

            if (excel.Exists)
            {
                excel.Delete();
            }
            using (ExcelPackage pck = new ExcelPackage(new System.IO.FileInfo("D:\\JSW\\Bills_" + DateTime.Now.Date.ToString().Substring(0, 10).Replace('/', '-') + ".xlsx")))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("JSWBills");
                ws.Cells["A1"].LoadFromDataTable(((DataTable)GvDetails.DataSource), true);
                ws.Cells.AutoFitColumns();

                // Add some styling
                using (ExcelRange rng = ws.Cells[1, 1, 1, GvDetails.Columns.Count])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                    rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                }

                pck.Save();

            }
            DialogResult ans = MessageBox.Show("File Downloaded at " + filename + Environment.NewLine + "Do you want to open?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(filename);
            }
        }
    }
}
