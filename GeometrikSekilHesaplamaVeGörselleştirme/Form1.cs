using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static zeynepödev2.Sekil;

namespace zeynepödev2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            ShowShapeInputFields();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double alan = 0, cevre = 0;

                string secilenSekil = comboBox1.SelectedItem.ToString();
                int id = int.Parse(textBox7.Text);  // ID
                string ad = textBox6.Text;          // Ad
                Renk renk = (Renk)Enum.Parse(typeof(Renk), comboBox2.SelectedItem.ToString()); // Renk

                Sekil sekil = null;

                if (secilenSekil == "Dikdörtgen")
                {
                    double en = Convert.ToDouble(textBox5.Text);
                    double genislik = Convert.ToDouble(textBox4.Text);
                    sekil = new Dikdortgen(id, ad, renk, en, genislik);
                }
                else if (secilenSekil == "Eşkenar Üçgen")
                {
                    double kenar = Convert.ToDouble(textBox3.Text);
                    sekil = new Eskenar_ucgen(id, ad, renk, kenar);
                }
                else if (secilenSekil == "Daire")
                {
                    double cap = Convert.ToDouble(textBox1.Text);
                    double aci = Convert.ToDouble(textBox2.Text);
                    sekil = new Daire(id, ad, renk, cap, aci);
                }

                alan = sekil.Alan_Hesapla();
                cevre = sekil.Cevre_Hesapla();

                label7.Text = "Alan: " + alan.ToString("F2");//alan 
                label8.Text = "Çevre: " + cevre.ToString("F2");//çevre

                // Bilgileri yazan label
                label11.Text = sekil.bilgiYazdir();
            }
            catch
            {
                MessageBox.Show("Lütfen tüm bilgileri eksiksiz ve doğru giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowShapeInputFields()
        {
            if (comboBox1.SelectedItem.ToString() == "Dikdörtgen")
            {
                textBox6.Visible = true;
                
                textBox7.Visible = true;//id
                textBox5.Visible = true; //en
                textBox4.Visible = true; //genişlik
                textBox3.Visible = false; //kenar
                textBox2.Visible = false; //açı
                textBox1.Visible = false; //çap
            }
            else if (comboBox1.SelectedItem.ToString() == "Eşkenar Üçgen")
            {

                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox5.Visible = false;
                textBox4.Visible = false;
                textBox3.Visible = true;
                textBox2.Visible = false;
                textBox1.Visible = false;
            }
            else if (comboBox1.SelectedItem.ToString() == "Daire")
            {

                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox5.Visible = false;
                textBox4.Visible = false;
                textBox3.Visible = false;
                textBox2.Visible = true;
                textBox1.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            
            label7.Text = "";
            label8.Text = "";//sonuçları temizle
            label11.Text = "";

            comboBox1.SelectedIndex = 0;
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
            {
                tabControl1.SelectedIndex = 0; // Ana ekranın açık olmalı
                //comboboca Itemstan ekledim ama buraya yazmak istersem
                //comboBox1.Items.AddRange(new string[] { "Dikdörtgen", "Eşkenar Üçgen", "Daire" });
                comboBox2.Items.AddRange(Enum.GetNames(typeof(Renk)));
                comboBox1.SelectedIndex = 0; 
                notifyIcon1.Icon = SystemIcons.Information;
                notifyIcon1.BalloonTipTitle = "Programa hoş geldiniz!";
                notifyIcon1.BalloonTipText = "Nesne Yönelimli Programlama Ödev";
                notifyIcon1.Visible = true;
                
                notifyIcon1.ShowBalloonTip(10000);
                ShowShapeInputFields();
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;  // Analiz tabına geçer
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;  // Ana ekran tabına geçer
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string secilenSekil = comboBox1.SelectedItem.ToString();
            int id = int.Parse(textBox7.Text);
            string ad = textBox6.Text; 
            Renk renk=(Renk)Enum.Parse(typeof(Renk), comboBox2.SelectedItem.ToString()); 

            Sekil sekil = null;

            try
            {
                if (secilenSekil == "Dikdörtgen")
                {
                    double en = Convert.ToDouble(textBox5.Text);
                    double genislik = Convert.ToDouble(textBox4.Text);
                    sekil = new Dikdortgen(id, ad, renk, en, genislik);
                }
                else if (secilenSekil == "Eşkenar Üçgen")
                {
                    double kenar = Convert.ToDouble(textBox3.Text);
                    sekil = new Eskenar_ucgen(id, ad, renk, kenar);
                }
                else if (secilenSekil == "Daire")
                {
                    double cap = Convert.ToDouble(textBox1.Text);
                    double aci = Convert.ToDouble(textBox2.Text);
                    sekil = new Daire(id, ad, renk, cap, aci);
                }
                if (sekil != null)
                {
                    Form2Cizim cizimForm = new Form2Cizim(sekil);
                    cizimForm.Show();
                }

            }
            catch
            {
                MessageBox.Show("Geçerli değerleri girdiğinizden emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
 }

