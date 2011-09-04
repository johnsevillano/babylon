using System;
using System.Runtime.Serialization;


namespace Babel.Services.Domain
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public virtual string Street { get; set; }

        [DataMember]
        public virtual string City { get; set; }

        [DataMember]
        public virtual string PostalCode { get; set; }
    }
}
