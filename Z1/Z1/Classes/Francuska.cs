using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    [Serializable]
    public class Francuska
    {

        public string Znamenitosti { get; set; }
        public double Ulaznica { get; set; }
        public DateTime DatumObilaska { get; set; }
        public string PutanjaSlika { get; set; }
        public string PutanjaPodaci { get; set; }

        public Francuska(string znamenitosti, double ulaznica, DateTime datumObilaska, string putanjaSlika, string putanjaPodaci)
        {
            Znamenitosti = znamenitosti;
            Ulaznica = ulaznica;
            DatumObilaska = datumObilaska;
            PutanjaSlika = putanjaSlika;
            PutanjaPodaci = putanjaPodaci;
        }


        public Francuska() { }
       

    }
}
