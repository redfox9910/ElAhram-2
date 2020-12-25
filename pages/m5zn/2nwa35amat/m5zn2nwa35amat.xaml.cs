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
    /// Interaction logic for m5zn2nwa35amat.xaml
    /// </summary>
    public partial class m5zn2nwa35amat : Window
    {
        public m5zn2nwa35amat()
        {
            InitializeComponent();
        }

        private void m5znAddno3Btn_Click(object sender, RoutedEventArgs e)
        {
            if (m5zn2smmno3.Text == "" || m5zn2smmno3.Text == null)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("من فضلك ادخل اسم المخزن !", "خطاء فى الادخال", MessageBoxButton.OK, MessageBoxImage.Error);
                DialogResult = false;
            }
            else
            {

                using (var db = new Models.DataContext())
                {
                    if (db.انواع_خامات.Where(x => x.النوع == m5zn2smmno3.Text).Any())
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("اسم المخزن موجود سابقا !", "خطاء فى الادخال", MessageBoxButton.OK, MessageBoxImage.Warning);

                    }
                    else
                    {
                        db.انواع_خامات.Add(new Models.انواع_الخامات { النوع = m5zn2smmno3.Text });
                        db.SaveChanges();
                        DialogResult = true;
                    }

                }
            }
        }
    }
}
