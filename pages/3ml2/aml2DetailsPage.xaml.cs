using ElAhram.Models;
using ElAhram.pages._3ml2;
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

namespace ElAhram.pages.Emp
{
    /// <summary>
    /// Interaction logic for aml2DetailsPage.xaml
    /// </summary>
    public partial class aml2DetailsPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public aml2DetailsPage()
        {
            InitializeComponent();
        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                عميل customer = db.عملاء.Where(x=>x.اسم == data.asmmwzf && x.نوع == 'ع').FirstOrDefault();
                List<fwterDataGVM> fwterDatas = new List<fwterDataGVM>();
                kod3melLabel.Content = customer.كودعميل;
                customerNameLabel.Content = customer.اسم;
                customerPhoneLabel.Content = customer.رقم;
                CustomerEmailLabel.Content = customer.email;
                CustomerAddressLabel.Content = customer.عنوان;
                TotalmoneyLabel.Content = customer.حساب;
               List <فواتير> element = db.فواتير.Where(y => y.كودعميل == customer.كودعميل).ToList();
                foreach (var item in element)
                {
                    fwterDatas.Add(new fwterDataGVM { رقم = item.رقم, اسم_عميل = data.asmmwzf, تاريخ_تشغيل = item.تاريخ_تسليم, اجمالى_نقدى = item.اجمالى_نقدى, اجمالى_حساب = item.اجمالى_حساب, اجمالى_وزن = item.اجمالى_وزن });
                }
                EmpfwterDataGrid.ItemsSource = fwterDatas;
            }
        }

        private void EmpfwterDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var rows = this.EmpfwterDataGrid.SelectedItem as fwterDataGVM;

            if (rows == null)
            {
                return;
            }
                data.rkmftora = rows.رقم;
            
            aml2detailsFtoraPage page = new aml2detailsFtoraPage();
            page.ShowDialog();
        }

        private void k4f7sab_Click(object sender, RoutedEventArgs e)
        {
            data.k4f7sabId = int.Parse(kod3melLabel.Content.ToString());
            aml2k4f7sab page = new aml2k4f7sab();
            page.ShowDialog();
        }

        private void edit3ml2Btn_Click(object sender, RoutedEventArgs e)
        {
            data.randomVal = int.Parse(kod3melLabel.Content.ToString());
            Aml2EditPage page = new Aml2EditPage();
            page.ShowDialog();
        }

        private void Delete3ml2Btn_Click(object sender, RoutedEventArgs e)
        {
            

                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("هل تريد مسح العميل؟", "مسح عميل", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                Xceed.Wpf.Toolkit.MessageBox.Show("يرجى العلم انه عند مسح العميل سيتم مسح كل البينات المتعلقة به \n يرجى عدم مسح بيانات اى عميل الا عند التاكد بعدم حاجتك اليها الانا و فيما بعد ف ربما تحتاجها ", "مسح عميل", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            result = Xceed.Wpf.Toolkit.MessageBox.Show("هل مازالت تريد مسح العميل؟", "مسح عميل", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            switch (result)
                {
                    case MessageBoxResult.Yes:
                        
                        using (var db = new Models.DataContext())
                        {

                            var element = db.عملاء.Where(x => x.كودعميل == data.k4f7sabId && x.نوع == 'ع').FirstOrDefault();
                           
                            db.Entry(element).State = EntityState.Deleted;

                            db.SaveChanges();
                            
                            Xceed.Wpf.Toolkit.MessageBox.Show("تم مسح العميل بنجاح", "مسح عميل", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
                        this.Close();

                        }
                        break;
                    case MessageBoxResult.No:

                        break;

                }
            
        }
    }
}
