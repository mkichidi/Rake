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
    public partial class WorkOrder : Form
    {
        string EditId = string.Empty;
        DataTable backup = new DataTable();
        public WorkOrder()
        {
            InitializeComponent();
            IncrementDestination();
            BindGrid();
        }

        public void IncrementDestination()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxRakeWorkOrderID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtJSWWorkOrderID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtJSWWorkOrderNo.Text))
            {
                MessageBox.Show("Please enter WF Work Order No Name");
                TxtJSWWorkOrderNo.Focus(); 
                return;
            }
            else if (string.IsNullOrEmpty(TxtHSWorkOrder.Text))
            {
                MessageBox.Show("Please enter HS Work Order No Name");
                TxtHSWorkOrder.Focus();
                return;
            }

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertRakeWorkOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderNo", TxtJSWWorkOrderNo.Text);
                cmd.Parameters.AddWithValue("@HosurOrderNo", TxtHSWorkOrder.Text);
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@From", DtFrom.Value.Date);
                cmd.Parameters.AddWithValue("@To", DtTo.Value.Date);
                
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Work order Saved Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                }
                else
                {
                    MessageBox.Show("Work order already exists");
                }
                con.Close();
            }
            else if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateRakeWorkOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@JSWWorkOrderID", EditId);
                cmd.Parameters.AddWithValue("@HosurOrderNo", TxtHSWorkOrder.Text);
                cmd.Parameters.AddWithValue("@OrderNo", TxtJSWWorkOrderNo.Text);
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@From", DtFrom.Value.Date);
                cmd.Parameters.AddWithValue("@To", DtTo.Value.Date);
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Work order Edited Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                    EditId = string.Empty;
                }
                else
                {
                    MessageBox.Show("Work order already exists");
                }
                con.Close();
            }

        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeWorkOrder", con);
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

        private void clear()
        {
            TxtDescription.Text = string.Empty;
            TxtJSWWorkOrderNo.Text = string.Empty;
            TxtHSWorkOrder.Text = string.Empty;
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetRakeWorkOrderOnId", con);
                cmd.Parameters.AddWithValue("@JSWWorkOrderID", EditId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                con.Close();
                if (dataTable.Rows.Count > 0)
                {
                    TxtJSWWorkOrderID.Text = Convert.ToString(dataTable.Rows[0]["JSWWorkOrderID"]);
                    TxtJSWWorkOrderNo.Text = Convert.ToString(dataTable.Rows[0]["OrderNo"]);
                    TxtHSWorkOrder.Text = Convert.ToString(dataTable.Rows[0]["HosurOrderNo"]);
                    TxtDescription.Text = Convert.ToString(dataTable.Rows[0]["Description"]);
                    DtFrom.Value = Convert.ToDateTime(dataTable.Rows[0]["From"]);
                    DtTo.Value = Convert.ToDateTime(dataTable.Rows[0]["To"]);
                }
            }
        }

        private void GvDestination_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GvDestination.SelectedRows)
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
            if (!string.IsNullOrEmpty(TxtWorkOrderSearch.Text))
            {
                GvDestination.DataSource = backup.Select("[OrderNo] Like '%" + TxtWorkOrderSearch.Text + "%'").Any() ? backup.Select("[OrderNo] Like '%" + TxtWorkOrderSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvDestination.DataSource = backup;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
