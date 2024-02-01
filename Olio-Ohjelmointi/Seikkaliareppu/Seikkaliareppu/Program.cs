using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
    private int maxTavaroidenMaara;
    private double maxKantoPaino;
    private double maxTilavuus;
    private int tavaroidenMaara;
    private double kokonaisPaino;
    private double kokonaisTilavuus;

    public Reppu(int maxTavaroidenMaara, double maxKantoPaino, double maxTilavuus)
    {
        this.maxTavaroidenMaara = maxTavaroidenMaara;
        this.maxKantoPaino = maxKantoPaino;
        this.maxTilavuus = maxTilavuus;
        tavarat = new Tavara[maxTavaroidenMaara];
        tavaroidenMaara = 0;
        kokonaisPaino = 0;
        kokonaisTilavuus = 0;
    }

    public bool Lisää(Tavara tavara)
    {
        if (tavaroidenMaara < maxTavaroidenMaara && kokonaisPaino + tavara.Paino <= maxKantoPaino && kokonaisTilavuus + tavara.Tilavuus <= maxTilavuus)
        {
            tavarat[tavaroidenMaara] = tavara;
            tavaroidenMaara++;
            kokonaisPaino += tavara.Paino;
            kokonaisTilavuus += tavara.Tilavuus;
            Console.WriteLine("Tavara lisätty onnistuneesti!");
            return true;
        }
        if (maxKantoPaino <= kokonaisPaino)
        {
            Console.WriteLine("Tavaran lisääminen epäonnistui. Reppu on liian painava");
            return false;
        }
        if (maxTavaroidenMaara <= tavaroidenMaara)
        {
            Console.WriteLine("Tavaran lisääminen epäonnistui. Repussa on liikaa tavaraa.");
            return false;
        }
        if (maxTilavuus <= kokonaisTilavuus)
        {
            Console.WriteLine("Tavaran lisääminen epäonnistui. Repussa ei ole tilaa");
            return false;
        }
        else
        {
            return false;
        }
    }

    public int TavaroidenMäärä
    {
        get { return tavaroidenMaara; }
    }

    public double KokonaisPaino
    {
        get { return kokonaisPaino; }
    }

    public double KokonaisTilavuus
    {
        get { return kokonaisTilavuus; }
    }
}

class Program
{
    int number;
    static void Main()
    {
        Reppu pelaajanReppu = new Reppu(10, 30, 20);

        Console.WriteLine("Tervetuloa seikkailijanreppuun!");
        Console.WriteLine("Voit lisätä eri tavaroita reppuusi.");

        while (true)
        {
            NäytäReppuTiedot(pelaajanReppu);

            Console.WriteLine();
            Console.WriteLine("Valitse tavara:");
            Console.WriteLine("1. Nuoli");
            Console.WriteLine("2. Jousi");
            Console.WriteLine("3. Köysi");
            Console.WriteLine("4. Vesi");
            Console.WriteLine("5. Ruoka-annos");
            Console.WriteLine("6. Miekka");
            Console.WriteLine("7. Poistu");
            int valinta = int.Parse(Console.ReadLine());

            bool isNumber = int.TryParse(valinta, out number);

            if (isNumber)

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
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Virheellinen valinta. Yritä uudelleen.");
                    break;
            }
        }
    }

    static void NäytäReppuTiedot(Reppu reppu)
    {
        Console.WriteLine();
        Console.WriteLine("Reppu sisältää:");
        Console.WriteLine($"Tavaroiden määrä: {reppu.TavaroidenMäärä} / 10");
        Console.WriteLine($"Kokonaispaino: {reppu.KokonaisPaino} / 30");
        Console.WriteLine($"Kokonaistilavuus: {reppu.KokonaisTilavuus} / 20");
    }
}
