using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetExamTwo.Models
{
    public class Phone : IModel
    {
        [Key]
        public int Id { get; set; }
        public string PhoneCountryCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
