namespace BangaloreUniversityLearningSystem.Utilities
{
    public class ValidationConstants
    {
        public const int MinUsernameLength = 5;
        public const int MinPasswordLength = 6;
        public const int MinCourseNameLength = 5;
        public const int MinLectureNameLength = 3;

        public const string ThereIsNoLoggedUser = "There is no currently logged in user.";
        public const string CurrUserIsNotAuthorized = "The current user is not authorized to perform this operation.";
        public const string ThereIsNoCurseWithId = "There is no course with ID {0}.";
    }
}
