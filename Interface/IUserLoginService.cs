using ContactManagement.Models;
using ContactManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Interface
{
    public interface IUserLoginService
    {
        public ResponseModel LoginUser(LoginRequest loginRequest);
    }
}
