using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ElAhram.pages._5zna
{
    /// <summary>
    /// Interaction logic for t7welNkdyPage.xaml
    /// </summary>
    public partial class t7welNkdyPage : Window
    {
        public t7welNkdyPage()
        {
            InitializeComponent();
        }

        private void t7welAddBtn_Click(object sender, RoutedEventArgs e)
        {

            if (no3Elt7welcombo.Text == null || nkdyElt7welText.Text == null || nkdyElt7welText.Text == "" || no3Elt7welcombo.Text == "")
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("برجاء ادخال نوع و قيمة التحويل", "تحويل داخلى", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                using (var db = new Models.DataContext())
                {
                    var elment = db.خزنة.FirstOrDefault();

                    if (no3Elt7welcombo.Text == "تحويل الى الحساب البنكى")
                    {
                        if (elment.نقدى >= decimal.Parse(nkdyElt7welText.Text ))
                        {
                            elment.نقدى -= decimal.Parse(nkdyElt7welText.Text);
                            elment.حساب += decimal.Parse(nkdyElt7welText.Text);
                            db.تحويلات.Add(new Models.التحويلات_الداخلية {تاريخ= DateTime.Today , قيمة = decimal.Parse(nkdyElt7welText.Text) , نوع = 'ح' } );
                            Xceed.Wpf.Toolkit.MessageBox.Show("تمت العملية بنجاح", "تحويل الى حساب البنك", MessageBoxButton.OK, MessageBoxImage.Information);
                            DialogResult = true;
                            this.Close();
                        }
                        else
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("لا يوجد رصيد كافى  فى النقدى الخاص بالخزنة", "تحويل الى حساب البنك", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                    }
                    else
                    {
                        if (elment.حساب >= decimal.Parse(nkdyElt7welText.Text))
                        {
                            elment.نقدى += decimal.Parse(nkdyElt7welText.Text);
                            elment.حساب -= decimal.Parse(nkdyElt7welText.Text);
                            db.تحويلات.Add(new Models.التحويلات_الداخلية { تاريخ = DateTime.Today, قيمة = decimal.Parse(nkdyElt7welText.Text), نوع = 'خ' });
                            Xceed.Wpf.Toolkit.MessageBox.Show("تمت العملية بنجاح", "تحويل الى الخزنة", MessageBoxButton.OK, MessageBoxImage.Information);
                            DialogResult = true;
                            this.Close();
                        }
                        else
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("لا يوجد رصيد كافى  فى الحساب البنكى", "تحويل الى الخزنة", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                    }
                    db.SaveChanges();
                }

             
            }
           

        }
        private void nkdyel4ekText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+[^.]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
