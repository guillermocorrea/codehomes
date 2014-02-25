using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodedHomes.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CodedHomes.Web.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class HomesListViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the homes.
        /// </summary>
        /// <value>
        /// The homes.
        /// </value>
        public IList<Home> Homes { get; set; }

        /// <summary>
        /// Gets the homes json.
        /// </summary>
        /// <value>
        /// The homes json.
        /// </value>
        public string HomesJson
        {
            get
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                var homes = JsonConvert.SerializeObject(this.Homes, settings);
                return homes;
            }
        }

        /// <summary>
        /// Gets the images URL prefix.
        /// </summary>
        /// <value>
        /// The images URL prefix.
        /// </value>
        public string ImagesUrlPrefix
        {
            get
            {
                return CodedHomes.Web.Infraestructure.Config.ImagesUrlPrefix;
            }
        }
    }
}