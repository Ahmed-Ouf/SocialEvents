﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocialEvents.Service.EdmsServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:rcjgen", ConfigurationName="EdmsServiceRef.WSESRCJGeneral")]
    public interface WSESRCJGeneral {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.DataContractFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="createRecordReturn")]
        string createRecord(string username, string password, string doctypeName, string parentDoctypeName, string sXmlAttributes, byte[] attachment, string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.DataContractFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc)]
        void updateRecord(string username, string password, string doctypeName, string parentDoctypeName, string recordKey, string sXmlAttributes);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.DataContractFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc)]
        void deleteRecord(string username, string password, string doctypeName, string parentDoctypeName, string recordKey);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.DataContractFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="searchRecordsReturn")]
        string searchRecords(string username, string password, string doctypeName, string parentDoctypeName, string query, string currentPage, string pageCount);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.DataContractFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="searchGISRecordsReturn")]
        string searchGISRecords(string username, string password, string doctypeName, string parentDoctypeName, string processcode, string processkeyno, string currentPage, string pageCount);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.DataContractFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="addAttachmentReturn")]
        string addAttachment(string username, string password, string doctypeName, string parentDoctypeName, string recordKey, byte[] attachment, string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.DataContractFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="updateAttachmentReturn")]
        string updateAttachment(string username, string password, string doctypeName, string parentDoctypeName, string recordKey, string attachmentKey, byte[] attachment, string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.DataContractFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="downloadAttachmentReturn")]
        byte[] downloadAttachment(string username, string password, string doctypeName, string parentDoctypeName, string recordKey, string attachmentKey);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.DataContractFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="downloadFirstAttachmentReturn")]
        byte[] downloadFirstAttachment(string username, string password, string doctypeName, string parentDoctypeName, string recordKey);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.DataContractFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc)]
        void deleteAttachment(string username, string password, string doctypeName, string parentDoctypeName, string recordKey, string attachmentKey);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://ws.es) of message authenticateRequest does not match the default value (urn:rcjgen)
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        SocialEvents.Service.EdmsServiceRef.authenticateResponse authenticate(SocialEvents.Service.EdmsServiceRef.authenticateRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="authenticate", WrapperNamespace="http://ws.es", IsWrapped=true)]
    public partial class authenticateRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string sUserCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string sPassWord;
        
        public authenticateRequest() {
        }
        
        public authenticateRequest(string sUserCode, string sPassWord) {
            this.sUserCode = sUserCode;
            this.sPassWord = sPassWord;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="authenticateResponse", WrapperNamespace="urn:rcjgen", IsWrapped=true)]
    public partial class authenticateResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string authenticateReturn;
        
        public authenticateResponse() {
        }
        
        public authenticateResponse(string authenticateReturn) {
            this.authenticateReturn = authenticateReturn;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WSESRCJGeneralChannel : SocialEvents.Service.EdmsServiceRef.WSESRCJGeneral, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WSESRCJGeneralClient : System.ServiceModel.ClientBase<SocialEvents.Service.EdmsServiceRef.WSESRCJGeneral>, SocialEvents.Service.EdmsServiceRef.WSESRCJGeneral {
        
        public WSESRCJGeneralClient() {
        }
        
        public WSESRCJGeneralClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WSESRCJGeneralClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSESRCJGeneralClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSESRCJGeneralClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string createRecord(string username, string password, string doctypeName, string parentDoctypeName, string sXmlAttributes, byte[] attachment, string fileName) {
            return base.Channel.createRecord(username, password, doctypeName, parentDoctypeName, sXmlAttributes, attachment, fileName);
        }
        
        public void updateRecord(string username, string password, string doctypeName, string parentDoctypeName, string recordKey, string sXmlAttributes) {
            base.Channel.updateRecord(username, password, doctypeName, parentDoctypeName, recordKey, sXmlAttributes);
        }
        
        public void deleteRecord(string username, string password, string doctypeName, string parentDoctypeName, string recordKey) {
            base.Channel.deleteRecord(username, password, doctypeName, parentDoctypeName, recordKey);
        }
        
        public string searchRecords(string username, string password, string doctypeName, string parentDoctypeName, string query, string currentPage, string pageCount) {
            return base.Channel.searchRecords(username, password, doctypeName, parentDoctypeName, query, currentPage, pageCount);
        }
        
        public string searchGISRecords(string username, string password, string doctypeName, string parentDoctypeName, string processcode, string processkeyno, string currentPage, string pageCount) {
            return base.Channel.searchGISRecords(username, password, doctypeName, parentDoctypeName, processcode, processkeyno, currentPage, pageCount);
        }
        
        public string addAttachment(string username, string password, string doctypeName, string parentDoctypeName, string recordKey, byte[] attachment, string fileName) {
            return base.Channel.addAttachment(username, password, doctypeName, parentDoctypeName, recordKey, attachment, fileName);
        }
        
        public string updateAttachment(string username, string password, string doctypeName, string parentDoctypeName, string recordKey, string attachmentKey, byte[] attachment, string fileName) {
            return base.Channel.updateAttachment(username, password, doctypeName, parentDoctypeName, recordKey, attachmentKey, attachment, fileName);
        }
        
        public byte[] downloadAttachment(string username, string password, string doctypeName, string parentDoctypeName, string recordKey, string attachmentKey) {
            return base.Channel.downloadAttachment(username, password, doctypeName, parentDoctypeName, recordKey, attachmentKey);
        }
        
        public byte[] downloadFirstAttachment(string username, string password, string doctypeName, string parentDoctypeName, string recordKey) {
            return base.Channel.downloadFirstAttachment(username, password, doctypeName, parentDoctypeName, recordKey);
        }
        
        public void deleteAttachment(string username, string password, string doctypeName, string parentDoctypeName, string recordKey, string attachmentKey) {
            base.Channel.deleteAttachment(username, password, doctypeName, parentDoctypeName, recordKey, attachmentKey);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SocialEvents.Service.EdmsServiceRef.authenticateResponse SocialEvents.Service.EdmsServiceRef.WSESRCJGeneral.authenticate(SocialEvents.Service.EdmsServiceRef.authenticateRequest request) {
            return base.Channel.authenticate(request);
        }
        
        public string authenticate(string sUserCode, string sPassWord) {
            SocialEvents.Service.EdmsServiceRef.authenticateRequest inValue = new SocialEvents.Service.EdmsServiceRef.authenticateRequest();
            inValue.sUserCode = sUserCode;
            inValue.sPassWord = sPassWord;
            SocialEvents.Service.EdmsServiceRef.authenticateResponse retVal = ((SocialEvents.Service.EdmsServiceRef.WSESRCJGeneral)(this)).authenticate(inValue);
            return retVal.authenticateReturn;
        }
    }
}
