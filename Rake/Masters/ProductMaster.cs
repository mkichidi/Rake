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
    public partial class ProductMaster : Form
    {
        string EditId = string.Empty;
        DataTable backup = new DataTable();
        public ProductMaster()
        {
            InitializeComponent();
            IncrementProduct();
            BindGrid();
        }

        public void IncrementProduct()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxProductIDRake", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtProductID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtProductName.Text))
            {
                MessageBox.Show("Please enter Product Name");
                TxtProductName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertProductRake", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", TxtProductName.Text);
                cmd.Parameters.AddWithValue("@ProductDescription", TxtDescription.Text);
                
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
                    MessageBox.Show("Product Saved Succesfully");
                    IncrementProduct();
                    BindGrid();
                    clear();
                }
                else
                {
                    MessageBox.Show("Product already exists");
                }
                con.Close();
            }
            else if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateProductRAke", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", TxtProductID.Text);
                cmd.Parameters.AddWithValue("@ProductName", TxtProductName.Text);
                cmd.Parameters.AddWithValue("@ProductDescription", TxtDescription.Text);

                if (ChkActive.Checked)
                {
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsActive", 0);
                }
                cmd.Parameters.AddWithValue("@UB", "");
                cmd.Parameters.AddWithValue("@UD", "");
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Product Edited Succesfully");
                    IncrementProduct();
                    BindGrid();
                    clear();
                    EditId = string.Empty;
                }
                else
                {
                    MessageBox.Show("Product already exists");
                }
                con.Close();
            }

        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetProductRake", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            GvProduct.DataSource = dataTable;
            backup = dataTable;
            this.GvProduct.AllowUserToAddRows = false;
        }

        private void clear()
        {
            TxtDescription.Text = string.Empty;
            TxtProductName.Text = string.Empty;
        } 

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetProductOnIdRake", con);
                cmd.Parameters.AddWithValue("@ProductID", EditId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                con.Close();
                if (dataTable.Rows.Count > 0)
                {
                    TxtProductID.Text = Convert.ToString(dataTable.Rows[0]["ProductID"]);
                    TxtProductName.Text = Convert.ToString(dataTable.Rows[0]["ProductName"]);
                    TxtDescription.Text = Convert.ToString(dataTable.Rows[0]["ProductDescription"]);
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

        private void GvProduct_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GvProduct.SelectedRows)
            {
                EditId = row.Cells[0].Value.ToString();
            }
        }

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            clear();
            IncrementProduct();
            EditId = string.Empty;
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void TxtProductSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtProductSearch.Text))
            {
                GvProduct.DataSource = backup.Select("[Product Name] Like '%" + TxtProductSearch.Text + "%'").Any() ? backup.Select("[Product Name] Like '%" + TxtProductSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvProduct.DataSource = backup;
            }
        }
    }
}
