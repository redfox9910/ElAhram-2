using ElAhram.Models;
using ElAhram.ViewmModels.M5ZNTAB;
using Microsoft.EntityFrameworkCore;
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
using WPFCustomMessageBox;

namespace ElAhram.pages._5zna
{
    /// <summary>
    /// Interaction logic for shekatListPage.xaml
    /// </summary>
    public partial class shekatListPage : Window
    {
        public shekatListPage()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var rows = this.shekatDataGrid.SelectedItem as shekatDataGVM;
            using (var db = new Models.DataContext())
            {

                var element = db.شيكات.Where(x => x.رقم == rows.رقم && x.كودعميل == db.عملاء.Where(y => y.اسم == rows.عميل).Select(x => x.كودعميل).FirstOrDefault()).FirstOrDefault();

                var khzna = db.خزنة.FirstOrDefault();
                khzna.شيكات -= element.قيمة;
                MessageBoxResult result =
                 Xceed.Wpf.Toolkit.MessageBox.Show("هل تريد اضافة المبلغ الى الحساب البنكى ؟", "صرف شيك ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    khzna.حساب += element.قيمة;
                }
                else
                {
                    khzna.نقدى += element.قيمة;
                }
               
                db.Entry(element).State = EntityState.Deleted;

                db.SaveChanges();
                refreshDG();
                total4ekatLb.Content = khzna.شيكات;
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var rows = this.shekatDataGrid.SelectedItem as shekatDataGVM;
            data.shekelement = rows;
            ShekatEditPage page = new ShekatEditPage();
            bool? y = page.ShowDialog();
            if (y==true)
            {
                refreshDG();
            }
            using (var db = new Models.DataContext())
            {
                var khzna = db.خزنة.FirstOrDefault();
                total4ekatLb.Content = khzna.شيكات;
            }

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("هل تريد مسح الشيك ؟", "مسح شيك", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    var rows = this.shekatDataGrid.SelectedItem as shekatDataGVM;
                    using (var db = new Models.DataContext())
                    {

                        var element = db.شيكات.Where(x => x.رقم == rows.رقم && x.كودعميل == db.عملاء.Where(y => y.اسم == rows.عميل).Select(x => x.كودعميل).FirstOrDefault()).FirstOrDefault();
                        db.Entry(element).State = EntityState.Deleted;

                        db.SaveChanges();
                        refreshDG();

                    }
                    break;
                case MessageBoxResult.No:
                  
                    break;
              
            }
            using (var db = new Models.DataContext())
            {
                var khzna = db.خزنة.FirstOrDefault();
                total4ekatLb.Content = khzna.شيكات;
            }

        }

            private void add4ekBtn_Click(object sender, RoutedEventArgs e)
        {
            shekatAddPage page = new shekatAddPage();
           bool? y= page.ShowDialog();
            if (y == true)
            {
                shekatDataGrid.ItemsSource = null;
                shekatDataGrid.Items.Clear();
                using (var db = new Models.DataContext())
                {
                    var x = db.شيكات.ToList();
                    List<shekatDataGVM> shekatData = new List<shekatDataGVM>();
                    foreach (var item in x)
                    {
                        shekatData.Add(new shekatDataGVM { رقم = item.رقم, عميل = db.عملاء.Where(y => y.رقم == item.رقم && y.نوع == 'ع').Select(x => x.اسم).FirstOrDefault(), تاريخ = item.تاريخ, قيمة = item.قيمة, ملاحظات = item.ملاحظات , بنك = item.بنك});
                    }
                    shekatDataGrid.ItemsSource = shekatData;
                    shekatDataGrid.Items.Refresh();
                    var khzna = db.خزنة.FirstOrDefault();
                    total4ekatLb.Content = khzna.شيكات;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refreshDG();
         }
        private void refreshDG()
        {
            using (var db = new Models.DataContext())
            {
                var x = db.شيكات.ToList();

                List<shekatDataGVM> shekatData = new List<shekatDataGVM>();
                foreach (var item in x)
                {

                    shekatData.Add(new shekatDataGVM { رقم = item.رقم, عميل = db.عملاء.Where(y => y.كودعميل == item.كودعميل && y.نوع == 'ع').Select(x => x.اسم).FirstOrDefault(), تاريخ = item.تاريخ, قيمة = item.قيمة, ملاحظات = item.ملاحظات,بنك= item.بنك });
                }
                shekatDataGrid.ItemsSource = shekatData;
                var khzna = db.خزنة.FirstOrDefault();
                total4ekatLb.Content = khzna.شيكات;
            }

        }

    }
}
