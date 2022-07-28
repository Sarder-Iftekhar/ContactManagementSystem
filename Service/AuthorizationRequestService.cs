using ContactManagement;
using ContactManagement.Interface;
using ContactManagement.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Services
{
    public class AuthorizationRequestService : IAuthorizationRequestService
    {
        private readonly ModelContext _context;

        public AuthorizationRequestService(ModelContext context)
        {
            _context = context;
        }
        public List<UserRegistration> GetAuthorizationRequestList()
        {
            var user = _context.UserRegistrations.Where(x => x.IsAuthorized == "0").ToList();
            return user;
        }

        public ResponseModel AuthorizatedUser(UserRegistration userInfo)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                var _temp = _context.UserRegistrations.FirstOrDefault(x => x.Id == userInfo.Id);
                if (_temp != null)
                {
                    _temp.IsAuthorized = "1";
                }
                _context.UserRegistrations.Update(_temp);
                _context.SaveChanges();
                model.Messsage = "User Authorization Successfully";
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
