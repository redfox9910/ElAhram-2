using ElAhram.ViewmModels.amrT48el;
using Microsoft.EntityFrameworkCore.Storage;
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

namespace ElAhram.pages.amrt48el
{
    /// <summary>
    /// Interaction logic for Amrt48elDetailsPage.xaml
    /// </summary>
    public partial class Amrt48elDetailsPage : Window
    {
        public Amrt48elDetailsPage()
        {
            InitializeComponent();
        }

        private void amrT48elDetailsDG_Loaded(object sender, RoutedEventArgs e)
        {
            List<amrt48elDataGVM> amrt48eldata = new List<amrt48elDataGVM>();
            using (var db = new Models.DataContext())
            {
                var items = db.امرتشغيل.Where(x => x.رقم == data.rkmftora && x.نوع_فاتورة == 'ب' && x.type == 'م').ToList();

                foreach (var item in items)
                {
                    amrt48eldata.Add( new amrt48elDataGVM { رقم = this.amrT48elDetailsDG.Items.Count+1 , اسم = db.منتجات.Where(x=>x.كودالخامة == item.كودالخامة && x.type == 'م').Select(y=>y.الخامة).FirstOrDefault(),اوميا=item.اوميا,بيور = item.بيور ,سمك = item.سمك , كمية = item.كمية , مقاس_تقطيع = item.مقاس_تقطيع , مقاس_طباعة = item.مقاس_طباعة });

                }
                this.amrT48elDetailsDG.ItemsSource = null;
                this.amrT48elDetailsDG.Items.Clear();

                this.amrT48elDetailsDG.ItemsSource = amrt48eldata;
            }
        }

        private void Amrt48elDetailsPage1_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                var itemx = db.فواتير.Where(x => x.رقم == data.rkmftora && x.نوع_فاتورة == 'ب').FirstOrDefault();

                this.amrt48elDate.Content = itemx.تاريخ_تشغيل.ToString("dd/MM/yyyy");
                this.amrt48elkodTextBox.Content = data.rkmftora;
                this.amrt48el2sm3melLabel.Content = db.عملاء.Where(x => x.كودعميل == itemx.كودعميل && x.نوع == 'ع').Select(y => y.اسم).FirstOrDefault();

             }
        }
    }
}
