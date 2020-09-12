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
namespace Rake.Masters
{
    public partial class UnLoad : Form
    {
        string EditId = string.Empty;
        DataTable backup = new DataTable();
        public UnLoad()
        {
            InitializeComponent();
            IncrementDestination();
            BindGrid();
        }

        public void IncrementDestination()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxUnLoadId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtUnLoadID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }


        private void clear()
        {
            TxtDescription.Text = string.Empty;
            TxtUnLoadName.Text = string.Empty;
            TxtAddress.Text = string.Empty;
            TxtPhoneNumber.Text = string.Empty;
        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetUnLoad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            GvDestination.DataSource = dataTable;
            backup = dataTable;
            this.GvDestination.AllowUserToAddRows = false;

        }
        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtUnLoadName.Text))
            {
                MessageBox.Show("Please enter Rake Type Name Name");
                TxtUnLoadName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertUnLoad", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UnLoadName", TxtUnLoadName.Text);
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@Address", TxtAddress.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", TxtPhoneNumber.Text);

                if (ChkActive.Checked)
                {
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsActive", 0);
                }
                cmd.Parameters.AddWithValue("@CB", "");
                cmd.Parameters.AddWithValue("@CD", DateTime.Now);

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Destination Saved Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                }
                else
                {
                    MessageBox.Show("Destination Name already exists");
                }
                con.Close();
            }
            else if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateUnLoad", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UnLoadID", TxtUnLoadID.Text);
                cmd.Parameters.AddWithValue("@UnLoadName", TxtUnLoadName.Text);
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@Address", TxtAddress.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", TxtPhoneNumber.Text);
                if (ChkActive.Checked)
                {
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsActive", 0);
                }
                cmd.Parameters.AddWithValue("@CB", "");
                cmd.Parameters.AddWithValue("@CD", "");
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Destination Edited Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                    EditId = string.Empty;
                }
                else
                {
                    MessageBox.Show("Destination already exists");
                }
                con.Close();
            }
        }

        private void GvDestination_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GvDestination.SelectedRows)
            {
                EditId = row.Cells[0].Value.ToString();
            }
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("[GetUnLoadIDOnID]", con);
                cmd.Parameters.AddWithValue("@UnLoadID", EditId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                con.Close();
                if (dataTable.Rows.Count > 0)
                {
                    TxtUnLoadID.Text = Convert.ToString(dataTable.Rows[0]["UnLoadID"]);
                    TxtUnLoadName.Text = Convert.ToString(dataTable.Rows[0]["UnLoadName"]);
                    TxtDescription.Text = Convert.ToString(dataTable.Rows[0]["Description"]);
                    TxtPhoneNumber.Text = Convert.ToString(dataTable.Rows[0]["PhoneNo"]);
                    TxtAddress.Text = Convert.ToString(dataTable.Rows[0]["Address"]);
                    if (Convert.ToBoolean(dataTable.Rows[0]["IsActive"]) == true)
                    {
                        ChkActive.Checked = true;
                    }
                    else
                    {
                        ChkActive.Checked = false;
                    }

                }
            }
        }

        private void TxtUnLoadSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtUnLoadSearch.Text))
            {
                GvDestination.DataSource = backup.Select("UnLoadName Like '%" + TxtUnLoadSearch.Text + "%'").Any() ? backup.Select("UnLoadName Like '%" + TxtUnLoadSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvDestination.DataSource = backup;
            }
        }
    }
}
