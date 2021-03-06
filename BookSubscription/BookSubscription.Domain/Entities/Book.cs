﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSubscription.Domain.Entities
{
    [Table("Book")]
    public class Book : IEntity
    {
        /// <summary>
        /// Gets or sets a book id.
        /// </summary>
        [Key]
        [Column("BookId")]
        public Guid Id { get ; set; }

        /// <summary>
        /// Gets or sets a category id.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or sets book name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets book title.
        /// </summary>
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets book price.
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        public Category Category { get; set; }
    }
}
