using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEvents.Web.ViewModels
{
    public class ChartItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int Count { get; set; }
    }
}
