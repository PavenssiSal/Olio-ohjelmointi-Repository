using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

// Luokka hahmolle
class Knight
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public Weapon EquippedWeapon { get; set; }
    public Armor EquippedArmor { get; set; }
    public Potion EquippedPotion { get; set; }
    public int Gold { get; set; }
    public int PotionCount;
    public bool CanFight = true;

    public Knight(string name, int health, int attack, int defense, int gold)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
        Gold = gold;
        PotionCount = PotionCount;
    }


    public void AttackEnemy(Enemy enemy)
    {
        while (true)
        {
            bool IsHit = true;

        int damageDealt = Attack - enemy.Defense;
        if (damageDealt < 0)
            damageDealt = 0;
        //Juttu joka tekee sen että lohikäärmeeseen osumiseen mahdollisuudet on 50/50 jos ei käytä Bowia
        if (EquippedWeapon != null && EquippedWeapon.Name == "Axe" && enemy.Name == "Dragon" || EquippedWeapon != null && EquippedWeapon.Name == "Sword" && enemy.Name == "Dragon")
            {
                // Create an instance of Random class #Random from my good friend GPT
                Random random = new Random();

                // Generate a random number between 1 and 2
                int randomNumber = random.Next(1, 3);

                if (randomNumber == 1)
                {
                    IsHit = false;
                }
            }
        //Koodi jolla Goblin varastaa yhden pelaajan health potioneista
        if (PotionCount != 0 && enemy.Name == "Goblin")
            {
                Console.WriteLine("The Goblin stole one of your Health Potions");
                PotionCount--;
            }
        //25% mahdollisuus tehdä pelaajasta taiselukyvytön
        if (enemy.Name == "Orc")
            {                // Create an instance of Random class #Random from my good friend GPT
                Random random = new Random();

                // Generate a random number between 1 and 4
                int randomNumber = random.Next(1, 5);

                if (randomNumber == 1)
                {
                    CanFight = false;
                }

            }
        // Tarkista onko pelaajalla tietty ase ja onko vihollinen hiekkosille
        if (EquippedWeapon != null && EquippedWeapon.Name == "Bow" && enemy.Name == "Dragon")
        {
                Console.WriteLine("Weapon is very effective against the foe");
            damageDealt += 10; // Lisää 10 vahinkopistettä
        }
        if (EquippedWeapon != null && EquippedWeapon.Name == "Axe" && enemy.Name == "Orc")
        {
                Console.WriteLine("Weapon is very effective against the foe");
                damageDealt += 10; // Lisää 10 vahinkopistettä
        }
        if (EquippedWeapon != null && EquippedWeapon.Name == "Sword" && enemy.Name == "Goblin")
        {
                Console.WriteLine("Weapon is very effective against the foe");
                damageDealt += 10; // Lisää 10 vahinkopistettä
        }
        if (IsHit == true)
            {
                enemy.Health -= damageDealt;
                Console.WriteLine($"You attack the {enemy.Name} and deal {damageDealt} damage!");
                break;
            }
            else
            {
                Console.WriteLine("Your attack did not reach the dragon");
                break;
            }
        }

    }

    public void DrinkPotion()
    {
        Health += EquippedPotion.HealAmount;
        Console.WriteLine($"You drink a potion and restore {EquippedPotion.HealAmount} health!");
    }
}

// Luokka aseelle
class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Price { get; set; }

    public Weapon(string name, int damage, int price)
    {
        Name = name;
        Damage = damage;
        Price = price;
    }
}

// Luokka haarniskalle
class Armor
{
    public string Name { get; set; }
    public int Defense { get; set; }
    public int Price { get; set; }

    public Armor(string name, int defense, int price)
    {
        Name = name;
        Defense = defense;
        Price = price;
    }
}

// Luokka taikajuomalle
class Potion
{
    public string Name { get; set; }
    public int HealAmount { get; set; }
    public int Price { get; set; }

