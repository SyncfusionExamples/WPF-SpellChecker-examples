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

namespace Themes
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
            SpellChecker.PerformSpellCheckUsingContextMenu(Editor);
        }

        //Call SpellCheck method to open SpellCheck on button click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SpellChecker.PerformSpellCheckUsingDialog(Editor);
        }
    }
}
