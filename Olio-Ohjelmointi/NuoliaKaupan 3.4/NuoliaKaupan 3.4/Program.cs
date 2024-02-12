using System;

namespace NuoliaKaupan_3._4
{
    public enum Karki
    {
        Puu,
        Teräs,
        Timantti
    }

    public enum Pera
    {
        Lehti,
        Kanansulka,
        Kotkansulka
    }

    // Luokka Nuoli, joka kuvaa pelaajan valitsemaa nuolta
    public class Nuoli
    {
        // Ominaisuudet
        public Karki Karki { get; private set; }
        public Pera Pera { get; private set; }
        public double VarrenPituus { get; private set; } // Pituus senttimetreinä

        // Konstruktori
        public Nuoli(Karki karki, Pera pera, double varrenPituus)
        {
            Karki = karki;
            Pera = pera;
            VarrenPituus = varrenPituus;
        }

        // Metodi nuolen hinnan laskemiseksi
        public double PalautaHinta()
        {
            // Hinnat materiaaleille
            double karkinHinta = 0;
            double peranHinta = 0.0;
            double varrenHinta = 0.05 * VarrenPituus;

            // Hinta kärjelle
            switch (Karki)
            {
                case Karki.Puu:
                    karkinHinta = 3;
                    break;
                case Karki.Teräs:
                    karkinHinta = 5;
                    break;
                case Karki.Timantti:
                    karkinHinta = 50;
                    break;
            }

            // Hinta perälle
            switch (Pera)
            {
                case Pera.Lehti:
                    peranHinta = 0;
                    break;
                case Pera.Kanansulka:
                    peranHinta = 1;
                    break;
                case Pera.Kotkansulka:
                    peranHinta = 5;
                    break;
            }

            // Yhteishinta
            return karkinHinta + peranHinta + varrenHinta;
        }

        // Staattiset metodit nuolien luomiseksi valmiista pohjista
        public static Nuoli LuoEliittiNuoli()
        {
            return new Nuoli(Karki.Timantti, Pera.Kotkansulka, 100);
        }

        public static Nuoli LuoAloittelijanuoli()
        {
            return new Nuoli(Karki.Puu, Pera.Kanansulka, 70);
        }

        public static Nuoli LuoPerusnuoli()
        {
            return new Nuoli(Karki.Teräs, Pera.Kanansulka, 85);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Valitse nuolen tyyppi:");
            Console.WriteLine("1. Eliittinuoli");
            Console.WriteLine("2. Aloittelijanuoli");
            Console.WriteLine("3. Perusnuoli");
            Console.WriteLine("4. Luo oma nuoli");

            int valinta = Convert.ToInt32(Console.ReadLine());

            Nuoli pelaajanNuoli;

            while (true) 
            {
                if (valinta == 1)
                {
                    pelaajanNuoli = Nuoli.LuoEliittiNuoli();
                    break;
                }
                else if (valinta == 2)
                {
                    pelaajanNuoli = Nuoli.LuoAloittelijanuoli();
                    break;
                }
                else if (valinta == 3)
                {
                    pelaajanNuoli = Nuoli.LuoPerusnuoli();
                    break;
                }
                else if (valinta == 4)
                {
                    pelaajanNuoli = LuoOmaNuoli();
                    break;
                }
                else
                {
                    Console.WriteLine("Virheellinen valinta. Why you do this?");
                    System.Environment.Exit(1);
                }
            }

            

            // Näytetään nuolen hinta
            Console.WriteLine($"Nuolen hinta on {pelaajanNuoli.PalautaHinta()} kultaa.");
        }

        // Metodi oman nuolen luomiseksi
        static Nuoli LuoOmaNuoli()
        {
            Karki valittuKarki = 0;
            Pera valittuPera = 0;
            double varrenPituus;

            // Nuolen terän valinta
            while (true)
            {
                Console.WriteLine("Minkälainen kärki?");
                Console.WriteLine("puu, teräs tai timantti");
                string karkiMalli = Console.ReadLine();
                if (karkiMalli == "puu" || karkiMalli == "teräs" || karkiMalli == "timantti")
                {
                    valittuKarki = (Karki)Enum.Parse(typeof(Karki), karkiMalli, true);
                    break;
                }
                else
                {
                    Console.WriteLine("Ei ole vaihtoehto, valitse uudestaan!");
                }
            }

            // Nuolen perän valinta
            while (true)
            {
                Console.WriteLine("Minkälainen perä?");
                Console.WriteLine("lehti, kanansulka tai kotkansulka");
                string peraMalli = Console.ReadLine();
                if (peraMalli == "lehti" || peraMalli == "kanansulka" || peraMalli == "kotkansulka")
                {
                    valittuPera = (Pera)Enum.Parse(typeof(Pera), peraMalli, true);
                    break;
                }
                else
                {
                    Console.WriteLine("Ei ole vaihtoehte, valitese uudestaan");
                }
            }

            // Kysytään varren pituus
            while (true)
            {
                Console.WriteLine("Kuinka pitkä? (60-100)");
                double pituus = Convert.ToDouble(Console.ReadLine());
                if (pituus <= 100 && pituus >= 60)
                {
                    varrenPituus = pituus;
                    break;
                }
                else
                {
                    Console.WriteLine("Koko ei sovi, valitse uudelleen!");
                }
            }

            // Palautetaan uusi Nuoli-instanssi käyttäjän valinnoilla
            return new Nuoli(valittuKarki, valittuPera, varrenPituus);
        }
    }
}
