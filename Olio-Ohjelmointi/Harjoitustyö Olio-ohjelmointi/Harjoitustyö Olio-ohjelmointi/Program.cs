using System;
using System.Collections.Generic;

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

    public Knight(string name, int health, int attack, int defense, int gold)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
        Gold = gold;
    }

    public void AttackEnemy(Enemy enemy)
    {
        int damageDealt = Attack - enemy.Defense;
        if (damageDealt < 0)
            damageDealt = 0;

        // Tarkista onko pelaajalla erityinen ase ja onko vihollinen tietty tyyppi
        if (EquippedWeapon != null && EquippedWeapon.Name == "Bow" && enemy.Name == "Dragon")
        {
            damageDealt += 10; // Lisää 10 vahinkopistettä
        }

        enemy.Health -= damageDealt;
        Console.WriteLine($"You attack the {enemy.Name} and deal {damageDealt} damage!");
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
        Console.WriteLine("Potions:");
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

        foreach (var armor in armors)
        {
            if (armor.Name.ToLower() == itemName.ToLower())
            {
                if (player.Gold >= armor.Price)
                {
                    player.Gold -= armor.Price;
                    Console.WriteLine($"You bought the {armor.Name}!");
                    return true;
                }
                else
                {
                    Console.WriteLine("You don't have enough gold to buy this item.");
                    return false;
                }
            }
        }

        foreach (var potion in potions)
        {
            if (potion.Name.ToLower() == itemName.ToLower())
            {
                if (player.Gold >= potion.Price)
                {
                    player.Gold -= potion.Price;
                    Console.WriteLine($"You bought the {potion.Name}!");
                    return true;
                }
                else
                {
                    Console.WriteLine("You don't have enough gold to buy this item.");
                    return false;
                }
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
        int damageDealt = Attack - knight.Defense;
        if (damageDealt < 0)
            damageDealt = 0;

        knight.Health -= damageDealt;
        Console.WriteLine($"The {Name} attacks you and deals {damageDealt} damage!");
    }
}



// Pääohjelma
class Program
{
    static void Main(string[] args)
    {
        Knight player = new Knight("Sir Knight", 100, 20, 10, 50);
        player.EquippedWeapon = new Weapon("Sword", 15, 0);
        player.EquippedArmor = new Armor("Plate Armor", 10, 0);
        player.EquippedPotion = new Potion("Health Potion", 20, 0);

        Enemy[] enemies = {
            new Enemy("Goblin", 50, 10, 5),
            new Enemy("Orc", 20, 15, 8),
            new Enemy("Dragon", 20, 25, 15)
        };

        Shop shop = new Shop();

        Console.WriteLine("Welcome, brave knight! Let the adventure begin!");

        while (true)
        {

            Console.WriteLine("\n1. Fight an enemy");
            Console.WriteLine("2. Visit the shop");
            Console.WriteLine("3. Quit");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Enemy enemy = enemies[new Random().Next(0, enemies.Length)];
                Console.WriteLine($"\nYou encounter a {enemy.Name}!");

                // Palauta vihollisen terveys alkuperäiseksi ennen uutta taistelua
                int originalEnemyHealth = enemy.Health;

                while (player.Health > 0 && enemy.Health > 0)
                {
                    Console.WriteLine($"\n{player.Name} - Health: {player.Health} | Enemy - Health: {enemy.Health}");
                    Console.WriteLine("\n1. Attack");
                    Console.WriteLine("2. Drink Potion");

                    int action = Convert.ToInt32(Console.ReadLine());

                    if (action == 1)
                    {
                        player.AttackEnemy(enemy);
                        if (enemy.Health > 0)
                            enemy.AttackKnight(player);
                    }
                    else if (action == 2)
                    {
                        player.DrinkPotion();
                        enemy.AttackKnight(player);
                    }

                    if (player.Health <= 0)
                    {
                        Console.WriteLine("\nYou have been defeated! Game over.");
                        break;
                    }
                    else if (enemy.Health <= 0)
                    {
                        int goldEarned = new Random().Next(10, 30);
                        player.Gold += goldEarned;
                        Console.WriteLine($"\nYou have defeated the {enemy.Name} and earned {goldEarned} gold!");
                        break;
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
                Console.WriteLine("\nThank you for playing!");
                break;
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please try again.");
            }
        }
    }
}
