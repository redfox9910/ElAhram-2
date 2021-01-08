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

namespace ElAhram.pages.fwater
{
    /// <summary>
    /// Interaction logic for FWaterListP.xaml
    /// </summary>
    public partial class FWaterListP : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public FWaterListP()
        {
            InitializeComponent();
        }

        private void fwterListDataG_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            var rows = this.fwterListDataG.SelectedItem as fwaterListDataGVM;

            data.rkmftora = rows.رقم;
            FwaterDetailsPage page = new FwaterDetailsPage();
            page.ShowDialog();

        }

        private void name3elCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          //  ComboBoxItem typeItem = (ComboBoxItem)name3elCombo.SelectedItem;
            List<fwaterListDataGVM> fwterData = new List<fwaterListDataGVM>();
            //typeItem.Content.ToString()
            var itemx = dataContext.فواتير.Where(x => x.نوع_فاتورة == 'ب' && x.كودعميل == dataContext.عملاء.Where(y => y.اسم == name3elCombo.SelectedItem.ToString()).Select(y=>y.كودعميل).FirstOrDefault()).ToList();
            using (var db = new Models.DataContext())
            {
                foreach (var item in itemx)
                {
                    fwterData.Add(new fwaterListDataGVM { رقم = item.رقم, تاريخ_تشغيل = item.تاريخ_تشغيل, تاريخ_تسليم = item.تاريخ_تسليم, اجمالى_حساب = (item.اجمالى_حساب - item.اجمالى_نقدى), اجمالى_نقدى = item.اجمالى_نقدى, اجمالى_وزن = item.اجمالى_وزن, اجمالى_حساب_جديد = item.اجمالى_حساب });

                }
               // this.fwterListDataG.Items.Clear();
              //  this.fwterListDataG.ItemsSource = null;
                this.fwterListDataG.ItemsSource = fwterData;
                this.fwterListDataG.Items.Refresh();
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<fwaterListDataGVM> fwterData = new List<fwaterListDataGVM>();
            name3elCombo.ItemsSource = dataContext.عملاء.Where(x=>x.نوع == 'ع').Select(x => x.اسم).ToList();
            name3elCombo.SelectedIndex = 0;
            //name3elCombo.Text = dataContext.عملاء.Where(y=>y.كودعميل== dataContext.عملاء.Min(x=>x.كودعميل)).Select(y=>y.اسم).FirstOrDefault();
             var itemx = dataContext.فواتير.Where(x => x.نوع_فاتورة == 'ب' && x.كودعميل== dataContext.عملاء.Min(x => x.كودعميل)).ToList();
            using (var db = new Models.DataContext())
            {
                foreach (var item in itemx)
                {
                    fwterData.Add(new fwaterListDataGVM { رقم = item.رقم , تاريخ_تشغيل = item.تاريخ_تشغيل,تاريخ_تسليم = item.تاريخ_تسليم, اجمالى_حساب = (item.اجمالى_حساب - item.اجمالى_نقدى), اجمالى_نقدى = item.اجمالى_نقدى, اجمالى_وزن = item.اجمالى_وزن ,اجمالى_حساب_جديد = item.اجمالى_حساب});

                }
                this.fwterListDataG.ItemsSource = fwterData;
            }
          }
    
     }
}
