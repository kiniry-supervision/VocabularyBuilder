using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocApp.Model {
    public abstract class Reader {

        private char[] specialcharacters = { '\n', ' ', '.', ',', '!', '?', '(', ')' };

        protected abstract string GetString(string name);

        public ISet<Word> Read(string source) {
            ISet<Word> result = new HashSet<Word>();
            string readstring = GetString(source);
            StringBuilder stringbuilder = new StringBuilder(20);
            foreach (char c in readstring) {
                if (!SpecialCharacter(c)) {
                    stringbuilder.Append(c);
                } else {
                    string newstring = stringbuilder.ToString();
                    if (newstring.Length > 0) {
                        newstring = newstring.ToLowerInvariant();
                        result.Add(new Word(newstring));
                        stringbuilder.Clear();
                    }
                }
            }
            return result;
        }

        private bool SpecialCharacter(char c) {
            foreach (char sp in specialcharacters) {
                if (sp == c) {
                    return true;
                }
            }
            return false;
        }
    }
}
