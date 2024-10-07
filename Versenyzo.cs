using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babolnai_bence_triatlon
{
    internal class Versenyzo
    {
        public string Nev { get; set; }
        public int SzuletesiEv { get; set; }
        public int VersenySzam { get; set; }

        public string Nem { get; set; }
        public string Kategoria { get; set; }
        public TimeSpan UszasiIdo { get; set; }
        public TimeSpan IDepoIdo { get; set; }
        public TimeSpan KerekparozasIdo { get; set; }
        public TimeSpan IIDepoIdo { get; set; }
        public TimeSpan FutasIdo { get; set; }

        public override string ToString()
        {
            return $"{Nev} ({Nem}) - {SzuletesiEv} {Kategoria}";
        }

        public Versenyzo(string sor)
        {
            string[] db = sor.Split(";");
            Nev = db[0];
            SzuletesiEv = int.Parse(db[1]);
            VersenySzam = int.Parse(db[2]);
            Nem = db[3];
            Kategoria = db[4];
            UszasiIdo = TimeSpan.Parse(db[5]);
            IDepoIdo = TimeSpan.Parse(db[6]);
            KerekparozasIdo = TimeSpan.Parse(db[7]);
            IIDepoIdo = TimeSpan.Parse(db[8]);
            FutasIdo = TimeSpan.Parse(db[9]);
        }
    }


}
