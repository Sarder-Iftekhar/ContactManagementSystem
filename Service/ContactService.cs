using ContactManagement.Interface;
using ContactManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Service
{
    public class ContactService:IContact
    {


        private ModelContext _context;
        public ContactService(ModelContext context)
        {
            _context = context;
        }


        public List<Contact> GetContactList()
        {
            List<Contact> empList;
            try
            {
                empList = _context.Set<Contact>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return empList;
        }


        public Contact GetContactDetailsById(int employeeID)
        {
            Contact emp;
            try
            {
                emp = _context.Find<Contact>(employeeID);
            }
            catch (Exception)
            {
                throw;
            }
            return emp;
        }
        //In the above code, you can see that this method takes one parameter, ID.
        //We get an employee object from the database which employee ID matches our parameter id.



        //************************************Save Employee Method***************************

        /// <summary>
        ///  add edit employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        public ResponseModel SaveContact(Contact contactModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Contact _temp = GetContactDetailsById(contactModel.ContactId);
                if (_temp != null)
                {
                    _temp.UserId = contactModel.UserId;
                    _temp.FirstName = contactModel.FirstName;
                    _temp.MiddleName = contactModel.MiddleName;
                    _temp.LastName = contactModel.LastName;
                    _temp.Image = contactModel.Image;
                    _temp.Email = contactModel.Email;
                    _temp.Image = contactModel.Image;
                    _temp.Image = contactModel.Image;
                    _temp.Image = contactModel.Image;
                    _temp.Image = contactModel.Image;

                    _context.Update<Contact>(_temp);
                    model.Messsage = "Contact Update Successfully";
                }
                else
                {
                    _context.Add<Contact>(contactModel);
                    model.Messsage = "Contact Inserted Successfully";
                }
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



        public ResponseModel DeleteContact(int contactId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Contact _temp = GetContactDetailsById(contactId);
                if (_temp != null)
                {
                    _context.Remove<Contact>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Contact Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    //In the delete method, we take employee id as a parameter. And call service method get detail by id
                    //forget employee details.
                    model.Messsage = "Contact Not Found";
                }
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
