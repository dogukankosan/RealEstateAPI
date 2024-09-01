namespace RealEstate_UI.Dtos.EmployeeDtos
{
    public class UpdateEmployeeDto
    {
        public int EmployeeID { get; set; }
        public required string EmployeeName { get; set; }
        public required string EmployeeTitle { get; set; }
        public required string EmployeeMail { get; set; }
        public required string EmployeePhoneNumber { get; set; }
        public required string EmployeeImageURL { get; set; }
        public bool EmployeeStatus { get; set; }
    }
}