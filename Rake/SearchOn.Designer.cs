namespace Rake
{
    partial class SearchOn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TxtGcNoSearch = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.TxtInvoiceSearch = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TSxtSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.DtFrom = new System.Windows.Forms.DateTimePicker();
            this.DdlDestination = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.CmbProduct = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.DdlCustomer = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.DdlVehicle = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.label16 = new System.Windows.Forms.Label();
            this.DdlRakeType = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.DdlTransport = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DdlOwnTransport = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.DdlFrom = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtBillNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DdlDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlVehicle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlRakeType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlTransport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlOwnTransport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Rake.Reports.ReportForms.Searc.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 198);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1216, 324);
            this.reportViewer1.TabIndex = 0;
            // 
            // TxtGcNoSearch
            // 
            this.TxtGcNoSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtGcNoSearch.Location = new System.Drawing.Point(730, 21);
            this.TxtGcNoSearch.Name = "TxtGcNoSearch";
            this.TxtGcNoSearch.Size = new System.Drawing.Size(100, 24);
            this.TxtGcNoSearch.TabIndex = 179;
            this.TxtGcNoSearch.TextChanged += new System.EventHandler(this.TxtShipmentSearch_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(672, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 18);
            this.label17.TabIndex = 182;
            this.label17.Text = "GC No";
            // 
            // TxtInvoiceSearch
            // 
            this.TxtInvoiceSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInvoiceSearch.Location = new System.Drawing.Point(545, 21);
            this.TxtInvoiceSearch.Name = "TxtInvoiceSearch";
            this.TxtInvoiceSearch.Size = new System.Drawing.Size(100, 24);
            this.TxtInvoiceSearch.TabIndex = 178;
            this.TxtInvoiceSearch.TextChanged += new System.EventHandler(this.TxtInvoiceSearch_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(464, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 18);
            this.label18.TabIndex = 181;
            this.label18.Text = "Invoice No";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(47, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 18);
            this.label8.TabIndex = 214;
            this.label8.Text = "Destination";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(442, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 18);
            this.label5.TabIndex = 212;
            this.label5.Text = "Product";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(767, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 216;
            this.label1.Text = "Customer";
            // 
            // TSxtSearch
            // 
            this.TSxtSearch.Location = new System.Drawing.Point(1141, 105);
            this.TSxtSearch.Name = "TSxtSearch";
            this.TSxtSearch.Size = new System.Drawing.Size(75, 23);
            this.TSxtSearch.TabIndex = 218;
            this.TSxtSearch.Text = "Search";
            this.TSxtSearch.UseVisualStyleBackColor = true;
            this.TSxtSearch.Click += new System.EventHandler(this.TSxtSearch_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1028, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 219;
            this.button1.Text = "Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 220;
            this.label2.Text = "Vehicle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(945, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 18);
            this.label4.TabIndex = 227;
            this.label4.Text = "To";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(977, 104);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(115, 20);
            this.dtTo.TabIndex = 226;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(718, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 18);
            this.label6.TabIndex = 225;
            this.label6.Text = "Shipment Date";
            // 
            // DtFrom
            // 
            this.DtFrom.Location = new System.Drawing.Point(824, 104);
            this.DtFrom.Name = "DtFrom";
            this.DtFrom.Size = new System.Drawing.Size(115, 20);
            this.DtFrom.TabIndex = 224;
            // 
            // DdlDestination
            // 
            this.DdlDestination.EditValue = "";
            this.DdlDestination.Location = new System.Drawing.Point(132, 66);
            this.DdlDestination.Name = "DdlDestination";
            this.DdlDestination.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DdlDestination.Size = new System.Drawing.Size(267, 20);
            this.DdlDestination.TabIndex = 228;
            // 
            // CmbProduct
            // 
            this.CmbProduct.EditValue = "";
            this.CmbProduct.Location = new System.Drawing.Point(508, 67);
            this.CmbProduct.Name = "CmbProduct";
            this.CmbProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbProduct.Size = new System.Drawing.Size(225, 20);
            this.CmbProduct.TabIndex = 229;
            // 
            // DdlCustomer
            // 
            this.DdlCustomer.EditValue = "";
            this.DdlCustomer.Location = new System.Drawing.Point(847, 67);
            this.DdlCustomer.Name = "DdlCustomer";
            this.DdlCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DdlCustomer.Size = new System.Drawing.Size(242, 20);
            this.DdlCustomer.TabIndex = 230;
            // 
            // DdlVehicle
            // 
            this.DdlVehicle.EditValue = "";
            this.DdlVehicle.Location = new System.Drawing.Point(132, 105);
            this.DdlVehicle.Name = "DdlVehicle";
            this.DdlVehicle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DdlVehicle.Size = new System.Drawing.Size(245, 20);
            this.DdlVehicle.TabIndex = 231;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(427, 109);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 18);
            this.label16.TabIndex = 297;
            this.label16.Text = "Rake Type";
            // 
            // DdlRakeType
            // 
            this.DdlRakeType.EditValue = "";
            this.DdlRakeType.Location = new System.Drawing.Point(508, 107);
            this.DdlRakeType.Name = "DdlRakeType";
            this.DdlRakeType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DdlRakeType.Size = new System.Drawing.Size(190, 20);
            this.DdlRakeType.TabIndex = 298;
            // 
            // DdlTransport
            // 
            this.DdlTransport.EditValue = "";
            this.DdlTransport.Location = new System.Drawing.Point(510, 147);
            this.DdlTransport.Name = "DdlTransport";
            this.DdlTransport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DdlTransport.Size = new System.Drawing.Size(245, 20);
            this.DdlTransport.TabIndex = 300;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(388, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 18);
            this.label7.TabIndex = 299;
            this.label7.Text = "Transport Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Tan;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(30, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 25);
            this.label3.TabIndex = 301;
            this.label3.Text = "Search on All";
            // 
            // DdlOwnTransport
            // 
            this.DdlOwnTransport.EditValue = "";
            this.DdlOwnTransport.Location = new System.Drawing.Point(904, 148);
            this.DdlOwnTransport.Name = "DdlOwnTransport";
            this.DdlOwnTransport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DdlOwnTransport.Size = new System.Drawing.Size(245, 20);
            this.DdlOwnTransport.TabIndex = 303;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(794, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 18);
            this.label9.TabIndex = 302;
            this.label9.Text = "Own Transport";
            // 
            // DdlFrom
            // 
            this.DdlFrom.EditValue = "";
            this.DdlFrom.Location = new System.Drawing.Point(132, 146);
            this.DdlFrom.Name = "DdlFrom";
            this.DdlFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DdlFrom.Size = new System.Drawing.Size(250, 20);
            this.DdlFrom.TabIndex = 305;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(85, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 18);
            this.label10.TabIndex = 304;
            this.label10.Text = "From";
            // 
            // TxtBillNo
            // 
            this.TxtBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBillNo.Location = new System.Drawing.Point(340, 20);
            this.TxtBillNo.Name = "TxtBillNo";
            this.TxtBillNo.Size = new System.Drawing.Size(100, 24);
            this.TxtBillNo.TabIndex = 306;
            this.TxtBillNo.TextChanged += new System.EventHandler(this.TxtBillNo_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(245, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 18);
            this.label11.TabIndex = 307;
            this.label11.Text = "Fright Bill No";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(875, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 308;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SearchOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 523);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TxtBillNo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DdlFrom);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.DdlOwnTransport);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DdlTransport);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DdlRakeType);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.DdlVehicle);
            this.Controls.Add(this.DdlCustomer);
            this.Controls.Add(this.CmbProduct);
            this.Controls.Add(this.DdlDestination);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DtFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TSxtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtGcNoSearch);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.TxtInvoiceSearch);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.reportViewer1);
            this.Name = "SearchOn";
            this.Text = "Search On All";
            ((System.ComponentModel.ISupportInitialize)(this.DdlDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlVehicle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlRakeType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlTransport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlOwnTransport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlFrom.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        //private JswBill JswBill;
        private System.Windows.Forms.TextBox TxtGcNoSearch;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TxtInvoiceSearch;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TSxtSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DtFrom;
        private DevExpress.XtraEditors.CheckedComboBoxEdit DdlDestination;
        private DevExpress.XtraEditors.CheckedComboBoxEdit CmbProduct;
        private DevExpress.XtraEditors.CheckedComboBoxEdit DdlCustomer;
        private DevExpress.XtraEditors.CheckedComboBoxEdit DdlVehicle;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.CheckedComboBoxEdit DdlRakeType;
        private DevExpress.XtraEditors.CheckedComboBoxEdit DdlTransport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.CheckedComboBoxEdit DdlOwnTransport;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.CheckedComboBoxEdit DdlFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtBillNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
    }
}