using ElAhram.Models;
using ElAhram.pages.amrt48el;
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
    /// Interaction logic for fwaterListPage.xaml
    /// </summary>
    public partial class fwaterListPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public fwaterListPage()
        {
            InitializeComponent();
        }
        private void AmrT48elListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                List<fwterDataGVM> fwterData = new List<fwterDataGVM>();
            List<فواتير> itemx = new List<فواتير>();
            if (data.asm3mel == "")
            {
                itemx = dataContext.فواتير.Where(x => x.نوع_فاتورة == 'ب' && x.فاتورة == 'n').ToList();
            }
            else
            {
                    int id = db.عملاء.Where(y => y.اسم == data.asm3mel).Select(y => y.كودعميل).FirstOrDefault();
                itemx = dataContext.فواتير.Where(x => x.نوع_فاتورة == 'ب' && x.فاتورة == 'n' && x.كودعميل ==id).ToList();
            }
            
           
                foreach (var item in itemx)
                {
                    fwterData.Add(new fwterDataGVM { رقم = item.رقم, اسم_عميل = db.عملاء.Where(x => x.كودعميل == item.كودعميل && x.نوع == 'ع').Select(y => y.اسم).FirstOrDefault(), تاريخ_تشغيل = item.تاريخ_تشغيل, اجمالى_حساب = item.اجمالى_حساب, اجمالى_نقدى = item.اجمالى_نقدى, اجمالى_وزن = item.اجمالى_وزن });

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
            //      DataRowView row = dg.SelectedItems as DataRowView;
            data.rkmftora = rows.رقم;
            DialogResult = true;
            this.Close();
        }

       
    }
}
