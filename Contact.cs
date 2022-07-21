using System;
using System.Collections.Generic;

#nullable disable

namespace ContactManagement
{
    public partial class Contact
    {
        public decimal? UserId { get; set; }
        public decimal? ContactId { get; set; }
        public byte[] Image { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal? Birthdate { get; set; }
        public decimal? Phone { get; set; }
        public string Relationship { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public decimal? PostalCode { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Event { get; set; }
        public string Website { get; set; }
        public string Chat { get; set; }
        public string Notes { get; set; }

        public virtual User User { get; set; }
    }
}
