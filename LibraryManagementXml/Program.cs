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
            foreach (var c in catalog)
            {
                Console.WriteLine(c.ToString());
            }
          
            Console.ReadLine();
        }



    }
}
