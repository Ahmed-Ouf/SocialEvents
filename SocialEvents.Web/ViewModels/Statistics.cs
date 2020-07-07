using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEvents.Web.ViewModels
{
    public class Statistics
    {
        public List<ChartItem> TargetGroups { get; set; }
        public List<ChartItem> Cateogries { get; set; }
        public List<ChartItem> Locations { get; set; }
        public List<ChartItem> MonthEvents { get; set; }
        public List<SocialEvents.Model.Event> Events { get; set; }
        public List<SocialEvents.Model.Event> CommingEvents { get; set; }
    }
}
