using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodedHomes.Models;

namespace CodedHomes.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class HomesRepository : GenericRepository<Home>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomesRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public HomesRepository(DbContext context)
            : base(context)
        {
        }
    }
}
