using System;
using System.Runtime.Serialization;

using Babel.Services.Common;


namespace Babel.Services.Filters
{
    [DataContract]
    public class ProfileFilter
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int AgeAbove { get; set; }

        [DataMember]
        public int AgeBelow { get; set; }

        [DataMember]
        public string Street { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public Gender Gender { get; set; }
    }
}
