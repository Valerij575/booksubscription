using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookSubscription.Domain.Entities
{
    [Table("BookCategory")]
    public class BookCategory : IEntity
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }
        
        [ForeignKey("CategiryId")]
        public Guid CategoryId { get; set; }

        [ForeignKey("BookId")]
        public Guid BookId { get; set; }

        public Category Category { get; set; }

        public Book Book { get; set; }
    }
}
