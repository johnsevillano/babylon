using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Babel.Services.Common;


namespace Babel.Services.Domain
{
    [DataContract]
    public class MediaItem
    {
        [DataMember]
        public virtual Guid ID { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string Title { get; set; }

        [DataMember]
        public virtual MediaType Type { get; set; }

        [DataMember]
        public virtual MediaFormat Format { get; set; }

        [DataMember]
        public virtual string AlternativeText { get; set; }

        [DataMember]
        public virtual DateTime UploadedOn { get; set; }

        public virtual Profile Owner { get; set; }

        public virtual byte[] Bytes { get; set; }

        public virtual string Base64
        {
            get
            {
                return Convert.ToBase64String(Bytes);
            }
            set
            {
                Bytes = Convert.FromBase64String(value);
            }
        }
    }
}
