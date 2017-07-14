using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace cardCatalog
{
    public class Book
    {
        /*
         * Purpose: Simple card catalog system
         * 
         * Programmers: Wanda, N. S. Clerman
         * 
         * Date: 13-Jul-2017
         * 
         * Revisions
         * =========
         * 1) N. S. Clerman, 14-Jul-2017: Add a constructor (required for XML
         *    Serialization). Add the XmlAttribute to all the properties (this 
         *    makes the XML more efficient). using System.Xml.Serialization to
         *    accomplish this.
         */

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

        // constructor
        // this must be present for XML Serialization
        // it also must be parameterless
        public Book() {}

        //
        private string filename;

    }
}
