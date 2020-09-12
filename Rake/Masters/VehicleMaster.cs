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
using System.Text.RegularExpressions;

namespace Rake
{
    public partial class VehicleMaster : Form
    {
        string[] files;
        string EditId = string.Empty;
        DataTable backup = new DataTable();
        public VehicleMaster()
        {
            InitializeComponent();
            IncrementVehicle();
            BindGrid();
            VehicleColumn();
            GrpVehicle.Enabled = false;
            TxtMake.Format = DateTimePickerFormat.Custom;
            TxtMake.CustomFormat = "yyyy";
            TxtMake.ShowUpDown = true;
            TxtMake.Height=24;
        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetVehicle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            GvVehicals.DataSource = dataTable;
            backup = dataTable;
            this.GvVehicals.AllowUserToAddRows = false;
        }

        private void VehicleColumn()
        {
            try
            {
                GvVehicals.Columns["VehicleID"].HeaderText = "Vehicle ID";
                GvVehicals.Columns["VehicleNo"].HeaderText = "Vehicle No";


                //GvVehicals.Columns["VehicleMake"].HeaderText = "Vehicle Make";

                //GvVehicals.Columns["VehicleOwn"].HeaderText = "Own Vehicle";

                //GvVehicals.Columns["IsActive"].HeaderText = "Active";

                //GvVehicals.Columns["AttachVehicleOwner"].HeaderText = "Vehicle Owner";

                //GvVehicals.Columns["AttachVehicleCompany"].HeaderText = "Company";

                //GvVehicals.Columns["AttachVehiclePhoneNumber"].HeaderText = "Phone Number";


                //GvVehicals.Columns["NameBoard"].HeaderText = "NameBoard";

                //GvVehicals.Columns["Wheels"].HeaderText = "Wheels";
                //GvVehicals.Columns["VehicleMake"].Visible = false;
                //GvVehicals.Columns["VehicleMakeCompany"].Visible = false;
                //GvVehicals.Columns["AttachVehicleCompanyAddress"].Visible = false;
                //GvVehicals.Columns["PAN"].Visible = false;
                //GvVehicals.Columns["Documents"].Visible = false;
                //GvVehicals.Columns["NextFCOn"].Visible = false;
                //GvVehicals.Columns["NextInsurenceOn"].Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void IncrementVehicle()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxVehicleID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtVehicleID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtVehicleNo.Text))
            {
                MessageBox.Show("Please enter Vehicle Number");
                TxtVehicleNo.Focus();
                return;
            }

            var match = Regex.Match(TxtVehicleNo.Text, "^[A-Z]{2}[ -][0-9]{1,2}(?: [A-Z])?(?: [A-Z]*)? [0-9]{4}$", RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                MessageBox.Show("Please enter correct Vehicle Number");
                TxtVehicleNo.Focus();
                return;
            }

            //else if (string.IsNullOrEmpty(TxtWheels.Text))
            //{
            //    MessageBox.Show("Please enter Vehicle Wheels");
            //    TxtWheels.Focus();
            //    return;
            //}
            //else if (!int.TryParse(TxtWheels.Text, out a))
            //{
            //    MessageBox.Show("Please enter Correct Vehicle Wheels");
            //    TxtWheels.Focus();
            //    return;
            //}
            //else if (string.IsNullOrEmpty(TxtNameBoard.Text))
            //{
            //    MessageBox.Show("Please enter Vehicle Name Board");
            //    TxtNameBoard.Focus();
            //    return;
            //}
            //else if (string.IsNullOrEmpty(TxtDocuments.Text))
            //{
            //    MessageBox.Show("Please upload Vehicle Documents");
            //    TxtDocuments.Focus();
            //    return;
            //} 

            //if (ChkOwnVehicle.Checked == false)
            //{
            //    if (string.IsNullOrEmpty(TxtOwner.Text))
            //    {
            //        MessageBox.Show("Please enter Attach Vehicle Owner");
            //        TxtOwner.Focus();
            //        return;
            //    } else if (string.IsNullOrEmpty(TxtCompany.Text))
            //    {
            //        MessageBox.Show("Please enter Attach Vehicle Company");
            //        TxtCompany.Focus();
            //        return;
            //    } else if (string.IsNullOrEmpty(TxtPhoneNumber.Text))
            //    {
            //        MessageBox.Show("Please enter Attach Vehicle Phone Number");
            //        TxtPhoneNumber.Focus();
            //        return;
            //    } else if (string.IsNullOrEmpty(TxtAddress.Text))
            //    {
            //        MessageBox.Show("Please enter Attach Vehicle Address");
            //        TxtAddress.Focus();
            //        return;
            //    } else if (string.IsNullOrEmpty(TxtPan.Text))
            //    {
            //        MessageBox.Show("Please enter Attach Vehicle PAN");
            //        TxtPan.Focus();
            //        return;
            //    } 
            //}

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertVehicle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleNo", TxtVehicleNo.Text);
                //cmd.Parameters.AddWithValue("@VehicleMake", TxtMake.Text);
                //cmd.Parameters.AddWithValue("@VehicleMakeCompany", TxtVehicleManu.Text);
                if (ChkOwnVehicle.Checked)
                {
                    cmd.Parameters.AddWithValue("@VehicleOwn", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@VehicleOwn", 0);
                }

                //if (ChkActive.Checked)
                //{
                //    cmd.Parameters.AddWithValue("@IsActive", 1);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@IsActive", 0);
                //}

                if (ChkSpecialVehicle.Checked)
                {
                    cmd.Parameters.AddWithValue("@SplVehicle", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SplVehicle", 0);

                }
                //cmd.Parameters.AddWithValue("@AttachVehicleOwner", TxtOwner.Text);
                //cmd.Parameters.AddWithValue("@AttachVehicleCompany", TxtCompany.Text);
                //cmd.Parameters.AddWithValue("@AttachVehiclePhoneNumber", TxtPhoneNumber.Text);
                //cmd.Parameters.AddWithValue("@AttachVehicleCompanyAddress", TxtAddress.Text);
                //cmd.Parameters.AddWithValue("@CB", "");
                //cmd.Parameters.AddWithValue("@CD", DateTime.Now);
                //cmd.Parameters.AddWithValue("@PAN", TxtPhoneNumber.Text);
                //cmd.Parameters.AddWithValue("@Documents", TxtDocuments.Text);
                //cmd.Parameters.AddWithValue("@Wheels", TxtWheels.Text);
                //cmd.Parameters.AddWithValue("@NextFCOn", TxtNextFCOn.Text);
                //cmd.Parameters.AddWithValue("@NextInsurenceOn", TxtNextInsurenceOn.Text);
                //cmd.Parameters.AddWithValue("@NameBoard", TxtNameBoard.Text);
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Vehicle Saved Succesfully");
                    IncrementVehicle();
                    BindGrid();
                    clear();
                }
                else
                {
                    MessageBox.Show("Vehicle No already exists");
                }
                con.Close();
            }
            else if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateVehicle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleNo", TxtVehicleNo.Text);
                cmd.Parameters.AddWithValue("@VehicleID", TxtVehicleID.Text);
                //cmd.Parameters.AddWithValue("@VehicleMake", TxtMake.Text);
                //cmd.Parameters.AddWithValue("@VehicleMakeCompany", TxtVehicleManu.Text);
                if (ChkOwnVehicle.Checked)
                {
                    cmd.Parameters.AddWithValue("@VehicleOwn", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@VehicleOwn", 0);
                }

                //if (ChkActive.Checked)
                //{
                //    cmd.Parameters.AddWithValue("@IsActive", 1);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@IsActive", 0);
                //}

                if (ChkSpecialVehicle.Checked)
                {
                    cmd.Parameters.AddWithValue("@SplVehicle", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SplVehicle", 0);

                }
                //cmd.Parameters.AddWithValue("@AttachVehicleOwner", TxtOwner.Text);
                //cmd.Parameters.AddWithValue("@AttachVehicleCompany", TxtCompany.Text);
                //cmd.Parameters.AddWithValue("@AttachVehiclePhoneNumber", TxtPhoneNumber.Text);
                //cmd.Parameters.AddWithValue("@AttachVehicleCompanyAddress", TxtAddress.Text);
                //cmd.Parameters.AddWithValue("@UB", "");
                //cmd.Parameters.AddWithValue("@UD", "");
                //cmd.Parameters.AddWithValue("@PAN", TxtPhoneNumber.Text);
                //cmd.Parameters.AddWithValue("@Documents", TxtDocuments.Text);
                //cmd.Parameters.AddWithValue("@Wheels", TxtWheels.Text);
                //cmd.Parameters.AddWithValue("@NextFCOn", TxtNextFCOn.Text);
                //cmd.Parameters.AddWithValue("@NextInsurenceOn", TxtNextInsurenceOn.Text);
                //cmd.Parameters.AddWithValue("@NameBoard", TxtNameBoard.Text);
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Vehicle Edited Succesfully");
                    IncrementVehicle();
                    BindGrid();
                    clear();
                    EditId = string.Empty;
                }
                else
                {
                    MessageBox.Show("Vehicle No already exists");
                }
                con.Close();
            }
        }

        private void clear()
        {
            TxtWheels.Text = string.Empty;
            TxtVehicleManu.Text = string.Empty;
            TxtPhoneNumber.Text = string.Empty;
            TxtPan.Text = string.Empty;
            TxtOwner.Text = string.Empty;
            TxtNameBoard.Text = string.Empty;
            TxtMake.Text = string.Empty;
            TxtDocuments.Text = string.Empty;
            TxtCompany.Text = string.Empty;
            TxtCompany.Text = string.Empty;
            TxtAddress.Text = string.Empty;
            TxtVehicleNo.Text = string.Empty;
        } 

        private void ChkOwnVehicle_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkOwnVehicle.Checked == false)
            {
                GrpVehicle.Enabled = true;
            }
            else
            {
                GrpVehicle.Enabled = false;
            }
        }

