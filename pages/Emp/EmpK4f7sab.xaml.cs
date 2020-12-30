using ElAhram.ViewmModels.Aml2Tab;
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

namespace ElAhram.pages.Emp
{
    /// <summary>
    /// Interaction logic for EmpK4f7sab.xaml
    /// </summary>
    public partial class EmpK4f7sab : Window
    {
        static List<k4f7sab3melDataGVM> k4F7Sab3MelDatas = new List<k4f7sab3melDataGVM>();
        public EmpK4f7sab()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {          
            int count = 1;
            using (var db = new Models.DataContext())
            {
                var elements = db.يوميات.Where(y => y.كودصاحب == data.randomVal && y.flag == 'ظ').ToList();
                                                
                List<k4f7sab3melDataGVM> k4f7sabData = new List<k4f7sab3melDataGVM>();
                foreach (var item in elements)
                {
                    k4f7sabData.Add( new k4f7sab3melDataGVM {رقم = count , كوداليومية = item.كود, تاريخ = item.تاريخ,  مبلغ = item.مبلغ, ملاحظات = item.ملاحظات });
                    count++;
                }
                k4f7sabDataG.ItemsSource = k4f7sabData;
                k4F7Sab3MelDatas = k4f7sabData.ToList();
                empLabel.Content = db.موظف.Where(z => z.كودموظف== data.randomVal).Select(z => z.اسم).FirstOrDefault();
            }                                                                                       
         }

        private void datefromDateP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datefromDateP.SelectedDate == null )
            {
                k4f7sabDataG.ItemsSource = null;
                k4f7sabDataG.ItemsSource = k4F7Sab3MelDatas.Where(x => x.تاريخ < dateToDateP.SelectedDate.Value.AddDays(1)).ToList();
            }
            else if (dateToDateP.SelectedDate == null)
            {
                k4f7sabDataG.ItemsSource = null;
                k4f7sabDataG.ItemsSource = k4F7Sab3MelDatas.Where(x => x.تاريخ >= datefromDateP.SelectedDate).ToList();
            }
            else
            {
                if (datefromDateP.SelectedDate > dateToDateP.SelectedDate)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("يرجى مراعاه الترتيب الزمنى للتاريخ المدخل", "تاريخ كشف الحساب", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);

                }
                else
                {

                    k4f7sabDataG.ItemsSource = null;

                    k4f7sabDataG.ItemsSource = k4F7Sab3MelDatas.Where(x => x.تاريخ >= datefromDateP.SelectedDate && x.تاريخ < dateToDateP.SelectedDate.Value.AddDays(1)).ToList();
                }
                }
            k4f7sabDataG.Items.Refresh();

        }
    }
}
