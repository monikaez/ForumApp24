using ForumApp24.Core.Contracts;
using ForumApp24.Core.Models;
using ForumApp24.Infrastructure.Data;
using ForumApp24.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp24.Core.Services
{
    public class PostService : IPostService
    {
        private readonly Forum24DbContext context;
        public PostService(Forum24DbContext _context)
        {
            context = _context;
        }

        public async Task AddAsync(PostModel model)
        {
            var entity = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };
            await context.AddAsync(entity); 
            await context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetEntityById(id);

            context.Remove(entity); 
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(PostModel model)
        {
            var entity =await GetEntityById(model.Id);
            entity.Title = model.Title;
            entity.Content = model.Content;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostModel>> GetAllPostsAsync()
        {
            return await context.Posts.Select(x => new PostModel()
            {
                Content = x.Content,
                Id = x.Id,
                Title = x.Title,
            }).AsNoTracking()
            .ToListAsync();  
         }

        public async Task<PostModel?> GetByIdAsync(int id)
        {
            return await context.Posts.Where(p => p.Id== id)
                .Select(p => new PostModel()
                {
                    Id= p.Id,
                    Title = p.Title,
                    Content = p.Content
                }).AsNoTracking().FirstOrDefaultAsync();
        }
        private async Task<Post> GetEntityById(int id)
        {
            var entity = await context.FindAsync<Post>(id);
            if (entity == null)
            {
                throw new ApplicationException("Invalid Post");
            }
            return entity;
        }

       
    }
}
