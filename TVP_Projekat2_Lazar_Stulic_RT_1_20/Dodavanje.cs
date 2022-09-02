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
    public partial class Dodavanje : Form
    {
        /*
         Knjiga (id_knjiga, autor, naziv, cena, popust, broj_strana)
         Pripadnost (id_knjiga, id_zanr)
         */
        KnjizaraDataSet ds;
        KnjizaraDataSetTableAdapters.KnjigaTableAdapter daKnjiga;
        KnjizaraDataSetTableAdapters.ZanrTableAdapter daZanr;
        KnjizaraDataSetTableAdapters.PripadnostTableAdapter daPripadnost;

        public Dodavanje()
        {
            InitializeComponent();
            ds = new KnjizaraDataSet();
            daKnjiga = new KnjizaraDataSetTableAdapters.KnjigaTableAdapter();
            daZanr = new KnjizaraDataSetTableAdapters.ZanrTableAdapter();
            daPripadnost = new KnjizaraDataSetTableAdapters.PripadnostTableAdapter();



            
        }

        private void Dodavanje_Load(object sender, EventArgs e)
        {
            daKnjiga.Fill(ds.Knjiga);
            daZanr.Fill(ds.Zanr);
            daPripadnost.Fill(ds.Pripadnost);


            foreach (var z in ds.Zanr)
            {
                clbZanrovi.Items.Add(z.naziv.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNaziv.Text != null && txtAutor.Text != null && txtCena.Text != null && txtPopust.Text != null && txtBroj.Text != null && clbZanrovi.CheckedItems.Count > 0)
            {
                if (int.TryParse(txtCena.Text, out int cena) && int.TryParse(txtPopust.Text, out int popust) && int.TryParse(txtBroj.Text, out int broj))
                {
                    string naziv = txtNaziv.Text;
                    string autor = txtAutor.Text;

                    int rez1 = daKnjiga.Insert(autor, naziv, cena, popust, broj);

                    if (rez1 > 0)
                    {
                        daKnjiga.Fill(ds.Knjiga);
                    }

                    int id = ds.Knjiga.Max(k => k.id_knjiga);


                    for (int i = 0; i < clbZanrovi.Items.Count; i++)
                    {
                        string zanr = "";
                        if (clbZanrovi.GetItemChecked(i))
                        {
                            zanr = clbZanrovi.GetItemText(i);
                            int rez2 = 0;
                            foreach (var z in ds.Zanr)
                            {
                                if (z.naziv == zanr)
                                {
                                    rez2 = daPripadnost.Insert(id, z.id_zanr);
                                    break;
                                }
                            }

                            if (rez2 > 0)
                            {
                                daPripadnost.Fill(ds.Pripadnost);
                            }
                        }
                        
                    }
                    MessageBox.Show("Uspesno dodato!");

                }
                else
                {
                    MessageBox.Show("Podaci koje ste uneli nisu validni!");
                }

            }
            else
            {
                MessageBox.Show("Niste uneli sve potrebne podatke!");
            }
        }
    }
}
