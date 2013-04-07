using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using VocApp.Model;

namespace VocApp.ViewModel {
    public class PdfArchiveViewModel {

        public MainViewModel mvm { get; private set; }

        public PdfItem SelectedItem { get; set; }

        public ICommand DeletePdfCommand { get; private set; }

        public PdfArchiveViewModel(MainViewModel mvm) {
            this.mvm = mvm;
            DeletePdfCommand = new RelayCommand(DeletePdf, CanDeletePdf);
        }

        public void DeletePdf() {
            mvm.model.Items.Remove(SelectedItem);
            mvm.model.PdfItems.Remove(SelectedItem);
        }

        public bool CanDeletePdf() {
            return SelectedItem != null;
        }
    }
}
