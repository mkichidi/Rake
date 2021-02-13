using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using OfficeOpenXml;

namespace Rake
{
    public partial class RakeShipmentDetailsAll : Form
    {
        string EditId = string.Empty;
        int flag = 0;
        DataTable backup = new DataTable();

        public RakeShipmentDetailsAll()
        {
            InitializeComponent();
            BindDropdowns();
            IncrementShipment();
            BindGrid();
            DtMonthYear.Format = DateTimePickerFormat.Custom;
            DtMonthYear.CustomFormat = "MMMM yyyy";
        }

        public void IncrementShipment()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxShipmentIDRake", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtShipmentID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool res;
            if (keyData == (System.Windows.Forms.Keys.ControlKey | System.Windows.Forms.Keys.Control) || (keyData == System.Windows.Forms.Keys.S) || (keyData == System.Windows.Forms.Keys.R))
            {
                if (keyData == (System.Windows.Forms.Keys.ControlKey | System.Windows.Forms.Keys.Control))
                {
                    flag = 1;
                    return false;
                }
                if (flag == 1)
                {
                    if ((keyData == System.Windows.Forms.Keys.S))
                    {
                        toolStrip1.Items["tsBtnSave"].PerformClick();
                        flag = 0;
                        res = base.ProcessCmdKey(ref msg, keyData);
                        return true;
                    }
                    else if ((keyData == System.Windows.Forms.Keys.R))
                    {
                        toolStrip1.Items["tsBtnRefresh"].PerformClick();
                        flag = 0;
                        res = base.ProcessCmdKey(ref msg, keyData);
                        return true;
                    }
                    else
                    {
                        flag = 0;
                    }
                }
                else
                {
                    flag = 0;
                }
            }
            else
            {
                flag = 0;
            }
            res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }

