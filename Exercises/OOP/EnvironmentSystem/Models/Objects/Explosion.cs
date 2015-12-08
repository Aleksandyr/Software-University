namespace EnvironmentSystem.Models.Objects
{
    public class Explosion : Tail
    {
        public Explosion(int x, int y, int lifetime = 2)
            : base(x, y, lifetime)
        {
            this.CollisionGroup = CollisionGroup.Explosion;
        }
    }
}
