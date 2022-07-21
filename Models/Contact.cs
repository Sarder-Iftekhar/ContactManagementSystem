using System;
using System.Collections.Generic;

#nullable disable

namespace ContactManagement
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public decimal? UserId { get; set; }
        public byte[] Image { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Phone { get; set; }
        public string Relationship { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Event { get; set; }
        public string Website { get; set; }
        public string Notes { get; set; }
    }
}
