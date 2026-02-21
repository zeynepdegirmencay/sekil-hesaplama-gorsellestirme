using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zeynepödev2
{
    public class Eskenar_ucgen:Sekil
    {
        public double Kenar { get; set; }
        public Eskenar_ucgen(int id, string ad, Renk renk, double kenar) : base(id, ad, renk)
        {
            Kenar = kenar;
        }
        public override double Alan_Hesapla()
        {
            return (Math.Sqrt(3) / 4) * Math.Pow(Kenar, 2);
        }
        public override double Cevre_Hesapla()
        {
            return 3 * Kenar;
        }
        public override string bilgiYazdir()
        {
            return $"Şeklin Bilgileri:\n-ID: {ID}\n-Ad: {Ad}\n-Renk: {SekilRenk}\n-Şekil: Eşkenar Üçgen";
        }

    }
}

