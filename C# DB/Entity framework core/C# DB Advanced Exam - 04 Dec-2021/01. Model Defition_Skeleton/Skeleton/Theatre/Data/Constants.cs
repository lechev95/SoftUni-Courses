using System;

namespace Theatre.Data
{
    public class Constants
    {
        //Theatre
        public const int TheatreNameMinLength = 4;
        public const int TheatreNameMaxLength = 30;
        public const int NumberOfHallsMinLength = 1;
        public const int NumberOfHallsMaxLength = 10;
        public const int DirectorMinLength = 4;
        public const int DirectorMaxLength = 30;

        //Play
        public const int TitleMinLength = 4;
        public const int TitleMaxLength = 50;
        public const int DurationMinLength = 1; //hour
        public const string RatingMinValue = "0.00";
        public const string RatingMaxValue = "10.00";
        public const int DescriptionMaxLength = 700;
        public const int ScreenwriterMinLength = 4;
        public const int ScreenwriterMaxLength = 30;

        //Cast
        public const int FullNameMinLength = 4;
        public const int FullNameMaxLength = 30;
        public const string PhoneNumberRegex = @"^\+44-\d{2}-\d{3}-\d{4}$";

        //Ticket
        public const double PriceMinValue = 1.00;
        public const double PriceMaxValue = 100.00;
        public const int RowNumberMinValue = 1;
        public const int RowNumberMaxValue = 10;
    }
}
