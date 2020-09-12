namespace Rake.Reports.Reports
{
    partial class TMTReport
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
            this.GvDetails = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnExcel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.BtnExcel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.DdlRakeNo);
            this.groupBox1.Controls.Add(this.DdlRakeType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DDLYear);
            this.groupBox1.Controls.Add(this.DDLMonth);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.BtnGetBills);
            this.groupBox1.Location = new System.Drawing.Point(21, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1131, 71);
            this.groupBox1.TabIndex = 187;
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
            this.BtnGetBills.Location = new System.Drawing.Point(792, 28);
            this.BtnGetBills.Name = "BtnGetBills";
            this.BtnGetBills.Size = new System.Drawing.Size(75, 23);
            this.BtnGetBills.TabIndex = 6;
            this.BtnGetBills.Text = "Get Bills";
            this.BtnGetBills.UseVisualStyleBackColor = true;
            this.BtnGetBills.Click += new System.EventHandler(this.BtnGetBills_Click);
            // 
            // GvDetails
            // 
            this.GvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvDetails.Location = new System.Drawing.Point(21, 167);
            this.GvDetails.Name = "GvDetails";
            this.GvDetails.Size = new System.Drawing.Size(1139, 348);
            this.GvDetails.TabIndex = 188;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Tan;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(41, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 25);
            this.label4.TabIndex = 302;
            this.label4.Text = "TMT Report";
            // 
            // BtnExcel
            // 
            this.BtnExcel.Location = new System.Drawing.Point(924, 29);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnExcel.TabIndex = 290;
            this.BtnExcel.Text = "Excel";
            this.BtnExcel.UseVisualStyleBackColor = true;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // TMTReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 527);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GvDetails);
            this.Controls.Add(this.groupBox1);
            this.Name = "TMTReport";
            this.Text = "TMTReport";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.DataGridView GvDetails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnExcel;
    }
}