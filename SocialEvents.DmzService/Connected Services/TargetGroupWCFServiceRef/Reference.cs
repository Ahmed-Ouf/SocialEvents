﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocialEvents.DmzService.TargetGroupWCFServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TargetGroupWCFServiceRef.ITargetGroupWCFService")]
    public interface ITargetGroupWCFService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITargetGroupWCFService/GetTargetGroups", ReplyAction="http://tempuri.org/ITargetGroupWCFService/GetTargetGroupsResponse")]
        System.Collections.Generic.List<SocialEvents.ViewModel.TargetGroupViewModel> GetTargetGroups();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITargetGroupWCFServiceChannel : SocialEvents.DmzService.TargetGroupWCFServiceRef.ITargetGroupWCFService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TargetGroupWCFServiceClient : System.ServiceModel.ClientBase<SocialEvents.DmzService.TargetGroupWCFServiceRef.ITargetGroupWCFService>, SocialEvents.DmzService.TargetGroupWCFServiceRef.ITargetGroupWCFService {
        
        public TargetGroupWCFServiceClient() {
        }
        
        public TargetGroupWCFServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TargetGroupWCFServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TargetGroupWCFServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TargetGroupWCFServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<SocialEvents.ViewModel.TargetGroupViewModel> GetTargetGroups() {
            return base.Channel.GetTargetGroups();
        }
    }
}
