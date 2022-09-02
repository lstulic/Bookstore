using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_Projekat2_Lazar_Stulic_RT_1_20
{
    class Racun
    {
        private int idRacuna;
        private double ukupnaCena;
        private DateTime datum;

        public Racun(int idRacuna)
        {
            this.idRacuna = idRacuna;
            this.ukupnaCena = 0;
            this.datum = DateTime.Now;
        }

        public Racun(int idRacuna, double ukupnaCena, DateTime datum)
        {
            this.idRacuna = idRacuna;
            this.ukupnaCena = ukupnaCena;
            this.datum = datum;
        }

        public int IdRacuna { get => idRacuna; set => idRacuna = value; }
        public double UkupnaCena { get => ukupnaCena; set => ukupnaCena = value; }
        public DateTime Datum { get => datum; set => datum = value; }
    }
}
