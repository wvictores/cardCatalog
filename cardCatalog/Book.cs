using System;
using static System.Console;
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
        // it also must be parameter-less (but it can be overloaded)
        public Book() {}

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

        public  void PrintBookInfo() 
        {
            WriteLine($"Author: {this.lastName}, {this.firstName}");
            WriteLine($"Title: {this.title}");
            WriteLine($"ISBN: {this.longISBN}");
            WriteLine($"Year published: {this.publishYear}");
            WriteLine();
        }                                   
    } // class Book

}
