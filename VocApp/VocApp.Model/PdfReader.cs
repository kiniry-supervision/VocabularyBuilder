using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocApp.Model {
    public class PdfReader : Reader {

        protected override string GetString(string filepath) {
            ISet<Word> result = new HashSet<Word>();
            return result;
        }
    }
}
