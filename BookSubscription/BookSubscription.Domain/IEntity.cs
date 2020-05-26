using System;

namespace BookSubscription.Domain
{
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets a Id model
        /// </summary>
        Guid Id { get; set; }
    }
}
