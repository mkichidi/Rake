namespace Rake
{
    partial class OSTVehicles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSTVehicles));
            this.DdlTransport = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GvGot = new System.Windows.Forms.DataGridView();
            this.GvAdd = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.Button();
            this.Sub = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnExit = new System.Windows.Forms.ToolStripButton();
            this.TxtVehicleSearchGot = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TxtVehicleSearchAll = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtVehicleSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GvTransport = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.GvGot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvAdd)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvTransport)).BeginInit();
            this.SuspendLayout();
            // 
            // DdlTransport
            // 
            this.DdlTransport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlTransport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlTransport.FormattingEnabled = true;
            this.DdlTransport.Location = new System.Drawing.Point(232, 101);
            this.DdlTransport.Name = "DdlTransport";
            this.DdlTransport.Size = new System.Drawing.Size(254, 21);
            this.DdlTransport.TabIndex = 1;
            this.DdlTransport.SelectedIndexChanged += new System.EventHandler(this.DdlProduct_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(110, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 18);
            this.label5.TabIndex = 161;
            this.label5.Text = "Transport Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Tan;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(15, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 25);
            this.label4.TabIndex = 162;
            this.label4.Text = "OST Vehicles";
            // 
            // GvGot
            // 
            this.GvGot.AllowUserToAddRows = false;
            this.GvGot.AllowUserToDeleteRows = false;
            this.GvGot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvGot.Location = new System.Drawing.Point(54, 171);
            this.GvGot.Name = "GvGot";
            this.GvGot.ReadOnly = true;
            this.GvGot.Size = new System.Drawing.Size(202, 150);
            this.GvGot.TabIndex = 4;
            // 
            // GvAdd
            // 
            this.GvAdd.AllowUserToAddRows = false;
            this.GvAdd.AllowUserToDeleteRows = false;
            this.GvAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvAdd.Location = new System.Drawing.Point(399, 171);
            this.GvAdd.Name = "GvAdd";
            this.GvAdd.ReadOnly = true;
            this.GvAdd.Size = new System.Drawing.Size(189, 150);
            this.GvAdd.TabIndex = 6;
            // 
            // add
            // 
            this.add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.Location = new System.Drawing.Point(306, 186);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(29, 23);
            this.add.TabIndex = 4;
            this.add.Text = "<";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // Sub
            // 
            this.Sub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sub.Location = new System.Drawing.Point(306, 268);
            this.Sub.Name = "Sub";
            this.Sub.Size = new System.Drawing.Size(29, 23);
            this.Sub.TabIndex = 5;
            this.Sub.Text = ">";
            this.Sub.UseVisualStyleBackColor = true;
            this.Sub.Click += new System.EventHandler(this.Sub_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSave,
            this.tsBtnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(638, 39);
            this.toolStrip1.TabIndex = 167;
            this.toolStrip1.Text = "Transporter";
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
            // TxtVehicleSearchGot
            // 
            this.TxtVehicleSearchGot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtVehicleSearchGot.Location = new System.Drawing.Point(102, 141);
            this.TxtVehicleSearchGot.Name = "TxtVehicleSearchGot";
            this.TxtVehicleSearchGot.Size = new System.Drawing.Size(164, 24);
            this.TxtVehicleSearchGot.TabIndex = 2;
            this.TxtVehicleSearchGot.TextChanged += new System.EventHandler(this.TxtVehicleSearchGot_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(20, 144);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 18);
            this.label16.TabIndex = 169;
            this.label16.Text = "Vehicle No";
            // 
            // TxtVehicleSearchAll
            // 
            this.TxtVehicleSearchAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtVehicleSearchAll.Location = new System.Drawing.Point(441, 141);
            this.TxtVehicleSearchAll.Name = "TxtVehicleSearchAll";
            this.TxtVehicleSearchAll.Size = new System.Drawing.Size(164, 24);
            this.TxtVehicleSearchAll.TabIndex = 3;
            this.TxtVehicleSearchAll.TextChanged += new System.EventHandler(this.TxtVehicleSearchAll_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(359, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 171;
            this.label1.Text = "Vehicle No";
            // 
            // TxtVehicleSearch
            // 
            this.TxtVehicleSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtVehicleSearch.Location = new System.Drawing.Point(147, 404);
            this.TxtVehicleSearch.Name = "TxtVehicleSearch";
            this.TxtVehicleSearch.Size = new System.Drawing.Size(164, 24);
            this.TxtVehicleSearch.TabIndex = 7;
            this.TxtVehicleSearch.TextChanged += new System.EventHandler(this.TxtVehicleSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 173;
            this.label2.Text = "Vehicle No";
            // 
            // GvTransport
            // 
            this.GvTransport.AllowUserToAddRows = false;
            this.GvTransport.AllowUserToDeleteRows = false;
            this.GvTransport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GvTransport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvTransport.Location = new System.Drawing.Point(342, 357);
            this.GvTransport.Name = "GvTransport";
            this.GvTransport.ReadOnly = true;
            this.GvTransport.Size = new System.Drawing.Size(246, 121);
            this.GvTransport.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox1.Location = new System.Drawing.Point(23, 345);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 143);
            this.groupBox1.TabIndex = 175;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // OSTVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 490);
            this.Controls.Add(this.GvTransport);
            this.Controls.Add(this.TxtVehicleSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtVehicleSearchAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtVehicleSearchGot);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Sub);
            this.Controls.Add(this.add);
            this.Controls.Add(this.GvAdd);
            this.Controls.Add(this.GvGot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DdlTransport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Name = "OSTVehicles";
            this.Text = "OST Vehicles";
            ((System.ComponentModel.ISupportInitialize)(this.GvGot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvAdd)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvTransport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox DdlTransport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView GvGot;
        private System.Windows.Forms.DataGridView GvAdd;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button Sub;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.ToolStripButton tsBtnExit;
        private System.Windows.Forms.TextBox TxtVehicleSearchGot;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TxtVehicleSearchAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtVehicleSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView GvTransport;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}