using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static NuoliaKaupan.Program;
using System;

namespace NuoliaKaupan
{

    public enum kärki
    {
        puu,
        teräs,
        timantti
    }

    public enum perä
    {
        lehti,
        kanansulka,
        kotkansulka
    }

    // Luokka Nuoli, joka kuvaa pelaajan valitsemaa nuolta
    public class Nuoli
    {
        // Luokkamuuttujat
        private kärki karki;
        private perä pera;
        private double varrenPituus; // Pituus senttimetreinä


        // Konstruktori
        public Nuoli(kärki karki, perä pera, double varrenPituus)
        {
            this.karki = karki;
            this.pera = pera;
            this.varrenPituus = varrenPituus;
        }

        // Metodi nuolen hinnan laskemiseksi
        public double PalautaHinta()
        {
            // Hinnat materiaaleille
            double karkinHinta = 0;
            double peranHinta = 0.0;
            double varrenHinta = 0.05 * varrenPituus;

            // Hinta kärjelle
            switch (karki)
            {
                case kärki.puu:
                    karkinHinta = 3;
                    break;
                case kärki.teräs:
                    karkinHinta = 5;
                    break;
                case kärki.timantti:
                    karkinHinta = 50;
                    break;
            }

            // Hinta perälle
            switch (pera)
            {
                case perä.lehti:
                    peranHinta = 0;
                    break;
                case perä.kanansulka:
                    peranHinta = 1;
                    break;
                case perä.kotkansulka:
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
            kärki _kärki = 0;
            perä _sulka = 0;
            kärki valittuKärki;
            perä valittuPerä;
            double varrenPituus;

            double hinta = 0;



            //Nuolen terän jutut
            while (true)
            {
                Console.WriteLine($"Minkälainen kärki?");
                Console.WriteLine("puu, teräs tai timantti");
                string KärkiMalli = Console.ReadLine();
                if (KärkiMalli == "puu" || KärkiMalli == "teräs" || KärkiMalli == "timantti")
                {
                    ValittuKarki = 
                    valittuKärki = ValittuKarki;
                    break;
                }
                else
                {
                    Console.WriteLine("Ei ole vaihtoehto, valitse uudestaan!");
                }
            }

            while (true)
            {
                //Nuolen perän metodit
                Console.WriteLine("Minkälainen perä?");
                Console.WriteLine("lehti, kanansulka tai kotkansulka");
                string SulkaMalli = Console.ReadLine();
                if (SulkaMalli == "lehti" || SulkaMalli == "kanansulka" || SulkaMalli == "kotkansulka")
                {
                    perä valittuPera = (perä)Enum.Parse(typeof(perä), Console.ReadLine());
                    valittuPerä = valittuPera;
                    break;
                }
                else
                {
                    Console.WriteLine("Ei ole vaihtoehte, valitese uudestaan");
                }

            }

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
                // Luodaan uusi Nuoli-instanssi käyttäjän valinnoilla
                Nuoli pelaajanNuoli = new Nuoli(valittuKärki, valittuPerä, pituus);

            // Näytetään nuolen hinta
            Console.WriteLine($"Nuolen hinta on {pelaajanNuoli.PalautaHinta()} kultaa.");
            }

        }
    }
}