    public Potion(string name, int healAmount, int price)
    {
        Name = name;
        HealAmount = healAmount;
        Price = price;
    }
}
// Luokka kaupalle
class Shop
{
    private List<Weapon> weapons;
    private List<Armor> armors;
    private List<Potion> potions;

    public Shop()
    {
        weapons = new List<Weapon>
        {
            new Weapon("Sword", 15, 20),
            new Weapon("Axe", 20, 30),
            new Weapon("Bow", 18, 25)
        };

        armors = new List<Armor>
        {
            new Armor("Leather Armor", 5, 15),
            new Armor("Chainmail", 8, 25),
            new Armor("Plate Armor", 10, 35)
        };

        potions = new List<Potion>
        {
            new Potion("Health Potion", 20, 10),
        };
    }

    public void DisplayItems()
    {
        Console.WriteLine("Welcome to the shop! What would you like to buy?");
        Console.WriteLine("Weapons:");
        foreach (var weapon in weapons)
        {
            Console.WriteLine($"- {weapon.Name} (Damage: {weapon.Damage}, Price: {weapon.Price} gold)");
        }
        Console.WriteLine("Armors:");
        foreach (var armor in armors)
        {
            Console.WriteLine($"- {armor.Name} (Defense: {armor.Defense}, Price: {armor.Price} gold)");
        }
        Console.WriteLine("Potion:");
        foreach (var potion in potions)
        {
            Console.WriteLine($"- {potion.Name} (Heal Amount: {potion.HealAmount}, Price: {potion.Price} gold)");
        }
        Console.WriteLine("Enter 'exit' to leave the shop.");
    }

    public bool BuyItem(Knight player, string itemName)
    {
        if (itemName.ToLower() == "sword")
        {
            if (player.Gold >= 20)
            {
                player.Gold -= 20;
                player.EquippedWeapon = new Weapon("Sword", 15, 0);
                Console.WriteLine("You bought the Sword!");
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough gold to buy this item.");
                return false;
            }
        }
        else if (itemName.ToLower() == "axe")
        {
            if (player.Gold >= 30)
            {
                player.Gold -= 30;
                player.EquippedWeapon = new Weapon("Axe", 20, 0);
                Console.WriteLine("You bought the Axe!");
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough gold to buy this item.");
                return false;
            }
        }
        else if (itemName.ToLower() == "bow")
        {
            if (player.Gold >= 25)
            {
                player.Gold -= 25;
                player.EquippedWeapon = new Weapon("Bow", 18, 0);
                Console.WriteLine("You bought the Bow!");
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough gold to buy this item.");
                return false;
            }
        }
        else if (itemName.ToLower() == "leather armor")
        {
            if (player.Gold >= 15)
            {
                player.Gold -= 15;
                player.EquippedArmor = new Armor("Leather Armor", 5, 15);
                Console.WriteLine("You bought the Leather Armor!");
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough gold to buy this item.");
                return false;
            }
        }
        else if (itemName.ToLower() == "chainmail")
        {
            if (player.Gold >= 25)
            {
                player.Gold -= 25;
                player.EquippedArmor = new Armor("Chainmail", 8, 25);
                Console.WriteLine("You bought the Chainmail Armor!");
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough gold to buy this item.");
                return false;
            }
        }
        else if (itemName.ToLower() == "plate armor")
        {
            if (player.Gold >= 35)
            {
                player.Gold -= 35;
                player.EquippedArmor = new Armor("Plate Armor", 15, 35);
                Console.WriteLine("You bought the Plate Armor!");
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough gold to buy this item.");
                return false;
            }
        }

        else if (itemName.ToLower() == "health potion")
        {
            if (player.Gold >= 10)
            {
                player.Gold -= 10;
                player.EquippedPotion = new Potion("Health Potion", 20, 10);
                Console.WriteLine("You bought a Health Potion!");
                player.PotionCount++;
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough gold to buy this item.");
                return false;
            }
        }

        Console.WriteLine("That item is not available in the shop.");
        return false;
    }
}

