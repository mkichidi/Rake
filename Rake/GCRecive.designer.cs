namespace Rake
{
    partial class GCRecive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GCRecive));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnNew = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnExit = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtShipment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupBoxShip = new System.Windows.Forms.GroupBox();
            this.TxtDiffereceWt = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.TxtWeighment = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.DdlUnLoad = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.DdlCustomer = new System.Windows.Forms.ComboBox();
            this.DdlFrom = new System.Windows.Forms.ComboBox();
            this.TxtFrom = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.TxtMaterial = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TxtWagon = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TxtCustomer = new System.Windows.Forms.TextBox();
            this.DDLParty = new System.Windows.Forms.ComboBox();
            this.TxtAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.TxtRate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtGCNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DtRecive = new System.Windows.Forms.DateTimePicker();
            this.DDLTo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.datetimeShipment = new System.Windows.Forms.DateTimePicker();
            this.DdlVehicle = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.DdlProduct = new System.Windows.Forms.ComboBox();
            this.TxtProduct = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtGrosswt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtInvoiceNoRc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtShipmentNoRc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LblShipmentID = new System.Windows.Forms.Label();
            this.DownloadFile = new System.Windows.Forms.Button();
            this.BtnUpload = new System.Windows.Forms.Button();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.TxtUploadfile = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.GroupBoxShip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnNew,
            this.tsBtnEdit,
            this.tsBtnSave,
            this.tsBtnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(734, 39);
            this.toolStrip1.TabIndex = 93;
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
            this.tsBtnEdit.Click += new System.EventHandler(this.tsBtnSave_Click);
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
            // tsBtnExit
            // 
            this.tsBtnExit.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnExit.Image")));
            this.tsBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExit.Name = "tsBtnExit";
            this.tsBtnExit.Size = new System.Drawing.Size(61, 36);
            this.tsBtnExit.Text = "E&xit";
            this.tsBtnExit.Click += new System.EventHandler(this.tsBtnExit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Tan;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(32, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 25);
            this.label4.TabIndex = 94;
            this.label4.Text = "Rake GC Recive";
            // 
            // TxtInvoiceNo
            // 
            this.TxtInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInvoiceNo.Location = new System.Drawing.Point(377, 99);
            this.TxtInvoiceNo.Name = "TxtInvoiceNo";
            this.TxtInvoiceNo.Size = new System.Drawing.Size(107, 24);
            this.TxtInvoiceNo.TabIndex = 2;
            this.TxtInvoiceNo.TextChanged += new System.EventHandler(this.TxtInvoiceNo_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(296, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 90;
            this.label3.Text = "Invoice No";
            // 
            // TxtShipment
            // 
            this.TxtShipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtShipment.Location = new System.Drawing.Point(146, 99);
            this.TxtShipment.Name = "TxtShipment";
            this.TxtShipment.Size = new System.Drawing.Size(132, 24);
            this.TxtShipment.TabIndex = 1;
            this.TxtShipment.Visible = false;
            this.TxtShipment.TextChanged += new System.EventHandler(this.TxtShipment_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 88;
            this.label2.Text = "Shipment No";
            this.label2.Visible = false;
            // 
            // GroupBoxShip
            // 
            this.GroupBoxShip.BackColor = System.Drawing.Color.LightBlue;
            this.GroupBoxShip.Controls.Add(this.TxtDiffereceWt);
            this.GroupBoxShip.Controls.Add(this.label20);
            this.GroupBoxShip.Controls.Add(this.TxtWeighment);
            this.GroupBoxShip.Controls.Add(this.label21);
            this.GroupBoxShip.Controls.Add(this.DdlUnLoad);
            this.GroupBoxShip.Controls.Add(this.label19);
            this.GroupBoxShip.Controls.Add(this.DdlCustomer);
            this.GroupBoxShip.Controls.Add(this.DdlFrom);
            this.GroupBoxShip.Controls.Add(this.TxtFrom);
            this.GroupBoxShip.Controls.Add(this.label18);
            this.GroupBoxShip.Controls.Add(this.TxtMaterial);
            this.GroupBoxShip.Controls.Add(this.label16);
            this.GroupBoxShip.Controls.Add(this.TxtWagon);
            this.GroupBoxShip.Controls.Add(this.label15);
            this.GroupBoxShip.Controls.Add(this.TxtCustomer);
            this.GroupBoxShip.Controls.Add(this.DDLParty);
            this.GroupBoxShip.Controls.Add(this.TxtAmount);
            this.GroupBoxShip.Controls.Add(this.label11);
            this.GroupBoxShip.Controls.Add(this.label14);
            this.GroupBoxShip.Controls.Add(this.TxtRate);
            this.GroupBoxShip.Controls.Add(this.label10);
            this.GroupBoxShip.Controls.Add(this.TxtGCNo);
            this.GroupBoxShip.Controls.Add(this.label1);
            this.GroupBoxShip.Controls.Add(this.label5);
            this.GroupBoxShip.Controls.Add(this.DtRecive);
            this.GroupBoxShip.Controls.Add(this.DDLTo);
            this.GroupBoxShip.Controls.Add(this.label8);
            this.GroupBoxShip.Controls.Add(this.datetimeShipment);
            this.GroupBoxShip.Controls.Add(this.DdlVehicle);
            this.GroupBoxShip.Controls.Add(this.label17);
            this.GroupBoxShip.Controls.Add(this.DdlProduct);
            this.GroupBoxShip.Controls.Add(this.TxtProduct);
            this.GroupBoxShip.Controls.Add(this.label13);
            this.GroupBoxShip.Controls.Add(this.TxtGrosswt);
            this.GroupBoxShip.Controls.Add(this.label12);
            this.GroupBoxShip.Controls.Add(this.label9);
            this.GroupBoxShip.Controls.Add(this.TxtInvoiceNoRc);
            this.GroupBoxShip.Controls.Add(this.label7);
            this.GroupBoxShip.Controls.Add(this.TxtShipmentNoRc);
            this.GroupBoxShip.Controls.Add(this.label6);
            this.GroupBoxShip.Enabled = false;
            this.GroupBoxShip.Location = new System.Drawing.Point(24, 164);
            this.GroupBoxShip.Name = "GroupBoxShip";
            this.GroupBoxShip.Size = new System.Drawing.Size(683, 253);
            this.GroupBoxShip.TabIndex = 101;
            this.GroupBoxShip.TabStop = false;
            this.GroupBoxShip.Text = "Shipment Details";
            this.GroupBoxShip.Enter += new System.EventHandler(this.GroupBoxShip_Enter);
            // 
            // TxtDiffereceWt
            // 
            this.TxtDiffereceWt.Enabled = false;
            this.TxtDiffereceWt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDiffereceWt.Location = new System.Drawing.Point(545, 211);
            this.TxtDiffereceWt.Name = "TxtDiffereceWt";
            this.TxtDiffereceWt.Size = new System.Drawing.Size(100, 24);
            this.TxtDiffereceWt.TabIndex = 18;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(475, 214);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 18);
            this.label20.TabIndex = 199;
            this.label20.Text = "Short Wt";
            // 
            // TxtWeighment
            // 
            this.TxtWeighment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtWeighment.Location = new System.Drawing.Point(323, 211);
            this.TxtWeighment.Name = "TxtWeighment";
            this.TxtWeighment.Size = new System.Drawing.Size(100, 24);
            this.TxtWeighment.TabIndex = 17;
            this.TxtWeighment.TextChanged += new System.EventHandler(this.TxtWeighment_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(238, 214);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 18);
            this.label21.TabIndex = 198;
            this.label21.Text = "Weighment";
            // 
            // DdlUnLoad
            // 
            this.DdlUnLoad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlUnLoad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlUnLoad.FormattingEnabled = true;
            this.DdlUnLoad.Location = new System.Drawing.Point(108, 215);
            this.DdlUnLoad.Name = "DdlUnLoad";
            this.DdlUnLoad.Size = new System.Drawing.Size(115, 21);
            this.DdlUnLoad.TabIndex = 16;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(42, 216);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 18);
            this.label19.TabIndex = 195;
            this.label19.Text = "Un Load";
            // 
            // DdlCustomer
            // 
            this.DdlCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlCustomer.FormattingEnabled = true;
            this.DdlCustomer.Location = new System.Drawing.Point(544, 107);
            this.DdlCustomer.Name = "DdlCustomer";
            this.DdlCustomer.Size = new System.Drawing.Size(127, 21);
            this.DdlCustomer.TabIndex = 193;
            this.DdlCustomer.Visible = false;
            // 
            // DdlFrom
            // 
            this.DdlFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlFrom.FormattingEnabled = true;
            this.DdlFrom.Location = new System.Drawing.Point(108, 108);
            this.DdlFrom.Name = "DdlFrom";
            this.DdlFrom.Size = new System.Drawing.Size(127, 21);
            this.DdlFrom.TabIndex = 191;
            this.DdlFrom.Visible = false;
            this.DdlFrom.SelectedIndexChanged += new System.EventHandler(this.DdlFrom_SelectedIndexChanged);
            // 
            // TxtFrom
            // 
            this.TxtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFrom.Location = new System.Drawing.Point(108, 104);
            this.TxtFrom.Name = "TxtFrom";
            this.TxtFrom.ReadOnly = true;
            this.TxtFrom.Size = new System.Drawing.Size(127, 24);
            this.TxtFrom.TabIndex = 192;
            this.TxtFrom.DoubleClick += new System.EventHandler(this.TxtFrom_DoubleClick);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(61, 108);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 18);
            this.label18.TabIndex = 190;
            this.label18.Text = "From";
            // 
            // TxtMaterial
            // 
            this.TxtMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMaterial.Location = new System.Drawing.Point(544, 69);
            this.TxtMaterial.Name = "TxtMaterial";
            this.TxtMaterial.ReadOnly = true;
            this.TxtMaterial.Size = new System.Drawing.Size(120, 24);
            this.TxtMaterial.TabIndex = 187;
            this.TxtMaterial.DoubleClick += new System.EventHandler(this.TxtShipmentNoRc_DoubleClick);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(482, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 18);
            this.label16.TabIndex = 188;
            this.label16.Text = "Material";
            // 
            // TxtWagon
            // 
            this.TxtWagon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtWagon.Location = new System.Drawing.Point(323, 69);
            this.TxtWagon.Name = "TxtWagon";
            this.TxtWagon.ReadOnly = true;
            this.TxtWagon.Size = new System.Drawing.Size(120, 24);
            this.TxtWagon.TabIndex = 185;
            this.TxtWagon.DoubleClick += new System.EventHandler(this.TxtShipmentNoRc_DoubleClick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(242, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 18);
            this.label15.TabIndex = 186;
            this.label15.Text = "Wagon No";
            // 
            // TxtCustomer
            // 
            this.TxtCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCustomer.Location = new System.Drawing.Point(544, 107);
            this.TxtCustomer.Name = "TxtCustomer";
            this.TxtCustomer.ReadOnly = true;
            this.TxtCustomer.Size = new System.Drawing.Size(127, 24);
            this.TxtCustomer.TabIndex = 184;
            this.TxtCustomer.DoubleClick += new System.EventHandler(this.TxtFrom_DoubleClick);
            // 
            // DDLParty
            // 
            this.DDLParty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DDLParty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DDLParty.FormattingEnabled = true;
            this.DDLParty.Location = new System.Drawing.Point(544, 108);
            this.DDLParty.Name = "DDLParty";
            this.DDLParty.Size = new System.Drawing.Size(127, 21);
            this.DDLParty.TabIndex = 11;
            this.DDLParty.Visible = false;
            // 
            // TxtAmount
            // 
            this.TxtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAmount.Location = new System.Drawing.Point(544, 147);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.ReadOnly = true;
            this.TxtAmount.Size = new System.Drawing.Size(120, 24);
            this.TxtAmount.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(481, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 18);
            this.label11.TabIndex = 181;
            this.label11.Text = "Amount";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(466, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 18);
            this.label14.TabIndex = 183;
            this.label14.Text = "Customer";
            // 
            // TxtRate
            // 
            this.TxtRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRate.Location = new System.Drawing.Point(323, 144);
            this.TxtRate.Name = "TxtRate";
            this.TxtRate.ReadOnly = true;
            this.TxtRate.Size = new System.Drawing.Size(120, 24);
            this.TxtRate.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(284, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 18);
            this.label10.TabIndex = 179;
            this.label10.Text = "Rate";
            // 
            // TxtGCNo
            // 
            this.TxtGCNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtGCNo.Location = new System.Drawing.Point(108, 144);
            this.TxtGCNo.Name = "TxtGCNo";
            this.TxtGCNo.Size = new System.Drawing.Size(120, 24);
            this.TxtGCNo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 174;
            this.label1.Text = "Gc No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(295, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 18);
            this.label5.TabIndex = 176;
            this.label5.Text = "To";
            // 
            // DtRecive
            // 
            this.DtRecive.Location = new System.Drawing.Point(323, 182);
            this.DtRecive.Name = "DtRecive";
            this.DtRecive.Size = new System.Drawing.Size(115, 20);
            this.DtRecive.TabIndex = 13;
            // 
            // DDLTo
            // 
            this.DDLTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DDLTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DDLTo.FormattingEnabled = true;
            this.DDLTo.Location = new System.Drawing.Point(323, 107);
            this.DDLTo.Name = "DDLTo";
            this.DDLTo.Size = new System.Drawing.Size(136, 21);
            this.DDLTo.TabIndex = 10;
            this.DDLTo.SelectedIndexChanged += new System.EventHandler(this.DdlFrom_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(233, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 18);
            this.label8.TabIndex = 172;
            this.label8.Text = "Recive Date";
            // 
            // datetimeShipment
            // 
            this.datetimeShipment.Location = new System.Drawing.Point(108, 181);
            this.datetimeShipment.Name = "datetimeShipment";
            this.datetimeShipment.Size = new System.Drawing.Size(115, 20);
            this.datetimeShipment.TabIndex = 12;
            this.datetimeShipment.ValueChanged += new System.EventHandler(this.datetimeShipment_ValueChanged);
            // 
            // DdlVehicle
            // 
            this.DdlVehicle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlVehicle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlVehicle.FormattingEnabled = true;
            this.DdlVehicle.Location = new System.Drawing.Point(544, 181);
            this.DdlVehicle.Name = "DdlVehicle";
            this.DdlVehicle.Size = new System.Drawing.Size(127, 21);
            this.DdlVehicle.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(461, 182);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 18);
            this.label17.TabIndex = 167;
            this.label17.Text = "Vehicle No";
            // 
            // DdlProduct
            // 
            this.DdlProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlProduct.FormattingEnabled = true;
            this.DdlProduct.Location = new System.Drawing.Point(544, 35);
            this.DdlProduct.Name = "DdlProduct";
            this.DdlProduct.Size = new System.Drawing.Size(127, 21);
            this.DdlProduct.TabIndex = 5;
            this.DdlProduct.Visible = false;
            // 
            // TxtProduct
            // 
            this.TxtProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProduct.Location = new System.Drawing.Point(544, 31);
            this.TxtProduct.Name = "TxtProduct";
            this.TxtProduct.ReadOnly = true;
            this.TxtProduct.Size = new System.Drawing.Size(127, 24);
            this.TxtProduct.TabIndex = 161;
            this.TxtProduct.DoubleClick += new System.EventHandler(this.TxtFrom_DoubleClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(480, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 18);
            this.label13.TabIndex = 160;
            this.label13.Text = "Product";
            // 
            // TxtGrosswt
            // 
            this.TxtGrosswt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtGrosswt.Location = new System.Drawing.Point(108, 66);
            this.TxtGrosswt.Name = "TxtGrosswt";
            this.TxtGrosswt.ReadOnly = true;
            this.TxtGrosswt.Size = new System.Drawing.Size(120, 24);
            this.TxtGrosswt.TabIndex = 7;
            this.TxtGrosswt.DoubleClick += new System.EventHandler(this.TxtShipmentNoRc_DoubleClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(35, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 18);
            this.label12.TabIndex = 151;
            this.label12.Text = "Gross Wt";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 18);
            this.label9.TabIndex = 147;
            this.label9.Text = "Shipment Date";
            // 
            // TxtInvoiceNoRc
            // 
            this.TxtInvoiceNoRc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInvoiceNoRc.Location = new System.Drawing.Point(323, 31);
            this.TxtInvoiceNoRc.Name = "TxtInvoiceNoRc";
            this.TxtInvoiceNoRc.ReadOnly = true;
            this.TxtInvoiceNoRc.Size = new System.Drawing.Size(136, 24);
            this.TxtInvoiceNoRc.TabIndex = 4;
            this.TxtInvoiceNoRc.DoubleClick += new System.EventHandler(this.TxtShipmentNoRc_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 18);
            this.label7.TabIndex = 102;
            this.label7.Text = "Shipment No";
            // 
            // TxtShipmentNoRc
            // 
            this.TxtShipmentNoRc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtShipmentNoRc.Location = new System.Drawing.Point(108, 31);
            this.TxtShipmentNoRc.Name = "TxtShipmentNoRc";
            this.TxtShipmentNoRc.ReadOnly = true;
            this.TxtShipmentNoRc.Size = new System.Drawing.Size(120, 24);
            this.TxtShipmentNoRc.TabIndex = 3;
            this.TxtShipmentNoRc.DoubleClick += new System.EventHandler(this.TxtShipmentNoRc_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(243, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 18);
            this.label6.TabIndex = 104;
            this.label6.Text = "Invoice No";
            // 
            // LblShipmentID
            // 
            this.LblShipmentID.AutoSize = true;
            this.LblShipmentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblShipmentID.Location = new System.Drawing.Point(421, 65);
            this.LblShipmentID.Name = "LblShipmentID";
            this.LblShipmentID.Size = new System.Drawing.Size(0, 18);
            this.LblShipmentID.TabIndex = 156;
            this.LblShipmentID.Visible = false;
            // 
            // DownloadFile
            // 
            this.DownloadFile.Location = new System.Drawing.Point(99, 134);
            this.DownloadFile.Name = "DownloadFile";
            this.DownloadFile.Size = new System.Drawing.Size(75, 23);
            this.DownloadFile.TabIndex = 157;
            this.DownloadFile.Text = "Download";
            this.DownloadFile.UseVisualStyleBackColor = true;
            this.DownloadFile.Click += new System.EventHandler(this.DownloadFile_Click);
            // 
            // BtnUpload
            // 
            this.BtnUpload.Location = new System.Drawing.Point(556, 134);
            this.BtnUpload.Name = "BtnUpload";
            this.BtnUpload.Size = new System.Drawing.Size(75, 23);
            this.BtnUpload.TabIndex = 160;
            this.BtnUpload.Text = "Upload";
            this.BtnUpload.UseVisualStyleBackColor = true;
            this.BtnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(465, 134);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtnBrowse.TabIndex = 159;
            this.BtnBrowse.Text = "Browse";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // TxtUploadfile
            // 
            this.TxtUploadfile.Enabled = false;
            this.TxtUploadfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUploadfile.Location = new System.Drawing.Point(214, 134);
            this.TxtUploadfile.Name = "TxtUploadfile";
            this.TxtUploadfile.Size = new System.Drawing.Size(253, 24);
            this.TxtUploadfile.TabIndex = 158;
            // 
            // GCRecive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 429);
            this.Controls.Add(this.DownloadFile);
            this.Controls.Add(this.BtnUpload);
            this.Controls.Add(this.BtnBrowse);
            this.Controls.Add(this.TxtUploadfile);
            this.Controls.Add(this.LblShipmentID);
            this.Controls.Add(this.GroupBoxShip);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtInvoiceNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtShipment);
            this.Controls.Add(this.label2);
            this.Name = "GCRecive";
            this.Text = "Rake GC Recive";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.GroupBoxShip.ResumeLayout(false);
            this.GroupBoxShip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnNew;
        private System.Windows.Forms.ToolStripButton tsBtnEdit;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.ToolStripButton tsBtnExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtInvoiceNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtShipment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GroupBoxShip;
        private System.Windows.Forms.TextBox TxtInvoiceNoRc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtShipmentNoRc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtGrosswt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LblShipmentID;
        private System.Windows.Forms.TextBox TxtProduct;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox DdlProduct;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox DdlVehicle;
        private System.Windows.Forms.DateTimePicker datetimeShipment;
        private System.Windows.Forms.ComboBox DDLParty;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtRate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox DDLTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtGCNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtRecive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtCustomer;
        private System.Windows.Forms.TextBox TxtWagon;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TxtMaterial;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox DdlFrom;
        private System.Windows.Forms.TextBox TxtFrom;
        private System.Windows.Forms.ComboBox DdlCustomer;
        private System.Windows.Forms.ComboBox DdlUnLoad;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TxtDiffereceWt;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TxtWeighment;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button DownloadFile;
        private System.Windows.Forms.Button BtnUpload;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.TextBox TxtUploadfile;
    }
}