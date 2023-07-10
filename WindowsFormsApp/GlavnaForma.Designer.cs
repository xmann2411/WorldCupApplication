namespace WindowsFormsApp
{
    partial class GlavnaForma
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
            this.comboBoxTim = new System.Windows.Forms.ComboBox();
            this.lblOdaber = new System.Windows.Forms.Label();
            this.lblRangiraj = new System.Windows.Forms.Label();
            this.btnGolovi = new System.Windows.Forms.Button();
            this.btnKartoni = new System.Windows.Forms.Button();
            this.btnUtakmice = new System.Windows.Forms.Button();
            this.lblOmiljeni = new System.Windows.Forms.Label();
            this.lblIgraci = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPostavke = new System.Windows.Forms.Button();
            this.panelIgraci = new System.Windows.Forms.FlowLayoutPanel();
            this.panelOmiljeni = new System.Windows.Forms.FlowLayoutPanel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxTim
            // 
            this.comboBoxTim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTim.FormattingEnabled = true;
            this.comboBoxTim.Location = new System.Drawing.Point(478, 115);
            this.comboBoxTim.Name = "comboBoxTim";
            this.comboBoxTim.Size = new System.Drawing.Size(151, 21);
            this.comboBoxTim.TabIndex = 0;
            this.comboBoxTim.SelectedIndexChanged += new System.EventHandler(this.comboBoxTim_SelectedIndexChanged);
            // 
            // lblOdaber
            // 
            this.lblOdaber.AutoSize = true;
            this.lblOdaber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblOdaber.Location = new System.Drawing.Point(500, 73);
            this.lblOdaber.Name = "lblOdaber";
            this.lblOdaber.Size = new System.Drawing.Size(101, 20);
            this.lblOdaber.TabIndex = 1;
            this.lblOdaber.Text = "Odaberi tim:";
            // 
            // lblRangiraj
            // 
            this.lblRangiraj.AutoSize = true;
            this.lblRangiraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblRangiraj.Location = new System.Drawing.Point(514, 199);
            this.lblRangiraj.Name = "lblRangiraj";
            this.lblRangiraj.Size = new System.Drawing.Size(87, 18);
            this.lblRangiraj.TabIndex = 2;
            this.lblRangiraj.Text = "Rangiraj po:";
            // 
            // btnGolovi
            // 
            this.btnGolovi.Location = new System.Drawing.Point(462, 242);
            this.btnGolovi.Name = "btnGolovi";
            this.btnGolovi.Size = new System.Drawing.Size(190, 36);
            this.btnGolovi.TabIndex = 3;
            this.btnGolovi.Text = "Golovi";
            this.btnGolovi.UseVisualStyleBackColor = true;
            this.btnGolovi.Click += new System.EventHandler(this.btnGolovi_Click);
            // 
            // btnKartoni
            // 
            this.btnKartoni.Location = new System.Drawing.Point(462, 320);
            this.btnKartoni.Name = "btnKartoni";
            this.btnKartoni.Size = new System.Drawing.Size(190, 36);
            this.btnKartoni.TabIndex = 4;
            this.btnKartoni.Text = "Kartoni";
            this.btnKartoni.UseVisualStyleBackColor = true;
            this.btnKartoni.Click += new System.EventHandler(this.btnKartoni_Click);
            // 
            // btnUtakmice
            // 
            this.btnUtakmice.Location = new System.Drawing.Point(462, 399);
            this.btnUtakmice.Name = "btnUtakmice";
            this.btnUtakmice.Size = new System.Drawing.Size(190, 36);
            this.btnUtakmice.TabIndex = 5;
            this.btnUtakmice.Text = "Utakmice";
            this.btnUtakmice.UseVisualStyleBackColor = true;
            this.btnUtakmice.Click += new System.EventHandler(this.btnUtakmice_Click);
            // 
            // lblOmiljeni
            // 
            this.lblOmiljeni.AutoSize = true;
            this.lblOmiljeni.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblOmiljeni.Location = new System.Drawing.Point(139, 31);
            this.lblOmiljeni.Name = "lblOmiljeni";
            this.lblOmiljeni.Size = new System.Drawing.Size(134, 24);
            this.lblOmiljeni.TabIndex = 8;
            this.lblOmiljeni.Text = "Omiljeni igraći:";
            // 
            // lblIgraci
            // 
            this.lblIgraci.AutoSize = true;
            this.lblIgraci.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblIgraci.Location = new System.Drawing.Point(836, 31);
            this.lblIgraci.Name = "lblIgraci";
            this.lblIgraci.Size = new System.Drawing.Size(90, 24);
            this.lblIgraci.TabIndex = 9;
            this.lblIgraci.Text = "Svi igraći:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1098, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // btnPostavke
            // 
            this.btnPostavke.Location = new System.Drawing.Point(462, 613);
            this.btnPostavke.Name = "btnPostavke";
            this.btnPostavke.Size = new System.Drawing.Size(190, 36);
            this.btnPostavke.TabIndex = 11;
            this.btnPostavke.Text = "Postavke";
            this.btnPostavke.UseVisualStyleBackColor = true;
            this.btnPostavke.Click += new System.EventHandler(this.btnPostavke_Click);
            // 
            // panelIgraci
            // 
            this.panelIgraci.AllowDrop = true;
            this.panelIgraci.AutoScroll = true;
            this.panelIgraci.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIgraci.Location = new System.Drawing.Point(693, 73);
            this.panelIgraci.Name = "panelIgraci";
            this.panelIgraci.Size = new System.Drawing.Size(370, 576);
            this.panelIgraci.TabIndex = 0;
            // 
            // panelOmiljeni
            // 
            this.panelOmiljeni.AllowDrop = true;
            this.panelOmiljeni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOmiljeni.Location = new System.Drawing.Point(37, 73);
            this.panelOmiljeni.Name = "panelOmiljeni";
            this.panelOmiljeni.Size = new System.Drawing.Size(370, 576);
            this.panelOmiljeni.TabIndex = 1;
            // 
            // GlavnaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 682);
            this.Controls.Add(this.panelOmiljeni);
            this.Controls.Add(this.panelIgraci);
            this.Controls.Add(this.btnPostavke);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblIgraci);
            this.Controls.Add(this.lblOmiljeni);
            this.Controls.Add(this.btnUtakmice);
            this.Controls.Add(this.btnKartoni);
            this.Controls.Add(this.btnGolovi);
            this.Controls.Add(this.lblRangiraj);
            this.Controls.Add(this.lblOdaber);
            this.Controls.Add(this.comboBoxTim);
            this.Name = "GlavnaForma";
            this.Text = "Omiljeni igraći i rangovi";
            this.Load += new System.EventHandler(this.GlavnaForma_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTim;
        private System.Windows.Forms.Label lblOdaber;
        private System.Windows.Forms.Label lblRangiraj;
        private System.Windows.Forms.Button btnGolovi;
        private System.Windows.Forms.Button btnKartoni;
        private System.Windows.Forms.Button btnUtakmice;
        private System.Windows.Forms.Label lblOmiljeni;
        private System.Windows.Forms.Label lblIgraci;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnPostavke;
        private System.Windows.Forms.FlowLayoutPanel panelIgraci;
        private System.Windows.Forms.FlowLayoutPanel panelOmiljeni;
    }
}

