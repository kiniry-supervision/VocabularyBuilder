using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocApp.Model {
    public abstract class Reader {

        private char[] specialchars = { '\n', ' ', '.', ',', '!', '?', '(', ')' };

        protected abstract string GetString(string name);

        public ISet<Word> Read(string source) {
            ISet<Word> result = new HashSet<Word>();
            string readstring = GetString(source);
            bool skiptonextspace = false;
            StringBuilder stringbuilder = new StringBuilder(20);
            foreach (char c in readstring) {
                if (!skiptonextspace) {
                    if (char.IsLetter(c)) {
                        stringbuilder.Append(c);
                    } else if (IsSpecialCharacter(c)) {
                        string newstring = stringbuilder.ToString();
                        if (newstring.Length > 0) { // Only add if the new word isn't the empty string.
                            newstring = newstring.ToLowerInvariant();
                            result.Add(new Word(newstring));
                            stringbuilder.Clear();
                        }
                    } else { // The word contains a number or a symbol not listed in 'specialchars' and the program skips to the next word.
                        stringbuilder.Clear();
                        skiptonextspace = true;
                    }
                } else if (c == ' ') {
                    skiptonextspace = false;
                }
            }
            return result;
        }

        private bool IsSpecialCharacter(char c) {
            foreach (char sp in specialchars) {
                if (sp == c) {
                    return true;
                }
            }
            return false;
        }
    }
}
