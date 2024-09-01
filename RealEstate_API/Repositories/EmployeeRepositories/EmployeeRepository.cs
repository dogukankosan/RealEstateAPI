using Dapper;
using RealEstate_API.Dtos.EmployeeDtos;
using RealEstate_API.Models.DapperContext;
using System.Data;

namespace RealEstate_API.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;
        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public async void AddEmployee(CreateEmployeeDto createEmployeeDto)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@employeeName", createEmployeeDto.EmployeeName);
                parameters.Add("@employeeTitle", createEmployeeDto.EmployeeTitle);
                parameters.Add("@employeeMail", createEmployeeDto.EmployeeMail);
                parameters.Add("@employeePhoneNumber", createEmployeeDto.EmployeePhoneNumber);
                parameters.Add("@employeeImageURL", createEmployeeDto.EmployeeImageURL);
                parameters.Add("@employeeStatus", createEmployeeDto.EmployeeStatus);
                parameters.Add("@employeeCreateDate", createEmployeeDto.EmployeeCreateDate);
                await connection.ExecuteAsync("INSERT Employees (EmployeeName,EmployeeTitle,EmployeeMail,EmployeePhoneNumber,EmployeeImageURL,EmployeeStatus,EmployeeCreateDate) VALUES (@employeeName,@employeeTitle,@employeeMail,@employeePhoneNumber,@employeeImageURL,@employeeStatus,@employeeCreateDate)", parameters);
            }
        }
        public async void DeleteEmployee(int id)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@employeeID", id);
                await connection.ExecuteAsync("DELETE FROM Employees WHERE EmployeeID=@employeeID", parameters);
            }
        }
        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                return (await connection.QueryAsync<ResultEmployeeDto>("SELECT * FROM Employees")).ToList();
            }
        }
        public async Task<ResultEmployeeDto> GetByIDEmployeAsync(int id)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@employeeID", id);
                return await connection.QueryFirstOrDefaultAsync<ResultEmployeeDto>("SELECT * FROM Employees WHERE EmployeeID=@employeeID", parameters);
            }
        }
        public async void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@employeeID", updateEmployeeDto.EmployeeID);
                parameters.Add("@employeeName", updateEmployeeDto.EmployeeName);
                parameters.Add("@employeeTitle", updateEmployeeDto.EmployeeTitle);
                parameters.Add("@employeeMail", updateEmployeeDto.EmployeeMail);
                parameters.Add("@employeePhoneNumber", updateEmployeeDto.EmployeePhoneNumber);
                parameters.Add("@employeeImageURL", updateEmployeeDto.EmployeeImageURL);
                parameters.Add("@employeeStatus", updateEmployeeDto.EmployeeStatus);
                await connection.ExecuteAsync("UPDATE Employees SET EmployeeName=@employeeName,EmployeeTitle=@employeeTitle,EmployeeMail=@employeeMail,EmployeePhoneNumber=@employeePhoneNumber,EmployeeImageURL=@employeeImageURL,EmployeeStatus=@employeeStatus WHERE EmployeeID=@employeeID", parameters);
            }
        }
    }
}