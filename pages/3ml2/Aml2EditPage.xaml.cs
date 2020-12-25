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

namespace ElAhram.pages._3ml2
{
    /// <summary>
    /// Interaction logic for Aml2EditPage.xaml
    /// </summary>
    public partial class Aml2EditPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();

        public Aml2EditPage()
        {
            InitializeComponent();
        }

        private void AmelEditBtn_Click(object sender, RoutedEventArgs e)
        {
            var customer = dataContext.عملاء.Where(y=>y.كودعميل == data.randomVal && y.نوع=='ع').FirstOrDefault();
            customer.اسم = this.amel2smText.Text;
            customer.رقم = this.amelMobText.Text;
            customer.عنوان = this.amel3nwanText.Text;
            customer.email = this.amelEmailText.Text;
           
            dataContext.SaveChanges();
            DialogResult = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var customer = dataContext.عملاء.Where(y => y.كودعميل == data.randomVal && y.نوع == 'ع').FirstOrDefault();

            this.amel2smText.Text = customer.اسم;
            this.amelMobText.Text = customer.رقم;
            this.amel3nwanText.Text = customer.عنوان;
            this.amelEmailText.Text = customer.email;
        }
    }
}
