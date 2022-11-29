using Microsoft.VisualBasic;
using System.Windows;

namespace MedicalManagementWPF.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
