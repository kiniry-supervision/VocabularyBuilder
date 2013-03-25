using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using VocApp.View;
using VocApp.Model;

namespace VocApp.ViewModel {
    class MainViewModel {

        internal VocApp.Model.VocApp model;

        public ICommand launchQuiz { get; private set; }
        public ICommand ReadPdfCommand { get; private set; }
        public ICommand ReadHtmlCommand { get; private set; }

        public MainViewModel() {
            model = new Model.VocApp();

            launchQuiz = new RelayCommand(beginQuiz);
            ReadPdfCommand = new RelayCommand(ReadPdf);
            ReadHtmlCommand = new RelayCommand(ReadHtml);
        }

        public void beginQuiz() {
            MultipleQuizWindow newWindow = new MultipleQuizWindow();
            newWindow.Show(); //  Shows a window
            newWindow.QuestionBox.Text = "Please translate the word Pomfrit ";
        }

        public void ReadPdf() {
            Microsoft.Win32.OpenFileDialog filedialog = new Microsoft.Win32.OpenFileDialog();
            filedialog.DefaultExt = ".pdf";
            filedialog.Filter = "Portable Document Format documents (.pdf)|*.pdf";
            Nullable<bool> result = filedialog.ShowDialog();
            if (result == true) {
                model.ReadPdf(filedialog.FileName);
            }
        }

        public void ReadHtml() {

        }
    }
}
