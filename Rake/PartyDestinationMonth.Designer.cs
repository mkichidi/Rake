namespace Rake
{
    partial class PartyDestinationMonth
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GvRakeBill = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DdlFrom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CtrlBtnPrintBill = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.DtPaidDateTo = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.DtPaidDateFrom = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.GvRakeBill)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GvRakeBill
            // 
            this.GvRakeBill.AllowUserToAddRows = false;
            this.GvRakeBill.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvRakeBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GvRakeBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvRakeBill.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GvRakeBill.Location = new System.Drawing.Point(30, 130);
            this.GvRakeBill.Name = "GvRakeBill";
            this.GvRakeBill.ReadOnly = true;
            this.GvRakeBill.Size = new System.Drawing.Size(658, 216);
            this.GvRakeBill.TabIndex = 204;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Tan;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(51, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 25);
            this.label4.TabIndex = 205;
            this.label4.Text = "Party Destination Month";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.DtPaidDateTo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.DtPaidDateFrom);
            this.groupBox1.Controls.Add(this.DdlFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(30, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 71);
            this.groupBox1.TabIndex = 207;
            this.groupBox1.TabStop = false;
            // 
            // DdlFrom
            // 
            this.DdlFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlFrom.FormattingEnabled = true;
            this.DdlFrom.Location = new System.Drawing.Point(65, 30);
            this.DdlFrom.Name = "DdlFrom";
            this.DdlFrom.Size = new System.Drawing.Size(127, 21);
            this.DdlFrom.TabIndex = 275;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 276;
            this.label2.Text = "From";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(553, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Get Details";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CtrlBtnPrintBill
            // 
            this.CtrlBtnPrintBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CtrlBtnPrintBill.BackgroundImage = global::Rake.Properties.Resources.PrintIcon;
            this.CtrlBtnPrintBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CtrlBtnPrintBill.FlatAppearance.BorderSize = 0;
            this.CtrlBtnPrintBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CtrlBtnPrintBill.Location = new System.Drawing.Point(507, 376);
            this.CtrlBtnPrintBill.Name = "CtrlBtnPrintBill";
            this.CtrlBtnPrintBill.Size = new System.Drawing.Size(75, 48);
            this.CtrlBtnPrintBill.TabIndex = 206;
            this.CtrlBtnPrintBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CtrlBtnPrintBill.UseVisualStyleBackColor = true;
            this.CtrlBtnPrintBill.Click += new System.EventHandler(this.CtrlBtnPrintBill_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(375, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 18);
            this.label10.TabIndex = 312;
            this.label10.Text = "To";
            // 
            // DtPaidDateTo
            // 
            this.DtPaidDateTo.Location = new System.Drawing.Point(407, 31);
            this.DtPaidDateTo.Name = "DtPaidDateTo";
            this.DtPaidDateTo.Size = new System.Drawing.Size(115, 20);
            this.DtPaidDateTo.TabIndex = 311;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(209, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 18);
            this.label11.TabIndex = 310;
            this.label11.Text = "Date";
            // 
            // DtPaidDateFrom
            // 
            this.DtPaidDateFrom.Location = new System.Drawing.Point(254, 31);
            this.DtPaidDateFrom.Name = "DtPaidDateFrom";
            this.DtPaidDateFrom.Size = new System.Drawing.Size(115, 20);
            this.DtPaidDateFrom.TabIndex = 309;
            // 
            // PartyDestinationMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 436);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CtrlBtnPrintBill);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GvRakeBill);
            this.Name = "PartyDestinationMonth";
            this.Text = "Party Destination Month";
            ((System.ComponentModel.ISupportInitialize)(this.GvRakeBill)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GvRakeBill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CtrlBtnPrintBill;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox DdlFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker DtPaidDateTo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker DtPaidDateFrom;
    }
}