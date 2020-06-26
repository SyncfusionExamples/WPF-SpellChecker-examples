using Syncfusion.SpellChecker.Base;
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OpenOfficeSpellCheck
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

        public MainWindow() {
            SpellChecker = new SfSpellChecker();
            InitializeComponent();
            SpellEditor = new TextSpellEditor(txtbx);
            Editor = SpellEditor;

            //Creating a Spanish culture instance
            CultureInfo culture = new CultureInfo("es-ES");

            SpellChecker = new SfSpellChecker();

            // Adding OpenOffice dictonaries in Dictionaries collection
            SpellChecker.Dictionaries = new DictionaryCollection();

            //Add Spanish culture OpenOffice dictionary
            SpellChecker.Dictionaries.Add(
                new OpenOfficeDictionary()
                {
                    Culture = culture,
                    GrammarUri = new Uri("/OpenOfficeSpellCheck;component//Spanish/es-ES.aff", UriKind.Relative),
                    DictionaryUri = new Uri("/OpenOfficeSpellCheck;component//Spanish/es-ES.dic", UriKind.Relative)
                }
            );

            //Setting a French culture for SpellChecker
            SpellChecker.Culture = culture;
            SpellChecker.PerformSpellCheckUsingContextMenu(Editor);
        }
        
        private void Button_Click(object sender, RoutedEventArgs e) {
            SpellChecker.PerformSpellCheckUsingDialog(Editor);
        }
    }
}
