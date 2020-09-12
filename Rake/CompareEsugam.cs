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

namespace Rake
{
    public partial class CompareEsugam : Form
    {
        public CompareEsugam()
        {
            InitializeComponent();

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("0", "-All-");
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
            row["RakeTypeName"] = "-All-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);

            DdlRakeType.DataSource = new DataView(dataTable);
            DdlRakeType.DisplayMember = "RakeTypeName";
            DdlRakeType.SelectedIndex = 0;
            DdlRakeType.ValueMember = "RakeTypeID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DDLMonth.SelectedIndex < 0)
            {
                MessageBox.Show("Please select Month");
                DDLMonth.Focus();
                return;
            }
            else if (DDLYear.SelectedIndex < 0)
            {
                MessageBox.Show("Please select Year");
                DDLYear.Focus();
                return;
            }
            else if (DdlRakeType.SelectedIndex < 0)
            {
                MessageBox.Show("Please select Rake Type");
                DdlRakeType.Focus();
                return;
            }
            BindGrid();
        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeBillDifference", con);
            if (DDLMonth.SelectedIndex > 0)
            {
                cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            }

            if (DDLYear.SelectedIndex > 0)
            {
                cmd.Parameters.AddWithValue("@Year", DDLYear.Text);
            }

            if (DdlRakeType.SelectedIndex > 0)
            {
                cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);

                if (DdlRakeNo.SelectedIndex >= 0)
                {
                    cmd.Parameters.AddWithValue("@RakeNo", DdlRakeType.SelectedValue);
                }

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
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            DdlRakeNo.DataSource = new DataView(dataTable);
            DdlRakeNo.DisplayMember = "Rakeno";
        }

    }
}
