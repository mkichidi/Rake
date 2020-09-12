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
    public partial class RailHandling : Form
    {
        string EditId = string.Empty;
        DataTable backup = new DataTable();
        public RailHandling()
        {
            InitializeComponent();
            IncrementDestination();
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeFrom", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
          DataRow  row = dataTable.NewRow();
            row["From"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);

            DdlFrom.DataSource = new DataView(dataTable);
            DdlFrom.DisplayMember = "From";
            DdlFrom.SelectedIndex = 0;
            DdlFrom.ValueMember = "ID";
            BindGrid();
        }

        public void IncrementDestination()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxRakeHandling", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtRakeHandlingID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            decimal b = 0M;
            //if (string.IsNullOrEmpty(TxtName.Text))
            //{
            //    MessageBox.Show("Please enter Tax Name");
            //    TxtName.Focus();
            //    return;
            //} else
            if (string.IsNullOrEmpty(TxtRakeHandling.Text))
            {
                MessageBox.Show("Please enter Rake Handling Charges");
                TxtRakeHandling.Focus();
                return;
            }
            else if (!decimal.TryParse(TxtRakeHandling.Text, out b))
            {
                MessageBox.Show("Please enter Correct Rake Handling Charges");
                TxtRakeHandling.Focus();
                return;
            }
            else if (DdlFrom.SelectedIndex<1)
            {
                MessageBox.Show("Please select From");
                DdlFrom.Focus();
                return;
            }


            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertRakeHandling", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@RakeHandling", TxtRakeHandling.Text);
                cmd.Parameters.AddWithValue("@EffectiveDate", DtEffectiveDate.Value.Date);
                cmd.Parameters.AddWithValue("@CB", "");
                cmd.Parameters.AddWithValue("@CD", DateTime.Now);
                cmd.Parameters.AddWithValue("@From", DdlFrom.SelectedValue);
                
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Rake Handling Charges Saved Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                }
                else
                {
                    MessageBox.Show("Rake Handling Charges already exists for this date");
                }
                con.Close();
            }
            else if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateRakeHandling", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RakeHandlingId", TxtRakeHandlingID.Text);
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@RakeHandling", TxtRakeHandling.Text);
                cmd.Parameters.AddWithValue("@EffectiveDate", DtEffectiveDate.Value.Date);
                cmd.Parameters.AddWithValue("@CB", "");
                cmd.Parameters.AddWithValue("@From", DdlFrom.SelectedValue);
                cmd.Parameters.AddWithValue("@CD", DateTime.Now);
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Rake Handling Charges Edited Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                    EditId = string.Empty;
                }
                else
                {
                    MessageBox.Show("Rake Handling Charges already exists");
                }
                con.Close();
            }

        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeHandling", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            GvRailHandling.DataSource = dataTable;
            backup = dataTable;
            this.GvRailHandling.AllowUserToAddRows = false;
        }

        private void clear()
        {
            TxtDescription.Text = string.Empty;
            TxtRakeHandling.Text = string.Empty;
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
                if (!string.IsNullOrEmpty(EditId))
                {
                    SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                    SqlCommand cmd = new SqlCommand("GetRakeHandlingOnIdRake", con);
                    cmd.Parameters.AddWithValue("@RakeHandlingId", EditId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    if (dataTable.Rows.Count > 0)
                    {
                        TxtRakeHandlingID.Text = Convert.ToString(dataTable.Rows[0]["RakeHandlingId"]);
                        TxtRakeHandling.Text = Convert.ToString(dataTable.Rows[0]["RakeHandling"]);
                        TxtDescription.Text = Convert.ToString(dataTable.Rows[0]["Description"]);
                        DtEffectiveDate.Value = Convert.ToDateTime(dataTable.Rows[0]["EffectiveDate"]);
                        DdlFrom.SelectedValue = Convert.ToInt32(dataTable.Rows[0]["FromiD"]);
                    }
                    con.Close();
                }
        }

        private void GvDestination_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GvRailHandling.SelectedRows)
            {
                EditId = row.Cells[0].Value.ToString();
            }
        }

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            clear();
            IncrementDestination();
            EditId = string.Empty;
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtDestinationSearch_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(TxtDestinationSearch.Text))
            //{
            //    GvRailHandling.DataSource = backup.Select("[RakeHandlingName] Like '%" + TxtDestinationSearch.Text + "%'").Any() ? backup.Select("[RakeHandlingName] Like '%" + TxtDestinationSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            //}
            //else
            //{
            //    GvRailHandling.DataSource = backup;
            //}
        }
    }
}
