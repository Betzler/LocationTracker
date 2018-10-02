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

            InitializeLocations(context);
            InitializeDivisions(context);
            InitializeAddresses(context);
            InitializeStudies(context);
            InitializeStatus(context);
            InitializeStudyType(context);
            InitializeBusinessUnits(context);

            context.SaveChangesAsync();
        }

        public static void InitializeLocations(TrackerContext context)
        {
            if (context.Location.Any())
            {
                return;
            }

            var locations = new Location[]
            {
            };

            foreach (Location l in locations)
            {
            }
        }

        public static void InitializeDivisions(TrackerContext context)
        {
            if (context.Division.Any())
            {
                return;
            }

            var divisions = new Division[]
            {
                new Division{DivisionName = "Carbohydrate Solutions"},
                new Division{DivisionName = "Nutrition"},
                new Division{DivisionName = "Oilseeds"},
                new Division{DivisionName = "Origination"},
                new Division{DivisionName = "Other"}
            };

            foreach (Division d in divisions)
            {
                context.Division.Add(d);
            }
        }

        public static void InitializeBusinessUnits(TrackerContext context)
        {
            if (context.BusinessUnit.Any())
            {
                return;
            }

            var businessUnits = new BusinessUnit[]
            {
                new BusinessUnit{BusinessUnitName = "Alliance Nutrition"},
                new BusinessUnit{BusinessUnitName = "ARTCO - American River Transport Company"},
                new BusinessUnit{BusinessUnitName = "Corn"},
                new BusinessUnit{BusinessUnitName = "Corporate"},
                new BusinessUnit{BusinessUnitName = "Edible Bean"},
                new BusinessUnit{BusinessUnitName = "GPC - Golden Peanut Company"},
                new BusinessUnit{BusinessUnitName = "Grain"},
                new BusinessUnit{BusinessUnitName = "Milling"},
                new BusinessUnit{BusinessUnitName = "Oilseeds"},
                new BusinessUnit{BusinessUnitName = "Research"},
                new BusinessUnit{BusinessUnitName = "Stratas Foods"},
                new BusinessUnit{BusinessUnitName = "Transportation"},
                new BusinessUnit{BusinessUnitName = "WFSI - WILD Flavors and Specialty Ingredients"}
            };

            foreach (BusinessUnit b in businessUnits)
            {
                context.BusinessUnit.Add(b);
            }
            context.SaveChanges();
        }
        public static void InitializeAddresses(TrackerContext context)
        {
            if (context.Address.Any())
            {
                return;
            }

            var addresses = new Address[]
            {
            };

            foreach (Address a in addresses)
            {
            }

            context.SaveChanges();
        }

        public static void InitializeStudies(TrackerContext context)
        {
            if (context.Study.Any())
            {
                return;
            }

            var studies = new Study[]
            {
            };

            foreach (Study s in studies)
            {
                context.Study.Add(s);
            }

            context.SaveChanges();
        }

        public static void InitializeStatus(TrackerContext context)
        {
            if (context.Status.Any())
            {
                return;
            }

            var statuses = new Status[]
            {
                new Status{StatusName = "Not Started" },
                new Status{StatusName = "In Progress"},
                new Status{StatusName = "On Hold"},
                new Status {StatusName = "Completed"}
            };

            foreach (Status s in statuses)
            {
                context.Status.Add(s);
            }

            context.SaveChanges();
        }

        public static void InitializeStudyType(TrackerContext context)
        {
            if (context.StudyType.Any())
            {
                return;
            }

            var studyTypes = new StudyType[]
            {
                new StudyType{StudyTypeName = "Original" },
                new StudyType{StudyTypeName = "Update"},

            };

            foreach (StudyType s in studyTypes)
            {
                context.StudyType.Add(s);
            }

            context.SaveChanges();
        }
    
    }
}
