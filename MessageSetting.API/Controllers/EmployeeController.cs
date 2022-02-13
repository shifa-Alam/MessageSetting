using MessageSetting.Application.Services;
using MessageSetting.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageSetting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController( IEmployeeService employeeService)
        {
            _service = employeeService;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            try
            
            {
               var result = await _service.GetAsync();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost]
        [Route("SaveAsync")]
        public async Task<IActionResult> SaveAsync([FromBody] Employee employee)
        {
            try
            {
                var result =  await _service.SaveAsync(employee);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
