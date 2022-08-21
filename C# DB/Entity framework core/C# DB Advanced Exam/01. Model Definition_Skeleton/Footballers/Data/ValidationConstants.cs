namespace Footballers.Data
{
    public class ValidationConstants
    {
        //Footballer
        public const int FootballerNameMinLength = 2;
        public const int FootballerNameMaxLength = 40;
        //Team
        public const int TeamNameMinLength = 3;
        public const int TeamNameMaxLength = 40;
        public const int NationalityMinLength = 2;
        public const int NationalityMaxLength = 40;
        public const string NameRegex = @"^\w+[ \w. 0-9-]*$";
        //Coach
        public const int CoachNameMinLength = 2;
        public const int CoachNameMaxLength = 40;
        //TeamFootballer
    }
}
