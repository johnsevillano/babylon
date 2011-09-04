using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Babel.Services.Common;


namespace Babel.Services.Filters
{
    [DataContract]
    public class MediaItemFilter
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public MediaType? Type { get; set; }

        public MediaFormat? Format { get; set; }

        public Guid OwnerID { get; set; }
    }
}
