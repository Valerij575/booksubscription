using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSubscription.Domain.Entities
{
    [Table("Category")]
    public class Category : IEntity
    {
        public Category()
        {
            BookCategories = new HashSet<BookCategory>();
        }

        /// <summary>
        /// Gets ot sets a Category Id
        /// </summary>
        [Key]
        [Column("CategoryId")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a title category
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a description category
        /// </summary>
        [Required]
        public string Description { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
