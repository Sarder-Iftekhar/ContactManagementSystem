

using ContactManagement;
using ContactManagement.Interface;
using ContactManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactManagement.Services
{
    public class ContactService : IContactService
    {


        //***********************Add Dependency***************************

        //We are going to use DbContext in our service class for this we add dependency in the constructor
        //as you can see in below code.


        private ModelContext _context;
        public ContactService(ModelContext context)
        {
            _context = context;
        }

        //*********************************Get All Employee Method************************************


        /// <summary>
        /// get list of all employees
        /// </summary>
        /// <returns></returns>
        public List<Contact> GetContactList()
        {
            List<Contact> contactList;
            try
            {
                contactList = _context.Set<Contact>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return contactList;
        }
        //In the above code, you can see that we are returning a list of employees from this method.
        //To retrieve data from the database, we use the toList() method of DbContext.


        //*****************Get Employee Details By Id Method**************************************


        /// <summary>
        /// get employee details by employee id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public Contact GetContactDetailsById(decimal contactId)
        {
            Contact contact;
            try
            {
                contact = _context.Find<Contact>(contactId);
                //var findId = _context.Contacts.FirstOrDefault(x => x.ContactId == id);
                //_context.Contacts.Remove(findId);
                //_context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return contact;
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
                   _temp.ContactId = contactModel.ContactId;
                    _temp.UserId = contactModel.UserId;
                   // _temp.Image = contactModel.Image;
                    _temp.FirstName = contactModel.FirstName;
                    _temp.MiddleName = contactModel.MiddleName; 
                    _temp.LastName = contactModel.LastName;
                    _temp.Email = contactModel.Email;
                    //_temp.Birthdate = contactModel.FirstName;
                    _temp.Phone = contactModel.Phone;
                    _temp.Address = contactModel.Address;
                    _temp.City = contactModel.City; 
         
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


        //As you have seen in the above code, we take the employee model as a parameter.
        //Then we called our get details by id method to get details of an employee by id and store In temp variable.

        //Here if employee Id is coming with a model which means we have to update the employee
        //and if the employee id is null or zero then we have added a new employee.

        //If we got data in the temp variable then we assign new data from our parameter model
        //and update employee context and with that, we also assign messages to our response model.

        //And if we got the temp variable is null, then we insert the parameter model as in context
        //and pass the message in the response model.

        //In last, we called the save changes method of context to save all changes like insert update
        //and set Is Success property of response model to true. If any error occurs,
        //then we update is success to false and pass error message in message property.





        //******************************Delete Employee Method*******************
        /// <summary>
        /// delete employees
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public ResponseModel DeleteContact(decimal contactId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Contact _contact = GetContactDetailsById(contactId);

                if (_contact != null)
                {
                    _context.Remove<Contact>(_contact);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Contact Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
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

        //In the delete method, we take employee id as a parameter. And call service method get detail by id
        //forget employee details.

        // If an employee is found then we remove this employee by calling remove method of context,
        // else we return the model with Employee not found


    }
}