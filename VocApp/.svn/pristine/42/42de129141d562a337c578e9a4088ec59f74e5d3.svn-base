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
using System.Collections.ObjectModel;

namespace VocApp.Model {
    public class VocAppModel {

        private string fileLanguage = "en";
        public string FileLanguage {
            get {
                return FileLanguage;
            }
            set {
                FileLanguage = value;
            }
        }

        private string yourLanguage = "en";
        public string YourLanguage {
            get {
                return yourLanguage;
            }
            set {
                yourLanguage = value;
            }
        }

        private string targetLanguage = "da";
        public string TargetLanguage {
            get {
                return targetLanguage;
            }
            set {
                targetLanguage = value;
            }
        }

        public List<Item> Items {
            get;
            private set;
        }

        public ObservableCollection<PdfItem> PdfItems {
            get;
            private set;
        }
        public ObservableCollection<HtmlItem> HtmlItems {
            get;
            private set;
        }

        private PdfReader pdfreader;
        private HtmlReader htmlreader;

        public VocAppModel() {
            Items = new List<Item>();
            PdfItems = new ObservableCollection<PdfItem>();
            HtmlItems = new ObservableCollection<HtmlItem>();
            pdfreader = new PdfReader();
            htmlreader = new HtmlReader();
        }

        public void ReadPdf(string filename) {
            ISet<Word> result = pdfreader.Read(filename);
            PdfItem newitem = new PdfItem(filename, result, fileLanguage);
            PdfItems.Add(newitem);
            Items.Add(newitem);
        }

        public void ReadHtml(string url) {
            ISet<Word> result = htmlreader.Read(url);
            HtmlItem newitem = new HtmlItem(url, result, fileLanguage);
            HtmlItems.Add(newitem);
            Items.Add(newitem);
        }

        public Word GetRandomWord() {
            
            Random r = new Random();
            Item[] itemarray = Items.ToArray<Item>();
            Item i = itemarray[r.Next(itemarray.Length)];
            Word[] wordarray = i.words.ToArray<Word>();
            return wordarray[r.Next(wordarray.Length)];
        }


        public Quiz GenerateQuiz() {
            Word word = GetRandomWord();
            MultipleQuiz quiz = new MultipleQuiz(this, word);
            return quiz;
        }

        public string Translate(string txtToTranslate) {
            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + 
                HttpUtility.UrlEncode(txtToTranslate) + "&from=" + YourLanguage + "&to=+" + TargetLanguage;
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
