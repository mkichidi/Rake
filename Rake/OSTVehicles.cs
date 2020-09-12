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
using System.Data;

namespace Rake
{
    public partial class OSTVehicles : Form
    {
        DataTable DtBackGot = new DataTable();
        DataTable DtBackAll = new DataTable();
        public OSTVehicles()
        {
            InitializeComponent();
            BindDropdowns();
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
        public void BindDropdowns()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetTransporter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();

            DataRow row = (ds.Tables[0]).NewRow();
            row["TransportName"] = "-Select-";
            ds.Tables[0].Rows.InsertAt(row, 0);
            DdlTransport.DataSource = new DataView(ds.Tables[0]);
            DdlTransport.DisplayMember = "TransportName";
            DdlTransport.ValueMember = "TransportersId";
            DdlTransport.SelectedIndex = 0;
        }

        private void DdlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlTransport.SelectedIndex > 0)
            {

            
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetVehicleOnTransporter", con);   
            cmd.Parameters.AddWithValue("@TransportersId", DdlTransport.SelectedValue);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();

            GvAdd.DataSource = ds.Tables[1];
            GvGot.DataSource = ds.Tables[0];

            DtBackGot = ds.Tables[0];
               DtBackAll= ds.Tables[1];
            }
            else
            {
                GvAdd.DataSource =null;
                GvGot.DataSource =null;
            }
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            TxtVehicleSearchGot.Text = string.Empty;
            DataTable dt = (DataTable)GvGot.DataSource;
            if (GvGot.Rows.Count > 0)
            {

                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("DeleteVehicleFromTransporter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransportersId", DdlTransport.SelectedValue);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                dt.AcceptChanges();
                foreach (DataRow dr in dt.Rows)
                {
                   

                     con = new SqlConnection(Connection.InvAdminConn());
                     cmd = new SqlCommand("AddVehicleToTransporter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransportersId", DdlTransport.SelectedValue);
                    cmd.Parameters.AddWithValue("@vehicleNo", dr["vehicleNo"]);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Vehicles addded successfully");
            }
            else
            {
                MessageBox.Show("Please select Vehicles to save");
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)GvGot.DataSource;
            foreach (DataGridViewRow dr in GvAdd.SelectedRows)
            {
                if (dt != null && dt.Rows.Count>0)
                {
                    int check = 0;
                    foreach (DataGridViewRow drr in GvGot.Rows)
                    {
                        if (drr.Cells[0].Value == dr.Cells[0].Value)
                        {
                            check=1;
                        }
                        
                    }
                    if (check == 0)
                    {
                    DataRow drNew = ((DataTable)GvAdd.DataSource).NewRow();
                    drNew["vehicleno"] = dr.Cells[0].Value;
                    dt.Rows.Add(drNew.ItemArray);
                    }
                }
                else
                {
                    dt = ((DataTable)GvAdd.DataSource).Clone();
                    DataRow drNew = ((DataTable)GvAdd.DataSource).NewRow();
                    drNew["vehicleno"] = dr.Cells[0].Value;
                    dt.Rows.Add(drNew.ItemArray);
                }
            }
            GvGot.DataSource = null;
            GvGot.DataSource = dt;
        }

        private void Sub_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)GvGot.DataSource;
            foreach (DataGridViewRow dr in GvGot.SelectedRows)
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                        //DataRow drNew = ((DataTable)GvAdd.DataSource).NewRow();
                        //drNew["vehicleno"] = dr.Cells[0].Value;
                        //dt.Rows.Remove(drNew);
                    GvGot.Rows.Remove(dr);
                }
            }
            GvGot.DataSource = null;
            GvGot.DataSource = dt;
        }

        private void TxtVehicleSearchGot_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtVehicleSearchGot.Text))
            {
                GvGot.DataSource = DtBackGot.Select("VehicleNo Like '%" + TxtVehicleSearchGot.Text + "%'").Any() ? DtBackGot.Select("VehicleNo Like '%" + TxtVehicleSearchGot.Text + "%'").CopyToDataTable() : DtBackGot.Clone();
            }
            else
            {
                GvGot.DataSource = DtBackGot;
            }
        }

        private void TxtVehicleSearchAll_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtVehicleSearchAll.Text))
            {
                GvAdd.DataSource = DtBackAll.Select("VehicleNo Like '%" + TxtVehicleSearchAll.Text + "%'").Any() ? DtBackAll.Select("VehicleNo Like '%" + TxtVehicleSearchAll.Text + "%'").CopyToDataTable() : DtBackAll.Clone();
            }
            else
            {
                GvAdd.DataSource = DtBackAll;
            }
        }

        private void TxtVehicleSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtVehicleSearch.Text))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetTransporterOnVehicle", con);
                cmd.Parameters.AddWithValue("@VehicleNo", '%'+TxtVehicleSearch.Text+'%');
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                con.Close();

                GvTransport.DataSource = ds.Tables[0];
            }
            else
            {
                GvTransport.DataSource = null;
            }
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
