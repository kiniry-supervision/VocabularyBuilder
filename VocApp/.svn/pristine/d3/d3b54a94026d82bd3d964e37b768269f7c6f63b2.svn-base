using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace VocApp.Model {
    public class PdfReader : Reader {

        protected override string GetString(string filepath) {
            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(filepath);
            string pdfstring = "";
            for (int page = 1; page <= reader.NumberOfPages; page++) {
                pdfstring += PdfTextExtractor.GetTextFromPage(reader, page);
            }
            reader.Close();
            return pdfstring;
        }
    }
}
