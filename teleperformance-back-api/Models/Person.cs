using System;
using System.Collections.Generic;

#nullable disable

namespace teleperformance_back_api.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public int IdentityTypeId { get; set; }
        public int IdentityNumber { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }
        public bool AllowPhoneMessage { get; set; }
        public bool AllowEmailMessage { get; set; }
        public bool CanRegister { get; set; }

        public virtual IdentityType IdentityType { get; set; }
    }
}
