using BookSubscription.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSubscription.Application.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetAsync(Guid id);
        Task<Book> AddAsync(Book entity);
        Task<Book> UpdateAsync(Book entity);
        Task<Book> DeleteAsync(Guid id);
    }
}
