using LibraryManagementXml.DAO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace LibraryManagementXml.Test
{
    [TestFixture]
    public class LibraryManagementTests
    {

        string path = "";
        Book book;
        Newspaper paper;
        Patent patent;

        [SetUp]
        public void Init()
        { 
            path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"..\..\";
            book = new Book {  Title = new Name("C# in Depth: Fourth Edition",true),
                                Authors= new List<string>  { "Jon Skeet" } ,
                                PublisherCity = "New York",
                                Year= "2019",
                                PagesCount=528,
                                Notes= "Effective techniques and experienced insights to C#",
                                ISBN= "1617294535"
            };

            paper = new Newspaper
            {
                Name = new Name(" The Guardian", true),
                PublishingCity = "London",
                Publisher = "The Guardian",
                Year = new DateTime(Convert.ToInt32(1821), 1, 1),
                PageCount = 20,
                Note = "British daily newspaper",
                Number = 1,
                NewsDate = DateTime.ParseExact("20200105", "yyyyMMdd", CultureInfo.InvariantCulture),
                ISSN = "0261-3077"
            };
            patent = new Patent
            {
                Name = new Name("Computer mouse", true),
                Inventors = new List<string> { " Lo; Jack", "Robinson; Calvin H. A." },
                Country = "US",
                RegistrationNumber = "EP1374218A1",
                ApplyDate = DateTime.ParseExact("19961029", "yyyyMMdd", CultureInfo.InvariantCulture),
                PublicationDate = DateTime.ParseExact("20040102", "yyyyMMdd", CultureInfo.InvariantCulture),
                PageCount = 100,
                Note = "An improved mouse computer input device (101) is provided which can easily be controlled"

            };

        }

        [Test]
        public void LibraryManagementTest_TestBook()
        {
            var filepath = path + @"TestBook.xml";
            //IEnumerable<ICatalogElement> bookCatalog= new List<ICatalogElement>() { book};
           // CatalogWriter.WriteDocument(filepath, bookCatalog);
            IEnumerable<ICatalogElement> readBookCatalog=  CatalogReader.readFrom(filepath);
            Book resultBook=null;
              foreach (var b in readBookCatalog) { 
                resultBook=(Book)b;
                Console.WriteLine(b);
             }

           Assert.AreEqual(resultBook, book);
             

        }







    }
}
