﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocialEvents.MobileApi.CategoryDmzServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CategoryDmzServiceRef.ICategoryWCFService")]
    public interface ICategoryWCFService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryWCFService/GetCategories", ReplyAction="http://tempuri.org/ICategoryWCFService/GetCategoriesResponse")]
        System.Collections.Generic.List<SocialEvents.ViewModel.CategoryViewModel> GetCategories();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICategoryWCFServiceChannel : SocialEvents.MobileApi.CategoryDmzServiceRef.ICategoryWCFService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CategoryWCFServiceClient : System.ServiceModel.ClientBase<SocialEvents.MobileApi.CategoryDmzServiceRef.ICategoryWCFService>, SocialEvents.MobileApi.CategoryDmzServiceRef.ICategoryWCFService {
        
        public CategoryWCFServiceClient() {
        }
        
        public CategoryWCFServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CategoryWCFServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CategoryWCFServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CategoryWCFServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<SocialEvents.ViewModel.CategoryViewModel> GetCategories() {
            return base.Channel.GetCategories();
        }
    }
}
