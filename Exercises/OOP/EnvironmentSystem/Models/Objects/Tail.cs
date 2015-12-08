namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;

    public class Tail : EnvironmentObject
    {
        private int lifetime;

        public Tail(int x, int y, int lifetime = 1)
            : base(x, y, 1, 1)
        {
            this.ImageProfile = new char[,] { { '*' } };
            this.lifetime = lifetime;
        }

        public override void Update()
        {
            this.lifetime--;
            if (this.lifetime <= 0)
            {
                this.Exists = false;
            }
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }
    }
}
