using Microsoft.EntityFrameworkCore;
using NetExamTwo.Data;
using NetExamTwo.Exceptions;
using NetExamTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetExamTwo.Services
{
    public class GetContainersService
    {
        private readonly NetExamTwoContext _context;

        public GetContainersService(NetExamTwoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Container>> GetAsync(
            Status? status,
            int? containerId,
            bool withStatusHistory)
        {
            IQueryable<Container> queryable = IncludeDependencies(withStatusHistory);

            List<Container> containers = new();

            if (containerId.HasValue)
            {
                Container container = await FindContainerAsync(containerId.Value, queryable);

                containers.Add(container);
            }
            else
            {
                containers = await queryable.ToListAsync();
            }

            return containers;
        }

        private static async Task<Container> FindContainerAsync(int CCTagId, IQueryable<Container> set)
        {
            List<Container> containers = await set.ToListAsync();

            Container container = containers.Find(c => c.CCTag == CCTagId);

            if (container == null)
            {
                throw new EntityNotFoundException(nameof(Container), CCTagId);
            }

            return container;
        }

        private IQueryable<Container> IncludeDependencies(bool withContainerHistory)
        {
            IQueryable<Container> set = _context.Containers;


            if (withContainerHistory)
            {
                set = set.Include(c => c.ContainerHistory);
            }

            return set;
        }
    }
}
