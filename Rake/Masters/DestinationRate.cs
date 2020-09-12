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
using OfficeOpenXml.Style;

namespace Rake
{
    public partial class DestinationRate : Form
    {
        DataTable backup = new DataTable();
        string EditId = string.Empty;

        public DestinationRate()
        {
            InitializeComponent();
            IncrementDestinationRate();
            BindDestination();
            BindGrid();
        }

        public void BindDestination()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetDestinationRake", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            DataRow row = dataTable.NewRow();
            row["Destination Name"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);
           
            DDLTo.DataSource =new DataView( dataTable);
            DDLTo.DisplayMember = "Destination Name";
            DDLTo.SelectedIndex = 0;
            DDLTo.ValueMember = "DestinationID";

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

            DDLFrom.DataSource = new DataView(dataTable);
            DDLFrom.DisplayMember = "From";
            DDLFrom.SelectedIndex = 0;
            DDLFrom.ValueMember = "ID";
        }

        public void IncrementDestinationRate()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxDestinationRateIDRake", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtDestinationRateID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

             con = new SqlConnection(Connection.InvAdminConn());
             cmd = new SqlCommand("GetDestinationRateDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            DataRow row = dataTable.NewRow();
            row["Text"] = "-Select-";
            dataTable.Rows.InsertAt(row, 0);
           
            DdlDate.DataSource =new DataView( dataTable);
            DdlDate.DisplayMember = "Text";
            DdlDate.SelectedIndex = 0;
            DdlDate.ValueMember = "Value";
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            decimal a = 0M;
         
             if (DDLFrom.SelectedIndex == 0)
             {
                 MessageBox.Show("Please select From");
                 DDLFrom.Focus();
                 return;
             }
             else if (DDLTo.SelectedIndex == 0)
            {
                MessageBox.Show("Please select To Place");
                DDLTo.Focus();
                return;
            }
             
            else if (string.IsNullOrEmpty(TxtRate.Text))
            {
                MessageBox.Show("Please enter rate");
                TxtRate.Focus();
                return;
            }
            else if (!decimal.TryParse(TxtRate.Text, out a))
            {
                MessageBox.Show("Please enter Correct rate");
                TxtRate.Focus();
                return;
            }

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertDestinationRateRake", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DestinationRate", TxtRate.Text);
                cmd.Parameters.AddWithValue("@DestinationRateTo", DDLTo.SelectedValue);
                cmd.Parameters.AddWithValue("@DestinationRateFrom", DDLFrom.SelectedValue);
                cmd.Parameters.AddWithValue("@DestinationRateFromDate", DtChangeDate.Value.Date);
                cmd.Parameters.AddWithValue("@CB", "");
                cmd.Parameters.AddWithValue("@CD", DateTime.Now);
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Destination Rate Saved Succesfully");
                    IncrementDestinationRate();
                    BindGrid();
                    clear();
                }
                con.Close();
            }
            else if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Rake.Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateDestinationRateRake", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DestinationRateID", TxtDestinationRateID.Text);
                cmd.Parameters.AddWithValue("@DestinationRate", TxtRate.Text);
                cmd.Parameters.AddWithValue("@DestinationRateFrom", DDLFrom.SelectedValue);
                cmd.Parameters.AddWithValue("@DestinationRateTo", DDLTo.SelectedValue);
                cmd.Parameters.AddWithValue("@DestinationRateFromDate", DtChangeDate.Value.Date);
                cmd.Parameters.AddWithValue("@UB", "");
                cmd.Parameters.AddWithValue("@UD", "");
        
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Destination Rate Edited Succesfully");
                    IncrementDestinationRate();
                    BindGrid();
                    clear();
                    EditId = string.Empty;
                }
                con.Close();
            }

        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetDestinationRateRake", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            backup = dataTable;
            GvDestinationRate.DataSource = dataTable;
            this.GvDestinationRate.AllowUserToAddRows = false;
            GvDestinationRate.Columns["DestinationRateFromDate"].Visible = false;
            con.Close(); 
        }

        private void clear()
        {
            TxtRate.Text = string.Empty;
            DDLTo.SelectedIndex = 0;
            DDLFrom.SelectedIndex = 0;
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetDestinationRateOnIdRake", con);
                cmd.Parameters.AddWithValue("@DestinationRateID", EditId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                con.Close();
                if (dataTable.Rows.Count > 0)
                {
                    TxtDestinationRateID.Text = Convert.ToString(dataTable.Rows[0]["DestinationRateID"]);
                    TxtRate.Text = Convert.ToString(dataTable.Rows[0]["DestinationRate"]);
                    DDLTo.SelectedValue = dataTable.Rows[0]["DestinationRateTo"];
                    DDLFrom.SelectedValue = dataTable.Rows[0]["DestinationRateFrom"];
                    DtChangeDate.Value = Convert.ToDateTime(dataTable.Rows[0]["DestinationRateFromDate"]).Date;
                }
            }
        }

        private void GvDestinationRate_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GvDestinationRate.SelectedRows)
            {
                EditId = row.Cells[0].Value.ToString();
            }
        }

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            clear();
            IncrementDestinationRate();
            EditId = string.Empty;
        }


        private void BtnDownload_Click(object sender, EventArgs e)
        {
            string filename = "D:\\Rake\\DestinationRates\\DestinationRates_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_');
            System.IO.Directory.CreateDirectory("D:\\Rake\\DestinationRates");
            System.IO.FileInfo excel = new System.IO.FileInfo(filename + ".xlsx");

            if (excel.Exists)
            {
                excel.Delete();
            }
            using (var xls = new ExcelPackage(excel))
            {
                var sheet = xls.Workbook.Worksheets.Add("DestinationRates");
                sheet.Cells["A1"].Value = "Destination";

                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetRakeFrom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                con.Close();

                char lastchar = 'A';
                sheet.Column(1).Width = 20;
                sheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["A1" ].Style.Font.Size = 12;

                sheet.Cells["A1" ].Style.Font.Bold = true;
                sheet.Cells["A1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                sheet.Cells["A1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                if (dataTable.Rows.Count > 0)
                {
                    for (int row = 0; row < dataTable.Rows.Count; row++)
                    {
                        char nextChar = (char)((int)lastchar + 1);
                        sheet.Cells[nextChar + "1"].Value = dataTable.Rows[row]["From"];

                        sheet.Column(row + 1).Width = 20;

                        sheet.Cells[nextChar + "1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Cells[nextChar + "1"].Style.Font.Size = 12;

                        sheet.Cells[nextChar + "1"].Style.Font.Bold = true;
                        sheet.Cells[nextChar + "1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        sheet.Cells[nextChar + "1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                        lastchar = nextChar;
                    }
                }
                
                con = new SqlConnection(Connection.InvAdminConn());
                 cmd = new SqlCommand("GetDestinationRake", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                 reader = cmd.ExecuteReader();
                 dataTable = new DataTable();
                dataTable.Load(reader);
                con.Close();

                int rowVal = 2;
                if (dataTable.Rows.Count > 0)
                {
                    for (int row = 0; row < dataTable.Rows.Count; row++)
                    {
                       
                        sheet.Cells["A" + rowVal].Value = dataTable.Rows[row]["Destination Name"];
                        rowVal++;

                    }
                }

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
                sSheetName = dtTablesList.Rows[0]["TABLE_NAME"].ToString();
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


                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetRakeFrom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                con.Close();

                //if (dt.Columns.Count-1 < (dataTable.Rows.Count))
                //{
                //    MessageBox.Show("Uploaded file has less Columns than expected");
                //    return;
                //}
                //else if (dt.Columns.Count-1 > (dataTable.Rows.Count))
                //{
                //    MessageBox.Show("Uploaded file has more Columns than expected");
                //    return;
                //}

                string error = string.Empty;
                string correct = string.Empty;
                for (int col = 1; col < dt.Columns.Count; col++)
                {
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    int errorBit = 0;

                    try
                    {

                         con = new SqlConnection(Connection.InvAdminConn());
                         cmd = new SqlCommand("GetDestinationOnNameRake", con);
                        cmd.Parameters.AddWithValue("@DestinationName", dt.Rows[row]["Destination"]);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please check Destination Name in Destination Master" + Environment.NewLine;
                        }
                        con.Close();

                        if ((dt.Rows[row][col]==DBNull.Value) || (string.IsNullOrEmpty(dt.Rows[row][col].ToString())))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter "+dt.Columns[col].ToString()+" Value." + Environment.NewLine;
                        }
                    }
                    catch (Exception ex)
                    {
                        error += ex.Message + Environment.NewLine;
                        continue;
                    }
                }
            }
                //if (error.Length > 0 && correct.Length > 0)
                //{
                //    //clearExcelUploadSuccess(correct);
                //    MessageBox.Show("Lines at " + correct.Substring(1) + " uploaded succesfully." + Environment.NewLine + " Error at " + error);
                //    error = string.Empty;
                //    correct = string.Empty;
                //}
                 if (error.Length > 0)
                {
                    MessageBox.Show(error);
                    error = string.Empty;
                    correct = string.Empty;
                    return;
                }
                //else
                //{
                //    MessageBox.Show("Destination Rates saved succesfully");
                //    error = string.Empty;
                //    correct = string.Empty;
                //}

                 for (int col = 1; col < dt.Columns.Count; col++)
                 {
                     for (int row = 0; row < dt.Rows.Count; row++)
                     {
                         if (Convert.ToDecimal(dt.Rows[row][col]) > 0)
                         {
                             con = new SqlConnection(Connection.InvAdminConn());
                             cmd = new SqlCommand("InsertDestinationRateOnUploadRake", con);
                             cmd.CommandType = CommandType.StoredProcedure;
                             DDLFrom.Text = dt.Columns[col].ToString();
                             cmd.Parameters.AddWithValue("@DestinationRateFrom", DDLFrom.SelectedValue);

                             cmd.Parameters.AddWithValue("@DestinationRate", dt.Rows[row][col]);
                             DDLTo.Text = Convert.ToString(dt.Rows[row]["Destination"]);
                             cmd.Parameters.AddWithValue("@DestinationRateTo", DDLTo.SelectedValue);
                             cmd.Parameters.AddWithValue("@DestinationRateFromDate", DtChangeDate.Value.Date);
                             cmd.Parameters.AddWithValue("@CB", "");
                             cmd.Parameters.AddWithValue("@CD", DateTime.Now);

                             con.Open();

                             if (cmd.ExecuteNonQuery() > 0)
                             {
                                 correct += "," + (row + 1);
                             }
                             else
                             {
                                 error += "Check data at Line No" + (row + 2) + Environment.NewLine;
                             }
                             con.Close();
                         }
                     }
                 }
                 if (error.Length > 0 && correct.Length > 0)
                 {
                     MessageBox.Show("Lines at " + correct.Substring(1) + " uploaded succesfully." + Environment.NewLine + " Error at " + error);
                     error = string.Empty;
                     correct = string.Empty;
                 }
                 else if (error.Length > 0)
                 {
                     MessageBox.Show(error);
                     error = string.Empty;
                     correct = string.Empty;
                     return;
                 }
                 else
                 {
                     MessageBox.Show("Destination Rates saved succesfully");
                     error = string.Empty;
                     correct = string.Empty;
                 }
                IncrementDestinationRate();
                BindGrid();
                clear();
            }
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
           DialogResult rs= MessageBox.Show("Do you want to change rate list of " + DtFrom.Value.Date.ToString().Substring(0, 10) + " to " + DtTo.Value.Date.ToString().Substring(0, 10),"Alert",MessageBoxButtons.YesNo);

           if (rs==DialogResult.Yes)
           {
               SqlConnection con = new SqlConnection(Connection.InvAdminConn());
               SqlCommand cmd = new SqlCommand("UpdateRateRake", con);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@From", DtFrom.Value.Date);
               cmd.Parameters.AddWithValue("@To", DtTo.Value.Date);
               con.Open();
               if (cmd.ExecuteNonQuery() > 0)
               {
                   MessageBox.Show("Date changed succesfully");
               }
               con.Close();
               BindGrid();
           }
        }

        private void TxtPartySearch_TextChanged(object sender, EventArgs e)
        {
            string query = string.Empty;

            if (DdlDate.SelectedIndex > 0)
            {
                query = "[DestinationRateFromDate] ='" + DdlDate.SelectedValue + "'";
            }

            if (!string.IsNullOrEmpty(query))
            {
                query = " and " + query;
            }

            query = "[Rate To] Like '%" + TxtPartySearch.Text + "%'" + query;

            if (DdlDate.SelectedIndex > 0)
            {
                GvDestinationRate.DataSource = backup.Select(query).Any() ? backup.Select(query).CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvDestinationRate.DataSource = backup;
            }
        }

        private void DdlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = string.Empty;

            if (DdlDate.SelectedIndex > 0)
            {
                query = "[DestinationRateFromDate] ='" + DdlDate.SelectedValue + "'";
            }

            if (!string.IsNullOrEmpty(query))
                {
                    query = " and "+query;
                }

            query = "[Rate To] Like '%" + TxtPartySearch.Text + "%'" + query;

            if (DdlDate.SelectedIndex>0)
            {
                GvDestinationRate.DataSource = backup.Select(query).Any() ? backup.Select(query).CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvDestinationRate.DataSource = backup;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)GvDestinationRate.DataSource;
            dt.Columns.Remove("DestinationRateFromDate");

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel File (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 1;

            System.IO.Directory.CreateDirectory("D:\\RakeDestinationRate\\Reports\\");
            using (ExcelPackage pck = new ExcelPackage(new System.IO.FileInfo("D:\\RakeDestinationRate\\Reports\\" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + ".xlsx")))
            {
                {

                    var worksheetCheck = pck.Workbook.Worksheets[Convert.ToString("Rake Rate")];

                    if (worksheetCheck != null)
                    {
                        pck.Workbook.Worksheets.Delete(worksheetCheck);
                    }

                    // Add a new worksheet to the empty workbook
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Rake Rate");
                    // Load data from DataTable to the worksheet
                    ws.Cells["A1"].LoadFromDataTable(((DataTable)GvDestinationRate.DataSource), true);
                    ws.Cells.AutoFitColumns();

                    // Add some styling
                    using (ExcelRange rng = ws.Cells[1, 1, 1, dt.Columns.Count])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                        rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    }

                    // Save the workbook to file
                    pck.Save();
                }
                DialogResult ans = MessageBox.Show("File Downloaded at " + "D:\\RakeDestinationRate\\Reports\\" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + ".xlsx" + Environment.NewLine + "Do you want to open?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("D:\\RakeDestinationRate\\Reports\\" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + ".xlsx");
                }
            }
        }
    }
}
