using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynepödev2
{
    public class Daire:Sekil
    {
        public double Cap { get; set; }
        public double Aci { get; set; }
        public Daire (int id, string ad, Renk renk, double cap,double aci): base(id, ad, renk)
        {
            Cap = cap;
            Aci = aci;       
        }
        public override double Alan_Hesapla()
        {
            return (Aci / 360) * Math.PI * Math.Pow(Cap / 2, 2);
        }
        public override double Cevre_Hesapla()
        {
            return Cap * Math.PI * (Aci / 360);
        }
        public override string bilgiYazdir()
        {
            return $"Şeklin Bilgileri:\n-ID: {ID}\n-Ad: {Ad}\n-Renk: {SekilRenk}\n-Şekil: Daire";
        }

    }
}
