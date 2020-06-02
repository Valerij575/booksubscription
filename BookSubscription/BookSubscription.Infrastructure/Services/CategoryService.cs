using BookSubscription.Application.Interfaces;
using BookSubscription.Domain.Entities;
using BookSubscription.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSubscription.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BookSubscriptionDbContext _dbContext;

        public CategoryService(BookSubscriptionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> AddAsync(Category entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Category> DeleteAsync(Guid id)
        {
            var entity = await _dbContext.Categories.FirstOrDefaultAsync(b => b.Id == id);
            if (entity == null)
            {
                return entity;
            }

            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var categories = await _dbContext.Categories.ToListAsync();

            return categories;
        }

        public async Task<Category> GetAsync(Guid id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
