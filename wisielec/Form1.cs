using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wisielec
{
    public partial class Form1 : Form
    {
        string slowo;
        int ilosc_pudel = 0;
        public Form1()
        {
            InitializeComponent();
            losuj_slowo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ilosc_pudel < 5)
            {
                string litera = textBox1.Text;
                bool czy_trafiony = false;
                int gdzie_trafiony = 0;
                for (int i = 1; i < 6; i++)
                {
                    if (Convert.ToString(slowo[i]) == litera)
                    {
                        czy_trafiony = true;
                        gdzie_trafiony = i;
                    }
                    if (gdzie_trafiony == 1) { label2.Text = litera; }
                    if (gdzie_trafiony == 2) { label3.Text = litera; }
                    if (gdzie_trafiony == 3) { label4.Text = litera; }
                    if (gdzie_trafiony == 4) { label5.Text = litera; }
                    if (gdzie_trafiony == 5) { label6.Text = litera; }
                }
                if (czy_trafiony == false)
                {
                    ilosc_pudel = ilosc_pudel + 1;
                    if (ilosc_pudel == 1) { pictureBox1.Image = wisielec.Properties.Resources.wisielec1; }
                    if (ilosc_pudel == 2) { pictureBox1.Image = wisielec.Properties.Resources.wisielec2; }
                    if (ilosc_pudel == 3) { pictureBox1.Image = wisielec.Properties.Resources.wisielec3; }
                    if (ilosc_pudel == 4) { pictureBox1.Image = wisielec.Properties.Resources.wisielec4; }
                    if (ilosc_pudel == 5) { pictureBox1.Image = wisielec.Properties.Resources.wisielec5; }
                }
                wygrana();
            }
            else
            {
                pictureBox1.Image = wisielec.Properties.Resources.przegrana;
                button2.Visible = true;
            }
        }
        private void losuj_slowo()
        {
            string[] slowa = { "krokusy", "liliput", "marchew", "selerek", "krakers", "klakier" };
            int ile_slow = slowa.Length;
            Random gen = new Random();
            int indeks_slow = gen.Next(0, ile_slow);
            slowo = slowa[indeks_slow];
            label1.Text = Convert.ToString(slowo[0]);
            label7.Text = Convert.ToString(slowo[6]);
        }
        private void wygrana()
        {
            if (label2.Text != "_")
            {
                if (label3.Text != "_")
                {
                    if (label4.Text != "_")
                    {
                        if (label5.Text != "_")
                        {
                            if (label6.Text != "_")
                            {
                                pictureBox1.Image = wisielec.Properties.Resources.wygrana;
                                button2.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            losuj_slowo();
            ilosc_pudel = 0;
            label2.Text = "_";
            label3.Text = "_";
            label4.Text = "_";
            label5.Text = "_";
            label6.Text = "_";
            button2.Visible = false;
            pictureBox1.Image = null;
        }
    }
}
