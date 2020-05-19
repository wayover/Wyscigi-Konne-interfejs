using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WyscigiKonnee;

namespace WYSCIGI_KONNGE_V2
{
    public partial class Form1 : Form
    {
        ProgressBar[] progressBars = new ProgressBar[5];




        public Form1()
        { 

        InitializeComponent();
            

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            progressBars[0] = progressBar1;
            progressBars[1] = progressBar2;
            progressBars[2] = progressBar3;
            progressBars[3] = progressBar4;
            progressBars[4] = progressBar5;

            for (int i = 0; i < 5; i++)
            {
                progressBars[i].Maximum = Wyscig.dlugosc;
            }

            richTextBox1.Text = "";
            Wyscig wyscig = new Wyscig();


            timer1.Enabled = true;
            Thread t = new Thread(wyscig.WyscigStart);
            t.Start();

        }

        
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int d = 0;
            int b = 0;
            for (int i = 0; i <Wyscig.konie.Length; ++i)
            {
                int a= Wyscig.konie[i].getgdzie();

                if (a <= progressBars[i].Maximum)
                {
                  
                       progressBars[i].Value = Wyscig.konie[i].getgdzie();
                 
                }
                else
                {
                     progressBars[i].Value = progressBars[i].Maximum;
                }
                if (Wyscig.konie[i].skonczyl == true)
                {
                    d++;
                }
            }

            if (d == 5&&b==0)
            {
                richTextBox1.Text = Wyscig.Wypisz();
                    b = 1;
            }


        }

        public static void koniec()
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}