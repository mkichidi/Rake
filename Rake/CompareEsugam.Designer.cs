namespace Rake
{
    partial class CompareEsugam
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DdlRakeType = new System.Windows.Forms.ComboBox();
            this.DDLYear = new System.Windows.Forms.ComboBox();
            this.DDLMonth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CtrlBtnPrintBill = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.GvRakeBill = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.DdlRakeNo = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvRakeBill)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DdlRakeNo);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DdlRakeType);
            this.groupBox1.Controls.Add(this.DDLYear);
            this.groupBox1.Controls.Add(this.DDLMonth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(35, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 71);
            this.groupBox1.TabIndex = 211;
            this.groupBox1.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(353, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 18);
            this.label16.TabIndex = 289;
            this.label16.Text = "Rake Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(209, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 198;
            this.label1.Text = "Year";
            // 
            // DdlRakeType
            // 
            this.DdlRakeType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlRakeType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlRakeType.FormattingEnabled = true;
            this.DdlRakeType.Location = new System.Drawing.Point(434, 28);
            this.DdlRakeType.Name = "DdlRakeType";
            this.DdlRakeType.Size = new System.Drawing.Size(121, 21);
            this.DdlRakeType.TabIndex = 288;
            this.DdlRakeType.SelectedIndexChanged += new System.EventHandler(this.DdlRakeType_SelectedIndexChanged);
            // 
            // DDLYear
            // 
            this.DDLYear.FormattingEnabled = true;
            this.DDLYear.Items.AddRange(new object[] {
            "-All-",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.DDLYear.Location = new System.Drawing.Point(248, 30);
            this.DDLYear.Name = "DDLYear";
            this.DDLYear.Size = new System.Drawing.Size(75, 21);
            this.DDLYear.TabIndex = 2;
            // 
            // DDLMonth
            // 
            this.DDLMonth.FormattingEnabled = true;
            this.DDLMonth.Location = new System.Drawing.Point(79, 30);
            this.DDLMonth.Name = "DDLMonth";
            this.DDLMonth.Size = new System.Drawing.Size(97, 21);
            this.DDLMonth.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 182;
            this.label3.Text = "Month";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(739, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Compare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CtrlBtnPrintBill
            // 
            this.CtrlBtnPrintBill.BackgroundImage = global::Rake.Properties.Resources.PrintIcon;
            this.CtrlBtnPrintBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CtrlBtnPrintBill.FlatAppearance.BorderSize = 0;
            this.CtrlBtnPrintBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CtrlBtnPrintBill.Location = new System.Drawing.Point(643, 376);
            this.CtrlBtnPrintBill.Name = "CtrlBtnPrintBill";
            this.CtrlBtnPrintBill.Size = new System.Drawing.Size(75, 48);
            this.CtrlBtnPrintBill.TabIndex = 210;
            this.CtrlBtnPrintBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CtrlBtnPrintBill.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Tan;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(46, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 25);
            this.label4.TabIndex = 209;
            this.label4.Text = "Compare to E-Sugam";
            // 
            // GvRakeBill
            // 
            this.GvRakeBill.AllowUserToAddRows = false;
            this.GvRakeBill.AllowUserToDeleteRows = false;
            this.GvRakeBill.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvRakeBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.GvRakeBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvRakeBill.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GvRakeBill.Location = new System.Drawing.Point(25, 141);
            this.GvRakeBill.Name = "GvRakeBill";
            this.GvRakeBill.ReadOnly = true;
            this.GvRakeBill.Size = new System.Drawing.Size(705, 216);
            this.GvRakeBill.TabIndex = 208;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(579, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 291;
            this.label2.Text = "Rake No";
            // 
            // DdlRakeNo
            // 
            this.DdlRakeNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlRakeNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlRakeNo.Enabled = false;
            this.DdlRakeNo.FormattingEnabled = true;
            this.DdlRakeNo.Location = new System.Drawing.Point(648, 28);
            this.DdlRakeNo.Name = "DdlRakeNo";
            this.DdlRakeNo.Size = new System.Drawing.Size(63, 21);
            this.DdlRakeNo.TabIndex = 290;
            // 
            // CompareEsugam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 435);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CtrlBtnPrintBill);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GvRakeBill);
            this.Name = "CompareEsugam";
            this.Text = "Compare E-sugam";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvRakeBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DdlRakeType;
        private System.Windows.Forms.ComboBox DDLYear;
        private System.Windows.Forms.ComboBox DDLMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CtrlBtnPrintBill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView GvRakeBill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DdlRakeNo;
    }
}