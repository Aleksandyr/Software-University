using TankManufacturer.Units;

namespace FactoryMethod
{
    public class AmericanTankFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            var m1Abrams = new Tank("M1 Abrams", 5.4, 120);

            return m1Abrams;
        }
    }
}
