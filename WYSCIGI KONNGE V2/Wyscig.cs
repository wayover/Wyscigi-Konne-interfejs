using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WyscigiKonnee
{
    class Wyscig
    {
        public static int dlugosc=50000;
        public static Kon[] konie = new Kon[5];
        public static List<Kon> pozycja = new List<Kon>();
        public static Barrier bariera = new Barrier(1);

        public Wyscig()
        {
        }


        public void WyscigStart()
        {
            pozycja.Clear();
            for (int i =konie.Length-5; i < konie.Length; i++)
            {
                lock (bariera)
                {
                    bariera.AddParticipant();
                }

                konie[i] = new Kon("Kon " + (i + 1-konie.Length+5), dlugosc);
                Thread t = new Thread(konie[i].Bieg);
                t.Start();


            }

            bariera.SignalAndWait();









            pozycja.Sort((kon1, kon2) => { return kon1.czas.CompareTo(kon2.czas); });
           // Wypisz();








        }




        public static string Wypisz()
        {
            string txt="";
            // Console.WriteLine("\n\n Tabela końcowa");
            txt+=" Tabela końcowa\n";
            for (int i = 0; i < pozycja.Count; i++)
            {
                if (pozycja[i].koniec == true)
                {
                   // Console.WriteLine("Pozycja " + (i + 1) + " " + pozycja[i].name+"   "+pozycja[i].speed);
                    txt+="Pozycja " + (i + 1) + " " + pozycja[i].name;
                    txt+='\n';
                }
                else
                {
                  // Console.WriteLine(pozycja[i].name + " nie dojechał do mety :(");
                   txt+= pozycja[i].name + " nie dojechał do mety :(";
                   txt += '\n';
                }

            }
            return txt;
        }

    }
}
