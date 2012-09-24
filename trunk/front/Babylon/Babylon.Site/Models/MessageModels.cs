using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Babylon.Site.Models
{
    public class Message
    {
        public Guid ID { get; set; }

        public Guid Sender { get; set; }

        public IList<Guid> Recipients { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime SentOn { get; set; }

        public IList<Attachment> Attachments { get; set; }

        public bool Deleted { get; set; }

    }

    public class Attachment
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public byte[] Content { get; set; }

        public long ContentSize { get; set; }
    }

}
