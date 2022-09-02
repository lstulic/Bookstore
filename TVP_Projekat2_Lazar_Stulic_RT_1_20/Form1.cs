using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP_Projekat2_Lazar_Stulic_RT_1_20
{
    public partial class Form1 : Form
    {
        double popust = 0;
        int idKnjige = -1;
        int idKnjigaRacun = -1;
        int pocetak = 0;
        int najduza = 0;
        Racun racun;
        KnjizaraDataSet ds;
        KnjizaraDataSetTableAdapters.KnjigaTableAdapter daKnjiga;
        KnjizaraDataSetTableAdapters.ZanrTableAdapter daZanr;
        KnjizaraDataSetTableAdapters.PripadnostTableAdapter daPripadnost;
        KnjizaraDataSetTableAdapters.RacunTableAdapter daRacun;
        KnjizaraDataSetTableAdapters.Stavka_racunaTableAdapter daStavka;
        List<Stavka> stavke;
        List<int> indexi;

        public Form1()
        {
            InitializeComponent();
            ds = new KnjizaraDataSet();
            daKnjiga = new KnjizaraDataSetTableAdapters.KnjigaTableAdapter();
            daZanr = new KnjizaraDataSetTableAdapters.ZanrTableAdapter();
            daPripadnost = new KnjizaraDataSetTableAdapters.PripadnostTableAdapter();
            daRacun = new KnjizaraDataSetTableAdapters.RacunTableAdapter();
            daStavka = new KnjizaraDataSetTableAdapters.Stavka_racunaTableAdapter();
            stavke = new List<Stavka>();
            indexi = new List<int>();
            DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            daKnjiga.Fill(ds.Knjiga);
            daZanr.Fill(ds.Zanr);
            daPripadnost.Fill(ds.Pripadnost);
            daRacun.Fill(ds.Racun);
            daStavka.Fill(ds.Stavka_racuna);



            var rezultatKnjiga = ds.Knjiga.OrderBy(s => s.naziv);
            DataTable knjige = ds.Knjiga.Copy();
            knjige.Clear();
            foreach (var red in rezultatKnjiga)
            {
                DataRow noviRed = knjige.NewRow();
                for (int i = 0; i < ds.Knjiga.Columns.Count; i++)
                {
                    noviRed[i] = red[i];
                }
                knjige.Rows.Add(noviRed);
            }

            dataGridView1.DataSource = knjige;




            
            cbZanr.DataSource = ds.Zanr;
            cbZanr.ValueMember = ds.Zanr.Columns[0].ToString();
            cbZanr.DisplayMember = ds.Zanr.Columns[1].ToString();
            cbZanr.SelectedItem = null;



            
            nudBroj.Minimum = 1;
            najprodavaniji();

            Task t1 = new Task(animacija1);
            t1.Start();
            Task t2 = new Task(animacija2);
            t2.Start();
            Task t3 = new Task(animacija3);
            t3.Start();

        }

        private void cbZanr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pocetak > 3)
            {
                var rezultat = from k in ds.Knjiga
                               join p in ds.Pripadnost on k.id_knjiga equals p.id_knjiga
                               join z in ds.Zanr on p.id_zanr equals z.id_zanr
                               orderby k.naziv
                               where z.id_zanr.Equals(Convert.ToInt32(cbZanr.SelectedValue))
                               select k;


                DataTable knjige = ds.Knjiga.Copy();
                knjige.Clear();
                foreach (var red in rezultat)
                {
                    DataRow noviRed = knjige.NewRow();
                    for (int i = 0; i < ds.Knjiga.Columns.Count; i++)
                    {
                        noviRed[i] = red[i];
                    }
                    knjige.Rows.Add(noviRed);
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = knjige;
            }
            else
            {
                pocetak++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            daKnjiga.Fill(ds.Knjiga);
            var rezultatKnjiga = ds.Knjiga.OrderBy(s => s.naziv);
            DataTable knjige = ds.Knjiga.Copy();
            knjige.Clear();
            foreach (var red in rezultatKnjiga)
            {
                DataRow noviRed = knjige.NewRow();
                for (int i = 0; i < ds.Knjiga.Columns.Count; i++)
                {
                    noviRed[i] = red[i];
                }
                knjige.Rows.Add(noviRed);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = knjige;
            pocetak = 3;
            cbZanr.SelectedItem = null;

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (racun == null)
            {
                int idRacuna = 0;
                //idRacuna = ds.Racun.Max(r => r.id_racun);

                racun = new Racun(idRacuna);

            }
            if (idKnjige > -1)
            {
                bool postoji = false;
                int komada = Convert.ToInt32(nudBroj.Value);
                var rezultat = ds.Knjiga.Where(k => k.id_knjiga == idKnjige).Select(k => new { id = k.id_knjiga, naziv = k.naziv, autor = k.autor, cena = k.cena, brojStrana = k.broj_strana, popust = k.popust });

                foreach (var k in rezultat)
                {
                   
                    stavke.Add(new Stavka(racun.IdRacuna, k.id, k.cena * komada));
                    indexi.Add(k.id);

                    lbRacun.Items.Add(k.naziv + " | " + k.autor + " | " + k.cena * komada + " | " + komada);
                    racun.UkupnaCena += k.cena * komada;
                    lblUkupnaCena.Text = racun.UkupnaCena.ToString();
                }
            }
            else
            {
                MessageBox.Show("Niste odabrali knjigu");
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            idKnjige = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            string ime = dataGridView1.SelectedCells[2].Value.ToString();
            string autor = dataGridView1.SelectedCells[1].Value.ToString();
            string cena = dataGridView1.SelectedCells[3].Value.ToString();
            lblTrenutnaKnjiga.Text = ime + " - " + autor + "   " + cena + " din";
        }

        private void lbRacun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbRacun.SelectedIndex < 0)
            {

            }
            else
            {
                if (lbRacun.Items.Count > 0)
                {
                    idKnjigaRacun = indexi[lbRacun.SelectedIndex];
                    string[] s = lbRacun.SelectedItem.ToString().Split('|');
                    nudKom.Maximum = Convert.ToInt32(s[3].Trim());
                }
            }
            
        }

        private void btnIzbaciSve_Click(object sender, EventArgs e)
        {
            stavke.Clear();
            indexi.Clear();
            lbRacun.Items.Clear();
            racun.UkupnaCena = 0;
            lblUkupnaCena.Text = racun.UkupnaCena.ToString();
        }

        private void btnIzbaciKom_Click(object sender, EventArgs e)
        {
            if (idKnjigaRacun > -1)
            {
                int kom = Convert.ToInt32(nudKom.Value);
                var rezultat = ds.Knjiga.Where(k => k.id_knjiga == idKnjigaRacun).Select(k => new { id = k.id_knjiga, naziv = k.naziv, autor = k.autor, cena = k.cena, brojStrana = k.broj_strana, popust = k.popust });
                foreach (var r in rezultat)
                {
                    string[] s = lbRacun.SelectedItem.ToString().Split('|');
                    int komada = Convert.ToInt32(s[3].Trim()) - kom;

                    stavke[lbRacun.SelectedIndex].Cena -= kom * r.cena;
                    racun.UkupnaCena -= stavke[lbRacun.SelectedIndex].Cena;
                    lbRacun.Items[lbRacun.SelectedIndex] = r.naziv + " | " + r.autor + " | " + stavke[lbRacun.SelectedIndex].Cena + " | " + komada;
                    if (stavke[lbRacun.SelectedIndex].Cena == 0)
                    {
                        stavke.RemoveAt(lbRacun.SelectedIndex);
                        indexi.RemoveAt(lbRacun.SelectedIndex);
                        lbRacun.Items.RemoveAt(lbRacun.SelectedIndex);
                    }
                    lblUkupnaCena.Text = racun.UkupnaCena.ToString();
                    nudKom.Minimum = 1;
                    break;
                    
                }
            }
            else
            {
                MessageBox.Show("Niste izabrali stavku");
            }

        }

        private void btnIzbaciJednu_Click(object sender, EventArgs e)
        {
            racun.UkupnaCena -= stavke[lbRacun.SelectedIndex].Cena;

            stavke.RemoveAt(lbRacun.SelectedIndex);
            indexi.RemoveAt(lbRacun.SelectedIndex);
            lbRacun.Items.RemoveAt(lbRacun.SelectedIndex);

            lblUkupnaCena.Text = racun.UkupnaCena.ToString();
        }

        private void cbPopust_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPopust.Checked)
            {
                racun.UkupnaCena = 0;
                var rezultat = ds.Knjiga.Select(k => new { id = k.id_knjiga, naziv = k.naziv, autor = k.autor, cena = k.cena, brojStrana = k.broj_strana, popust = k.popust });

                foreach (var k in rezultat)
                {
                    for (int i = 0; i < stavke.Count; i++)
                    {

                        if (stavke[i].Popust == 1)
                        {
                            continue;
                        }

                        string[] s = lbRacun.Items[i].ToString().Split('|');
                        if (stavke[i].IdKnjige == k.id)
                        {
                            stavke[i].Cena -= (stavke[i].Cena *( (double) k.popust / 100));
                            lbRacun.Items[i] = s[0].Trim() + " | " + s[1].Trim() + " | " + stavke[i].Cena + " | " + s[3].Trim();
                            stavke[i].Popust = 1;
                            continue;
                        }

                    }
                }

                for (int i = 0; i < stavke.Count; i++)
                {
                    racun.UkupnaCena += stavke[i].Cena;
                }

            }
            else
            {
                racun.UkupnaCena = 0;
                var rezultat = ds.Knjiga.Select(k => new { id = k.id_knjiga, naziv = k.naziv, autor = k.autor, cena = k.cena, brojStrana = k.broj_strana, popust = k.popust });

                foreach (var k in rezultat)
                {
                    for (int i = 0; i < stavke.Count; i++)
                    {
                        if (stavke[i].Popust == 0)
                        {
                            continue;
                        }
                        string[] s = lbRacun.Items[i].ToString().Split('|');
                        if (stavke[i].IdKnjige == k.id)
                        {
                            stavke[i].Cena = k.cena * Convert.ToInt32(s[3].Trim());
                            lbRacun.Items[i] = k.naziv + " | " + k.autor + " | " + stavke[i].Cena + " | " + Convert.ToInt32(s[3].Trim());
                            stavke[i].Popust = 0;
                            continue;
                        }
                        

                    }
                }
                for (int i = 0; i < stavke.Count; i++)
                {
                    racun.UkupnaCena += stavke[i].Cena;
                }

                
            }

            lblUkupnaCena.Text = racun.UkupnaCena.ToString();
        }

        private void btnIzbaci_Click(object sender, EventArgs e)
        {
            List<Stavka> stav = new List<Stavka>();

            for (int i = 0; i < stavke.Count; i++)
            {
                bool postoji = false;
                for (int j = 0; j < stav.Count; j++)
                {
                    if (stav[j].IdRacuna == stavke[i].IdRacuna && stav[j].IdKnjige == stavke[i].IdKnjige)
                    {
                        stav[j].Cena += stavke[i].Cena;
                        postoji = true;
                        break;
                    }
                }

                if (!postoji)
                {
                    stav.Add(stavke[i]);
                }
            }

            stavke = stav;

            if (racun != null && stavke.Count > 0)
            {
                int rez1 = daRacun.Insert(racun.Datum, Convert.ToInt32(racun.UkupnaCena));

                if (rez1 > 0)
                {
                    daRacun.Fill(ds.Racun);
                }

                var izdat = ds.Racun.Max(s => s.id_racun);

                for (int i = 0; i < stavke.Count; i++)
                {
                    stavke[i].IdRacuna = izdat;
                    int rez2 = daStavka.Insert(stavke[i].IdRacuna, stavke[i].IdKnjige, Convert.ToInt32(stavke[i].Cena), stavke[i].Popust);

                    if (rez2 > 0)
                    {
                        daStavka.Fill(ds.Stavka_racuna);
                        
                    }
                }
                MessageBox.Show("Uspesno dodato!");
                racun = null;
                stavke.Clear();
                indexi.Clear();
                lbRacun.Items.Clear();
            }
            else
            {
                MessageBox.Show("Niste dodali ni jednu knjigu na racun!!!");
            }

        }

        private void btnDodavanje_Click(object sender, EventArgs e)
        {
            Dodavanje d = new Dodavanje();
            d.FormClosed += D_FormClosed;
            d.Show();
        }

        private void D_FormClosed(object sender, FormClosedEventArgs e)
        {
            var rezultatKnjiga = ds.Knjiga.OrderBy(s => s.naziv);
            DataTable knjige = ds.Knjiga.Copy();
            knjige.Clear();
            foreach (var red in rezultatKnjiga)
            {
                DataRow noviRed = knjige.NewRow();
                for (int i = 0; i < ds.Knjiga.Columns.Count; i++)
                {
                    noviRed[i] = red[i];
                }
                knjige.Rows.Add(noviRed);
            }


            dataGridView1.DataSource = null;
            dataGridView1.DataSource = knjige;
        }

        private void btnRacuni_Click(object sender, EventArgs e)
        {
            Racuni r = new Racuni();
            r.Show();
        }

        private void btnStatistika_Click(object sender, EventArgs e)
        {
            Statistika s = new Statistika();
            s.Show();
        }

        public void najprodavaniji()
        {
            List<int> broj = new List<int>();
            foreach (var v in ds.Knjiga)
            {
                var izabrana = (from k in ds.Knjiga
                                join s in ds.Stavka_racuna on k.id_knjiga equals s.id_knjiga
                                join r in ds.Racun on s.id_racun equals r.id_racun
                                where r.datum.Date == DateTime.Now.Date && k.id_knjiga == v.id_knjiga
                                select k).Count();
                broj.Add(izabrana);
            }

            broj.Sort();
            int[] ID = new int[3];
            foreach (var v in ds.Knjiga)
            {
                var izabrana = (from k in ds.Knjiga
                                join s in ds.Stavka_racuna on k.id_knjiga equals s.id_knjiga
                                join r in ds.Racun on s.id_racun equals r.id_racun
                                where r.datum.Date == DateTime.Now.Date && k.id_knjiga == v.id_knjiga
                                select k).Count();
                if (izabrana == broj[broj.Count - 1] && broj[broj.Count - 1] != 0)
                {
                    ID[0] = v.id_knjiga;
                    lbl1.Text = v.naziv + " - " + v.autor;
                }
                else if (izabrana == broj[broj.Count - 2] && broj[broj.Count - 2] != 0)
                {
                    ID[1] = v.id_knjiga;
                    lbl2.Text = v.naziv + " - " + v.autor;
                }
                else if (izabrana == broj[broj.Count - 3] && broj[broj.Count - 3] != 0)
                {
                    ID[1] = v.id_knjiga;
                    lbl3.Text = v.naziv + " - " + v.autor;
                }
            }


            najduza = lbl1.Width;
            if (lbl2.Width > najduza)
            {
                najduza = lbl2.Width;
            }
            if (lbl3.Width > najduza)
            {
                najduza = lbl3.Width; 
            }

        }


        public void animacija1()
        {
            int sirina = ClientSize.Width;

            while (true)
            {

                lbl1.Invoke((MethodInvoker)(() => lbl1.Left -= 1));
                //lbl1.Left -= 1;
                if (lbl1.Location.X == 0 - 475)
                {
                    lbl1.Invoke((MethodInvoker)(() => lbl1.Left = sirina));
                    //lbl1.Left = sirina;
                }

                


                Thread.Sleep(1);
            }
        }

        public void animacija2()
        {
            int sirina = ClientSize.Width;

            while (true)
            {
                lbl2.Invoke((MethodInvoker)(() => lbl2.Left -= 1));
                //lbl2.Left -= 1;
                if (lbl2.Location.X == 0 - 475)
                {
                    lbl2.Invoke((MethodInvoker)(() => lbl2.Left = sirina));
                    //lbl2.Left = sirina;
                }




                Thread.Sleep(1);
            }
        }

        public void animacija3()
        {
            int sirina = ClientSize.Width;

            while (true)
            {
                lbl3.Invoke((MethodInvoker)(() => lbl3.Left -= 1));
                //lbl3.Left -= 1;
                if (lbl3.Location.X == 0 - 475)
                {
                    lbl3.Invoke((MethodInvoker)(() => lbl3.Left = sirina));
                    //lbl3.Left = sirina;
                }




                Thread.Sleep(1);
            }
        }


    }
}
