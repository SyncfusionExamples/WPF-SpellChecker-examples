#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SpellChecker
{

    public class ViewModel : NotificationObject
    {
        public SfSpellChecker SpellChecker
        {
            get;
            set;
        }

        public bool showMessageBox = true;
        public bool ShowMessageBox
        {
            get
            {
                return showMessageBox;
            }
            set
            {
                showMessageBox = value;
                RaisePropertyChanged("ShowMessageBox");
            }
        }
        public IEditorProperties Editor
        {
            get;
            set;
        }

        private ICommand buttonclick;
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

        public ViewModel()
        {
            SpellChecker = new SfSpellChecker();           
            Buttonclick = new DelegateCommand(LoadItems, CanLoad);
        }
        private bool CanLoad(object arg)
        {
            return true;
        }
        private void LoadItems(object obj)
        {
            Editor = new TextSpellEditor(obj as TextBox);
            SpellChecker.SpellCheckCompleted += SpellChecker_SpellCheckCompleted;
            SpellChecker.PerformSpellCheckUsingContextMenu(Editor);
            SpellChecker.PerformSpellCheckUsingDialog(Editor);
            
        }

        private void SpellChecker_SpellCheckCompleted(object sender, EventArgs e)
        {
            if (ShowMessageBox)
            {
                (e as SpellCheckCompletedEventArgs).ShowMessageBox = true;
            }
            else
            {
                (e as SpellCheckCompletedEventArgs).ShowMessageBox = false;
            }

        }
    }
}