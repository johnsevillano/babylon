using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Babylon.Site.Common
{
    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxSize;

        public FileSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            return _maxSize > (value as HttpPostedFileBase).ContentLength;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("File size should not exceed {0} KB.", _maxSize / 1024);
        }
    }

    public class FileTypesAttribute : ValidationAttribute
    {
        private readonly IList<string> _types;

        public FileTypesAttribute(string types)
        {
            _types = types.Split(',').ToList();
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            string ext = System.IO.Path.GetExtension((value as HttpPostedFileBase).FileName).Substring(1);

            return _types.Contains(ext, StringComparer.OrdinalIgnoreCase);
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("Invalid file type. Only the following types {0} are supported.", String.Join(", ", _types));
        }
    }

}