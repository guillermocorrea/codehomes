using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CodedHomes.Web.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleEvaluator
    {
        /// <summary>
        /// Gets a value indicating whether [can edit].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [can edit]; otherwise, <c>false</c>.
        /// </value>
        public bool CanEdit { 
            get 
            {
                return Roles.IsUserInRole("admin") ||
                    Roles.IsUserInRole("manager") ||
                    Roles.IsUserInRole("user");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [can delete].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [can delete]; otherwise, <c>false</c>.
        /// </value>
        public bool CanDelete
        {
            get
            {
                return Roles.IsUserInRole("admin") ||
                    Roles.IsUserInRole("manager");
            }
        }
    }
}