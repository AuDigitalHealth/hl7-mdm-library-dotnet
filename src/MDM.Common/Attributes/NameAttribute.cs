using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDM.Common.Attributes
{
    /// <summary>
    /// This attribute contains the name and code to be associated with a property / enum
    /// </summary>
    public class NameAttribute : Attribute
    {
        /// <summary>
        /// The free text Name
        /// </summary>
        public String Name { get; set; }


        /// <summary>
        /// The Code (typically a CDA code)
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// Alternate code
        /// </summary>
        public String AlternateCode { get; set; }
    }
}
