using System;
using System.Collections.Generic;

#nullable disable

namespace ContactManagement
{
    public partial class UserRrgistration
    {
        public decimal Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Password { get; set; }
        public string Isauthorized { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string Status { get; set; }
    }
}
