namespace BangaloreUniversityLearningSystem.Infrastructure
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Exceptions;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities;

    public abstract class Controller
    {
        public User User { get; set; }

        public bool HasCurrentUser
        {
            get
            {
                return User != null;
            }
        }

        protected IBangaloreUniversityData Data { get; set; }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(Constants.NamespaceSeparator);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);

            string controllerName = this.GetType().Name.Replace(Constants.ControllerSuffix, string.Empty);
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
