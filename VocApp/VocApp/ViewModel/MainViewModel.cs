﻿using System;
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
    public class MainViewModel : ViewModelBase {

        internal VocApp.Model.VocApp model;

        private string pdfpath = "";
        public string PdfPath {
            get {
                return pdfpath;
            }
            set {
                pdfpath = value;
                RaisePropertyChanged("PdfPath");
            }
        }

        private string htmlpath = "";
        public string HtmlPath {
            get {
                return htmlpath;
            }
            set {
                htmlpath = value;
                RaisePropertyChanged("HtmlPath");
            }
        }

        public ICommand StartQuizCommand { get; private set; }
        public ICommand BrowsePdfCommand { get; private set; }
        public ICommand AddPdfCommand { get; private set; }
        public ICommand AddHtmlCommand { get; private set; }

        public MainViewModel() {
            model = new Model.VocApp();

            StartQuizCommand = new RelayCommand(StartQuiz, CanStartQuiz);
            BrowsePdfCommand = new RelayCommand(BrowsePdf);
            AddPdfCommand = new RelayCommand(AddPdf, CanAddPdf);
            AddHtmlCommand = new RelayCommand(AddHtml);
        }

        public void StartQuiz() {
            MultipleQuizWindow newWindow = new MultipleQuizWindow(this);
            newWindow.Show();
        }

        public bool CanStartQuiz() {
            return model.Wordset.Count >= 5;
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
            model.ReadPdf(PdfPath);
            PdfPath = "";
        }

        public bool CanAddPdf() {
            return PdfPath.Length > 0;
        }

        public void AddHtml() {
            model.AddHtml(HtmlPath);
            HtmlPath = "";
        }

        //private bool CanAddHtml() {
        //    return HtmlPath.Length > 0;
        //}
    }
}
