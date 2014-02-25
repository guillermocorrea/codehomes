using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodedHomes.Models;

namespace CodedHomes.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationUnit : IDisposable
    {
        /// <summary>
        /// The _context
        /// </summary>
        private DataContext _context = new DataContext();

        /// <summary>
        /// The _homes
        /// </summary>
        private IRepository<Home> _homes = null;
        /// <summary>
        /// The _users
        /// </summary>
        private IRepository<User> _users = null;

        /// <summary>
        /// Gets the homes.
        /// </summary>
        /// <value>
        /// The homes.
        /// </value>
        public IRepository<Home> Homes 
        { 
            get 
            {
                if (_homes == null)
                {
                    _homes = new GenericRepository<Home>(_context);
                }

                return _homes;
            } 
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public IRepository<User> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new GenericRepository<User>(_context);
                }

                return _users;
            }
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._context != null)
            {
                this._context.Dispose();
            }
        }
    }
}
