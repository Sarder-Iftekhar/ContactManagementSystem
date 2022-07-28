using ContactManagement.Interface;
using ContactManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Service
{
    public class UserRegistrationsService: IUserRegistrationsService
    {

        private readonly ModelContext _context;

        public UserRegistrationsService(ModelContext context)
        {
            _context = context;
        }

        //Get All User List
        public List<UserRegistration> GetUserList()
        {

            var UserList = _context.UserRegistrations.OrderByDescending(x => x.Id).ToList();
            return UserList;
        }

        //Save User Information
        public ResponseModel AddUser(UserRegistration userInfo)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                UserRegistration user = new UserRegistration()
                {
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    PhoneNumber = userInfo.PhoneNumber,
                    Email = userInfo.Email,
                    IsAuthorized = "0",
                    Status = "0",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Password = "erainfotech"
                };
                _context.UserRegistrations.Add(user);
                model.Messsage = "Employee Inserted Successfully";
                _context.SaveChanges();
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
