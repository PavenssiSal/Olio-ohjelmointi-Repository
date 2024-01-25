namespace Ruokatiski
{
    internal class Program
    {
        enum pääaine { nautaa, kanaa, kasviksia }
        enum lisuke { riisi, peruna, pasta }
        enum kastike { curry, hapanimelä, pippuri, chili }


        public struct RuokaAnnos
        {
            public string Pääraakaaine;
            public string Liusuke;
            public string Sauce;

            public RuokaAnnos(string pääraakaaine, string Lisuke, string Kastike, int v)
            {
                Pääraakaaine = pääraakaaine;
                Liusuke = Lisuke;
                Sauce = Kastike;
            }
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Pääaine (nautaa, kanaa, kasviksia)");
            string pääaine = Console.ReadLine();
            Console.WriteLine("Lisuke (riisi, peruna, pasta)");
            string lisuke = Console.ReadLine();
            Console.WriteLine("Kastike (curry, hapanimelä, pippuri, chili");
            string sauce = Console.ReadLine();

            RuokaAnnos[] ruokaAnnos = new RuokaAnnos[2];
            ruokaAnnos[0] = new RuokaAnnos();

            RuokaAnnos[] tyontekijat = new RuokaAnnos[2];
            tyontekijat[0] = new RuokaAnnos("Suvi", "ohjelmoija", "Yees", 20);

            Console.WriteLine(ruokaAnnos);
        }
    }
}