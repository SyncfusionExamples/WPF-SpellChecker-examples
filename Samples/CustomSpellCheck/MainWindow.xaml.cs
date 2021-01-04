using Syncfusion.SpellChecker.Base;
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomSpellCheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        
        public MainWindow()
        {           
            InitializeComponent(); 
        }

        private void SpellCheck_Clicked(object sender, RoutedEventArgs e) {
            spellChecker.PerformSpellCheckUsingDialog();
        }
    }
}
