using System;
//Idk if this is right, noi ohjeet ei tässä tehtävässä ollu selkeimmät
public struct Koordinaatti
{
    public readonly int X;
    public readonly int Y;

    public Koordinaatti(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Katotaan onko kordinaatit vierekkäin
    public bool OnVieressa(Koordinaatti toinen)
    {
        return Math.Abs(X - toinen.X) <= 1 && Math.Abs(Y - toinen.Y) <= 1;
    }

    // Tarkistetaan onko kordinaatit samassa kohassa
    public bool OnSama(Koordinaatti toinen)
    {
        return X == toinen.X && Y == toinen.Y;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tehään testi kordinaatit
        Koordinaatti koordinaatti1 = new Koordinaatti(0, 0);
        Koordinaatti koordinaatti2 = new Koordinaatti(-1, -1);
        Koordinaatti koordinaatti3 = new Koordinaatti(-1, 0);
        Koordinaatti koordinaatti4 = new Koordinaatti(-1, 1);
        Koordinaatti koordinaatti5 = new Koordinaatti(0, -1);
        Koordinaatti koordinaatti6 = new Koordinaatti(0, 0);
        Koordinaatti koordinaatti7 = new Koordinaatti(0, 1);
        Koordinaatti koordinaatti8 = new Koordinaatti(1, -1);
        Koordinaatti koordinaatti9 = new Koordinaatti(1, 0);
        Koordinaatti koordinaatti10 = new Koordinaatti(1, 1);
        Koordinaatti koordinaatti11 = new Koordinaatti(2, 2);

        // Tulostetaan kordinaatit
        TulostaTulos(koordinaatti1, koordinaatti2);
        TulostaTulos(koordinaatti1, koordinaatti3);
        TulostaTulos(koordinaatti1, koordinaatti4);
        TulostaTulos(koordinaatti1, koordinaatti5);
        TulostaTulos(koordinaatti1, koordinaatti6);
        TulostaTulos(koordinaatti1, koordinaatti7);
        TulostaTulos(koordinaatti1, koordinaatti8);
        TulostaTulos(koordinaatti1, koordinaatti9);
        TulostaTulos(koordinaatti1, koordinaatti10);
        TulostaTulos(koordinaatti1, koordinaatti11);
    }

    static void TulostaTulos(Koordinaatti ensimmainen, Koordinaatti toinen)
    {
        // Katotaan onko kordinaatit samassa kohassa
        if (toinen.OnSama(ensimmainen))
        {
            Console.WriteLine($"Annettu koordinaatti {toinen.X}, {toinen.Y} on koordinaatin {ensimmainen.X}, {ensimmainen.Y} kanssa samassa kohdassa.");
        }
        //Jos ei oo nii printataan normaali tarkistus
        else
        {
            string tulos = toinen.OnVieressa(ensimmainen) ? "vieressä" : "ei vieressä";
            Console.WriteLine($"Annettu koordinaatti {toinen.X}, {toinen.Y} on koordinaatin {ensimmainen.X}, {ensimmainen.Y} {tulos}.");
        }
    }
}
