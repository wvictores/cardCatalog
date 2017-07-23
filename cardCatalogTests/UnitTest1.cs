using System;
using cardCatalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cardCatalogTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BookToStringTest()
        {
            Book testBook = new Book( "Roth", "Philip", "Goodbye Columbus", "83467", "1960");
            string toStringResult = testBook.ToString();
            string expectedString = "lastName:Roth,firstName:Philip," +
                "title:Goodbye Columbus,longISBN:83467,publishYear:1960";
            Assert.AreEqual(toStringResult, expectedString);
        }
    }
}
