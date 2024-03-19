using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitustyö_Olio_ohjelmointi
{
    //Rajapinta kaikille vihollisille
    internal interface IEnemy
    {
        public abstract void DoSpecialAttack (Knight player);

        public abstract void TakeDmg(Weapon weapon);

        class Enemy
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public int Attack { get; set; }
            public int Defense { get; set; }

            public Enemy(string name, int health, int attack, int defense)
            {
                Name = name;
                Health = health;
                Attack = attack;
                Defense = defense;
            }

            public void AttackKnight(Knight knight)
            {
                int damageDealt = Attack;
                if (damageDealt < 0)
                    damageDealt = 0;

                if (knight.EquippedArmor != null)
                {
                    damageDealt -= knight.EquippedArmor.Defense;
                    if (damageDealt < 0)
                        damageDealt = 0;
                }

                knight.Health -= damageDealt;
                Console.WriteLine($"The {Name} attacks you and deals {damageDealt} damage!");
            }
        }
    }
}
