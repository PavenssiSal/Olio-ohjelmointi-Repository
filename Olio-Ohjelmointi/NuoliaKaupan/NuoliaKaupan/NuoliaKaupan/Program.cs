using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace NuoliaKaupan
{
    internal class Program
    {
        enum kärki { 
            puu,
            teräs, 
            timantti
        }
        enum perä
        {
            lehti,
            kanansulka,
            kotkansulka
        }

        static void Main(string[] args)
        {
            kärki _kärki = 0;
            perä _sulka = 0;

            double hinta = 0;
            

                //Nuolen terän jutut
                while (true)
                {
                     Console.WriteLine($"Minkälainen kärki?");
                     Console.WriteLine("puu, teräs tai timantti");
                    string KärkiMalli = Console.ReadLine();
                    if (KärkiMalli == "puu")
                    {
                        _kärki = kärki.puu;
                        hinta += 3;
                        break;
                     }
                    else if (KärkiMalli == "teräs")
                    {
                        _kärki = kärki.teräs;
                        hinta += 5;
                        break;
                    }
                    else if (KärkiMalli == "timantti")
                    {
                        _kärki = kärki.timantti;
                        hinta += 50;
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
                if (SulkaMalli == "lehti")
                {
                    _sulka = perä.lehti;
                    break;
                }
                else if (SulkaMalli == "kanansulka")
                {
                    _sulka = perä.kanansulka;
                    hinta += 1;
                    break;
                }
                else if (SulkaMalli == "kotkansulka")
                {
                    _sulka = perä.kotkansulka;
                    hinta += 5;
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
                double pituus = Convert.ToInt32(Console.ReadLine());
                if (pituus <= 100 && pituus >= 60)
                {
                    pituus *= 0.05;
                    hinta += pituus;
                    break;
                }
                else
                {
                    Console.WriteLine("Koko ei sovi, valitse uudelleen!");
                }
            }
            Console.WriteLine($"Nuolen hinta on {hinta} kultaa");
        }
    }
}