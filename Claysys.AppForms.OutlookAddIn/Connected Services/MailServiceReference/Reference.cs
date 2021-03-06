﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Claysys.AppForms.OutlookAddIn.MailServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MailServiceReference.IMailService")]
    public interface IMailService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMailService/InsertMailBody", ReplyAction="http://tempuri.org/IMailService/InsertMailBodyResponse")]
        bool InsertMailBody(string from, string to, string subject, string body);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMailService/InsertMailBody", ReplyAction="http://tempuri.org/IMailService/InsertMailBodyResponse")]
        System.Threading.Tasks.Task<bool> InsertMailBodyAsync(string from, string to, string subject, string body);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMailService/GetTargetMailId", ReplyAction="http://tempuri.org/IMailService/GetTargetMailIdResponse")]
        string GetTargetMailId();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMailService/GetTargetMailId", ReplyAction="http://tempuri.org/IMailService/GetTargetMailIdResponse")]
        System.Threading.Tasks.Task<string> GetTargetMailIdAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMailServiceChannel : Claysys.AppForms.OutlookAddIn.MailServiceReference.IMailService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MailServiceClient : System.ServiceModel.ClientBase<Claysys.AppForms.OutlookAddIn.MailServiceReference.IMailService>, Claysys.AppForms.OutlookAddIn.MailServiceReference.IMailService {
        
        public MailServiceClient() {
        }
        
        public MailServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MailServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MailServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MailServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool InsertMailBody(string from, string to, string subject, string body) {
            return base.Channel.InsertMailBody(from, to, subject, body);
        }
        
        public System.Threading.Tasks.Task<bool> InsertMailBodyAsync(string from, string to, string subject, string body) {
            return base.Channel.InsertMailBodyAsync(from, to, subject, body);
        }
        
        public string GetTargetMailId() {
            return base.Channel.GetTargetMailId();
        }
        
        public System.Threading.Tasks.Task<string> GetTargetMailIdAsync() {
            return base.Channel.GetTargetMailIdAsync();
        }
    }
}
