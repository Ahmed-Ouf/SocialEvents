﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocialEvents.DmzService.EventWCFServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EventWCFServiceRef.IEventWCFService")]
    public interface IEventWCFService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEventWCFService/GetEvents", ReplyAction="http://tempuri.org/IEventWCFService/GetEventsResponse")]
        System.Collections.Generic.List<SocialEvents.ViewModel.EventViewModel> GetEvents();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEventWCFServiceChannel : SocialEvents.DmzService.EventWCFServiceRef.IEventWCFService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EventWCFServiceClient : System.ServiceModel.ClientBase<SocialEvents.DmzService.EventWCFServiceRef.IEventWCFService>, SocialEvents.DmzService.EventWCFServiceRef.IEventWCFService {
        
        public EventWCFServiceClient() {
        }
        
        public EventWCFServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EventWCFServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EventWCFServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EventWCFServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<SocialEvents.ViewModel.EventViewModel> GetEvents() {
            return base.Channel.GetEvents();
        }
    }
}
