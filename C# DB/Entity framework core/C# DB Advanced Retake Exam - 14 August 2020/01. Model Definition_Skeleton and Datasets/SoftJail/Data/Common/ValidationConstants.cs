namespace SoftJail.Data.Common
{
    public class ValidationConstants
    {
        //Prisoner
        public const int PrisonerFullNameMaxLength = 20;
        public const int PrisonerFullNameMinLength = 3;
        public const string PrisonerNicknameRegex = @"^(The\s)([A-Z][a-z]*)$";
        public const int PrisonerAgeMinValue = 18;
        public const int PrisonerAgeMaxValue = 65;
        public const string PrisonerBailMinValue = "0";
        public const string PrisonerBailMaxValue = "79228162514264337593543950335";

        //Officer
        public const int OfficerFullNameMaxLength = 30;
        public const int OfficerFullNameMinLength = 3;
        public const string OfficerSalaryMinValue = "0";
        public const string OfficerSalaryMaxValue = "79228162514264337593543950335";


        //Department
        public const int DepartmentNameMaxLength = 25;
        public const int DepartmentNameMinLength = 3;

        //Cell
        public const int CellNumberMinValue = 1;
        public const int CellNumberMaxValue = 1000;

        //Mail
        public const string MailAddressRegex = @"^([A-Za-z\s0-9]+?)(\sstr\.)$";
    }
}
