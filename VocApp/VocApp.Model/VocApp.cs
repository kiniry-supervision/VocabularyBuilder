using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Runtime.Serialization.Json;

namespace VocApp.Model {
    public class VocApp {


        private string fromLanguage = "en";
        public string FromLanguage {
            get {
                return fromLanguage;
            }
            set {
                fromLanguage = value;
            }
        }

        private string toLanguage = "es";
        public string ToLanguage {
            get {
                return toLanguage;
            }
            set {
                toLanguage = "en";
            }
        }

        private ISet<Word> Wordset;
        private PdfReader pdfreader;
        private HtmlReader htmlreader;

        public VocApp() {
            Wordset = new HashSet<Word>();
            pdfreader = new PdfReader();
            htmlreader = new HtmlReader();
        }

        public void ReadPdf(string filename) {
            ISet<Word> result = pdfreader.Read(filename);
            Wordset.UnionWith(result);
        }

        public Word GetRandomWord() {
            Word[] wordarray = Wordset.ToArray<Word>();
            Random r = new Random();
            return wordarray[r.Next(wordarray.Length)];
        }

        public string Translate(string txtToTranslate) {
            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + 
                HttpUtility.UrlEncode(txtToTranslate) + "&from=" + FromLanguage + "&to=+" + ToLanguage;
            WebRequest translationWebRequest = System.Net.WebRequest.Create(uri);
            translationWebRequest.Headers.Add("Authorization", getAccessToken());
            WebResponse response = null;
            response = translationWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader translatedStream = new System.IO.StreamReader(stream, encode);
            XmlDocument xTranslation = new System.Xml.XmlDocument();
            xTranslation.LoadXml(translatedStream.ReadToEnd());
            return xTranslation.InnerText;
        }

        public string getAccessToken() {
            string clientID = "Fagprojekt";
            string clientSecret = "Ons8Cd47hFxMfwGGvlOtUPsp3WJcLA5agDAyTc7KMEg=";
            String strTranslatorAccessURI = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";
            String strRequestDetails = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=http://api.microsofttranslator.com", HttpUtility.UrlEncode(clientID), HttpUtility.UrlEncode(clientSecret));
            WebRequest webRequest = WebRequest.Create(strTranslatorAccessURI);
            
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(strRequestDetails);
            webRequest.ContentLength = bytes.Length;
            using (System.IO.Stream outputStream = webRequest.GetRequestStream()) {
                outputStream.Write(bytes, 0, bytes.Length);
            }
            WebResponse webResponse = webRequest.GetResponse();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AdmAccessToken));

            //Get deserialized object from JSON stream 

            AdmAccessToken token = (AdmAccessToken)serializer.ReadObject(webResponse.GetResponseStream());
            return "Bearer " + token.access_token;
        }
    }
}
