using Syncfusion.Windows.Controls;
using System;
using System.Windows.Controls;

namespace IspellCheck
{
    public class TextSpellEditor : IEditorProperties
    {
        TextBox textbox;
        public TextSpellEditor(Control control)
        {
            ControlToSpellCheck = control;
        }
        public Control ControlToSpellCheck
        {
            get
            {
                return textbox;
            }
            set
            {
                textbox = value as TextBox;
            }
        }

        public string SelectedText
        {
            get
            {
                return textbox.SelectedText;
            }
            set
            {
                textbox.SelectedText = value;
            }
        }

        public string Text
        {
            get
            {
                return textbox.Text;
            }
            set
            {
                textbox.Text = value;
            }
        }

        public void Select(int selectionStart, int selectionLength)
        {
            textbox.Select(selectionStart, selectionLength);
        }

        public bool HasMoreTextToCheck()
        {
            return false;
        }

        public void Focus()
        {
            textbox.Focus();
        }

        public void UpdateTextField()
        {
            throw new NotImplementedException();
        }
    }
}
