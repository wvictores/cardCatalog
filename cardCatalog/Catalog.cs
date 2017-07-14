using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardCatalog
{

    class Catalog
    {
        public enum options { list = 1, add, save }
        private List<Book> books;
        private string _filename = "books.xml";
        static void Main(string[] args)
        {
            // var books = new List<Book>;


            bool finished = false;
            WriteLine("Welcome to the card catalog");
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
                while (!finished) ;

                switch (choice)

                {

                    case "1": // Do Something

                        break;

                    case "2": //Do that

                        break;

                    case "3": //Do that

                        break;
                    case "4": (!finished) 

                        break;

                }

            } while (choice != "0")




              /*  Book 1 = new Book();
            1.lastName = "Atwood";
            1.firstName = "Margaret";
            1.longISBN = "5882300312";
            1.PublishYear = "2007";
            Console.WriteLine();
            Console.ReadLine();

            Console.WriteLine("Enter a Last Name: ");
            String lastName;
            lastName = Console.ReadLine();
            Console.WriteLine("Enter a First Name: ");
            String firstName;
            Console.WriteLine("Enter a long ISBN: ");
            string ISBN;
            }
            */
    }
    }
