using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace Babylon.Site.Common
{
    public class ViewHelpers
    {

        /// <summary>
        /// Builds a SelectList to be used to populate a DropDownListFor helper.
        /// </summary>
        /// <param name="enumType">Enumeration type declaring the items in the list.</param>
        /// <returns></returns>
        public static SelectList GetSelectList(Type enumType)
        {
            Array values = Enum.GetValues(enumType);

            List<ListItem> items = new List<ListItem>(values.Length);

            foreach (var i in values)
            {
                items.Add(new ListItem
                {
                    Text = Enum.GetName(enumType, i),
                    Value = i.ToString()
                });
            }

            return new SelectList(items);
        }
    }
}