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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElAhram.pages.report
{
    /// <summary>
    /// Interaction logic for tryprint.xaml
    /// </summary>
    public partial class tryprint : Window
    {
        public tryprint()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                List<bnodFatoraDataGVM> bnodftoradata = new List<bnodFatoraDataGVM>();
                var items = db.بنودفاتورة.Where(x => x.رقم == 1 && x.نوع_فاتورة == 'ب' && x.type == 'م').ToList();

                foreach (var item in items)
                {
                    bnodftoradata.Add(new bnodFatoraDataGVM { number = item.number, المنتج = db.منتجات.Where(x => x.كودالخامة == item.كودالمنتج && x.type == 'م').Select(x => x.الخامة).FirstOrDefault(), كمية = item.كمية, سعر_الوحدة = item.سعر_الوحدة, الاجمالى = item.الاجمالى });

                }
                for (int i = 0; i < 100; i++)
                {
                    bnodftoradata.Add(new bnodFatoraDataGVM { number = i });

                }

                this.datagrid.ItemsSource = bnodftoradata;
                this.datagrid.Items.Refresh();
            }
        }

        private void ButtonAdv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                  //  printDialog.PrintDocument(datagrid, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
