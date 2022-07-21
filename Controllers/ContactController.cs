using ContactManagement.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IContact _contactService;
        public ContactController(IContact service)
        {
            _contactService = service;
        }


        [HttpGet("GetAllContact")]
        //[Route("[action]")]
        public IActionResult GetAllContact()
        {
            try
            {
                var contact = _contactService.GetContactList();
                if (contact == null) return NotFound();
                return Ok(contact);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }




        [HttpGet]
        [Route("[action]/id/{contactID}")]
        public IActionResult GetContactById(int contactID)
        {
            try
            {
                var contact = _contactService.GetContactDetailsById(contactID);
                if (contact == null) return NotFound();
                return Ok(contact);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }





        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveEmployees(Contact contactModel)
        {
            try
            {
                var model = _contactService.SaveContact(contactModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteContact(int id)
        {
            try
            {
                var model = _contactService.DeleteContact(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }




    }
}