// Luokka viholliselle
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



// Pääohjelma
class Program
{
    static void Main(string[] args)
    {
        Knight player = new Knight("Knight knightious", 100, 20, 10, 50);
        player.EquippedWeapon = new Weapon("Sword", 15, 0);
        player.EquippedArmor = new Armor("Leather Armor", 5, 0);
        player.EquippedPotion = new Potion("Health Potion", 20, 0);
        player.Gold = 0;
        player.PotionCount = 1;

        Enemy[] enemies = {
            new Enemy("Goblin", 20, 30, 10),
            new Enemy("Orc", 75, 15, 10),
            new Enemy("Dragon", 100, 25, 15)
        };

        Shop shop = new Shop();

        Console.WriteLine("Welcome, brave knight! Let the adventure begin!");

        while (player.Health > 0)
        {


            //UI               
            Console.WriteLine("---------------");
            Console.WriteLine("HP: " + player.Health);
            Console.WriteLine("Gold: " + player.Gold);
            Console.WriteLine("Weapon: " + player.EquippedWeapon.Name);
            Console.WriteLine("Armor: " + player.EquippedArmor.Name);
            Console.WriteLine("Health potions remaining: " + player.PotionCount);
            Console.WriteLine("---------------");
            Console.WriteLine("1. Fight an enemy");
            Console.WriteLine("2. Visit the shop");
            Console.WriteLine("3. Quit");



            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("---------------");
                Enemy enemy = enemies[new Random().Next(0, enemies.Length)];
                Console.WriteLine("You encounter a " + enemy.Name + "!");

                // Palauta vihollisen terveys alkuperäiseksi ennen uutta taistelua
                int originalEnemyHealth = enemy.Health;

                while (player.Health > 0 && enemy.Health > 0)
                {
                    if (player.CanFight == true)
                    {
                        Console.WriteLine(player.Name + " - Health: " + player.Health + " | Enemy - Health: " + enemy.Health);
                        Console.WriteLine("1. Attack");
                        Console.WriteLine("2. Drink Potion");
                        Console.WriteLine("---------------");

                        //Please dont f**k up the game and just do as told
                        int action = Convert.ToInt32(Console.ReadLine());

                        if (action == 1)
                        {
                            player.AttackEnemy(enemy);
                            if (enemy.Health > 0)
                                enemy.AttackKnight(player);
                            if (player.CanFight == false)
                            {
                                Console.WriteLine("The Orc immobilised you for a turn");
                            }
                            Console.WriteLine("---------------");
                        }
                        else if (action == 2 && player.PotionCount > 0)
                        {
                            player.DrinkPotion();
                            player.PotionCount--;
                            enemy.AttackKnight(player);
                            Console.WriteLine("---------------");
                        }
                        else
                        {
                            Console.WriteLine("Command failed");
                        }

                        if (player.Health <= 0)
                        {
                            Console.WriteLine("You have been defeated!");
                            break;
                        }
                        else if (enemy.Health <= 0)
                        {
                            int goldEarned = new Random().Next(10, 30);
                            player.Gold += goldEarned;
                            Console.WriteLine("You have defeated the " + enemy.Name + " and earned " + goldEarned + " gold!");
                            break;
                        }
                    }
                    if (player.CanFight == false)
                    {
                        Console.WriteLine("You are unable to move this turn");
                        enemy.AttackKnight(player);
                        player.CanFight = true;
                    }
                }
                    
                // Palauta vihollisen terveys alkuperäiseksi
                enemy.Health = originalEnemyHealth;
            }
            else if (choice == 2)
            {
                shop.DisplayItems();
                Console.WriteLine("Enter the name of the item you want to buy:");
                string itemName = Console.ReadLine();
                if (itemName.ToLower() == "exit")
                {
                    Console.WriteLine("You leave the shop.");
                }
                else
                {
                    shop.BuyItem(player, itemName);
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("Thank you for playing!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
        Console.WriteLine("Game over");
    }
}
