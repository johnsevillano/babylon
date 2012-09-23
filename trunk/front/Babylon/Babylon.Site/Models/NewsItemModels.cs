using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Babylon.Site.Models
{
    public class NewsItem
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime ReportedOn { get; set; }

        public string ReportedBy { get; set; }

        public byte[] Picture { get; set; }

        public long PictureSize { get; set; }

        public double PictureScale { get; set; }

        public int Reviews { get; set; }

        public short Rating { get; set; }

        public IList<string> Tags { get; set; }

        public IDictionary<string, string> Categories { get; set; }
    }
}