using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocApp.Model {
    public class Word {

        public string Wordstring {
            get;
            private set;
        }

        public int Rating {
            get; 
            set;
        }

        public Word(string Wordstring) {
            this.Wordstring = Wordstring;
        }

        public string ToString() {
            return Wordstring;
        }
    }
}
