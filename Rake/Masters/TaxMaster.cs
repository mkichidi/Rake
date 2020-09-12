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
    public partial class TaxMaster : Form
    {
        string EditId = string.Empty;
        DataTable backup = new DataTable();
        public TaxMaster ()
        {
            InitializeComponent();
            IncrementDestination();
            BindGrid();
        }

        public void IncrementDestination()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxRakeTaxID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtTaxID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            decimal b = 0M;
            if (string.IsNullOrEmpty(TxtName.Text))
            {
                MessageBox.Show("Please enter Tax Name");
                TxtName.Focus();
                return;
            } else
            if (string.IsNullOrEmpty(TxtTaxRate.Text))
            {
                MessageBox.Show("Please enter Tax Rate");
                TxtTaxRate.Focus();
                return;
            }
            else if (!decimal.TryParse(TxtTaxRate.Text, out b))
            {
                MessageBox.Show("Please enter Correct Tax Rate");
                TxtTaxRate.Focus();
                return;
            }

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertRakeTax", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RakeTaxName", TxtName.Text);
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@RakeTax", TxtTaxRate.Text);
                cmd.Parameters.AddWithValue("@EffectiveDate", DtEffectiveDate.Value.Date);
                cmd.Parameters.AddWithValue("@CB", "");
                cmd.Parameters.AddWithValue("@CD", DateTime.Now);
                
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Tax Saved Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                }
                else
                {
                    MessageBox.Show("Tax Name already exists for this date");
                }
                con.Close();
            }
            else if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateRakeTax", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RakeTaxName", TxtName.Text);
                cmd.Parameters.AddWithValue("@RakeTaxId", TxtTaxID.Text);
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@RakeTax", TxtTaxRate.Text);
                cmd.Parameters.AddWithValue("@EffectiveDate", DtEffectiveDate.Value.Date);
                cmd.Parameters.AddWithValue("@CB", "");
                cmd.Parameters.AddWithValue("@CD", DateTime.Now);
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Tax Edited Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                    EditId = string.Empty;
                }
                else
                {
                    MessageBox.Show("Tax already exists");
                }
                con.Close();
            }

        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeTax", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            GvTax.DataSource = dataTable;
            backup = dataTable;
            this.GvTax.AllowUserToAddRows = false;
        }

        private void clear()
        {
            TxtDescription.Text = string.Empty;
            TxtTaxRate.Text = string.Empty;
            TxtName.Text = string.Empty;
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
                if (!string.IsNullOrEmpty(EditId))
                {
                    SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                    SqlCommand cmd = new SqlCommand("GetRakeTaxOnIdRake", con);
                    cmd.Parameters.AddWithValue("@RakeTaxId", EditId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    con.Close();
                    if (dataTable.Rows.Count > 0)
                    {
                        TxtTaxID.Text = Convert.ToString(dataTable.Rows[0]["RakeTaxId"]);
                        TxtTaxRate.Text = Convert.ToString(dataTable.Rows[0]["RakeTax"]);
                        TxtName.Text = Convert.ToString(dataTable.Rows[0]["RakeTaxName"]);
                        TxtDescription.Text = Convert.ToString(dataTable.Rows[0]["Description"]);
                        DtEffectiveDate.Value = Convert.ToDateTime(dataTable.Rows[0]["EffectiveDate"]);
                    }
                }
        }

        private void GvDestination_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GvTax.SelectedRows)
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
            if (!string.IsNullOrEmpty(TxtDestinationSearch.Text))
            {
                GvTax.DataSource = backup.Select("[RakeTaxName] Like '%" + TxtDestinationSearch.Text + "%'").Any() ? backup.Select("[RakeTaxName] Like '%" + TxtDestinationSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvTax.DataSource = backup;
            }
        }
    }
}
