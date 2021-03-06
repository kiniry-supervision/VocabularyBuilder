﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VocApp.Model;
using VocApp.ViewModel;

namespace VocApp.View {
    /// <summary>
    /// Interaction logic for MultipleQuizWindow.xaml
    /// </summary>

    public partial class MultipleQuizWindow : Window {

        public MultipleQuizViewModel vmQuiz;

        public MultipleQuizWindow(MainViewModel mvm) {
            InitializeComponent();
            vmQuiz = new MultipleQuizViewModel(mvm);
            this.DataContext = vmQuiz;
        }

        private void Next_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}