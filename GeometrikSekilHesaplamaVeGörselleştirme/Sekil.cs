using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace zeynepödev2
{
    public abstract class Sekil
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public Renk SekilRenk { get; set; }

        public Sekil(int id, string ad, Renk sekilRenk)
        {
            ID = id;
            Ad = ad;
            SekilRenk = sekilRenk;
        }
        public enum Renk //enum büyük harf olmalı
        { Kirmizi, Siyah, Sari, Mavi }
        public abstract string bilgiYazdir();
        public abstract double Cevre_Hesapla();
        public abstract double Alan_Hesapla();
    }
}

