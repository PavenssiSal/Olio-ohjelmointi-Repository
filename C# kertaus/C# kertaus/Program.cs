namespace C__kertaus
{
    using System;

    namespace Testgame
    {
        class program
        {
            static void Main(string[] args)
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Olet ritari, jonk tehtävänä on tappaa ilkeä örkki, joka on aiheuttanut kaaosta läheisessä kylässä.");
                Console.ResetColor();

                //Hahmojen elämät
                int Ritari = 15;
                int Örkki = 15;

                //Toistaa tämän muuttujan jos hahmoilla on enemmän kuin 1 elämä
                while (Ritari > 0 && Örkki > 0) 
                {
                    Console.WriteLine("--------------------");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Ritari (Sinä): {Ritari}/15 Örkki: {Örkki}/15");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"1 - Hyökkää miekalla");
                    Console.WriteLine($"2 - Puollustaudu kilvellä");
                    Console.ResetColor();

                    //Kysyy pelaajalta mitä tämä tahtoo tehdä
                    Console.WriteLine("Mitä teet? ");
                    int Position = int.Parse(Console.ReadLine());

                    //Jos pelaaja valitsee 1, tämä toistetaan
                    if (Position == 1) 
                    {
                        //Luodaan uusi random elementti
                        Random random = new Random();

                        int hyökkäys = random.Next(1, 6);

                        //Pelaaja hyökkää
                        Console.ForegroundColor= ConsoleColor.Blue;
                        Console.WriteLine($"Hyökkäät miekallasi!");
                        Örkki -= hyökkäys;
                        Console.WriteLine($"Osuit! Teet miekallasi {hyökkäys} vahinkoa!");
                        Console.ResetColor();

                        //Luodaan uusi random elementti
                        int vahinko = random.Next(1, 6);

                        //Örkki hyökkää
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Örkki hyökkää kimpuusi nuijallaan ja osuu!");
                        Console.WriteLine($"Örkki tekee {vahinko} vahinkoa");
                        Ritari -= vahinko;
                        Console.ResetColor();
                    }
                    else if (Position == 2)
                    {
                        //Luodaan uusi random elementti
                        Random random = new Random();

                        int vahinko = random.Next(1, 4) /2;

                        //Tehdään puollustus
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Nostat kilpesi puollustukseen");
                        Console.ResetColor();

                        //Tehdään örkin hyökkäys
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Örkki hyökkää kimppuusi nuijallaan ja osuu kilpeesi.");
                        Console.WriteLine($"Tehden {vahinko} vahinkoa");
                        Ritari -= vahinko;
                        Console.ResetColor();
                    }
                    else
                    {

                    }
                }

                //Jos ritarin elämät on vähemmän kuin 1, peli on hävitty
                if (Ritari < 1 && Örkki > 0)
                {
                    //Lopputekstit jos örkki voittaa
                    Console.WriteLine("--------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Örkki päihitti ritarin.");
                    Console.WriteLine($"Örkille jäi {Örkki} elämää jäljelle.");
                    Console.ResetColor();
                }
                //Jos örkin elämät on vähemmän kuin 1, peli on voitettu
                else if (Örkki < 1 && Ritari > 0)
                {
                    Console.WriteLine("--------------------");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Päihitit örkin.");
                    Console.WriteLine($"Sinulle jäi {Ritari} elämää jäljelle.");
                    Console.ResetColor();
                }
                else 
                {
                    Console.WriteLine("--------------------");
                    Console.ForegroundColor= ConsoleColor.DarkRed;
                    Console.WriteLine("Örkki ja ritari tappavat toisensa samaan aikaan");
                    Console.ForegroundColor= ConsoleColor.DarkBlue;
                    Console.WriteLine("Tasapeli");
                    Console.ResetColor();

                }

            }
        }
    }

}