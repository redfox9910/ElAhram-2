using CustomDocumentPaginator;
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
    /// Interaction logic for FwaterDetailsPage.xaml
    /// </summary>
    public partial class FwaterDetailsPage : Window
    {
        public FwaterDetailsPage()
        {
            InitializeComponent();
            
        }

        class azntslemm5azn
        {
            public   int number;
            public string name { get; set; }
            public double wzn { get; set; }
        }
        fwterDataGVM aznData;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<azntslemm5azn> azndata = new List<azntslemm5azn>();


            fwterDataGVM fwterData;
            List<bnodFatoraDataGVM> bnodftoradata = new List<bnodFatoraDataGVM>();
            using (var db = new Models.DataContext())
            {

                var itemx = db.فواتير.Where(x => x.رقم == data.rkmftora && x.نوع_فاتورة == 'ب').FirstOrDefault();

                this.amrt48elDate.Content = itemx.تاريخ_تشغيل.ToString("dd/MM/yyyy");
                TslemFatoraDate.Content = itemx.تاريخ_تسليم.ToString("dd/MM/yyyy");
                this.fatorakodlabel.Content = data.rkmftora;
                this.fatora2sm3melLabel.Content = db.عملاء.Where(x => x.كودعميل == itemx.كودعميل && x.نوع == 'ع').Select(y => y.اسم).FirstOrDefault();
                this.TotalWzn.Content = itemx.اجمالى_وزن.ToString();
                this.totalFatoraLabel.Content = itemx.اجمالى_نقدى.ToString();
                this.Total7sab.Content = (itemx.اجمالى_حساب - itemx.اجمالى_نقدى).ToString();
                this.TotalNew7sab.Content = itemx.اجمالى_حساب.ToString();


                var items = db.بنودفاتورة.Where(x => x.رقم == data.rkmftora && x.نوع_فاتورة == 'ب' && x.type == 'م').ToList();

                foreach (var item in items)
                {
                    bnodftoradata.Add(new bnodFatoraDataGVM {number = item.number , المنتج = db.منتجات.Where(x=>x.كودالخامة==item.كودالمنتج && x.type =='م').Select(x=>x.الخامة).FirstOrDefault(),كمية=item.كمية , سعر_الوحدة = item.سعر_الوحدة , الاجمالى = item.الاجمالى });
                    azndata.Add(new azntslemm5azn { number = item.number, name = db.منتجات.Where(x => x.كودالخامة == item.كودالمنتج && x.type == 'م').Select(x => x.الخامة).FirstOrDefault(), wzn = item.كمية });
                }
                this.fatoraDetailsDG.ItemsSource = null;
                this.fatoraDetailsDG.Items.Clear();

                this.fatoraDetailsDG.ItemsSource = bnodftoradata;
                this.fatoraDetailsDG.Items.Refresh();

                azntslemm5znDatag.ItemsSource = null;

                this.azntslemm5znDatag.ItemsSource = azndata;
                this.azntslemm5znDatag.Items.Refresh();

                fwterData = new fwterDataGVM {اسم_عميل = this.fatora2sm3melLabel.Content.ToString(),تاريخ_تشغيل= itemx.تاريخ_تسليم ,اجمالى_وزن= Convert.ToDouble(itemx.اجمالى_وزن ),اجمالى_نقدى = itemx.اجمالى_نقدى,اجمالى_حساب = itemx.اجمالى_حساب};
                aznData = new fwterDataGVM { اسم_عميل = this.fatora2sm3melLabel.Content.ToString(), تاريخ_تشغيل = itemx.تاريخ_تسليم, اجمالى_وزن = Convert.ToDouble(itemx.اجمالى_وزن)};
            }
            this.DataContext = new MainWindowViewModel("فاتورة\n\nرقم : " + data.rkmftora, fwterData, "فاتورة");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new MainWindowViewModel("اذن تسليم مخازن\n\n فاتورة رقم : " + data.rkmftora, aznData, "اذن تسليم");
        }
    }
}
