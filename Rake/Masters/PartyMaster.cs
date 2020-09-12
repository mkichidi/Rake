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
    public partial class PartyMaster : Form
    {
        string EditId = string.Empty;
        DataTable backup = new DataTable();
        public PartyMaster()
        {
            InitializeComponent();
            IncrementParty();
            BindGrid();
        }

        public void IncrementParty()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxPartyIDRake", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtPartyID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
           if (string.IsNullOrEmpty(TxtPartyName.Text))
            {
                MessageBox.Show("Please enter Party Name");
                TxtPartyName.Focus();
                return;
            }
            

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertPartyRAke", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PartyName", TxtPartyName.Text);
                cmd.Parameters.AddWithValue("@PartyPhoneNumber",TxtPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@PartyDescription", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@PartyAddress", TxtAddress.Text);
                cmd.Parameters.AddWithValue("@CB", "");
                cmd.Parameters.AddWithValue("@CD", DateTime.Now);
                cmd.Parameters.AddWithValue("@FactoryAddress", TxtFactoryAddress.Text);
                cmd.Parameters.AddWithValue("@FactoryPhoneNo", TxtFactoryPhoneNo.Text);
                cmd.Parameters.AddWithValue("@Tin", TxtTin.Text);
                cmd.Parameters.AddWithValue("@CST", TxtCst.Text);
                cmd.Parameters.AddWithValue("@ContactPerson", TxtContactPerson.Text);
                cmd.Parameters.AddWithValue("@GCName", TxtGCName.Text);


                if (ChkActive.Checked)
                {
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsActive", 0);
                }

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Party Saved Succesfully");
                    IncrementParty();
                    BindGrid();
                    clear();
                }
                else
                {
                    MessageBox.Show("Party already exists");
                }
                con.Close();
            }
            else if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdatePartyRAke", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PartyID", TxtPartyID.Text);
                cmd.Parameters.AddWithValue("@PartyName", TxtPartyName.Text);
                cmd.Parameters.AddWithValue("@PartyPhoneNumber", TxtPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@PartyDescription", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@PartyAddress", TxtAddress.Text);
                cmd.Parameters.AddWithValue("@UB", "");
                cmd.Parameters.AddWithValue("@UD", "");
                cmd.Parameters.AddWithValue("@FactoryAddress", TxtFactoryAddress.Text);
                cmd.Parameters.AddWithValue("@FactoryPhoneNo", TxtFactoryPhoneNo.Text);
                cmd.Parameters.AddWithValue("@CST", TxtCst.Text);
                cmd.Parameters.AddWithValue("@Tin", TxtTin.Text);
                cmd.Parameters.AddWithValue("@ContactPerson", TxtContactPerson.Text);
                cmd.Parameters.AddWithValue("@GCName", TxtGCName.Text);
                
                if (ChkActive.Checked)
                {
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsActive", 0);
                }

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Party Edited Succesfully");
                    IncrementParty();
                    BindGrid();
                    clear();
                    EditId = string.Empty;
                }
                else
                {
                    MessageBox.Show("Party already exists");
                }
                con.Close();
            }

        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetPartyRake", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            GvParty.DataSource = dataTable;
            backup = dataTable;
            this.GvParty.AllowUserToAddRows = false;
        }

        private void clear()
        {
            TxtAddress.Text = string.Empty;
            TxtDescription.Text = string.Empty;
            TxtPartyName.Text = string.Empty;
            TxtPhoneNumber.Text = string.Empty;
            TxtFactoryPhoneNo.Text = string.Empty;
            TxtFactoryAddress.Text = string.Empty;
            TxtTin.Text = string.Empty;
            TxtCst.Text = string.Empty;
            TxtContactPerson.Text = string.Empty;
            TxtGCName.Text = string.Empty;
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetPartyOnIdRake", con);
                cmd.Parameters.AddWithValue("@PartyID", EditId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                con.Close();
                if (dataTable.Rows.Count > 0)
                {
                    TxtPartyID.Text = Convert.ToString(dataTable.Rows[0]["PartyID"]);
                    TxtPhoneNumber.Text = Convert.ToString(dataTable.Rows[0]["PartyPhoneNo"]);
                    TxtPartyName.Text = Convert.ToString(dataTable.Rows[0]["PartyName"]);
                    TxtDescription.Text = Convert.ToString(dataTable.Rows[0]["PartyDescription"]);
                    TxtAddress.Text = Convert.ToString(dataTable.Rows[0]["PartyAddress"]);
                    TxtFactoryAddress.Text = Convert.ToString(dataTable.Rows[0]["FactoryAddress"]);
                    TxtFactoryPhoneNo.Text = Convert.ToString(dataTable.Rows[0]["FactoryPhoneNo"]);
                    TxtTin.Text = Convert.ToString(dataTable.Rows[0]["Tin"]);
                    TxtCst.Text = Convert.ToString(dataTable.Rows[0]["CST"]);
                    TxtContactPerson.Text = Convert.ToString(dataTable.Rows[0]["ContactPerson"]);
                    TxtGCName.Text = Convert.ToString(dataTable.Rows[0]["GCName"]);

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

        private void GvParty_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GvParty.SelectedRows)
            {
                EditId = row.Cells[0].Value.ToString();
            }
        }

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            clear();
            IncrementParty();
            EditId = string.Empty;
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void TxtPartySearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtPartySearch.Text))
            {
                GvParty.DataSource = backup.Select("[Party Name] Like '%" + TxtPartySearch.Text + "%'").Any() ? backup.Select("[Party Name] Like '%" + TxtPartySearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvParty.DataSource = backup;
            }
        }
    }
}
