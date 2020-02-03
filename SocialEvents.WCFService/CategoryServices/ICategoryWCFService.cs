﻿using System.Collections.Generic;
using System.ServiceModel;
using vm = SocialEvents.ViewModel;

namespace SocialEvents.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICategoryWCFService
    {

        [OperationContract]
        IEnumerable<vm.Category> GetCategories();

    }

}