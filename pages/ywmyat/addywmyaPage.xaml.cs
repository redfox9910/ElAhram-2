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
            refpage();
        }
        void refpage()
        {
            using (var db = new Models.DataContext())
            {

                var dates = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                var datesf = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day );
                try
                {
                     datesf = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);
                }
                catch (Exception)
                {
                    try
                    {
                        datesf = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1);
                    }
                    catch (Exception)
                    {

                        datesf = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month , 1);
                    }
                    
                    
                }
                
                if (db.يوميات.Where(x => x.تاريخ >= dates && x.تاريخ < datesf).Any())
                {
                   
                    rkmywmyaText.Text = (db.يوميات.Where(x => x.تاريخ >= dates && x.تاريخ < datesf).Max(x => x.كود) + 1).ToString();
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


                ComboBoxItem typeItem = (ComboBoxItem)ywmyacombo.SelectedItem;
               
                
                switch (typeItem.Content.ToString())
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

            ComboBoxItem ywmya = (ComboBoxItem)ywmyacombo.SelectedItem;
           // ComboBoxItem s7b = (ComboBoxItem)s7bywmyacombox.SelectedItem;
            
            using (var db = new Models.DataContext())
            {
                var x = db.خزنة.FirstOrDefault();
                string _7sab="";
                عميل emp = new عميل();
                switch (ywmya.Content.ToString())
                {

                    case "وارد":
                       emp = db.عملاء.Where(x => x.اسم == s7bywmyacombox.Text && x.نوع == 'ع').FirstOrDefault();
                        if (noteywmyaText.Text == "")
                        {
                            _7sab = emp.حساب.ToString();
                         db.يوميات.Add(new Models.يوميات { كود = int.Parse(rkmywmyaText.Text), تاريخ = DateTime.Now, مبلغ = decimal.Parse(nkdyelywmyaText.Text), كودحالة = db.حالات_يوميات.Where(y => y.حالة == "وارد").Select(y => y.كودحالة).FirstOrDefault(), ملاحظات = "دفعة"+"\t\t اجمالى الحساب :- "+ _7sab, كودصاحب = emp.كودعميل, flag = 'ع' });
                        }
                        else
                        {
                            db.يوميات.Add(new Models.يوميات { كود = int.Parse(rkmywmyaText.Text), تاريخ = DateTime.Now, مبلغ = decimal.Parse(nkdyelywmyaText.Text), كودحالة = db.حالات_يوميات.Where(y => y.حالة == "وارد").Select(y => y.كودحالة).FirstOrDefault(), ملاحظات = noteywmyaText.Text+ "\t\t دفعة\t\tاجمالى الحساب :- " + _7sab, كودصاحب = db.عملاء.Where(x => x.اسم == s7bywmyacombox.Text && x.نوع == 'ع').Select(x => x.كودعميل).FirstOrDefault(), flag = 'ع' });
                         }
                        x.نقدى += decimal.Parse(nkdyelywmyaText.Text);
                        db.SaveChanges();
                        Xceed.Wpf.Toolkit.MessageBox.Show("تمت  عملية اضافة الوارد  بنجاح", "اضافة وارد", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case "مصاريف":
                        emp = db.عملاء.Where(x => x.اسم == s7bywmyacombox.Text && x.نوع == 'م').FirstOrDefault();
                        if (x.نقدى > decimal.Parse(nkdyelywmyaText.Text))
                        {
                            _7sab = emp.حساب.ToString();
                            if (noteywmyaText.Text == "")
                            {
                                db.يوميات.Add(new Models.يوميات { كود = int.Parse(rkmywmyaText.Text), تاريخ = DateTime.Now, مبلغ = decimal.Parse(nkdyelywmyaText.Text), كودحالة = db.حالات_يوميات.Where(y => y.حالة == "مصاريف").Select(y => y.كودحالة).FirstOrDefault(), ملاحظات = "\t\t دفعة \t\t اجمالى الحساب :- " + _7sab, كودصاحب = emp.كودعميل, flag = 'م' });
                            }
                            else
                            {
                                db.يوميات.Add(new Models.يوميات { كود = int.Parse(rkmywmyaText.Text), تاريخ = DateTime.Now, مبلغ = decimal.Parse(nkdyelywmyaText.Text), كودحالة = db.حالات_يوميات.Where(y => y.حالة == "مصاريف").Select(y => y.كودحالة).FirstOrDefault(), ملاحظات = noteywmyaText.Text+ "\t\t دفعة \t\t اجمالى الحساب  :- " + _7sab, كودصاحب = emp.كودعميل, flag = 'م' });
                            }
                            x.نقدى -= decimal.Parse(nkdyelywmyaText.Text);
                            db.SaveChanges();
                            Xceed.Wpf.Toolkit.MessageBox.Show("تمت عملية خصم المصاريف بنجاح", "خصم مصاريف", MessageBoxButton.OK, MessageBoxImage.Information);
                             
                        }
                        else
                        {
                         MessageBoxResult boxResult =   Xceed.Wpf.Toolkit.MessageBox.Show("لا يوجد مال كافى لاجراء العملية \n هل تريد اضافة بالسالب فى الخزنة", "خصم مصاريف", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                            if (boxResult == MessageBoxResult.OK)
                            {

                                _7sab = emp.حساب.ToString();
                                if (noteywmyaText.Text == "")
                                {
                                    db.يوميات.Add(new Models.يوميات { كود = int.Parse(rkmywmyaText.Text), تاريخ = DateTime.Now, مبلغ = decimal.Parse(nkdyelywmyaText.Text), كودحالة = db.حالات_يوميات.Where(y => y.حالة == "مصاريف").Select(y => y.كودحالة).FirstOrDefault(), ملاحظات = "\t\t اجمالى الحساب :- " + _7sab, كودصاحب = emp.كودعميل, flag = 'م' });
                                }
                                else
                                {
                                    db.يوميات.Add(new Models.يوميات { كود = int.Parse(rkmywmyaText.Text), تاريخ = DateTime.Now, مبلغ = decimal.Parse(nkdyelywmyaText.Text), كودحالة = db.حالات_يوميات.Where(y => y.حالة == "مصاريف").Select(y => y.كودحالة).FirstOrDefault(), ملاحظات = noteywmyaText.Text + "\t\t اجمالى الحساب :- " + _7sab, كودصاحب = emp.كودعميل, flag = 'م' });
                                }
                                x.نقدى -= decimal.Parse(nkdyelywmyaText.Text);
                                db.SaveChanges();
                                Xceed.Wpf.Toolkit.MessageBox.Show("تمت عملية خصم المصاريف بنجاح", "خصم مصاريف", MessageBoxButton.OK, MessageBoxImage.Information);

                            }
                        }
                        break;
                    case "سلف":
                        if (x.نقدى > decimal.Parse(nkdyelywmyaText.Text))
                        {
                            db.يوميات.Add(new Models.يوميات { كود = int.Parse(rkmywmyaText.Text), تاريخ = DateTime.Now, مبلغ = decimal.Parse(nkdyelywmyaText.Text), كودحالة = db.حالات_يوميات.Where(y => y.حالة == "سلف").Select(y => y.كودحالة).FirstOrDefault(), ملاحظات = noteywmyaText.Text, كودصاحب = db.موظف.Where(x => x.اسم == s7bywmyacombox.Text).Select(x => x.كودموظف).FirstOrDefault(), flag = 'ظ' });
                            x.نقدى -= decimal.Parse(nkdyelywmyaText.Text);
                            if (db.حسابات_الموظف.Where(y => y.كودموظف == db.موظف.Where(x => x.اسم == s7bywmyacombox.Text).Select(x => x.كودموظف).FirstOrDefault() && y.تاريخ >= DateTime.Now.Date && y.تاريخ <= DateTime.Now.AddDays(1).Date).Any())
                            {
                                var empx = db.حسابات_الموظف.Where(y => y.كودموظف == db.موظف.Where(x => x.اسم == s7bywmyacombox.Text).Select(x => x.كودموظف).FirstOrDefault() && y.تاريخ >= DateTime.Now.Date && y.تاريخ <= DateTime.Now.AddDays(1).Date).FirstOrDefault();
                                empx.سلف += decimal.Parse(nkdyelywmyaText.Text);
                            }
                            else
                            {
                                db.حسابات_الموظف.Add(new Models.حسابات_موظف { كودموظف = db.موظف.Where(y => y.اسم == s7bywmyacombox.Text).Select(y => y.كودموظف).FirstOrDefault(), تاريخ = DateTime.Now.Date, دقيقةانصراف = 0, ساعةانصراف = 0, دقيقةحضور = 0, ساعةحضور = 0, سلف = decimal.Parse(nkdyelywmyaText.Text), غياب = false, ملاحظات = "" });
                            }
                            db.SaveChanges();
                            Xceed.Wpf.Toolkit.MessageBox.Show("تمت  عملية صرف السلفة  بنجاح", "صرف سلف", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("لا يوجد مال كافى لاجراء العملية", "صرف سلف", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                        break;
                    case "مرتبات":
                        if (x.نقدى > decimal.Parse(nkdyelywmyaText.Text))
                        {
                            db.يوميات.Add(new Models.يوميات { كود = int.Parse(rkmywmyaText.Text), تاريخ = DateTime.Now, مبلغ = decimal.Parse(nkdyelywmyaText.Text), كودحالة = db.حالات_يوميات.Where(y => y.حالة == "مرتبات").Select(y => y.كودحالة).FirstOrDefault(), ملاحظات = noteywmyaText.Text, كودصاحب = db.موظف.Where(x => x.اسم == s7bywmyacombox.Text).Select(x => x.كودموظف).FirstOrDefault(), flag = 'ظ' });
                            x.نقدى -= decimal.Parse(nkdyelywmyaText.Text);
                            db.SaveChanges();
                            Xceed.Wpf.Toolkit.MessageBox.Show("تمت  عملية صرف المرتب  بنجاح", "صرف مرتبات", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("لا يوجد مال كافى لاجراء العملية", "صرف مرتبات", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                        break;
                    case "تحويلات":
                        db.يوميات.Add(new Models.يوميات{ كود = int.Parse(rkmywmyaText.Text) , تاريخ =  DateTime.Now , مبلغ = decimal.Parse(nkdyelywmyaText .Text),كودحالة = db.حالات_يوميات .Where(y=>y.حالة == "تحويلات").Select(y=>y.كودحالة).FirstOrDefault(),ملاحظات = noteywmyaText .Text,كودصاحب = db.عملاء.Where(x=>x.اسم == s7bywmyacombox.Text && x.نوع =='ع').Select(x=>x.كودعميل).FirstOrDefault(),flag='ع' });                      
                        x.حساب += decimal.Parse(nkdyelywmyaText.Text);
                        db.SaveChanges();
                        Xceed.Wpf.Toolkit.MessageBox.Show("تمت  عملية التحويل  بنجاح", "تحويل بنكى", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    default:
                        break;
                }
               
            }
            refpage();
            ywmyacombo.SelectedIndex = 0;
            s7bywmyacombox.Text = "";
            nkdyelywmyaText.Text = "";
            noteywmyaText.Text = "";



        }
    }
}
