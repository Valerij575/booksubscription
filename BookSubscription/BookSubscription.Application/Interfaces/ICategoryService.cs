using BookSubscription.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSubscription.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetAsync(Guid id);
        Task<Category> AddAsync(Category entity);
        Task<Category> UpdateAsync(Category entity);
        Task<Category> DeleteAsync(Guid id);
    }
}
