using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CodedHomes.Models;

namespace CodedHomes.Data.Configuration
{
    public class CustomDatabaseInitializer : 
        DropCreateDatabaseIfModelChanges<DataContext>
        // CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            string[] descriptions = new string[] 
            {
                "Nice neighborhood with nice trees.",
                "Nice crap with dealers and drugs.",
                "A beatiful home!.",
                "A quite street.",
                "What a nice view!.",
                "Ridiculously confortable.",
                "Close to malls.",
                "Close to schools.",
                "Close to bar´s.",
                "Includes pool, tennis and basketball court"
            };

            int count = 10;
            while (count-- != 0)
            {
                Home home = new Home()
                {
                    StreetAddress = string.Format("12{0} Street St.", count),
                    City = "Anytown",
                    ZipCode = 90210,
                    Bedrooms = count % 2 == 1 ? 4 : 3,
                    SquareFeet = 3700 + count,
                    Price = 275000 + (count * 1000),
                    ImageName = string.Format("home-{0}.jpg", count % 2 == 1 ? "1" : "2"),
                    Description = descriptions[count]
                };
                home.Bathrooms = home.Bedrooms - 2;
                context.Homes.Add(home);
            }

            base.Seed(context);
        }
    }
}
