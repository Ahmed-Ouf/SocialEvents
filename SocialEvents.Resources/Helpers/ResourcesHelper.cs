using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SocialEvents.Resources.Helpers
{
    public static class ResourcesHelper
    {
        private static readonly  ResourceManager _resourceManager;
        private static readonly CultureInfo AR;
        private static readonly CultureInfo EN;
        static ResourcesHelper()
        {
            _resourceManager = new ResourceManager(typeof(Resources));
            AR = CultureInfo.CreateSpecificCulture("ar-EG");
            EN = CultureInfo.CreateSpecificCulture("en-US");
        }

        public static string GetAR(string word)
        {
            return _resourceManager.GetString(word, AR);
        }

        public static string GetEn(string word)
        {
            return _resourceManager.GetString(word, EN);
        }
    }
}
