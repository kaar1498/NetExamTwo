using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using NetExamTwo.Models;

namespace NetExamTwo.Data
{
    public class DbInitialize
    {
        internal static void Initialize(NetExamTwoContext context)
        {
            //if (context.Containers.Any())
            //{
            //    return;
            //}

            Randomizer.Seed = new Random(1);

            var Phones = new Faker<Phone>()
                .RuleFor(o => o.PhoneCountryCode, p => p.Address.CountryCode())
                .RuleFor(o => o.PhoneNumber, p => p.Person.Phone);

            var ContainerStatuses = new Faker<ContainerStatus>()
                .RuleFor(o => o.Status, cs => cs.Random.Enum<Status>())
                .RuleFor(o => o.DateCreated, cs => cs.Date.Recent());

            var ContainerHistories = new Faker<ContainerHistory>()
                .RuleFor(o => o.StatusHistory, ch => ContainerStatuses.Generate(6))
                .RuleFor(o => o.CustomerHistory, ch => ch.Random.Int());

            var ContactInfos = new Faker<ContactInfo>()
                .RuleFor(o => o.Email, ci => ci.Person.Email)
                .RuleFor(o => o.Phone, ci => Phones.Generate(1).First())
                .RuleFor(o => o.Fax, ci => ci.Person.Phone);

            var ContactPersons = new Faker<ContactPerson>()
                .RuleFor(o => o.Name, ci => ci.Person.FullName)
                .RuleFor(o => o.Title, ci => ci.Lorem.Word())
                .RuleFor(o => o.ContactInfo, ci => ContactInfos.Generate(1).First());

            var Containers = new Faker<Container>()
                .RuleFor(o => o.Pipe, c => c.Random.Int(0, 4))
                .RuleFor(o => o.Shelf, c => c.Random.Int(2, 6))
                .RuleFor(o => o.BottomFrame, c => c.Random.Int(0, 1))
                .RuleFor(o => o.CustomerId, c => c.Random.Int())
                .RuleFor(o => o.ContainerHistory, c => ContainerHistories.Generate(1))
                .RuleFor(o => o.currentStatus, c => c.ContainerStatuses.Generate(1));

            var Customers = new Faker<Customer>()
                .RuleFor(o => o.PostCode, c => c.Address.ZipCode())
                .RuleFor(o => o.Address, c => c.Address.FullAddress())
                .RuleFor(o => o.CVR, c => c.Random.Int())
                .RuleFor(o => o.ContactInfo, c => ContactInfos.Generate(1).First())
                .RuleFor(o => o.ContactList, c => ContactPersons.Generate(3));
           

            context.AddRange(Containers.Generate(50));
            context.AddRange(Customers.Generate(50));

            context.SaveChanges();
        }
    }
}
