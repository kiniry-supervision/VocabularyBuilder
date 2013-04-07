using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VocApp.Model {
    public class HtmlReader : Reader {

        WebClient client = new WebClient();

        protected override string GetString(string url) {
            return client.DownloadString(url);
        }
    }
}
