using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationTracker.Models;

namespace LocationTracker.Data
{
    public class DbInitializer
    {
        public static void Initialize(TrackerContext context)
        {
            context.Database.EnsureCreated();

            if(context.Location.Any())
            {
                return;
            }

            var locations = new Location[]
            {
                new Location{LocationCode = "MY9"},
                new Location{LocationCode = "B89"}
            };
            foreach (Location l in locations)
            {
                context.Location.Add(l);
            }
            context.SaveChanges();

            var divisions = new Division[]
            {
                new Division{DivisionName="Carbohydrate Solutions"},
                new Division{DivisionName = "Nutrition"},
                new Division{DivisionName = "Oilseeds"},
                new Division{DivisionName = "Origination"},
                new Division{DivisionName = "Other"}
            };

            foreach (Division d in divisions)
            {
                context.Division.Add(d);
            }
            context.SaveChanges();

            var addresses = new Address[]
            {
                new Address{StateProvince = "IL", Country = "US"}
            };
            foreach (Address a in addresses)
            {
                context.Address.Add(a);
            }

            context.SaveChanges();
        }
    }
}
