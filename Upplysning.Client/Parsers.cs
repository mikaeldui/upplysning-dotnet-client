using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Upplysning
{
    internal static class UpplysningPeopleParser
    {
        public static async Task<UpplysningPersonResult[]> ParsePeopleAsync(string searchResultHtml) => await Task.Run(() =>
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(searchResultHtml);

            var pnrNodes = doc.DocumentNode.SelectNodes("//*[text()[contains(., '-XXXX')]]");

            if (pnrNodes == null)
                return null;

            return pnrNodes.Select(n => n.ParentNode.ParentNode).Where(_ => !string.IsNullOrWhiteSpace(_.InnerText)).Where(_ => !_.InnerHtml.Contains("pagination")).Select(personNode =>
            {
                string name;
                string spokenName = null;
                string personnummer;
                string address;
                string postalCode;
                string city;

                {
                    name = personNode.Descendants().First(n => n.HasClass("name")).InnerText;
                    if (name.Contains("<b>"))
                    {
                        spokenName = name.Between("<b>", "</b>");
                        name = name.Replace("<b>", "").Replace("</b>", "");
                    }
                }

                personnummer = personNode.Descendants().First(n => n.HasClass("gray-text")).InnerText.Substring(0, 13);

                {
                    var addressColumnNode = personNode.ChildNodes[1];
                    var nodeCount = addressColumnNode.ChildNodes.Count;
                    {
                        address = addressColumnNode.ChildNodes[nodeCount - 3].InnerText;
                    }

                    var postalCodeAndCityNode = addressColumnNode.ChildNodes[nodeCount - 2];
                    postalCode = postalCodeAndCityNode.InnerText[..6];
                    city = postalCodeAndCityNode.InnerText[12..];
                }

                return new UpplysningPersonResult
                (
                    name: name,
                    spokenName: spokenName,
                    personnummer: personnummer,
                    address: address,
                    postalCode: postalCode,
                    city: city
                );
            }).ToArray();
        });
    }
}
