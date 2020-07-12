using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AutoMapper;
using SocialEvents.Model;
using SocialEvents.Service;
using SocialEvents.ViewModel;

namespace SocialEvents.WCFService
{
    public class TargetGroupWCFService : ITargetGroupWCFService
    {

        private readonly ITargetGroupService _TargetGroupService;
        private readonly IMapper _mapper;
        public TargetGroupWCFService(ITargetGroupService targetGroupService , IMapper mapper)
        {
            _TargetGroupService = targetGroupService;
            _mapper = mapper;
        }

        public IEnumerable<TargetGroupViewModel> GetTargetGroups()
        {
            var entities = _TargetGroupService.GetAllAtive().ToList();
            var models = _mapper.Map<List<TargetGroup>, List<TargetGroupViewModel>>(entities);
            return models;
        }
    }
}
