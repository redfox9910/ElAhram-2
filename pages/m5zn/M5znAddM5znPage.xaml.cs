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
    /// Interaction logic for M5znAddM5znPage.xaml
    /// </summary>
    public partial class M5znAddM5znPage : Window
    {
        public M5znAddM5znPage()
        {
            InitializeComponent();
        }

        private void m5znAddM5znBtn_Click(object sender, RoutedEventArgs e)
        {
            if (m5zn2smm5zn.Text == "" || m5zn2smm5zn.Text == null)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("من فضلك ادخل اسم المخزن !", "خطاء فى الادخال", MessageBoxButton.OK,MessageBoxImage.Error);
                DialogResult = false;
            }
            else {
               
            using (var db = new Models.DataContext())
            {
                    if (db.مخزن.Where(x=>x.المخزن == m5zn2smm5zn.Text).Any())
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("اسم المخزن موجود سابقا !", "خطاء فى الادخال", MessageBoxButton.OK,MessageBoxImage.Warning);
                       
                    }
                    else
                    {
                        db.مخزن.Add(new Models.مخازن { المخزن = m5zn2smm5zn.Text });
                        db.SaveChanges();
                        DialogResult = true;
                    }
               
                }
            }
        }
    }
}
