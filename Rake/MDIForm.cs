using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rake
{
    public partial class MDIForm : Form
    {
        public MDIForm()
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetDestinationRateRakeExpired", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();

            if (dataTable.Rows.Count >0)
            {
                string message = string.Empty;

                foreach (DataRow dr in dataTable.Rows)
                {
                    if (Convert.ToDateTime(dr["Date"]) < DateTime.Now.Subtract(TimeSpan.FromDays(90)))
                    {
                        message += dr["DestinationName"]+",";
                    }
                }
                if (!string.IsNullOrEmpty(message))
                {
                    message = message.Substring(0, message.Length-1);
                    MessageBox.Show(message + " rates are more than 3 months old. Please enter new rate.");
                }
            }
        }

        private bool CheckForDuplicateForm(Form newForm)
        {
            bool bValue = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == newForm.GetType())
                {
                    frm.Activate();
                    bValue = true;
                }
            }
            return bValue;
        }

        private void Destination_Click(object sender, EventArgs e)
        {
            Rake.DestinationMaster Destination = new Rake.DestinationMaster();
            bool frmPresent = CheckForDuplicateForm(Destination);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                Destination.Show();
            }
        }

        private void DestinationRate_Click(object sender, EventArgs e)
        {
            Rake.DestinationRate DestinationRate = new Rake.DestinationRate();
            bool frmPresent = CheckForDuplicateForm(DestinationRate);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                DestinationRate.Show();
            }
        }

        private void Product_Click(object sender, EventArgs e)
        {
            Rake.ProductMaster ProductMaster = new Rake.ProductMaster();
            bool frmPresent = CheckForDuplicateForm(ProductMaster);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                ProductMaster.Show();
            }
        }

        private void Party_Click(object sender, EventArgs e)
        {
            Rake.PartyMaster PartyMaster = new Rake.PartyMaster();
            bool frmPresent = CheckForDuplicateForm(PartyMaster);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                PartyMaster.Show();
            }
        }

        private void Vehicle_Click(object sender, EventArgs e)
        {
            Rake.VehicleMaster VehicleMaster = new Rake.VehicleMaster();
            bool frmPresent = CheckForDuplicateForm(VehicleMaster);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                VehicleMaster.Show();
            }
        }

        //private void JSWBilling_Click(object sender, EventArgs e)
        //{
        //    Rake.GernerateJswBill GernerateJswBill = new Rake.GernerateJswBill();
        //    bool frmPresent = CheckForDuplicateForm(GernerateJswBill);
        //    if (frmPresent)
        //        return;
        //    else if (!frmPresent)
        //    {
        //        GernerateJswBill.Show();
        //    }
        //}

        //private void reciveGCToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Rake.GCRecive GCRecive = new Rake.GCRecive();
        //    bool frmPresent = CheckForDuplicateForm(GCRecive);
        //    if (frmPresent)
        //        return;
        //    else if (!frmPresent)
        //    {
        //        GCRecive.Show();
        //    }
        //}

        //private void shipmentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Rake.Shipment Shipment = new Rake.Shipment();
        //    bool frmPresent = CheckForDuplicateForm(Shipment);
        //    if (frmPresent)
        //        return;
        //    else if (!frmPresent)
        //    {
        //        Shipment.Show();
        //    }
        //}

        //private void editJSWBillingToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Rake.EditJSWBill EditJSWBill = new Rake.EditJSWBill();
        //    bool frmPresent = CheckForDuplicateForm(EditJSWBill);
        //    if (frmPresent)
        //        return;
        //    else if (!frmPresent)
        //    {
        //        EditJSWBill.Show();
        //    }
        //}

        //private void incentiveOfAllProducts_Click(object sender, EventArgs e)
        //{
        //    Rake.JSW_Incentive_All_Products JSWIncentiveAllProducts = new Rake.JSW_Incentive_All_Products();
        //    bool frmPresent = CheckForDuplicateForm(JSWIncentiveAllProducts);
        //    if (frmPresent)
        //        return;
        //    else if (!frmPresent)
        //    {
        //        JSWIncentiveAllProducts.Show();
        //    }
        //}

        //private void jSWConsolidatedBills_Click(object sender, EventArgs e)
        //{
        //    Rake.JSWConsolidate JSWConsolidate = new Rake.JSWConsolidate();
        //    bool frmPresent = CheckForDuplicateForm(JSWConsolidate);
        //    if (frmPresent)
        //        return;
        //    else if (!frmPresent)
        //    {
        //        JSWConsolidate.Show();
        //    }
        //}

        //private void incentiveOnProduct_Click(object sender, EventArgs e)
        //{
        //    Rake.JswIncentiveOnProduct JswIncentiveOnProduct = new Rake.JswIncentiveOnProduct();
        //    bool frmPresent = CheckForDuplicateForm(JswIncentiveOnProduct);
        //    if (frmPresent)
        //        return;
        //    else if (!frmPresent)
        //    {
        //        JswIncentiveOnProduct.Show();
        //    }
        //}

        private void CtrlBtnCal_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");

        }

        private void CrtlBtnAbout_Click(object sender, EventArgs e)
        {
            //Rake.About Ctrl_ObjAbout = new About();
            //bool frmPresent = CheckForDuplicateForm(Ctrl_ObjAbout);
            //if (frmPresent)
            //    return;
            //else if (!frmPresent)
            //{
            //    Ctrl_ObjAbout.MdiParent = this;
            //    Ctrl_ObjAbout.Show();
            //}
        }

        private void CtrlBtnAppClose_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Do you want to Close Application ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void shipmentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.RakeShipmentDetails RakeShipmentDetails = new Rake.RakeShipmentDetails();
            bool frmPresent = CheckForDuplicateForm(RakeShipmentDetails);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                RakeShipmentDetails.Show();
            }
        }

        private void reciveGCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.GCRecive GCRecive = new Rake.GCRecive();
            bool frmPresent = CheckForDuplicateForm(GCRecive);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                GCRecive.Show();
            }
        }

        private void fromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.From From = new Rake.From();
            bool frmPresent = CheckForDuplicateForm(From);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                From.Show();
            }
        }

        private void rakeTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.Masters.RakeType RakeType = new Rake.Masters.RakeType();
            bool frmPresent = CheckForDuplicateForm(RakeType);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                RakeType.Show();
            }
        }

        private void unLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.Masters.UnLoad UnLoad = new Rake.Masters.UnLoad();
            bool frmPresent = CheckForDuplicateForm(UnLoad);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                UnLoad.Show();
            }
        }

        private void editJSWBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.GenerateBills GenerateBills = new Rake.GenerateBills();
            bool frmPresent = CheckForDuplicateForm(GenerateBills);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                GenerateBills.Show();
            }
        }

        private void taxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.TaxMaster TaxMaster = new Rake.TaxMaster();
            bool frmPresent = CheckForDuplicateForm(TaxMaster);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                TaxMaster.Show();
            }
        }

        private void rakeHandlingChargesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.RailHandling RailHandling = new Rake.RailHandling();
            bool frmPresent = CheckForDuplicateForm(RailHandling);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                RailHandling.Show();
            }
        }

        private void shipmentDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Rake.LocalShipmentDetails LocalShipmentDetails = new Rake.LocalShipmentDetails();
            bool frmPresent = CheckForDuplicateForm(LocalShipmentDetails);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                LocalShipmentDetails.Show();
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Rake.LocalGCRecive LocalGCRecive = new Rake.LocalGCRecive();
            bool frmPresent = CheckForDuplicateForm(LocalGCRecive);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                LocalGCRecive.Show();
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Rake.GenerateLocalBills GenerateLocalBills = new Rake.GenerateLocalBills();
            bool frmPresent = CheckForDuplicateForm(GenerateLocalBills);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                GenerateLocalBills.Show();
            }
        }

        private void summuryOfMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.RakeSummary RakeSummary = new Rake.RakeSummary();
            bool frmPresent = CheckForDuplicateForm(RakeSummary);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                RakeSummary.Show();
            }
        }

        private void genearateGCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.GenerateGC GenerateGC = new Rake.GenerateGC();
            bool frmPresent = CheckForDuplicateForm(GenerateGC);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                GenerateGC.Show();
            }
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.Payment Payment = new Rake.Payment();
            bool frmPresent = CheckForDuplicateForm(Payment);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                Payment.Show();
            }
        }

        private void rakeShipmentDetailsAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.RakeShipmentDetailsAll RakeShipmentDetailsAll = new Rake.RakeShipmentDetailsAll();
            bool frmPresent = CheckForDuplicateForm(RakeShipmentDetailsAll);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                RakeShipmentDetailsAll.Show();
            }
        }

        private void eSugamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.Esugam Esugam = new Rake.Esugam();
            bool frmPresent = CheckForDuplicateForm(Esugam);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                Esugam.Show();
            }
        }

        private void compareToESugamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.CompareEsugam CompareEsugam = new Rake.CompareEsugam();
            bool frmPresent = CheckForDuplicateForm(CompareEsugam);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                CompareEsugam.Show();
            }
        }

        private void reportsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void searchOnAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.SearchOn SearchOn = new Rake.SearchOn();
            bool frmPresent = CheckForDuplicateForm(SearchOn);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                SearchOn.Show();
            }
        }

        private void taxReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.TaxReports TaxReports = new Rake.TaxReports();
            bool frmPresent = CheckForDuplicateForm(TaxReports);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                TaxReports.Show();
            }
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void searchOnAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Rake.SearchOn SearchOn = new Rake.SearchOn();
            bool frmPresent = CheckForDuplicateForm(SearchOn);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                SearchOn.Show();
            }
        }

        private void taxDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.TaxReports TaxReports = new Rake.TaxReports();
            bool frmPresent = CheckForDuplicateForm(TaxReports);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                TaxReports.Show();
            }
        }

        private void oSTVehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.OSTVehicles OSTVehicles = new Rake.OSTVehicles();
            bool frmPresent = CheckForDuplicateForm(OSTVehicles);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                OSTVehicles.Show();
            }
        }

        private void transportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.OST_Transporters OST_Transporters = new Rake.OST_Transporters();
            bool frmPresent = CheckForDuplicateForm(OST_Transporters);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                OST_Transporters.Show();
            }
        }

        private void sumOnDestinationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.SumOnDestination SumOnDestination = new Rake.SumOnDestination();
            bool frmPresent = CheckForDuplicateForm(SumOnDestination);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                SumOnDestination.Show();
            }
        }

        private void workOrderNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rake.Masters.WorkOrder SumOnDestination = new Rake.Masters.WorkOrder();
            bool frmPresent = CheckForDuplicateForm(SumOnDestination);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                SumOnDestination.Show();
            }
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            GCData SumOnDestination = new GCData();
            bool frmPresent = CheckForDuplicateForm(SumOnDestination);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                SumOnDestination.Show();
            }
        }

        private void partyDestinationMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PartyDestinationMonth SumOnDestination = new PartyDestinationMonth();
            bool frmPresent = CheckForDuplicateForm(SumOnDestination);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                SumOnDestination.Show();
            }
        }

        private void destinationProductWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DestinationWiseReport SumOnDestination = new DestinationWiseReport();
            bool frmPresent = CheckForDuplicateForm(SumOnDestination);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                SumOnDestination.Show();
            }
        }

        private void searchOnShipmentDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchOnShipment SumOnDestination = new SearchOnShipment();
            bool frmPresent = CheckForDuplicateForm(SumOnDestination);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                SumOnDestination.Show();
            }
        }

        private void taxDetailsDatewiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaxReportsDatewise SumOnDestination = new TaxReportsDatewise();
            bool frmPresent = CheckForDuplicateForm(SumOnDestination);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                SumOnDestination.Show();
            }
        }

        private void billWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillWiseReports SumOnDestination = new BillWiseReports();
            bool frmPresent = CheckForDuplicateForm(SumOnDestination);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                SumOnDestination.Show();
            }
        }

        private void tMTReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.Reports.TMTReport SumOnDestination = new Reports.Reports.TMTReport();
            bool frmPresent = CheckForDuplicateForm(SumOnDestination);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                SumOnDestination.Show();
            }
        }

        private void rakeEwayGCReciveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GCReciveEsugam SumOnDestination = new GCReciveEsugam();
            bool frmPresent = CheckForDuplicateForm(SumOnDestination);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                SumOnDestination.Show();
            }
        }

 

        //private void jSWNotBilled_Click(object sender, EventArgs e)
        //{
        //    Rake.JSWNotBilled JSWNotBilled = new Rake.JSWNotBilled();
        //    bool frmPresent = CheckForDuplicateForm(JSWNotBilled);
        //    if (frmPresent)
        //        return;
        //    else if (!frmPresent)
        //    {
        //        JSWNotBilled.Show();
        //    }
        //}

        //private void jSWBillsOnDate_Click(object sender, EventArgs e)
        //{
        //    Rake.Reports.ReportForms.BillsOnDate BillsOnDate = new Rake.Reports.ReportForms.BillsOnDate();
        //    bool frmPresent = CheckForDuplicateForm(BillsOnDate);
        //    if (frmPresent)
        //        return;
        //    else if (!frmPresent)
        //    {
        //        BillsOnDate.Show();
        //    }
        //}

        //private void CheckDetails_Click(object sender, EventArgs e)
        //{
        //    Rake.CheckDetails CheckDetails = new Rake.CheckDetails();
        //    bool frmPresent = CheckForDuplicateForm(CheckDetails);
        //    if (frmPresent)
        //        return;
        //    else if (!frmPresent)
        //    {
        //        CheckDetails.Show();
        //    }
        //}
    }
}
