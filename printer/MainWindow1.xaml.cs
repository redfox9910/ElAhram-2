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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomDocumentPaginator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow1 : Window
    {
        public MainWindow1()
        {
            InitializeComponent();

            //Set the data context to a new instance of main window view model.
            this.DataContext = new MainWindowViewModel("");
            using (var db = new ElAhram.Models.DataContext())
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

                this.wpfDataGrid.ItemsSource = bnodftoradata;
                this.wpfDataGrid.Items.Refresh();
            }
        }
    }
}
