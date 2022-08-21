namespace Artillery.Data
{
    public class ValidationConstants
    {
        //Country
        public const int CountryNameMinLength = 4;
        public const int CountryNameMaxLength = 60;
        public const int ArmySizeMinValue = 50000;
        public const int ArmySizeMaxValue = 10000000;
        //Manufacturer
        public const int ManufacturerNameMinLength = 4;
        public const int ManufacturerNameMaxLength = 40;
        public const int FoundedMinLength = 10;
        public const int FoundedMaxLength = 100;
        //Shell
        public const double ShellWeightMinValue = 2;
        public const double ShellWeightMaxValue = 1680;
        public const int CaliberMinLength = 4;
        public const int CaliberMaxLength = 30;
        //Gun
        public const int GunWeightMinValue = 100;
        public const int GunWeightMaxValue = 1350000;
        public const double BarrelLengthMinValue = 2.00;
        public const double BarrelLengthMaxValue = 35.00;
        public const int RangeMinValue = 1;
        public const int RangeMaxValue = 100000;
    }
}
