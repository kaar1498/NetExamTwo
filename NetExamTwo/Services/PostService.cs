using NetExamTwo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetExamTwo.Services
{
    public class PostService
    {
        private readonly NetExamTwoContext _context;

        public PostService(NetExamTwoContext context)
        {
            _context = context;
        }

        public async Task<T> PostAsync<T>(T postObject)
        {
            await _context.AddAsync(postObject);
            await _context.SaveChangesAsync();

            return postObject;
        }
    }
}
