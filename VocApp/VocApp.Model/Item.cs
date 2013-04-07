using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocApp.Model {
    public class Item {

        public ISet<Word> words {
            get;
            private set;
        }

        public string Language {
            get;
            private set;
        }

        public Item(ISet<Word> words, string language) {
            this.words = words;
            this.Language = language;
        }
    }
}
