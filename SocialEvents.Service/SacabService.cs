using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialEvents.Service
{
    public interface ISacabService
    {
        List<SacabServiceRef.UserApplicationRoles> GetUserRolesByUserName(string userName);
    }

    public class SacabService : ISacabService
    {
        private readonly SacabServiceRef.SacabServiceClient sacabService;
        public SacabService()
        {
            sacabService = new SacabServiceRef.SacabServiceClient();
        }


        public List<SacabServiceRef.UserApplicationRoles> GetUserRolesByUserName(string userName)
        {
            var result = sacabService.GetUserRolesByAppIdAndUserName_Production(37, userName);
            return result;
        }
    }
}
