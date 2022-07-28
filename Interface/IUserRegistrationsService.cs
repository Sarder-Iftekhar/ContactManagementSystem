using ContactManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Interface
{
    public interface IUserRegistrationsService
    {

        public List<UserRegistration> GetUserList();
        public ResponseModel AddUser(UserRegistration userInfo);
    }
}
