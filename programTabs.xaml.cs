using ElAhram.Models;
using ElAhram.pages.m5zn;
using ElAhram.ViewmModels.M5ZNTAB;
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

namespace ElAhram
{
    /// <summary>
    /// Interaction logic for programTabs.xaml
    /// </summary>
    public partial class programTabs : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public programTabs(DataContext Db)
        {
            InitializeComponent();
            using (var db = new Models.DataContext())
            {
            
            
            
            
            
            
            
            var x = db.خزنة.FirstOrDefault();
            cash.Content = x.نقدى;
                mden.Content = x.مدين;
                d2n.Content = x.دائن;
                total.Content = x.اجمالى;
            }
        }
       /* public programTabs()
        {
            InitializeComponent();
            var x = dataContext.خزنة.FirstOrDefault();
            cash.Content = x.نقدى;
        }  */

            private void btnSelectedTab_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Selected tab: " + (ptabs.SelectedItem as TabItem).Header+"\n index " + (ptabs.SelectedItem as TabItem).TabIndex);
        }

        private void btnSelectedTab_home(object sender, RoutedEventArgs e)
        {
            ptabs.SelectedIndex = 5;
        }

        private void ptabs_Loaded(object sender, RoutedEventArgs e)
        {
            List<M5znDGrid> m5zndata = new List<M5znDGrid>();
            foreach (var item in dataContext.منتجات)
            {
                m5zndata.Add(new M5znDGrid { كودالخامة = item.كودالخامة, الخامة = item.الخامة, الكمية = item.الكمية });

            }
           // m5zndata = dataContext.منتجات.ToList();
            this.m5znDataGrid.ItemsSource = m5zndata;
            
        }

        private void addM5znBtn_Click(object sender, RoutedEventArgs e)
        {
            M5znnAddPage m5ZnaddPage = new M5znnAddPage();
            m5ZnaddPage.Owner = this;
            m5ZnaddPage.ShowDialog();
            //m5ZnaddPage.Focusable = true;
            
        }

        private void EditM5znBtn_Click(object sender, RoutedEventArgs e)
        {
            m5znEditPage m5ZneditPage = new m5znEditPage();
            m5ZneditPage.ShowDialog();
        }

        private void DeleteM5znBtn_Click(object sender, RoutedEventArgs e)
        {
            M5znDeletePage m5ZneditPage = new M5znDeletePage();
            m5ZneditPage.ShowDialog();
        }
    }
}                   
