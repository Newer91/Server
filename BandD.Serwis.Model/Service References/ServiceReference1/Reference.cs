﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BandD.Serwis.Model.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IDictionariesService")]
    public interface IDictionariesService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDictionariesService/getDataFromSlOrderStat", ReplyAction="http://tempuri.org/IDictionariesService/getDataFromSlOrderStatResponse")]
        BandD.Serwis.Class.SlOrderStat[] getDataFromSlOrderStat(string name, bool activity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDictionariesService/getDataFromSlOrderStat", ReplyAction="http://tempuri.org/IDictionariesService/getDataFromSlOrderStatResponse")]
        System.Threading.Tasks.Task<BandD.Serwis.Class.SlOrderStat[]> getDataFromSlOrderStatAsync(string name, bool activity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDictionariesServiceChannel : BandD.Serwis.Model.ServiceReference1.IDictionariesService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DictionariesServiceClient : System.ServiceModel.ClientBase<BandD.Serwis.Model.ServiceReference1.IDictionariesService>, BandD.Serwis.Model.ServiceReference1.IDictionariesService {
        
        public DictionariesServiceClient() {
        }
        
        public DictionariesServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DictionariesServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DictionariesServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DictionariesServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public BandD.Serwis.Class.SlOrderStat[] getDataFromSlOrderStat(string name, bool activity) {
            return base.Channel.getDataFromSlOrderStat(name, activity);
        }
        
        public System.Threading.Tasks.Task<BandD.Serwis.Class.SlOrderStat[]> getDataFromSlOrderStatAsync(string name, bool activity) {
            return base.Channel.getDataFromSlOrderStatAsync(name, activity);
        }
    }
}
