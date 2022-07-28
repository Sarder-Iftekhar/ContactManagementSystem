using ContactManagement.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Controllers
{
    [Route("api/Contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {



            //n the Constructor of our controller, we implement dependency injection for our service.

            IContactService _contactService;

            public ContactController(IContactService service)
            {
                _contactService = service;
            }

            //For this controller, we are using routing with action methods.
            //For example, if the user called Employee with Get method then it will call Get List Of All Employee Method
            //and if the user called Employee/{id} with Get then it will call Get Employee Details By Id Method
            //and If user called Employee with POST method then it will call Save Employee Method
            //and same as if the user called Employee with Delete method then it will call Delete Employee Method

            //*************************************Get List Of All Employee Method*********************
            /// <summary>
            /// get all employess
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            [Route("[action]")]
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

            //in the above method, we call a method from our service and assign it to the variable.
            //If the variable is not null then we return ok status with this variable, else we return not found.

            //*********************Get Employee Details By Id Method*************************
            /// <summary>
            /// get employee details by  
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            /// 


            [HttpGet("GetContactById/{id}")]
            //[Route("[action]/id")]
            public IActionResult GetContactById(decimal id)
            {
                try
                {
                    var contact = _contactService.GetContactDetailsById(id);
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
            public IActionResult SaveContact(Contact contactModel)
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



        [HttpDelete("DeleteContact/{id}")]
        //[Route("[action]")]
        public IActionResult DeleteContact(decimal id)
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
