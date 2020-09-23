using ElAhram.Models;
using ElAhram.ViewmModels.fwter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Amrt48elListPage.xaml
    /// </summary>
    public partial class Amrt48elListPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public Amrt48elListPage()
        {
            InitializeComponent();
        }

        private void AmrT48elListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List <fwterDataGVM> fwterData = new List<fwterDataGVM>();
            var itemx = dataContext.فواتير.Where(x => x.نوع_فاتورة == 'ب').ToList();
            using (var db = new Models.DataContext())
            {
                foreach (var item in itemx)
            {
                fwterData.Add( new fwterDataGVM { رقم = item.رقم , اسم_عميل = db.عملاء.Where(x => x.كودعميل == item.كودعميل && x.نوع == 'ع').Select(y => y.اسم).FirstOrDefault(),تاريخ_تشغيل = item.تاريخ_تشغيل ,اجمالى_حساب = item.اجمالى_حساب , اجمالى_نقدى = item.اجمالى_نقدى , اجمالى_وزن = item.اجمالى_وزن});

            }
            this.amrT48elListDataG.ItemsSource = fwterData;
             }
        }

       /* private void amrT48elListDataG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
              
        }      */

        private void amrT48elListDataG_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            var rows = this.amrT48elListDataG.SelectedItem as fwterDataGVM;
      
            data.rkmftora = rows.رقم ;
            Amrt48elDetailsPage page = new Amrt48elDetailsPage();
            page.ShowDialog();
        }
    }
}
