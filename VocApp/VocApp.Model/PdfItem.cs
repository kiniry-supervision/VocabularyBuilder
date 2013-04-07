using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocApp.Model {
    public class PdfItem : Item {

        public string Filename {
            get;
            private set;
        }

        public PdfItem(string filename, ISet<Word> words, string language)
            : base(words, language) {
            this.Filename = filename;
        }
    }
}
