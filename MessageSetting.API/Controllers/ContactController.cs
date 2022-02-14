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
        private readonly IContactService _contactService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public ContactController(
            IMapper mapper,
            IContactService contactService,
            IUserService userService)
        {
            _mapper = mapper;
            _contactService = contactService;
            _userService = userService;
        }
        #region Contact

        [HttpGet]
        [Route("GetContactAsync")]
        public async Task<IActionResult> GetContactAsync()
        {
            try

            {
                var result = await _contactService.GetAllWithChildAsync();
                var contacts = _mapper.Map<List<Contact>, List<ContactModel>>(result.ToList());
                //contacts.ForEach(contact => { contact.ContactUsers.Select(e => e.UserType != 1); });

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
                var result = await _contactService.SaveAsync(contact);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        [Route("UpdateRangeAsync")]
        public async Task<IActionResult> UpdateRangeAsync([FromBody] IList<ContactModel> contacts)
        {
            try
            {

                var mappedContacts = _mapper.Map<List<ContactModel>, List<Contact>>(contacts.ToList());

                _contactService.UpdateRange(mappedContacts);

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

                var users = _mapper.Map<List<User>, List<UserModel>>(result.ToList());


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
