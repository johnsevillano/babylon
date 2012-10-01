using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Babylon.Site.Providers;


namespace Babylon.Site.Models
{
    public class MediaItem
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public MediaType Type { get; set; }

        public MediaFormat Format { get; set; }

        public string AlternativeText { get; set; }

        public DateTime UploadedOn { get; set; }

        public Profile Owner { get; set; }

        public virtual byte[] Bytes { get; set; }
    }

    public enum MediaType
    {
        Image,
        Audio,
        Video
    }

    public enum MediaFormat
    {
        JPG,
        BMP,
        PNG,
        WMA,
        MP3,
        OGG,
        WMV,
        MPG,
        AVI
    }
}