using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationTracker.Models.ViewModels
{
    public class StudyHistoryGraphViewModel
    {
        public string[] Labels { get; set; }
        public int?[] UnderratedData { get; set; }
        public int?[] ArcFlashData { get; set; }
        public int?[] EquipmentProtectionData { get; set; }
    }

}
