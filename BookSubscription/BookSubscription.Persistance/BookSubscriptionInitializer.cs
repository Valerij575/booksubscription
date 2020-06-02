using BookSubscription.Domain.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;

namespace BookSubscription.Persistance
{
    public class BookSubscriptionInitializer
    {
        private readonly Dictionary<int, Book> Books = new Dictionary<int, Book>();
        private readonly Dictionary<int, Category> Categories = new Dictionary<int, Category>();

        public static void Initialize(BookSubscriptionDbContext context)
        {
            var initializer = new BookSubscriptionInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(BookSubscriptionDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Categories.Any())
            {
                SeedCategories(context);
            }

            if (!context.Books.Any())
            {
                SeedBooks(context);
            }
            

            
        }

        public void SeedBooks(BookSubscriptionDbContext context)
        {
            Books.Add(1,
                new Book
                {
                    Id = Guid.Parse("D6F2FC85-0D5F-4D90-904F-5BE330D56765"),
                    Name = "Freedom at Midnight",
                    Text = @"In 1947 India gained independence from Britain. The resulting chaos 
                                led some Indian leaders to beseech the British to revoke the new mandate. 
                                Collins and Lapierre examine the decline of the Raj and the roles enacted 
                                by the principal players in the drama.",
                    Price = 22.95M,
                    Category = Categories[1]

                });
            Books.Add(2,
                new Book
                {
                    Id = Guid.Parse("DE8EDEA9-9EB6-45D2-8E09-072ED86E9EBD"),
                    Name = "At Home with the Queen",
                    Text = @"One of our best-informed royal commentators goes behind the scenes at Buckingham Palace 
                                to tell the real story of what goes on inside the royal residences through the eyes 
                                and words of royal staff past and present.",
                    Price = 18.60M,
                    Category = Categories[1]
                });
            Books.Add(3,
                new Book
                {
                    Id = Guid.Parse("A65BB426-F06C-44DD-88B9-BE98CA0D0535"),
                    Name = "City of Djinns A Year in Delhi",
                    Text = @"Alive with the mayhem of the present and sparkling with William Dalrymple's irrepressible wit, 
                                City of Djinns is a fascinating portrait of a city.",
                    Price = 12.00M,
                    Category = Categories[1]
                });
            Books.Add(4,
                new Book
                {
                    Id = Guid.Parse("B4C3EF4B-B7BB-42A2-9159-AEA22114C2B1"),
                    Name = "Linux: the Complete Reference, Sixth Edition",
                    Text = @"Your one-stop guide to Linux--fully revised and expanded Get in-depth coverage of all Linux features, 
                            tools, and utilities from this thoroughly updated and comprehensive resource, 
                            designed for all Linux distributions.",
                    Price = 57.00M,
                    Category = Categories[2]
                });
            Books.Add(5,
                new Book
                {
                    Id = Guid.Parse("4202E2D1-5229-4BD9-9E87-2984ED7A051D"),
                    Name = "Oracle Database 11g DBA Handbook",
                    Text = @"The bestselling, comprehensive guide to Oracle database administration, fully revised for the new releaseThis essential 
                                resource for Oracle DBAs has been completely updated to cover the new features of Oracle
                                Database 11g, the industry standard Web-enabled enterprise database system.",
                    Price = 65.00M,
                    Category = Categories[2]
                });
            Books.Add(6,
                new Book
                {
                    Id = Guid.Parse("CB1249E8-C6DD-49F4-8303-F3CCBA83410B"),
                    Name = "Schaum's Outline of Principles of Computer Science",
                    Text = @"",
                    Price = 22.00M,
                    Category = Categories[2]
                });

            foreach(var book in Books.Values)
            {
                context.Books.Add(book);
            }

            context.SaveChanges();
        }

        public void SeedCategories(BookSubscriptionDbContext context)
        {
            Categories.Add(1,
                new Category
                {
                    Id = Guid.Parse("73A806AC-45CA-4361-A001-B14A7AA79891"),
                    Title = "History",
                    Description = "Events occurring before the invention of writing systems are considered prehistory."
                });
            Categories.Add(2,
                new Category
                {
                    Id = Guid.Parse("FB8C5CFD-1F31-45C7-A843-0ADD07BA5FAF"),
                    Title = "Computers",
                    Description = "",
                });

            foreach(var category in Categories.Values)
            {
                context.Categories.Add(category);
            }

            context.SaveChanges();
        }
    }
}
