namespace ISIS.Core
{
    using System;
    using System.Reflection;
    using System.Linq;

    using ISIS.Interfaces;
    using ISIS.Models;
    using System.Text.RegularExpressions;
    using System.Text;

    public class Engine : IRunnable
    {
        private IData data;
        private IInputReader reader;
        private IOutputWriter writer;
        private IWarEffectFactory warFactory;
        private IAttackTypeFactory attackTypeFectory;
        private IGroupFactory groupFactory;

        public Engine(IData data, IInputReader reader, IOutputWriter writer, IWarEffectFactory warFactory, IAttackTypeFactory attackFactory, IGroupFactory groupFactory)
        {
            this.data = data;
            this.reader = reader;
            this.writer = writer;
            this.warFactory = warFactory;
            this.attackTypeFectory = attackFactory;
            this.groupFactory = groupFactory;
        }

        public void Run()
        {
            while (true)
            {
                string input = this.reader.ReadLine().Trim();
                string[] splited = Regex.Split(input, @"\W+");

                this.ExecuteCommand(splited);
                this.UpdateGroups();
            }   
        }

        private void UpdateGroups()
        {
            foreach (var group in this.data.Groups)
            {
                if (!group.Value.IsAlive)
                {
                    this.writer.Print(string.Format("Group {0} AMEN", group.Key));
                }
                group.Value.Update();
            }

            this.data.Groups
                .OrderBy(g => g.Value.Health)
                .ThenBy(g => g.Value.Damage);
        }

        private void ExecuteCommand(string[] input)
        {
            string name = string.Empty;
            string command = input[1];
            int health = 0;
            int damage = 0;
            string warEffectType = string.Empty;
            string attackType = string.Empty;
            string enemyName = string.Empty;

            switch (command)
            {
                case "create":
                    name = input[0];
                    health = int.Parse(input[2]);
                    damage = int.Parse(input[3]);
                    warEffectType = input[4];
                    attackType = input[5];

                    this.CreateGroup(name, health, damage, warEffectType, attackType);
                    break;
                case "attack":
                    name = input[0];
                    enemyName = input[2];

                    this.AttackBetweenGroups(name, enemyName);
                    break;
                case "status":
                    this.ExecuteGroup();
                    break;
                case "apocalypse":
                    Environment.Exit(0);
                    break;
                default:
                    throw new InvalidOperationException("Incorrect command.");
            }
        }

        private void AttackBetweenGroups(string attackerName, string enemyName)
        {
            IGroup attackGroup = this.data.Groups.FirstOrDefault(g => g.Key == attackerName).Value;
            IGroup enemyGroup = this.data.Groups.FirstOrDefault(g => g.Key == enemyName).Value;
            if (attackGroup != null && enemyGroup != null &&
                attackGroup.IsAlive && enemyGroup.IsAlive)
            {

                var attackType = attackGroup.AttackType.GetType().Name;
                var warrEffectType = enemyGroup.WarEffect.GetType().Name;

                switch (attackType.ToString())
                {
                    case "SU24":
                        attackGroup.Damage *= 2;
                        attackGroup.Health /= 2;
                        break;
                    case "Paris":
                        attackGroup.Health /= 2;
                        break;
                    default:
                        throw new InvalidOperationException("Invalid attack type");
                        break;
                }

                switch (warrEffectType.ToString())
                {
                    case "Jihad":
                        enemyGroup.Damage *= enemyGroup.WarEffect.MultipleIncrease;
                        break;
                    case "Kamikaze":
                        enemyGroup.Health += enemyGroup.WarEffect.HealthIncrease;
                        break;
                    default:
                        throw new InvalidOperationException("Invalid attack type");
                        break;
                }


                //attackGroup.AttackType = this.CreateAttackType(attackGroup.Damage, attackGroup.Health);
                
            }
            
        }

        private void ExecuteGroup()
        {
            StringBuilder output = new StringBuilder();

            if (this.data.Groups.Any())
            {
                foreach (var group in this.data.Groups)
                {
                    output.AppendLine(string.Format("Group {0}: {1}", group.Key, group.Value));
                }
            }

            this.writer.Print(output.ToString().Trim());
        }

        private void CreateGroup(string name, int health, int damage, string warEffectType, string attackTypeParam)
        {
            IWarEffect warEffect = this.warFactory.CreateWarEffect(warEffectType);
            IAttackType attackType = this.attackTypeFectory.CreateAttackType(attackTypeParam, damage, health);
            IGroup group = new GroupGame(health, damage, attackType, warEffect);
            this.data.AddGroup(name, group);
        }

        private IAttackType CreateAttackType(string attackType, int attackDamage, int health)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant() == attackType.ToLowerInvariant());

            if (type == null)
            {
                throw new InvalidOperationException("Invalid attack type.");
            }

            var warEffect = Activator.CreateInstance(type, attackDamage, health) as IAttackType;

            return warEffect;
        }

        private IWarEffect CreateWarEffect(string warEffectType)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant() == warEffectType.ToLowerInvariant());

            if (type == null)
            {
                throw new InvalidOperationException("Invalid war effect type.");
            }

            var warEffect = Activator.CreateInstance(type) as IWarEffect;

            return warEffect;
        }
    }
}