        public void BindDropdowns()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("ShipmentDropDownRake", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();

            DataRow row = (ds.Tables[1]).NewRow();
            row["Destination Name"] = "-Select-";
            ds.Tables[1].Rows.InsertAt(row, 0);
            DDLTo.DataSource = new DataView(ds.Tables[1]);
            DDLTo.DisplayMember = "Destination Name";
            DDLTo.SelectedIndex = 0;
            DDLTo.ValueMember = "DestinationID";

            row = (ds.Tables[2]).NewRow();
            row["Product Name"] = "-Select-";
            ds.Tables[2].Rows.InsertAt(row, 0);
            DdlProduct.DataSource = new DataView(ds.Tables[2]);
            DdlProduct.DisplayMember = "Product Name";
            DdlProduct.SelectedIndex = 0;
            DdlProduct.ValueMember = "ProductID";

            row = (ds.Tables[0]).NewRow();
            row["VehicleNo"] = "-Select-";
            ds.Tables[0].Rows.InsertAt(row, 0);
            DdlVehicle.DataSource = new DataView(ds.Tables[0]);
            DdlVehicle.DisplayMember = "VehicleNo";
            DdlVehicle.ValueMember = "VehicleID";
            DdlVehicle.SelectedIndex = 0;

            


            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("GetRakeFrom", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            row = dataTable.NewRow();
            row["From"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);

            DdlFrom.DataSource = new DataView(dataTable);
            DdlFrom.DisplayMember = "From";
            DdlFrom.SelectedIndex = 0;
            DdlFrom.ValueMember = "ID";
            

            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("GetUnLoad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            reader = cmd.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            row = dataTable.NewRow();
            row["UnLoadName"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);

            DdlUnLoad.DataSource = new DataView(dataTable);
            DdlUnLoad.DisplayMember = "UnLoadName";
            DdlUnLoad.SelectedIndex = 0;
            DdlUnLoad.ValueMember = "UnLoadID";

             con = new SqlConnection(Connection.InvAdminConn());
             cmd = new SqlCommand("ShipmentDropDownRake", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
             adapter = new SqlDataAdapter(cmd);
             ds = new DataSet();
            adapter.Fill(ds);
            con.Close();

             row = (ds.Tables[2]).NewRow();
            row["Product Name"] = "-Select-";
            ds.Tables[2].Rows.InsertAt(row, 0);
            DdlProduct.DataSource = new DataView(ds.Tables[2]);
            DdlProduct.DisplayMember = "Product Name";
            DdlProduct.SelectedIndex = 0;
            DdlProduct.ValueMember = "ProductID";

            row = (ds.Tables[3]).NewRow();
            row["Party Name"] = "-Select-";
            ds.Tables[3].Rows.InsertAt(row, 0);
            DdlParty.DataSource = new DataView(ds.Tables[3]);
            DdlParty.DisplayMember = "Party Name";
            DdlParty.SelectedIndex = 0;
            DdlParty.ValueMember = "PartyID";


            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("GetRakeFrom", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
             reader = cmd.ExecuteReader();
             dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            row = dataTable.NewRow();
            row["From"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);

            DdlFrom.DataSource = new DataView(dataTable);
            DdlFrom.DisplayMember = "From";
            DdlFrom.SelectedIndex = 0;
            DdlFrom.ValueMember = "ID";

            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("GetRakeType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
             reader = cmd.ExecuteReader();
             dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            row = dataTable.NewRow();
            row["RakeTypeName"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);

            DdlRakeType.DataSource = new DataView(dataTable);
            DdlRakeType.DisplayMember = "RakeTypeName";
            DdlRakeType.SelectedIndex = 0;
            DdlRakeType.ValueMember = "RakeTypeID";
        }

        private void clear()
        {
            TxtShipmentNo.Text = string.Empty;
            TxtWagonNo.Text = string.Empty;
            TxtInvioceNo.Text = string.Empty;
            DdlParty.SelectedIndex = 0;
            DdlFrom.SelectedIndex = 0;
            DdlProduct.SelectedIndex = 0;
            DdlRakeType.SelectedIndex = 0;
            TxtMaterial.Text = string.Empty;
            TxtGrossWt.Text = string.Empty;
            TxtInValue.Text = string.Empty;
            TxtWidth.Text = string.Empty;
            TxtRakeNo.Text = string.Empty;
            TxtGCNo.Text = string.Empty;
            TxtRate.Text = string.Empty;
            TxtAmount.Text = string.Empty;
            TxtThickness.Text = string.Empty;

            DDLTo.SelectedIndex = 0;
            DdlUnLoad.SelectedIndex = 0;
            DdlVehicle.SelectedIndex = 0;

        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetShipmentRake", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            GvShipment.DataSource = dataTable;
            backup = dataTable;
            this.GvShipment.AllowUserToAddRows = false;
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            decimal b = 0M;
            if (string.IsNullOrEmpty(TxtShipmentNo.Text) && string.IsNullOrEmpty(TxtInvioceNo.Text) )
            {
                MessageBox.Show("Please enter Shipment No or Invoice No");
                TxtShipmentNo.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtWagonNo.Text))
            {
                MessageBox.Show("Please enter Wagon");
                TxtWagonNo.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtMaterial.Text))
            {
                MessageBox.Show("Please enter Material No");
                TxtMaterial.Focus();
                return;
            }
            else if (!decimal.TryParse(TxtGrossWt.Text, out b))
            {
                MessageBox.Show("Please enter Correct Gross Wt");
                TxtGrossWt.Focus();
                return;
            }
            else if (DdlParty.SelectedIndex <1)
            {
                MessageBox.Show("Please select Customer");
                DdlParty.Focus();
                return;
            }
            else if (DdlProduct.SelectedIndex < 1)
            {
                MessageBox.Show("Please select Product");
                DdlProduct.Focus();
                return;
            }
            else if (DdlFrom.SelectedIndex < 1)
            {
                MessageBox.Show("Please select From");
                DdlFrom.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtRakeNo.Text))
            {
                MessageBox.Show("Please enter Rake No");
                TxtRakeNo.Focus();
                return;
            }
            else if (!decimal.TryParse(TxtWidth.Text, out b))
            {
                MessageBox.Show("Please enter Correct Width");
                TxtWidth.Focus();
                return;
            }
            else if (!decimal.TryParse(TxtInValue.Text, out b))
            {
                MessageBox.Show("Please enter Correct In Value");
                TxtInValue.Focus();
                return;
            }
            else if (!decimal.TryParse(TxtThickness.Text, out b))
            {
                MessageBox.Show("Please enter Correct Thickness");
                TxtThickness.Focus();
                return;

            }
            else if (DdlRakeType.SelectedIndex < 1)
            {
                MessageBox.Show("Please select Rake Type");
                DdlRakeType.Focus();
                return;
            }
            else if (TxtShipDate.Value > DtRecive.Value)
            {
                MessageBox.Show("Please enter Correct Recive Date");
                DtRecive.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtGCNo.Text))
            {
                MessageBox.Show("Please Gc No");
                TxtGCNo.Focus();
                return;
            }
            else if (DDLTo.SelectedIndex <1)
            {
                MessageBox.Show("Please select To");
                DDLTo.Focus();
                return;
            }
            else if (DdlUnLoad.SelectedIndex < 1)
            {
                MessageBox.Show("Please select Unload");
                DdlUnLoad.Focus();
                return;
            }
            else if (DdlVehicle.SelectedIndex < 1)
            {
                MessageBox.Show("Please select Vehicle No");
                DdlVehicle.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtRate.Text))
            {
                MessageBox.Show("Please enter Rate in Destination Rate Master");
                TxtRate.Focus();
                return;
            }


            if (DdlParty.SelectedIndex == -1)
            {
                DialogResult ans = MessageBox.Show("Customer " + DdlParty.Text + " is not present in master.Do you want to save this Party?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    string party = DdlParty.Text;
                    SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                    SqlCommand cmd = new SqlCommand("InsertPartyRake", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PartyName", party);
                    cmd.Parameters.AddWithValue("@PartyPhoneNumber", "");
                    cmd.Parameters.AddWithValue("@PartyDescription", "");
                    cmd.Parameters.AddWithValue("@PartyAddress", "");
                    cmd.Parameters.AddWithValue("@CB", "");
                    cmd.Parameters.AddWithValue("@CD", DateTime.Now);
                    cmd.Parameters.AddWithValue("@IsActive", 1);

                    con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        con = new SqlConnection(Connection.InvAdminConn());
                        cmd = new SqlCommand("ShipmentDropDown", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        con.Close();
                        DataRow row = (ds.Tables[3]).NewRow();
                        row["Party Name"] = "-Select-";
                        ds.Tables[3].Rows.InsertAt(row, 0);
                        DdlParty.DataSource = new DataView(ds.Tables[3]);
                        DdlParty.DisplayMember = "Party Name";
                        DdlParty.ValueMember = "PartyID";
                        DdlParty.Text = party;

                    }
                    else
                    {
                        MessageBox.Show("Customer already exists");
                    }
                    con.Close();
                }
            }

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertShipmentRakeAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ShipmentNo", TxtShipmentNo.Text);
                cmd.Parameters.AddWithValue("@InvoiceNo", TxtInvioceNo.Text);
                cmd.Parameters.AddWithValue("@ShipmentDate", TxtShipDate.Value.Date);
                cmd.Parameters.AddWithValue("@Material", TxtMaterial.Text);
                cmd.Parameters.AddWithValue("@WagonNo", TxtWagonNo.Text);
                cmd.Parameters.AddWithValue("@NetWt", TxtGrossWt.Text);
                cmd.Parameters.AddWithValue("@FromID", DdlFrom.SelectedValue);
                cmd.Parameters.AddWithValue("@RakeNo", TxtRakeNo.Text);
                cmd.Parameters.AddWithValue("@Thickness", TxtThickness.Text);
                cmd.Parameters.AddWithValue("@Width", TxtWidth.Text);
                cmd.Parameters.AddWithValue("@InValue", TxtInValue.Text);
                cmd.Parameters.AddWithValue("@ProductID", DdlProduct.SelectedValue);
                cmd.Parameters.AddWithValue("@PartyID", DdlParty.SelectedValue);
                cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
                cmd.Parameters.AddWithValue("@CB", "");
                cmd.Parameters.AddWithValue("@CD", "");
                cmd.Parameters.AddWithValue("@Recivedate", DtRecive.Value.Date);
                cmd.Parameters.AddWithValue("@GcNo", TxtGCNo.Text);
                cmd.Parameters.AddWithValue("@VehicleNo", DdlVehicle.SelectedValue);
                cmd.Parameters.AddWithValue("@UnLoad", DdlUnLoad.SelectedValue);
                cmd.Parameters.AddWithValue("@To", DDLTo.SelectedValue);
                cmd.Parameters.AddWithValue("@Rate", TxtRate.Text);
                cmd.Parameters.AddWithValue("@Amount", TxtAmount.Text);
                cmd.Parameters.AddWithValue("@MonthYear", DtMonthYear.Value.Date);

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Shipment Details Saved Succesfully");
                    IncrementShipment();
                    BindGrid();
                    clear();
                }
                else
                {
                    MessageBox.Show("Shipment Details already exists");
                }
                con.Close();
            }
            else if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateShipmentRakeAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ShipMentID", TxtShipmentID.Text);
                cmd.Parameters.AddWithValue("@ShipmentNo", TxtShipmentNo.Text);
                cmd.Parameters.AddWithValue("@InvoiceNo", TxtInvioceNo.Text);
                cmd.Parameters.AddWithValue("@ShipmentDate", TxtShipDate.Value.Date);
                cmd.Parameters.AddWithValue("@Material", TxtMaterial.Text);
                cmd.Parameters.AddWithValue("@WagonNo", TxtWagonNo.Text);
                cmd.Parameters.AddWithValue("@NetWt", TxtGrossWt.Text);
                cmd.Parameters.AddWithValue("@ProductID", DdlProduct.SelectedValue);
                cmd.Parameters.AddWithValue("@PartyID", DdlParty.SelectedValue);
                cmd.Parameters.AddWithValue("@FromID", DdlFrom.SelectedValue);
                cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
                cmd.Parameters.AddWithValue("@Thickness", TxtThickness.Text);
                cmd.Parameters.AddWithValue("@Width", TxtWidth.Text);
                cmd.Parameters.AddWithValue("@InValue", TxtInValue.Text);
                cmd.Parameters.AddWithValue("@RakeNo", TxtRakeNo.Text);
                cmd.Parameters.AddWithValue("@UB", "");
                cmd.Parameters.AddWithValue("@UD", "");
                cmd.Parameters.AddWithValue("@Recivedate", DtRecive.Value.Date);
                cmd.Parameters.AddWithValue("@GcNo", TxtGCNo.Text);
                cmd.Parameters.AddWithValue("@VehicleNo", DdlVehicle.SelectedValue);
                cmd.Parameters.AddWithValue("@UnLoad", DdlUnLoad.SelectedValue);
                cmd.Parameters.AddWithValue("@To", DDLTo.SelectedValue);
                cmd.Parameters.AddWithValue("@Rate", TxtRate.Text);
                cmd.Parameters.AddWithValue("@Amount", TxtAmount.Text);
                cmd.Parameters.AddWithValue("@MonthYear", DtMonthYear.Value.Date);

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Shipment Details Edited Succesfully");
                    IncrementShipment();
                    BindGrid();
                    clear();
                    EditId = string.Empty;
                }
                con.Close();
            }
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetShipMentOnIdRAkeAll", con);
                cmd.Parameters.AddWithValue("@ShipMentID", EditId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                con.Close();

                if (dataTable.Rows.Count > 0)
                {
                    TxtShipmentID.Text = Convert.ToString(dataTable.Rows[0]["RakeShipmentID"]);
                    TxtShipmentNo.Text = Convert.ToString(dataTable.Rows[0]["ShipmentNo"]);
                    TxtInvioceNo.Text = Convert.ToString(dataTable.Rows[0]["InvoiceNo"]);
                    TxtMaterial.Text = Convert.ToString(dataTable.Rows[0]["Material"]);
                    TxtWagonNo.Text = Convert.ToString(dataTable.Rows[0]["WagonNo"]);
                    TxtRakeNo.Text = Convert.ToString(dataTable.Rows[0]["RakeNo"]);
                    TxtWidth.Text = Convert.ToString(dataTable.Rows[0]["Width"]);
                    TxtThickness.Text = Convert.ToString(dataTable.Rows[0]["Thickness"]);
                    TxtInValue.Text = Convert.ToString(dataTable.Rows[0]["InValue"]);
                    TxtShipDate.Value = Convert.ToDateTime(dataTable.Rows[0]["ShipmentDate"]).Date;
                    TxtGrossWt.Text = Convert.ToString(dataTable.Rows[0]["NetWt"]);
                    DdlProduct.SelectedValue = Convert.ToInt32(dataTable.Rows[0]["ProductID"]);
                    DdlParty.SelectedValue = Convert.ToInt32(dataTable.Rows[0]["PartyID"]);
                    DdlFrom.SelectedValue = Convert.ToInt32(dataTable.Rows[0]["FromID"]);
                    DdlRakeType.SelectedValue = Convert.ToInt32(dataTable.Rows[0]["RakeType"]);

                    DtRecive.Value = Convert.ToDateTime(dataTable.Rows[0]["GcReciveDate"]).Date;
                    TxtGCNo.Text = Convert.ToString(dataTable.Rows[0]["GCNo"]);
                    TxtRate .Text = Convert.ToString(dataTable.Rows[0]["Rate"]);
                    TxtAmount.Text = Convert.ToString(dataTable.Rows[0]["Amount"]);
                    DdlVehicle.SelectedValue = Convert.ToInt32(dataTable.Rows[0]["VehicleID"]);
                    DdlUnLoad.SelectedValue = Convert.ToInt32(dataTable.Rows[0]["UnLoadId"]);
                    DDLTo.SelectedValue = Convert.ToInt32(dataTable.Rows[0]["DestinationId"]);
                    DtMonthYear.Value = Convert.ToDateTime(dataTable.Rows[0]["MonthYear"]).Date;
                }
            }
        }

        private void GvShipment_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GvShipment.SelectedRows)
            {
                EditId = row.Cells[0].Value.ToString();
            }
        }


        public static DataTable ConvertExcelToDataTable(string FileName)
        {
            string sSheetName = null;
            string sConnection = null;
            DataTable dtTablesList = default(DataTable);
            OleDbCommand oleExcelCommand = default(OleDbCommand);
            OleDbDataReader oleExcelReader = default(OleDbDataReader);
            OleDbConnection oleExcelConnection = default(OleDbConnection);
            sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            oleExcelConnection = new OleDbConnection(sConnection);
            oleExcelConnection.Open();
            dtTablesList = oleExcelConnection.GetSchema("Tables");
            if (dtTablesList.Rows.Count > 0)
            {
                sSheetName = "ShipmentDetails$";
            }
            dtTablesList.Clear();
            dtTablesList.Dispose();
            if (!string.IsNullOrEmpty(sSheetName))
            {
                oleExcelCommand = oleExcelConnection.CreateCommand();
                oleExcelCommand.CommandText = "Select * From [" + sSheetName + "]";
                oleExcelCommand.CommandType = CommandType.Text;
                oleExcelReader = oleExcelCommand.ExecuteReader();
                dtTablesList = new DataTable();
                dtTablesList.Load(oleExcelReader);
                oleExcelReader.Close();
            }
            oleExcelConnection.Close();

            return dtTablesList;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
                OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = true;
            op.ShowDialog();
            TxtUploadfile.Text = op.FileName;
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtUploadfile.Text))
            {
                DataTable dt = ConvertExcelToDataTable(TxtUploadfile.Text);

                string error = string.Empty;
                string correct = string.Empty;

                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    int errorBit = 0;

                    try
                    {
                        //SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                        //SqlCommand cmd = new SqlCommand("GetVehicleOnName", con);
                        //cmd.Parameters.AddWithValue("@VehicleNo", dt.Rows[row]["Vehicle No"]);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //con.Open();
                        //if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                        //{
                        //    string vehicle = DdlVehicle.Text;
                        //    con = new SqlConnection(Connection.InvAdminConn());
                        //    cmd = new SqlCommand("InsertVehicle", con);
                        //    cmd.CommandType = CommandType.StoredProcedure;
                        //    cmd.Parameters.AddWithValue("@VehicleNo", dt.Rows[row]["Vehicle No"]);
                        //    cmd.Parameters.AddWithValue("@SplVehicle", 0);
                        //    con.Open();
                        //    cmd.ExecuteNonQuery();
                        //    con.Close();
                        //}

                        SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                        SqlCommand cmd = new SqlCommand("GetFromOnName", con);
                        cmd.Parameters.AddWithValue("@From", dt.Rows[row]["From"]);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please check From in From Master" + Environment.NewLine;

                        }
                        con.Close();

                         con = new SqlConnection(Connection.InvAdminConn());
                         cmd = new SqlCommand("GetProductOnNameRake", con);
                        cmd.Parameters.AddWithValue("@ProductName", dt.Rows[row]["Product"]);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please check Product Name in Product Master" + Environment.NewLine;
                        }
                        con.Close();

                        con = new SqlConnection(Connection.InvAdminConn());
                        cmd = new SqlCommand("GetPartyOnNameRake", con);
                        cmd.Parameters.AddWithValue("@PartyName", dt.Rows[row]["Customer"]);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please check Customer Name in Customer Master" + Environment.NewLine;
                        }
                        con.Close();
                        DateTime datetime;

                        if (!DateTime.TryParse(Convert.ToString(dt.Rows[row]["Shipment Date"]), out datetime))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct Shipment Date" + Environment.NewLine;
                        }

                        if (!DateTime.TryParse(Convert.ToString(dt.Rows[row]["Month Year"]), out datetime))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct Month Year" + Environment.NewLine;
                        }

                        if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Material"])))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter Material" + Environment.NewLine;
                        }


                        if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["WagonNo"])))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter WagonNo" + Environment.NewLine;
                        }

                        if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Rake No"])))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter Rake No" + Environment.NewLine;

                        }
                        decimal dec = 0m;

                        //if (!decimal.TryParse(Convert.ToString(dt.Rows[row]["Inv Wt"]), out dec))
                        //{
                        //    if (errorBit == 0)
                        //    {
                        //        error += "Line No " + (row + 2) + Environment.NewLine;
                        //        errorBit = 1;
                        //    }
                        //    error += "    Please enter correct Inv Wt" + Environment.NewLine;
                        //}

                        if (!decimal.TryParse(Convert.ToString(dt.Rows[row]["Gross Wt"]), out dec))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct Gross Wt" + Environment.NewLine;
                        }

                        //if (!decimal.TryParse(Convert.ToString(dt.Rows[row]["Width"]), out dec))
                        //{
                        //    if (errorBit == 0)
                        //    {
                        //        error += "Line No " + (row + 2) + Environment.NewLine;
                        //        errorBit = 1;
                        //    }
                        //    error += "    Please enter correct Width" + Environment.NewLine;
                        //}

                        //if (!decimal.TryParse(Convert.ToString(dt.Rows[row]["Thickness"]), out dec))
                        //{
                        //    if (errorBit == 0)
                        //    {
                        //        error += "Line No " + (row + 2) + Environment.NewLine;
                        //        errorBit = 1;
                        //    }
                        //    error += "    Please enter correct Thickness" + Environment.NewLine;
                        //}

                        //if (!decimal.TryParse(Convert.ToString(dt.Rows[row]["In Value"]), out dec))
                        //{
                        //    if (errorBit == 0)
                        //    {
                        //        error += "Line No " + (row + 2) + Environment.NewLine;
                        //        errorBit = 1;
                        //    }
                        //    error += "    Please enter correct In Value" + Environment.NewLine;
                        //}

                        con = new SqlConnection(Connection.InvAdminConn());
                        cmd = new SqlCommand("GetRakeTypeOnNameRake", con);
                        cmd.Parameters.AddWithValue("@RakeTypeName", dt.Rows[row]["Rake Type"]);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please check Rake Type Name in Rake Type Master" + Environment.NewLine;
                        }
                        con.Close();

                         con = new SqlConnection(Connection.InvAdminConn());
                         cmd = new SqlCommand("GetVehicleOnName", con);
                        cmd.Parameters.AddWithValue("@VehicleNo", dt.Rows[row]["Vehicle No"]);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Vehicle No not in Master." + Environment.NewLine;

                            //string vehicle = DdlVehicle.Text;
                            //con = new SqlConnection(Connection.InvAdminConn());
                            //cmd = new SqlCommand("InsertVehicle", con);
                            //cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.Parameters.AddWithValue("@VehicleNo", dt.Rows[row]["Vehicle No"]);
                            //cmd.Parameters.AddWithValue("@SplVehicle", 0);
                            //cmd.Parameters.AddWithValue("@VehicleOwn", 0);
                            //con.Open();
                            //cmd.ExecuteNonQuery();
                            //con.Close();
                        }
                        con.Close();

                        con = new SqlConnection(Connection.InvAdminConn());
                        cmd = new SqlCommand("GetToOnName", con);
                        cmd.Parameters.AddWithValue("@From", dt.Rows[row]["To"]);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please check Destination in From Destination" + Environment.NewLine;

                        }
                        con.Close();

                        con = new SqlConnection(Connection.InvAdminConn());
                        cmd = new SqlCommand("GetUnloadOnName", con);
                        cmd.Parameters.AddWithValue("@From", dt.Rows[row]["UnLoad"]);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please check UnLoad Name in UnLoad Master" + Environment.NewLine;
                        }
                        con.Close();


                        if (!DateTime.TryParse(Convert.ToString(dt.Rows[row]["Recive date"]), out datetime))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct Recive date" + Environment.NewLine;
                        }

                        con.Close();
                        int allow = 0;
                        long allow64 = 0;

                        if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Gc No"])))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter Gc No" + Environment.NewLine;
                        }


                        if (errorBit == 0)
                        {
                            con = new SqlConnection(Connection.InvAdminConn());
                            cmd = new SqlCommand("InsertShipmentOnUploadRakeAll", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            //if (int.TryParse(Convert.ToString(dt.Rows[row]["Shipment No"]), out allow))
                            //{
                            //    cmd.Parameters.AddWithValue("@ShipmentNo", Convert.ToInt32(dt.Rows[row]["Shipment No"]));
                            //}
                            //else
                            //{
                                cmd.Parameters.AddWithValue("@ShipmentNo", "");
                            //}

                            if (int.TryParse(Convert.ToString(dt.Rows[row]["Invoice No"]), out allow))
                            {
                                cmd.Parameters.AddWithValue("@InvoiceNo", Convert.ToInt32(dt.Rows[row]["Invoice No"]));
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@InvoiceNo", "");
                            }

                            if (int.TryParse(Convert.ToString(dt.Rows[row]["Material"]), out allow))
                            {
                                cmd.Parameters.AddWithValue("@Material", Convert.ToInt32(dt.Rows[row]["Material"]));
                            }
                            else if (Int64.TryParse(Convert.ToString(dt.Rows[row]["Material"]), out allow64))
                            {
                                cmd.Parameters.AddWithValue("@Material", Convert.ToInt64(dt.Rows[row]["Material"]));
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@Material", dt.Rows[row]["Material"]);
                            }

                            //cmd.Parameters.AddWithValue("@Material", dt.Rows[row]["Material"]);
                            cmd.Parameters.AddWithValue("@ShipmentDate", Convert.ToDateTime(dt.Rows[row]["Shipment Date"]));
                            TxtShipDate.Value = Convert.ToDateTime(dt.Rows[row]["Shipment Date"]);
                            cmd.Parameters.AddWithValue("@WagonNo", dt.Rows[row]["WagonNo"]);
                            cmd.Parameters.AddWithValue("@NetWt", Convert.ToDecimal(dt.Rows[row]["Gross Wt"]));
                            cmd.Parameters.AddWithValue("@Product", dt.Rows[row]["Product"]);
                            cmd.Parameters.AddWithValue("@Party", dt.Rows[row]["Customer"]);
                            cmd.Parameters.AddWithValue("@From", dt.Rows[row]["From"]);
                            cmd.Parameters.AddWithValue("@RakeNo", dt.Rows[row]["RAke No"]);
                            cmd.Parameters.AddWithValue("@Thickness", dt.Rows[row]["Thickness"]);
                            cmd.Parameters.AddWithValue("@Width", dt.Rows[row]["Width"]);
                            cmd.Parameters.AddWithValue("@InValue", dt.Rows[row]["In value"]);
                            cmd.Parameters.AddWithValue("@RakeType", dt.Rows[row]["Rake Type"]);
                            cmd.Parameters.AddWithValue("@CB", "");
                            cmd.Parameters.AddWithValue("@CD", DateTime.Now);
                            TxtGrossWt.Text=Convert.ToString(dt.Rows[row]["Gross Wt"]);
                            cmd.Parameters.AddWithValue("@Recivedate", dt.Rows[row]["Recive date"]);
                            cmd.Parameters.AddWithValue("@GcNo", dt.Rows[row]["Gc No"]);
                            DdlVehicle.SelectedText = Convert.ToString(dt.Rows[row]["Vehicle No"]);
                            DdlUnLoad.Text = Convert.ToString(dt.Rows[row]["UnLoad"]).Trim();
                            DDLTo.Text = Convert.ToString(dt.Rows[row]["To"]).Trim();
                            DdlFrom.Text = Convert.ToString(dt.Rows[row]["From"]).Trim();
                            DtMonthYear.Value =Convert.ToDateTime(dt.Rows[row]["Month Year"]);
                            DdlFrom_SelectedIndexChanged(null, null);
                            cmd.Parameters.AddWithValue("@VehicleNo", dt.Rows[row]["Vehicle No"]);
                            cmd.Parameters.AddWithValue("@UnLoad", DdlUnLoad.SelectedValue);
                            cmd.Parameters.AddWithValue("@To", DDLTo.SelectedValue);
                            cmd.Parameters.AddWithValue("@Rate", TxtRate.Text);
                            cmd.Parameters.AddWithValue("@Amount", TxtAmount.Text);
                            cmd.Parameters.AddWithValue("@MonthYear", dt.Rows[row]["Month Year"]);

                           

                            if (string.IsNullOrEmpty(TxtRate.Text) || string.IsNullOrEmpty(TxtAmount.Text) || (Convert.ToDecimal(TxtRate.Text) < 1) || (Convert.ToDecimal(TxtAmount.Text) < 1))
                            {
                                if (Convert.ToString(dt.Rows[row]["To"]).ToLower() == "unknown")
                                {
                                    TxtAmount.Text = "0";
                                    TxtRate.Text = "0";
                                }
                                else
                                {
                                    if (errorBit == 0)
                                    {
                                        error += "Line No " + (row + 2) + Environment.NewLine;
                                        errorBit = 1;
                                    }
                                    error += "    Please enter Destination Rate" + Environment.NewLine;
                                }
                            }

                            if (errorBit == 0)
                            {
                                con.Open();
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    correct += "," + (row + 2);
                                }
                                con.Close();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        error += "Line No" + (row + 2) + Environment.NewLine;
                        error += ex.Message;
                        continue;
                    }
                }
                if (error.Length > 0 && correct.Length > 0)
                {
                    MessageBox.Show("Lines at " + correct.Substring(1) + " uploaded succesfully." + Environment.NewLine + " Error at " + error + Environment.NewLine);
                    error = string.Empty;
                    correct = string.Empty;
                }
                else if (error.Length > 0)
                {
                    MessageBox.Show(error + Environment.NewLine + "Please correct and upload error data at " + TxtUploadfile.Text);
                    error = string.Empty;
                    correct = string.Empty;
                }
                else
                {
                    MessageBox.Show("Shipment details saved succesfully");
                    error = string.Empty;
                    correct = string.Empty;
                }
                IncrementShipment();
                BindGrid();
                clear();
            }
        }

        private string clearExcelUploadSuccess(string correct)
        {
            using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(TxtUploadfile.Text)))
            {
                var worksheet = package.Workbook.Worksheets[1];
                string[] corrects = correct.Substring(1).Split(',');
                for (int row = 0; row < corrects.Count(); row++)
                {
                    worksheet.DeleteRow(Convert.ToInt32(corrects[row]) - row);
                }
                string filename = "D:\\Rake\\ShipmentDetails\\Shipment_Error_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_');
                System.IO.Directory.CreateDirectory("D:\\RAke\\ShipmentDetails");
                System.IO.FileInfo excel = new System.IO.FileInfo(filename + ".xlsx");

                if (excel.Exists)
                {
                    excel.Delete();
                }
                using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Rake\\ShipmentDetails\\Shipment_Error_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_') + ".xlsx")))
                {
                    pac.Workbook.Worksheets.Add(("ShipmentDetails"), worksheet);
                    pac.Save();
                }
            }
            return ("D:\\Rake\\ShipmentDetails\\Shipment_Error_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_') + ".xlsx");
        }

        private string ExcelDropdown(DataTable dt, string value)
        {
            string data = string.Empty;
            foreach (DataRow datarow in dt.Rows)
            {
                if (data.Length > 0)
                {
                    data += datarow[value] + ",";
                }
                else
                {
                    data += "\"" + datarow[value] + ",";
                }
            }
            if (data.Length > 0)
            {
                data = data.Substring(0, data.Length - 1);
                data += "\"";
            }
            return data;
        }

        private void DownloadFile_Click(object sender, EventArgs e)
        {
            string filename = "D:\\RAke\\ShipmentDetailsAll\\ShipmentDetails_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_') + " (" + DateTime.Now.ToString("h.mm.ss")+")";
            System.IO.Directory.CreateDirectory("D:\\RAke\\ShipmentDetailsAll");
            System.IO.FileInfo excel = new System.IO.FileInfo(filename + ".xlsx");

            if (excel.Exists)
            {
                excel.Delete();
            }
            using (var xls = new ExcelPackage(excel))
            {
                var sheet = xls.Workbook.Worksheets.Add("ShipmentDetails");
                sheet.Cells["A1"].Value = "WagonNo";
                sheet.Cells["B1"].Value = "Material";
                sheet.Cells["C1"].Value = "Customer";
                sheet.Cells["D1"].Value = "Product";
                sheet.Cells["E1"].Value = "Gross Wt";
                sheet.Cells["F1"].Value = "Thickness";
                sheet.Cells["G1"].Value = "Width";
                sheet.Cells["H1"].Value = "In Value";
                sheet.Cells["I1"].Value = "Shipment Date";
                sheet.Cells["J1"].Value = "Invoice No";
                sheet.Cells["K1"].Value = "Month year"; 
                sheet.Cells["L1"].Value = "Recive date";
                sheet.Cells["M1"].Value = "Gc No";
                sheet.Cells["N1"].Value = "Vehicle No";
                sheet.Cells["O1"].Value = "UnLoad";
                sheet.Cells["P1"].Value = "To";
                sheet.Cells["Q1"].Value = "From";
                sheet.Cells["R1"].Value = "Rake No";
                sheet.Cells["S1"].Value = "Rake Type";
                sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                sheet.Column(1).Width = 20;
                sheet.Column(2).Width = 20;
                sheet.Column(3).Width = 20;
                sheet.Column(4).Width = 20;
                sheet.Column(5).Width = 20;
                sheet.Column(6).Width = 20;
                sheet.Column(7).Width = 15;
                sheet.Column(8).Width = 20;
                sheet.Column(9).Width = 20;
                sheet.Column(10).Width = 20;
                sheet.Column(11).Width = 20;
                sheet.Column(12).Width = 20;
                sheet.Column(13).Width = 20;
                sheet.Column(14).Width = 20;
                sheet.Column(15).Width = 20;
                sheet.Column(16).Width = 20;
                sheet.Column(17).Width = 20;
                sheet.Column(18).Width = 20;
                sheet.Column(19).Width = 20;

                //Get the final row for the column in the worksheet
                int finalrows = sheet.Dimension.End.Row;


                sheet.Cells["A1:S" + finalrows.ToString()].Style.WrapText = true;
                sheet.Cells["A1:S1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["A1:S1"].Style.Font.Size = 12;

                sheet.Cells["A1:S1"].Style.Font.Bold = true;
                sheet.Cells["A1:S1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                sheet.Cells["A1:S1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);

                //sheet.Cells["H1:P" + finalrows.ToString()].Style.Numberformat.Format = "#,##0.00";


                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("ShipmentDropDownRakeGcRecive", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                con.Close();

                var sheetVehicle = xls.Workbook.Worksheets.Add("Vehicles");
                for (int dr = 1; dr <= ds.Tables[0].Rows.Count; dr++)
                {
                    sheetVehicle.Cells["A" + dr].Value = ds.Tables[0].Rows[dr - 1]["VehicleNo"];
                }

                //var validation = sheet.DataValidations.AddListValidation("F2");
                //validation.Formula.ExcelFormula = (ExcelDropdown(ds.Tables[0], "VehicleNo"));

                var sheetDestination = xls.Workbook.Worksheets.Add("Destination Name");
                for (int dr = 1; dr <= ds.Tables[1].Rows.Count; dr++)
                {
                    sheetDestination.Cells["A" + dr].Value = ds.Tables[1].Rows[dr - 1]["Destination Name"];
                }
                //validation = sheet.DataValidations.AddListValidation("J2");
                //validation.Formula.ExcelFormula = (ExcelDropdown(ds.Tables[1], "Destination Name"));

                //validation = sheet.DataValidations.AddListValidation("K2");
                //validation.Formula.ExcelFormula = (ExcelDropdown(ds.Tables[1], "Destination Name"));

                var sheetProduct = xls.Workbook.Worksheets.Add("UnLoad");
                for (int dr = 1; dr <= ds.Tables[2].Rows.Count; dr++)
                {
                    sheetProduct.Cells["A" + dr].Value = ds.Tables[2].Rows[dr - 1]["UnLoadName"];
                }


                 con = new SqlConnection(Connection.InvAdminConn());
                 cmd = new SqlCommand("ShipmentDropDownRake", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                 adapter = new SqlDataAdapter(cmd);
                 ds = new DataSet();
                adapter.Fill(ds);

                con.Close();
              

                var Customer = xls.Workbook.Worksheets.Add("Customer");
                for (int dr = 1; dr <= ds.Tables[3].Rows.Count; dr++)
                {
                    Customer.Cells["A" + dr].Value = ds.Tables[3].Rows[dr - 1]["Party Name"];
                }

                //validation = sheet.DataValidations.AddListValidation("M2");
                //validation.Formula.ExcelFormula = (ExcelDropdown(ds.Tables[3], "Party Name"));
                

                xls.Save();

                DialogResult ans = MessageBox.Show("File Downloaded at " + filename + Environment.NewLine + "Do you want to open?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(filename + ".xlsx");
                }
            }
        }

        private void TxtUploadfile_TextChanged(object sender, EventArgs e)
        {

        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void tsBtnRefresh_Click(object sender, EventArgs e)
        {
            BindDropdowns();
        }

        private void TxtInvoiceSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtInvoiceSearch.Text))
            {
                GvShipment.DataSource = backup.Select("InvoiceNo Like '%" + TxtInvoiceSearch.Text + "%'").Any() ? backup.Select("InvoiceNo Like '%" + TxtInvoiceSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvShipment.DataSource = backup;
            }
        }

        private void DdlFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlFrom.SelectedIndex > 0 && DDLTo.SelectedIndex > 0)
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetRakeRate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@From", DdlFrom.SelectedValue);
                cmd.Parameters.AddWithValue("@to", DDLTo.SelectedValue);
                cmd.Parameters.AddWithValue("@date", DtMonthYear.Value.Date);

                con.Open();
                TxtRate.Text = Convert.ToString(cmd.ExecuteScalar());
                con.Close();

                decimal a;
                if (!string.IsNullOrEmpty(TxtRate.Text))
                {
                    if (decimal.TryParse(TxtGrossWt.Text, out a))
                    {
                        TxtAmount.Text = Convert.ToString(Math.Round(Convert.ToDecimal(TxtGrossWt.Text) * Convert.ToDecimal(TxtRate.Text)));
                    }
                }
            }
        }

        private void TxtShipDate_ValueChanged(object sender, EventArgs e)
        {
            if (DdlFrom.SelectedIndex > 1 && DDLTo.SelectedIndex >1)
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetRakeRate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@From", DdlFrom.SelectedValue);
                cmd.Parameters.AddWithValue("@to", DDLTo.SelectedValue);
                cmd.Parameters.AddWithValue("@date", DtMonthYear.Value.Date);
                con.Open();
                TxtRate.Text = Convert.ToString(cmd.ExecuteScalar());
                con.Close();

                decimal a;
                if (!string.IsNullOrEmpty(TxtRate.Text))
                {
                    if (decimal.TryParse(TxtGrossWt.Text, out a))
                    {
                        TxtAmount.Text = Convert.ToString(Convert.ToDecimal(TxtGrossWt.Text) * Convert.ToDecimal(TxtGrossWt.Text));
                    }
                }
            }
        }

        private void DDLTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlFrom.SelectedIndex > 0 && DDLTo.SelectedIndex > 0)
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetRakeRate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@From", DdlFrom.SelectedValue);
                cmd.Parameters.AddWithValue("@to", DDLTo.SelectedValue);
                cmd.Parameters.AddWithValue("@date", DtMonthYear.Value.Date);

                con.Open();
                TxtRate.Text = Convert.ToString(cmd.ExecuteScalar());
                con.Close();

                decimal a;
                if (!string.IsNullOrEmpty(TxtRate.Text))
                {
                    if (decimal.TryParse(TxtGrossWt.Text, out a))
                    {
                        TxtAmount.Text = Convert.ToString(Math.Round(Convert.ToDecimal(TxtGrossWt.Text) * Convert.ToDecimal(TxtRate.Text)));
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtGcNoSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtGcNoSearch.Text))
            {
                GvShipment.DataSource = backup.Select("GCNo Like '%" + TxtGcNoSearch.Text + "%'").Any() ? backup.Select("GCNo Like '%" + TxtGcNoSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvShipment.DataSource = backup;
            }
        }

        private void TxtToSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtToSearch.Text))
            {
                GvShipment.DataSource = backup.Select("To Like '%" + TxtToSearch.Text + "%'").Any() ? backup.Select("To Like '%" + TxtToSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvShipment.DataSource = backup;
            }
        }

        private void TxtUnLoadSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtUnLoadSearch.Text))
            {
                GvShipment.DataSource = backup.Select("UnLoadName Like '%" + TxtUnLoadSearch.Text + "%'").Any() ? backup.Select("UnLoadName Like '%" + TxtUnLoadSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvShipment.DataSource = backup;
            }
        }

        private void TxtVehicleSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtVehicleSearch.Text))
            {
                GvShipment.DataSource = backup.Select("VehicleNo Like '%" + TxtVehicleSearch.Text + "%'").Any() ? backup.Select("VehicleNo Like '%" + TxtVehicleSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvShipment.DataSource = backup;
            }
        }

        private void TxtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCustomerSearch.Text))
            {
                GvShipment.DataSource = backup.Select("PartyName Like '%" + TxtCustomerSearch.Text + "%'").Any() ? backup.Select("PartyName Like '%" + TxtCustomerSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvShipment.DataSource = backup;
            }
        }

        private void TxtProductSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtProductSearch.Text))
            {
                GvShipment.DataSource = backup.Select("ProductName Like '%" + TxtProductSearch.Text + "%'").Any() ? backup.Select("ProductName Like '%" + TxtProductSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvShipment.DataSource = backup;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtMaterialSearch.Text))
            {
                GvShipment.DataSource = backup.Select("Material Like '%" + TxtMaterialSearch.Text + "%'").Any() ? backup.Select("Material Like '%" + TxtMaterialSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvShipment.DataSource = backup;
            }
        }

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            clear();
            IncrementShipment();
            EditId = string.Empty;
        }
    }
}
