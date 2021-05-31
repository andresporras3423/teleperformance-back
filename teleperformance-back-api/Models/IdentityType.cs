using System;
using System.Collections.Generic;

#nullable disable

namespace teleperformance_back_api.Models
{
    public partial class IdentityType
    {
        public IdentityType()
        {
            People = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Type1 { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
