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
       // private readonly DataContext dataContext = new Models.DataContext();
        public M5znnAddPage()
        {
            InitializeComponent();
        }

        private void m5znAddMntag_Click(object sender, RoutedEventArgs e)
        {
            int id,m5znID,no3Id;
            using (var db = new Models.DataContext())
            {
           

                char typex,w7da;
              

            ComboBoxItem typeItem = (ComboBoxItem)m5znNo3elmntg.SelectedItem;
            string value = typeItem.Content.ToString();
            if (value == "خامة")
            {
                    m5znID = db.مخزن.Where(x => x.المخزن == m5znlocationCombo.Text.ToString()).Select(x => x.كودالمخزن).FirstOrDefault();
                    no3Id = db.انواع_خامات.Where(x => x.النوع == m5znsnfCombo.Text).Select(x => x.كودالنوع).FirstOrDefault();
                    typex = 'خ';
                if (db.منتجات.Where(x => x.type == 'خ' && x.كودالمخزن == m5znID).Any())
                {
                    id = db.منتجات.Where(x => x.type == 'خ' &&x.كودالمخزن == m5znID).Max(x => x.كودالخامة) + 1;
                }
                else
                {
                    id = 1;
                }
            }
            else
            {


                    m5znID = db.مخزن.Min(x => x.كودالمخزن);
                    no3Id = db.انواع_خامات.Min(x => x.كودالنوع);
                typex = 'م';
                if (db.منتجات.Any())
                {
                    id = db.منتجات.Where(x => x.type == 'م').Max(x => x.كودالخامة) + 1;
                }
                else
                {
                    id = 1;
                }
            }
                if (m5znw7dCombo.Text == "كيلو")
                {
                    w7da = 'ك';
                }
                else
                {
                    w7da = 'ع';
                }

                db.منتجات.Add(new المنتجات { كودالخامة = id,الخامة=m5zn2smmntg.Text, الكمية=0,type=typex,كودالمخزن = m5znID ,كودالنوع =no3Id,وحدة = w7da});
                db.SaveChanges();
          
            DialogResult = true;
            this.Close();

            }

        }

        private void m5znNo3elmntg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)m5znNo3elmntg.SelectedItem;
            string value = typeItem.Content.ToString();
            if (value == "خامة")
            {
                m5znsnfCombo.Visibility = Visibility.Visible;
                snfLabel.Visibility = Visibility.Visible;
                m5znlocationCombo.Visibility = Visibility.Visible;
                locationLabel.Visibility = Visibility.Visible;
            }

            else
            {
                m5znsnfCombo.Visibility = Visibility.Collapsed;
                snfLabel.Visibility = Visibility.Collapsed;
                m5znlocationCombo.Visibility = Visibility.Collapsed;
                locationLabel.Visibility = Visibility.Collapsed;


            }
         }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                m5znsnfCombo.ItemsSource = db.انواع_خامات.Select(x => x.النوع).ToList();
                m5znlocationCombo.ItemsSource = db.مخزن.Select(y => y.المخزن).ToList();

            }
        }
    }
}
