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
    /// Interaction logic for passwordEdit.xaml
    /// </summary>
    public partial class passwordEdit : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public passwordEdit()
        {
            InitializeComponent();
        }

        private void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (revealModeCheckBox.IsChecked == true)
            {
                // old password
                oldpasswordBoxText.Visibility = System.Windows.Visibility.Collapsed;
                passwordText.Visibility = System.Windows.Visibility.Visible;
                  //new password
                oldpasswordBoxText.Visibility = System.Windows.Visibility.Collapsed;
                passwordText.Visibility = System.Windows.Visibility.Visible;
                   // new password confirm
                oldpasswordBoxText.Visibility = System.Windows.Visibility.Collapsed;
                passwordText.Visibility = System.Windows.Visibility.Visible;

                // passwordText.Focus();
            }
            else
            {
                // old password
                oldpasswordBoxText.Visibility = System.Windows.Visibility.Visible;
                passwordText.Visibility = System.Windows.Visibility.Collapsed;

                //new password
                newpasswordBoxText.Visibility = System.Windows.Visibility.Visible;
                newpasswordText.Visibility = System.Windows.Visibility.Collapsed;
                // new password confirm
                newpasswordconBoxText.Visibility = System.Windows.Visibility.Visible;
                newpasswordconText.Visibility = System.Windows.Visibility.Collapsed;

                //passwordBoxText.Focus();

            }
        }

        private void enterPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            var password = dataContext.خزنة.Where(x => x.رقم == '1').FirstOrDefault();
            if (oldpasswordBoxText.Password == password.password)
            {
                if (newpasswordBoxText.Password == newpasswordconBoxText.Password)
                {
                    password.password = newpasswordBoxText.Password;
                    dataContext.SaveChanges();
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("كلمة السر الجديدة و تأكيدها مختلفان \nالرجاء ادخال الكلمة و تأكيدها ", "كلمة مرور", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
               
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("كلمة مرور القديمة خاطئه ", "كلمة مرور", MessageBoxButton.OK, MessageBoxImage.Error);
                oldpasswordText.Focus();
                oldpasswordBoxText.Focus();
                return;
            }



            DialogResult = true;
            this.Close();
        }


        private void passwordBoxText_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (oldpasswordText.Text != oldpasswordBoxText.Password)
            {
                oldpasswordText.Text = oldpasswordBoxText.Password;
            }
            if (newpasswordText.Text != newpasswordBoxText.Password)
            {
                newpasswordText.Text = newpasswordBoxText.Password;
            }
            if (newpasswordconText.Text != newpasswordconBoxText.Password)
            {
                newpasswordconText.Text = newpasswordconBoxText.Password;
            }

        }

        private void passwordText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (oldpasswordBoxText.Password != oldpasswordText.Text)
            {
                oldpasswordBoxText.Password = oldpasswordText.Text;
            }
            if (newpasswordBoxText.Password != newpasswordText.Text)
            {
                newpasswordBoxText.Password = newpasswordText.Text;
            }
            if (newpasswordconBoxText.Password != newpasswordconText.Text)
            {
                newpasswordconBoxText.Password = newpasswordconText.Text;
            }

        }



    }
}
