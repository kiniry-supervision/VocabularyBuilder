using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using VocApp.View;
using VocApp.Model;

namespace VocApp.ViewModel {
    public class MultipleQuizViewModel {

        internal MainViewModel mvm;

        private string ans1;
        public string Ans1 {
            get {
                return ans1;
            }
            set {
                ans1 = value;
            }
        }
        private string ans2;
        public string Ans2 {
            get {
                return ans2;
            }
            set {
                ans2 = value;
            }
        }
        private string ans3;
        public string Ans3 {
            get {
                return ans3;
            }
            set {
                ans3 = value;
            }
        }
        private string ans4;
        public string Ans4 {
            get {
                return ans4;
            }
            set {
                ans4 = value;
            }
        }
        private string ans5;
        public string Ans5 {
            get {
                return ans5;
            }
            set {
                ans5 = value;
            }
        }
        private string text;
        public string Text {
            get {
                return text;
            }
            set {
                text = value;
            }
        }

        public MultipleQuizViewModel(MainViewModel mvm) {
            this.mvm = mvm;
            MultipleQuiz quiz = mvm.model.GenerateQuiz() as MultipleQuiz;
            string[] words = quiz.AllAnswers;
            text = "Please translate the word " + quiz.word.Wordstring;
            ans1 = words[0];
            ans2 = words[1];
            ans3 = words[2];
            ans4 = words[3];
            ans5 = words[4];
        }
    }
}