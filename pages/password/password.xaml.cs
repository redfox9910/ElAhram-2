using ElAhram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ElAhram.pages.password
{
    /// <summary>
    /// Interaction logic for password.xaml
    /// </summary>
    public partial class password : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public password()
        {
            InitializeComponent();
            passwordBoxText.Focus();
        }

        private void passwordBoxText_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passwordText.Text != passwordBoxText.Password)
            {
                passwordText.Text = passwordBoxText.Password;
            }
            
        }

        private void passwordText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (passwordBoxText.Password != passwordText.Text)
            {
                passwordBoxText.Password = passwordText.Text;
            }
            
        }

        private void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (revealModeCheckBox.IsChecked == true)
            {
                passwordBoxText.Visibility = System.Windows.Visibility.Collapsed;
                passwordText.Visibility = System.Windows.Visibility.Visible;

               // passwordText.Focus();
            }
            else
            {
                passwordBoxText.Visibility = System.Windows.Visibility.Visible;
                passwordText.Visibility = System.Windows.Visibility.Collapsed;
               
               //passwordBoxText.Focus();
                
            }
        }

        private void enterPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            string password = dataContext.خزنة.Where(x => x.رقم == '1').Select(x => x.password).FirstOrDefault();
            if (passwordBoxText.Password == password)
            {

                DialogResult = true;
                this.Close();
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("كلمة مرور خاطئه ", "كلمة مرور", MessageBoxButton.OK, MessageBoxImage.Error);
                passwordText.Focus();
                passwordBoxText.Focus();
            }
        }
    }
}
