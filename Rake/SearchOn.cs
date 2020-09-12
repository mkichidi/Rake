using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;
using System.Diagnostics;
using DevExpress.XtraEditors.Repository;

namespace Rake
{
    public partial class SearchOn : Form
    {

        public SearchOn()
        {
            InitializeComponent();
            BindDropdowns();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.P))
            {
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                byte[] bytes = reportViewer1.LocalReport.Render(
                   "PDF", null, out mimeType, out encoding, out extension,
                   out streamids, out warnings);

                FileStream fs = new FileStream(@"d:\output.pdf", FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();

                ProcessStartInfo info = new ProcessStartInfo();
                info.Verb = "print";
                info.FileName = @"d:\output.pdf";
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                Process p = new Process();
                p.StartInfo = info;
                p.Start();

                p.WaitForInputIdle();
                System.Threading.Thread.Sleep(3000);
                if (false == p.CloseMainWindow())
                    p.Kill();

                System.IO.FileInfo pdf = new System.IO.FileInfo(@"d:\output.pdf");

                if (pdf.Exists)
                {
                    pdf.Delete();
                }
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public DataTable BindGrid()
        {
            SqlDataReader reader;
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("SearchOnRake", con);
            cmd.CommandTimeout = 1000000000;
            cmd.Parameters.AddWithValue("@From", DtFrom.Value.Date.Date);
            cmd.Parameters.AddWithValue("@to", dtTo.Value.Date.Date);

            //if (DdlDestination.Text.Contains("-ALL-"))
            //{
            //    DataTable dt = new DataTable();
            //    dt = (DataTable)DdlDestination.DataSource;
            //    string destination = string.Empty;
            //    for (int i = 2; i < DdlDestination.Items.Count; i++)
            //    {
            //        destination += "," + DdlDestination.Items[i];
            //    }
            //    cmd.Parameters.AddWithValue("@Destination", destination.Substring(1));
            //}
            //else
            //{
            cmd.Parameters.AddWithValue("@Destination", DdlDestination.Text.Replace(", ", ","));
            if ((!string.IsNullOrEmpty(DdlOwnTransport.Text)) && (!string.IsNullOrEmpty(DdlTransport.Text)))
            {
                cmd.Parameters.AddWithValue("@OwnTransport", DdlOwnTransport.Text.Replace(", ", ",") + "," + DdlTransport.Text.Replace(", ", ","));
            }
            else if (!string.IsNullOrEmpty(DdlOwnTransport.Text))
            {
                cmd.Parameters.AddWithValue("@OwnTransport", DdlOwnTransport.Text.Replace(", ", ","));
            }
            else if (!string.IsNullOrEmpty(DdlTransport.Text))
            {
                cmd.Parameters.AddWithValue("@OwnTransport", DdlTransport.Text.Replace(", ", ","));
            }
            ////}
                cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.Text.Replace(", ", ","));

            //if (CmbProduct.Text.Contains("-ALL-"))
            //{
            //    DataTable dt = new DataTable();
            //    dt = (DataTable)CmbProduct.DataSource;
            //    string product = string.Empty;
            //    for (int i = 2; i < CmbProduct.Items.Count; i++)
            //    {
            //        product += "," + CmbProduct.Items[i];
            //    }
            //    cmd.Parameters.AddWithValue("@Product", product.Substring(1));
            //}
            //else
            //{
                cmd.Parameters.AddWithValue("@Product", CmbProduct.Text.Replace(", ", ","));
            //}

            //if (DdlCustomer.Text.Contains("-ALL-"))
            //{
            //    DataTable dt = new DataTable();
            //    dt = (DataTable)DdlCustomer.DataSource;
            //    string customer = string.Empty;
            //    for (int i = 2; i < DdlCustomer.Items.Count; i++)
            //    {
            //        customer += "," + DdlCustomer.Items[i];
            //    }
            //    cmd.Parameters.AddWithValue("@Party", customer.Substring(1));
            //}
            //else
            //{
                cmd.Parameters.AddWithValue("@Party", DdlCustomer.Text.Replace(", ", ","));
            //}

            //if (DdlVehicle.Text.Contains("-ALL-"))
            //{
            //    DataTable dt = new DataTable();
            //    dt = (DataTable)DdlVehicle.DataSource;
            //    string vehicle = string.Empty;
            //    for (int i = 2; i < DdlVehicle.Items.Count; i++)
            //    {
            //        vehicle += "," + DdlVehicle.Items[i];
            //    }
            //    cmd.Parameters.AddWithValue("@Vehicle", vehicle.Substring(1));
            //}
            //else
            //{
                cmd.Parameters.AddWithValue("@Vehicle", DdlVehicle.Text.Replace(", ", ","));

            string sts=string.Empty;
         foreach(int str in   DdlFrom.Properties.GetItems().GetCheckedValues())
         {
             sts += str.ToString() +',';
         }

         if (sts.Length > 0)
         {
             cmd.Parameters.AddWithValue("@FromPlace", sts.Substring(0, sts.Length - 1));
         }
            //}

            //if (DdlSplVehicle.Text.Contains("-ALL-"))
            //{
            //    DataTable dt = new DataTable();
            //    dt = (DataTable)DdlSplVehicle.DataSource;
            //    string vehicle = string.Empty;
            //    for (int i = 2; i < DdlSplVehicle.Items.Count; i++)
            //    {
            //        vehicle += "," + DdlSplVehicle.Items[i];
            //    }
            //    cmd.Parameters.AddWithValue("@SplVehicle", vehicle.Substring(1));
            //}
            //else
            //{
                //cmd.Parameters.AddWithValue("@SplVehicle", DdlSplVehicle.Text.Replace(", ", ","));
            //}

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            return dataTable;
        }

        public DataTable BindGridOnSearch()
        {
            SqlDataReader reader;
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("SearchOnRakeOnSGI", con);

            cmd.Parameters.AddWithValue("@InvoiceNo", TxtInvoiceSearch.Text);
            cmd.Parameters.AddWithValue("@GcNo", TxtGcNoSearch.Text);
            cmd.Parameters.AddWithValue("@Bill", TxtBillNo.Text);

          
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            return dataTable;

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

            
            SqlDataReader reader;
            DataTable dataTable = new DataTable();
           

            //DdlDestination.Items.Add("-ALL-");


            //foreach (DataRow dr in dataTable.Rows)
            //{
            //    DdlDestination.Items.Add(dr["Destination Name"]);
            //    DdlDestination.Properties.Items.Add(dr["Destination Name"], CheckState.Unchecked, true);
            //}
            //Cmb.
            //RepositoryItemCheckedComboBoxEdit rr = new RepositoryItemCheckedComboBoxEdit();
            //rr.IncrementalSearch = true;
            //Cmb.Properties.Items.Add ( rr);
            //con.Close();

            dataTable = ds.Tables[1].Select("", "[Destination Name] ASC").CopyToDataTable();

            DdlDestination.Properties.DataSource = dataTable;
            DdlDestination.Properties.DisplayMember = "Destination Name";
            DdlDestination.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            DdlDestination.Properties.IncrementalSearch = true;
            DdlDestination.KeyDown += new KeyEventHandler(checkedComboBoxEdit1_KeyDown);

            //CmbProduct.Items.Add("-ALL-");
            //foreach (DataRow dr in ds.Tables[2].Rows)
            //{
            //    CmbProduct.Items.Add(dr["Product Name"]);
            //}

            //DdlCustomer.Items.Add("-ALL-");
            //foreach (DataRow dr in ds.Tables[3].Rows)
            //{
            //    DdlCustomer.Items.Add(dr["Party Name"]);
            //}

            //DdlVehicle.Items.Add("-ALL-");
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    DdlVehicle.Items.Add(dr["VehicleNo"]);
            //}
            dataTable = new DataTable();
            dataTable = ds.Tables[2].Select("", "[Product Name] ASC").CopyToDataTable(); 

            CmbProduct.Properties.DataSource = dataTable;
            CmbProduct.Properties.DisplayMember = "Product Name";
            CmbProduct.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            CmbProduct.Properties.IncrementalSearch = true;
            CmbProduct.KeyDown += new KeyEventHandler(checkedComboBoxEdit1_KeyDown);
            
            dataTable = new DataTable();
            dataTable = ds.Tables[3].Select("", "[Party Name] ASC").CopyToDataTable(); 

            DdlCustomer.Properties.DataSource = dataTable;
            DdlCustomer.Properties.DisplayMember = "Party Name";
            DdlCustomer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            DdlCustomer.Properties.IncrementalSearch = true;
            DdlCustomer.KeyDown += new KeyEventHandler(checkedComboBoxEdit1_KeyDown);

            dataTable = new DataTable();
            dataTable = ds.Tables[0].Select("", "[VehicleNo] ASC").CopyToDataTable();

            DdlVehicle.Properties.DataSource = dataTable;
            DdlVehicle.Properties.DisplayMember = "VehicleNo";
            DdlVehicle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            DdlVehicle.Properties.IncrementalSearch = true;
            DdlVehicle.KeyDown += new KeyEventHandler(checkedComboBoxEdit1_KeyDown);

             con = new SqlConnection(Connection.InvAdminConn());
             cmd = new SqlCommand("GetRakeType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
             reader = cmd.ExecuteReader();
             dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            DataView dv = dataTable.DefaultView;
            dv.Sort = "RakeTypeName asc";
            dataTable = dv.ToTable();

            DdlRakeType.Properties.DataSource = dataTable;
            DdlRakeType.Properties.DisplayMember = "RakeTypeName";
            DdlRakeType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            DdlRakeType.Properties.IncrementalSearch = true;
            DdlRakeType.KeyDown += new KeyEventHandler(checkedComboBoxEdit1_KeyDown);

            //con = new SqlConnection(Connection.InvAdminConn());
            //cmd = new SqlCommand("GetSplvehicles", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //con.Open();
            //reader = cmd.ExecuteReader();
            //dataTable = new DataTable();
            //dataTable.Load(reader);
            //dataTable = dataTable.Select("", "VehicleNo ASC").CopyToDataTable(); ;

            ////DdlSplVehicle.Items.Add("-ALL-");

            ////foreach (DataRow dr in dataTable.Rows)
            ////{
            ////    DdlSplVehicle.Items.Add(dr["VehicleNo"]);
            ////}

            //DdlSplVehicle.Properties.DataSource = dataTable;
            //DdlSplVehicle.Properties.DisplayMember = "VehicleNo";
            //DdlSplVehicle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            //DdlSplVehicle.Properties.IncrementalSearch = true;
            //DdlSplVehicle.KeyDown += new KeyEventHandler(checkedComboBoxEdit1_KeyDown);

            //con.Close();

            dv = ds.Tables[5].DefaultView;
            dv.Sort = "TransportName asc";
            dataTable = dv.ToTable();

            DdlTransport.Properties.DataSource = ds.Tables[5];
            DdlTransport.Properties.DisplayMember = "TransportName";
            DdlTransport.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            DdlTransport.Properties.IncrementalSearch = true;
            DdlTransport.KeyDown += new KeyEventHandler(checkedComboBoxEdit1_KeyDown);
            con.Close();

            dv = ds.Tables[4].DefaultView;
            dv.Sort = "TransportName asc";
            dataTable = dv.ToTable();

            DdlOwnTransport.Properties.DataSource = ds.Tables[4];
            DdlOwnTransport.Properties.DisplayMember = "TransportName";
            DdlOwnTransport.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            DdlOwnTransport.Properties.IncrementalSearch = true;
            DdlOwnTransport.KeyDown += new KeyEventHandler(checkedComboBoxEdit1_KeyDown);
            con.Close();

            dataTable = new DataTable();
            dataTable = ds.Tables[6].Select("", "[From] ASC").CopyToDataTable();

            DdlFrom.Properties.DataSource = dataTable;
            DdlFrom.Properties.DisplayMember = "From";
            DdlFrom.Properties.ValueMember = "ID";
            DdlFrom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            DdlFrom.Properties.IncrementalSearch = true;
            DdlFrom.KeyDown += new KeyEventHandler(checkedComboBoxEdit1_KeyDown);
        }

        void checkedComboBoxEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((DevExpress.XtraEditors.CheckedComboBoxEdit)sender).IsPopupOpen)
                ((DevExpress.XtraEditors.CheckedComboBoxEdit)sender).ShowPopup();
        }

