using ElAhram.Models;
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
    /// Interaction logic for shekatAddPage.xaml
    /// </summary>
    public partial class shekatAddPage : Window
    {
        public shekatAddPage()
        {
            InitializeComponent();
        }

       

        private void shekAddBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                شيكات شيك = new شيكات { رقم = rkm4ekText.Text, كودعميل = db.عملاء.Where(x=>x.اسم == s7bel4ekcombo.Text).Select(x=>x.كودعميل).FirstOrDefault(),تاريخ = (DateTime)srfDateText.SelectedDate ,قيمة = decimal.Parse(nkdyel4ekText.Text),ملاحظات = note4ekText.Text,بنك = bankText.Text,flag = 'ا',الحالة = "انتظار الصرف"};
                db.شيكات.Add(شيك);

                var khzna = db.خزنة.FirstOrDefault();
                khzna.شيكات += شيك.قيمة;
                db.SaveChanges();
                this.DialogResult = true;
            }
        }

        private void s7bel4ekcombo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            s7bel4ekcombo.IsDropDownOpen = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            List<String> names = new List<string>();


            using (var db = new Models.DataContext())
            {
                foreach (var item in db.عملاء.Where(x => x.نوع == 'ع'))

                {

                    this.s7bel4ekcombo.Items.Add(item.اسم);
                }
               
            }
            this.s7bel4ekcombo.IsEditable = true;
            this.s7bel4ekcombo.IsTextSearchEnabled = true;
        }

        private void nkdyel4ekText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+[.]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
