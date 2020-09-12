using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rake
{
    public partial class GCData : Form
    {
        DataTable backup = new DataTable();

        public GCData()
        {
            InitializeComponent();
            BindGrid();
        }

        private void DownloadFile_Click(object sender, EventArgs e)
        {
            string filename = "D:\\RAke\\GCData\\GCData_" + DateTime.Now.ToString("dd/MMM/yy_hh_mm");
            System.IO.Directory.CreateDirectory("D:\\RAke\\GCData");
            System.IO.FileInfo excel = new System.IO.FileInfo(filename + ".xlsx");

            if (excel.Exists)
            {
                excel.Delete();
            }
            using (var xls = new ExcelPackage(excel))
            {
                var sheet = xls.Workbook.Worksheets.Add("GCData");
                sheet.Cells["A1"].Value = "WagonNo";
                sheet.Cells["B1"].Value = "Material";
                sheet.Cells["C1"].Value = "Customer";
                sheet.Cells["D1"].Value = "Product";
                sheet.Cells["E1"].Value = "Gross Wt";
                sheet.Cells["F1"].Value = "Thickness";
                sheet.Cells["G1"].Value = "Width";
                sheet.Cells["H1"].Value = "In Value";
                sheet.Cells["I1"].Value = "Month";
                sheet.Cells["J1"].Value = "Invoice No";
                sheet.Cells["K1"].Value = "UnLoad";
                sheet.Cells["L1"].Value = "Rake No";
                sheet.Cells["M1"].Value = "Rake Type";
                sheet.Cells["N1"].Value = "From";
                sheet.Cells["O1"].Value = "To";
                sheet.Cells["P1"].Value = "ODN No";
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

                //Get the final row for the column in the worksheet
                int finalrows = sheet.Dimension.End.Row;


                sheet.Cells["A1:P" + finalrows.ToString()].Style.WrapText = true;
                sheet.Cells["A1:P1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["A1:P1"].Style.Font.Size = 12;

                sheet.Cells["A1:P1"].Style.Font.Bold = true;
                sheet.Cells["A1:P1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                sheet.Cells["A1:P1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);

                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("ShipmentDropDownRakeGcRecive", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                con.Close();

                var sheetProduct = xls.Workbook.Worksheets.Add("Product Name");
                for (int dr = 1; dr <= ds.Tables[3].Rows.Count; dr++)
                {
                    sheetProduct.Cells["A" + dr].Value = ds.Tables[3].Rows[dr - 1]["Product Name"];
                }

                var Customer = xls.Workbook.Worksheets.Add("Customer");
                for (int dr = 1; dr <= ds.Tables[4].Rows.Count; dr++)
                {
                    Customer.Cells["A" + dr].Value = ds.Tables[4].Rows[dr - 1]["Party Name"];
                }

                var sheetDestination = xls.Workbook.Worksheets.Add("Destination Name");
                for (int dr = 1; dr <= ds.Tables[1].Rows.Count; dr++)
                {
                    sheetDestination.Cells["A" + dr].Value = ds.Tables[1].Rows[dr - 1]["Destination Name"];
                }

                var UnLoad = xls.Workbook.Worksheets.Add("UnLoad");
                for (int dr = 1; dr <= ds.Tables[2].Rows.Count; dr++)
                {
                    UnLoad.Cells["A" + dr].Value = ds.Tables[2].Rows[dr - 1]["UnLoadName"];
                }

                var From = xls.Workbook.Worksheets.Add("From");
                for (int dr = 1; dr <= ds.Tables[5].Rows.Count; dr++)
                {
                    From.Cells["A" + dr].Value = ds.Tables[5].Rows[dr - 1]["From"];
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
                sSheetName = "GCData$";
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

                        //con = new SqlConnection(Connection.InvAdminConn());
                        //cmd = new SqlCommand("GetToOnName", con);
                        //cmd.Parameters.AddWithValue("@From", dt.Rows[row]["To"]);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //con.Open();
                        //if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                        //{
                        //    if (errorBit == 0)
                        //    {
                        //        error += "Line No " + (row + 2) + Environment.NewLine;
                        //        errorBit = 1;
                        //    }
                        //    error += "    Please check To in Destination Master" + Environment.NewLine;
                        //}
                        //con.Close();

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

                        if (!DateTime.TryParse(Convert.ToString(dt.Rows[row]["Month"]), out datetime))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct Month" + Environment.NewLine;
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

                        if (!decimal.TryParse(Convert.ToString(dt.Rows[row]["Width"]), out dec))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct Width" + Environment.NewLine;
                        }

                        if (!decimal.TryParse(Convert.ToString(dt.Rows[row]["Thickness"]), out dec))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct Thickness" + Environment.NewLine;
                        }

                        if (!decimal.TryParse(Convert.ToString(dt.Rows[row]["In Value"]), out dec))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct In Value" + Environment.NewLine;
                        }

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

                        int allow = 0;

                        if (errorBit == 0)
                        {
                            con = new SqlConnection(Connection.InvAdminConn());
                            cmd = new SqlCommand("InsertGCDetailsOnUploadRake", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            //if (int.TryParse(Convert.ToString(dt.Rows[row]["Shipment No"]), out allow))
                            //{
                            //    cmd.Parameters.AddWithValue("@ShipmentNo", Convert.ToInt32(dt.Rows[row]["Shipment No"]));
                            //}
                            //else
                            //{
                            //    cmd.Parameters.AddWithValue("@ShipmentNo", "");
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
                            else
                            {
                                cmd.Parameters.AddWithValue("@Material", dt.Rows[row]["Material"]);
                            }

                            cmd.Parameters.AddWithValue("@UnLoad", dt.Rows[row]["UnLoad"]);
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
                            cmd.Parameters.AddWithValue("@To", dt.Rows[row]["To"]);
                            cmd.Parameters.AddWithValue("@Month", dt.Rows[row]["Month"]);
                            cmd.Parameters.AddWithValue("@CB", "");
                            cmd.Parameters.AddWithValue("@CD", DateTime.Now);
                            cmd.Parameters.AddWithValue("@OdnNo", dt.Rows[row]["ODN No"]);

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
                    MessageBox.Show("Shipment details saved succesfully");
                    error = string.Empty;
                    correct = string.Empty;
                }
                BindGrid();
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
                string filename = "D:\\Rake\\GCData\\GCData_Error_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_');
                System.IO.Directory.CreateDirectory("D:\\RAke\\GCData");
                System.IO.FileInfo excel = new System.IO.FileInfo(filename + ".xlsx");

                if (excel.Exists)
                {
                    excel.Delete();
                }
                using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Rake\\GCData\\GCData_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_') + ".xlsx")))
                {
                    pac.Workbook.Worksheets.Add(("GCData"), worksheet);
                    pac.Save();
                }
            }
            return ("D:\\Rake\\GCData\\GCData_Error_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_') + ".xlsx");
        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetGCDateRake", con);
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

        private void TxtShipmentSearch_TextChanged(object sender, EventArgs e)
        {
           
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


    }
}
