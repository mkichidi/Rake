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
    public partial class GenerateLocalBills : Form
    {
        public GenerateLocalBills()
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

            BindGrid();
        }

        protected void GetBillNo()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetLocalBills", con);
            cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", DDLYear.Text);

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            if (dataTable.Rows.Count > 0)
            {
                TxtLocalBill.Text = Convert.ToString(dataTable.Rows[0]["Bill"]);
            }
            else
            {


                if (NextBill().Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = NextBill();
                    TxtLocalBill.Text = Convert.ToString(dt.Rows[0]["Bill"]);
                }
            }
        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetLocalBill", con);
            cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", DDLYear.Text);

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            GvRakeBill.DataSource = dataTable;
            this.GvRakeBill.AllowUserToAddRows = false;

             con = new SqlConnection(Connection.InvAdminConn());
             cmd = new SqlCommand("GetLocalNotGcRecived", con);
            cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", DDLYear.Text);

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            reader = cmd.ExecuteReader();
             dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            string invoice = string.Empty;
            int count = 0;

            GetBillNo();

            if (dataTable.Rows.Count > 0)
            {
                foreach(DataRow dr in dataTable.Rows)
                {
                    invoice +=","+ dr["InvoiceNo"];
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

        protected DataTable NextBill()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetNextRakeOrLocalBills", con);

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            return dataTable;
            con.Close();
        }

        private void CtrlBtnPrintBill_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtLocalBill.Text))
            {
                MessageBox.Show("Please enter Local Bill No");
                TxtLocalBill.Focus();
                return;
            } 
            
            DataTable dt = new DataTable();
            dt = (DataTable)GvRakeBill.DataSource;

            if (dt == null||dt.Rows.Count < 1)
            {
                MessageBox.Show("Please select shipment to bill");
                return;
            }
            dt.AcceptChanges();


            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("DeleteLocalBill", con);
            cmd.Parameters.AddWithValue("@Month", DDLMonth.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", DDLYear.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            if (dt.Select("ProductName ='TMT'").Count() > 0)
            {
                PrintBills(dt.Select("ProductName ='TMT'").CopyToDataTable());

                    for(int i = dt.Rows.Count - 1; i >= 0;i--)
                    {
                        DataRow dr = dt.Rows[i];
                        if (Convert.ToString( dr["ProductName"]) == "TMT")
                        {
                            dr.Delete();
                        }
                    }
                    dt.AcceptChanges();
                    if (dt.Rows.Count > 0)
                    {
                        PrintBills(dt);
                    }
            }
            else
            {
                PrintBills(dt);
            }
            BindGrid();
        }


        protected void PrintBills(DataTable dt)
        {
            DataTable dtComplete = new DataTable();

            dtComplete = dt.Clone();
            dtComplete.Constraints.Clear();
            


            DataTable dvParty = new DataTable();
            dvParty = dt.DefaultView.ToTable(true, "Customer");

            foreach (DataRow dr in dvParty.Rows)
            {
                DataTable OnParty = new DataTable();
                OnParty = dt.Select("Customer ='" + dr["Customer"] + "'").CopyToDataTable();
                decimal totalQty = 0M;
                int totalAmount = 0;
                foreach (DataRow drParty in OnParty.Rows)
                {
                    totalQty += Convert.ToDecimal(drParty["NetWt"]);
                    totalAmount += Convert.ToInt32(drParty["Amount"]);
                    dtComplete.Rows.Add(drParty.ItemArray);
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
            }

            DataTable summary = new DataTable();
            summary.Columns.Add("Customer", typeof(String));
            summary.Columns.Add("NetWt", typeof(decimal));
            summary.Columns.Add("Rate", typeof(int));
            summary.Columns.Add("Amount", typeof(int));
            summary.Columns.Add("UnLoad", typeof(String));
            summary.Columns.Add("ProductName", typeof(String));
            summary.Columns.Add("Nos", typeof(int));

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

                        DataTable OnDestination = dt.Select("Customer ='" + dr["Customer"] + "' and " + "Destination ='" + drDes["Destination"] + "'").CopyToDataTable();

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

            RakeDatatable.bill = TxtLocalBill.Text;
                RakeDatatable.dt = dt;
                RakeDatatable.submitDate = DtSubmitDate.Value.Date;
                Rake.Reports.Reports.LocalBill LocalBill = new Rake.Reports.Reports.LocalBill();
                LocalBill.Show();

                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertLocalBillDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SubmittedOn", DtSubmitDate.Value.Date);
                cmd.Parameters.AddWithValue("@BillMonth", "01/" + DDLMonth.Text + "/" + DDLYear.Text);
                cmd.Parameters.AddWithValue("@BillAmount", summary.Rows[0]["Amount"]);
                cmd.Parameters.AddWithValue("@Bill", TxtLocalBill.Text);
                cmd.Parameters.AddWithValue("@NetWt", summary.Rows[0]["NetWt"]);
                cmd.Parameters.AddWithValue("@CB", "");
                cmd.Parameters.AddWithValue("@CD", DateTime.Now);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                RakeDatatable.dt = dt;
                RakeDatatable.dtSummary = summary;
                Rake.Reports.Reports.LocalBillAttach LocalBillAttach = new Rake.Reports.Reports.LocalBillAttach();
                LocalBillAttach.Show();
                TxtLocalBill.Text =Convert.ToString( Convert.ToInt32(TxtLocalBill.Text) + 1);

                RakeDatatable.bill = string.Empty;
            RakeDatatable.dt = new DataTable();
            RakeDatatable.dtSummary = new DataTable();
            RakeDatatable.dtTax = new DataTable();
        }

        private void TxtLocalBill_TextChanged(object sender, EventArgs e)
        {
            int a = 0;
            if (!string.IsNullOrEmpty(TxtLocalBill.Text))
            {
                if (!int.TryParse(TxtLocalBill.Text, out a))
                {
                    MessageBox.Show("Please enter correct Bill No");
                    TxtLocalBill.Focus();
                }
            }
        }
    }
}
