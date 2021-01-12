using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LibraryManagementXml.DAO;

namespace LibraryManagementXml
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<ICatalogElement> catalog = PopulateCatalog.readFrom(@"..\..\CatalogSample.xml");
            Book book=null;
            Newspaper paper = null;
            Patent patent = null;
            foreach (var c in catalog)
            {
                if(c is Book)
                {
                    book = (Book)c;
                }
                if (c is Newspaper)
                {
                    paper=(Newspaper)c;
                }
                if(c is Patent){
                    patent = (Patent)c;
                }

                Console.WriteLine(c.ToString());
             }

            Console.WriteLine("Bk:" + book.ToString());

            using (XmlWriter writer = XmlWriter.Create(@"..\..\CatalogWriterExample.xml")) {
                writer.WriteStartDocument();
                writer.WriteStartElement("catalog");
                
                CatalogWriter.WriteBook(writer, book);
                CatalogWriter.WriteNewspaper(writer, paper);
                CatalogWriter.WritePatent(writer, patent);

                writer.WriteEndDocument();
                
             }

    
            Console.ReadLine();
        }


    }
}
