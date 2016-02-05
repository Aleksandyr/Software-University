using RPG.Weapons;

namespace RPG
{
    using System;

    using RPG.Characters;

    public class Program
    {
        static void Main()
        {
            Axe axe = new Axe();
            Sword sword = new Sword();

            Warrior axeWarrior = new Warrior(axe);
            Warrior swordWarrior = new Warrior(sword);
            Mage axeMage = new Mage(axe);
            Mage swordMage = new Mage(sword);

            Console.WriteLine(axeWarrior);
            Console.WriteLine(swordWarrior);
            Console.WriteLine(axeMage);
            Console.WriteLine(swordMage);
        }
    }
}
