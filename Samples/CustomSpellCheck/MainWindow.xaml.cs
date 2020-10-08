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
        TextSpellEditor SpellEditor;
        public IEditorProperties Editor {
            get;
            set;
        }

        public SfSpellChecker SpellChecker {
            get;
            set;
        }
        public MainWindow()
        {
            SpellChecker = new SfSpellChecker();
            InitializeComponent();
            SpellEditor = new TextSpellEditor(txtbx);
            Editor = SpellEditor;

            //Creating a culture instance
            CultureInfo culture = new CultureInfo("en-US");

            // Instance of Dictionaries collection
            SpellChecker.Dictionaries = new DictionaryCollection();

            // Get the current PROJECT directory
            Uri CustomDict_uri = new Uri(Directory.GetCurrentDirectory() + @"\CustomDictionary\Custom_en-US.txt", UriKind.Absolute);
            //Add US culture Custom dictionary
            SpellChecker.Dictionaries.Add(
                new CustomDictionary()
                {
                    Culture = culture,
                    DictionaryUri = CustomDict_uri
                }
            );

            //Setting a US culture for SpellChecker
            SpellChecker.Culture = culture;
            SpellChecker.PerformSpellCheckUsingContextMenu(Editor);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            SpellChecker.PerformSpellCheckUsingDialog(Editor);
        }
    }
}
