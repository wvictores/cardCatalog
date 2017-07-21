using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace cardCatalog
{
    /// <summary>
    /// Purpose: Simple card catalog system
    /// 
    /// Programmers: Wanda, N. S. Clerman
    /// 
    /// Date: 13-Jul-2017
    /// 
    /// Revisions
    /// =========
    /// 1) N. S. Clerman, 14-Jul-2017: Add a parameter-less constructor (required for XML
    ///    Serialization). Add the XmlAttribute to all the properties (this makes the XML 
    ///    more efficient), using System.Xml.Serialization to accomplish this. Add a 
    ///    second constructor with parameters.
    /// 2) N. S. Clerman, 19-Jul-2017: Move this documentation block and employ <summary>
    /// </summary>
    public class Book
    {

        // properties
        [XmlAttribute("fname")]
        public string lastName { get; set; }
        [XmlAttribute("lname")]
        public string firstName { get; set; }
        [XmlAttribute("title")]
        public string title { get; set; }
        [XmlAttribute("isbn")]
        public string longISBN { get; set; }
        [XmlAttribute("year")]
        public string publishYear { get; set; }

        /// <summary>
        /// 
        /// Purpose: constructor
        // Note: This must be present for XML Serialization
        //       It also must be parameter-less (but it can be overloaded)
        /// </summary>
        public Book() { }

        // overload of constructor
        public Book(string lastName, string firstName, string title, string isbn,
            string pubYear)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.title = title;
            this.longISBN = isbn;
            this.publishYear = pubYear;
        }

        public const int NO_OF_PROPS = 5;
        public static readonly string[] PROP_NAMES = { "lastName", "firstName",
            "title", "longISBN", "publishYear" };

        /// <summary>
        /// Purpose: Return a single string containing the string properties of
        ///          class Book.
        ///
        /// Programmer: N. S. Clerman, 14-Jul-2017
        /// 
        /// Revisions
        /// =========
        /// 1) N. S. Clerman, 18-Jul-2017: Change the method name, overloading
        ///    the ToString() method.
        /// 2) N. S. Clerman, 19-Jul-2017: Undo the change from yesterday.
        /// 3) N. S. Clerman, 21-Jul-2017: Redo the change overloading the 
        ///    ToString() method.
        ///    
        /// Notes
        /// =====
        /// 1) N. S. Clerman, 21-Jul-2017: The format of the string will be
        ///    name-of-property:value,name-of-property:value,..
        ///
        /// </summary>
        public override string ToString()
        {
            string [] propValues = { this.lastName, this.firstName, this.title,
                this.longISBN, this.publishYear };
            string[] pairs = new string[NO_OF_PROPS];
            for (int knt = 0; knt < NO_OF_PROPS; knt++)
            {
                pairs[knt] = PROP_NAMES[knt] + ":" + propValues[knt];
            }
            string retString = string.Join(",", pairs);
            return retString;
        }
    } // class Book

}