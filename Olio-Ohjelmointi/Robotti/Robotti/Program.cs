using System;

namespace Robotti
{

    public class Program
    {
        static void Main(string[] args)
        {
            Robotti rob = new Robotti();

            Console.WriteLine("Mitä komentoja syötetään robotille? Vaihtoehdot: Käynnistä, Sammuta, Vasemmalle," +
            " Oikealle, Alas, Ylös");
            string vastaus = Console.ReadLine();
            if (vastaus == "Käynnistä")
            {
                rob.AnnaKäsky(new Käynnistä());
            }
            if (vastaus == "Sammuta")
            {
                rob.AnnaKäsky(new Sammuta());
            }

            rob.Suorita();


        }
    }
    public class Käynnistä : RobottiKäsky
    {
        public override void Suorita(Robotti toimija)
        {
            toimija.OnKäynnissä = true;
        }
    }
    public class Sammuta : RobottiKäsky
    {
        public override void Suorita(Robotti toimija)
        {
            toimija.OnKäynnissä = false;
        }
    }

    public class Robotti
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool OnKäynnissä { get; set; }

        // Taulukko kannattaa olla private, muuten
        // voi helposti tulla lukeminen tai kirjoitus sen
        // ulkopuolelle
        private RobottiKäsky?[] Käskyt;

        public Robotti()
        {
            Käskyt = new RobottiKäsky[3];
        }

        // Palauttaa true jos käskyn antaminen onnistui
        // Palauttaa false, jos Käskyt taulukko on jo täynnä
        public bool AnnaKäsky(RobottiKäsky käsky)
        {
            // Onko tilaa uudelle käskylle?
            for (int i = 0; i < Käskyt.Length; i++)
            {
                // Onko tässä vapaa kohta?
                if (Käskyt[i] == null)
                {
                    // Käskyn antaminen onnistui
                    Käskyt[i] = käsky;
                    return true;
                }
            }
            // Käskyn antaminen ei onnistunut
            return false;
        }

        public void Suorita()
        {
            foreach (RobottiKäsky? käsky in Käskyt)
            {
                käsky?.Suorita(this);
                Console.WriteLine($"[{X} {Y} {OnKäynnissä}]");
            }
        }
    }
}
