using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_Projekat2_Lazar_Stulic_RT_1_20
{
    public partial class Statistika : Form
    {
        KnjizaraDataSet ds;
        KnjizaraDataSetTableAdapters.KnjigaTableAdapter daKnjiga;
        KnjizaraDataSetTableAdapters.RacunTableAdapter daRacun;
        KnjizaraDataSetTableAdapters.Stavka_racunaTableAdapter daStavka;
        List<Racun> racuni;
        List<Stavka> stavke;
        int mesec;

        int idKnjige = -1;

        public Statistika()
        {
            InitializeComponent();
            ds = new KnjizaraDataSet();
            daKnjiga = new KnjizaraDataSetTableAdapters.KnjigaTableAdapter();
            daRacun = new KnjizaraDataSetTableAdapters.RacunTableAdapter();
            daStavka = new KnjizaraDataSetTableAdapters.Stavka_racunaTableAdapter();
            racuni = new List<Racun>();
            stavke = new List<Stavka>();
        }

        private void Statistika_Load(object sender, EventArgs e)
        {
            daKnjiga.Fill(ds.Knjiga);
            dataGridView1.DataSource = ds.Knjiga;
            daRacun.Fill(ds.Racun);
            daStavka.Fill(ds.Stavka_racuna);

            comboBox1.Items.Add("Januar");
            comboBox1.Items.Add("Februar");
            comboBox1.Items.Add("Mart");
            comboBox1.Items.Add("April");
            comboBox1.Items.Add("Maj");
            comboBox1.Items.Add("Jun");
            comboBox1.Items.Add("Jul");
            comboBox1.Items.Add("Avgust");
            comboBox1.Items.Add("Septembar");
            comboBox1.Items.Add("Oktobar");
            comboBox1.Items.Add("Novembar");
            comboBox1.Items.Add("Decembar");
            comboBox1.SelectedIndex = 0;




        }



        bool dodato = true;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            idKnjige = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            string ime = dataGridView1.SelectedCells[2].Value.ToString();
            string autor = dataGridView1.SelectedCells[1].Value.ToString();
            string cena = dataGridView1.SelectedCells[3].Value.ToString();
            label1.Text = ime + " - " + autor;
            this.Paint += crtaj;
            dodato = false;
            Invalidate();
        }

        private void crtaj(object sender, PaintEventArgs e)
        {
            var sve = (from k in ds.Knjiga
                       join s in ds.Stavka_racuna on k.id_knjiga equals s.id_knjiga
                       join r in ds.Racun on s.id_racun equals r.id_racun
                       where r.datum.Month == mesec
                       select k).Count();

            var izabrana = (from k in ds.Knjiga
                            join s in ds.Stavka_racuna on k.id_knjiga equals s.id_knjiga
                            join r in ds.Racun on s.id_racun equals r.id_racun
                            where r.datum.Month == mesec && k.id_knjiga == idKnjige
                            select k).Count();

            double procenat = (izabrana / (sve * 1.0)) * 100;
            if (procenat >= 1 && procenat <= 100)
            {
                Rectangle r = new Rectangle(400, 100, 150, 150);
                e.Graphics.FillRectangle(Brushes.Red, new Rectangle(385, 47, 10, 10));
                e.Graphics.FillRectangle(Brushes.Blue, new Rectangle(385, 69, 10, 10));
                e.Graphics.FillEllipse(Brushes.Blue, r);
                e.Graphics.FillPie(Brushes.Red, r, -90, 3.6f * (float) procenat);
                label2.Text = "Ostale knjige";
            }
        }

        private void Statistika_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    mesec = 1;
                    break;
                case 1:
                    mesec = 2;
                    break;
                case 2:
                    mesec = 3;
                    break;
                case 3:
                    mesec = 4;
                    break;
                case 4:
                    mesec = 5;
                    break;
                case 5:
                    mesec = 6;
                    break;
                case 6:
                    mesec = 7;
                    break;
                case 7:
                    mesec = 8;
                    break;
                case 8:
                    mesec = 9;
                    break;
                case 9:
                    mesec = 10;
                    break;
                case 10:
                    mesec = 11;
                    break;
                case 11:
                    mesec = 12;
                    break;
            }
            this.Paint += crtaj;
            dodato = false;
            Invalidate();
        }
        
    }
}
