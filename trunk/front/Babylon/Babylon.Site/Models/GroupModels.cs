using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Babylon.Site.Models
{
    public class Group
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Interests { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public IList<Profile> Members { get; set; }
    }
}