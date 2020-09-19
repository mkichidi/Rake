namespace Rake
{
    partial class GenerateGC
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
            this.TxtGcNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkExtraCopy = new System.Windows.Forms.CheckBox();
            this.ChkOfficeCopy = new System.Windows.Forms.CheckBox();
            this.ChkCustomerCopy = new System.Windows.Forms.CheckBox();
            this.ChkDriverCopy = new System.Windows.Forms.CheckBox();
            this.DdlCustomer = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.DdlRakeNo = new System.Windows.Forms.ComboBox();
            this.DdlRakeType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DDLYear = new System.Windows.Forms.ComboBox();
            this.DDLMonth = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnGetBills = new System.Windows.Forms.Button();
            this.CtrlBtnPrintBill = new System.Windows.Forms.Button();
            this.GvRakeBill = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DdlCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvRakeBill)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtGcNo
            // 
            this.TxtGcNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtGcNo.Location = new System.Drawing.Point(831, 28);
            this.TxtGcNo.Name = "TxtGcNo";
            this.TxtGcNo.Size = new System.Drawing.Size(120, 24);
            this.TxtGcNo.TabIndex = 190;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(771, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 18);
            this.label12.TabIndex = 191;
            this.label12.Text = "GC No";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.ChkExtraCopy);
            this.groupBox1.Controls.Add(this.ChkOfficeCopy);
            this.groupBox1.Controls.Add(this.ChkCustomerCopy);
            this.groupBox1.Controls.Add(this.ChkDriverCopy);
            this.groupBox1.Controls.Add(this.DdlCustomer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtGcNo);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.DdlRakeNo);
            this.groupBox1.Controls.Add(this.DdlRakeType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DDLYear);
            this.groupBox1.Controls.Add(this.DDLMonth);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.BtnGetBills);
            this.groupBox1.Location = new System.Drawing.Point(9, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1099, 109);
            this.groupBox1.TabIndex = 189;
            this.groupBox1.TabStop = false;
            // 
            // ChkExtraCopy
            // 
            this.ChkExtraCopy.AutoSize = true;
            this.ChkExtraCopy.Location = new System.Drawing.Point(795, 75);
            this.ChkExtraCopy.Name = "ChkExtraCopy";
            this.ChkExtraCopy.Size = new System.Drawing.Size(77, 17);
            this.ChkExtraCopy.TabIndex = 295;
            this.ChkExtraCopy.Text = "Extra Copy";
            this.ChkExtraCopy.UseVisualStyleBackColor = true;
            this.ChkExtraCopy.Visible = false;
            // 
            // ChkOfficeCopy
            // 
            this.ChkOfficeCopy.AutoSize = true;
            this.ChkOfficeCopy.Location = new System.Drawing.Point(695, 75);
            this.ChkOfficeCopy.Name = "ChkOfficeCopy";
            this.ChkOfficeCopy.Size = new System.Drawing.Size(81, 17);
            this.ChkOfficeCopy.TabIndex = 294;
            this.ChkOfficeCopy.Text = "Office Copy";
            this.ChkOfficeCopy.UseVisualStyleBackColor = true;
            this.ChkOfficeCopy.Visible = false;
            // 
            // ChkCustomerCopy
            // 
            this.ChkCustomerCopy.AutoSize = true;
            this.ChkCustomerCopy.Location = new System.Drawing.Point(579, 74);
            this.ChkCustomerCopy.Name = "ChkCustomerCopy";
            this.ChkCustomerCopy.Size = new System.Drawing.Size(97, 17);
            this.ChkCustomerCopy.TabIndex = 293;
            this.ChkCustomerCopy.Text = "Customer Copy";
            this.ChkCustomerCopy.UseVisualStyleBackColor = true;
            this.ChkCustomerCopy.Visible = false;
            // 
            // ChkDriverCopy
            // 
            this.ChkDriverCopy.AutoSize = true;
            this.ChkDriverCopy.Checked = true;
            this.ChkDriverCopy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkDriverCopy.Location = new System.Drawing.Point(473, 73);
            this.ChkDriverCopy.Name = "ChkDriverCopy";
            this.ChkDriverCopy.Size = new System.Drawing.Size(81, 17);
            this.ChkDriverCopy.TabIndex = 292;
            this.ChkDriverCopy.Text = "Driver Copy";
            this.ChkDriverCopy.UseVisualStyleBackColor = true;
            this.ChkDriverCopy.Visible = false;
            // 
            // DdlCustomer
            // 
            this.DdlCustomer.EditValue = "";
            this.DdlCustomer.Location = new System.Drawing.Point(155, 73);
            this.DdlCustomer.Name = "DdlCustomer";
            this.DdlCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DdlCustomer.Size = new System.Drawing.Size(242, 20);
            this.DdlCustomer.TabIndex = 291;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 290;
            this.label1.Text = "Customer";
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
            this.BtnGetBills.Location = new System.Drawing.Point(987, 28);
            this.BtnGetBills.Name = "BtnGetBills";
            this.BtnGetBills.Size = new System.Drawing.Size(75, 23);
            this.BtnGetBills.TabIndex = 6;
            this.BtnGetBills.Text = "Get Bills";
            this.BtnGetBills.UseVisualStyleBackColor = true;
            this.BtnGetBills.Click += new System.EventHandler(this.BtnGetBills_Click);
            // 
            // CtrlBtnPrintBill
            // 
            this.CtrlBtnPrintBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CtrlBtnPrintBill.BackgroundImage = global::Rake.Properties.Resources.PrintIcon;
            this.CtrlBtnPrintBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CtrlBtnPrintBill.FlatAppearance.BorderSize = 0;
            this.CtrlBtnPrintBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CtrlBtnPrintBill.Location = new System.Drawing.Point(845, 382);
            this.CtrlBtnPrintBill.Name = "CtrlBtnPrintBill";
            this.CtrlBtnPrintBill.Size = new System.Drawing.Size(75, 48);
            this.CtrlBtnPrintBill.TabIndex = 191;
            this.CtrlBtnPrintBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CtrlBtnPrintBill.UseVisualStyleBackColor = true;
            this.CtrlBtnPrintBill.Click += new System.EventHandler(this.CtrlBtnPrintBill_Click);
            // 
            // GvRakeBill
            // 
            this.GvRakeBill.AllowUserToAddRows = false;
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
            this.GvRakeBill.Location = new System.Drawing.Point(12, 166);
            this.GvRakeBill.Name = "GvRakeBill";
            this.GvRakeBill.ReadOnly = true;
            this.GvRakeBill.Size = new System.Drawing.Size(991, 195);
            this.GvRakeBill.TabIndex = 190;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Tan;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 25);
            this.label4.TabIndex = 192;
            this.label4.Text = "Generate GC";
            // 
            // GenerateGC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 442);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CtrlBtnPrintBill);
            this.Controls.Add(this.GvRakeBill);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenerateGC";
            this.Text = "GenerateGC";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DdlCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvRakeBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtGcNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox DdlRakeNo;
        private System.Windows.Forms.ComboBox DdlRakeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DDLYear;
        private System.Windows.Forms.ComboBox DDLMonth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnGetBills;
        private System.Windows.Forms.Button CtrlBtnPrintBill;
        private System.Windows.Forms.DataGridView GvRakeBill;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.CheckedComboBoxEdit DdlCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ChkDriverCopy;
        private System.Windows.Forms.CheckBox ChkCustomerCopy;
        private System.Windows.Forms.CheckBox ChkOfficeCopy;
        private System.Windows.Forms.CheckBox ChkExtraCopy;
    }
}