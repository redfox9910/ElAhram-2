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

namespace ElAhram.pages.m5zn._2nwa35amat
{
    /// <summary>
    /// Interaction logic for m5zn2nwa35amatEditPage.xaml
    /// </summary>
    public partial class m5zn2nwa35amatEditPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public m5zn2nwa35amatEditPage()
        {
            InitializeComponent();
        }

        private void No3EditCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m5zn2smmno3.Text = this.No3EditCombobox.SelectedItem.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var data = dataContext.انواع_خامات.Select(x => x.النوع).ToList();
            No3EditCombobox.ItemsSource = data;
            No3EditCombobox.SelectedIndex = 0;
            m5zn2smmno3.Text = No3EditCombobox.Text;
        }

        private void m5znAddno3Btn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                var x = db.انواع_خامات.Where(x => x.النوع== No3EditCombobox.Text).FirstOrDefault();
                x.النوع = m5zn2smmno3.Text;
                db.SaveChanges();
                DialogResult = true;
            }
        }
    }
}
