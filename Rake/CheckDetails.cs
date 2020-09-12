using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraEditors.Repository;

namespace FleetManagement
{
    public partial class CheckDetails : Form
    {
        public CheckDetails()
        {
            InitializeComponent();

            if (Convert.ToInt32(DateTime.Now.Date.ToString("dd")) < 31)
            {
                DtSubmitDate.Value = new DateTime(Convert.ToInt32(DateTime.Now.Date.ToString("yyyy")), Convert.ToInt32(DateTime.Now.Date.ToString("MM")), 30);
            }

            if (Convert.ToInt32(DateTime.Now.Date.ToString("dd")) < 20)
            {
                DtSubmitDate.Value = new DateTime(Convert.ToInt32(DateTime.Now.Date.ToString("yyyy")), Convert.ToInt32(DateTime.Now.Date.ToString("MM")), 20);
            }

            if (Convert.ToInt32(DateTime.Now.Date.ToString("dd")) < 10)
            {
                DtSubmitDate.Value = new DateTime(Convert.ToInt32(DateTime.Now.Date.ToString("yyyy")), Convert.ToInt32(DateTime.Now.Date.ToString("MM")), 10);
            }
        }

        private void BtnGetBills_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            //SqlCommand cmd = new SqlCommand("GetCheckDetails", con);
            //cmd.Parameters.AddWithValue("@SubmitDate", DtSubmitDate.Value);
            //cmd.CommandType = CommandType.StoredProcedure;
            //con.Open();
            //SqlDataReader reader;
            //reader = cmd.ExecuteReader();
            //DataTable dataTable = new DataTable();
            //dataTable.Load(reader);

            //CtrlInventoryIssuedataGridView.DataSource = dataTable;
            //this.CtrlInventoryIssuedataGridView.AllowUserToAddRows = false;
            //con.Close();
            ////GvJSWBill.AllowUserToAddRows = true;

            //CtrlInventoryIssuedataGridView.ReadOnly = false;
            //CtrlInventoryIssuedataGridView.Enabled = true;
            //CtrlInventoryIssuedataGridView.Columns["BillNo"].ReadOnly = true;
            //CtrlInventoryIssuedataGridView.Columns["Amount"].ReadOnly = true;
            //CtrlInventoryIssuedataGridView.Columns["Place"].ReadOnly = true;
            //CtrlInventoryIssuedataGridView.Columns["Tonns"].ReadOnly = true;
            //CtrlInventoryIssuedataGridView.Columns["Rate"].ReadOnly = true;
            //CtrlInventoryIssuedataGridView.Columns["Product"].ReadOnly = true;
            //CtrlInventoryIssuedataGridView.Columns["TDS"].ReadOnly = true;
            //CtrlInventoryIssuedataGridView.Columns["Shortage"].ReadOnly = true;

             SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetCheckDetails", con);
            cmd.Parameters.AddWithValue("@SubmitDate", DtSubmitDate.Value);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                //Set up a master-detail relationship between the DataTables
                DataColumn keyColumn = ds.Tables[0].Columns["BillNo"];
                DataColumn foreignKeyColumn = ds.Tables[1].Columns["Bill"];
                ds.Relations.Add("BillRelation", keyColumn, foreignKeyColumn);

                //Bind the grid control to the data source
                GvCheck.DataSource = ds.Tables[0];
                GvCheck.ForceInitialize();


                //Assign a CardView to the relationship
                CardView cardView1 = new CardView(GvCheck);
                GvCheck.LevelTree.Nodes.Add("BillRelation", cardView1);
                //Specify text to be displayed within detail tabs.
                cardView1.ViewCaption = "Bill Details";
        }

        private void CtrlInventoryIssuedataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            decimal dec = 0;
            bool bol = false;
            if (e.ColumnIndex == 7)
            {
                if (decimal.TryParse(CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["Payment"].Value.ToString(), out dec))
                {
                    if ((bool.TryParse(CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["IsTDS"].Value.ToString(), out bol) && Convert.ToBoolean(CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["IsTDS"].Value.ToString())))
                    {
                        CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["TDS"].Value = Convert.ToInt32((Convert.ToInt32(CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["Amount"].Value) * 0.01));
                    }
                    else
                    {
                        CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["TDS"].Value = 0;
                    }
                    CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells[10].Value = Convert.ToInt32(Convert.ToInt32(CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["Amount"].Value) - Convert.ToInt32(CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["Payment"].Value)-Convert.ToInt32(CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["TDS"].Value));
                }
                else
                {
                    MessageBox.Show("Please enter proper Payment Details");
                }
            }

            
            if (e.ColumnIndex == 8)
            {   
                if ((bool.TryParse(CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["IsTDS"].Value.ToString(), out bol) && Convert.ToBoolean(CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["IsTDS"].Value.ToString())))
                {
                    CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["TDS"].Value = Convert.ToInt32((Convert.ToInt32(CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["Amount"].Value) * 0.01));
                }
                else
                {
                    CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["TDS"].Value = 0;
                }
                CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells[10].Value = Convert.ToInt32(Convert.ToInt32(CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["Amount"].Value) - Convert.ToInt32(CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["Payment"].Value) - Convert.ToInt32(CtrlInventoryIssuedataGridView.Rows[e.RowIndex].Cells["TDS"].Value));
            }
        }

        private void CtrlBtnPrintBill_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt =(DataTable) GvCheck.DataSource;
            dt.AcceptChanges();
            foreach (DataRow dr in dt.Rows)
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateCheckDetails", con);
                cmd.Parameters.AddWithValue("@BillNo", dr["BillNo"]);
                cmd.Parameters.AddWithValue("@Payment", dr["Payment"]);
                cmd.Parameters.AddWithValue("@TDS", dr["TDS"]);
                cmd.Parameters.AddWithValue("@IsTDS", dr["IsTDS"]);
                cmd.Parameters.AddWithValue("@Shortage", dr["Shortage"]);
                cmd.Parameters.AddWithValue("@Remarks", dr["Remarks"]);
                cmd.Parameters.AddWithValue("@Passdate", dr["Passdate"]);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Saved Successfully");
            //JswDatatable.dt = dt;
            //JswDatatable.submitDate = DtSubmitDate.Value;
            //FleetManagement.Reports.ReportForms.CheckDetails CheckDetails = new FleetManagement.Reports.ReportForms.CheckDetails();
            //CheckDetails.Show();

            //JswDatatable.dt = dt;
            //JswDatatable.submitDate = DtSubmitDate.Value;
            //FleetManagement.Reports.ReportForms.CheckDetailsAttach CheckDetailsAttach = new FleetManagement.Reports.ReportForms.CheckDetailsAttach();
            //CheckDetailsAttach.Show();
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            //CtrlInventoryIssuedataGridView.Columns["BillNo"].ReadOnly = true;
            //CtrlInventoryIssuedataGridView.Columns["Amount"].ReadOnly = true;
            //CtrlInventoryIssuedataGridView.Columns["Place"].ReadOnly = true;
            //CtrlInventoryIssuedataGridView.Columns["Tonns"].ReadOnly = true;
            //CtrlInventoryIssuedataGridView.Columns["Rate"].ReadOnly = true;
            //CtrlInventoryIssuedataGridView.Columns["Product"].ReadOnly = true;
            //CtrlInventoryIssuedataGridView.Columns["TDS"].ReadOnly = true;
            //CtrlInventoryIssuedataGridView.Columns["Shortage"].ReadOnly = true;

            if (view.FocusedColumn.FieldName == "BillNo" || view.FocusedColumn.FieldName == "Amount" || view.FocusedColumn.FieldName == "Place" || view.FocusedColumn.FieldName == "Tonns" || view.FocusedColumn.FieldName == "Rate" || view.FocusedColumn.FieldName == "Product" || view.FocusedColumn.FieldName == "TDS" || view.FocusedColumn.FieldName == "Shortage" || view.FocusedColumn.FieldName == "SlNo")

                e.Cancel = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            

                  decimal dec = 0;
            bool bol = false;
            if (e.Column.AbsoluteIndex == 7)
            {
                if (decimal.TryParse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Payment"]).ToString(), out dec))
                {
                    if ((bool.TryParse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["IsTDS"]).ToString(), out bol) && Convert.ToBoolean(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["IsTDS"]).ToString())))
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["TDS"], Convert.ToInt32((Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Amount"])) * 0.01)).ToString());
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["TDS"], "0");
                    }


                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["Shortage"],


                        Convert.ToInt32(Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Amount"])) - Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Payment"])) - Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["TDS"]))).ToString());
                }
                else
                {
                    MessageBox.Show("Please enter proper Payment Details");
                }
            }


            if (e.Column.AbsoluteIndex == 8)
            {
                if (decimal.TryParse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Payment"]).ToString(), out dec))
                {
                    if ((bool.TryParse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["IsTDS"]).ToString(), out bol) && Convert.ToBoolean(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["IsTDS"]).ToString())))
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["TDS"], Convert.ToInt32((Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Amount"])) * 0.01)).ToString());
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["TDS"], "0");
                    }


                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["Shortage"],


                        Convert.ToInt32(Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Amount"])) - Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Payment"])) - Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["TDS"]))).ToString());
                }
                else
                {
                    MessageBox.Show("Please enter proper Payment Details");
                }
            }
        }

        private void gridView1_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView gridViewWelds = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //DevExpress.XtraGrid.Views.Grid.GridView gridViewTests = gridViewWelds.GetDetailView(e.RowHandle, e.RelationIndex) as DevExpress.XtraGrid.Views.Grid.GridView;
            //gridViewTests.BeginUpdate();
            //gridViewTests.Columns["ShipmentNo"].ColumnEdit = ;
            ////gridViewTests.Columns["WeldId"].OptionsColumn.ShowInCustomizationForm = false;
            //gridViewTests.EndUpdate();
        }

    }
}
