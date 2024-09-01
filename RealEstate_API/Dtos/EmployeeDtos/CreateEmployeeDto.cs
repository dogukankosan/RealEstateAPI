namespace RealEstate_API.Dtos.EmployeeDtos
{
    public class CreateEmployeeDto
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeTitle { get; set; }
        public string EmployeeMail { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public string EmployeeImageURL { get; set; }
        public bool EmployeeStatus { get; set; } = false;
        public DateTime EmployeeCreateDate { get; set; } = DateTime.Now;
    }
}