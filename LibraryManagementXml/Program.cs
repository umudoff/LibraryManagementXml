using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using LibraryManagementXml.DAO;

namespace LibraryManagementXml
{
    class Program
    {
        static void Main(string[] args)
        {
            //@"..\..\CatalogWriterExample.xml" 
            //@"..\..\CatalogSample.xml"
           var  path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"..\..\";

           
            
          IEnumerable<ICatalogElement> catalog = CatalogReader.readFrom(path+@"CatalogSample.xml");

            foreach ( var c in catalog)
            {
                Console.WriteLine(c.ToString());
            }

            Console.ReadLine();
        }

    }
}
