using ElAhram.Models;
using ElAhram.ViewmModels.M5ZNTAB;
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
    /// Interaction logic for M5znDeletePage.xaml
    /// </summary>
    public partial class M5znDeletePage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public M5znDeletePage()
        {
            InitializeComponent();
        }

        private void M5znDeletePage1_Loaded(object sender, RoutedEventArgs e)
        {
            var data = dataContext.منتجات.Select(x => x.الخامة).ToList();
            M5zndeleteCombobox.ItemsSource = data;
            M5zndeleteCombobox.SelectedIndex = 0;
        }

        private void m5znDeleteMntagBtn_Click(object sender, RoutedEventArgs e)
        {
            المنتجات mntg = dataContext.منتجات.Where(x => x.الخامة == M5zndeleteCombobox.SelectedItem.ToString()).FirstOrDefault();
                  dataContext.Entry(mntg).State = EntityState.Deleted;
            dataContext.SaveChanges();
            DialogResult = true;
            this.Close();
            
        }
    }
}
