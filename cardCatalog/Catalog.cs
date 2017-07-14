using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace cardCatalog
{

    class Catalog
    {
        public enum options { list = 1, add, save }
        private static List<Book> books = new List<Book>();
        //private static List<Book> books;
        private static string _filename;
        static void Main(string[] args)
        {
            // var books = new List<Book>;

            bool finished = false;
            WriteLine("Welcome to the card catalog");
            WriteLine();
            Write("Please enter the catalog filename: ");
            string _filename = ReadLine();
            do
            {
                WriteLine("What would you like to do?");
                WriteLine("List Books(1)");
                WriteLine("Add a Book(2)");
                WriteLine("Save to File(3)");
                WriteLine("Exit (4)");
                Write("Enter your choice: ");
                string choice = ReadLine();
                /* foreach (options item in Enum.GetValues(typeof(options)))
                {

                }
                */

                switch (choice)

                {

                    case "1": // List all the books.
                        foreach (Book book in books)

                            
                            {

                                Console.WriteLine(Books ());;
                            } 
                        
                        break;

                    case "2": // Add a book.
                        // Book newBook = AddABook();
                        WriteLine("Enter the book information");
                        Write("Author's last name: ");
                        string lName = ReadLine();
                        Write("Author's first name: ");
                        string fName = ReadLine();
                        Write("Title: ");
                        string tit = ReadLine();
                        Write("ISBN: ");
                        string number = ReadLine();
                        Write("Year published: ");
                        string year = ReadLine();

                        Book nextBook = new Book(lName, fName, tit, number,
                            year);
                        books.Add(nextBook);

                        break;

                    case "3": //Do that

                        break;
                    case "4":
                        finished = false;
                        break;
                 }
             } while (!finished) ;

        }  // Main

        public void Save ()
        {
            /*
             * Purpose: Write the books List as an XML file.
             * 
             * Author: N. S. Clerman, 14-Jul-2017
             * 
             * Note: This code was taken from the following book:
             *       "C#7 and .NET Core: Modern Cross-Platform Development"
             *       Mark J. Price, Second Edition, Packt> Publishing 2017.
             */ 
            /* 
             * 1) establish a filestream on which to write the XML file 
             *    containing the books list.
             * 2) create the serializer object and serialize the list to the file.
             * 3) close the stream to release the file lock.
            */
            string xmlFilepath = _filename;
            FileStream xmlStream = File.Create(xmlFilepath);
            var xs = new XmlSerializer(typeof(List<Book>));
            xs.Serialize(xmlStream, books);
            xmlStream.Dispose();

            // Debugging code. to be commented out as necessary
            WriteLine($"Written {new FileInfo(xmlFilepath).Length} bytes of "
                + $"XML to {xmlFilepath}");
            WriteLine();

            }
    }
}
