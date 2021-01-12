using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementXml.DAO
{
    public class Newspaper:ICatalogElement
    {
        public Name Name { get; set; }
        public string PublishingCity { get; set; }
        public string Publisher { get; set; }
        public DateTime Year { get; set; }
        public int PageCount { get; set; }
        public string Note { get; set; }
        public int Number { get; set; }
        public DateTime NewsDate { get; set; }
        public string ISSN { get; set; }
        public override String ToString()
        {
            return Name.name;
        }
    }
}

 
