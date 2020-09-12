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
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Rake.Reports.Reports
{
    public partial class GenerateGC : Form
    {
        public GenerateGC()
        {
            InitializeComponent();
            this.Hide();
        }


        //private static void MergeMultiplePDFIntoSinglePDF ()
        //{
        //    PdfDocument output;
        //    PdfDocument outputPDFDocument;
        //    if (File.Exists(RakeDatatable.GcPath))
        //    {
        //        outputPDFDocument = PdfReader.Open(RakeDatatable.GcPath, PdfDocumentOpenMode.Modify);
        //    }
        //    else
        //    {
        //        outputPDFDocument = new PdfDocument(RakeDatatable.GcPath);
        //    }
        //        PdfDocument inputPDFDocument = PdfReader.Open("D:\\output.pdf", PdfDocumentOpenMode.Import);
        //        outputPDFDocument.Version = inputPDFDocument.Version;
        //        foreach (PdfPage page in inputPDFDocument.Pages)
        //        {
        //            outputPDFDocument.AddPage(page);
        //        }
        //        output = outputPDFDocument;
        //    output.Save(RakeDatatable.GcPath);
        // }

        private static void MergeMultiplePDFIntoSinglePDF()
        {
            if (File.Exists(RakeDatatable.GcPath))
            {

            PdfDocument outputPDFDocument = new PdfDocument();

            string[] pdfFiles = {  RakeDatatable.GcPath,"D:\\output.pdf" };
            foreach (string pdfFile in pdfFiles)
            {
                PdfDocument inputPDFDocument = PdfReader.Open(pdfFile, PdfDocumentOpenMode.Import);
                outputPDFDocument.Version = inputPDFDocument.Version;
                foreach (PdfPage page in inputPDFDocument.Pages)
                {
                    outputPDFDocument.AddPage(page);
                }
            }
            outputPDFDocument.Save(RakeDatatable.GcPath);
            }
            else
            {
                if (!Directory.Exists(Path.GetDirectoryName(RakeDatatable.GcPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(RakeDatatable.GcPath));
                }
                File.Copy("D:\\output.pdf", RakeDatatable.GcPath);
            }
        }

        private void GenerateGC_Load(object sender, EventArgs e)
        {
            ReportParameter[] parms = new ReportParameter[1];
            parms[0] = new ReportParameter("type", RakeDatatable.type);

            ReportDataSource rds = new ReportDataSource("GcGenerate", RakeDatatable.dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.SetParameters(parms);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = reportViewer1.LocalReport.Render(
                "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

            using (FileStream fs = new FileStream("D:\\output.pdf", FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
            MergeMultiplePDFIntoSinglePDF();
            this.Close();
        }
    }
}
