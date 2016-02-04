namespace BangaloreUniversityLearningSystem.Infrastructure
{
    using System.Diagnostics;
    using Interfaces;
    using System.Reflection;
    using System.Linq;
    using System;

    using Enums;
    using Models;

    using BangaloreUniversityLearningSystem.Exceptions;
    using BangaloreUniversityLearningSystem.Utilities;

    public abstract class Controller
    {
        protected IBangaloreUniversityData Data { get; set; }

        public User User { get; set; }

        public bool HasCurrentUser
        {
            get
            {
                return User != null;
            }
        }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(Constants.NamespaceSeparator);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);

            string controllerName = this.GetType().Name.Replace(Constants.ControllerSuffix, "");
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;

            string fullPath = baseNamespace + 
                Constants.NamespaceSeparator +
                Constants.ViewsFolder + 
                Constants.NamespaceSeparator +
                controllerName + 
                Constants.NamespaceSeparator + 
                actionName;

            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);

            return Activator.CreateInstance(viewType, model) as IView;
        }
        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }
           
            if (!roles.Any(role => this.User.IsInRole(role)))
            {
                throw new AuthorizationFailedException("The current user is not authorized to perform this operation.");
            }
           
        }
    }
}
