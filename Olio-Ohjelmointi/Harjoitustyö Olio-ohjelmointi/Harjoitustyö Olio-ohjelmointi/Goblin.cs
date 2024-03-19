using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitustyö_Olio_ohjelmointi
{
    internal class Goblin : IEnemy
    {
        public void DoSpecialAttack(Knight player)
        {
            if (player.PotionCount > 0)
            {
                Console.WriteLine("The goblin stole one of your potions");
                player.PotionCount--;
            }
        }
        public void TakeDmg(Weapon weapon)
        {
            
        }
    }
}
