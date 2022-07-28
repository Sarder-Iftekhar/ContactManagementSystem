using ContactManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Interface
{
   public  interface IAuthorizationRequestService
    {
        public List<UserRegistration> GetAuthorizationRequestList();
        ResponseModel AuthorizatedUser(UserRegistration userInfo);


    }
}
