using ElAhram.Models;
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

namespace ElAhram.pages._3ml2
{
    /// <summary>
    /// Interaction logic for Aml2AddPage.xaml
    /// </summary>
    public partial class Aml2AddPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public Aml2AddPage()
        {
            InitializeComponent();
        }

        private void AmelAddBtn_Click(object sender, RoutedEventArgs e)
        {
            dataContext.عملاء.Add(new عميل { اسم = this.amel2smText.Text, رقم = this.amelMobText.Text, عنوان = this.amel3nwanText.Text, email = this.amelEmailText.Text, حساب = decimal.Parse(this.amel2ftt7yText.Text)  , نوع = 'ع'});
            dataContext.SaveChanges();
            DialogResult = true;
            this.Close();
        }
    }
}
