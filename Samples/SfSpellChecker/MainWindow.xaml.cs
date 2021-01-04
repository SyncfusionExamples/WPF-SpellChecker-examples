#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpellChecker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            spellChecker.SpellCheckCompleted += SpellChecker_SpellCheckCompleted;
        }

        private void SpellChecker_SpellCheckCompleted(object sender, EventArgs e)
        {
            if (showMessagebx.IsChecked == true)
            {
                (e as SpellCheckCompletedEventArgs).ShowMessageBox = true;
            }
            else
            {
                (e as SpellCheckCompletedEventArgs).ShowMessageBox = false;
            }
        }

        //Call SpellCheck method to open SpellCheck on button click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            spellChecker.PerformSpellCheckUsingDialog();
        }
    }
}