        private void TxtDocuments_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = true;
            op.ShowDialog();
            TxtDocuments.Text +=  op.FileName+Environment.NewLine;
            files = op.FileNames;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetVehicleOnId", con);
                cmd.Parameters.AddWithValue("@VehicleID", EditId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                con.Close();
                
                if (dataTable.Rows.Count > 0)
                {
                    TxtVehicleID.Text = Convert.ToString(dataTable.Rows[0]["VehicleID"]);
                    //TxtWheels.Text = Convert.ToString(dataTable.Rows[0]["Wheels"]);
                    //TxtVehicleManu.Text = Convert.ToString(dataTable.Rows[0]["VehicleMakeCompany"]);
                    //TxtPhoneNumber.Text = Convert.ToString(dataTable.Rows[0]["AttachVehiclePhoneNumber"]);
                    //TxtPan.Text = Convert.ToString(dataTable.Rows[0]["PAN"]);
                    //TxtOwner.Text = Convert.ToString(dataTable.Rows[0]["AttachVehicleOwner"]);
                    //TxtNameBoard.Text = Convert.ToString(dataTable.Rows[0]["NameBoard"]);
                    //TxtMake.Value = new DateTime(Convert.ToInt32(dataTable.Rows[0]["VehicleMake"]), 1, 1);
                    //TxtDocuments.Text = Convert.ToString(dataTable.Rows[0]["Documents"]);
                    //TxtCompany.Text = Convert.ToString(dataTable.Rows[0]["AttachVehicleCompany"]);
                    //TxtAddress.Text = Convert.ToString(dataTable.Rows[0]["AttachVehicleCompanyAddress"]);
                    TxtVehicleNo.Text = Convert.ToString(dataTable.Rows[0]["VehicleNo"]);
                    //TxtNextFCOn.Value=Convert.ToDateTime(dataTable.Rows[0]["NextFCOn"]).Date;
                    //TxtNextInsurenceOn.Value = Convert.ToDateTime(dataTable.Rows[0]["NextInsurenceOn"]).Date;

                    //if (Convert.ToBoolean(dataTable.Rows[0]["IsActive"]) == true)
                    //{
                    //    ChkActive.Checked = true;
                    //}
                    //else
                    //{
                    //    ChkActive.Checked = false;
                    //}

                    if (Convert.ToBoolean(dataTable.Rows[0]["VehicleOwn"]) == true)
                    {
                        ChkOwnVehicle.Checked = true;
                    }
                    else
                    {
                        ChkOwnVehicle.Checked = false;
                    }

                    if (Convert.ToBoolean(dataTable.Rows[0]["SplVehicle"]) == true)
                    {
                        ChkSpecialVehicle.Checked = true;
                    }
                    else
                    {
                        ChkSpecialVehicle.Checked = false;
                    }
                }
            }
        }

        private void GvVehicals_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GvVehicals.SelectedRows)
            {
                EditId = row.Cells[0].Value.ToString();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            clear();
            IncrementVehicle();
            EditId=string.Empty;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void TxtVehicleSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtVehicleSearch.Text))
            {
                GvVehicals.DataSource = backup.Select("VehicleNo Like '%" + TxtVehicleSearch.Text + "%'").Any() ? backup.Select("VehicleNo Like '%" + TxtVehicleSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvVehicals.DataSource = backup;
            }
        }
    }
}
