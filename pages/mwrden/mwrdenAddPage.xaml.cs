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

namespace ElAhram.pages.mwrden
{
    /// <summary>
    /// Interaction logic for mwrdenAddPage.xaml
    /// </summary>
    public partial class mwrdenAddPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public mwrdenAddPage()
        {
            InitializeComponent();
        }

        private void mwrdAddBtn_Click(object sender, RoutedEventArgs e)
        {
            dataContext.عملاء.Add(new عميل { اسم = this.mwrd2smText.Text, رقم = this.mwrdMobText.Text, عنوان = this.mwrd3nwanText.Text, email = this.mwrdEmailText.Text, حساب = decimal.Parse(this.mwrd2ftt7yText.Text), نوع = 'م' });
            dataContext.SaveChanges();
            DialogResult = true;
            this.Close();
        }
    }
}
