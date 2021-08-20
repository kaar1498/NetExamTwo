using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetExamTwo.Models
{
    public class ContactPerson : IModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }
}
