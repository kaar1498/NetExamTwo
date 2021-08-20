using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetExamTwo.Models
{
    public class Customer : IModel
    {
        [Key]
        public int Id { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public int CVR { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public List<ContactPerson> ContactList { get; set; }
    }
}
