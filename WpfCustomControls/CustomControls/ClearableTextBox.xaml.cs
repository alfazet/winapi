using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
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

namespace WpfCustomControls
{
    /// <summary>
    /// Interaction logic for ClearableTextBox.xaml
    /// </summary>
    public partial class ClearableTextBox : UserControl
    {
        private string _placeholder;

        public string Placeholder
        {
            get => _placeholder;
            set
            {
                _placeholder = value;
                tblkPlaceholder.Text = _placeholder;
            }
        }

        public ClearableTextBox()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tboxTextInput.Clear();
        }

        private void tboxTextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(tboxTextInput.Text))
            {
                tblkPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                tblkPlaceholder.Visibility = Visibility.Hidden;
            }
        }
    }
}
