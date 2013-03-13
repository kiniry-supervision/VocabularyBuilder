using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using VocApp.View;

namespace VocApp.ViewModel {
    class MainViewModel {

        public ICommand launchQuiz { get; private set; }
        public ICommand answerSelect { get; private set; }

        public MainViewModel() {
            launchQuiz = new RelayCommand(beginQuiz);
        }

        public void beginQuiz() {
            MultipleQuizWindow newWindow = new MultipleQuizWindow();
            newWindow.Show(); //  Shows a window
            newWindow.QuestionBox.Text = "Please translate the word Pomfrit ";
        }
    }
}
