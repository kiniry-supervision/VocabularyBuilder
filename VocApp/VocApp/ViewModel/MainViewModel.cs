using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using VocApp.View;
using VocApp.Model;
using GalaSoft.MvvmLight;

namespace VocApp.ViewModel {
    class MainViewModel : ViewModelBase {

        internal VocApp.Model.VocApp model;

        private string pdfpath = "";
        public string PdfPath {
            get {
                return pdfpath;
            }
            set {
                pdfpath = value;
                RaisePropertyChanged("Pdfpath");
            }
        }

        public ICommand launchQuiz { get; private set; }
        public ICommand BrowsePdfCommand { get; private set; }
        public ICommand AddPdfCommand { get; private set; }
        public ICommand ReadHtmlCommand { get; private set; }

        public MainViewModel() {
            model = new Model.VocApp();

            launchQuiz = new RelayCommand(beginQuiz);
            BrowsePdfCommand = new RelayCommand(BrowsePdf);
            AddPdfCommand = new RelayCommand(AddPdf, CanAddPdf);
            ReadHtmlCommand = new RelayCommand(ReadHtml);
        }

        public void beginQuiz() {
            MultipleQuizWindow newWindow = new MultipleQuizWindow();
            newWindow.Show(); //  Shows a window
            newWindow.QuestionBox.Text = "Please translate the word Pomfrit ";
        }

        private void BrowsePdf() {
            Microsoft.Win32.OpenFileDialog filedialog = new Microsoft.Win32.OpenFileDialog();
            filedialog.DefaultExt = ".pdf";
            filedialog.Filter = "Portable Document Format documents (.pdf)|*.pdf";
            Nullable<bool> result = filedialog.ShowDialog();
            if (result == true) {
                PdfPath = filedialog.FileName;
            }
        }

        public void AddPdf() {
            model.ReadPdf(pdfpath);
            PdfPath = "";
        }

        public bool CanAddPdf() {
            return pdfpath.Length > 0;
        }

        public void ReadHtml() {

        }
    }
}
