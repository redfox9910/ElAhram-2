using ElAhram.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for ShekatEditPage.xaml
    /// </summary>
    public partial class ShekatEditPage : Window
    {
        public ShekatEditPage()
        {
            InitializeComponent();
        }

        private void shekAddBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                شيكات datax = new شيكات();
                شيكات شيك = db.شيكات.Where(x => x.رقم == data.shekelement.رقم&& x.كودعميل == db.عملاء.Where(y => y.اسم == data.shekelement.عميل).Select(x => x.كودعميل).FirstOrDefault()).FirstOrDefault();
                datax.رقم = rkm4ekText.Text;
                datax.كودعميل = db.عملاء.Where(x => x.اسم == s7bel4ekcombo.Text).Select(x => x.كودعميل).FirstOrDefault();
                datax.تاريخ = (DateTime)srfDateText.SelectedDate;
                datax.قيمة = decimal.Parse(nkdyel4ekText.Text);
                datax .ملاحظات= note4ekText.Text;
                datax.بنك = bankText.Text;
                
                db.Entry(شيك).State = EntityState.Deleted;
               
                db.شيكات.Add(datax);
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
            this.s7bel4ekcombo.Text = data.shekelement.عميل;
            rkm4ekText.Text = data.shekelement.رقم;

            srfDateText.SelectedDate = data.shekelement.تاريخ;
            nkdyel4ekText.Text = data.shekelement.قيمة.ToString() ;
            note4ekText.Text = data.shekelement.ملاحظات;
            bankText.Text = data.shekelement.بنك;
        }

        private void nkdyel4ekText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
    }
}
