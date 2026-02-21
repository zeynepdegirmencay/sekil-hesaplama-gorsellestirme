using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zeynepödev2
{
    public partial class Form2Cizim : Form
    {
        private Sekil sekil;
        public Form2Cizim()
        {
            InitializeComponent();
           
        }

        public Form2Cizim(Sekil sekil)
        {
            this.sekil = sekil;
            Paint += Form2Cizim_Paint;
            DoubleBuffered = true; //titrememesi için

        }

        private void Form2Cizim_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            string renkStr = RenkCevir(sekil.SekilRenk); // Renk çevir

            Pen kalem = new Pen(Color.FromName(renkStr), 2); // Kenar çizgisi
            Brush firca = new SolidBrush(Color.FromName(renkStr)); // İçini doldurması için

            if (sekil is Dikdortgen d)
            {
                float x = 50;
                float y = 50;
                float en = (float)d.En * 10;
                float boy = (float)d.Genislik * 10;

                g.FillRectangle(firca, x, y, en, boy);
                g.DrawRectangle(kalem, x, y, en, boy);
            }
            else if (sekil is Eskenar_ucgen u)
            {
                float kenar = (float)u.Kenar * 10;
                float yukseklik = (float)(Math.Sqrt(3) / 2 * kenar);

                float centerX = this.ClientSize.Width / 2;
                float startY = 50;

                PointF p1 = new PointF(centerX, startY); // tepe
                PointF p2 = new PointF(centerX - kenar / 2, startY + yukseklik); // sol alt
                PointF p3 = new PointF(centerX + kenar / 2, startY + yukseklik); // sağ alt

                PointF[] ucgenNoktalari = new[] { p1, p2, p3 };

                g.FillPolygon(firca, ucgenNoktalari);
                g.DrawPolygon(kalem, ucgenNoktalari);
            }
            else if (sekil is Daire c)
            {
                float cap = (float)c.Cap * 5;
                float x = 50;
                float y = 50;

                g.FillEllipse(firca, x, y, cap, cap);
                g.DrawEllipse(kalem, x, y, cap, cap);
            }
        }
        private void Form2Cizim_Load(object sender, EventArgs e)
        {

        }
        private string RenkCevir(Sekil.Renk renk)
        {
            switch (renk)
            {
                case Sekil.Renk.Kirmizi:
                    return "Red";
                case Sekil.Renk.Siyah:
                    return "Black";
                case Sekil.Renk.Sari:
                    return "Yellow";
                case Sekil.Renk.Mavi:
                    return "Blue";
                default:
                    return "Black"; //varsayılan renk siyah
            }
        }

    }
}
