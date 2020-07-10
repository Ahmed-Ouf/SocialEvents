using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEvents.Service.Helpers
{
   
        public static class ConfigrationHelper
        {
            public static string FirebaseServiceFile = ConfigurationManager.AppSettings["FirebaseServiceFile"];
        }
}
