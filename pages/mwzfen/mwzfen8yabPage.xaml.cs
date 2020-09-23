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
    /// Interaction logic for mwzfen8yabPage.xaml
    /// </summary>
    public partial class mwzfen8yabPage : Window
    {
        public mwzfen8yabPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {

                var datas = db.حسابات_الموظف.ToList();
                List<mwzfen8yabDataGVM> mwzfen8YabDatas = new List<mwzfen8yabDataGVM>();
                foreach (var item in datas)
                {
                    mwzfen8YabDatas.Add(new mwzfen8yabDataGVM {موظف= db.موظف.Where(x=>x.كودموظف== item.كودموظف).Select(y=>y.اسم).FirstOrDefault(),تاريخ= item.تاريخ ,ساعةحضور= item.ساعةحضور ,دقيقةحضور =item.دقيقةحضور,ساعةانصراف = item.ساعةانصراف , دقيقةانصراف = item.دقيقةانصراف ,ملاحظات = item.ملاحظات ,غياب= item.غياب });
                }
                mwzfen8yabDataG.ItemsSource = mwzfen8YabDatas;
            }   
        }

        private void mwzfen8yabDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                this.mwzfen8yabDataG.CommitEdit();
                this.mwzfen8yabDataG.Items.Refresh(); ;
            }));


        }

        private void mwzfen8yabDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

            var row1 = this.mwzfen8yabDataG.SelectedItem as mwzfen8yabDataGVM;
            string name = row1.موظف;
            DateTime tre5 = row1.تاريخ;
            int sa3t7dor = row1.ساعةحضور;
            int min7dor = row1.دقيقةحضور;
            int sa3t2nsrf = row1.ساعةانصراف;
            int min2nsrf = row1.دقيقةانصراف;
           
            
            var y = e.Row.DataContext;
            var sd = e.Row;
            (sender as DataGrid).RowEditEnding -= mwzfen8yabDataGrid_RowEditEnding;
            (sender as DataGrid).CommitEdit();
            (sender as DataGrid).Items.Refresh();
            (sender as DataGrid).RowEditEnding += mwzfen8yabDataGrid_RowEditEnding;
           
            var rows = this.mwzfen8yabDataG.SelectedItem as mwzfen8yabDataGVM;
            if (rows.موظف != name)
            {
                rows.موظف = name;
            }
            if (rows.تاريخ != tre5)
            {
                rows.تاريخ = tre5;
            }
            if (rows.ساعةحضور != sa3t7dor)
            {
                rows.ساعةحضور = sa3t7dor;
            }
            if (rows.دقيقةحضور != min7dor)
            {
                
                rows.دقيقةحضور= min7dor;
            }
            if (rows.ساعةانصراف != sa3t2nsrf)
            {
                rows.ساعةحضور = sa3t2nsrf;
            }
            if (rows.دقيقةانصراف != min2nsrf)
            {

                rows.دقيقةحضور = min2nsrf;
            }

           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
            foreach (var item in mwzfen8yabDataG.ItemsSource )
            {
                var x = item as mwzfen8yabDataGVM;
            }

        }
    }
}
