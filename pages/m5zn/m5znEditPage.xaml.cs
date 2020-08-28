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
    /// Interaction logic for m5znEditPage.xaml
    /// </summary>
    public partial class m5znEditPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public m5znEditPage()
        {
            InitializeComponent();
        }

        private void m5znEditPage1_Loaded(object sender, RoutedEventArgs e)
        {
            var data = dataContext.منتجات.Select(x => x.الخامة).ToList();
            M5znEditCombobox.ItemsSource = data;
            M5znEditCombobox.SelectedIndex = 0;
            المنتجات mntg = dataContext.منتجات.Where(x => x.الخامة == data.First()).FirstOrDefault();
            m5zn2smmntgEdit.Text = mntg.الخامة;
            if (mntg.type == 'خ')
            {
                m5znNo3elmntgEdit.SelectedIndex = 0;
            }
            else
            {
                m5znNo3elmntgEdit.SelectedIndex = 1;
            }

            m5zn3ddmntgedit.Text = mntg.الكمية.ToString();
        }

        private void M5znEditCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            المنتجات mntg = dataContext.منتجات.Where(x => x.الخامة== M5znEditCombobox.SelectedItem.ToString()).FirstOrDefault();
            m5zn2smmntgEdit.Text = mntg.الخامة;
            if (mntg.type == 'خ')
            {
                m5znNo3elmntgEdit.SelectedIndex = 0;
            }
            else
            {
                m5znNo3elmntgEdit.SelectedIndex = 1;
            }

            m5zn3ddmntgedit.Text = mntg.الكمية.ToString();
        }

        private void m5znEDITMntagBtn_Click(object sender, RoutedEventArgs e)
        {
            المنتجات mntg = dataContext.منتجات.Where(x => x.الخامة == M5znEditCombobox.SelectedItem.ToString()).FirstOrDefault();
            mntg.الخامة= m5zn2smmntgEdit.Text ;
            if (m5znNo3elmntgEdit.SelectedItem.ToString() == "خامة")
            {
                mntg.type = 'خ';
            }
            else
            {
                mntg.type = 'م';
            }

            mntg.الكمية= Convert.ToDouble(m5zn3ddmntgedit.Text) ;

            dataContext.SaveChanges();
           
            this.Close();
            


        }
    }
}
