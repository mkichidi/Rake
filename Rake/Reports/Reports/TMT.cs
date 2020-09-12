using System.Diagnostics;
using System.IO;
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

namespace Rake.Reports.Reports
{
    public partial class TMT : Form
    {
        public TMT()
        {
            InitializeComponent();
        }

        private void TMT_Load(object sender, EventArgs e)
        {

            DataTable dt = RakeDatatable.dt;
            DataTable dtClone = new DataTable();
            dtClone = dt.Clone();

            DataView dv = dt.DefaultView;
            dv.Sort = "WagonNo";
             dt = dv.ToTable();

            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                dt.Rows[i-1]["SlNo"] = i;
            }

            if (dt.DefaultView.ToTable(true, "WagonNo").Rows.Count > 1)
            {
                foreach (DataRow drWagon in dt.DefaultView.ToTable(true, "WagonNo").Rows)
                {
                    DataTable OnWagon = dt.Select("WagonNo ='" + drWagon["WagonNo"] + "'").CopyToDataTable();
                    decimal NetWt = 0M;
                    decimal Weighment = 0M;
                    decimal Short = 0M;

                    foreach (DataRow dr in OnWagon.Rows)
                    {
                        NetWt += Convert.ToDecimal(dr["NetWt"]);
                        Weighment += Convert.ToDecimal(dr["Weighment"]);
                        Short += Convert.ToDecimal(dr["Short"]);
                        dtClone.Rows.Add(dr.ItemArray);
                    }
                    DataRow drs = dt.NewRow();
                    drs["NetWt"] = NetWt;
                    drs["Weighment"] = Weighment;
                    drs["Short"] = Short;

                    dtClone.Rows.Add(drs.ItemArray);
                }
            }

            this.reportViewer1.ProcessingMode = ProcessingMode.Local;

            ReportDataSource rds = new ReportDataSource("TMT", dtClone);


            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
    }
}
