using System;

namespace BookSubscription.Infrastructure.Configurations.Options
{
    public class SwaggerOptions
    {
        /// <summary>
        /// Get or set a version
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Get or set a url format
        /// </summary>
        public string UrlFormat { get; set; }

        /// <summary>
        /// Get or set a title of swagger
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Get or set a decription of swagger
        /// </summary>
        public string Description { get; set; }

        public Contract Contract { get; set; }
    }

    public class Contract
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Uri Url { get; set; }
    }
}
