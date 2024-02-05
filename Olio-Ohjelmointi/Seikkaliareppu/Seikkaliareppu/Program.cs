using System;
using System.Linq;

class Tavara
{
    public double Paino { get; }
    public double Tilavuus { get; }

    public Tavara(double paino, double tilavuus)
    {
        Paino = paino;
        Tilavuus = tilavuus;
    }
}

class Nuoli : Tavara
{
    public Nuoli() : base(0.1, 0.05) { }
}

class Jousi : Tavara
{
    public Jousi() : base(1, 4) { }
}

class Köysi : Tavara
{
    public Köysi() : base(1, 1.5) { }
}

class Vesi : Tavara
{
    public Vesi() : base(2, 2) { }
}

class RuokaAnnos : Tavara
{
    public RuokaAnnos() : base(1, 0.5) { }
}

class Miekka : Tavara
{
    public Miekka() : base(5, 3) { }
}

class Reppu
{
    private Tavara[] tavarat;
    private int maksimiTavaroidenMäärä;
    private double maksimiKantoPaino;
    private double maksimiTilavuus;

    public Reppu(int maksimiTavaroidenMäärä, double maksimiKantoPaino, double maksimiTilavuus)
    {
        this.maksimiTavaroidenMäärä = maksimiTavaroidenMäärä;
        this.maksimiKantoPaino = maksimiKantoPaino;
        this.maksimiTilavuus = maksimiTilavuus;
        tavarat = new Tavara[maksimiTavaroidenMäärä];
    }

    public int TavaraMäärä => tavarat.Count(t => t != null);
    public double TavaroidenPaino => tavarat.Where(t => t != null).Sum(t => t.Paino);
    public double TavaroidenTilavuus => tavarat.Where(t => t != null).Sum(t => t.Tilavuus);
    public double JäljelläKantoPaino => maksimiKantoPaino - TavaroidenPaino;
    public double JäljelläTilavuus => maksimiTilavuus - TavaroidenTilavuus;

    public bool Lisää(Tavara tavara)
    {
        if (TavaraMäärä < maksimiTavaroidenMäärä && TavaroidenPaino + tavara.Paino <= maksimiKantoPaino && TavaroidenTilavuus + tavara.Tilavuus <= maksimiTilavuus)
        {
            for (int i = 0; i < maksimiTavaroidenMäärä; i++)
            {
                if (tavarat[i] == null)
                {
                    tavarat[i] = tavara;
                    return true;
                }
            }
        }
        else
        {
            Console.WriteLine($"Tavaran lisääminen epäonnistui. {MiksiEiPysty(tavara)}");
        }
        return false;
    }

    private string MiksiEiPysty(Tavara tavara)
    {
        if (TavaraMäärä >= maksimiTavaroidenMäärä)
        {
            return "Reppussa on liikaa tavaraa.";
        }
        else if (TavaroidenPaino + tavara.Paino > maksimiKantoPaino)
        {
            return "Reppu on liian painava.";
        }
        else if (TavaroidenTilavuus + tavara.Tilavuus > maksimiTilavuus)
        {
            return "Reppu on liian täynnä tilavuudeltaan.";
        }
        else
        {
            return "U broke it, why and how";
        }
    }
}

class Program
{
    static void Main()
    {
        Reppu pelaajanReppu = new Reppu(maksimiTavaroidenMäärä: 10, maksimiKantoPaino: 30, maksimiTilavuus: 20);

        Console.WriteLine("Tervetuloa pelaaja! Voit lisätä tavaroita repun avulla.");

        while (true)
        {
            Console.WriteLine("\nValitse tavara:");
            Console.WriteLine("1. Nuoli");
            Console.WriteLine("2. Jousi");
            Console.WriteLine("3. Köysi");
            Console.WriteLine("4. Vesi");
            Console.WriteLine("5. Ruoka-annos");
            Console.WriteLine("6. Miekka");

            int valinta;
            if (int.TryParse(Console.ReadLine(), out valinta))
            {
                switch (valinta)
                {
                    case 1:
                        pelaajanReppu.Lisää(new Nuoli());
                        break;
                    case 2:
                        pelaajanReppu.Lisää(new Jousi());
                        break;
                    case 3:
                        pelaajanReppu.Lisää(new Köysi());
                        break;
                    case 4:
                        pelaajanReppu.Lisää(new Vesi());
                        break;
                    case 5:
                        pelaajanReppu.Lisää(new RuokaAnnos());
                        break;
                    case 6:
                        pelaajanReppu.Lisää(new Miekka());
                        break;
                    default:
                        Console.WriteLine("Virheellinen valinta. Yritä uudelleen.");
                        break;
                }

                Console.WriteLine($"\nReppu sisältää nyt {pelaajanReppu.TavaraMäärä} / 10 tavaraa, paino {pelaajanReppu.TavaroidenPaino} / 30, tilavuus {pelaajanReppu.TavaroidenTilavuus} / 20");

            }
            else
            {
                Console.WriteLine("Virheellinen syöte. Yritä uudelleen.");
            }
        }
    }
}
