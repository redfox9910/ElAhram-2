using ElAhram.ViewmModels.mwzfen;
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

namespace ElAhram.pages.mwzfen
{
    /// <summary>
    /// Interaction logic for mwzfenkf48yabPage.xaml
    /// </summary>
    public partial class mwzfenkf48yabPage : Window
    {
        public mwzfenkf48yabPage()
        {
            InitializeComponent();
        }

        static List<MwzfenSgl8yabDataGVM> k4F7Sab3MelDatas = new List<MwzfenSgl8yabDataGVM>();
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int count = 1;
            using (var db = new Models.DataContext())
            {
                var elements = db.حسابات_الموظف.Where(y => y.كودموظف == data.randomVal ).ToList();

                List<MwzfenSgl8yabDataGVM> k4f7sabData = new List<MwzfenSgl8yabDataGVM>();
                foreach (var item in elements)
                {
                    float timex = float.Parse((item.ساعةانصراف + '.' + item.دقيقةانصراف).ToString()) - float.Parse((item.ساعةحضور + '.' + item.دقيقةحضور).ToString());
                    k4f7sabData.Add(new MwzfenSgl8yabDataGVM { رقم = count, حضور = item.غياب , تاريخ = item.تاريخ, ساعةحضور= item.ساعةحضور,دقيقةحضور = item.دقيقةحضور ,ساعةانصراف = item.ساعةانصراف , دقيقةانصراف = item.دقيقةانصراف,عمل=timex, ملاحظات = item.ملاحظات ,سلف= item.سلف});
                    count++;
                }
                k4f7sabDataG.ItemsSource = k4f7sabData;
                k4F7Sab3MelDatas = k4f7sabData.ToList();
                empLabel.Content = db.موظف.Where(z => z.كودموظف == data.randomVal).Select(z => z.اسم).FirstOrDefault();
            }
        }

        private void datefromDateP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datefromDateP.SelectedDate == null)
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
