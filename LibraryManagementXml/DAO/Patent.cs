using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementXml.DAO
{
    class Patent:ICatalogElement
    {
        public Name Name { get; set; }
        public List<string> Inventors { get; set; }
        public string Country { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime PublicationDate { get; set; }
        public int PageCount { get; set; }
        public string Note { get; set; }

        public override String ToString()
        {
            return Name.name;
        }
    }
}

 