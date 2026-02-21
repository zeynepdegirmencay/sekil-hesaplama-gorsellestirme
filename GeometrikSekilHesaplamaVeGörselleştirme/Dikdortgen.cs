using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;



namespace zeynepödev2
{
    public class Dikdortgen : Sekil
    {
        public double Genislik { get; set; }
        public double En { get; set; }

        public Dikdortgen(int id, string ad, Renk renk, double en, double genislik) : base(id, ad, renk)
        {
            En = en;
            Genislik = genislik;
        }

        public override double Alan_Hesapla()
        {
            return En * Genislik;
        }

        public override double Cevre_Hesapla()
        {
            return 2 * (En + Genislik);
        }
        public override string bilgiYazdir()
        {
            return $"Şeklin Bilgileri:\n-ID: {ID}\n-Ad: {Ad}\n-Renk: {SekilRenk}\n-Şekil: Dikdörtgen";
        }

    }
}
