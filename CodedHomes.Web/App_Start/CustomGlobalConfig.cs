using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CodedHomes.Web.Filters;

namespace CodedHomes.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomGlobalConfig
    {
        /// <summary>
        /// Customizes the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Customize(HttpConfiguration config)
        {
            config.Filters.Add(new ValidationActionFilter());
        }
    }
}