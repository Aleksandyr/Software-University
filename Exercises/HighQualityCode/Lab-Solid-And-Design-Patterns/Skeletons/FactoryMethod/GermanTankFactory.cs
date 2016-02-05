using TankManufacturer.Units;

namespace FactoryMethod
{
    public class GermanTankFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            var tiger = new Tank("Tiger", 4.5, 120);

            return tiger;
        }
    }
}
