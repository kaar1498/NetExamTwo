using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetExamTwo.Models
{
    public class ContainerHistory : IModel
    {
        [Key]
        public int Id { get; set; }
        public List<ContainerStatus> StatusHistory { get; set; }
        public List<int> CustomerHistory { get; set; }
    }
}
