using System;
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace Babel.Services.Domain
{
    [DataContract]
    public class Group
    {
        [DataMember]
        public virtual Guid ID { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string Description { get; set; }

        [DataMember]
        public virtual string Interests { get; set; }

        [DataMember]
        public virtual DateTime CreatedOn { get; set; }

        [DataMember]
        public virtual DateTime UpdatedOn { get; set; }

        public virtual IList<Profile> Members { get; set; }
    }
}
