namespace Rake
{
    partial class GCData
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GvShipment = new System.Windows.Forms.DataGridView();
            this.TxtShipmentSearch = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.TxtInvoiceSearch = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.DownloadFile = new System.Windows.Forms.Button();
            this.BtnUpload = new System.Windows.Forms.Button();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.TxtUploadfile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvShipment)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.GvShipment);
            this.groupBox1.Controls.Add(this.TxtShipmentSearch);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.TxtInvoiceSearch);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Location = new System.Drawing.Point(18, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(837, 311);
            this.groupBox1.TabIndex = 272;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // GvShipment
            // 
            this.GvShipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.GvShipment.Size = new System.Drawing.Size(801, 237);
            this.GvShipment.TabIndex = 21;
            // 
            // TxtShipmentSearch
            // 
            this.TxtShipmentSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtShipmentSearch.Location = new System.Drawing.Point(329, 19);
            this.TxtShipmentSearch.Name = "TxtShipmentSearch";
            this.TxtShipmentSearch.Size = new System.Drawing.Size(100, 24);
            this.TxtShipmentSearch.TabIndex = 20;
            this.TxtShipmentSearch.TextChanged += new System.EventHandler(this.TxtShipmentSearch_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(232, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 18);
            this.label21.TabIndex = 268;
            this.label21.Text = "Shipment No";
            // 
            // TxtInvoiceSearch
            // 
            this.TxtInvoiceSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInvoiceSearch.Location = new System.Drawing.Point(543, 19);
            this.TxtInvoiceSearch.Name = "TxtInvoiceSearch";
            this.TxtInvoiceSearch.Size = new System.Drawing.Size(100, 24);
            this.TxtInvoiceSearch.TabIndex = 21;
            this.TxtInvoiceSearch.TextChanged += new System.EventHandler(this.TxtInvoiceSearch_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(462, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 18);
            this.label18.TabIndex = 269;
            this.label18.Text = "Invoice No";
            // 
            // DownloadFile
            // 
            this.DownloadFile.Location = new System.Drawing.Point(169, 75);
            this.DownloadFile.Name = "DownloadFile";
            this.DownloadFile.Size = new System.Drawing.Size(75, 23);
            this.DownloadFile.TabIndex = 268;
            this.DownloadFile.Text = "Download";
            this.DownloadFile.UseVisualStyleBackColor = true;
            this.DownloadFile.Click += new System.EventHandler(this.DownloadFile_Click);
            // 
            // BtnUpload
            // 
            this.BtnUpload.Location = new System.Drawing.Point(626, 75);
            this.BtnUpload.Name = "BtnUpload";
            this.BtnUpload.Size = new System.Drawing.Size(75, 23);
            this.BtnUpload.TabIndex = 271;
            this.BtnUpload.Text = "Upload";
            this.BtnUpload.UseVisualStyleBackColor = true;
            this.BtnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(535, 75);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtnBrowse.TabIndex = 270;
            this.BtnBrowse.Text = "Browse";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // TxtUploadfile
            // 
            this.TxtUploadfile.Enabled = false;
            this.TxtUploadfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUploadfile.Location = new System.Drawing.Point(284, 75);
            this.TxtUploadfile.Name = "TxtUploadfile";
            this.TxtUploadfile.Size = new System.Drawing.Size(253, 24);
            this.TxtUploadfile.TabIndex = 269;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Tan;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(12, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 25);
            this.label4.TabIndex = 273;
            this.label4.Text = "GC Data Upload";
            // 
            // GCData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 444);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DownloadFile);
            this.Controls.Add(this.BtnUpload);
            this.Controls.Add(this.BtnBrowse);
            this.Controls.Add(this.TxtUploadfile);
            this.Name = "GCData";
            this.Text = "GCData";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvShipment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView GvShipment;
        private System.Windows.Forms.TextBox TxtShipmentSearch;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox TxtInvoiceSearch;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button DownloadFile;
        private System.Windows.Forms.Button BtnUpload;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.TextBox TxtUploadfile;
        private System.Windows.Forms.Label label4;

    }
}