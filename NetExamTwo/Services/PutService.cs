using Microsoft.EntityFrameworkCore;
using NetExamTwo.Data;
using NetExamTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetExamTwo.Services
{
    public class PutService<T> where T : class
    {
        private readonly NetExamTwoContext _context;
        private readonly DbSet<T> _set;

        public PutService(NetExamTwoContext context, DbSet<T> set)
        {
            _context = context;
            _set = set;
        }

        public async Task<bool> PutAsync(
            IModel modelToPut,
            int objectId)
        {
            bool hasOverwritten = false;
            modelToPut.Id = objectId;

            T existingModel = await _set.FindAsync(objectId);

            if (existingModel == null)
            {
                await AddModelAsync(modelToPut);
            }
            else
            {
                await OverwriteExistingModel(modelToPut, existingModel);
                hasOverwritten = true;
            }

            return hasOverwritten;
        }

        private async Task AddModelAsync(IModel modelToPut)
        {
            await _context.AddAsync(modelToPut);
            await _context.SaveChangesAsync();
        }


        private async Task OverwriteExistingModel(IModel modelToPut, T existingModel)
        {
            _context.Remove(existingModel);
            await AddModelAsync(modelToPut);
        }
    }
}
