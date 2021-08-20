using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetExamTwo.Models
{
    public class ContactInfo : IModel
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public Phone Phone { get; set; }
        public string Fax { get; set; }
    }
}
