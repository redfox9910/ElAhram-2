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

namespace ElAhram.pages.ywmyat
{
    /// <summary>
    /// Interaction logic for addywmya.xaml
    /// </summary>
    public partial class addywmya : Window
    {
        public addywmya()
        {
            InitializeComponent();
        }

        private void s7bywmyacombox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            s7bywmyacombox.IsDropDownOpen = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {

                var dates = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                var datesf = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day +1);
                if (db.يوميات.Where(x=> x.تاريخ < dates && x.تاريخ >= datesf).Any())
                {
                    rkmywmyaText.Text = db.يوميات.Where(x => x.تاريخ < dates && x.تاريخ >= datesf). Max(x => x.كود).ToString();
                }
                else
                {
                    rkmywmyaText.Text = "1";
                }
            }
            this.s7bywmyacombox.IsEditable = true;
            this.s7bywmyacombox.IsTextSearchEnabled = true;
        }

        private void nkdyelywmyaText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ywmyacombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> names = new List<string>();
            using (var db = new Models.DataContext())
            {
                switch (ywmyacombo.SelectedItem.ToString())
                {

                    case "وارد":
                        names = db.عملاء.Where(x=>x.نوع == 'ع').Select(x => x.اسم).ToList();
                        break;
                    case "مصاريف":
                        names = db.عملاء.Where(x => x.نوع == 'م').Select(x => x.اسم).ToList();
                        break;
                    case "سلف":
                        names = db.موظف.Select(x => x.اسم).ToList();
                        break;
                    case "مرتبات":
                        names = db.موظف.Select(x => x.اسم).ToList();
                        break;
                    case "تحويلات":
                        names = db.عملاء.Where(x => x.نوع == 'ع').Select(x => x.اسم).ToList();
                        break;
                    default:
                        break;
                }
                s7bywmyacombox.ItemsSource = names;
            }
        }

        private void ywmyaAddBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                switch (ywmyacombo.SelectedItem.ToString())
                {

                    case "وارد":
                        
                        break;
                    case "مصاريف":
                        
                        break;
                    case "سلف":
                       
                        break;
                    case "مرتبات":
                       
                        break;
                    case "تحويلات":
                        db.يوميات.Add(new Models.يوميات{ كود = int.Parse(rkmywmyaText.Text) , تاريخ =  DateTime.Now , مبلغ = decimal.Parse(nkdyelywmyaText .Text),كودحالة = db.حالات_يوميات .Where(y=>y.حالة == "تحويلات").Select(y=>y.كودحالة).FirstOrDefault(),ملاحظات = noteywmyaText .Text,كودصاحب = db.عملاء.Where(x=>x.اسم == s7bywmyacombox.Text && x.نوع =='ع').Select(x=>x.كودعميل).FirstOrDefault(),flag='ع' });
                        var x = db.خزنة.FirstOrDefault();
                        x.حساب += decimal.Parse(nkdyelywmyaText.Text);
                        break;
                    default:
                        break;
                }
               
            }

        }
    }
}
