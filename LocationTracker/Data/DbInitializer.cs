using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationTracker.Data
{
    public class DbInitializer
    {
        public static void Initialize(TrackerContext context)
        {
            context.Database.Migrate();

            InitializeLocations(context);
            InitializeDivisions(context);
            InitializeAddresses(context);
            InitializeStudies(context);
            InitializeStatuses(context);
            InitializeStudyTypes(context);
            InitializeBusinessUnits(context);
            InitializeAssessments(context);
            InitializeCountries(context);
            InitializeSubdivisions(context);
            InitializeVendors(context);
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
                new BusinessUnit{DivisionID = 2, BusinessUnitName = "Alliance Nutrition"},
                new BusinessUnit{DivisionID = 4, BusinessUnitName = "ARTCO - American River Transport Company"},
                new BusinessUnit{DivisionID = 1, BusinessUnitName = "Corn"},
                new BusinessUnit{DivisionID = 5, BusinessUnitName = "Corporate"},
                new BusinessUnit{DivisionID = 4, BusinessUnitName = "Edible Bean"},
                new BusinessUnit{DivisionID = 4, BusinessUnitName = "GPC - Golden Peanut Company"},
                new BusinessUnit{DivisionID = 4, BusinessUnitName = "Grain"},
                new BusinessUnit{DivisionID = 1, BusinessUnitName = "Milling"},
                new BusinessUnit{DivisionID = 3, BusinessUnitName = "Oilseeds"},
                new BusinessUnit{DivisionID = 5, BusinessUnitName = "Research"},
                new BusinessUnit{DivisionID = 4, BusinessUnitName = "Stratas Foods"},
                new BusinessUnit{DivisionID = 4, BusinessUnitName = "Transportation"},
                new BusinessUnit{DivisionID = 2, BusinessUnitName = "WFSI - WILD Flavors and Specialty Ingredients"}
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

        public static void InitializeStatuses(TrackerContext context)
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

        public static void InitializeStudyTypes(TrackerContext context)
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
        public static void InitializeAssessments(TrackerContext context)
        {
            if (context.Assessment.Any())
            {
                return;
            }

            var assessments = new Assessment[]
            {
            };

            foreach (Assessment a in assessments)
            {
                context.Assessment.Add(a);
            }

            context.SaveChanges();
        }

        public static void InitializeCountries(TrackerContext context)
        {
            if (context.Country.Any())
            {
                return;
            }

            var countries = new Country[]
            {
            };

            foreach (Country c in countries)
            {
            }
        }

        public static void InitializeSubdivisions(TrackerContext context)
        {
            if (context.Subdivision.Any())
            {
                return;
            }

            var subdivisions = new Subdivision[]
            {
            };

            foreach (Subdivision s in subdivisions)
            {
            }
        }

        public static void InitializeVendors(TrackerContext context)
        {
            if(context.Vendor.Any())
            {
                return;
            }

            var vendors = new Vendor[]
            {
            };

            foreach(Vendor v in vendors)
            {
                context.Vendor.Add(v);
            }
            context.SaveChanges();
        }
    }
}
