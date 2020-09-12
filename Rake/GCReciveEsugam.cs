using OfficeOpenXml;
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
using System.Data.OleDb;

namespace Rake
{
    public partial class GCReciveEsugam : Form
    {
        int flag = 0;
        public GCReciveEsugam()
        {
            InitializeComponent();
            BindDropdowns();
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

            row = (ds.Tables[3]).NewRow();
            row["Party Name"] = "-Select-";
            ds.Tables[3].Rows.InsertAt(row, 0);
            DdlCustomer.DataSource = new DataView(ds.Tables[3]);
            DdlCustomer.DisplayMember = "Party Name";
            DdlCustomer.SelectedIndex = 0;
            DdlCustomer.ValueMember = "PartyID";

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
            con.Close();

            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("GetUnLoad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            reader = cmd.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(reader);
            row = dataTable.NewRow();
            row["UnLoadName"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);

            DdlUnLoad.DataSource = new DataView(dataTable);
            DdlUnLoad.DisplayMember = "UnLoadName";
            DdlUnLoad.SelectedIndex = 0;
            DdlUnLoad.ValueMember = "UnLoadID";
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            decimal b = 0M;
            DateTime dt = new DateTime();
           
            if (datetimeShipment.Value > DtRecive.Value)
            {
                MessageBox.Show("Please enter Correct Recive Date");
                DtRecive.Focus();
                return;
            }
            else if (DDLTo.SelectedIndex < 1)
            {
                MessageBox.Show("Please select To");
                DDLTo.Focus();
                return;
            }
            else if (DdlFrom.SelectedIndex <1)
            {
                MessageBox.Show("Please select From");
                DdlFrom.Focus();
                return;
            }
            else if (DdlUnLoad.SelectedIndex < 1)
            {
                MessageBox.Show("Please select Un Load Place");
                DdlUnLoad.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtWeighment.Text))
            {
                MessageBox.Show("Please enter Weighment");
                TxtWeighment.Focus();
                return;
            }


            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("UpdateGcRecivedRakeEsugam", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ShipMentID", LblShipmentID.Text);
            cmd.Parameters.AddWithValue("@GcReciveDate", DtRecive.Value.Date);
            cmd.Parameters.AddWithValue("@FromId", DdlFrom.SelectedValue);
            cmd.Parameters.AddWithValue("@DestinationId", DDLTo.SelectedValue);
            cmd.Parameters.AddWithValue("@Weighment", TxtWeighment.Text);
            cmd.Parameters.AddWithValue("@Short", TxtDiffereceWt.Text);
            cmd.Parameters.AddWithValue("@UnLoadId", DdlUnLoad.SelectedValue);

            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("GC Recived updated succesfully");

                // con = new SqlConnection(Connection.InvAdminConn());
                // cmd = new SqlCommand("JSWBill", con);
                //cmd.Parameters.AddWithValue("@DestinationID", DdlDestination.SelectedValue);
                //cmd.Parameters.AddWithValue("@ProductID", DdlProduct.SelectedValue);
                //if ((datetimeShipment.Value.Day >= 1) && (datetimeShipment.Value.Day <= 14))
                //{
                //    cmd.Parameters.AddWithValue("@From", 1);
                //    cmd.Parameters.AddWithValue("@To", 14);
                //}
                //else if ((datetimeShipment.Value.Day >= 15) && (datetimeShipment.Value.Day <= 31))
                //{
                //    cmd.Parameters.AddWithValue("@From", 15);
                //    cmd.Parameters.AddWithValue("@To", 31);
                //}
                //cmd.Parameters.AddWithValue("@Month", datetimeShipment.Value.Month);

                //cmd.CommandType = CommandType.StoredProcedure;
                //con.Open();
                //SqlDataReader reader;
                //reader = cmd.ExecuteReader();
                //DataTable dataTable = new DataTable();
                //dataTable.Load(reader);
                //con.Close();
                //if (dataTable.Rows.Count >= 10)
                //{
                //    MessageBox.Show("10 GC recived which are matching with this Shipment. Go to Generate JSW Bills to bill.");
                //}

                clear();
                LblShipmentID.Text = string.Empty;
                GroupBoxShip.Enabled = false;
            }
            con.Close();
        }

