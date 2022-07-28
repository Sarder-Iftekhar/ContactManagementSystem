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
    public class AuthorizationRequestController : ControllerBase
    {


        IAuthorizationRequestService authorizationRequestService;
        public AuthorizationRequestController(IAuthorizationRequestService _authorizationRequestService)
        {
            authorizationRequestService = _authorizationRequestService;
        }

        //Get Un Authorized User List
        [HttpGet]
        [Route("[action]")]
        public IActionResult AuthorizationRequestList()
        {
            try
            {
                var data = authorizationRequestService.GetAuthorizationRequestList();
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AuthorizedUser(UserRegistration userInfo)
        {
            try
            {
                var data = authorizationRequestService.AuthorizatedUser(userInfo);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

