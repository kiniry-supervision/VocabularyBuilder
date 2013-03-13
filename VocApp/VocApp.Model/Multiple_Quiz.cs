using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocApp.Model {
    class Multiple_Quiz : Quiz {
        Word word;
        Word answer;
        Word[] wrong_ans = new Word[4];
        int attempts;

        // constructor
        public Multiple_Quiz(VocApp core, Word word) : base(core) {
            this.word = word;
        }

        // returns the question presented in the gui
        public String GetText() {
           return "Which of the following 5 words is the correct translation for " + word + " ?"; 
        }

        public bool MatchAnswer(string selected) {
            if (answer.ToString() == selected)
                return true;
            else
                attempts++;
            return false;
        }
        

    }
}
