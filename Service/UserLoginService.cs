using ContactManagement;
using ContactManagement.Interface;
using ContactManagement.Models;
using ContactManagement.ViewModels;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly ModelContext _context;

        public UserLoginService(ModelContext context)
        {
            _context = context;
        }

        //For User Login Action
        public ResponseModel LoginUser(LoginRequest loginRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                var user = _context.UserRegistrations.SingleOrDefault(x => x.Email == loginRequest.Username && x.Password == loginRequest.Password);
                if (user != null && user.IsAuthorized == "0")
                {
                    responseModel.Messsage = "User is not authorized!";
                    return responseModel;
                }
                else if (user == null)
                {
                    responseModel.Messsage = "Incorrect username/password!";
                    return responseModel;
                }
                responseModel.Messsage = "User login successfully.";
                responseModel.IsSuccess = true;
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.IsSuccess = false;
                responseModel.Messsage = "Error : " + ex.Message;
            }
            return responseModel;
        }
    }
}
