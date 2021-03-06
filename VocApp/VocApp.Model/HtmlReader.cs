﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace VocApp.Model {
    public class HtmlReader : Reader {

        WebClient client = new WebClient();

        protected override string GetString(string url) {
            string htmlstring = client.DownloadString(url);
            HtmlDocument htmldoc = new HtmlDocument();
            htmldoc.LoadHtml(htmlstring);
            StringBuilder sb = new StringBuilder();

            htmldoc.DocumentNode.Descendants()
                            .Where(n => n.Name == "script" || n.Name == "style")
                            .ToList()
                            .ForEach(n => n.Remove());


            foreach (HtmlTextNode node in htmldoc.DocumentNode.SelectNodes("//text()")) {
                sb.AppendLine(node.Text);
            }
            return sb.ToString();
        }
    }
}
