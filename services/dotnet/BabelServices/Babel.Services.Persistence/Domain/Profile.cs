using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

using Babel.Services.Common;


namespace Babel.Services.Domain
{
    [DataContract]
    public class Profile
    {
        [DataMember]
        public virtual Guid ID { get; set; }

        [DataMember]
        public virtual string Username { get; set; }

        [DataMember]
        public virtual string Password { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string Surname { get; set; }

        [DataMember]
        public virtual string Email { get; set; }

        [DataMember]
        public virtual DateTime? DateOfBirth { get; set; }

        [DataMember]
        public virtual Address Address { get; set; }

        [DataMember]
        public virtual Gender? Gender { get; set; }

        [DataMember]
        public virtual string Description { get; set; }

        [DataMember]
        public virtual byte[] Picture { get; set; }

        [DataMember]
        public virtual DateTime? PictureUploadedOn { get; set; }

        [DataMember]
        public virtual DateTime CreatedOn { get; set; }

        [DataMember]
        public virtual DateTime UpdatedOn { get; set; }

        public virtual IList<Profile> Contacts { get; set; }
    }
}
