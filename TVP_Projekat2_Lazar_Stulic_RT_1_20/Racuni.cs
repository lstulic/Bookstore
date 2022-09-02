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
    public partial class Racuni : Form
    {

        KnjizaraDataSet ds;
        KnjizaraDataSetTableAdapters.RacunTableAdapter daRacun;

        public Racuni()
        {
            InitializeComponent();
            ds = new KnjizaraDataSet();
            daRacun = new KnjizaraDataSetTableAdapters.RacunTableAdapter();
        }

        private void Racuni_Load(object sender, EventArgs e)
        {
            daRacun.Fill(ds.Racun);

            dataGridView1.DataSource = ds.Racun;
        }

        private void dtpOd_ValueChanged(object sender, EventArgs e)
        {
            var rezultat = ds.Racun.Where(s => s.datum.Date >= dtpOd.Value.Date && s.datum.Date <= dtpDo.Value.Date);
            DataTable racuni = ds.Racun.Copy();
            racuni.Clear();
            foreach (var red in rezultat)
            {
                DataRow noviRed = racuni.NewRow();
                for (int i = 0; i < ds.Racun.Columns.Count; i++)
                {
                    noviRed[i] = red[i];
                }
                racuni.Rows.Add(noviRed);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = racuni;
        }

        private void dtpDo_ValueChanged(object sender, EventArgs e)
        {
            
            var rezultat = ds.Racun.Where(s => s.datum.Date >= dtpOd.Value.Date && s.datum.Date <= dtpDo.Value.Date.Date);
            DataTable racuni = ds.Racun.Copy();
            racuni.Clear();
            foreach (var red in rezultat)
            {
                DataRow noviRed = racuni.NewRow();
                for (int i = 0; i < ds.Racun.Columns.Count; i++)
                {
                    noviRed[i] = red[i];
                }
                racuni.Rows.Add(noviRed);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = racuni;
        }

    }
}
