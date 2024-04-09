using System;
using System.Collections.Generic;

// Luokka esineelle
class Item
{
    public string Name { get; set; }
    public int Cost { get; set; }

    public Item(string name, int cost)
    {
        Name = name;
        Cost = cost;
    }
}

// Luokka aseelle, joka perii Esine-luokan
class Weapon : Item
{
    public int Damage { get; set; }

    public Weapon(string name, int damage, int cost) : base(name, cost)
    {
        Damage = damage;
    }
}

// Luokka haarniskalle, joka perii Esine-luokan
class Armor : Item
{
    public int Defense { get; set; }

    public Armor(string name, int defense, int cost) : base(name, cost)
    {
        Defense = defense;
    }
}

// Luokka taikajuomalle, joka perii Esine-luokan
class Potion : Item
{
    public int HealAmount { get; set; }

    public Potion(string name, int healAmount, int cost) : base(name, cost)
    {
        HealAmount = healAmount;
    }
}

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
    public int PotionCount { get; set; }
    public bool CanFight { get; set; }

    public Knight(string name, int health, int attack, int defense, int gold)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
        Gold = gold;
        PotionCount = 0;
        CanFight = true;
    }

    public void AttackEnemy(Enemy enemy)
    {
        // Tässä toteutetaan hyökkäyslogiikka

        {
            while (true)
            {
                bool IsHit = true;
                int damageDealt = Attack + EquippedWeapon.Damage - enemy.Defense;
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
    }

    public void DrinkPotion()
    {
        Health += EquippedPotion.HealAmount;
        Console.WriteLine($"You drink a potion and restore {EquippedPotion.HealAmount} health!");
        // Tässä toteutetaan juoman juonti
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
        // Tässä toteutetaan vihollisen hyökkäys
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

// Kaupan rajapinta
interface IShop
{
    void DisplayItems();
    bool BuyItem(Knight player, string itemName);
}

// Luokka kaupalle, joka toteuttaa IShop-rajapinnan
class Shop : IShop
{
    private List<Item> items;

    public Shop()
    {
        items = new List<Item>
        {
            new Weapon("Sword", 15, 20),
            new Weapon("Axe", 20, 30),
            new Weapon("Bow", 18, 25),
            new Armor("Leather Armor", 5, 15),
            new Armor("Chainmail", 8, 25),
            new Armor("Plate Armor", 10, 35),
            new Potion("Health Potion", 20, 10),
        };
    }

    public void DisplayItems()
    {
        // Tässä näytetään kaupan esineet
        Console.WriteLine("Welcome to the shop! What would you like to buy?");
        Console.WriteLine("Weapons:");
        //ChatGPT teki nää foreach jutut. Pienintäkää ideaa enää miten tää toimi mut it works
        foreach (var weapon in items.OfType<Weapon>())
        {
            Console.WriteLine($"- {weapon.Name} (Damage: {weapon.Damage}, Price: {weapon.Cost} gold)");
        }
        Console.WriteLine("Armors:");
        foreach (var armor in items.OfType<Armor>())
        {
            Console.WriteLine($"- {armor.Name} (Defense: {armor.Defense}, Price: {armor.Cost} gold)");
        }
        Console.WriteLine("Potion:");
        foreach (var potion in items.OfType<Potion>())
        {
            Console.WriteLine($"- {potion.Name} (Heal Amount: {potion.HealAmount}, Price: {potion.Cost} gold)");
        }
        Console.WriteLine("'Enter' to leave the shop.");
    }

    public bool BuyItem(Knight player, string itemName)
    {
        // Etsi haluttu esine kaupan valikoimasta
        Item itemToBuy = items.FirstOrDefault(item => item.Name.ToLower() == itemName.ToLower());

        if (itemToBuy != null)
        {
            // Tarkista pelaajan kultatilanne
            if (player.Gold >= itemToBuy.Cost)
            {
                // Vähennä pelaajan kultaa ostoksen hinnan verran
                player.Gold -= itemToBuy.Cost;

                // Aseta pelaajalle ostettu esine
                if (itemToBuy is Weapon)
                {
                    player.EquippedWeapon = itemToBuy as Weapon;
                }
                else if (itemToBuy is Armor)
                {
                    player.EquippedArmor = itemToBuy as Armor;
                }
                else if (itemToBuy is Potion)
                {
                    player.EquippedPotion = itemToBuy as Potion;
                    player.PotionCount++;
                }

                Console.WriteLine($"You bought the {itemToBuy.Name}!");
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough gold to buy this item.");
                return false;
            }
        }
        else
        {
            Console.WriteLine("That item is not available in the shop. We recommend you go to a different store... if those exist.");
            return false;
        }
    }
}

// Pääohjelma
class Program
{
    static void Main(string[] args)
    {
        // Tässä luodaan hahmo, viholliset ja kauppa, ja peli alkaa

        {
            Knight player = new Knight("Knight knightious", 100, 20, 10, 50);
            player.EquippedWeapon = new Weapon("Sword", 15, 0);
            player.EquippedArmor = new Armor("Leather Armor", 5, 0);
            player.EquippedPotion = new Potion("Health Potion", 20, 0);
            player.Gold = 0;
            player.PotionCount = 1;

            Enemy[] enemies = {
            new Enemy("Orc", 80, 20, 15),
            new Enemy("Dragon", 200, 25, 20),
            new Enemy("Goblin", 20, 10, 15)
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

                //Please dont f**k up the game and just do as told
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

                            //Still please dont f**k up the game and just do as told
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
                            else if (action == 2 && player.PotionCount == 0)
                            {
                                Console.WriteLine("Out of potions");
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
                                player.CanFight = true;
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
}
