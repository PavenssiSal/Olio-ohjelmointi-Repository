using System;

namespace NuoliaKaupan
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Karki valittuKarki = 0;
            Pera valittuPera = 0;
            double varrenPituus;

            // Nuolen terän jutut
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

            // Nuolen perän metodit
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

            // Luodaan uusi Nuoli-instanssi käyttäjän valinnoilla
            Nuoli pelaajanNuoli = new Nuoli(valittuKarki, valittuPera, varrenPituus);

            // Näytetään nuolen hinta
            Console.WriteLine($"Nuolen hinta on {pelaajanNuoli.PalautaHinta()} kultaa.");
        }
    }
}
