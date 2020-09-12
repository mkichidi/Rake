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
using System.Globalization;

namespace Rake
{
    public partial class RakeSummary : Form
    {
        string rake = string.Empty;
        string monthYear = string.Empty;
        string rakeTypeId = string.Empty;
        DataTable dtDetails;
        DataTable backup = new DataTable();

        public RakeSummary()
        {
            InitializeComponent();

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("0", "-All-");
            comboSource.Add("1", "Jan");
            comboSource.Add("2", "Feb");
            comboSource.Add("3", "Mar");
            comboSource.Add("4", "Apr");
            comboSource.Add("5", "May");
            comboSource.Add("6", "Jun");
            comboSource.Add("7", "Jul");
            comboSource.Add("8", "Aug");
            comboSource.Add("9", "Sep");
            comboSource.Add("10", "Oct");
            comboSource.Add("11", "Nov");
            comboSource.Add("12", "Dec");
            DDLMonth.DataSource = new BindingSource(comboSource, null);
            DDLMonth.DisplayMember = "Value";
            DDLMonth.ValueMember = "Key";

            DDLYear.SelectedIndex = 0;
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            DataRow row = dataTable.NewRow();
            row["RakeTypeName"] = "-All-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);

            DdlRakeType.DataSource = new DataView(dataTable);
            DdlRakeType.DisplayMember = "RakeTypeName";
            DdlRakeType.SelectedIndex = 0;
            DdlRakeType.ValueMember = "RakeTypeID";
        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeBillSummary", con);
            if (DDLMonth.SelectedIndex > 0)
            {
                cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            }

            if (DDLYear.SelectedIndex > 0)
            {
                cmd.Parameters.AddWithValue("@Year", DDLYear.Text);
            }

            if (DdlRakeType.SelectedIndex > 0)
            {
                cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
            }

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            GvRakeBill.DataSource = dataTable;
            backup = dataTable;
            this.GvRakeBill.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DDLMonth.SelectedIndex < 0)
            {
                MessageBox.Show("Please select Month");
                DDLMonth.Focus();
                return;
            }
            else if (DDLYear.SelectedIndex < 0)
            {
                MessageBox.Show("Please select Year");
                DDLYear.Focus();
                return;
            }
            else if (DdlRakeType.SelectedIndex < 0)
            {
                MessageBox.Show("Please select Rake Type");
                DdlRakeType.Focus();
                return;
            }
            BindGrid();
        }

