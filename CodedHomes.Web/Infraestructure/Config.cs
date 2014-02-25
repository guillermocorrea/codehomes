using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CodedHomes.Web.Infraestructure
{
    /// <summary>
    /// 
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Gets the images folder path.
        /// </summary>
        /// <value>
        /// The images folder path.
        /// </value>
        public static string ImagesFolderPath
        {
            get
            {
                if (ConfigurationManager.AppSettings["ImagesFolderPath"] != null)
                {
                    return ConfigurationManager.AppSettings["ImagesFolderPath"] as string;
                }

                return "~/img/homes/";
            }
        }

        /// <summary>
        /// Gets the images URL prefix.
        /// </summary>
        /// <value>
        /// The images URL prefix.
        /// </value>
        public static string ImagesUrlPrefix
        {
            get
            {
                return Config.ImagesFolderPath.Replace("~", ""); 
            }
        }

        /// <summary>
        /// Gets the name of the connection string.
        /// </summary>
        /// <value>
        /// The name of the connection string.
        /// </value>
        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                {
                    return ConfigurationManager.AppSettings["ConnectionStringName"] as string;
                }

                return "DefaultConnection";
            }
        }

        /// <summary>
        /// Gets the name of the users table.
        /// </summary>
        /// <value>
        /// The name of the users table.
        /// </value>
        public static string UsersTableName
        {
            get
            {
                if (ConfigurationManager.AppSettings["UsersTableName"] != null)
                {
                    return ConfigurationManager.AppSettings["UsersTableName"] as string;
                }

                return "Users";
            }
        }

        /// <summary>
        /// Gets the name of the users primary key column.
        /// </summary>
        /// <value>
        /// The name of the users primary key column.
        /// </value>
        public static string UsersPrimaryKeyColumnName
        {
            get
            {
                if (ConfigurationManager.AppSettings["UsersPrimaryKeyColumnName"] != null)
                {
                    return ConfigurationManager.AppSettings["UsersPrimaryKeyColumnName"] as string;
                }

                return "Id";
            }
        }


        /// <summary>
        /// Gets the name of the users username column.
        /// </summary>
        /// <value>
        /// The name of the users username column.
        /// </value>
        public static string UsersUsernameColumnName
        {
            get
            {
                if (ConfigurationManager.AppSettings["UsersUsernameColumnName"] != null)
                {
                    return ConfigurationManager.AppSettings["UsersUsernameColumnName"] as string;
                }

                return "Username";
            }
        }
    }
}