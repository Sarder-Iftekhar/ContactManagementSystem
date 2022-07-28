using ContactManagement.Interface;
using ContactManagement.Models;
using ContactManagement.ViewModels;
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
    public class LoginUserController : ControllerBase
    {


        ResponseModel model = new ResponseModel();
        IUserLoginService userLoginService;

        public LoginUserController(IUserLoginService _userLoginService)
        {
            userLoginService = _userLoginService;
        }


        //User Login Controller
        [HttpPost]
        [Route("[action]")]
        public IActionResult UserLogin(LoginRequest userData)
        {
            try
            {
                var data = userLoginService.LoginUser(userData);
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

