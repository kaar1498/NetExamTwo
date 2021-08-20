using Microsoft.EntityFrameworkCore;
using NetExamTwo.Data;
using NetExamTwo.Exceptions;
using NetExamTwo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetExamTwo.Services
{
    public class GetCustomersService
    {
        private readonly NetExamTwoContext _context;

        public GetCustomersService(NetExamTwoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAsync(
            int? customerId,
            bool withContactInfo,
            bool withContactList)
        {
            IQueryable<Customer> queryable = IncludeDependencies(withContactInfo, withContactList);

            List<Customer> customers = new();

            if (customerId.HasValue)
            {
                Customer customer = await FindCustomerAsync(customerId.Value, queryable);

                customers.Add(customer);
            }
            else
            {
                customers = await queryable.ToListAsync();
            }

            return customers;
        }

        private static async Task<Customer> FindCustomerAsync(int id, IQueryable<Customer> set)
        {
            List<Customer> customers = await set.ToListAsync();

            Customer customer = customers.Find(c => c.Id == id);

            if (customer == null)
            {
                throw new EntityNotFoundException(nameof(Container), id);
            }
                       return customer;
        }

        private IQueryable<Customer> IncludeDependencies(bool withContactInfo, bool withContactList)
        {
            IQueryable<Customer> set = _context.Customers;


            if (withContactInfo)
            {
                set = set.Include(c => c.ContactInfo);
            }
            if(withContactList)
            {
                set = set.Include(c => c.ContactList);
            }

            return set;
        }
    }
}
