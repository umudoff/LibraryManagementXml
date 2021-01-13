using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LibraryManagementXml.DAO
{
    public class CatalogReader
    {

        private static ICatalogElement PopulateBook(XmlReader reader)
        {
            reader.ReadToFollowing("name");
            var nameRequired = reader.GetAttribute("required");
            var name = reader.ReadElementContentAsString();
            List<string> authors = new List<string>();
            reader.ReadToFollowing("authors");
                using (var innerReader = reader.ReadSubtree())
                {
                    while (innerReader.ReadToFollowing("author"))
                    {
                        authors.Add(innerReader.ReadElementContentAsString());
                    }
                } 
            reader.ReadToFollowing("publisherCity");
            var publisherCity = reader.ReadElementContentAsString();
            reader.ReadToFollowing("year");
            var year = reader.ReadElementContentAsString();
            reader.ReadToFollowing("pagesCount");
            int pageCount = reader.ReadElementContentAsInt();
            reader.ReadToFollowing("notes");
            var notes = reader.ReadElementContentAsString();
            reader.ReadToFollowing("ISBN");
            string isbn = reader.ReadElementContentAsString();
            return new Book
            {
                Title = new Name(name, bool.Parse(nameRequired)),
                Authors = authors,
                PublisherCity = publisherCity,
                Year = year,
                PagesCount = pageCount,
                Notes = notes,
                ISBN = isbn
            };

        }


        private static ICatalogElement PopulateNewspaper(XmlReader reader)
        {
            reader.ReadToFollowing("name");
            var nameRequired = bool.Parse(reader.GetAttribute("required"));
            var name = reader.ReadElementContentAsString();
            reader.ReadToFollowing("publisherCity");
            var publisherCity = reader.ReadElementContentAsString();
            reader.ReadToFollowing("publisher");
            var publisher = reader.ReadElementContentAsString();
            reader.ReadToFollowing("year");
            var year = reader.ReadElementContentAsString();
            reader.ReadToFollowing("pageCount");
            int pageCount = reader.ReadElementContentAsInt();
            reader.ReadToFollowing("note");
            var note = reader.ReadElementContentAsString();
            reader.ReadToFollowing("number");
            int number = reader.ReadElementContentAsInt();
            reader.ReadToFollowing("date");
            var date = DateTime.ParseExact(reader.ReadElementContentAsString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            reader.ReadToFollowing("issn");
            var issn = reader.ReadElementContentAsString();

            return new Newspaper
            {
                Name = new Name(name, nameRequired),
                PublishingCity = publisherCity,
                Publisher = publisher,
                Year = new DateTime(Convert.ToInt32(year), 1, 1),
                PageCount = pageCount,
                Note = note,
                Number = number,
                NewsDate = date,
                ISSN = issn
            };


        }


        private static ICatalogElement PopulatePatent(XmlReader reader)
        {
            reader.ReadToFollowing("name");
            var nameRequired = bool.Parse(reader.GetAttribute("required"));
            var name = reader.ReadElementContentAsString();
            List<string> inventors = new List<string>();
            reader.ReadToFollowing("inventors");

            using (var innerReader = reader.ReadSubtree())
            {
                while (innerReader.ReadToFollowing("inventor"))
                {
                    inventors.Add(innerReader.ReadElementContentAsString());
                }
            }
            reader.ReadToFollowing("country");
            var country = reader.ReadElementContentAsString();
            reader.ReadToFollowing("registrationNumber");
            var registrationNumber = reader.ReadElementContentAsString();
            reader.ReadToFollowing("applyDate");
            var applyDate = DateTime.ParseExact(reader.ReadElementContentAsString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            reader.ReadToFollowing("publicationDate");
            var publicDate = DateTime.ParseExact(reader.ReadElementContentAsString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            reader.ReadToFollowing("pageCount");
            var pageCount = reader.ReadElementContentAsInt();
            reader.ReadToFollowing("note");
            var note = reader.ReadElementContentAsString();
            return new Patent
            {
                Name = new Name(name, nameRequired),
                Inventors = inventors,
                Country = country,
                RegistrationNumber = registrationNumber,
                ApplyDate = applyDate,
                PublicationDate = publicDate,
                PageCount = pageCount,
                Note = note
            };

        }


        private static ICatalogElement readPatent(XmlReader reader)
        {
            var patentElement = XNode.ReadFrom(reader) as XElement;
            var name = patentElement.Element("name").Value;
            bool requiredName = bool.Parse(patentElement.Element("name").Attribute("required").Value);
            List<string> inventors = patentElement.Element("inventors").Elements("inventor").Select(x => x.Value).ToList();
            var country = patentElement.Element("country").Value;
            var registrationNumber = patentElement.Element("registrationNumber").Value;
            DateTime applyDate = DateTime.ParseExact(patentElement.Element("applyDate").Value, "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime publicationDate = DateTime.ParseExact(patentElement.Element("publicationDate").Value, "yyyyMMdd", CultureInfo.InvariantCulture);
            var pageCount = int.Parse(patentElement.Element("pageCount").Value);
            var note = patentElement.Element("note").Value;

            return new Patent
            {
                Name = new Name(name, requiredName),
                Inventors = inventors,
                Country = country,
                RegistrationNumber = registrationNumber,
                ApplyDate = applyDate,
                PublicationDate = publicationDate,
                PageCount = pageCount,
                Note = note
            };

        }


        public static IEnumerable<ICatalogElement> readFrom(string input)
        {

            var reader = XmlReader.Create(input);
            reader.ReadToFollowing("catalog");
            reader.ReadStartElement();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "book")
                {
                    yield return CatalogReader.PopulateBook(reader);
                }

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "newspaper")
                {
                    yield return CatalogReader.PopulateNewspaper(reader);
                }

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "patent")
                {
                    yield return CatalogReader.readPatent(reader);
                }


            }

        }
    }




}
