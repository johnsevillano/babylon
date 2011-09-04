using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Babel.Services.Filters
{
    [DataContract]
    public class GroupFilter
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Interests { get; set; }

        [DataMember]
        public DateTime CreatedAfter { get; set; }

        [DataMember]
        public DateTime CreatedBefore { get; set; }
    }
}