        private void clear()
        {
            TxtShipmentNoRc.ReadOnly = true;
            TxtInvoiceNoRc.ReadOnly = true;
            TxtWagon.ReadOnly = true;
            TxtGrosswt.ReadOnly = true;
            TxtMaterial.ReadOnly = true;
            DdlProduct.Visible = false;
            //DdlFrom.Visible = false;
            DDLParty.Visible = false;
            TxtProduct.Visible = true;
            TxtCustomer.Visible = true;
            TxtProduct.Text = string.Empty;
            TxtShipmentNoRc.Text = string.Empty;
            TxtInvoiceNoRc.Text = string.Empty;
            TxtGCNo.Text = string.Empty;
            TxtGrosswt.Text = string.Empty;
            TxtCustomer.Text = string.Empty;
            TxtWagon.Text = string.Empty;
            TxtMaterial.Text = string.Empty;
            TxtWeighment.Text = string.Empty;
            TxtDiffereceWt.Text = string.Empty;
            DdlVehicle.SelectedIndex = 0;
            DDLTo.SelectedIndex = 0;
            DdlFrom.SelectedIndex = 0;
            DdlUnLoad.SelectedIndex = 0;
            //TxtShipment.Text = string.Empty;
            //TxtInvoiceNo.Text = string.Empty;
            //TxtGCNo .Text = string.Empty;
        }

        private void GetDetails(int type)
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetShipMentDetailsForGCRakeESugam", con);
            cmd.Parameters.AddWithValue("@Material", TxtShipment.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            if (dataTable.Rows.Count > 0)
            {
                GroupBoxShip.Enabled = true;
                TxtShipmentNoRc.Text = Convert.ToString(dataTable.Rows[0]["ShipmentNo"]);
                TxtInvoiceNoRc.Text = Convert.ToString(dataTable.Rows[0]["InvoiceNo"]);
                TxtGCNo.Text = Convert.ToString(dataTable.Rows[0]["GcNo"]);
                if (dataTable.Rows[0]["ShipmentDate"] != DBNull.Value)
                {
                    datetimeShipment.Value = Convert.ToDateTime(dataTable.Rows[0]["ShipmentDate"]).Date;
                }
                if (dataTable.Rows[0]["GcReciveDate"] != DBNull.Value)
                {
                    DtRecive.Value = Convert.ToDateTime(dataTable.Rows[0]["GcReciveDate"]).Date;
                }
                TxtGrosswt.Text = Convert.ToString(dataTable.Rows[0]["NetWt"]);
                LblShipmentID.Text = Convert.ToString(dataTable.Rows[0]["RakeShipmentID"]);
                TxtWagon.Text = Convert.ToString(dataTable.Rows[0]["WagonNo"]);
                TxtMaterial.Text = Convert.ToString(dataTable.Rows[0]["Material"]);
                TxtCustomer.Text = Convert.ToString(dataTable.Rows[0]["PartyName"]);
                DdlCustomer.Text = Convert.ToString(dataTable.Rows[0]["PartyName"]);
                DDLTo.Text = Convert.ToString(dataTable.Rows[0]["DestinationName"]);
                DdlFrom.Text = Convert.ToString(dataTable.Rows[0]["From"]);
                TxtProduct.Text = Convert.ToString(dataTable.Rows[0]["ProductName"]);
                DdlProduct.Text = Convert.ToString(dataTable.Rows[0]["ProductName"]);
                DdlVehicle.Text = Convert.ToString(dataTable.Rows[0]["VehicleNo"]);


                if (string.IsNullOrEmpty(Convert.ToString(dataTable.Rows[0]["Weighment"])))
                {
                    TxtWeighment.Text = Convert.ToString(dataTable.Rows[0]["NetWt"]);
                }
                else
                {
                    TxtWeighment.Text = Convert.ToString(dataTable.Rows[0]["Weighment"]);
                }
                if (dataTable.Rows[0]["UnLoadId"] != DBNull.Value)
                {
                    DdlUnLoad.SelectedValue = Convert.ToString(dataTable.Rows[0]["UnLoadId"]);
                }
            }

            //if (!string.IsNullOrEmpty(LblShipmentID.Text))
            //{
            //    con = new SqlConnection(Connection.InvAdminConn());
            //    cmd = new SqlCommand("GetIsBilled", con);
            //    cmd.Parameters.AddWithValue("@ShipMentID", LblShipmentID.Text);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    con.Open();
            //    reader = cmd.ExecuteReader();
            //     dataTable = new DataTable();
            //    dataTable.Load(reader);
            //    if (dataTable.Rows.Count > 0)
            //    {
            //        MessageBox.Show("This is already Billed in Bill No:" + dataTable.Rows[0]["bill"] + ", Submit Date:" + Convert.ToString(dataTable.Rows[0]["BillDate"]).Substring(0,10));
            //    }
            //}
        }

