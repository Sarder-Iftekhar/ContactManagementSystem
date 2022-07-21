using System;
using System.Collections.Generic;

#nullable disable

namespace ContactManagement
{
    public partial class User
    {
        public decimal UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Authentication { get; set; }
    }
}
