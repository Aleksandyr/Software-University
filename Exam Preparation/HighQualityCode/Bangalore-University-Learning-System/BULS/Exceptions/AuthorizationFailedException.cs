namespace BangaloreUniversityLearningSystem.Exceptions
{
    using System;

    public class AuthorizationFailedException : Exception
    {
        public AuthorizationFailedException()
        {   
        }

        public AuthorizationFailedException(string msg)
            : base(msg)
        {
        }
    }
}
