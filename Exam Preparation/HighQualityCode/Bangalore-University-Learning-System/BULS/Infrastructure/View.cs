﻿namespace BangaloreUniversityLearningSystem.Infrastructure
{
    using System.Text;
    using Interfaces;

    public abstract class View : IView
    {
        protected View(object model)
        {
            this.Model = model;
        }

        public object Model { get; private set; }

        public string Display()
        {
            var viewResult = new StringBuilder();
            this.BuildViewResult(viewResult);
            return viewResult.ToString().Trim();
        }

        public abstract void BuildViewResult(StringBuilder viewResult);
    }
}
