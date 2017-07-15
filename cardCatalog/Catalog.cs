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
        private static List<Book> books = new List<Book>();
        private static string _filename;
        static void Main(string[] args)
        {
            /*
             * Purpose: Main method. Setup XML file. Prompt user for operation.
             * Invoke the appropriate procedure to perform it.
             * 
             * Programmers: W. Victores, N. S. Clerman, 13-Jul-2017
             */

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
                try
                {
                    using(xmlStream = File.OpenRead(_filename))
                    {
                        books = (List<Book>)xs.Deserialize(xmlStream);
                    }
                }
                catch(Exception ex)
                {
                    WriteLine($"Problem with {_filename}.");
                    WriteLine($"Program reports {ex.Message}; exiting program.");
                    WriteLine("Enter any key to exit.");
                    ReadLine();
                    Environment.Exit(1);
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
                        WriteLine("Catalog");
                        WriteLine("=======");
                        foreach (Book book in books)
                        {
                            book.PrintBookInfo();
                        }
                        kountTries = 0;
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

        public static void Save(string fileName)
        {
            /*
             * Purpose: Write the books List as an XML file.
             * 
             * Author: N. S. Clerman, 14-Jul-2017
             * 
             * Revisions
             * =========
             * 1) N. S. Clerman, 15-Jul-2017: Add some exception handling.
             *    Remove some debugging code.
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
    }
}