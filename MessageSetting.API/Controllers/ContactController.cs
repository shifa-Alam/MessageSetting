using AutoMapper;
using MessageSetting.API.Models;
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
        private readonly IMapper _mapper;
        public ContactController(IMapper mapper, IContactService contactService, IUserService userService)
        {
            _mapper = mapper;
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
                var contacts = _mapper.Map<List<Contact>, List<ContactInputModel>>(result.ToList());
                return Ok(contacts);
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
        public async Task<IActionResult> UpdateRangeAsync([FromBody] IList<ContactInputModel> contacts)
        {
            try
            {
                var mappedContacts = _mapper.Map<List<ContactInputModel>, List<Contact>>(contacts.ToList());
                
                var result = _service.UpdateRangeAsync(mappedContacts);
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

               var users =_mapper.Map<List<User>, List<UserInputModel>>(result.ToList());
                return Ok(users);
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}
