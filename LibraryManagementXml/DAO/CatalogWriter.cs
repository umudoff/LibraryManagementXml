using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LibraryManagementXml.DAO
{
    public class CatalogWriter
    {
       

        public static void WriteDocument(string FilePath, IEnumerable<ICatalogElement> LibraryCatalog)
        {
            var settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "    "
            };
            using (XmlWriter writer = XmlWriter.Create(FilePath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("catalog");


                foreach (var c in LibraryCatalog)
                {
                    CatalogWriter.Write(writer, c);
                }

                writer.WriteEndDocument();

            }
        }
        public static void Write(XmlWriter writer, ICatalogElement catalogElement)
        {
            if (catalogElement is Book)
            {
                WriteBook(writer,(Book)catalogElement);
            }
            if (catalogElement is Newspaper)
            {
                WriteNewspaper(writer,(Newspaper)catalogElement);
            }
            if (catalogElement is Patent)
            {
                WriteElementPatent(writer,(Patent)catalogElement);
            }
        }
        private static void WriteBook(XmlWriter writer, Book book)
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
            writer.WriteElementString("year", book.Year);
            writer.WriteElementString("pagesCount", book.PagesCount.ToString());
            writer.WriteElementString("notes", book.Notes);
            writer.WriteElementString("ISBN", book.ISBN);
            writer.WriteEndElement();
        }

        private static void WriteNewspaper(XmlWriter writer, Newspaper paper)
        {
            writer.WriteStartElement("newspaper");
            writer.WriteStartElement("name");
            writer.WriteAttributeString("required", "true");
            writer.WriteString(paper.Name.name);
            writer.WriteEndElement();
            writer.WriteElementString("publisherCity", paper.PublishingCity);
            writer.WriteElementString("publisher", paper.Publisher);
            writer.WriteElementString("year", paper.Year);
            writer.WriteElementString("pageCount", paper.PageCount.ToString());
            writer.WriteElementString("note", paper.Note);
            writer.WriteElementString("number", paper.Number.ToString());
            writer.WriteElementString("date", paper.NewsDate.ToString("yyyyMMdd"));
            writer.WriteElementString("issn", paper.ISSN);
            writer.WriteEndElement();
        }


        private static void WritePatent(XmlWriter writer, Patent patent)
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

        public static void WriteElementPatent(XmlWriter writer , Patent patent)
        { 
            var element = new XElement("patent");
            element.Add(new XElement("name", patent.Name.name, new XAttribute("required","true")));             
            element.Add(new XElement("inventors", patent.Inventors.Select(i => new XElement("inventor", i))));
            element.Add(new XElement("country", patent.Country));
            element.Add(new XElement("registrationNumber", patent.RegistrationNumber));
            element.Add(new XElement("applyDate", patent.ApplyDate.ToString("yyyyMMdd")));
            element.Add(new XElement("publicationDate", patent.PublicationDate.ToString("yyyyMMdd")));
            element.Add(new XElement("pageCount", patent.PageCount.ToString()));
            element.Add(new XElement("note", patent.Note));
            element.WriteTo(writer);
        }

    }
}
