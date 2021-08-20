using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetExamTwo.Models;

namespace NetExamTwo.Data
{
    public class NetExamTwoContext : DbContext
    {
        public NetExamTwoContext (DbContextOptions<NetExamTwoContext> options)
            : base(options)
        {
        }

        public DbSet<Container> Containers { get; set; }
        public DbSet<ContainerStatus> ContainerStatuses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<ContactPerson> ContactPeople { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
