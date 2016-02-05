using TankManufacturer.Units;

namespace FactoryMethod
{
    public class RussianTankFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            var t34 = new Tank("T 34", 3.3, 75);

            return t34;
        }
    }
}
