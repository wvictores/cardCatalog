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

    /// <summary>
    /// Purpose: Class for the card catalog
    /// 
    /// Programmers: W. Victores, N. S. Clerman, 13-Jul-2017
    /// 
    /// Revisions
    /// =========
    /// 1) N. S. Clerman, 18-Jul-2017: Remove static variable _filename.
    /// </summary>
    class Catalog
    {
        // books - container for the list of books        
        private static List<Book> books = new List<Book>();
        /// <summary>
        /// Purpose: Main method. Setup XML file. Prompt user for operation.
        /// Invoke the appropriate procedure to perform it.
        ///
        /// Programmers: W. Victores, N. S. Clerman, 13-Jul-2017
        /// 
        /// Revisions
        /// =========
        /// 1) N. S. Clerman, 18-Jul-2017: Modify the call to PrintBookInfo to
        ///    ToString().
        /// 2) N. S. Clerman, 21-Jul-2017: Separate out the code to list the
        ///    books to a separate static method, ListBooks; and the code to
        ///    add a book to one, AddABook, also. Remove the try for opening an
        ///    existing catalog - just let the exception appear.
        /// </summary>
        /// <param name="args">Command Line Arguments</param>
        static void Main(string[] args)
        {

            // MAX_TRIES - maximum number of bad entries allowed
            // finished - flag for exit
            const int MAX_TRIES = 4;
            bool finished = false;

            // obtain the filename.
            WriteLine("Welcome to the card catalog");
            WriteLine();
            Write("Please enter the catalog filename: ");
            string _filename = ReadLine().Trim() + ".xml";

            // If the file already exist, read it into books
            var xs = new XmlSerializer(typeof(List<Book>));
            FileStream xmlStream;
            bool fileExists = File.Exists(_filename);

            if (fileExists)
            {
                using(xmlStream = File.OpenRead(_filename))
                {
                    books = (List<Book>)xs.Deserialize(xmlStream);
                }
            }

            // prompt the user for entry.
            int kountTries = 0;
            string failMessage;
            do
            {
                WriteLine("What would you like to do?");
                WriteLine("List Books(1)");
                WriteLine("Add a Book(2)");
                WriteLine("Save to File and Exit(3)");
                Write("Enter your choice: ");
                string choice = ReadLine();

                switch (choice)
                {
                    case "1": // List all the books.
                        if (books.Count > 0)
                        {
                            Catalog.ListBooks();
                        }
                        else
                        {
                            WriteLine("The catalog is empty.");
                        }
                        kountTries = 0;
                        break;
                    case "2": // Add a book.
                        Catalog.AddABook();
                        kountTries = 0;
                        break;
                    case "3": // Save
                        Catalog.Save(_filename);
                        finished = true;
                        break;
                    default:
                        kountTries++;
                        finished = kountTries > MAX_TRIES;
                        if (finished)
                        {
                            failMessage = "Maximum tries reached. Press <Enter> to exit.";
                        }
                        else
                        {
                            failMessage = "Invalid entry, try again.";
                        }
                        WriteLine(failMessage);
                        if (finished) {ReadLine();}
                        break;
                 }
             } while (!finished) ;

        }  // Main

        /// <summary>
        /// 
        /// Purpose: Write the books List as an XML file.
        /// 
        /// Author: N. S. Clerman, 14-Jul-2017
        /// 
        /// Revisions
        /// =========
        /// 1) N. S. Clerman, 15-Jul-2017: Add some exception handling.
        ///    Remove some debugging code.
        /// 2) N. S. Clerman, 19-Jul-2017: Re-document the code using <summmary>.
        /// 
        /// Note: This code was taken from the following book:
        ///       "C#7 and .NET Core: Modern Cross-Platform Development"
        ///       Mark J. Price, Second Edition, Packt> Publishing 2017.
        /// </summary>
        /// <param name="fileName">Name of File (without extension)</param>
        public static void Save(string fileName)
        {
            /* 
             * 1) create the serializer object and serialize the list to the file.
             * 2) use a filestream on which to write the XML file containing
             *    the books list.
            */

            try
            {
                var xs = new XmlSerializer(typeof(List<Book>));
                using(FileStream xmlStream = File.OpenWrite(fileName))
                {
                    xs.Serialize(xmlStream, books);
                }
            }
            catch (Exception ex)
            {
                WriteLine($"Problem with {fileName}.");
                WriteLine($"Program reports {ex.Message}; exiting program.");
                WriteLine("Enter any key to exit.");
                ReadLine();
                Environment.Exit(1);
            }
        } // Save

        /// <summary>
        /// Purpose: List the books on the screen.
        /// 
        /// Programmers: W. Victores, N. S. Clerman
        /// 
        /// Note: This code used to be part of the Main method. On 21-Jul-2017
        ///       it was completely rewritten and made a separate method.
        /// </summary>
        public static void ListBooks()
        {
            // common format string
            const string listFormat = "{0,1}{1,-20}{0,1}{2,-30}{0,1}{3,-11}{0,1}{4,8}";

            WriteLine("Catalog");
            WriteLine("=======");
            WriteLine();
            WriteLine("{0,67}{1}", ' ', "Year");
            WriteLine(listFormat, ' ', "Author", "Title", "ISBN", "Published");
            WriteLine(listFormat, ' ', "------", "-----", "----", "---------");
            string bookInfo = "";
            string[] pairs = new string[Book.NO_OF_PROPS];
            Dictionary<string, string> propValues =
                new Dictionary<string, string>();
            string[] key_value = new string[2];
            foreach (Book book in books)
            {
                bookInfo = "";
                bookInfo = book.ToString();
                pairs = bookInfo.Split(',');
                foreach (string pair in pairs)
                {
                    key_value = pair.Split(':');
                    propValues.Add(key_value[0], key_value[1]);
                }
                WriteLine(listFormat, ' ',
                    propValues[Book.PROP_NAMES[1]] + ' ' +
                    propValues[Book.PROP_NAMES[0]],
                    propValues[Book.PROP_NAMES[2]],
                    propValues[Book.PROP_NAMES[3]],
                    propValues[Book.PROP_NAMES[4]]);
                propValues.Clear();
            } // loop over books
            WriteLine();
        } // ListBooks

        /// <summary>
        /// Purpose: Add a book to the card catalog.
        /// 
        /// Programmers: W. Victores, N. S. Clerman,
        /// 
        /// Revisions
        /// =========
        /// 1) N. S. Clerman, 21-Jul-2017: The code was broken out as a separate
        ///    static method.
        /// </summary>
        public static void AddABook()
        {
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
        }
    }
}