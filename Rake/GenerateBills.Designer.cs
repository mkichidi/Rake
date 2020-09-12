namespace Rake
{
    partial class GenerateBills
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
            this.GvRakeBill = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.DdlRakeNo = new System.Windows.Forms.ComboBox();
            this.DdlRakeType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DDLYear = new System.Windows.Forms.ComboBox();
            this.DDLMonth = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnGetBills = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DtSubmitDate = new System.Windows.Forms.DateTimePicker();
            this.CtrlBtnPrintBill = new System.Windows.Forms.Button();
            this.TxtHandlingBill = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TxtFrightBill = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtShipmentNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtHosurHandling = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtHosurFright = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TxtMaddurHandling = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtMaddurFright = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GvRakeBill)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // GvRakeBill
            // 
            this.GvRakeBill.AllowUserToAddRows = false;
            this.GvRakeBill.AllowUserToDeleteRows = false;
            this.GvRakeBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GvRakeBill.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvRakeBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GvRakeBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvRakeBill.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GvRakeBill.Location = new System.Drawing.Point(12, 201);
            this.GvRakeBill.Name = "GvRakeBill";
            this.GvRakeBill.ReadOnly = true;
            this.GvRakeBill.Size = new System.Drawing.Size(1413, 216);
            this.GvRakeBill.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Tan;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 25);
            this.label4.TabIndex = 162;
            this.label4.Text = "Generate Rake Bill";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.DdlRakeNo);
            this.groupBox1.Controls.Add(this.DdlRakeType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DDLYear);
            this.groupBox1.Controls.Add(this.DDLMonth);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.BtnGetBills);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DtSubmitDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1413, 71);
            this.groupBox1.TabIndex = 186;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(593, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 18);
            this.label3.TabIndex = 289;
            this.label3.Text = "Rake No";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(352, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 18);
            this.label16.TabIndex = 287;
            this.label16.Text = "Rake Type";
            // 
            // DdlRakeNo
            // 
            this.DdlRakeNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlRakeNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlRakeNo.Enabled = false;
            this.DdlRakeNo.FormattingEnabled = true;
            this.DdlRakeNo.Location = new System.Drawing.Point(662, 30);
            this.DdlRakeNo.Name = "DdlRakeNo";
            this.DdlRakeNo.Size = new System.Drawing.Size(63, 21);
            this.DdlRakeNo.TabIndex = 4;
            this.DdlRakeNo.SelectedIndexChanged += new System.EventHandler(this.DdlRakeNo_SelectedIndexChanged);
            // 
            // DdlRakeType
            // 
            this.DdlRakeType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlRakeType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlRakeType.Enabled = false;
            this.DdlRakeType.FormattingEnabled = true;
            this.DdlRakeType.Location = new System.Drawing.Point(433, 31);
            this.DdlRakeType.Name = "DdlRakeType";
            this.DdlRakeType.Size = new System.Drawing.Size(121, 21);
            this.DdlRakeType.TabIndex = 3;
            this.DdlRakeType.SelectedIndexChanged += new System.EventHandler(this.DdlRakeType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(198, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 198;
            this.label2.Text = "Year";
            // 
            // DDLYear
            // 
            this.DDLYear.Enabled = false;
            this.DDLYear.FormattingEnabled = true;
            this.DDLYear.Items.AddRange(new object[] {
            "-Select-",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.DDLYear.Location = new System.Drawing.Point(237, 33);
            this.DDLYear.Name = "DDLYear";
            this.DDLYear.Size = new System.Drawing.Size(75, 21);
            this.DDLYear.TabIndex = 2;
            this.DDLYear.SelectedIndexChanged += new System.EventHandler(this.DDLYear_SelectedIndexChanged);
            // 
            // DDLMonth
            // 
            this.DDLMonth.FormattingEnabled = true;
            this.DDLMonth.Location = new System.Drawing.Point(74, 33);
            this.DDLMonth.Name = "DDLMonth";
            this.DDLMonth.Size = new System.Drawing.Size(97, 21);
            this.DDLMonth.TabIndex = 1;
            this.DDLMonth.SelectedIndexChanged += new System.EventHandler(this.DDLMonth_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 182;
            this.label6.Text = "Month";
            // 
            // BtnGetBills
            // 
            this.BtnGetBills.Location = new System.Drawing.Point(1084, 32);
            this.BtnGetBills.Name = "BtnGetBills";
            this.BtnGetBills.Size = new System.Drawing.Size(75, 23);
            this.BtnGetBills.TabIndex = 6;
            this.BtnGetBills.Text = "Get Bills";
            this.BtnGetBills.UseVisualStyleBackColor = true;
            this.BtnGetBills.Click += new System.EventHandler(this.BtnGetBills_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(768, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 166;
            this.label1.Text = "Submit Date";
            // 
            // DtSubmitDate
            // 
            this.DtSubmitDate.Location = new System.Drawing.Point(860, 31);
            this.DtSubmitDate.Name = "DtSubmitDate";
            this.DtSubmitDate.Size = new System.Drawing.Size(115, 20);
            this.DtSubmitDate.TabIndex = 5;
            // 
            // CtrlBtnPrintBill
            // 
            this.CtrlBtnPrintBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CtrlBtnPrintBill.BackgroundImage = global::Rake.Properties.Resources.PrintIcon;
            this.CtrlBtnPrintBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CtrlBtnPrintBill.FlatAppearance.BorderSize = 0;
            this.CtrlBtnPrintBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CtrlBtnPrintBill.Location = new System.Drawing.Point(811, 433);
            this.CtrlBtnPrintBill.Name = "CtrlBtnPrintBill";
            this.CtrlBtnPrintBill.Size = new System.Drawing.Size(75, 48);
            this.CtrlBtnPrintBill.TabIndex = 8;
            this.CtrlBtnPrintBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CtrlBtnPrintBill.UseVisualStyleBackColor = true;
            this.CtrlBtnPrintBill.Click += new System.EventHandler(this.CtrlBtnPrintBill_Click);
            // 
            // TxtHandlingBill
            // 
            this.TxtHandlingBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHandlingBill.Location = new System.Drawing.Point(280, 14);
            this.TxtHandlingBill.Name = "TxtHandlingBill";
            this.TxtHandlingBill.Size = new System.Drawing.Size(96, 24);
            this.TxtHandlingBill.TabIndex = 189;
            this.TxtHandlingBill.TextChanged += new System.EventHandler(this.TxtHandlingBill_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(189, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 18);
            this.label15.TabIndex = 190;
            this.label15.Text = "Handling Bill";
            // 
            // TxtFrightBill
            // 
            this.TxtFrightBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFrightBill.Location = new System.Drawing.Point(82, 14);
            this.TxtFrightBill.Name = "TxtFrightBill";
            this.TxtFrightBill.Size = new System.Drawing.Size(89, 24);
            this.TxtFrightBill.TabIndex = 187;
            this.TxtFrightBill.TextChanged += new System.EventHandler(this.TxtFrightBill_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 18);
            this.label12.TabIndex = 188;
            this.label12.Text = "Fright Bill";
            // 
            // TxtShipmentNo
            // 
            this.TxtShipmentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtShipmentNo.Location = new System.Drawing.Point(1305, 150);
            this.TxtShipmentNo.Name = "TxtShipmentNo";
            this.TxtShipmentNo.Size = new System.Drawing.Size(120, 24);
            this.TxtShipmentNo.TabIndex = 191;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1209, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 18);
            this.label5.TabIndex = 192;
            this.label5.Text = "Shipment No";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox2.Controls.Add(this.TxtHandlingBill);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.TxtFrightBill);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(12, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 54);
            this.groupBox2.TabIndex = 193;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Whitefield";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox3.Controls.Add(this.TxtHosurHandling);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.TxtHosurFright);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(428, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 54);
            this.groupBox3.TabIndex = 194;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hosur";
            // 
            // TxtHosurHandling
            // 
            this.TxtHosurHandling.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHosurHandling.Location = new System.Drawing.Point(269, 14);
            this.TxtHosurHandling.Name = "TxtHosurHandling";
            this.TxtHosurHandling.Size = new System.Drawing.Size(85, 24);
            this.TxtHosurHandling.TabIndex = 189;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 18);
            this.label7.TabIndex = 188;
            this.label7.Text = "Fright Bill";
            // 
            // TxtHosurFright
            // 
            this.TxtHosurFright.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHosurFright.Location = new System.Drawing.Point(82, 14);
            this.TxtHosurFright.Name = "TxtHosurFright";
            this.TxtHosurFright.Size = new System.Drawing.Size(82, 24);
            this.TxtHosurFright.TabIndex = 187;
            this.TxtHosurFright.TextChanged += new System.EventHandler(this.TxtHosurFright_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(178, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 18);
            this.label8.TabIndex = 190;
            this.label8.Text = "Handling Bill";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox4.Controls.Add(this.TxtMaddurHandling);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.TxtMaddurFright);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(825, 136);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(367, 54);
            this.groupBox4.TabIndex = 194;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Maddur";
            // 
            // TxtMaddurHandling
            // 
            this.TxtMaddurHandling.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMaddurHandling.Location = new System.Drawing.Point(269, 14);
            this.TxtMaddurHandling.Name = "TxtMaddurHandling";
            this.TxtMaddurHandling.Size = new System.Drawing.Size(77, 24);
            this.TxtMaddurHandling.TabIndex = 189;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 18);
            this.label9.TabIndex = 188;
            this.label9.Text = "Fright Bill";
            // 
            // TxtMaddurFright
            // 
            this.TxtMaddurFright.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMaddurFright.Location = new System.Drawing.Point(82, 14);
            this.TxtMaddurFright.Name = "TxtMaddurFright";
            this.TxtMaddurFright.Size = new System.Drawing.Size(79, 24);
            this.TxtMaddurFright.TabIndex = 187;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(178, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 18);
            this.label10.TabIndex = 190;
            this.label10.Text = "Handling Bill";
            // 
            // GenerateBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 490);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.TxtShipmentNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CtrlBtnPrintBill);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GvRakeBill);
            this.Name = "GenerateBills";
            this.Text = "Generate Rake Bills";
            ((System.ComponentModel.ISupportInitialize)(this.GvRakeBill)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GvRakeBill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox DDLMonth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnGetBills;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtSubmitDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DDLYear;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox DdlRakeType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox DdlRakeNo;
        private System.Windows.Forms.Button CtrlBtnPrintBill;
        private System.Windows.Forms.TextBox TxtHandlingBill;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TxtFrightBill;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtShipmentNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtHosurHandling;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtHosurFright;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TxtMaddurHandling;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtMaddurFright;
        private System.Windows.Forms.Label label10;
    }
}