using Syncfusion.SpellChecker.Base;
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HunSpellCheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextSpellEditor SpellEditor;

        public IEditorProperties Editor
        {
            get;
            set;
        }

        public SfSpellChecker SpellChecker
        {
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
            CultureInfo culture = new CultureInfo("fr-FR");

            // Adding HunSpell dictonaries in Dictionaries collection
            SpellChecker.Dictionaries = new DictionaryCollection();

            //Add French culture HunSpell dictionary
            SpellChecker.Dictionaries.Add(
                new HunspellDictionary()
                {
                    Culture = culture,
                    GrammarUri = new Uri("/HunSpellCheck;component//French/fr-FR.aff", UriKind.Relative),
                    DictionaryUri = new Uri("/HunSpellCheck;component//French/fr-FR.dic", UriKind.Relative)
                }
            );

            //Setting a French culture for SpellChecker
            SpellChecker.Culture = culture;
            SpellChecker.PerformSpellCheckUsingContextMenu(Editor);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SpellChecker.PerformSpellCheckUsingDialog(Editor);
        }
    }
}
