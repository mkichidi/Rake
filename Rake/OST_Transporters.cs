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
    public partial class OST_Transporters : Form
    {
        string EditId = string.Empty;
        DataTable backup = new DataTable();
        public OST_Transporters()
        {
            InitializeComponent();
            IncrementTranporter();
            BindGrid();
        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection( Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetTransporter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            GvTranport.DataSource = dataTable;
            backup = dataTable;
            this.GvTranport.AllowUserToAddRows = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool res = false;
            if (keyData == (Keys.Control | Keys.S))
            {
                toolStrip1.Items["tsBtnSave"].PerformClick();
                res = base.ProcessCmdKey(ref msg, keyData);
                return true;
            }
            return res;
        }

        private void OST_Transporters_Load(object sender, EventArgs e)
        {

        }

        public void IncrementTranporter()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetTransporter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtTransporterID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        private void clear()
        {
            TxtAdvance.Text = string.Empty;
            TxtBank.Text = string.Empty;
            TxtBranch.Text = string.Empty;
            TxtTransportSearch.Text = string.Empty;
            TxtTransportSearch.Text = string.Empty;
            TxtIFSC.Text = string.Empty;
            TxtOwnerName.Text = string.Empty;
            TxtPAN.Text = string.Empty;
            TxtPhoneNo.Text = string.Empty;
            TxtTransportName.Text = string.Empty;
            TxtAccountNo.Text = string.Empty;
            TxtAddress.Text = string.Empty;
            ChkOwnVehicle.Checked = false;
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtTransportName.Text))
            {
                MessageBox.Show("Please enter Transport Name");
                TxtTransportName.Focus();
                return;
            } else  if (string.IsNullOrEmpty(TxtOwnerName.Text))
                {
                    MessageBox.Show("Please enter Owner Name");
                    TxtOwnerName.Focus();
                    return;
                }
            //else if (string.IsNullOrEmpty(TxtBank.Text))
            //{
            //    MessageBox.Show("Please enter Bank Name");
            //    TxtBank.Focus();
            //    return;
            //}
            //else if (string.IsNullOrEmpty(TxtBranch.Text))
            //{
            //    MessageBox.Show("Please enter Branch Name");
            //    TxtBranch.Focus();
            //    return;
            //}
            //else if (string.IsNullOrEmpty(TxtAccountNo.Text))
            //{
            //    MessageBox.Show("Please enter Account No Name");
            //    TxtAccountNo.Focus();
            //    return;
            //}
            //else if (string.IsNullOrEmpty(TxtIFSC.Text))
            //{
            //    MessageBox.Show("Please enter IFSC No Name");
            //    TxtIFSC.Focus();
            //    return;
            //}
            //else if (string.IsNullOrEmpty(TxtPAN.Text))
            //{
            //    MessageBox.Show("Please enter PAN No Name");
            //    TxtPAN.Focus();
            //    return; 
            //}

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertTransport", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransportName", TxtTransportName.Text);
                cmd.Parameters.AddWithValue("@TransportOwnerName", TxtOwnerName.Text);
                cmd.Parameters.AddWithValue("@Bank", TxtBank.Text);
                cmd.Parameters.AddWithValue("@Branch", TxtBranch.Text);
                cmd.Parameters.AddWithValue("@AccountNo", TxtAccountNo.Text);
                cmd.Parameters.AddWithValue("@IFSC", TxtIFSC.Text);
                cmd.Parameters.AddWithValue("@PAN", TxtPAN.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", TxtPhoneNo.Text);
                cmd.Parameters.AddWithValue("@Advance", TxtAdvance.Text);
                cmd.Parameters.AddWithValue("@Address", TxtAddress.Text);

                if (ChkOwnVehicle.Checked)
                {
                    cmd.Parameters.AddWithValue("@OwnTransport", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@OwnTransport", 0);
                }


                if (ChkActive.Checked)
                {
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsActive", 0);
                }

                if (ChkTDS.Checked)
                {
                    cmd.Parameters.AddWithValue("@IsTDS", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsTDS", 0);
                }

                cmd.Parameters.AddWithValue("@CB", "");
                cmd.Parameters.AddWithValue("@CD", DateTime.Now);

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Transporter Saved Succesfully");
                    IncrementTranporter();
                    BindGrid();
                    clear();
                }
                else
                {
                    MessageBox.Show("Transporter Name already exists");
                    TxtTransportName.Focus();
                }
                con.Close();
            } 
            else if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateTransport", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransportName", TxtTransportName.Text);
                cmd.Parameters.AddWithValue("@TransportOwnerName", TxtOwnerName.Text);
                cmd.Parameters.AddWithValue("@Bank", TxtBank.Text);
                cmd.Parameters.AddWithValue("@Branch", TxtBranch.Text);
                cmd.Parameters.AddWithValue("@AccountNo", TxtAccountNo.Text);
                cmd.Parameters.AddWithValue("@IFSC", TxtIFSC.Text);
                cmd.Parameters.AddWithValue("@PAN", TxtPAN.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", TxtPhoneNo.Text);
                cmd.Parameters.AddWithValue("@Advance", TxtAdvance.Text);
                cmd.Parameters.AddWithValue("@TransportersId", TxtTransporterID.Text);
                cmd.Parameters.AddWithValue("@Address", TxtAddress.Text);

                if (ChkOwnVehicle.Checked)
                {
                    cmd.Parameters.AddWithValue("@OwnTransport", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@OwnTransport", 0);
                }
                if (ChkActive.Checked)
                {
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsActive", 0);
                }

                if (ChkTDS.Checked)
                {
                    cmd.Parameters.AddWithValue("@IsTDS", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsTDS", 0);
                }
                cmd.Parameters.AddWithValue("@CB", "");
                cmd.Parameters.AddWithValue("@CD", DateTime.Now);
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Transport Edited Succesfully");
                    IncrementTranporter();
                    BindGrid();
                    clear();
                    EditId = string.Empty;
                }
                else
                {
                    MessageBox.Show("Transport Name already exists");
                }
                con.Close();
            }

        }

        private void GvTranport_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GvTranport.SelectedRows)
            {
                EditId = row.Cells[0].Value.ToString();
            }
        }

        private void TxtTransportSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtTransportSearch.Text))
            {
                GvTranport.DataSource = backup.Select("[TransportName] Like '%" + TxtTransportSearch.Text + "%'").Any() ? backup.Select("[TransportName] Like '%" + TxtTransportSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvTranport.DataSource = backup;
            }
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetTransporterOnId", con);
                cmd.Parameters.AddWithValue("@TransportersId", EditId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                con.Close();
                if (dataTable.Rows.Count > 0)
                {
                    TxtTransporterID.Text = Convert.ToString(dataTable.Rows[0]["TransportersId"]);
                    TxtTransportName.Text = Convert.ToString(dataTable.Rows[0]["TransportName"]);
                    TxtOwnerName.Text = Convert.ToString(dataTable.Rows[0]["OwnerName"]);
                    TxtBank.Text = Convert.ToString(dataTable.Rows[0]["Bank"]);
                    TxtBranch.Text = Convert.ToString(dataTable.Rows[0]["Branch"]);
                    TxtAccountNo.Text = Convert.ToString(dataTable.Rows[0]["AccountNo"]);
                    TxtIFSC.Text = Convert.ToString(dataTable.Rows[0]["IFSC"]);
                    TxtPAN.Text = Convert.ToString(dataTable.Rows[0]["PAN"]);
                    TxtPhoneNo.Text = Convert.ToString(dataTable.Rows[0]["PhoneNo"]);
                    TxtAdvance.Text = Convert.ToString(dataTable.Rows[0]["Advance"]);
                    TxtAddress.Text = Convert.ToString(dataTable.Rows[0]["Address"]);
                    if (Convert.ToBoolean(dataTable.Rows[0]["IsActive"]) == true)
                    {
                        ChkActive.Checked = true;
                    }
                    else
                    {
                        ChkActive.Checked = false;
                    }

                    if (Convert.ToBoolean(dataTable.Rows[0]["Own"]) == true)
                    {
                        ChkOwnVehicle.Checked = true;
                    }
                    else
                    {
                        ChkOwnVehicle.Checked = false;
                    }

                    if (Convert.ToBoolean(dataTable.Rows[0]["IsTDS"]) == true)
                    {
                        ChkTDS.Checked = true;
                    }
                    else
                    {
                        ChkTDS.Checked = false;
                    }

                }
            }
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        
    }
}
