namespace Racun
{
    partial class Racuni
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
            this.txtBrRacuna = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxKupci = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labAdresa = new System.Windows.Forms.Label();
            this.labOib = new System.Windows.Forms.Label();
            this.labTelefon = new System.Windows.Forms.Label();
            this.cboxUsluge = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDodajUslugu = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnZakljuci = new System.Windows.Forms.Button();
            this.txtKolicina = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIdUsl = new System.Windows.Forms.Label();
            this.lblNazivUsl = new System.Windows.Forms.Label();
            this.lblCijenaUsl = new System.Windows.Forms.Label();
            this.txtSifraKupca = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelpdv = new System.Windows.Forms.Label();
            this.labelukupno = new System.Windows.Forms.Label();
            this.labIznosRn = new System.Windows.Forms.Label();
            this.labPdvRn = new System.Windows.Forms.Label();
            this.lblUkRn = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBrRacuna
            // 
            this.txtBrRacuna.Location = new System.Drawing.Point(89, 55);
            this.txtBrRacuna.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBrRacuna.Name = "txtBrRacuna";
            this.txtBrRacuna.ReadOnly = true;
            this.txtBrRacuna.Size = new System.Drawing.Size(88, 22);
            this.txtBrRacuna.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Broj";
            // 
            // cboxKupci
            // 
            this.cboxKupci.FormattingEnabled = true;
            this.cboxKupci.Location = new System.Drawing.Point(89, 96);
            this.cboxKupci.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboxKupci.Name = "cboxKupci";
            this.cboxKupci.Size = new System.Drawing.Size(121, 24);
            this.cboxKupci.TabIndex = 2;
            this.cboxKupci.SelectionChangeCommitted += new System.EventHandler(this.cboxKupci_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kupac";
            // 
            // labAdresa
            // 
            this.labAdresa.AutoSize = true;
            this.labAdresa.Location = new System.Drawing.Point(301, 55);
            this.labAdresa.Name = "labAdresa";
            this.labAdresa.Size = new System.Drawing.Size(0, 17);
            this.labAdresa.TabIndex = 5;
            // 
            // labOib
            // 
            this.labOib.AutoSize = true;
            this.labOib.Location = new System.Drawing.Point(301, 98);
            this.labOib.Name = "labOib";
            this.labOib.Size = new System.Drawing.Size(0, 17);
            this.labOib.TabIndex = 6;
            // 
            // labTelefon
            // 
            this.labTelefon.AutoSize = true;
            this.labTelefon.Location = new System.Drawing.Point(440, 99);
            this.labTelefon.Name = "labTelefon";
            this.labTelefon.Size = new System.Drawing.Size(0, 17);
            this.labTelefon.TabIndex = 7;
            // 
            // cboxUsluge
            // 
            this.cboxUsluge.FormattingEnabled = true;
            this.cboxUsluge.Location = new System.Drawing.Point(89, 138);
            this.cboxUsluge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboxUsluge.Name = "cboxUsluge";
            this.cboxUsluge.Size = new System.Drawing.Size(411, 24);
            this.cboxUsluge.TabIndex = 8;
            this.cboxUsluge.SelectionChangeCommitted += new System.EventHandler(this.cboxUsluge_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Usluga";
            // 
            // btnDodajUslugu
            // 
            this.btnDodajUslugu.Location = new System.Drawing.Point(673, 132);
            this.btnDodajUslugu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDodajUslugu.Name = "btnDodajUslugu";
            this.btnDodajUslugu.Size = new System.Drawing.Size(75, 34);
            this.btnDodajUslugu.TabIndex = 10;
            this.btnDodajUslugu.Text = "Dodaj";
            this.btnDodajUslugu.UseVisualStyleBackColor = true;
            this.btnDodajUslugu.Click += new System.EventHandler(this.btnDodajUslugu_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 238);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(775, 201);
            this.dataGridView1.TabIndex = 11;
            // 
            // btnZakljuci
            // 
            this.btnZakljuci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnZakljuci.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnZakljuci.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZakljuci.Location = new System.Drawing.Point(620, 200);
            this.btnZakljuci.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZakljuci.Name = "btnZakljuci";
            this.btnZakljuci.Size = new System.Drawing.Size(167, 34);
            this.btnZakljuci.TabIndex = 12;
            this.btnZakljuci.Text = "Zaključi";
            this.btnZakljuci.UseVisualStyleBackColor = false;
            this.btnZakljuci.Click += new System.EventHandler(this.btnZakljuci_Click);
            // 
            // txtKolicina
            // 
            this.txtKolicina.Location = new System.Drawing.Point(577, 139);
            this.txtKolicina.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKolicina.Name = "txtKolicina";
            this.txtKolicina.Size = new System.Drawing.Size(69, 22);
            this.txtKolicina.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(515, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Količina";
            // 
            // lblIdUsl
            // 
            this.lblIdUsl.AutoSize = true;
            this.lblIdUsl.Location = new System.Drawing.Point(12, 174);
            this.lblIdUsl.Name = "lblIdUsl";
            this.lblIdUsl.Size = new System.Drawing.Size(46, 17);
            this.lblIdUsl.TabIndex = 16;
            this.lblIdUsl.Text = "label5";
            this.lblIdUsl.Visible = false;
            // 
            // lblNazivUsl
            // 
            this.lblNazivUsl.AutoSize = true;
            this.lblNazivUsl.Location = new System.Drawing.Point(64, 174);
            this.lblNazivUsl.Name = "lblNazivUsl";
            this.lblNazivUsl.Size = new System.Drawing.Size(46, 17);
            this.lblNazivUsl.TabIndex = 17;
            this.lblNazivUsl.Text = "label5";
            this.lblNazivUsl.Visible = false;
            // 
            // lblCijenaUsl
            // 
            this.lblCijenaUsl.AutoSize = true;
            this.lblCijenaUsl.Location = new System.Drawing.Point(453, 174);
            this.lblCijenaUsl.Name = "lblCijenaUsl";
            this.lblCijenaUsl.Size = new System.Drawing.Size(46, 17);
            this.lblCijenaUsl.TabIndex = 18;
            this.lblCijenaUsl.Text = "label5";
            this.lblCijenaUsl.Visible = false;
            // 
            // txtSifraKupca
            // 
            this.txtSifraKupca.AutoSize = true;
            this.txtSifraKupca.Location = new System.Drawing.Point(301, 9);
            this.txtSifraKupca.Name = "txtSifraKupca";
            this.txtSifraKupca.Size = new System.Drawing.Size(14, 17);
            this.txtSifraKupca.TabIndex = 19;
            this.txtSifraKupca.Text = "x";
            this.txtSifraKupca.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(594, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Iznos";
            // 
            // labelpdv
            // 
            this.labelpdv.AutoSize = true;
            this.labelpdv.Location = new System.Drawing.Point(593, 65);
            this.labelpdv.Name = "labelpdv";
            this.labelpdv.Size = new System.Drawing.Size(78, 17);
            this.labelpdv.TabIndex = 21;
            this.labelpdv.Text = "PDV (25%)";
            // 
            // labelukupno
            // 
            this.labelukupno.AutoSize = true;
            this.labelukupno.Location = new System.Drawing.Point(594, 108);
            this.labelukupno.Name = "labelukupno";
            this.labelukupno.Size = new System.Drawing.Size(57, 17);
            this.labelukupno.TabIndex = 22;
            this.labelukupno.Text = "Ukupno";
            // 
            // labIznosRn
            // 
            this.labIznosRn.AutoSize = true;
            this.labIznosRn.Location = new System.Drawing.Point(686, 22);
            this.labIznosRn.Name = "labIznosRn";
            this.labIznosRn.Size = new System.Drawing.Size(0, 17);
            this.labIznosRn.TabIndex = 23;
            // 
            // labPdvRn
            // 
            this.labPdvRn.AutoSize = true;
            this.labPdvRn.Location = new System.Drawing.Point(686, 65);
            this.labPdvRn.Name = "labPdvRn";
            this.labPdvRn.Size = new System.Drawing.Size(0, 17);
            this.labPdvRn.TabIndex = 24;
            // 
            // lblUkRn
            // 
            this.lblUkRn.AutoSize = true;
            this.lblUkRn.Location = new System.Drawing.Point(686, 108);
            this.lblUkRn.Name = "lblUkRn";
            this.lblUkRn.Size = new System.Drawing.Size(0, 17);
            this.lblUkRn.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Adresa:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "OIB:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(399, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 17);
            this.label8.TabIndex = 28;
            this.label8.Text = "Tel.:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 17);
            this.label9.TabIndex = 29;
            this.label9.Text = "Datum:";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(89, 22);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(0, 17);
            this.lblDatum.TabIndex = 30;
            // 
            // Racuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblUkRn);
            this.Controls.Add(this.labPdvRn);
            this.Controls.Add(this.labIznosRn);
            this.Controls.Add(this.labelukupno);
            this.Controls.Add(this.labelpdv);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSifraKupca);
            this.Controls.Add(this.lblCijenaUsl);
            this.Controls.Add(this.lblNazivUsl);
            this.Controls.Add(this.lblIdUsl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKolicina);
            this.Controls.Add(this.btnZakljuci);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDodajUslugu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboxUsluge);
            this.Controls.Add(this.labTelefon);
            this.Controls.Add(this.labOib);
            this.Controls.Add(this.labAdresa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboxKupci);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBrRacuna);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Racuni";
            this.Text = "Racuni";
            this.Load += new System.EventHandler(this.Racuni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBrRacuna;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxKupci;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labAdresa;
        private System.Windows.Forms.Label labOib;
        private System.Windows.Forms.Label labTelefon;
        private System.Windows.Forms.ComboBox cboxUsluge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDodajUslugu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnZakljuci;
        private System.Windows.Forms.TextBox txtKolicina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblIdUsl;
        private System.Windows.Forms.Label lblNazivUsl;
        private System.Windows.Forms.Label lblCijenaUsl;
        private System.Windows.Forms.Label txtSifraKupca;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelpdv;
        private System.Windows.Forms.Label labelukupno;
        private System.Windows.Forms.Label labIznosRn;
        private System.Windows.Forms.Label labPdvRn;
        private System.Windows.Forms.Label lblUkRn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDatum;
    }
}

