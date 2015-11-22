namespace TheSlum.GameEngine
{
    using System;
    using System.Linq;

    using TheSlum.Characters;
    using TheSlum.Characters.Items;
    using TheSlum.Characters.Items.Bonuses;

    public class ExtendEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
                case "status":
                    this.PrintCharactersStatus(this.characterList);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            Character character = null;

            switch (inputParams[1].ToLower())
            {
                case "warrior":
                    character = new Warrior(inputParams[2], int.Parse(inputParams[3]), int.Parse(inputParams[4]), 200, 100, (Team)Enum.Parse(typeof(Team), inputParams[5], true), 2, 150);
                    break;
                case "mage":
                    character = new Mage(inputParams[2], int.Parse(inputParams[3]), int.Parse(inputParams[4]), 150, 50, (Team)Enum.Parse(typeof(Team), inputParams[5], true), 5, 300);
                    break;
                case "healer":
                    character = new Healer(inputParams[2], int.Parse(inputParams[3]), int.Parse(inputParams[4]), 75, 50, (Team)Enum.Parse(typeof(Team), inputParams[5], true), 6, 60);
                    break;
                default:
                    throw new FormatException("This character is not exist!");
            }

            this.characterList.Add(character);
        }

        private new void AddItem(string[] inputParams)
        {
            var character = this.characterList.FirstOrDefault(c => c.Id == inputParams[1]);
            Item item = null;
            switch (inputParams[2])
            {
                case "axe":
                    item = new Axe(inputParams[3], 0, 0, 75);
                    break;
                case "shield":
                    item = new Shield(inputParams[3], 0, 50, 0);
                    break;
                case "injection":
                    item = new Injection(inputParams[3], 200, 0, 0);
                    break;
                case "pill":
                    item = new Pill(inputParams[3], 0, 0, 100);
                    break;
                default:
                    throw new FormatException("This item is not exist!");
            }
            if (character == null)
            {
                throw new InvalidOperationException("This charectar is not exist!");
            }

            character.AddToInventory(item);
        }
    }
}