        private void TxtShipment_TextChanged(object sender, EventArgs e)
        {
            //TxtInvoiceNo.Text = string.Empty;
            //TxtGCNo.Text = string.Empty;
            //LblShipmentID.Text = string.Empty;
            //clear();
            //GetDetails(1);
        }

        private void TxtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            TxtShipment.Text = string.Empty;
            TxtGCNo.Text = string.Empty;
            LblShipmentID.Text = string.Empty;
            clear();
            GetDetails(2);
        }

        private void TxtGCNo_TextChanged(object sender, EventArgs e)
        {
            TxtInvoiceNo.Text = string.Empty;
            TxtShipment.Text = string.Empty;
            LblShipmentID.Text = string.Empty;
            clear();
            GetDetails(3);
        }



        //private void DtRecive_ValueChanged(object sender, EventArgs e)
        //{
        //    if (datetimeShipment.Value <= DtRecive.Value)
        //    {
        //        if (DtRecive.Value.Date == datetimeShipment.Value.Date)
        //        {
        //            TxtActual.Text = "1";
        //        }
        //        else
        //        {
        //            TxtActual.Text = ((DtRecive.Value.Date - datetimeShipment.Value.Date).Days).ToString();
        //        }
        //        if ((Convert.ToInt32(TxtActual.Text)-Convert.ToInt32(TxtAllowed.Text)>0)){
        //        TxtDelay.Text = (Convert.ToInt32(TxtActual.Text)-Convert.ToInt32(TxtAllowed.Text)).ToString();
        //        }
        //        else {
        //        TxtDelay.Text = "0";
        //        }
        //    }
        //    else
        //    {
        //        TxtActual.Text = "0";
        //        TxtDelay.Text = "0";
        //    }
        //}

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void TxtShipmentNoRc_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LblShipmentID.Text))
            {
                TextBox txt = (TextBox)sender;
                txt.ReadOnly = false;
            }
        }

        private void TxtFrom_DoubleClick(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(LblShipmentID.Text))
            //{
            //    TextBox txt = (TextBox)sender;


            //    if (txt.Name == "TxtProduct")
            //    {
            //        TxtProduct.Visible = false;
            //        DdlProduct.Visible = true;
            //        DdlProduct.Focus();
            //    }
            //    else if (txt.Name == "TxtFrom")
            //    {
            //        DdlFrom.Visible = true;
            //        DdlFrom.Focus();
            //    }
            //    else if (txt.Name == "TxtCustomer")
            //    {
            //        TxtCustomer.Visible = false;
            //        DdlCustomer.Visible = true;
            //        DdlCustomer.Focus();
            //    }
            //}
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

        private void GroupBoxShip_Enter(object sender, EventArgs e)
        {

        }

        private void DdlFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (DdlFrom.SelectedIndex > 0 && DDLTo.SelectedIndex > 0)
            //{
            //    SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            //    SqlCommand cmd = new SqlCommand("GetRakeRate", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@From", DdlFrom.SelectedValue);
            //    cmd.Parameters.AddWithValue("@to", DDLTo.SelectedValue);
            //    cmd.Parameters.AddWithValue("@date", datetimeShipment.Value.Date);
            //    con.Open();
            //    con.Close();

            //    decimal a;
                
            //}
        }

        private void datetimeShipment_ValueChanged(object sender, EventArgs e)
        {
            //if (DdlFrom.SelectedIndex != 0 && DDLTo.SelectedIndex != 0)
            //{
            //    SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            //    SqlCommand cmd = new SqlCommand("GetRakeRate", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@From", DdlFrom.SelectedValue);
            //    cmd.Parameters.AddWithValue("@to", DDLTo.SelectedValue);
            //    cmd.Parameters.AddWithValue("@date", datetimeShipment.Value.Date);
            //    con.Open();
            //    con.Close();

            //    decimal a;
              
            //}
        }

        private void TxtWeighment_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0M;
            if (decimal.TryParse(TxtWeighment.Text, out a))
            {
                TxtDiffereceWt.Text = (Convert.ToDecimal(TxtGrosswt.Text) - Convert.ToDecimal(TxtWeighment.Text)).ToString();
                if (Convert.ToDecimal(TxtDiffereceWt.Text) < 0)
                {
                    TxtDiffereceWt.Text = "0";
                }
            }
            else
            {
                TxtDiffereceWt.Text = "0";
            }
        }

        private void DownloadFile_Click(object sender, EventArgs e)
        {
            string filename = "D:\\RAke\\GcRecive\\GcRecive_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_');
            System.IO.Directory.CreateDirectory("D:\\RAke\\GcRecive");
            System.IO.FileInfo excel = new System.IO.FileInfo(filename + ".xlsx");

            if (excel.Exists)
            {
                excel.Delete();
            }
            using (var xls = new ExcelPackage(excel))
            {
                var sheet = xls.Workbook.Worksheets.Add("GcRecive");
                sheet.Cells["A1"].Value = "Invoice No";
                sheet.Cells["B1"].Value = "To";
                sheet.Cells["C1"].Value = "Gc No";
                sheet.Cells["D1"].Value = "UnLoad";
                sheet.Cells["E1"].Value = "Recive date";
                sheet.Cells["F1"].Value = "Vehicle No";
                sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                sheet.Column(1).Width = 20;
                sheet.Column(2).Width = 20;
                sheet.Column(3).Width = 20;
                sheet.Column(4).Width = 20;
                sheet.Column(5).Width = 20;
                sheet.Column(6).Width = 20;


                //Get the final row for the column in the worksheet
                int finalrows = sheet.Dimension.End.Row;


                sheet.Cells["A1:F" + finalrows.ToString()].Style.WrapText = true;
                sheet.Cells["A1:F1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["A1:F1"].Style.Font.Size = 12;

                sheet.Cells["A1:F1"].Style.Font.Bold = true;
                sheet.Cells["A1:F1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                sheet.Cells["A1:F1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);

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
                //validation = sheet.DataValidations.AddListValidation("K2");
                //validation.Formula.ExcelFormula = (ExcelDropdown(ds.Tables[2], "Product Name"));

                //var Customer = xls.Workbook.Worksheets.Add("Customer");
                //for (int dr = 1; dr <= ds.Tables[3].Rows.Count; dr++)
                //{
                //    Customer.Cells["A" + dr].Value = ds.Tables[3].Rows[dr - 1]["Party Name"];
                //}

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

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = true;
            op.ShowDialog();
            TxtUploadfile.Text = op.FileName;
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
                string filename = "D:\\Rake\\GcRecive\\GcRecive_Error_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_');
                System.IO.Directory.CreateDirectory("D:\\RAke\\GcRecive");
                System.IO.FileInfo excel = new System.IO.FileInfo(filename + ".xlsx");

                if (excel.Exists)
                {
                    excel.Delete();
                }
                using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Rake\\GcRecive\\GcRecive_Error_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_') + ".xlsx")))
                {
                    pac.Workbook.Worksheets.Add(("GcRecive"), worksheet);
                    pac.Save();
                }
            }
            return ("D:\\Rake\\GcRecive\\GcRecive_Error_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_') + ".xlsx");
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
                sSheetName = "GcRecive$";
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
                        SqlCommand cmd = new SqlCommand("GetVehicleOnName", con);
                        cmd.Parameters.AddWithValue("@VehicleNo", dt.Rows[row]["Vehicle No"]);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                        {
                            string vehicle = DdlVehicle.Text;
                            con = new SqlConnection(Connection.InvAdminConn());
                            cmd = new SqlCommand("InsertVehicle", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@VehicleNo", dt.Rows[row]["Vehicle No"]);
                            cmd.Parameters.AddWithValue("@SplVehicle", 0);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
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

                        DateTime datetime;

                        if (!DateTime.TryParse(Convert.ToString(dt.Rows[row]["Recive date"]), out datetime))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct Recive date" + Environment.NewLine;
                        }

                        con = new SqlConnection(Connection.InvAdminConn());
                        cmd = new SqlCommand("GetInvoiceOnInvoiceNo", con);
                        cmd.Parameters.AddWithValue("@From", dt.Rows[row]["Invoice No"]);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please check Invoice No" + Environment.NewLine;
                        }
                        con.Close();


                        if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Gc No"])))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter Gc No" + Environment.NewLine;
                        }


                        con.Close();
                        int allow = 0;

                        if (errorBit == 0)
                        {
                            con = new SqlConnection(Connection.InvAdminConn());
                            cmd = new SqlCommand("UpdateGcRecivedRakeOnUpload", con);
                            cmd.CommandType = CommandType.StoredProcedure;


                            if (int.TryParse(Convert.ToString(dt.Rows[row]["Invoice No"]), out allow))
                            {
                                cmd.Parameters.AddWithValue("@InvoiceNo", Convert.ToInt32(dt.Rows[row]["Invoice No"]));
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@InvoiceNo", "");
                            }

                            if (int.TryParse(Convert.ToString(dt.Rows[row]["Gc No"]), out allow))
                            {
                                cmd.Parameters.AddWithValue("@GcNo", Convert.ToInt32(dt.Rows[row]["Gc No"]));
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@GcNo", "");
                            }

                            TxtInvoiceNo.Text = Convert.ToString(dt.Rows[row]["Invoice No"]);
                            //cmd.Parameters.AddWithValue("@Material", dt.Rows[row]["Material"]);
                            cmd.Parameters.AddWithValue("@GcReciveDate", Convert.ToDateTime(dt.Rows[row]["Recive date"]));
                            DdlVehicle.Text = Convert.ToString(dt.Rows[row]["Vehicle No"]);
                            DdlUnLoad.Text = Convert.ToString(dt.Rows[row]["UnLoad"]);
                            DDLTo.Text = Convert.ToString(dt.Rows[row]["To"]);
                            DdlFrom_SelectedIndexChanged(this, EventArgs.Empty);
                            cmd.Parameters.AddWithValue("@Vehicle", DdlVehicle.SelectedValue);
                            cmd.Parameters.AddWithValue("@DestinationId", DDLTo.SelectedValue);
                            cmd.Parameters.AddWithValue("@UnLoadId", DdlUnLoad.SelectedValue);
                            con.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                correct += "," + (row + 2);
                            }
                            con.Close();
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
                    MessageBox.Show("Lines at " + correct.Substring(1) + " uploaded succesfully." + Environment.NewLine + " Error at " + error + Environment.NewLine + "Please correct and upload error data at " + clearExcelUploadSuccess(correct));
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
                    MessageBox.Show("Gc Recive details saved succesfully");
                    error = string.Empty;
                    correct = string.Empty;
                }
                clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetDetails(2);
        }
    }
}