using Microsoft.EntityFrameworkCore;
using NetExamTwo.Data;
using NetExamTwo.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetExamTwo.Services
{
    public class DeleteService<T> where T : class
    {
        private readonly NetExamTwoContext _context;
        private readonly DbSet<T> _set;
        private readonly string _modelName;

        public DeleteService(NetExamTwoContext context, DbSet<T> set, string modelName)
        {
            _context = context;
            _set = set;
            _modelName = modelName;
        }

        public async Task DeleteAsync(int modelId)
        {
            T model = await _set.FindAsync(modelId);

            if (model != null)
            {
                _set.Remove(model);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new EntityNotFoundException(_modelName, modelId);
            }
        }
    }
}
