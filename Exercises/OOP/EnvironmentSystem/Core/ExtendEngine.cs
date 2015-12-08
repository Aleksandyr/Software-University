namespace EnvironmentSystem.Core
{
    using System;
    using System.Threading;

    using EnvironmentSystem.Interfaces;
    using EnvironmentSystem.Models.Objects;

    public class ExtendEngine : Engine
    {
        private readonly IController controller;
        private bool isPaused;

        public ExtendEngine(int worldWidth, 
            int worldHeight, 
            IObjectGenerator<EnvironmentObject> objectGenerator, 
            ICollisionHandler collisionHandler, 
            IRenderer renderer,
            IController controller)
            : base(worldWidth, worldHeight, objectGenerator, collisionHandler, renderer)
        {
            this.controller = controller;
            this.AttachControllerEvents();
        }

        protected override void ExecuteEnvironmentLoop()
        {
            this.controller.ProcessInput();

            if (!this.isPaused)
            {
                base.ExecuteEnvironmentLoop();
            }
            else
            {
                Thread.Sleep(LoopIntervalInMilliseconds);
            }
        }

        protected override void Insert(EnvironmentObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Object cannot be null.");
            }

            base.Insert(obj);
        }

        private void AttachControllerEvents()
        {
            this.controller.Pause += (sender, args) =>
            {
                this.isPaused = !this.isPaused;
            };
        }
    }
}
