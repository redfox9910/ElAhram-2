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

namespace ElAhram.pages.mwrden
{
    /// <summary>
    /// Interaction logic for MwrdenEditPage.xaml
    /// </summary>
    public partial class MwrdenEditPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public MwrdenEditPage()
        {
            InitializeComponent();
        }

        private void MwrdEditBtn_Click(object sender, RoutedEventArgs e)
        {
            var customer =   dataContext.عملاء.Where(y => y.كودعميل == data.randomVal && y.نوع == 'م').FirstOrDefault();
            customer.اسم =   this.Mwrd2smText.Text;
            customer.رقم =   this.MwrdMobText.Text;
            customer.عنوان = this.Mwrd3nwanText.Text;
            customer.email = this.MwrdEmailText.Text;

            dataContext.SaveChanges();
            DialogResult = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var customer = dataContext.عملاء.Where(y => y.كودعميل == data.randomVal && y.نوع == 'م').FirstOrDefault();

            this.Mwrd2smText.Text = customer.اسم;
            this.MwrdMobText.Text = customer.رقم;
            this.Mwrd3nwanText.Text = customer.عنوان;
            this.MwrdEmailText.Text = customer.email;
        }
    }
}
