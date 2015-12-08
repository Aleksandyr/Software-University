namespace EnvironmentSystem.Models.Objects
{
    using EnvironmentSystem.Models.DataStructures;
    using System;
    using System.Collections.Generic;

    public class Star : EnvironmentObject
    {
        private const int ImageChangeFrequency = 10;

        protected static readonly char[] StartImages = new char[] { 'O', '@', '0' };
        private static readonly Random ImageRandom = new Random();

        private int updatesCount;

        public Star(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.ImageProfile = new char[,] { { StartImages[0] } };
        }

        public override void Update()
        {
            if (this.updatesCount % ImageChangeFrequency == 0)
            {
                int index = ImageRandom.Next(0, StartImages.Length);
                this.ImageProfile = new char[,] { { StartImages[index] } };
            }

            this.updatesCount++;
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
