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

namespace ElAhram.pages.m5zn
{
    /// <summary>
    /// Interaction logic for M5znEditM5znPage.xaml
    /// </summary>
    public partial class M5znEditM5znPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public M5znEditM5znPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var data = dataContext.مخزن.Select(x => x.المخزن).ToList();
            M5znEditCombobox.ItemsSource = data;
            M5znEditCombobox.SelectedIndex = 0;
            m5zn2smm5zn.Text = M5znEditCombobox.Text;


        }

        private void M5znEditCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m5zn2smm5zn.Text = this.M5znEditCombobox.SelectedItem.ToString(); 
        }

      

        private void m5znEditM5znBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                var x = db.مخزن.Where(x => x.المخزن == M5znEditCombobox.Text).FirstOrDefault();
                x.المخزن = m5zn2smm5zn.Text;
                db.SaveChanges();
                DialogResult = true;
             }
        }
    }
}
