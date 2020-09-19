using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace Rake
{
    public partial class GenerateGC : Form
    {

        List<string> types = new List<string>();

        public GenerateGC()
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
            SqlCommand cmd = new SqlCommand("GetRakeTypeRakeGCDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            DataRow row = dataTable.NewRow();
            row["RakeTypeName"] = "-Select-";
            //row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);

            DdlRakeType.DataSource = new DataView(dataTable);
            DdlRakeType.DisplayMember = "RakeTypeName";
            DdlRakeType.SelectedIndex = 0;
            DdlRakeType.ValueMember = "RakeTypeID";

            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("GetPartyRake", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            reader = cmd.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            
            DdlCustomer.Properties.DataSource = dataTable;
            DdlCustomer.Properties.DisplayMember = "Party Name";
            DdlCustomer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            DdlCustomer.Properties.IncrementalSearch = true;
            DdlCustomer.KeyDown += new KeyEventHandler(checkedComboBoxEdit1_KeyDown);
        }

        void checkedComboBoxEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((DevExpress.XtraEditors.CheckedComboBoxEdit)sender).IsPopupOpen)
                ((DevExpress.XtraEditors.CheckedComboBoxEdit)sender).ShowPopup();
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

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeGcGenerate", con);
            cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", DDLYear.Text);
            cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
            cmd.Parameters.AddWithValue("@RakeNo", DdlRakeNo.Text);
            cmd.Parameters.AddWithValue("@Customer", DdlCustomer.Text.Replace(", ", ","));

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            GvRakeBill.DataSource = dataTable;
            this.GvRakeBill.AllowUserToAddRows = false;
        }

        private void CtrlBtnPrintBill_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt =(DataTable) GvRakeBill.DataSource;
            dt.AcceptChanges();


            DataGridViewColumn oldColumn = GvRakeBill.SortedColumn;

            if (oldColumn != null)
            {
                string sortOrder = string.Empty;
                if (oldColumn.HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Ascending)
                {
                    sortOrder = " Asc";
                }
                else
                {
                    sortOrder = " Desc";
                }
                DataView dv = dt.DefaultView;
                dv.Sort = oldColumn.HeaderText + sortOrder;
                dt = dv.ToTable();
            }

            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("No data to print Gc");
                return;
            }

            int dec = 0;
            if (string.IsNullOrEmpty(TxtGcNo.Text))
            {
                MessageBox.Show("Please enter Gc No");
                TxtGcNo.Focus();
                return;
            }
            else if (!int.TryParse(TxtGcNo.Text,out dec))
            {
                MessageBox.Show("Please enter correct Gc No");
                TxtGcNo.Focus();
                return;
            }
            RakeDatatable.GcPath = "D:\\Rake\\GCGenerated\\" + DateTime.Now.ToString("dd/MMM/yy_hh_mm") + ".pdf";

            if (ChkDriverCopy.Checked)
            {
                types.Add(ChkDriverCopy.Text);
            }

            if (ChkCustomerCopy.Checked)
            {
                types.Add(ChkCustomerCopy.Text);
            }

            if (ChkOfficeCopy.Checked)
            {
                types.Add(ChkOfficeCopy.Text);
            }

            if (ChkExtraCopy.Checked)
            {
                types.Add(ChkExtraCopy.Text);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                RakeDatatable.dt = dt.Clone();
                RakeDatatable.dt.Rows.Add( dt.Rows[i].ItemArray);

                RakeDatatable.dt.Columns.Add("GCNo", typeof(System.Int32));
                RakeDatatable.dt.Rows[0]["GCNo"] = i + Convert.ToInt32( TxtGcNo.Text);

                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateGCNoAfterGCGenerate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ShipMentID", RakeDatatable.dt.Rows[0]["RakeShipmentID"]);
                cmd.Parameters.AddWithValue("@GcNo", RakeDatatable.dt.Rows[0]["GCNo"]);
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    RakeDatatable.type = string.Empty;
                    foreach (string type in types)
                    {
                        RakeDatatable.type = type;
                        Rake.Reports.Reports.GenerateGC GenerateGC = new Rake.Reports.Reports.GenerateGC();
                        GenerateGC.Show();
                    }
                    RakeDatatable.type = string.Empty;
                    RakeDatatable.dt = new DataTable();
                }
                else
                {
                    MessageBox.Show("GC Not updated. Please try again.");
                }
                con.Close();

                
            }

            types.Clear();
            DialogResult ans = MessageBox.Show("File Downloaded at " + RakeDatatable.GcPath + Environment.NewLine + "Do you want to open?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(RakeDatatable.GcPath);
            }
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
            SqlCommand cmd = new SqlCommand("GetRakeNoGCData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", DDLYear.Text);
            cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            DdlRakeNo.DataSource = null;
            DdlRakeNo.DataSource = new DataView(dataTable);
            DdlRakeNo.DisplayMember = "Rakeno";
        }
    }
}
