using BookSubscription.Application.Interfaces;
using BookSubscription.Domain.Entities;
using BookSubscription.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSubscription.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly BookSubscriptionDbContext _dbContext;

        public BookService(BookSubscriptionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> AddAsync(Book entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Book> DeleteAsync(Guid id)
        {
            var entity = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
            if(entity == null)
            {
                return entity;
            }

            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var books = await _dbContext.Books.ToListAsync();

            return books;
        }

        public async Task<Book> GetAsync(Guid id)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
