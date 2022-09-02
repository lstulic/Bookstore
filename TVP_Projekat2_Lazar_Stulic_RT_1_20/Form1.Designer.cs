
namespace TVP_Projekat2_Lazar_Stulic_RT_1_20
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.knjizaraDataSet = new TVP_Projekat2_Lazar_Stulic_RT_1_20.KnjizaraDataSet();
            this.knjigaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.knjigaTableAdapter = new TVP_Projekat2_Lazar_Stulic_RT_1_20.KnjizaraDataSetTableAdapters.KnjigaTableAdapter();
            this.cbZanr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nudBroj = new System.Windows.Forms.NumericUpDown();
            this.lbRacun = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.lblTrenutnaKnjiga = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUkupnaCena = new System.Windows.Forms.Label();
            this.btnIzbaciJednu = new System.Windows.Forms.Button();
            this.btnIzbaciSve = new System.Windows.Forms.Button();
            this.nudKom = new System.Windows.Forms.NumericUpDown();
            this.btnIzbaciKom = new System.Windows.Forms.Button();
            this.cbPopust = new System.Windows.Forms.CheckBox();
            this.btnIzbaci = new System.Windows.Forms.Button();
            this.btnDodavanje = new System.Windows.Forms.Button();
            this.btnRacuni = new System.Windows.Forms.Button();
            this.btnStatistika = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knjizaraDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knjigaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBroj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKom)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(513, 403);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // knjizaraDataSet
            // 
            this.knjizaraDataSet.DataSetName = "KnjizaraDataSet";
            this.knjizaraDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // knjigaBindingSource
            // 
            this.knjigaBindingSource.DataMember = "Knjiga";
            this.knjigaBindingSource.DataSource = this.knjizaraDataSet;
            // 
            // knjigaTableAdapter
            // 
            this.knjigaTableAdapter.ClearBeforeFill = true;
            // 
            // cbZanr
            // 
            this.cbZanr.FormattingEnabled = true;
            this.cbZanr.Location = new System.Drawing.Point(47, 482);
            this.cbZanr.Name = "cbZanr";
            this.cbZanr.Size = new System.Drawing.Size(121, 21);
            this.cbZanr.TabIndex = 1;
            this.cbZanr.SelectedIndexChanged += new System.EventHandler(this.cbZanr_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 485);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Zanr";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 480);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Resetuj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nudBroj
            // 
            this.nudBroj.Location = new System.Drawing.Point(456, 512);
            this.nudBroj.Name = "nudBroj";
            this.nudBroj.Size = new System.Drawing.Size(44, 20);
            this.nudBroj.TabIndex = 4;
            // 
            // lbRacun
            // 
            this.lbRacun.FormattingEnabled = true;
            this.lbRacun.Location = new System.Drawing.Point(546, 72);
            this.lbRacun.Name = "lbRacun";
            this.lbRacun.Size = new System.Drawing.Size(377, 407);
            this.lbRacun.TabIndex = 5;
            this.lbRacun.SelectedIndexChanged += new System.EventHandler(this.lbRacun_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 514);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kolicina";
            // 
            // btnDodaj
            // 
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.Location = new System.Drawing.Point(506, 511);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(23, 23);
            this.btnDodaj.TabIndex = 7;
            this.btnDodaj.Text = "+";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // lblTrenutnaKnjiga
            // 
            this.lblTrenutnaKnjiga.AutoSize = true;
            this.lblTrenutnaKnjiga.Location = new System.Drawing.Point(255, 485);
            this.lblTrenutnaKnjiga.Name = "lblTrenutnaKnjiga";
            this.lblTrenutnaKnjiga.Size = new System.Drawing.Size(13, 13);
            this.lblTrenutnaKnjiga.TabIndex = 8;
            this.lblTrenutnaKnjiga.Text = "k";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(551, 514);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cena: ";
            // 
            // lblUkupnaCena
            // 
            this.lblUkupnaCena.AutoSize = true;
            this.lblUkupnaCena.Location = new System.Drawing.Point(593, 514);
            this.lblUkupnaCena.Name = "lblUkupnaCena";
            this.lblUkupnaCena.Size = new System.Drawing.Size(0, 13);
            this.lblUkupnaCena.TabIndex = 10;
            // 
            // btnIzbaciJednu
            // 
            this.btnIzbaciJednu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzbaciJednu.Location = new System.Drawing.Point(592, 479);
            this.btnIzbaciJednu.Name = "btnIzbaciJednu";
            this.btnIzbaciJednu.Size = new System.Drawing.Size(23, 23);
            this.btnIzbaciJednu.TabIndex = 11;
            this.btnIzbaciJednu.Text = "-";
            this.btnIzbaciJednu.UseVisualStyleBackColor = true;
            this.btnIzbaciJednu.Click += new System.EventHandler(this.btnIzbaciJednu_Click);
            // 
            // btnIzbaciSve
            // 
            this.btnIzbaciSve.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzbaciSve.Location = new System.Drawing.Point(549, 479);
            this.btnIzbaciSve.Name = "btnIzbaciSve";
            this.btnIzbaciSve.Size = new System.Drawing.Size(37, 23);
            this.btnIzbaciSve.TabIndex = 12;
            this.btnIzbaciSve.Text = "------";
            this.btnIzbaciSve.UseVisualStyleBackColor = true;
            this.btnIzbaciSve.Click += new System.EventHandler(this.btnIzbaciSve_Click);
            // 
            // nudKom
            // 
            this.nudKom.Location = new System.Drawing.Point(848, 482);
            this.nudKom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudKom.Name = "nudKom";
            this.nudKom.Size = new System.Drawing.Size(46, 20);
            this.nudKom.TabIndex = 13;
            this.nudKom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnIzbaciKom
            // 
            this.btnIzbaciKom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzbaciKom.Location = new System.Drawing.Point(900, 481);
            this.btnIzbaciKom.Name = "btnIzbaciKom";
            this.btnIzbaciKom.Size = new System.Drawing.Size(23, 23);
            this.btnIzbaciKom.TabIndex = 14;
            this.btnIzbaciKom.Text = "-";
            this.btnIzbaciKom.UseVisualStyleBackColor = true;
            this.btnIzbaciKom.Click += new System.EventHandler(this.btnIzbaciKom_Click);
            // 
            // cbPopust
            // 
            this.cbPopust.AutoSize = true;
            this.cbPopust.Location = new System.Drawing.Point(621, 484);
            this.cbPopust.Name = "cbPopust";
            this.cbPopust.Size = new System.Drawing.Size(59, 17);
            this.cbPopust.TabIndex = 15;
            this.cbPopust.Text = "Popust";
            this.cbPopust.UseVisualStyleBackColor = true;
            this.cbPopust.CheckedChanged += new System.EventHandler(this.cbPopust_CheckedChanged);
            // 
            // btnIzbaci
            // 
            this.btnIzbaci.Location = new System.Drawing.Point(756, 509);
            this.btnIzbaci.Name = "btnIzbaci";
            this.btnIzbaci.Size = new System.Drawing.Size(167, 23);
            this.btnIzbaci.TabIndex = 16;
            this.btnIzbaci.Text = "Izbaci račun";
            this.btnIzbaci.UseVisualStyleBackColor = true;
            this.btnIzbaci.Click += new System.EventHandler(this.btnIzbaci_Click);
            // 
            // btnDodavanje
            // 
            this.btnDodavanje.Location = new System.Drawing.Point(15, 512);
            this.btnDodavanje.Name = "btnDodavanje";
            this.btnDodavanje.Size = new System.Drawing.Size(108, 26);
            this.btnDodavanje.TabIndex = 17;
            this.btnDodavanje.Text = "Dodavanje knjiga";
            this.btnDodavanje.UseVisualStyleBackColor = true;
            this.btnDodavanje.Click += new System.EventHandler(this.btnDodavanje_Click);
            // 
            // btnRacuni
            // 
            this.btnRacuni.Location = new System.Drawing.Point(129, 512);
            this.btnRacuni.Name = "btnRacuni";
            this.btnRacuni.Size = new System.Drawing.Size(108, 26);
            this.btnRacuni.TabIndex = 18;
            this.btnRacuni.Text = "Prikaz racuna";
            this.btnRacuni.UseVisualStyleBackColor = true;
            this.btnRacuni.Click += new System.EventHandler(this.btnRacuni_Click);
            // 
            // btnStatistika
            // 
            this.btnStatistika.Location = new System.Drawing.Point(243, 512);
            this.btnStatistika.Name = "btnStatistika";
            this.btnStatistika.Size = new System.Drawing.Size(108, 26);
            this.btnStatistika.TabIndex = 19;
            this.btnStatistika.Text = "Statistika";
            this.btnStatistika.UseVisualStyleBackColor = true;
            this.btnStatistika.Click += new System.EventHandler(this.btnStatistika_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(0, 30);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(39, 24);
            this.lbl1.TabIndex = 20;
            this.lbl1.Text = "lbl1";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(450, 28);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(39, 24);
            this.lbl2.TabIndex = 21;
            this.lbl2.Text = "lbl2";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(900, 28);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(39, 24);
            this.lbl3.TabIndex = 22;
            this.lbl3.Text = "lbl3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 546);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnStatistika);
            this.Controls.Add(this.btnRacuni);
            this.Controls.Add(this.btnDodavanje);
            this.Controls.Add(this.btnIzbaci);
            this.Controls.Add(this.cbPopust);
            this.Controls.Add(this.btnIzbaciKom);
            this.Controls.Add(this.nudKom);
            this.Controls.Add(this.btnIzbaciSve);
            this.Controls.Add(this.btnIzbaciJednu);
            this.Controls.Add(this.lblUkupnaCena);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTrenutnaKnjiga);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbRacun);
            this.Controls.Add(this.nudBroj);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbZanr);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knjizaraDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knjigaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBroj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private KnjizaraDataSet knjizaraDataSet;
        private System.Windows.Forms.BindingSource knjigaBindingSource;
        private KnjizaraDataSetTableAdapters.KnjigaTableAdapter knjigaTableAdapter;
        private System.Windows.Forms.ComboBox cbZanr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nudBroj;
        private System.Windows.Forms.ListBox lbRacun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Label lblTrenutnaKnjiga;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUkupnaCena;
        private System.Windows.Forms.Button btnIzbaciJednu;
        private System.Windows.Forms.Button btnIzbaciSve;
        private System.Windows.Forms.NumericUpDown nudKom;
        private System.Windows.Forms.Button btnIzbaciKom;
        private System.Windows.Forms.CheckBox cbPopust;
        private System.Windows.Forms.Button btnIzbaci;
        private System.Windows.Forms.Button btnDodavanje;
        private System.Windows.Forms.Button btnRacuni;
        private System.Windows.Forms.Button btnStatistika;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
    }
}

