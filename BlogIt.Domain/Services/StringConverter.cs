using System.Collections.Generic;
using System.Xml.Linq;

namespace BlogIt.Domain.Services
{
    /// <summary>
    /// Static class containing string helper methods.
    /// </summary>
    public static class StringConverter
    {
        /// <summary>
        /// String extension method that converts the provided set of key/value pairs to an XML document.
        /// </summary>
        /// <param name="source">Source data</param>
        /// <returns>Source data as an XML string</returns>
        public static string ToXML(this Dictionary<string, string> source)
        {
            XDocument document = new XDocument(new XElement("Source"));

            foreach (KeyValuePair<string, string> element in source)
            {
                document.Root.Add(new XElement(element.Key, element.Value));
            }

            return document.ToString(SaveOptions.DisableFormatting);
        }
    }
}
