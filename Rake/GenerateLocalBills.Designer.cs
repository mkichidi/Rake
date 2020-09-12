namespace Rake
{
    partial class GenerateLocalBills
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
            this.TxtLocalBill = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DDLYear = new System.Windows.Forms.ComboBox();
            this.DDLMonth = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnGetBills = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DtSubmitDate = new System.Windows.Forms.DateTimePicker();
            this.CtrlBtnPrintBill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GvRakeBill)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GvRakeBill
            // 
            this.GvRakeBill.AllowUserToAddRows = false;
            this.GvRakeBill.AllowUserToDeleteRows = false;
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
            this.GvRakeBill.Location = new System.Drawing.Point(12, 151);
            this.GvRakeBill.Name = "GvRakeBill";
            this.GvRakeBill.ReadOnly = true;
            this.GvRakeBill.Size = new System.Drawing.Size(1131, 216);
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
            this.label4.Size = new System.Drawing.Size(213, 25);
            this.label4.TabIndex = 162;
            this.label4.Text = "Generate Local Bill";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.TxtLocalBill);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DDLYear);
            this.groupBox1.Controls.Add(this.DDLMonth);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.BtnGetBills);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DtSubmitDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1131, 71);
            this.groupBox1.TabIndex = 186;
            this.groupBox1.TabStop = false;
            // 
            // TxtLocalBill
            // 
            this.TxtLocalBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLocalBill.Location = new System.Drawing.Point(770, 27);
            this.TxtLocalBill.Name = "TxtLocalBill";
            this.TxtLocalBill.Size = new System.Drawing.Size(120, 24);
            this.TxtLocalBill.TabIndex = 199;
            this.TxtLocalBill.TextChanged += new System.EventHandler(this.TxtLocalBill_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(697, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 18);
            this.label12.TabIndex = 200;
            this.label12.Text = "Local Bill";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 198;
            this.label2.Text = "Year";
            // 
            // DDLYear
            // 
            this.DDLYear.FormattingEnabled = true;
            this.DDLYear.Items.AddRange(new object[] {
            "-Select-",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.DDLYear.Location = new System.Drawing.Point(343, 30);
            this.DDLYear.Name = "DDLYear";
            this.DDLYear.Size = new System.Drawing.Size(75, 21);
            this.DDLYear.TabIndex = 2;
            // 
            // DDLMonth
            // 
            this.DDLMonth.FormattingEnabled = true;
            this.DDLMonth.Location = new System.Drawing.Point(165, 30);
            this.DDLMonth.Name = "DDLMonth";
            this.DDLMonth.Size = new System.Drawing.Size(97, 21);
            this.DDLMonth.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(113, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 182;
            this.label6.Text = "Month";
            // 
            // BtnGetBills
            // 
            this.BtnGetBills.Location = new System.Drawing.Point(930, 27);
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
            this.label1.Location = new System.Drawing.Point(461, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 166;
            this.label1.Text = "Submit Date";
            // 
            // DtSubmitDate
            // 
            this.DtSubmitDate.Location = new System.Drawing.Point(553, 29);
            this.DtSubmitDate.Name = "DtSubmitDate";
            this.DtSubmitDate.Size = new System.Drawing.Size(115, 20);
            this.DtSubmitDate.TabIndex = 5;
            // 
            // CtrlBtnPrintBill
            // 
            this.CtrlBtnPrintBill.BackgroundImage = global::Rake.Properties.Resources.PrintIcon;
            this.CtrlBtnPrintBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CtrlBtnPrintBill.FlatAppearance.BorderSize = 0;
            this.CtrlBtnPrintBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CtrlBtnPrintBill.Location = new System.Drawing.Point(1023, 383);
            this.CtrlBtnPrintBill.Name = "CtrlBtnPrintBill";
            this.CtrlBtnPrintBill.Size = new System.Drawing.Size(75, 48);
            this.CtrlBtnPrintBill.TabIndex = 8;
            this.CtrlBtnPrintBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CtrlBtnPrintBill.UseVisualStyleBackColor = true;
            this.CtrlBtnPrintBill.Click += new System.EventHandler(this.CtrlBtnPrintBill_Click);
            // 
            // GenerateLocalBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 455);
            this.Controls.Add(this.CtrlBtnPrintBill);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GvRakeBill);
            this.Name = "GenerateLocalBills";
            this.Text = "Generate Local Bills";
            ((System.ComponentModel.ISupportInitialize)(this.GvRakeBill)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button CtrlBtnPrintBill;
        private System.Windows.Forms.TextBox TxtLocalBill;
        private System.Windows.Forms.Label label12;
    }
}