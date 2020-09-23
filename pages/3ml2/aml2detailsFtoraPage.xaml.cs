using ElAhram.Models;
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

namespace ElAhram.pages._3ml2
{
    /// <summary>
    /// Interaction logic for aml2detailsFtoraPage.xaml
    /// </summary>
    public partial class aml2detailsFtoraPage : Window
    {
        public aml2detailsFtoraPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            using (var db = new Models.DataContext())
            {
                فواتير ftora = db.فواتير.Where(x => x.رقم == data.rkmftora && x.نوع_فاتورة == 'ب').FirstOrDefault();
                List<بنود_الفاتورة> bnods = db.بنودفاتورة.Where(x => x.رقم == ftora.رقم && x.نوع_فاتورة == 'ب').ToList();
                List<bnodFatora> bnodFatoras = new List<bnodFatora>();
                aml2ftorakodTextBox.Content = ftora.رقم;
                aml2ftoraT49elDate.Content = ftora.تاريخ_تشغيل;
                aml2ftora2stlmDate.Content = ftora.تاريخ_تسليم;
                total7sabLabel.Content = ftora.اجمالى_حساب;
                nkdyFatoraLabel.Content = ftora.اجمالى_نقدى;
                TotalWznLabel.Content = ftora.اجمالى_وزن;
                aml2ftora2sm3melLabel.Content = db.عملاء.Where(z => z.كودعميل == ftora.كودعميل && z.نوع == 'ع').Select(x => x.اسم).FirstOrDefault();

                foreach (var item in bnods)
                {
                    bnodFatoras.Add(new bnodFatora {المنتج = db.منتجات.Where(y=>y.كودالخامة== item.كودالمنتج && y.type =='م').Select(x=>x.الخامة).FirstOrDefault(),كمية = item.كمية , سعر_الوحدة = item.سعر_الوحدة ,الاجمالى = item.الاجمالى });
                }
                amrT48elDetailsDG.ItemsSource = bnodFatoras;
            }
        }

      
    }
}
