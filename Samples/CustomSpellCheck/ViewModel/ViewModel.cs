using Syncfusion.SpellChecker.Base;
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomSpellCheck
{
    public class ViewModel : NotificationObject
    {
        private ICommand buttonclick;
        public SfSpellChecker SpellChecker
        {
            get;
            set;
        }

        public IEditorProperties Editor
        {
            get;
            set;
        }

        public ICommand Buttonclick
        {
            get
            {
                return buttonclick;
            }
            set
            {
                buttonclick = value;
                RaisePropertyChanged("Buttonclick");
            }
        }

        private bool CanLoad(object arg)
        {
            return true;
        }
        private void LoadItems(object obj)
        {
            Editor = new TextSpellEditor(obj as TextBox);
            SpellChecker.PerformSpellCheckUsingContextMenu(Editor);
            SpellChecker.PerformSpellCheckUsingDialog(Editor);
        }
        public ViewModel()
        {
            //Creating a culture instance
            CultureInfo culture = new CultureInfo("en-US");

            SpellChecker = new SfSpellChecker();

            // Adding HunSpell dictonaries in Dictionaries collection
            SpellChecker.Dictionaries = new DictionaryCollection();

            //Add US culture HunSpell dictionary
            SpellChecker.Dictionaries.Add(
                new HunspellDictionary()
                {
                    Culture = culture,
                    GrammarUri = new Uri("/CustomSpellCheck;component//English/en-US.aff", UriKind.Relative),
                    DictionaryUri = new Uri("/CustomSpellCheck;component//English/en-US.dic", UriKind.Relative)
                }
            );

            // Get the current PROJECT directory
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;

            //Add US culture Custom dictionary
            SpellChecker.Dictionaries.Add(
                new CustomDictionary()
                {
                    Culture = culture,
                    DictionaryUri = new Uri(projectDirectory + @"\English\Custom_en-US.txt", UriKind.Absolute)
                }
            );

            //Setting a US culture for SpellChecker
            SpellChecker.Culture = culture;
            Buttonclick = new DelegateCommand(LoadItems, CanLoad);
        }
    }
}
