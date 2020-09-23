using ElAhram.Models;
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

namespace ElAhram.pages.m5zn
{
    /// <summary>
    /// Interaction logic for M5znnAddPage.xaml
    /// </summary>
    public partial class M5znnAddPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public M5znnAddPage()
        {
            InitializeComponent();
        }

        private void m5znAddMntag_Click(object sender, RoutedEventArgs e)
        {
            int id;
            
            
            char typex;
            ComboBoxItem typeItem = (ComboBoxItem)m5znNo3elmntg.SelectedItem;
            string value = typeItem.Content.ToString();
            if (value == "خامة")
            {
                typex = 'خ';
                if (dataContext.منتجات.Any())
                {
                    id = dataContext.منتجات.Where(x => x.type == 'خ').Max(x => x.كودالخامة) + 1;
                }
                else
                {
                    id = 1;
                }
            }
            else
            {
                typex = 'م';
                if (dataContext.منتجات.Any())
                {
                    id = dataContext.منتجات.Where(x => x.type == 'م').Max(x => x.كودالخامة) + 1;
                }
                else
                {
                    id = 1;
                }
            }
            dataContext.منتجات.Add(new المنتجات { كودالخامة = id,الخامة=m5zn2smmntg.Text, الكمية=0,type=typex});
            dataContext.SaveChanges();
          
            DialogResult = true;
            this.Close();
          


        }
    }
}
