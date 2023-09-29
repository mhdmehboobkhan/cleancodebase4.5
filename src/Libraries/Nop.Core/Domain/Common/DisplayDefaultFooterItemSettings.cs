﻿using Nop.Core.Configuration;

namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// Display default menu item settings
    /// </summary>
    public class DisplayDefaultFooterItemSettings : ISettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether to display "sitemap" footer item
        /// </summary>
        public bool DisplaySitemapFooterItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display "contact us" footer item
        /// </summary>
        public bool DisplayContactUsFooterItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display "news" footer item
        /// </summary>
        public bool DisplayNewsFooterItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display "blog" footer item
        /// </summary>
        public bool DisplayBlogFooterItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display "customer info" footer item
        /// </summary>
        public bool DisplayCustomerInfoFooterItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display "customer addresses" footer item
        /// </summary>
        public bool DisplayCustomerAddressesFooterItem { get; set; }
    }
}
