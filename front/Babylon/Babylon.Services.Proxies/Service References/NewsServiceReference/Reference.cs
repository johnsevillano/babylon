﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Babylon.Services.Proxies.NewsServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Metro.Services.Babylon/", ConfigurationName="NewsServiceReference.NewsService")]
    public interface NewsService {
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://Metro.Services.Babylon/NewsService/CreateNewsItemRequest", ReplyAction="http://Metro.Services.Babylon/NewsService/CreateNewsItemResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        Babylon.Services.Proxies.NewsServiceReference.CreateNewsItemResponse CreateNewsItem(Babylon.Services.Proxies.NewsServiceReference.CreateNewsItemRequest request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://Metro.Services.Babylon/NewsService/ReportNewsItemRequest", ReplyAction="http://Metro.Services.Babylon/NewsService/ReportNewsItemResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        Babylon.Services.Proxies.NewsServiceReference.ReportNewsItemResponse ReportNewsItem(Babylon.Services.Proxies.NewsServiceReference.ReportNewsItemRequest request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://Metro.Services.Babylon/NewsService/GetLatestNewsRequest", ReplyAction="http://Metro.Services.Babylon/NewsService/GetLatestNewsResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        Babylon.Services.Proxies.NewsServiceReference.GetLatestNewsResponse GetLatestNews(Babylon.Services.Proxies.NewsServiceReference.GetLatestNewsRequest request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://Metro.Services.Babylon/NewsService/GetNewsItemRequest", ReplyAction="http://Metro.Services.Babylon/NewsService/GetNewsItemResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        Babylon.Services.Proxies.NewsServiceReference.GetNewsItemResponse GetNewsItem(Babylon.Services.Proxies.NewsServiceReference.GetNewsItemRequest request);
        
        // CODEGEN: Parameter 'item' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Metro.Services.Babylon/NewsService/ModifyNewsItem")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void ModifyNewsItem(Babylon.Services.Proxies.NewsServiceReference.ModifyNewsItem request);
        
        // CODEGEN: Parameter 'id' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://Metro.Services.Babylon/NewsService/DeleteNewsItem")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void DeleteNewsItem(Babylon.Services.Proxies.NewsServiceReference.DeleteNewsItem request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://Metro.Services.Babylon/NewsService/SearchNewsRequest", ReplyAction="http://Metro.Services.Babylon/NewsService/SearchNewsResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        Babylon.Services.Proxies.NewsServiceReference.SearchNewsResponse SearchNews(Babylon.Services.Proxies.NewsServiceReference.SearchNewsRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Metro.Services.Babylon/")]
    public partial class newsItem : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string bodyField;
        
        private newsItemEntry[] categoriesField;
        
        private string idField;
        
        private byte[] pictureField;
        
        private double pictureScaleField;
        
        private bool pictureScaleFieldSpecified;
        
        private long pictureSizeField;
        
        private bool pictureSizeFieldSpecified;
        
        private short ratingField;
        
        private bool ratingFieldSpecified;
        
        private string reportedByField;
        
        private System.DateTime reportedOnField;
        
        private bool reportedOnFieldSpecified;
        
        private int reviewsField;
        
        private bool reviewsFieldSpecified;
        
        private string[] tagsField;
        
        private string titleField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string body {
            get {
                return this.bodyField;
            }
            set {
                this.bodyField = value;
                this.RaisePropertyChanged("body");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("entry", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public newsItemEntry[] categories {
            get {
                return this.categoriesField;
            }
            set {
                this.categoriesField = value;
                this.RaisePropertyChanged("categories");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("id");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary", Order=3)]
        public byte[] picture {
            get {
                return this.pictureField;
            }
            set {
                this.pictureField = value;
                this.RaisePropertyChanged("picture");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public double pictureScale {
            get {
                return this.pictureScaleField;
            }
            set {
                this.pictureScaleField = value;
                this.RaisePropertyChanged("pictureScale");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool pictureScaleSpecified {
            get {
                return this.pictureScaleFieldSpecified;
            }
            set {
                this.pictureScaleFieldSpecified = value;
                this.RaisePropertyChanged("pictureScaleSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public long pictureSize {
            get {
                return this.pictureSizeField;
            }
            set {
                this.pictureSizeField = value;
                this.RaisePropertyChanged("pictureSize");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool pictureSizeSpecified {
            get {
                return this.pictureSizeFieldSpecified;
            }
            set {
                this.pictureSizeFieldSpecified = value;
                this.RaisePropertyChanged("pictureSizeSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public short rating {
            get {
                return this.ratingField;
            }
            set {
                this.ratingField = value;
                this.RaisePropertyChanged("rating");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ratingSpecified {
            get {
                return this.ratingFieldSpecified;
            }
            set {
                this.ratingFieldSpecified = value;
                this.RaisePropertyChanged("ratingSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public string reportedBy {
            get {
                return this.reportedByField;
            }
            set {
                this.reportedByField = value;
                this.RaisePropertyChanged("reportedBy");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=8)]
        public System.DateTime reportedOn {
            get {
                return this.reportedOnField;
            }
            set {
                this.reportedOnField = value;
                this.RaisePropertyChanged("reportedOn");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool reportedOnSpecified {
            get {
                return this.reportedOnFieldSpecified;
            }
            set {
                this.reportedOnFieldSpecified = value;
                this.RaisePropertyChanged("reportedOnSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=9)]
        public int reviews {
            get {
                return this.reviewsField;
            }
            set {
                this.reviewsField = value;
                this.RaisePropertyChanged("reviews");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool reviewsSpecified {
            get {
                return this.reviewsFieldSpecified;
            }
            set {
                this.reviewsFieldSpecified = value;
                this.RaisePropertyChanged("reviewsSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("tags", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=10)]
        public string[] tags {
            get {
                return this.tagsField;
            }
            set {
                this.tagsField = value;
                this.RaisePropertyChanged("tags");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=11)]
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
                this.RaisePropertyChanged("title");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://Metro.Services.Babylon/")]
    public partial class newsItemEntry : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string keyField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
                this.RaisePropertyChanged("key");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("value");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Metro.Services.Babylon/")]
    public partial class newsItemFilter : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string bodyField;
        
        private System.DateTime reportedAfterField;
        
        private bool reportedAfterFieldSpecified;
        
        private System.DateTime reportedBeforeField;
        
        private bool reportedBeforeFieldSpecified;
        
        private string reportedByField;
        
        private string titleField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string body {
            get {
                return this.bodyField;
            }
            set {
                this.bodyField = value;
                this.RaisePropertyChanged("body");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public System.DateTime reportedAfter {
            get {
                return this.reportedAfterField;
            }
            set {
                this.reportedAfterField = value;
                this.RaisePropertyChanged("reportedAfter");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool reportedAfterSpecified {
            get {
                return this.reportedAfterFieldSpecified;
            }
            set {
                this.reportedAfterFieldSpecified = value;
                this.RaisePropertyChanged("reportedAfterSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public System.DateTime reportedBefore {
            get {
                return this.reportedBeforeField;
            }
            set {
                this.reportedBeforeField = value;
                this.RaisePropertyChanged("reportedBefore");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool reportedBeforeSpecified {
            get {
                return this.reportedBeforeFieldSpecified;
            }
            set {
                this.reportedBeforeFieldSpecified = value;
                this.RaisePropertyChanged("reportedBeforeSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string reportedBy {
            get {
                return this.reportedByField;
            }
            set {
                this.reportedByField = value;
                this.RaisePropertyChanged("reportedBy");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
                this.RaisePropertyChanged("title");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateNewsItem", WrapperNamespace="http://Metro.Services.Babylon/", IsWrapped=true)]
    public partial class CreateNewsItemRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Metro.Services.Babylon/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string title;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Metro.Services.Babylon/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string body;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Metro.Services.Babylon/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string reportedBy;
        
        public CreateNewsItemRequest() {
        }
        
        public CreateNewsItemRequest(string title, string body, string reportedBy) {
            this.title = title;
            this.body = body;
            this.reportedBy = reportedBy;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateNewsItemResponse", WrapperNamespace="http://Metro.Services.Babylon/", IsWrapped=true)]
    public partial class CreateNewsItemResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Metro.Services.Babylon/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Babylon.Services.Proxies.NewsServiceReference.newsItem @return;
        
        public CreateNewsItemResponse() {
        }
        
        public CreateNewsItemResponse(Babylon.Services.Proxies.NewsServiceReference.newsItem @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ReportNewsItem", WrapperNamespace="http://Metro.Services.Babylon/", IsWrapped=true)]
    public partial class ReportNewsItemRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Metro.Services.Babylon/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Babylon.Services.Proxies.NewsServiceReference.newsItem newsItem;
        
        public ReportNewsItemRequest() {
        }
        
        public ReportNewsItemRequest(Babylon.Services.Proxies.NewsServiceReference.newsItem newsItem) {
            this.newsItem = newsItem;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ReportNewsItemResponse", WrapperNamespace="http://Metro.Services.Babylon/", IsWrapped=true)]
    public partial class ReportNewsItemResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Metro.Services.Babylon/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string @return;
        
        public ReportNewsItemResponse() {
        }
        
        public ReportNewsItemResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetLatestNews", WrapperNamespace="http://Metro.Services.Babylon/", IsWrapped=true)]
    public partial class GetLatestNewsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Metro.Services.Babylon/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int count;
        
        public GetLatestNewsRequest() {
        }
        
        public GetLatestNewsRequest(int count) {
            this.count = count;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetLatestNewsResponse", WrapperNamespace="http://Metro.Services.Babylon/", IsWrapped=true)]
    public partial class GetLatestNewsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Metro.Services.Babylon/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public newsItem[] @return;
        
        public GetLatestNewsResponse() {
        }
        
        public GetLatestNewsResponse(newsItem[] @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetNewsItem", WrapperNamespace="http://Metro.Services.Babylon/", IsWrapped=true)]
    public partial class GetNewsItemRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Metro.Services.Babylon/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string id;
        
        public GetNewsItemRequest() {
        }
        
        public GetNewsItemRequest(string id) {
            this.id = id;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetNewsItemResponse", WrapperNamespace="http://Metro.Services.Babylon/", IsWrapped=true)]
    public partial class GetNewsItemResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Metro.Services.Babylon/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Babylon.Services.Proxies.NewsServiceReference.newsItem @return;
        
        public GetNewsItemResponse() {
        }
        
        public GetNewsItemResponse(Babylon.Services.Proxies.NewsServiceReference.newsItem @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ModifyNewsItem", WrapperNamespace="http://Metro.Services.Babylon/", IsWrapped=true)]
    public partial class ModifyNewsItem {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Metro.Services.Babylon/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Babylon.Services.Proxies.NewsServiceReference.newsItem item;
        
        public ModifyNewsItem() {
        }
        
        public ModifyNewsItem(Babylon.Services.Proxies.NewsServiceReference.newsItem item) {
            this.item = item;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DeleteNewsItem", WrapperNamespace="http://Metro.Services.Babylon/", IsWrapped=true)]
    public partial class DeleteNewsItem {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Metro.Services.Babylon/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string id;
        
        public DeleteNewsItem() {
        }
        
        public DeleteNewsItem(string id) {
            this.id = id;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SearchNews", WrapperNamespace="http://Metro.Services.Babylon/", IsWrapped=true)]
    public partial class SearchNewsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Metro.Services.Babylon/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Babylon.Services.Proxies.NewsServiceReference.newsItemFilter filter;
        
        public SearchNewsRequest() {
        }
        
        public SearchNewsRequest(Babylon.Services.Proxies.NewsServiceReference.newsItemFilter filter) {
            this.filter = filter;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SearchNewsResponse", WrapperNamespace="http://Metro.Services.Babylon/", IsWrapped=true)]
    public partial class SearchNewsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Metro.Services.Babylon/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public newsItem[] @return;
        
        public SearchNewsResponse() {
        }
        
        public SearchNewsResponse(newsItem[] @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface NewsServiceChannel : Babylon.Services.Proxies.NewsServiceReference.NewsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NewsServiceClient : System.ServiceModel.ClientBase<Babylon.Services.Proxies.NewsServiceReference.NewsService>, Babylon.Services.Proxies.NewsServiceReference.NewsService {
        
        public NewsServiceClient() {
        }
        
        public NewsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NewsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NewsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NewsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Babylon.Services.Proxies.NewsServiceReference.CreateNewsItemResponse Babylon.Services.Proxies.NewsServiceReference.NewsService.CreateNewsItem(Babylon.Services.Proxies.NewsServiceReference.CreateNewsItemRequest request) {
            return base.Channel.CreateNewsItem(request);
        }
        
        public Babylon.Services.Proxies.NewsServiceReference.newsItem CreateNewsItem(string title, string body, string reportedBy) {
            Babylon.Services.Proxies.NewsServiceReference.CreateNewsItemRequest inValue = new Babylon.Services.Proxies.NewsServiceReference.CreateNewsItemRequest();
            inValue.title = title;
            inValue.body = body;
            inValue.reportedBy = reportedBy;
            Babylon.Services.Proxies.NewsServiceReference.CreateNewsItemResponse retVal = ((Babylon.Services.Proxies.NewsServiceReference.NewsService)(this)).CreateNewsItem(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Babylon.Services.Proxies.NewsServiceReference.ReportNewsItemResponse Babylon.Services.Proxies.NewsServiceReference.NewsService.ReportNewsItem(Babylon.Services.Proxies.NewsServiceReference.ReportNewsItemRequest request) {
            return base.Channel.ReportNewsItem(request);
        }
        
        public string ReportNewsItem(Babylon.Services.Proxies.NewsServiceReference.newsItem newsItem) {
            Babylon.Services.Proxies.NewsServiceReference.ReportNewsItemRequest inValue = new Babylon.Services.Proxies.NewsServiceReference.ReportNewsItemRequest();
            inValue.newsItem = newsItem;
            Babylon.Services.Proxies.NewsServiceReference.ReportNewsItemResponse retVal = ((Babylon.Services.Proxies.NewsServiceReference.NewsService)(this)).ReportNewsItem(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Babylon.Services.Proxies.NewsServiceReference.GetLatestNewsResponse Babylon.Services.Proxies.NewsServiceReference.NewsService.GetLatestNews(Babylon.Services.Proxies.NewsServiceReference.GetLatestNewsRequest request) {
            return base.Channel.GetLatestNews(request);
        }
        
        public newsItem[] GetLatestNews(int count) {
            Babylon.Services.Proxies.NewsServiceReference.GetLatestNewsRequest inValue = new Babylon.Services.Proxies.NewsServiceReference.GetLatestNewsRequest();
            inValue.count = count;
            Babylon.Services.Proxies.NewsServiceReference.GetLatestNewsResponse retVal = ((Babylon.Services.Proxies.NewsServiceReference.NewsService)(this)).GetLatestNews(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Babylon.Services.Proxies.NewsServiceReference.GetNewsItemResponse Babylon.Services.Proxies.NewsServiceReference.NewsService.GetNewsItem(Babylon.Services.Proxies.NewsServiceReference.GetNewsItemRequest request) {
            return base.Channel.GetNewsItem(request);
        }
        
        public Babylon.Services.Proxies.NewsServiceReference.newsItem GetNewsItem(string id) {
            Babylon.Services.Proxies.NewsServiceReference.GetNewsItemRequest inValue = new Babylon.Services.Proxies.NewsServiceReference.GetNewsItemRequest();
            inValue.id = id;
            Babylon.Services.Proxies.NewsServiceReference.GetNewsItemResponse retVal = ((Babylon.Services.Proxies.NewsServiceReference.NewsService)(this)).GetNewsItem(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void Babylon.Services.Proxies.NewsServiceReference.NewsService.ModifyNewsItem(Babylon.Services.Proxies.NewsServiceReference.ModifyNewsItem request) {
            base.Channel.ModifyNewsItem(request);
        }
        
        public void ModifyNewsItem(Babylon.Services.Proxies.NewsServiceReference.newsItem item) {
            Babylon.Services.Proxies.NewsServiceReference.ModifyNewsItem inValue = new Babylon.Services.Proxies.NewsServiceReference.ModifyNewsItem();
            inValue.item = item;
            ((Babylon.Services.Proxies.NewsServiceReference.NewsService)(this)).ModifyNewsItem(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void Babylon.Services.Proxies.NewsServiceReference.NewsService.DeleteNewsItem(Babylon.Services.Proxies.NewsServiceReference.DeleteNewsItem request) {
            base.Channel.DeleteNewsItem(request);
        }
        
        public void DeleteNewsItem(string id) {
            Babylon.Services.Proxies.NewsServiceReference.DeleteNewsItem inValue = new Babylon.Services.Proxies.NewsServiceReference.DeleteNewsItem();
            inValue.id = id;
            ((Babylon.Services.Proxies.NewsServiceReference.NewsService)(this)).DeleteNewsItem(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Babylon.Services.Proxies.NewsServiceReference.SearchNewsResponse Babylon.Services.Proxies.NewsServiceReference.NewsService.SearchNews(Babylon.Services.Proxies.NewsServiceReference.SearchNewsRequest request) {
            return base.Channel.SearchNews(request);
        }
        
        public newsItem[] SearchNews(Babylon.Services.Proxies.NewsServiceReference.newsItemFilter filter) {
            Babylon.Services.Proxies.NewsServiceReference.SearchNewsRequest inValue = new Babylon.Services.Proxies.NewsServiceReference.SearchNewsRequest();
            inValue.filter = filter;
            Babylon.Services.Proxies.NewsServiceReference.SearchNewsResponse retVal = ((Babylon.Services.Proxies.NewsServiceReference.NewsService)(this)).SearchNews(inValue);
            return retVal.@return;
        }
    }
}
