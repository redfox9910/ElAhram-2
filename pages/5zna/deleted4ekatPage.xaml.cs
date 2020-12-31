using ElAhram.ViewmModels._5zna;
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

namespace ElAhram.pages._5zna
{
    /// <summary>
    /// Interaction logic for deleted4ekatPage.xaml
    /// </summary>
    public partial class deleted4ekatPage : Window
    {
        public deleted4ekatPage()
        {
            InitializeComponent();
        }
        static List<shekatSgalDataGVM> sglatDatas = new List<shekatSgalDataGVM>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            using (var db = new Models.DataContext())
            {
                var elements = db.شيكات.Where(s => s.flag == 'ح').ToList();
                List<shekatSgalDataGVM> k4f7sabsglatData = new List<shekatSgalDataGVM>();
                foreach (var item in elements)
                {

                    k4f7sabsglatData.Add(new shekatSgalDataGVM { رقم = item.رقم, عميل = db.عملاء.Where(x => x.كودعميل == item.كودعميل && x.نوع == 'ع').Select(x => x.اسم).FirstOrDefault(), بنك = item.بنك, تاريخ = item.تاريخ, حالة = item.الحالة, قيمة = item.قيمة, ملاحظات = item.ملاحظات });

                }
                sglatT4ekatDataG.ItemsSource = k4f7sabsglatData;
                sglatDatas = k4f7sabsglatData.ToList();

            }
        }


        private void datefromDateP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datefromDateP.SelectedDate == null)
            {
                sglatT4ekatDataG.ItemsSource = null;
                sglatT4ekatDataG.ItemsSource = sglatDatas.Where(x => x.تاريخ < dateToDateP.SelectedDate.Value.AddDays(1)).ToList();
            }
            else if (dateToDateP.SelectedDate == null)
            {
                sglatT4ekatDataG.ItemsSource = null;
                sglatT4ekatDataG.ItemsSource = sglatDatas.Where(x => x.تاريخ >= datefromDateP.SelectedDate).ToList();
            }
            else
            {
                sglatT4ekatDataG.ItemsSource = null;
                sglatT4ekatDataG.ItemsSource = sglatDatas.Where(x => x.تاريخ >= datefromDateP.SelectedDate && x.تاريخ < dateToDateP.SelectedDate.Value.AddDays(1)).ToList();
            }
            sglatT4ekatDataG.Items.Refresh();

        }
    }
}
