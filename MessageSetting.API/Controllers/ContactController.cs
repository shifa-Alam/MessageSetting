using MessageSetting.Application.Services;
using MessageSetting.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageSetting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;
        public ContactController( IContactService contactService)
        {
            _service = contactService;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            try
            
            {
               var result = _service.GetAsync();
                return Ok(result.Result);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost]
        [Route("SaveAsync")]
        public async Task<IActionResult> SaveAsync([FromBody] Contact contact)
        {
            try
            {
                var result = _service.SaveAsync(contact);
                return Ok(result.Result);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
