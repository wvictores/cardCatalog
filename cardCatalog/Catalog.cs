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
            } while (!finished);


            }

    }
    }