        private void TSxtSearch_Click(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("Search", BindGrid());
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private void TxtShipmentSearch_TextChanged(object sender, EventArgs e)
        {
            TxtInvoiceSearch.Text = string.Empty;
            TxtBillNo.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = reportViewer1.LocalReport.Render(
               "EXCELOPENXML", null, out mimeType, out encoding, out extension,
               out streamids, out warnings);

            FileStream fs = new FileStream(@"d:\output.xlsx", FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(@"d:\output.xlsx")))
            {
                var worksheet = package.Workbook.Worksheets[1];
                System.IO.Directory.CreateDirectory("D:\\Rake\\Search\\");
                System.IO.FileInfo excels = new System.IO.FileInfo(@"D:\\Rake\\Search\\" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + ".xlsx"); 
                if (excels.Exists)
                {
                    excels.Delete();
                }
                using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Rake\\Search\\" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + ".xlsx")))
                {
                    var worksheetCheck = pac.Workbook.Worksheets[Convert.ToString("SearchOnAll")];

                    if (worksheetCheck == null)
                    {

                        pac.Workbook.Worksheets.Add((Convert.ToString("SearchOnAll")), worksheet);
                        pac.Save();
                    }
                    else
                    {
                        pac.Workbook.Worksheets.Delete(worksheetCheck);
                        pac.Workbook.Worksheets.Add((Convert.ToString("SearchOnAll")), worksheet);
                    }
                    DialogResult ans = MessageBox.Show("File Downloaded at " + "D:\\Rake\\Search\\" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + ".xlsx" + Environment.NewLine + "Do you want to open?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ans == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("D:\\Rake\\Search\\" + DateTime.Now.Date.ToShortDateString().Replace("/", "-") + ".xlsx");
                    }
                }
            }
            System.IO.FileInfo excel = new System.IO.FileInfo(@"d:\output.xlsx");

            if (excel.Exists)
            {
                excel.Delete();
            }
        }

        private void TxtBillNo_TextChanged(object sender, EventArgs e)
        {
            TxtInvoiceSearch.Text = string.Empty;
            TxtGcNoSearch.Text = string.Empty;
            
        }

        private void TxtInvoiceSearch_TextChanged(object sender, EventArgs e)
        {
            TxtBillNo.Text = string.Empty;
            TxtGcNoSearch.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("Search", BindGridOnSearch());
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
