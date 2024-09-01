using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Dtos.EmployeeDtos;
using RealEstate_API.Repositories.EmployeeRepositories;

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> EmployeeByID(int id)
        {
            return Ok(await _employeeRepository.GetByIDEmployeAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            return Ok(await _employeeRepository.GetAllEmployeeAsync());
        }
        [HttpPost]
        public IActionResult EmployeeCreate(CreateEmployeeDto createEmployeeDto)
        {
            _employeeRepository.AddEmployee(createEmployeeDto);
            return Ok("Emlakçı Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return Ok("Emlakçı Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public IActionResult EmployeeUpdate(UpdateEmployeeDto updateEmployeeDto)
        {
            _employeeRepository.UpdateEmployee(updateEmployeeDto);
            return Ok("Emlakçı Başarılı Bir Şekilde Güncellendi");
        }
    }
}