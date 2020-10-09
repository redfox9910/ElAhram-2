using ElAhram.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for M5znDeleteM5znPage.xaml
    /// </summary>
    public partial class M5znDeleteM5znPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public M5znDeleteM5znPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var data = dataContext.مخزن.Select(x => x.المخزن).ToList();
            M5zndeleteCombobox.ItemsSource = data;
            M5zndeleteCombobox.SelectedIndex = 0;

        }

        private void m5znDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int m5znID = dataContext.مخزن.Where(x => x.المخزن == M5zndeleteCombobox.SelectedItem.ToString()).Select(x => x.كودالمخزن).FirstOrDefault();
            MessageBoxResult boxResult;
            if (dataContext.منتجات.Where(x=>x.كودالمخزن==m5znID).Any())
            {
                boxResult = Xceed.Wpf.Toolkit.MessageBox.Show("هذا المخزن يتوفر فى خامات هل تريد حذفه ؟  !", "حذف مخزن", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            }
            else
            {
                boxResult = Xceed.Wpf.Toolkit.MessageBox.Show("هذا المخزن فارغ هل تريد حذفه؟", "حذف مخزن", MessageBoxButton.YesNo, MessageBoxImage.Information);
            }
            if (boxResult == MessageBoxResult.Yes)
            {
                مخازن m5zn = dataContext.مخزن.Where(x => x.كودالمخزن == m5znID).FirstOrDefault();
                dataContext.Entry(m5zn).State = EntityState.Deleted;
                dataContext.SaveChanges();
                DialogResult = true;
                this.Close();
            }
           
           

        }
    }
}
