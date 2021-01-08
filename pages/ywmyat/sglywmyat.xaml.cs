using ElAhram.ViewmModels.ywmyat;
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

namespace ElAhram.pages.ywmyat
{
    /// <summary>
    /// Interaction logic for sglywmyat.xaml
    /// </summary>
    public partial class sglywmyat : Window
    {
        public sglywmyat()
        {
            InitializeComponent();
        }

        static List<ywmyatDataGVM> ywmyatDatas = new List<ywmyatDataGVM>();
        ViewmModels.fwter.fwterDataGVM fwterData;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            using (var db = new Models.DataContext())
            {
                var elements = db.يوميات.ToList();
                List<ywmyatDataGVM> k4f7sabData = new List<ywmyatDataGVM>();
                foreach (var item in elements)
                {
                    if (item.flag == 'ظ')
                    {
                        k4f7sabData.Add(new ywmyatDataGVM { كود = item.كود, صاحب = db.موظف.Where(x => x.كودموظف == item.كودصاحب ).Select(x => x.اسم).FirstOrDefault(), تاريخ = item.تاريخ, ألحالة = db.حالات_يوميات.Where(z => z.كودحالة == item.كودحالة).Select(z => z.حالة).FirstOrDefault(), مبلغ = item.مبلغ, ملاحظات = item.ملاحظات });
                    }
                    else
                    {
                        k4f7sabData.Add(new ywmyatDataGVM { كود = item.كود, صاحب = db.عملاء.Where(x=>x.كودعميل==item.كودصاحب &&x.نوع == item.flag).Select(x=>x.اسم).FirstOrDefault(), تاريخ = item.تاريخ, ألحالة = db.حالات_يوميات.Where(z => z.كودحالة == item.كودحالة).Select(z => z.حالة).FirstOrDefault(), مبلغ = item.مبلغ, ملاحظات = item.ملاحظات });
                    }
                    
                }
                sglywmyaDG.ItemsSource = k4f7sabData.Where(x=>x.تاريخ == DateTime.Today).ToList().OrderBy(x=>x.تاريخ);
                ywmyatDatas = k4f7sabData.ToList();
                decimal income=0,outm = 0;
                foreach (var item in k4f7sabData.Where(x => x.تاريخ == DateTime.Today).ToList())
                {
                    if (item.ألحالة == "مصاريف" || item.ألحالة == "سلف " || item.ألحالة == "مرتبات ")
                    {
                        outm += item.مبلغ;
                    }
                    else
                    {
                        income += item.مبلغ;
                    }
                }
                // _2sm3melLabel.Content = db.عملاء.Where(z => z.كودعميل == data.k4f7sabId && z.نوع == 'ع').Select(z => z.اسم).FirstOrDefault();
                fwterData = new ViewmModels.fwter.fwterDataGVM {  اجمالى_حساب = income , اجمالى_نقدى = outm };

            }
            this.DataContext = new CustomDocumentPaginator.MainWindowViewModel("كشف يوميات", fwterData, "يوميات");
        }

       /* private void dateOfYwmya_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //try
            //{
            //    using (var db = new Models.DataContext())
            //    {
            //        var data = db.يوميات.Where(y => y.تاريخ >= dateOfYwmya.SelectedDate.Value && y.تاريخ< dateOfYwmya.SelectedDate.Value.AddDays(1).Date).ToList();
            //        List<ywmyatDataGVM> ywmyatDatas = new List<ywmyatDataGVM>();
            //        foreach (var item in data)
            //        {
            //            if (item.flag !='ظ')
            //            {
            //                ywmyatDatas.Add(new ywmyatDataGVM { كود = item.كود, صاحب = db.عملاء.Where(z => z.كودعميل == item.كودصاحب && z.نوع == item.flag).Select(z => z.اسم).FirstOrDefault(), ألحالة = db.حالات_يوميات.Where(z => z.كودحالة == item.كودحالة).Select(z => z.حالة).FirstOrDefault(), مبلغ = item.مبلغ, ملاحظات = item.ملاحظات });
            //            }
            //            else
            //            {
            //                ywmyatDatas.Add(new ywmyatDataGVM { كود = item.كود, صاحب = db.موظف.Where(z => z.كودموظف == item.كودصاحب ).Select(z => z.اسم).FirstOrDefault(), ألحالة = db.حالات_يوميات.Where(z => z.كودحالة == item.كودحالة).Select(z => z.حالة).FirstOrDefault(), مبلغ = item.مبلغ, ملاحظات = item.ملاحظات });

            //            }
                       
            //        }
            //        sglywmyaDG.ItemsSource = ywmyatDatas.OrderBy(x=>x.ألحالة);
            //    }
            //}
           
           
            // catch (Exception)
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("خطاء فى التاريخ المدخل", "عرض يوميات", MessageBoxButton.OK, MessageBoxImage.Error);

            //    throw;
            //}
        }
             */
        private void datefromDateP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            List<ywmyatDataGVM> k4f7sabData = new List<ywmyatDataGVM>();

            if (datefromDateP.SelectedDate == null)
            {
                sglywmyaDG.ItemsSource = null;
                sglywmyaDG.ItemsSource = ywmyatDatas.Where(x => x.تاريخ < dateToDateP.SelectedDate.Value.AddDays(1)).ToList().OrderBy(x => x.تاريخ);
                k4f7sabData = ywmyatDatas.Where(x => x.تاريخ < dateToDateP.SelectedDate.Value.AddDays(1)).ToList();
            }
            else if (dateToDateP.SelectedDate == null)
            {
                sglywmyaDG.ItemsSource = null;
                sglywmyaDG.ItemsSource = ywmyatDatas.Where(x => x.تاريخ >= datefromDateP.SelectedDate).ToList().OrderBy(x => x.تاريخ);
                k4f7sabData = ywmyatDatas.Where(x => x.تاريخ >= datefromDateP.SelectedDate).ToList();
            }
            else
            {
                if (datefromDateP.SelectedDate > dateToDateP.SelectedDate)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("يرجى مراعاه الترتيب الزمنى للتاريخ المدخل", "تاريخ كشف الحساب", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);

                }
                else
                {

                    sglywmyaDG.ItemsSource = null;
                    sglywmyaDG.ItemsSource = ywmyatDatas.Where(x => x.تاريخ >= datefromDateP.SelectedDate && x.تاريخ < dateToDateP.SelectedDate.Value.AddDays(1)).ToList().OrderBy(x => x.تاريخ);
                    k4f7sabData = ywmyatDatas.Where(x => x.تاريخ >= datefromDateP.SelectedDate && x.تاريخ < dateToDateP.SelectedDate.Value.AddDays(1)).ToList();
                }
            }
            sglywmyaDG.Items.Refresh();



            decimal income = 0, outm = 0;
            foreach (var item in k4f7sabData)
            {
                if (item.ألحالة == "مصاريف" || item.ألحالة == "سلف " || item.ألحالة == "مرتبات ")
                {
                    outm += item.مبلغ;
                }
                else
                {
                    income += item.مبلغ;
                }
            }
            // _2sm3melLabel.Content = db.عملاء.Where(z => z.كودعميل == data.k4f7sabId && z.نوع == 'ع').Select(z => z.اسم).FirstOrDefault();
            fwterData = new ViewmModels.fwter.fwterDataGVM { اجمالى_حساب = income, اجمالى_نقدى = outm };

            this.DataContext = new CustomDocumentPaginator.MainWindowViewModel("كشف يوميات", fwterData, "يوميات");


        }
    }
}
