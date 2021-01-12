using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LibraryManagementXml.DAO
{
    public class CatalogWriter
    {
        public static void WriteBook(XmlWriter writer, Book book)
        {
            writer.WriteStartElement("book");
            writer.WriteStartElement("name");
            writer.WriteAttributeString("required", "true");
            writer.WriteString(book.Title.name);
            writer.WriteEndElement();
            writer.WriteStartElement("authors");
            foreach (var a in book.Authors)
            {
                writer.WriteElementString("author", a);
            }
            writer.WriteEndElement();
            writer.WriteElementString("publisherCity", book.PublisherCity);
            writer.WriteElementString("publisherName", book.PublisherName);
            writer.WriteElementString("year", book.Year.ToString("yyyyMMdd"));
            writer.WriteElementString("pagesCount", book.PagesCount.ToString());
            writer.WriteElementString("notes", book.Notes);
            writer.WriteElementString("ISBN", book.ISBN);
            writer.WriteEndElement();
        }

        public static void WriteNewspaper(XmlWriter writer, Newspaper paper)
        {
            writer.WriteStartElement("newspaper");
            writer.WriteStartElement("name");
            writer.WriteAttributeString("required", "true");
            writer.WriteString(paper.Name.name);
            writer.WriteEndElement();
            writer.WriteElementString("publisherCity", paper.PublishingCity);
            writer.WriteElementString("publisher", paper.Publisher);
            writer.WriteElementString("year", paper.Year.ToString("yyyyMMdd"));
            writer.WriteElementString("pagesCount", paper.PageCount.ToString());
            writer.WriteElementString("note", paper.Note);
            writer.WriteElementString("number", paper.Number.ToString());
            writer.WriteElementString("date", paper.NewsDate.ToString("yyyyMMdd"));
            writer.WriteElementString("issn", paper.ISSN);
            writer.WriteEndElement();
        }


        public static void WritePatent(XmlWriter writer, Patent patent)
        {
            writer.WriteStartElement("patent");
            writer.WriteStartElement("name");
            writer.WriteAttributeString("required", "true");
            writer.WriteString(patent.Name.name);
            writer.WriteEndElement();
            writer.WriteStartElement("inventors");
            foreach (var a in patent.Inventors)
            {
                writer.WriteElementString("inventor", a);
            }
            writer.WriteEndElement();
            writer.WriteElementString("country", patent.Country);
            writer.WriteElementString("registrationNumber", patent.RegistrationNumber);
            writer.WriteElementString("applyDate", patent.ApplyDate.ToString("yyyyMMdd"));
            writer.WriteElementString("publicationDate", patent.PublicationDate.ToString("yyyyMMdd"));
            writer.WriteElementString("pageCount", patent.PageCount.ToString());
            writer.WriteElementString("note", patent.Note);
            writer.WriteEndElement();

        }

    }
}
