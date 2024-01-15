using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ovi
{
  
    enum OvenMuodot { Auki, Kiinni, Lukossa};

    internal class Ovi
    {
        static void Main(string[] args)
        {
            OvenMuodot tila = OvenMuodot.Auki;

            while (true)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine($"Ovi on {tila}!");
                Console.WriteLine("Mitä haluat tehdä?");
                Console.WriteLine("Sulje, Lukitse, Avaa tai Avaa lukko");
                string toiminto = Console.ReadLine();

                if (toiminto == "Sulje" && tila == OvenMuodot.Auki)
                {
                    tila = OvenMuodot.Kiinni;
                }
                else if (toiminto == "Lukitse" && tila == OvenMuodot.Kiinni) 
                {
                    tila = OvenMuodot.Lukossa;
                }
                else if(toiminto == "Avaa" && tila == OvenMuodot.Kiinni)
                {
                    tila = OvenMuodot.Auki;
                }
                else if (toiminto == "Avaa lukko" && tila == OvenMuodot.Lukossa)
                {
                    tila = OvenMuodot.Kiinni;
                }
                else
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Ei käy, valitse uudelleen!");
                }
            }

        }
    }
}