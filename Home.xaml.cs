using ElAhram.Models;
using ElAhram.pages.password;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ElAhram
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private readonly DataContext dataContext;
        public Home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            programTabs tab = new programTabs(dataContext);
            
            var x = (sender as Button).Name.ToString();
            switch ((sender as Button).Name.ToString())
            {
                case "b0":
                    password Page = new password(); 
                    bool? result = Page.ShowDialog();
                    if (result == true)   {    tab.ptabs.SelectedIndex = 0;   }
                    else {  Xceed.Wpf.Toolkit.MessageBox.Show("الرجاء ادخال كلمة المرور لتتمكن من الوصول الى هذه النافذة ", "كلمة مرور", MessageBoxButton.OK, MessageBoxImage.Error);
                        Home page = new Home();  page.Show();            this.Close();   }              break;
                case "b1": tab.ptabs.SelectedIndex = 1 ; break;
                case "b2": tab.ptabs.SelectedIndex = 2 ; break;
                case "b3": tab.ptabs.SelectedIndex = 3 ; break;
                case "b4": tab.ptabs.SelectedIndex = 4 ; break;
                case "b5": tab.ptabs.SelectedIndex = 5 ; break;
                case "b6": tab.ptabs.SelectedIndex = 6 ; break;
                case "b7": tab.ptabs.SelectedIndex = 7 ; break;
                case "b8": tab.ptabs.SelectedIndex = 8 ; break;
                case "b9": tab.ptabs.SelectedIndex = 9 ; break;
               
                default:
                    break;
            }
            tab.Show();
            this.Close();
        }
    }
}