        private void CtrlBtnPrintBill_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)GvRakeBill.DataSource;

            if (dt == null||dt.Rows.Count < 1)
            {
                MessageBox.Show("Please select shipment to bill");
                return;
            }
            dt.AcceptChanges();
            DataTable dataTable = new DataTable();

            if (DDLMonth.SelectedIndex > 0 && DDLMonth.SelectedIndex > 0)
            {
                SqlConnection cons = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmds = new SqlCommand("GetRakeWorkOrderOnDate", cons);
                cmds.CommandType = CommandType.StoredProcedure;
                cmds.Parameters.AddWithValue("@Date", Convert.ToDateTime("01/" + DDLMonth.Text + "/" + DDLYear.Text).Date);
                cons.Open();

                SqlDataReader reader;
                reader = cmds.ExecuteReader();
                dataTable.Load(reader);
                cons.Close();
            }
            if (dataTable.Rows.Count > 0)
            {
                SqlConnection cons = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmds = new SqlCommand("GetRakeFinancialYear", cons);
                cmds.CommandType = CommandType.StoredProcedure;
                cmds.Parameters.AddWithValue("@Date", dtSubmitDate.Value.Date);
                cons.Open();
                RakeDatatable.financialYear = Convert.ToString(cmds.ExecuteScalar());
                cons.Close();

             if (Convert.ToInt32(dataTable.Rows[0]["ID"])>3)
             {
                 dt.Columns[0].ReadOnly = false;
                 foreach (DataRow dr in dt.Rows)
                 {
                     dr["Bill"] = "R" + dr["Bill"];
                 }
             }

            }

            if (ChkAll.Checked)
            {
                //if (dt.Rows.Count > 0)
                //{
                //    DataTable dtRakeMonth = new DataTable();
                //    dtRakeMonth=dt.DefaultView.ToTable(true, "RakeMonth");

                //    if (dtRakeMonth.Rows.Count > 0)
                //    {
                //        dt.Columns.Add("RakeMonthValue", typeof(System.Int32));

                //        string count = "0";
                //        foreach (DataRow dr in dtRakeMonth.Rows)
                //        {
                //            foreach (DataRow drs in dt.Select("RakeMonth='" + dr["RakeMonth"]+"'"))
                //            {
                //                drs["RakeMonthValue"] = count;
                //            }
                //            count =Convert.ToString( Convert.ToInt32(count) + 1);
                //        }
                //    }
                //    else
                //    {
                //        dt.Columns.Add("RakeMonthValue", typeof(System.Int32));
                //        dt.Columns["RakeMonthValue"].Expression = "0";
                //    }
                //}


                RakeDatatable.dt = dt;
                Rake.Reports.Reports.RakeSummary RakeSummary = new Rake.Reports.Reports.RakeSummary();
                RakeSummary.Show();
                RakeDatatable.dt = new DataTable();
            }
            else
            {

            DataTable dtData = new DataTable();
            //dt.Columns.Add("RakeMonthValue", typeof(System.Int32));
            //dt.Columns["RakeMonthValue"].Expression = "0";
                dtData = dt.Clone();
                RakeDatatable.shipmentNo = DDLMonth.Text + " " + DDLYear.Text;
                RakeDatatable.submitDate = dtSubmitDate.Value.Date;                
            if (dt.DefaultView.ToTable(true, "Rake").Rows.Count > 1)
            {
                DataTable dtRakes=new DataTable();
                dtRakes = dt.DefaultView.ToTable(true, "Rake");
                for (int i = 0; i < dtRakes.Rows.Count; i=i+1)
                {
                    dtData.Rows.Clear();

                     for(int j = 0; j < 1; j++)
                     {
                         if (dtRakes.Rows.Count > (i + j))
                         {
                             foreach (DataRow dr in dt.Select("Rake ='" + dtRakes.Rows[i + j]["Rake"] + "'"))
                             {
                                 dtData.Rows.Add(dr.ItemArray);
                             }
                         }
                     }
                     RakeDatatable.dt = new DataTable();

                     RakeDatatable.dt = dtData;
                     Rake.Reports.Reports.RakeSummaryIndividual RakeSummary = new Rake.Reports.Reports.RakeSummaryIndividual();
                     RakeSummary.Show();
                     System.Threading.Thread.Sleep(1000);
                }
            }
            else
            {
                RakeDatatable.dt = dt;
                Rake.Reports.Reports.RakeSummaryIndividual RakeSummary = new Rake.Reports.Reports.RakeSummaryIndividual();
                RakeSummary.Show();
                RakeDatatable.dt = new DataTable();
            }

            }

        }

        private void GvRakeBill_SelectionChanged(object sender, EventArgs e)
        {
          if(GvRakeBill.Rows.Count>0)
          {
              foreach (DataGridViewRow row in GvRakeBill.SelectedRows)
              {
                  rake = row.Cells[4].Value.ToString();
                  monthYear = row.Cells[5].Value.ToString();
                  break;
              }
          }
        }

        private void BtnGetBills_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rake) && string.IsNullOrEmpty(monthYear))
            {
                MessageBox.Show("Please select bill to generate");
                return;
            }

            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeNoOnType", con);
            cmd.Parameters.AddWithValue("@RakeName", rake.Split('-')[0]);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            rakeTypeId =Convert.ToString(cmd.ExecuteScalar());
            con.Close();


             con = new SqlConnection(Connection.InvAdminConn());
             cmd = new SqlCommand("GetRakeBill", con);
             cmd.Parameters.AddWithValue("@Month", (DateTime.ParseExact(monthYear.Split('-')[1].Split(' ')[0], "MMMM", CultureInfo.InvariantCulture).Month));
            cmd.Parameters.AddWithValue("@Year", monthYear.Split('-')[0]);
            cmd.Parameters.AddWithValue("@RakeType", rakeTypeId);
            cmd.Parameters.AddWithValue("@RakeNo", rake.Split('-')[1]);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();

            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("GetRakeBillDetails", con);
            cmd.Parameters.AddWithValue("@Month", (DateTime.ParseExact(monthYear.Split('-')[1].Split(' ')[0], "MMMM", CultureInfo.InvariantCulture).Month));
            cmd.Parameters.AddWithValue("@Year", monthYear.Split('-')[0]);
            cmd.Parameters.AddWithValue("@RakeType", rakeTypeId);
            cmd.Parameters.AddWithValue("@RakeNo", rake.Split('-')[1]);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            dtDetails = new DataTable();
            dtDetails.Load(reader);
            con.Close();



            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                dt.Rows.Add(dr.ItemArray);
            }
            DataColumn dc = new DataColumn("SlNo");
            dc.DataType = typeof(int);
            dt.Columns.Add(dc);

            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                dt.Rows[i - 1]["SlNo"] = i;
            }

            DataTable dtFrom = dt.DefaultView.ToTable(true, "FromId");
            if (dtFrom.Rows.Count > 1)
            {
                DataView dv = dtFrom.DefaultView;
                dv.Sort = "FromId";
                dtFrom = new DataTable();
                dtFrom = dv.ToTable();
                foreach (DataRow dr in dtFrom.Rows)
                {
                    PrintBills(dt.Select("FromId ='" + dr["FromId"] + "'").CopyToDataTable(), Convert.ToInt32(dr["FromId"]));
                }
            }
            else
            {
                PrintBills(dt, Convert.ToInt32(dt.Rows[0]["FromId"]));
            }

            if (dt.Select("ProductName ='TMT'").Count() > 0)
            {
                RakeDatatable.dt = dt.Select("ProductName ='TMT'").CopyToDataTable();

                Rake.Reports.Reports.TMT TMT = new Rake.Reports.Reports.TMT();
                TMT.Show();
                RakeDatatable.dt = new DataTable();
            }
        }

        protected void PrintBills(DataTable dt, int fromId)
        {
            DataTable dtComplete = new DataTable();

            dtComplete = dt.Clone();
            dtComplete.Constraints.Clear();

            DataTable summary = new DataTable();
            summary.Columns.Add("Customer", typeof(String));
            summary.Columns.Add("NetWt", typeof(decimal));
            summary.Columns.Add("Rate", typeof(decimal));
            summary.Columns.Add("Amount", typeof(int));
            summary.Columns.Add("UnLoad", typeof(String));
            summary.Columns.Add("ProductName", typeof(String));
            summary.Columns.Add("Nos", typeof(int));

            DataTable dtTmt = new DataTable();


            DataTable dvParty = new DataTable();
            dvParty = dt.DefaultView.ToTable(true, "Customer");
            //dvParty =(DataTable) (from r in dt.AsEnumerable()
            //select r["Customer"]).Distinct();

            foreach (DataRow dr in dvParty.Rows)
            {
                DataTable dtonDestination = dt.DefaultView.ToTable(true, "Destination");
                if (dtonDestination.Rows.Count > 0)
                {
                    foreach (DataRow drDes in dtonDestination.Rows)
                    {
                        if (dt.Select("Customer ='" + dr["Customer"] + "' and " + "Destination ='" + drDes["Destination"] + "'").Count() < 1)
                        {
                            continue;
                        }

                        DataTable dtonGroup = dt.Select("Customer ='" + dr["Customer"] + "' and " + "Destination ='" + drDes["Destination"] + "'").CopyToDataTable().DefaultView.ToTable(true, "Group");

                        foreach (DataRow drGroup in dtonGroup.Rows)
                        {
                            if (dt.Select("Customer ='" + dr["Customer"] + "' and " + "Destination ='" + drDes["Destination"] + "' and " + "Group ='" + drGroup["Group"] + "'").Count() < 1)
                            {
                                continue;
                            }

                            DataTable OnDestination = dt.Select("Customer ='" + dr["Customer"] + "' and " + "Destination ='" + drDes["Destination"] + "' and " + "Group ='" + drGroup["Group"] + "'").CopyToDataTable();

                            decimal totalQty = 0M;
                            int totalAmount = 0;
                            foreach (DataRow drDestination in OnDestination.Rows)
                            {
                                totalQty += Convert.ToDecimal(drDestination["NetWt"]);
                                totalAmount += Convert.ToInt32(drDestination["Amount"]);
                            }

                            DataRow drAdd = summary.NewRow();
                            drAdd["Customer"] = OnDestination.Rows[0]["Customer"];
                            drAdd["NetWt"] = totalQty;
                            drAdd["Rate"] = OnDestination.Rows[0]["Rate"];
                            drAdd["Amount"] = totalAmount;
                            drAdd["UnLoad"] = OnDestination.Rows[0]["Destination"];
                            drAdd["ProductName"] = OnDestination.Rows[0]["ProductName"];
                            drAdd["Nos"] = OnDestination.Rows.Count;
                            summary.Rows.Add(drAdd.ItemArray);
                        }
                    }
                }
            }

            DataRow[] drrr = summary.Select("ProductName in ('TMT','WRM','HRCT','HRCTL','HRCTLF')"); ;
            foreach (DataRow dr in drrr)
            {
                DataRow newRow = summary.NewRow();
                // We "clone" the row
                newRow.ItemArray = dr.ItemArray;
                // We remove the old and insert the new
                summary.Rows.Remove(dr);
                summary.Rows.Add(newRow);
            }

            //DataTable dtTmt = new DataTable();

            if (dt.Select("ProductName in ('TMT','WRM','HRCT','HRCTL','HRCTLF')").Count() > 0)
            {
                dtTmt = dt.Select("ProductName in ('TMT','WRM','HRCT','HRCTL','HRCTLF')").CopyToDataTable();
            }

            DataTable DtBackUp = dt;
            //foreach (DataRow row in dtTmt.Rows)
            //{
            //    dt.Rows.Remove(row.ItemArray);
            //}

            DataView dvs = dt.DefaultView;
            dvs.RowFilter = "ProductName not in ('TMT','WRM','HRCT','HRCTL','HRCTLF')";
            dt = dvs.ToTable();


            //if (dt.Select("ProductName in ('TMT','WRM','HRCT')").Count() > 0)
            //{
            //    dtTmt = dt.Select("ProductName in ('TMT','WRM','HRCT')").CopyToDataTable();
            //}

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    DataView dv = dt.DefaultView;
            //    dv.RowFilter = "ProductName not in ('TMT','WRM','HRCT')";
            //    dv.Sort = "Customer";
            //    dt = dv.ToTable();
            //}

            if (dt != null && dt.Rows.Count > 0)
            {
                DataView dv = dt.DefaultView;
                dv.Sort = "Customer,Group,ProductName,InvoiceNo";
                dt = dv.ToTable();
            }

            if (dtTmt != null && dtTmt.Rows.Count > 0)
            {
                DataView dv = dtTmt.DefaultView;
                dv.Sort = "ProductName desc,Customer asc,InvoiceNo asc";
                dtTmt = dv.ToTable();
            }

            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                dt.Rows[i - 1]["SlNo"] = i;
            }

            for (int i = 1; i <= dtTmt.Rows.Count; i++)
            {
                dtTmt.Rows[i - 1]["SlNo"] = i + dt.Rows.Count;
            }

            dvParty = dt.DefaultView.ToTable(true, "Customer");

            foreach (DataRow dr in dvParty.Rows)
            {
                DataTable OnParty = new DataTable();
                OnParty = dt.Select("Customer ='" + dr["Customer"] + "'").CopyToDataTable();
                decimal totalQty = 0M;
                int totalAmount = 0;

                //foreach (DataRow drParty in OnParty.Rows)
                //{
                DataTable dvGroup = new DataTable();
                dvGroup = OnParty.DefaultView.ToTable(true, "Group");

                foreach (DataRow drGroup in dvGroup.Rows)
                {
                    DataTable OnProductGroup = new DataTable();
                    OnProductGroup = OnParty.Select("Group ='" + drGroup["Group"] + "'").CopyToDataTable();

                    foreach (DataRow drG in OnProductGroup.Rows)
                    {
                        totalQty += Convert.ToDecimal(drG["NetWt"]);
                        totalAmount += Convert.ToInt32(drG["Amount"]);
                        dtComplete.Rows.Add(drG.ItemArray);
                    }
                    DataRow row = dt.NewRow();
                    row["NetWt"] = totalQty;
                    row["Amount"] = totalAmount;
                    row["Customer"] = " ";
                    row["VehicleNo"] = " ";
                    row["From"] = " ";
                    row["Destination"] = " ";
                    row["ProductName"] = " ";

                    dtComplete.Rows.Add(row.ItemArray);
                    totalQty = 0;
                    totalAmount = 0;
                }
            }


            DataTable OnInvoice = new DataTable();
            DataTable dtonInvoice = new DataTable();
            if (dtTmt != null && dtTmt.Rows.Count > 0)
            {
                dtonInvoice = dtTmt.DefaultView.ToTable(true, "InvoiceNo");


                foreach (DataRow dr in dtonInvoice.Rows)
                {
                    decimal totalQty = 0M;
                    int totalAmount = 0;

                    if (dtTmt.Select("InvoiceNo ='" + dr["InvoiceNo"] + "'").Count() > 0)
                    {
                        OnInvoice = dtTmt.Select("InvoiceNo ='" + dr["InvoiceNo"] + "'").CopyToDataTable();

                        foreach (DataRow drG in OnInvoice.Rows)
                        {
                            totalQty += Convert.ToDecimal(drG["NetWt"]);
                            totalAmount += Convert.ToInt32(drG["Amount"]);
                            dtComplete.Rows.Add(drG.ItemArray);
                        }
                        DataRow row = dt.NewRow();
                        row["NetWt"] = totalQty;
                        row["Amount"] = totalAmount;
                        row["Customer"] = " ";
                        row["VehicleNo"] = " ";
                        row["From"] = " ";
                        row["Destination"] = " ";
                        row["ProductName"] = " ";

                        dtComplete.Rows.Add(row.ItemArray);
                        totalQty = 0;
                        totalAmount = 0;
                    }
                }
            }


            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeTaxOnDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ShipDate", dtDetails.Rows[0]["SubmittedOn"]);
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            RakeDatatable.submitDate =Convert.ToDateTime(dtDetails.Rows[0]["SubmittedOn"]);
            RakeDatatable.bill = Convert.ToString(dtDetails.Select("FrightOrHandling=1 AND FromID = " + fromId)[0]["Bill"]);

            RakeDatatable.shipmentNo = Convert.ToString(dtDetails.Rows[0]["ShipmentNo"]); 
            RakeDatatable.dt = dtComplete;
            RakeDatatable.dtSummary = summary;

            //if (fromId == 2 && dataTable.Rows.Count > 0 && DtSubmitDate.Value.Date > new DateTime(2017, 06, 30))
            //{
            //    DataTable dtGST = dataTable.Clone();
            //    dtGST.Rows.Add("IGST", dataTable.Compute("Sum(RakeTax)", ""), Convert.ToInt32(dataTable.Rows[0]["RakeTaxId"]));
            //    RakeDatatable.dtTax = dtGST;
            //}
            //else
            //{
            RakeDatatable.dtTax = dataTable;
            //}

            Rake.Reports.Reports.BillsAttach BillsAttach = new Rake.Reports.Reports.BillsAttach();
            BillsAttach.Show();

            RakeDatatable.dt = new DataTable();
            RakeDatatable.dtSummary = new DataTable();
            RakeDatatable.dtTax = new DataTable();
            RakeDatatable.shipmentNo = string.Empty;

            RakeDatatable.shipmentNo = Convert.ToString(dtDetails.Rows[0]["ShipmentNo"]); 
            RakeDatatable.dt = DtBackUp;
            Rake.Reports.Reports.BillFright BillFright = new Rake.Reports.Reports.BillFright();
            BillFright.Show();


            RakeDatatable.dt = new DataTable();
            RakeDatatable.dtSummary = new DataTable();
            RakeDatatable.dtTax = new DataTable();
            RakeDatatable.bill = string.Empty;
            RakeDatatable.shipmentNo = string.Empty;
            RakeDatatable.shipmentNo = string.Empty;

            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("GetRakeTaxOnDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ShipDate", dtDetails.Rows[0]["SubmittedOn"]);
            con.Open();
            reader = cmd.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            RakeDatatable.shipmentNo = Convert.ToString(dtDetails.Rows[0]["ShipmentNo"]); 
            RakeDatatable.bill = Convert.ToString(dtDetails.Select("FrightOrHandling=0 AND FromID = " + fromId)[0]["Bill"]);

            //RakeDatatable.bill = TxtHandlingBill.Text;
            RakeDatatable.dt = DtBackUp;
            //if (fromId == 2 && dataTable.Rows.Count>0 && DtSubmitDate.Value.Date>new DateTime(2017,06,30))
            //{
            //    DataTable dtGST = dataTable.Clone();
            //    dtGST.Rows.Add("IGST", dataTable.Compute("Sum(RakeTax)", ""),Convert.ToInt32( dataTable.Rows[0]["RakeTaxId"]));
            //    RakeDatatable.dtTax = dtGST;
            //}
            //else
            //{
            RakeDatatable.dtTax = dataTable;
            //}
            RakeDatatable.submitDate =Convert.ToDateTime( dtDetails.Rows[0]["SubmittedOn"]);
            Rake.Reports.Reports.BillHandling BillHandling = new Rake.Reports.Reports.BillHandling();
            BillHandling.Show();

            RakeDatatable.dt = new DataTable();
            RakeDatatable.dtSummary = new DataTable();
            RakeDatatable.bill = string.Empty;
            RakeDatatable.dtTax = new DataTable();
        }

        private void TxtBillNo_TextChanged(object sender, EventArgs e)
        {
            if (backup.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(TxtBillNo.Text))
                {
                    GvRakeBill.DataSource = backup.Select("Convert(Bill, 'System.String') Like '" + TxtBillNo.Text + "%'").Any() ? backup.Select("Convert(Bill, 'System.String') Like '" + TxtBillNo.Text + "%'").CopyToDataTable() : backup.Clone();
                }
                else
                {
                    GvRakeBill.DataSource = backup;
                }
            }
        }
    }
}
