using ElAhram.Models;
using ElAhram.ViewmModels.fwter;
using Microsoft.EntityFrameworkCore;
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

namespace ElAhram.pages.mwrden
{
    /// <summary>
    /// Interaction logic for mwrdenDetailsPage.xaml
    /// </summary>
    public partial class mwrdenDetailsPage : Window
    {
        public mwrdenDetailsPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                عميل customer = db.عملاء.Where(x => x.اسم == data.asmmwzf && x.نوع == 'م').FirstOrDefault();
                List<fwterDataGVM> fwterDatas = new List<fwterDataGVM>();
                kod3melLabel.Content = customer.كودعميل;
                mwrdenNameLabel.Content = customer.اسم;
                mwrdenPhoneLabel.Content = customer.رقم;
                mwrdenEmailLabel.Content = customer.email;
                mwrdenAddressLabel.Content = customer.عنوان;
                TotalmoneyLabel.Content = customer.حساب;
                List<فواتير> element = db.فواتير.Where(y => y.كودعميل == customer.كودعميل).ToList();
                foreach (var item in element)
                {
                    fwterDatas.Add(new fwterDataGVM { رقم = item.رقم, اسم_عميل = data.asmmwzf, تاريخ_تشغيل = item.تاريخ_تسليم, اجمالى_نقدى = item.اجمالى_نقدى, اجمالى_حساب = item.اجمالى_حساب, اجمالى_وزن = item.اجمالى_وزن });
                }
                mwrdenfwterDataGrid.ItemsSource = fwterDatas;
            }
        }

        private void mwrdenfwterDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var rows = this.mwrdenfwterDataGrid.SelectedItem as fwterDataGVM;
            data.rkmftora = rows.رقم;

            MwrdendetailsFtoraPage page = new MwrdendetailsFtoraPage();
            page.ShowDialog();
        }

        private void sgl7sabMwrdenBtn_Click(object sender, RoutedEventArgs e)
        {
            data.k4f7sabId = int.Parse(kod3melLabel.Content.ToString());
            mwrdenK4f7sab page = new mwrdenK4f7sab();
            page.ShowDialog();
        }

        private void editMwrdenBtn_Click(object sender, RoutedEventArgs e)
        {
            data.randomVal = int.Parse(kod3melLabel.Content.ToString());
            MwrdenEditPage page = new MwrdenEditPage();
            page.ShowDialog();
        }

        private void DeleteMwrdenBtn_Click(object sender, RoutedEventArgs e)
        {


            MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("هل تريد مسح المورد ؟", "مسح مورد", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            Xceed.Wpf.Toolkit.MessageBox.Show("يرجى العلم انه عند مسح المورد سيتم مسح كل البينات المتعلقة به \n يرجى عدم مسح بيانات اى مورد الا عند التاكد بعدم حاجتك اليها الانا و فيما بعد ف ربما تحتاجها ", "مسح مورد", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            result = Xceed.Wpf.Toolkit.MessageBox.Show("هل مازالت تريد مسح المورد ؟", "مسح عميل", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            switch (result)
            {
                case MessageBoxResult.Yes:

                    using (var db = new Models.DataContext())
                    {

                        var element = db.عملاء.Where(x => x.كودعميل == data.k4f7sabId && x.نوع == 'م').FirstOrDefault();

                        db.Entry(element).State = EntityState.Deleted;

                        db.SaveChanges();

                        Xceed.Wpf.Toolkit.MessageBox.Show("تم مسح المورد بنجاح", "مسح عميل", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
                        this.Close();

                    }
                    break;
                case MessageBoxResult.No:

                    break;

            }
        }
    }
}
