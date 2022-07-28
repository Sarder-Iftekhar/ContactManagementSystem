using System;
using System.Collections.Generic;

#nullable disable

namespace ContactManagement
{
    public partial class UserRegistration
    {
        public decimal Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string IsAuthorized { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string Status { get; set; }
    }
}
