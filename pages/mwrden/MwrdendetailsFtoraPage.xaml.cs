using ElAhram.Models;
using ElAhram.ViewmModels.Amr4r2;
using ElAhram.ViewmModels.fwter;
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

namespace ElAhram.pages.mwrden
{
    /// <summary>
    /// Interaction logic for MwrdendetailsFtoraPage.xaml
    /// </summary>
    public partial class MwrdendetailsFtoraPage : Window
    {
        public MwrdendetailsFtoraPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            using (var db = new Models.DataContext())
            {
                فواتير ftora = db.فواتير.Where(x => x.رقم == data.rkmftora && x.نوع_فاتورة == 'ش').FirstOrDefault();
                List<بنود_الفاتورة> bnods = db.بنودفاتورة.Where(x => x.رقم == ftora.رقم && x.نوع_فاتورة == 'ش').ToList();
                List<amr4r2DataGVM> bnodFatoras = new List<amr4r2DataGVM>();
                MwrdenftorakodTextBox.Content = ftora.رقم;
                MwrdenftoraT49elDate.Content = ftora.تاريخ_تشغيل;
                Mwrdenftora2stlmDate.Content = ftora.تاريخ_تسليم;
                total7sabLabel.Content = ftora.اجمالى_حساب;
                nkdyFatoraLabel.Content = ftora.اجمالى_نقدى;
                TotalWznLabel.Content = ftora.اجمالى_وزن;
                Mwrdenftora2sm3melLabel.Content = db.عملاء.Where(z => z.كودعميل == ftora.كودعميل && z.نوع == 'م').Select(x => x.اسم).FirstOrDefault();
                int count = 1;
                foreach (var item in bnods)
                {
                    bnodFatoras.Add(new amr4r2DataGVM { الخامة= db.منتجات.Where(y => y.كودالخامة == item.كودالمنتج && y.type == 'خ').Select(x => x.الخامة).FirstOrDefault(), الكمية = item.كمية, رقم = count});
                    count++;
                }
                MwrdenDetailsDG.ItemsSource = bnodFatoras;
            }
        }
    }
}
