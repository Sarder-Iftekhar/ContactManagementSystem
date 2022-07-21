using ContactManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Interface
{
    public interface IContact
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
            Contact GetContactDetailsById(int contactID);

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
            ResponseModel DeleteContact(int contactId);
        
    }



}
