using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementXml.DAO
{
     public class Name
    {
        public string name { get; set; }
        public bool required { get; set; }
       public  Name(string n, bool r) { this.required = r; this.name = n; }
       public  Name() { }

    }
    public class Book :ICatalogElement
    {
       public Name Title { get; set; }
       public List<string> Authors{ get; set; }
       public string PublisherCity { get; set; }
       public string PublisherName { get; set; }
       public string Year { get; set; }
       public int PagesCount { get; set; }
       public string Notes { get; set; }
       public string ISBN { get; set; }

        public override String ToString()
        {
            return Title.name;
        }
   
    }
}

 