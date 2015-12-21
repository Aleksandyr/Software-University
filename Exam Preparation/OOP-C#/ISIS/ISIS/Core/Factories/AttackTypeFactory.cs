namespace ISIS.Core.Factories
{
    using System;
    using System.Reflection;
    using System.Linq;

    using ISIS.Interfaces;

    public class AttackTypeFactory : IAttackTypeFactory
    {
        public IAttackType CreateAttackType(string attackType, int attackDamage, int health)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant() == attackType.ToLowerInvariant());

            if (type == null)
            {
                throw new InvalidOperationException("Invalid attack type.");
            }

            var attackTypeInstance = Activator.CreateInstance(type, attackDamage, health) as IAttackType;

            return attackTypeInstance;
        }
    }
}
