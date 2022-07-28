
using ContactManagement;
using ContactManagement.ViewModels;
using System.Collections.Generic;

namespace ContactManagement.Interface
{
    public interface IContactService
    {

        /// <summary>
        /// get list of all employees
        /// </summary>
        /// <returns></returns>
        List<Contact> GetContactList();

        /// <summary>
        /// get employee details by employee id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        Contact GetContactDetailsById(decimal contactId);

        /// <summary>
        ///  add edit employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        ResponseModel SaveContact(Contact contactModel);


        /// <summary>
        /// delete employees
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        ResponseModel DeleteContact(decimal contactId);




    }
}