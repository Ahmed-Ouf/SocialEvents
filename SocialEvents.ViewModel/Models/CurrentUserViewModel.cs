using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEvents.ViewModel
{
    public class CurrentUserViewModel
    {
        public string LoginName { get; set; }
        public List<string> Roles { get; set; }
        public string SafeerDepartmentId { get; set; }
    }
}
