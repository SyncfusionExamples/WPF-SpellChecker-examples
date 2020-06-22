using Syncfusion.SpellChecker.Base;
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Input;

namespace IspellCheck
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
            CultureInfo culture = new CultureInfo("es-ES");

            SpellChecker = new SfSpellChecker();

            // Adding Ispell dictonaries in Dictionaries collection
            SpellChecker.Dictionaries = new DictionaryCollection();

            //Add Spanish culture Ispell dictionary
            SpellChecker.Dictionaries.Add(
                new IspellDictionary()
                {
                    Culture = culture,
                    GrammarUri = new Uri("/IspellCheck;component//Spanish/es-ES.aff", UriKind.Relative),
                    DictionaryUri = new Uri("/IspellCheck;component//Spanish/es-ES.dic", UriKind.Relative)
                }
            );

            //Setting a Spanish culture for SpellChecker
            SpellChecker.Culture = culture;
            Buttonclick = new DelegateCommand(LoadItems, CanLoad);
        }
    }
}
