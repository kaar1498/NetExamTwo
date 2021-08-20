using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetExamTwo.Models
{
    public class ContainerStatus : IModel
    {
        [Key]
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public enum Status
    {
        Available,
        InUse,
        Lost
    }
}
