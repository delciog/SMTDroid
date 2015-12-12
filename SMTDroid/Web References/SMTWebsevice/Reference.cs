//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMTDroid.SMTWebsevice {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SMTSoap", Namespace="http://SMTWebservice/")]
    public partial class SMT : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public SMT() {
            this.Url = "http://192.168.0.3/smt.asmx";
        }
        
        public SMT(string url) {
            this.Url = url;
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://SMTWebservice/login", RequestNamespace="http://SMTWebservice/", ResponseNamespace="http://SMTWebservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int login(string username, string password) {
            object[] results = this.Invoke("login", new object[] {
                        username,
                        password});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult Beginlogin(string username, string password, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("login", new object[] {
                        username,
                        password}, callback, asyncState);
        }
        
        /// <remarks/>
        public int Endlogin(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://SMTWebservice/listEvents", RequestNamespace="http://SMTWebservice/", ResponseNamespace="http://SMTWebservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Event[] listEvents(queryTimeOption eventOption) {
            object[] results = this.Invoke("listEvents", new object[] {
                        eventOption});
            return ((Event[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginlistEvents(queryTimeOption eventOption, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("listEvents", new object[] {
                        eventOption}, callback, asyncState);
        }
        
        /// <remarks/>
        public Event[] EndlistEvents(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Event[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://SMTWebservice/listEventsByContact", RequestNamespace="http://SMTWebservice/", ResponseNamespace="http://SMTWebservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Event[] listEventsByContact(string contactId, queryTimeOption eventOption) {
            object[] results = this.Invoke("listEventsByContact", new object[] {
                        contactId,
                        eventOption});
            return ((Event[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginlistEventsByContact(string contactId, queryTimeOption eventOption, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("listEventsByContact", new object[] {
                        contactId,
                        eventOption}, callback, asyncState);
        }
        
        /// <remarks/>
        public Event[] EndlistEventsByContact(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Event[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://SMTWebservice/getEventById", RequestNamespace="http://SMTWebservice/", ResponseNamespace="http://SMTWebservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Event getEventById(string eventId) {
            object[] results = this.Invoke("getEventById", new object[] {
                        eventId});
            return ((Event)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetEventById(string eventId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getEventById", new object[] {
                        eventId}, callback, asyncState);
        }
        
        /// <remarks/>
        public Event EndgetEventById(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Event)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://SMTWebservice/toggleAttendEvent", RequestNamespace="http://SMTWebservice/", ResponseNamespace="http://SMTWebservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool toggleAttendEvent(string eventId, string personId) {
            object[] results = this.Invoke("toggleAttendEvent", new object[] {
                        eventId,
                        personId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegintoggleAttendEvent(string eventId, string personId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("toggleAttendEvent", new object[] {
                        eventId,
                        personId}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndtoggleAttendEvent(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://SMTWebservice/isAttendingEvent", RequestNamespace="http://SMTWebservice/", ResponseNamespace="http://SMTWebservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool isAttendingEvent(string eventId, string personId) {
            object[] results = this.Invoke("isAttendingEvent", new object[] {
                        eventId,
                        personId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginisAttendingEvent(string eventId, string personId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("isAttendingEvent", new object[] {
                        eventId,
                        personId}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndisAttendingEvent(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://SMTWebservice/listContacts", RequestNamespace="http://SMTWebservice/", ResponseNamespace="http://SMTWebservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Contact[] listContacts() {
            object[] results = this.Invoke("listContacts", new object[0]);
            return ((Contact[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginlistContacts(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("listContacts", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public Contact[] EndlistContacts(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Contact[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://SMTWebservice/listContactsMet", RequestNamespace="http://SMTWebservice/", ResponseNamespace="http://SMTWebservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Contact[] listContactsMet(string userId) {
            object[] results = this.Invoke("listContactsMet", new object[] {
                        userId});
            return ((Contact[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginlistContactsMet(string userId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("listContactsMet", new object[] {
                        userId}, callback, asyncState);
        }
        
        /// <remarks/>
        public Contact[] EndlistContactsMet(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Contact[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://SMTWebservice/listContactsInEvent", RequestNamespace="http://SMTWebservice/", ResponseNamespace="http://SMTWebservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Contact[] listContactsInEvent(string eventId, queryTimeOption eventOption) {
            object[] results = this.Invoke("listContactsInEvent", new object[] {
                        eventId,
                        eventOption});
            return ((Contact[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginlistContactsInEvent(string eventId, queryTimeOption eventOption, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("listContactsInEvent", new object[] {
                        eventId,
                        eventOption}, callback, asyncState);
        }
        
        /// <remarks/>
        public Contact[] EndlistContactsInEvent(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Contact[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://SMTWebservice/getContactById", RequestNamespace="http://SMTWebservice/", ResponseNamespace="http://SMTWebservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Contact getContactById(string contactId) {
            object[] results = this.Invoke("getContactById", new object[] {
                        contactId});
            return ((Contact)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetContactById(string contactId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getContactById", new object[] {
                        contactId}, callback, asyncState);
        }
        
        /// <remarks/>
        public Contact EndgetContactById(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Contact)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://SMTWebservice/toggleContactMet", RequestNamespace="http://SMTWebservice/", ResponseNamespace="http://SMTWebservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool toggleContactMet(string userId, string personId) {
            object[] results = this.Invoke("toggleContactMet", new object[] {
                        userId,
                        personId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegintoggleContactMet(string userId, string personId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("toggleContactMet", new object[] {
                        userId,
                        personId}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndtoggleContactMet(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://SMTWebservice/isContactMet", RequestNamespace="http://SMTWebservice/", ResponseNamespace="http://SMTWebservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool isContactMet(string userId, string personId) {
            object[] results = this.Invoke("isContactMet", new object[] {
                        userId,
                        personId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginisContactMet(string userId, string personId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("isContactMet", new object[] {
                        userId,
                        personId}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndisContactMet(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://SMTWebservice/")]
    public enum queryTimeOption {
        
        /// <remarks/>
        Past,
        
        /// <remarks/>
        Present,
        
        /// <remarks/>
        Future,
        
        /// <remarks/>
        All,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://SMTWebservice/")]
    public partial class Event {
        
        /// <remarks/>
        public int id;
        
        /// <remarks/>
        public string name;
        
        /// <remarks/>
        public string url;
        
        /// <remarks/>
        public string location;
        
        /// <remarks/>
        public System.DateTime session;
        
        /// <remarks/>
        public string description;
        
        /// <remarks/>
        public System.DateTime dateCreated;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://SMTWebservice/")]
    public partial class Contact {
        
        /// <remarks/>
        public int id;
        
        /// <remarks/>
        public string name;
        
        /// <remarks/>
        public string jobTitle;
        
        /// <remarks/>
        public string organisation;
        
        /// <remarks/>
        public string notes;
        
        /// <remarks/>
        public System.DateTime dateCreated;
    }
}