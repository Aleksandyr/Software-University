
namespace ISIS.Core.Factories
{
    using System;
    using System.Reflection;
    using System.Linq;

    using ISIS.Interfaces;
    public class WarEffectFactory : IWarEffectFactory
    {
        public IWarEffect CreateWarEffect(string warEffectType)
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
