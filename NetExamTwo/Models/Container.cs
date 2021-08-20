using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetExamTwo.Models
{
    public class Container : IModel
    {
        [Key]
        public int Id { get; set; }
        public int CCTag { get; set; }
        public int Pipe { get; set; }
        public int Shelf { get; set; }
        public int BottomFrame { get; set; }
        public int? CustomerId { get; set; }
        public ContainerHistory ContainerHistory { get; set; }
        public ContainerStatus currentStatus { get { return ContainerHistory.StatusHistory.Last(); } }

    }
}
