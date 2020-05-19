using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WyscigiKonnee
{
    class Kon
    {
        private int gdzie = 0 ;
        public string name;
        public int speed;
        public int dystans;
        public bool koniec = true;
        public int czas = 0;
        static Random rand = new Random();
        public  bool skonczyl=false;

        public int getgdzie()
        {
            return gdzie;
        }
        public Kon(string imie, int dyst)
        {
            this.name = imie;
            this.dystans = dyst;
            this.speed = PredkoncRand();
        }

        public Kon(string imie, int predkosc, int dyst)
        {
            this.name = imie;
            this.speed = predkosc;
            this.dystans = dyst;
        }

        public int PredkoncRand()
        {
            int predkosc = 0;

                
            predkosc = rand.Next(1, 10);


            return predkosc;
        }

        public void ruch()
        {
            gdzie += speed;
            Thread.Sleep(1);
        }

        public void Bieg()
        {
            Random rand = new Random();
            for (; gdzie < dystans;)
            {
                ruch();
                czas++;

                if (rand.Next(1, 200000) < 3)
                {
                    koniec = false;
                    break;
                }

            }
            if (koniec == true)
            {
                Console.WriteLine(name + " dobiegł do mety");
                skonczyl = true;
            }
            else
            {
                Console.WriteLine(name + " nie dobiegł do mety");
                czas = 99999999;
                skonczyl = true;
            }
            Wyscig.pozycja.Add(this);
            


            Wyscig.bariera.SignalAndWait();

        }

    }



}
