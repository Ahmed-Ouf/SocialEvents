﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocialEvents.DmzService.AnnouncementWCFServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AnnouncementWCFServiceRef.IAnnouncementWCFService")]
    public interface IAnnouncementWCFService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAnnouncementWCFService/GetAnnouncements", ReplyAction="http://tempuri.org/IAnnouncementWCFService/GetAnnouncementsResponse")]
        System.Collections.Generic.List<SocialEvents.ViewModel.AnnouncementViewModel> GetAnnouncements();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAnnouncementWCFServiceChannel : SocialEvents.DmzService.AnnouncementWCFServiceRef.IAnnouncementWCFService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AnnouncementWCFServiceClient : System.ServiceModel.ClientBase<SocialEvents.DmzService.AnnouncementWCFServiceRef.IAnnouncementWCFService>, SocialEvents.DmzService.AnnouncementWCFServiceRef.IAnnouncementWCFService {
        
        public AnnouncementWCFServiceClient() {
        }
        
        public AnnouncementWCFServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AnnouncementWCFServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AnnouncementWCFServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AnnouncementWCFServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<SocialEvents.ViewModel.AnnouncementViewModel> GetAnnouncements() {
            return base.Channel.GetAnnouncements();
        }
    }
}
