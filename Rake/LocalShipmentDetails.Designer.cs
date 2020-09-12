namespace Rake
{
    partial class LocalShipmentDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalShipmentDetails));
            this.TxtInvoiceSearch = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GvShipment = new System.Windows.Forms.DataGridView();
            this.DownloadFile = new System.Windows.Forms.Button();
            this.BtnUpload = new System.Windows.Forms.Button();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.TxtUploadfile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DdlParty = new System.Windows.Forms.ComboBox();
            this.TxtGrossWt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtShipDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtInvioceNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtShipmentNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnNew = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtShipmentID = new System.Windows.Forms.TextBox();
            this.TxtMaterial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DdlProduct = new System.Windows.Forms.ComboBox();
            this.DdlFrom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtThickness = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtWidth = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvShipment)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtInvoiceSearch
            // 
            this.TxtInvoiceSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInvoiceSearch.Location = new System.Drawing.Point(372, 19);
            this.TxtInvoiceSearch.Name = "TxtInvoiceSearch";
            this.TxtInvoiceSearch.Size = new System.Drawing.Size(100, 24);
            this.TxtInvoiceSearch.TabIndex = 20;
            this.TxtInvoiceSearch.Click += new System.EventHandler(this.TxtInvoiceSearch_TextChanged);
            this.TxtInvoiceSearch.TextChanged += new System.EventHandler(this.TxtInvoiceSearch_TextChanged_1);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(291, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 18);
            this.label18.TabIndex = 269;
            this.label18.Text = "Invoice No";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.GvShipment);
            this.groupBox1.Controls.Add(this.TxtInvoiceSearch);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Location = new System.Drawing.Point(17, 291);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 286);
            this.groupBox1.TabIndex = 267;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // GvShipment
            // 
            this.GvShipment.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvShipment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GvShipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvShipment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GvShipment.Location = new System.Drawing.Point(15, 54);
            this.GvShipment.Name = "GvShipment";
            this.GvShipment.Size = new System.Drawing.Size(755, 216);
            this.GvShipment.TabIndex = 21;
            this.GvShipment.SelectionChanged += new System.EventHandler(this.GvShipment_SelectionChanged);
            // 
            // DownloadFile
            // 
            this.DownloadFile.Location = new System.Drawing.Point(168, 261);
            this.DownloadFile.Name = "DownloadFile";
            this.DownloadFile.Size = new System.Drawing.Size(75, 23);
            this.DownloadFile.TabIndex = 15;
            this.DownloadFile.Text = "Download";
            this.DownloadFile.UseVisualStyleBackColor = true;
            this.DownloadFile.Click += new System.EventHandler(this.DownloadFile_Click);
            // 
            // BtnUpload
            // 
            this.BtnUpload.Location = new System.Drawing.Point(625, 261);
            this.BtnUpload.Name = "BtnUpload";
            this.BtnUpload.Size = new System.Drawing.Size(75, 23);
            this.BtnUpload.TabIndex = 18;
            this.BtnUpload.Text = "Upload";
            this.BtnUpload.UseVisualStyleBackColor = true;
            this.BtnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(534, 261);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtnBrowse.TabIndex = 17;
            this.BtnBrowse.Text = "Browse";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // TxtUploadfile
            // 
            this.TxtUploadfile.Enabled = false;
            this.TxtUploadfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUploadfile.Location = new System.Drawing.Point(283, 261);
            this.TxtUploadfile.Name = "TxtUploadfile";
            this.TxtUploadfile.Size = new System.Drawing.Size(253, 24);
            this.TxtUploadfile.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(64, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 18);
            this.label6.TabIndex = 258;
            this.label6.Text = "Customer";
            // 
            // DdlParty
            // 
            this.DdlParty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlParty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlParty.FormattingEnabled = true;
            this.DdlParty.Location = new System.Drawing.Point(140, 183);
            this.DdlParty.Name = "DdlParty";
            this.DdlParty.Size = new System.Drawing.Size(138, 21);
            this.DdlParty.TabIndex = 8;
            // 
            // TxtGrossWt
            // 
            this.TxtGrossWt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtGrossWt.Location = new System.Drawing.Point(609, 142);
            this.TxtGrossWt.Name = "TxtGrossWt";
            this.TxtGrossWt.Size = new System.Drawing.Size(100, 24);
            this.TxtGrossWt.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(533, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 18);
            this.label12.TabIndex = 255;
            this.label12.Text = "Gross Wt";
            // 
            // TxtShipDate
            // 
            this.TxtShipDate.Location = new System.Drawing.Point(140, 148);
            this.TxtShipDate.Name = "TxtShipDate";
            this.TxtShipDate.Size = new System.Drawing.Size(115, 20);
            this.TxtShipDate.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(294, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 18);
            this.label9.TabIndex = 252;
            this.label9.Text = "Material";
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(33, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 18);
            this.label10.TabIndex = 251;
            this.label10.Text = "Shipment Date";
            // 
            // TxtInvioceNo
            // 
            this.TxtInvioceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInvioceNo.Location = new System.Drawing.Point(609, 105);
            this.TxtInvioceNo.Name = "TxtInvioceNo";
            this.TxtInvioceNo.Size = new System.Drawing.Size(100, 24);
            this.TxtInvioceNo.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(529, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 18);
            this.label7.TabIndex = 248;
            this.label7.Text = "Invoice No";
            // 
            // TxtShipmentNo
            // 
            this.TxtShipmentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtShipmentNo.Location = new System.Drawing.Point(356, 105);
            this.TxtShipmentNo.Name = "TxtShipmentNo";
            this.TxtShipmentNo.Size = new System.Drawing.Size(100, 24);
            this.TxtShipmentNo.TabIndex = 1;
            this.TxtShipmentNo.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(260, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 247;
            this.label1.Text = "Shipment No";
            this.label1.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnNew,
            this.tsBtnEdit,
            this.tsBtnSave,
            this.toolStripButton1,
            this.tsBtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(817, 39);
            this.toolStrip1.TabIndex = 245;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnNew
            // 
            this.tsBtnNew.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNew.Image")));
            this.tsBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNew.Name = "tsBtnNew";
            this.tsBtnNew.Size = new System.Drawing.Size(67, 36);
            this.tsBtnNew.Text = "&New";
            this.tsBtnNew.ToolTipText = "New";
            // 
            // tsBtnEdit
            // 
            this.tsBtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnEdit.Image")));
            this.tsBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEdit.Name = "tsBtnEdit";
            this.tsBtnEdit.Size = new System.Drawing.Size(63, 36);
            this.tsBtnEdit.Text = "&Edit";
            this.tsBtnEdit.ToolTipText = "Edit";
            this.tsBtnEdit.Click += new System.EventHandler(this.tsBtnEdit_Click);
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSave.Image")));
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(67, 36);
            this.tsBtnSave.Text = "&Save";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(61, 36);
            this.toolStripButton1.Text = "E&xit";
            this.toolStripButton1.DoubleClick += new System.EventHandler(this.tsBtnExit_Click);
            // 
            // tsBtnRefresh
            // 
            this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefresh.Name = "tsBtnRefresh";
            this.tsBtnRefresh.Size = new System.Drawing.Size(50, 36);
            this.tsBtnRefresh.Text = "Refresh";
            this.tsBtnRefresh.Click += new System.EventHandler(this.tsBtnRefresh_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Tan;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(34, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 25);
            this.label4.TabIndex = 246;
            this.label4.Text = "Local Shipment Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 18);
            this.label2.TabIndex = 243;
            this.label2.Text = "Rake Shipment ID";
            // 
            // TxtShipmentID
            // 
            this.TxtShipmentID.Enabled = false;
            this.TxtShipmentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtShipmentID.Location = new System.Drawing.Point(140, 105);
            this.TxtShipmentID.Name = "TxtShipmentID";
            this.TxtShipmentID.Size = new System.Drawing.Size(100, 24);
            this.TxtShipmentID.TabIndex = 244;
            // 
            // TxtMaterial
            // 
            this.TxtMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMaterial.Location = new System.Drawing.Point(356, 144);
            this.TxtMaterial.Name = "TxtMaterial";
            this.TxtMaterial.Size = new System.Drawing.Size(100, 24);
            this.TxtMaterial.TabIndex = 6;
            this.TxtMaterial.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(293, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 18);
            this.label5.TabIndex = 273;
            this.label5.Text = "Product";
            // 
            // DdlProduct
            // 
            this.DdlProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlProduct.FormattingEnabled = true;
            this.DdlProduct.Location = new System.Drawing.Point(356, 180);
            this.DdlProduct.Name = "DdlProduct";
            this.DdlProduct.Size = new System.Drawing.Size(121, 21);
            this.DdlProduct.TabIndex = 9;
            // 
            // DdlFrom
            // 
            this.DdlFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlFrom.FormattingEnabled = true;
            this.DdlFrom.Location = new System.Drawing.Point(609, 180);
            this.DdlFrom.Name = "DdlFrom";
            this.DdlFrom.Size = new System.Drawing.Size(127, 21);
            this.DdlFrom.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(562, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 274;
            this.label3.Text = "From";
            // 
            // TxtThickness
            // 
            this.TxtThickness.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtThickness.Location = new System.Drawing.Point(140, 219);
            this.TxtThickness.Name = "TxtThickness";
            this.TxtThickness.Size = new System.Drawing.Size(100, 24);
            this.TxtThickness.TabIndex = 12;
            this.TxtThickness.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(62, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 18);
            this.label13.TabIndex = 279;
            this.label13.Text = "Thickness";
            this.label13.Visible = false;
            // 
            // TxtWidth
            // 
            this.TxtWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtWidth.Location = new System.Drawing.Point(356, 222);
            this.TxtWidth.Name = "TxtWidth";
            this.TxtWidth.Size = new System.Drawing.Size(100, 24);
            this.TxtWidth.TabIndex = 13;
            this.TxtWidth.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(307, 225);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 18);
            this.label14.TabIndex = 281;
            this.label14.Text = "Width";
            this.label14.Visible = false;
            // 
            // LocalShipmentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 582);
            this.Controls.Add(this.TxtWidth);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.TxtThickness);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.DdlFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DdlProduct);
            this.Controls.Add(this.TxtMaterial);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DownloadFile);
            this.Controls.Add(this.BtnUpload);
            this.Controls.Add(this.BtnBrowse);
            this.Controls.Add(this.TxtUploadfile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DdlParty);
            this.Controls.Add(this.TxtGrossWt);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TxtShipDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtInvioceNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtShipmentNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtShipmentID);
            this.Name = "LocalShipmentDetails";
            this.Text = "Local Shipment Details";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvShipment)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtInvoiceSearch;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView GvShipment;
        private System.Windows.Forms.Button DownloadFile;
        private System.Windows.Forms.Button BtnUpload;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.TextBox TxtUploadfile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox DdlParty;
        private System.Windows.Forms.TextBox TxtGrossWt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker TxtShipDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtInvioceNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtShipmentNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnNew;
        private System.Windows.Forms.ToolStripButton tsBtnEdit;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtShipmentID;
        private System.Windows.Forms.TextBox TxtMaterial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox DdlProduct;
        private System.Windows.Forms.ComboBox DdlFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtThickness;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtWidth;
        private System.Windows.Forms.Label label14;

    }
}

