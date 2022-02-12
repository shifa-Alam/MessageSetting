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
        private readonly IUserService _userService;
        public ContactController(IContactService contactService, IUserService userService)
        {
            _service = contactService;
            _userService = userService;
        }
        #region Contact
        [HttpGet]
        [Route("GetContactAsync")]
        public async Task<IActionResult> GetContactAsync()
        {
            try

            {
                var result = await _service.GetAllWithChildAsync();
                return Ok(result.ToList());
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


        [HttpPost]
        [Route("UpdateRangeAsync")]
        public async Task<IActionResult> UpdateRangeAsync([FromBody] IList<Object> contacts)
        {
            try
            {
                IList<Contact> conts = new List<Contact>();
                foreach (var contact in contacts)
                {
                    conts.Add((Contact)contact);
                }
                var result = _service.UpdateRangeAsync(conts);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region User
        [HttpGet]
        [Route("GetUserAsync")]
        public async Task<IActionResult> GetUserAsync()
        {
            try
            {
                var result = await _userService.GetAsync();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}
