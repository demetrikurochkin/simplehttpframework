﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Xavier.Integration.Tests.CompositionService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PreviewRequest", Namespace="http://schemas.datacontract.org/2004/07/W2P.Xavier.Composition")]
    [System.SerializableAttribute()]
    public partial class PreviewRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EntryIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.Dictionary<string, string> VariableDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EntryID {
            get {
                return this.EntryIDField;
            }
            set {
                if ((object.ReferenceEquals(this.EntryIDField, value) != true)) {
                    this.EntryIDField = value;
                    this.RaisePropertyChanged("EntryID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.Dictionary<string, string> VariableData {
            get {
                return this.VariableDataField;
            }
            set {
                if ((object.ReferenceEquals(this.VariableDataField, value) != true)) {
                    this.VariableDataField = value;
                    this.RaisePropertyChanged("VariableData");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PreviewResponse", Namespace="http://schemas.datacontract.org/2004/07/W2P.Xavier.Composition")]
    [System.SerializableAttribute()]
    public partial class PreviewResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int pagesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Xavier.Integration.Tests.CompositionService.PreviewResources resourcesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string id {
            get {
                return this.idField;
            }
            set {
                if ((object.ReferenceEquals(this.idField, value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int pages {
            get {
                return this.pagesField;
            }
            set {
                if ((this.pagesField.Equals(value) != true)) {
                    this.pagesField = value;
                    this.RaisePropertyChanged("pages");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Xavier.Integration.Tests.CompositionService.PreviewResources resources {
            get {
                return this.resourcesField;
            }
            set {
                if ((object.ReferenceEquals(this.resourcesField, value) != true)) {
                    this.resourcesField = value;
                    this.RaisePropertyChanged("resources");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PreviewResources", Namespace="http://schemas.datacontract.org/2004/07/W2P.Xavier.Composition")]
    [System.SerializableAttribute()]
    public partial class PreviewResources : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Xavier.Integration.Tests.CompositionService.PreviewPage pageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Xavier.Integration.Tests.CompositionService.PreviewPage page {
            get {
                return this.pageField;
            }
            set {
                if ((object.ReferenceEquals(this.pageField, value) != true)) {
                    this.pageField = value;
                    this.RaisePropertyChanged("page");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PreviewPage", Namespace="http://schemas.datacontract.org/2004/07/W2P.Xavier.Composition")]
    [System.SerializableAttribute()]
    public partial class PreviewPage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string imageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string image {
            get {
                return this.imageField;
            }
            set {
                if ((object.ReferenceEquals(this.imageField, value) != true)) {
                    this.imageField = value;
                    this.RaisePropertyChanged("image");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CompositionService.ICompositionService")]
    public interface ICompositionService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompositionService/CreatePreview", ReplyAction="http://tempuri.org/ICompositionService/CreatePreviewResponse")]
        string CreatePreview(Xavier.Integration.Tests.CompositionService.PreviewRequest previewRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompositionService/CreatePreview", ReplyAction="http://tempuri.org/ICompositionService/CreatePreviewResponse")]
        System.Threading.Tasks.Task<string> CreatePreviewAsync(Xavier.Integration.Tests.CompositionService.PreviewRequest previewRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompositionService/CreatePreviewResult", ReplyAction="http://tempuri.org/ICompositionService/CreatePreviewResultResponse")]
        Xavier.Integration.Tests.CompositionService.PreviewResponse CreatePreviewResult(Xavier.Integration.Tests.CompositionService.PreviewRequest previewRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompositionService/CreatePreviewResult", ReplyAction="http://tempuri.org/ICompositionService/CreatePreviewResultResponse")]
        System.Threading.Tasks.Task<Xavier.Integration.Tests.CompositionService.PreviewResponse> CreatePreviewResultAsync(Xavier.Integration.Tests.CompositionService.PreviewRequest previewRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompositionService/GetPreviewFile", ReplyAction="http://tempuri.org/ICompositionService/GetPreviewFileResponse")]
        System.IO.Stream GetPreviewFile(string jobId, int page);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompositionService/GetPreviewFile", ReplyAction="http://tempuri.org/ICompositionService/GetPreviewFileResponse")]
        System.Threading.Tasks.Task<System.IO.Stream> GetPreviewFileAsync(string jobId, int page);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompositionService/CreateProductionArtwork", ReplyAction="http://tempuri.org/ICompositionService/CreateProductionArtworkResponse")]
        string CreateProductionArtwork(Xavier.Integration.Tests.CompositionService.PreviewRequest previewRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompositionService/CreateProductionArtwork", ReplyAction="http://tempuri.org/ICompositionService/CreateProductionArtworkResponse")]
        System.Threading.Tasks.Task<string> CreateProductionArtworkAsync(Xavier.Integration.Tests.CompositionService.PreviewRequest previewRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompositionService/GetProductionArtwork", ReplyAction="http://tempuri.org/ICompositionService/GetProductionArtworkResponse")]
        System.IO.Stream GetProductionArtwork(string jobId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompositionService/GetProductionArtwork", ReplyAction="http://tempuri.org/ICompositionService/GetProductionArtworkResponse")]
        System.Threading.Tasks.Task<System.IO.Stream> GetProductionArtworkAsync(string jobId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICompositionServiceChannel : Xavier.Integration.Tests.CompositionService.ICompositionService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CompositionServiceClient : System.ServiceModel.ClientBase<Xavier.Integration.Tests.CompositionService.ICompositionService>, Xavier.Integration.Tests.CompositionService.ICompositionService {
        
        public CompositionServiceClient() {
        }
        
        public CompositionServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CompositionServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CompositionServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CompositionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string CreatePreview(Xavier.Integration.Tests.CompositionService.PreviewRequest previewRequest) {
            return base.Channel.CreatePreview(previewRequest);
        }
        
        public System.Threading.Tasks.Task<string> CreatePreviewAsync(Xavier.Integration.Tests.CompositionService.PreviewRequest previewRequest) {
            return base.Channel.CreatePreviewAsync(previewRequest);
        }
        
        public Xavier.Integration.Tests.CompositionService.PreviewResponse CreatePreviewResult(Xavier.Integration.Tests.CompositionService.PreviewRequest previewRequest) {
            return base.Channel.CreatePreviewResult(previewRequest);
        }
        
        public System.Threading.Tasks.Task<Xavier.Integration.Tests.CompositionService.PreviewResponse> CreatePreviewResultAsync(Xavier.Integration.Tests.CompositionService.PreviewRequest previewRequest) {
            return base.Channel.CreatePreviewResultAsync(previewRequest);
        }
        
        public System.IO.Stream GetPreviewFile(string jobId, int page) {
            return base.Channel.GetPreviewFile(jobId, page);
        }
        
        public System.Threading.Tasks.Task<System.IO.Stream> GetPreviewFileAsync(string jobId, int page) {
            return base.Channel.GetPreviewFileAsync(jobId, page);
        }
        
        public string CreateProductionArtwork(Xavier.Integration.Tests.CompositionService.PreviewRequest previewRequest) {
            return base.Channel.CreateProductionArtwork(previewRequest);
        }
        
        public System.Threading.Tasks.Task<string> CreateProductionArtworkAsync(Xavier.Integration.Tests.CompositionService.PreviewRequest previewRequest) {
            return base.Channel.CreateProductionArtworkAsync(previewRequest);
        }
        
        public System.IO.Stream GetProductionArtwork(string jobId) {
            return base.Channel.GetProductionArtwork(jobId);
        }
        
        public System.Threading.Tasks.Task<System.IO.Stream> GetProductionArtworkAsync(string jobId) {
            return base.Channel.GetProductionArtworkAsync(jobId);
        }
    }
}