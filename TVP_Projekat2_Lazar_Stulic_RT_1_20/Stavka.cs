using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP_Projekat2_Lazar_Stulic_RT_1_20
{
    class Stavka
    {
        private int idRacuna;
        private int idKnjige;
        private double cena;
        private int popust;

        public Stavka(int idRacuna, int idKnjige, double cena)
        {
            this.idRacuna = idRacuna;
            this.idKnjige = idKnjige;
            this.cena = cena;
            this.popust = 0;
        }

        public Stavka(int idRacuna, int idKnjige, double cena, int popust)
        {
            this.idRacuna = idRacuna;
            this.idKnjige = idKnjige;
            this.cena = cena;
            this.popust = popust;
        }

        public int IdRacuna { get => idRacuna; set => idRacuna = value; }
        public int IdKnjige { get => idKnjige; set => idKnjige = value; }
        public double Cena { get => cena; set => cena = value; }
        public int Popust { get => popust; set => popust = value; }

    }
}
