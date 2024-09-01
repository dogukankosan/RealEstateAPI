using RealEstate_API.Dtos.EmployeeDtos;

namespace RealEstate_API.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
        Task<ResultEmployeeDto> GetByIDEmployeAsync(int id);
        void AddEmployee(CreateEmployeeDto createEmployeeDto);
        void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);
        void DeleteEmployee(int id);
    }
}