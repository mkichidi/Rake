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
    public partial class GenerateBills : Form
    {
        int rakeOrderId;
        public GenerateBills()
        {
            InitializeComponent();

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("0", "-Select-");
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
            row["RakeTypeName"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);

            DdlRakeType.DataSource = new DataView(dataTable);
            DdlRakeType.DisplayMember = "RakeTypeName";
            DdlRakeType.SelectedIndex = 0;
            DdlRakeType.ValueMember = "RakeTypeID";
        }

        private void DDLMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLMonth.SelectedIndex > 0)
            {
                DDLYear.Enabled = true;
            }
            else
            {
                DDLYear.Enabled = false;
                DDLYear.SelectedIndex = 0;

                DdlRakeType.Enabled = false;
                DdlRakeNo.Enabled = false;
                return;
            }
        }

        private void DDLYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLYear.SelectedIndex > 0)
            {
                DdlRakeType.Enabled = true;
            }
            else
            {
                DdlRakeType.Enabled = false;
                DdlRakeType.Enabled = false;
                DdlRakeNo.Enabled = false;
                return;
            }


        }

        private void DdlRakeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlRakeType.SelectedIndex > 0)
            {
                DdlRakeNo.Enabled = true;
            }
            else
            {
                DdlRakeNo.Enabled = false;
                return;
            }
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", DDLYear.Text);
            cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
            cmd.CommandTimeout = 1000000;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            DdlRakeNo.DataSource = new DataView(dataTable);
            DdlRakeNo.DisplayMember = "Rakeno";
        }

        private void BtnGetBills_Click(object sender, EventArgs e)
        {
            if (DDLMonth.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Month");
                DDLMonth.Focus();
                return;
            }
            else if (DDLYear.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Year");
                DDLYear.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(DdlRakeType.Text) || DdlRakeType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Rake Type");
                DdlRakeType.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(DdlRakeNo.Text))
            {
                MessageBox.Show("Please select Rake No");
                DdlRakeNo.Focus();
                return;
            }

            BindGrid();
        }

        protected DataTable NextBill()
        {
            DataTable dtDetails = (DataTable)GvRakeBill.DataSource;
            SqlDataReader reader;
            DataTable dataTable = new DataTable();
            if (dtDetails.Rows.Count > 0 && Convert.ToString(dtDetails.Rows[0]["From"]) == "Maddur Siding")
            {
                SqlConnection cons = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmds = new SqlCommand("GetRakeWorkOrderForMandyaBill", cons);
                cmds.CommandType = CommandType.StoredProcedure;
                cmds.Parameters.AddWithValue("@Date", Convert.ToDateTime("01/" + DDLMonth.Text + "/" + DDLYear.Text).Date);
                cons.Open();

                reader = cmds.ExecuteReader();
                dataTable.Load(reader);
                cons.Close();
            }
            else
            {
                SqlConnection cons = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmds = new SqlCommand("GetRakeWorkOrderForBill", cons);
                cmds.CommandType = CommandType.StoredProcedure;
                cmds.Parameters.AddWithValue("@Date", Convert.ToDateTime("01/" + DDLMonth.Text + "/" + DDLYear.Text).Date);
                cons.Open();

                reader = cmds.ExecuteReader();
                dataTable.Load(reader);
                cons.Close();
            }



            if (dataTable.Rows.Count > 0)
            {
                SqlConnection cons = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmds = new SqlCommand("GetRakeFinancialYear", cons);
                cmds.CommandType = CommandType.StoredProcedure;
                cmds.Parameters.AddWithValue("@Date", DtSubmitDate.Value.Date);
                cons.Open();
                RakeDatatable.financialYear = Convert.ToString(cmds.ExecuteScalar());
                cons.Close();

                rakeOrderId = Convert.ToInt32(dataTable.Rows[0]["ID"]);
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetNextRakeOrLocalBills", con);
                cmd.Parameters.AddWithValue("@RakeWorkOrderID", dataTable.Rows[0]["ID"]);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                con.Close();
                return dt;
            }
            return null;
        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeBill", con);
            cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", DDLYear.Text);
            cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
            cmd.Parameters.AddWithValue("@RakeNo", DdlRakeNo.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 1000000;
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();

            DataTable datatable = new DataTable();
            datatable = ds.Tables[0];
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                datatable.Rows.Add(dr.ItemArray);
            }
            DataColumn dc = new DataColumn("SlNo");
            dc.DataType = typeof(int);
            datatable.Columns.Add(dc);

            for (int i = 1; i <= datatable.Rows.Count; i++)
            {
                datatable.Rows[i - 1]["SlNo"] = i;
            }
            GvRakeBill.DataSource = datatable;
            this.GvRakeBill.AllowUserToAddRows = false;

            GetBillNo();



            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("GetRakeNotGcRecived", con);
            cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", DDLYear.Text);
            cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
            cmd.Parameters.AddWithValue("@RakeNo", DdlRakeNo.Text);

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            string invoice = string.Empty;
            int count = 0;
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    invoice += "," + dr["InvoiceNo"];
                    if (count >= 5)
                    {
                        invoice += Environment.NewLine;
                        count = 0;
                    }
                    count++;
                }
                MessageBox.Show("Invoice No :" + Environment.NewLine + invoice.Substring(1) + Environment.NewLine + " not yet GC recived.");
            }


        }

        protected void GetBillNo()
        {
            TxtFrightBill.Text = string.Empty;
            TxtHandlingBill.Text = string.Empty;
            TxtHosurFright.Text = string.Empty;
            TxtHosurHandling.Text = string.Empty;
            TxtMaddurHandling.Text = string.Empty;
            TxtMaddurFright.Text = string.Empty;

            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetRakeBills", con);
            cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", DDLYear.Text);
            cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
            cmd.Parameters.AddWithValue("@RakeNo", DdlRakeNo.Text);

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    if (Convert.ToInt32(dr["FromId"]) == 1)
                    {
                        if (Convert.ToInt32(dr["FrightOrHandling"]) == 1)
                        {
                            TxtFrightBill.Text = Convert.ToString(dr["Bill"]);
                            TxtHosurFright.Text = "";
                            TxtHosurHandling.Text = "";
                        }
                        else if (Convert.ToInt32(dr["FrightOrHandling"]) == 0)
                        {
                            TxtHandlingBill.Text = Convert.ToString(dr["Bill"]);
                        }
                    }
                    else if (Convert.ToInt32(dr["FromId"]) == 2)
                    {
                        if (Convert.ToInt32(dr["FrightOrHandling"]) == 1)
                        {
                            TxtHosurFright.Text = Convert.ToString(dr["Bill"]);
                        }
                        else if (Convert.ToInt32(dr["FrightOrHandling"]) == 0)
                        {
                            TxtHosurHandling.Text = Convert.ToString(dr["Bill"]);
                        }
                    }
                    else if (Convert.ToInt32(dr["FromId"]) == 4)
                    {
                        if (Convert.ToInt32(dr["FrightOrHandling"]) == 1)
                        {
                            TxtMaddurFright.Text = Convert.ToString(dr["Bill"]);
                        }
                        else if (Convert.ToInt32(dr["FrightOrHandling"]) == 0)
                        {
                            TxtMaddurHandling.Text = Convert.ToString(dr["Bill"]);
                        }
                    }
                }

                if (dataTable.Rows[0]["ShipmentNo"] != null)
                {
                    TxtShipmentNo.Text = Convert.ToString(dataTable.Rows[0]["ShipmentNo"]);
                }

                if (dataTable.Rows[0]["SubmittedOn"] != null)
                {
                    DtSubmitDate.Value = Convert.ToDateTime(dataTable.Rows[0]["SubmittedOn"]);
                }

                DataTable dtDetails = (DataTable)GvRakeBill.DataSource;
                if (dtDetails.Rows.Count > 0 && Convert.ToString(dtDetails.Rows[0]["From"]) == "Maddur Siding")
                {
                    SqlConnection cons = new SqlConnection(Connection.InvAdminConn());
                    SqlCommand cmds = new SqlCommand("GetRakeWorkOrderForMandyaBill", cons);
                    cmds.CommandType = CommandType.StoredProcedure;
                    cmds.Parameters.AddWithValue("@Date", Convert.ToDateTime("01/" + DDLMonth.Text + "/" + DDLYear.Text).Date);
                    cons.Open();

                    reader = cmds.ExecuteReader();
                    dataTable = new DataTable();
                    dataTable.Load(reader);
                    cons.Close();
                }
                else
                {

                    SqlConnection cons = new SqlConnection(Connection.InvAdminConn());
                    SqlCommand cmds = new SqlCommand("GetRakeWorkOrderForBill", cons);
                    cmds.CommandType = CommandType.StoredProcedure;
                    cmds.Parameters.AddWithValue("@Date", Convert.ToDateTime("01/" + DDLMonth.Text + "/" + DDLYear.Text).Date);
                    cons.Open();

                    reader = cmds.ExecuteReader();
                    dataTable = new DataTable();
                    dataTable.Load(reader);
                    cons.Close();
                }
                if (dataTable.Rows.Count > 0)
                {
                    rakeOrderId = Convert.ToInt32(dataTable.Rows[0]["ID"]);
                }

                SqlConnection cons1 = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmds1 = new SqlCommand("GetRakeFinancialYear", cons1);
                cmds1.CommandType = CommandType.StoredProcedure;
                cmds1.Parameters.AddWithValue("@Date", DtSubmitDate.Value.Date);
                cons1.Open();
                RakeDatatable.financialYear = Convert.ToString(cmds1.ExecuteScalar());
                cons1.Close();
            }
            else
            {
                DataTable dt = NextBill();
                if (dt != null && dt.Rows.Count > 0)
                {
                    TxtFrightBill.Text = Convert.ToString(dt.Rows[0]["Bill"]);
                }
            }
        }

        private void CtrlBtnPrintBill_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtShipmentNo.Text))
            {
                MessageBox.Show("Please enter Shipment No");
                TxtShipmentNo.Focus();
                return;
            }
            DataTable dt = new DataTable();
            dt = (DataTable)GvRakeBill.DataSource;

            if (dt == null || dt.Rows.Count < 1)
            {
                MessageBox.Show("Please select shipment to bill");
                return;
            }
            dt.AcceptChanges();


            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("DeleteRakeBillOnRake", con);
            cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
            cmd.Parameters.AddWithValue("@RakeNo", DdlRakeNo.Text);
            cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", DDLYear.Text);
            //cmd.Parameters.AddWithValue("@RakeWorkOrderID", rakeOrderId);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dtFrom = dt.DefaultView.ToTable(true, "FromId");

            if (dtFrom.Rows.Count > 1)
            {
                DataView dv = dtFrom.DefaultView;
                dv.Sort = "FromId";
                dtFrom = new DataTable();
                dtFrom = dv.ToTable();

                foreach (DataRow drs in dtFrom.Rows)
                {
                    if (Convert.ToInt32(drs["FromId"]) == 1)
                    {
                        if (string.IsNullOrEmpty(TxtFrightBill.Text))
                        {
                            MessageBox.Show("Please enter Whitefield Fright Bill No");
                            TxtFrightBill.Focus();
                            return;
                        }
                        else if (string.IsNullOrEmpty(TxtHandlingBill.Text))
                        {
                            MessageBox.Show("Please enter Whitefield Handling Bill No");
                            TxtHandlingBill.Focus();
                            return;
                        }
                    }
                    else if (Convert.ToInt32(drs["FromId"]) == 2)
                    {
                        if (string.IsNullOrEmpty(TxtHosurFright.Text))
                        {
                            MessageBox.Show("Please enter Hosur Fright Bill No");
                            TxtHosurFright.Focus();
                            return;
                        }
                        else if (string.IsNullOrEmpty(TxtHosurHandling.Text))
                        {
                            MessageBox.Show("Please enter Hosur Handling Bill No");
                            TxtHosurHandling.Focus();
                            return;
                        }
                    }
                    else if (Convert.ToInt32(drs["FromId"]) == 4)
                    {
                        if (string.IsNullOrEmpty(TxtMaddurFright.Text))
                        {
                            MessageBox.Show("Please enter Maddur Fright Bill No");
                            TxtMaddurFright.Focus();
                            return;
                        }
                        else if (string.IsNullOrEmpty(TxtMaddurHandling.Text))
                        {
                            MessageBox.Show("Please enter Maddur Handling Bill No");
                            TxtMaddurHandling.Focus();
                            return;
                        }
                    }
                }

                foreach (DataRow dr in dtFrom.Rows)
                {
                    PrintBills(dt.Select("FromId ='" + dr["FromId"] + "'").CopyToDataTable(), Convert.ToInt32(dr["FromId"]));

                    if (Convert.ToInt32(dr["FromId"]) == 1)
                    {
                        if (string.IsNullOrEmpty(TxtFrightBill.Text))
                        {
                            MessageBox.Show("Please enter Whitefield Fright Bill No");
                            TxtFrightBill.Focus();
                            return;
                        }
                        else if (string.IsNullOrEmpty(TxtHandlingBill.Text))
                        {
                            MessageBox.Show("Please enter Whitefield Handling Bill No");
                            TxtHandlingBill.Focus();
                            return;
                        }
                    }
                    else if (Convert.ToInt32(dr["FromId"]) == 2)
                    {
                        if (string.IsNullOrEmpty(TxtHosurFright.Text))
                        {
                            MessageBox.Show("Please enter Hosur Fright Bill No");
                            TxtFrightBill.Focus();
                            return;
                        }
                        else if (string.IsNullOrEmpty(TxtHosurHandling.Text))
                        {
                            MessageBox.Show("Please enter Hosur Handling Bill No");
                            TxtHandlingBill.Focus();
                            return;
                        }
                    }
                    else if (Convert.ToInt32(dr["FromId"]) == 4)
                    {
                        if (string.IsNullOrEmpty(TxtMaddurFright.Text))
                        {
                            MessageBox.Show("Please enter Hosur Fright Bill No");
                            TxtMaddurFright.Focus();
                            return;
                        }
                        else if (string.IsNullOrEmpty(TxtMaddurHandling.Text))
                        {
                            MessageBox.Show("Please enter Hosur Handling Bill No");
                            TxtMaddurHandling.Focus();
                            return;
                        }
                    }


                    //RakeDatatable.dt = dt.Select("From ='" + dr["From"] + "'").CopyToDataTable();
                    //RakeDatatable.submitDate = DtSubmitDate.Value.Date;
                    //Rake.Reports.Reports.BillFright BillFright = new Rake.Reports.Reports.BillFright();
                    //BillFright.Show();

                    //RakeDatatable.dt = null;
                    //RakeDatatable.dt = dt.Select("From ='" + dr["From"] + "'").CopyToDataTable();
                    //RakeDatatable.dt = dt.Select("From ='" + dr["From"] + "'").CopyToDataTable();
                    //Rake.Reports.Reports.BillHandling BillHandling = new Rake.Reports.Reports.BillHandling();
                    //BillHandling.Show();

                    //RakeDatatable.dt = null;
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
            GetBillNo();
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

            DataRow[] drrr = summary.Select("ProductName in ('TMT','WRM','HRCT','HRCTL','HRCTLF','WRC')"); ;
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

            if (dt.Select("ProductName in ('TMT','WRM','HRCT','HRCTL','HRCTLF','WRC')").Count() > 0)
            {
                dtTmt = dt.Select("ProductName in ('TMT','WRM','HRCT','HRCTL','HRCTLF','WRC')").CopyToDataTable();
            }

            DataTable DtBackUp = dt;
            //foreach (DataRow row in dtTmt.Rows)
            //{
            //    dt.Rows.Remove(row.ItemArray);
            //}

            DataView dvs = dt.DefaultView;
            dvs.RowFilter = "ProductName not in ('TMT','WRM','HRCT','HRCTL','HRCTLF','WRC')";
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
            cmd.Parameters.AddWithValue("@ShipDate", DtSubmitDate.Value);
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            SqlConnection cons = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmds = new SqlCommand("GetRakeWorkOrderOnDateAndPlace", cons);
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.Parameters.AddWithValue("@Date", Convert.ToDateTime("01/" + DDLMonth.Text + "/" + DDLYear.Text).Date);
            cmds.Parameters.AddWithValue("@Place", fromId);
            cons.Open();

            reader = cmds.ExecuteReader();
            DataTable dtWorkOrder = new DataTable();
            dtWorkOrder.Load(reader);
            cons.Close();

            int OrderId = 0;
            if (dtWorkOrder.Rows.Count > 0)
            {
                OrderId = Convert.ToInt32(dtWorkOrder.Rows[0]["ID"]);
            }
            else
            {
                MessageBox.Show("workorder expired for " + fromId);
            }

            RakeDatatable.submitDate = DtSubmitDate.Value.Date;
            if (fromId == 1)
            {
                RakeDatatable.bill = (OrderId > 5 ? "R" : "") + TxtFrightBill.Text;
            }
            else if (fromId == 2)
            {
                RakeDatatable.bill = (OrderId > 5 ? "R" : "") + TxtHosurFright.Text;
            }
             else if (fromId == 4)
            {
                RakeDatatable.bill = (OrderId > 5 ? "R" : "") + TxtMaddurFright.Text;
            }
            RakeDatatable.shipmentNo = TxtShipmentNo.Text;
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

            RakeDatatable.shipmentNo = TxtShipmentNo.Text;
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
            cmd.Parameters.AddWithValue("@ShipDate", DtSubmitDate.Value);
            con.Open();
            reader = cmd.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            cons = new SqlConnection(Connection.InvAdminConn());
            cmds = new SqlCommand("GetRakeWorkOrderOnDateAndPlace", cons);
            cmds.CommandType = CommandType.StoredProcedure;
            cmds.Parameters.AddWithValue("@Date", Convert.ToDateTime("01/" + DDLMonth.Text + "/" + DDLYear.Text).Date);
            cmds.Parameters.AddWithValue("@Place", fromId);
            cons.Open();

            reader = cmds.ExecuteReader();
            dtWorkOrder = new DataTable();
            dtWorkOrder.Load(reader);
            cons.Close();

            if (dtWorkOrder.Rows.Count > 0)
            {
                OrderId = Convert.ToInt32(dtWorkOrder.Rows[0]["ID"]);
            }

            RakeDatatable.shipmentNo = TxtShipmentNo.Text;
            if (fromId == 1)
            {
                RakeDatatable.bill = (OrderId > 5 ? "R" : "") + TxtHandlingBill.Text;
            }
            else if(fromId == 2)
            {
                RakeDatatable.bill = (OrderId > 5 ? "R" : "") + TxtHosurHandling.Text;
            }
            else if (fromId == 4)
            {
                RakeDatatable.bill = (OrderId > 5 ? "R" : "") + TxtMaddurHandling.Text;
            }
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
            RakeDatatable.submitDate = DtSubmitDate.Value.Date;
            Rake.Reports.Reports.BillHandling BillHandling = new Rake.Reports.Reports.BillHandling();
            BillHandling.Show();

            int amount = 0;
            decimal nt = 0M;

            foreach (DataRow dr in dataTable.Rows)
            {
                con = new SqlConnection(Connection.InvAdminConn());
                cmd = new SqlCommand("InsertRakeTaxDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RakeNo", DdlRakeNo.Text);
                cmd.Parameters.AddWithValue("@SubmittedOn", DtSubmitDate.Value.Date);
                if (fromId == 1)
                {
                    cmd.Parameters.AddWithValue("@Bill", TxtHandlingBill.Text);
                }
                else if (fromId == 2)
                {
                    cmd.Parameters.AddWithValue("@Bill", TxtHosurHandling.Text);
                }
                else if (fromId == 4)
                {
                    cmd.Parameters.AddWithValue("@Bill", TxtMaddurHandling.Text);
                }
                //cmd.Parameters.AddWithValue("@Bill", TxtHandlingBill.Text);
                cmd.Parameters.AddWithValue("@BillMonth", "01/" + DDLMonth.Text + "/" + DDLYear.Text);
                amount += Convert.ToInt32(Convert.ToDecimal(dr["RakeTax"]) * Convert.ToInt32(Convert.ToDecimal(DtBackUp.Rows[0]["RakeHandling/Ton"]) * Convert.ToDecimal(DtBackUp.Compute("Sum([NetWt])", ""))) / 100);

                decimal taxAmount = Math.Round(Convert.ToDecimal(dr["RakeTax"]) * Convert.ToInt32(Convert.ToDecimal(DtBackUp.Rows[0]["RakeHandling/Ton"]) * Convert.ToDecimal(DtBackUp.Compute("Sum([NetWt])", ""))) / 100, 0);

                cmd.Parameters.AddWithValue("@TaxAmount", taxAmount);
                //nt = (Convert.ToDecimal(dt.Rows[0]["RakeHandling/Ton"]) * Convert.ToDecimal(dt.Compute("Sum([NetWt])", "")));

                cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
                cmd.Parameters.AddWithValue("@RakeTax", dr["RakeTax"]);
                cmd.Parameters.AddWithValue("@RakeTaxId", dr["RakeTaxId"]);
                cmd.Parameters.AddWithValue("@CB", "");
                cmd.Parameters.AddWithValue("@CD", DateTime.Now);
                cmd.Parameters.AddWithValue("@RakeWorkOrderID", OrderId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }



            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("InsertRakeBillDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RakeNo", DdlRakeNo.Text);
            cmd.Parameters.AddWithValue("@SubmittedOn", DtSubmitDate.Value.Date);
            if (fromId == 1)
            {
                cmd.Parameters.AddWithValue("@Bill", TxtFrightBill.Text);
            }
            else if (fromId == 2)
            {
                cmd.Parameters.AddWithValue("@Bill", TxtHosurFright.Text);
            }
            else if (fromId == 4)
            {
                cmd.Parameters.AddWithValue("@Bill", TxtMaddurFright.Text);
            } 
            cmd.Parameters.AddWithValue("@BillMonth", "01/" + DDLMonth.Text + "/" + DDLYear.Text);
            cmd.Parameters.AddWithValue("@BillAmount", Convert.ToDecimal(summary.Compute("Sum(Amount)", "")));
            cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
            cmd.Parameters.AddWithValue("@FrightOrHandling", 1);
            cmd.Parameters.AddWithValue("@ShipmentNo", TxtShipmentNo.Text);
            //decimal netwt = 0M;
            //foreach (DataRow dr in summary.Rows)
            //{
            //    netwt=Convert.ToDecimal(dr["NetWt"]);
            //}
            cmd.Parameters.AddWithValue("@NetWt", DtBackUp.Compute("Sum(NetWt)", ""));
            cmd.Parameters.AddWithValue("@From", DtBackUp.Rows[0]["From"]);
            cmd.Parameters.AddWithValue("@CB", "");
            cmd.Parameters.AddWithValue("@CD", DateTime.Now);
            cmd.Parameters.AddWithValue("@RakeWorkOrderID", OrderId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            amount = Convert.ToInt32(Convert.ToDecimal(DtBackUp.Rows[0]["RakeHandling/Ton"]) * Convert.ToDecimal(DtBackUp.Compute("Sum([NetWt])", "")) + amount);
            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("InsertRakeBillDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RakeNo", DdlRakeNo.Text);
            cmd.Parameters.AddWithValue("@SubmittedOn", DtSubmitDate.Value.Date);
            if (fromId == 1)
            {
                cmd.Parameters.AddWithValue("@Bill", TxtHandlingBill.Text);
            }
            else if (fromId == 2)
            {
                cmd.Parameters.AddWithValue("@Bill", TxtHosurHandling.Text);
            }
            else if (fromId == 4)
            {
                cmd.Parameters.AddWithValue("@Bill", TxtMaddurHandling.Text);
            } 
            //cmd.Parameters.AddWithValue("@Bill", TxtHandlingBill.Text);
            cmd.Parameters.AddWithValue("@BillMonth", "01/" + DDLMonth.Text + "/" + DDLYear.Text);
            cmd.Parameters.AddWithValue("@ShipmentNo", TxtShipmentNo.Text);
            cmd.Parameters.AddWithValue("@BillAmount", amount);
            //Convert.ToDecimal(summary.Rows[0]["NetWt"]) * Convert.ToDecimal(dt.Rows[0]["NetWt"]));
            cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
            cmd.Parameters.AddWithValue("@FrightOrHandling", 0);
            cmd.Parameters.AddWithValue("@NetWt", DtBackUp.Compute("Sum(NetWt)", ""));
            cmd.Parameters.AddWithValue("@From", DtBackUp.Rows[0]["From"]);
            cmd.Parameters.AddWithValue("@CB", "");
            cmd.Parameters.AddWithValue("@CD", DateTime.Now);
            cmd.Parameters.AddWithValue("@RakeWorkOrderID", OrderId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            //TxtFrightBill.Text = Convert.ToString(Convert.ToInt32(TxtHandlingBill.Text) + 1);
            //TxtHandlingBill.Text = Convert.ToString(Convert.ToInt32(TxtFrightBill.Text) + 1);


            RakeDatatable.dt = new DataTable();
            RakeDatatable.dtSummary = new DataTable();
            RakeDatatable.bill = string.Empty;
            RakeDatatable.dtTax = new DataTable();
        }

        private void TxtFrightBill_TextChanged(object sender, EventArgs e)
        {
            int a = 0;
            if (!string.IsNullOrEmpty(TxtFrightBill.Text))
            {
                if (int.TryParse(TxtFrightBill.Text, out a))
                {
                    TxtHandlingBill.Text = Convert.ToString(Convert.ToInt32(TxtFrightBill.Text) + 1);
                }
                else
                {
                    MessageBox.Show("Please enter correct Bill No");
                    TxtFrightBill.Focus();
                }

            }
        }

        private void DdlRakeNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (DdlRakeType.SelectedIndex > 0)
            //{
            //    DdlRakeNo.Enabled = true;
            //}
            //else
            //{
            //    DdlRakeNo.Enabled = false;
            //    return;
            //}
            //SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            //SqlCommand cmd = new SqlCommand("GetRakeNo", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            //cmd.Parameters.AddWithValue("@Year", DDLYear.Text);
            //cmd.Parameters.AddWithValue("@RakeType", DdlRakeType.SelectedValue);
            //con.Open();
            //SqlDataReader reader;
            //reader = cmd.ExecuteReader();
            //DataTable dataTable = new DataTable();
            //dataTable.Load(reader);
            //DdlRakeNo.DataSource = new DataView(dataTable);
            //DdlRakeNo.DisplayMember = "Rakeno";
            //con.Close();
        }

        private void TxtHandlingBill_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void TxtHosurFright_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
