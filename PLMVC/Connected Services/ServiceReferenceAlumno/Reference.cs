﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PLMVC.ServiceReferenceAlumno {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/SLWCF")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Exception))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Alumno))]
    public partial class Result : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool CorrectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Exception ExField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ObjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] ObjectsField;
        
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
        public bool Correct {
            get {
                return this.CorrectField;
            }
            set {
                if ((this.CorrectField.Equals(value) != true)) {
                    this.CorrectField = value;
                    this.RaisePropertyChanged("Correct");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Exception Ex {
            get {
                return this.ExField;
            }
            set {
                if ((object.ReferenceEquals(this.ExField, value) != true)) {
                    this.ExField = value;
                    this.RaisePropertyChanged("Ex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Object {
            get {
                return this.ObjectField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectField, value) != true)) {
                    this.ObjectField = value;
                    this.RaisePropertyChanged("Object");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] Objects {
            get {
                return this.ObjectsField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectsField, value) != true)) {
                    this.ObjectsField = value;
                    this.RaisePropertyChanged("Objects");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceAlumno.IAlumnoService")]
    public interface IAlumnoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Add", ReplyAction="http://tempuri.org/IAlumnoService/AddResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PLMVC.ServiceReferenceAlumno.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        PLMVC.ServiceReferenceAlumno.Result Add(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Add", ReplyAction="http://tempuri.org/IAlumnoService/AddResponse")]
        System.Threading.Tasks.Task<PLMVC.ServiceReferenceAlumno.Result> AddAsync(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Update", ReplyAction="http://tempuri.org/IAlumnoService/UpdateResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PLMVC.ServiceReferenceAlumno.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        PLMVC.ServiceReferenceAlumno.Result Update(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Update", ReplyAction="http://tempuri.org/IAlumnoService/UpdateResponse")]
        System.Threading.Tasks.Task<PLMVC.ServiceReferenceAlumno.Result> UpdateAsync(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Delete", ReplyAction="http://tempuri.org/IAlumnoService/DeleteResponse")]
        PLMVC.ServiceReferenceAlumno.Result Delete(int idAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/Delete", ReplyAction="http://tempuri.org/IAlumnoService/DeleteResponse")]
        System.Threading.Tasks.Task<PLMVC.ServiceReferenceAlumno.Result> DeleteAsync(int idAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/GetAll", ReplyAction="http://tempuri.org/IAlumnoService/GetAllResponse")]
        PLMVC.ServiceReferenceAlumno.Result GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/GetAll", ReplyAction="http://tempuri.org/IAlumnoService/GetAllResponse")]
        System.Threading.Tasks.Task<PLMVC.ServiceReferenceAlumno.Result> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/GetById", ReplyAction="http://tempuri.org/IAlumnoService/GetByIdResponse")]
        PLMVC.ServiceReferenceAlumno.Result GetById(int idAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumnoService/GetById", ReplyAction="http://tempuri.org/IAlumnoService/GetByIdResponse")]
        System.Threading.Tasks.Task<PLMVC.ServiceReferenceAlumno.Result> GetByIdAsync(int idAlumno);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAlumnoServiceChannel : PLMVC.ServiceReferenceAlumno.IAlumnoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AlumnoServiceClient : System.ServiceModel.ClientBase<PLMVC.ServiceReferenceAlumno.IAlumnoService>, PLMVC.ServiceReferenceAlumno.IAlumnoService {
        
        public AlumnoServiceClient() {
        }
        
        public AlumnoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AlumnoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlumnoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlumnoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PLMVC.ServiceReferenceAlumno.Result Add(ML.Alumno alumno) {
            return base.Channel.Add(alumno);
        }
        
        public System.Threading.Tasks.Task<PLMVC.ServiceReferenceAlumno.Result> AddAsync(ML.Alumno alumno) {
            return base.Channel.AddAsync(alumno);
        }
        
        public PLMVC.ServiceReferenceAlumno.Result Update(ML.Alumno alumno) {
            return base.Channel.Update(alumno);
        }
        
        public System.Threading.Tasks.Task<PLMVC.ServiceReferenceAlumno.Result> UpdateAsync(ML.Alumno alumno) {
            return base.Channel.UpdateAsync(alumno);
        }
        
        public PLMVC.ServiceReferenceAlumno.Result Delete(int idAlumno) {
            return base.Channel.Delete(idAlumno);
        }
        
        public System.Threading.Tasks.Task<PLMVC.ServiceReferenceAlumno.Result> DeleteAsync(int idAlumno) {
            return base.Channel.DeleteAsync(idAlumno);
        }
        
        public PLMVC.ServiceReferenceAlumno.Result GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<PLMVC.ServiceReferenceAlumno.Result> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public PLMVC.ServiceReferenceAlumno.Result GetById(int idAlumno) {
            return base.Channel.GetById(idAlumno);
        }
        
        public System.Threading.Tasks.Task<PLMVC.ServiceReferenceAlumno.Result> GetByIdAsync(int idAlumno) {
            return base.Channel.GetByIdAsync(idAlumno);
        }
    }
}
