using ElAhram.Models;
using ElAhram.pages.mwzfen;
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
    /// Interaction logic for EmpDetilsPage.xaml
    /// </summary>
    public partial class EmpDetilsPage : Window
    {
        public EmpDetilsPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                موظف customer = db.موظف.Where(x => x.كودموظف == data.kodemwzf).FirstOrDefault();
                List<حسابات_موظف> emp8yabDatas = new List<حسابات_موظف>();
                decimal slf = 0;
                kodEMPLabel.Content = customer.كودموظف;
                EMPNameLabel.Content = customer.اسم;
                EMPPhoneLabel.Content = customer.رقم;
                EmpRbtakaLabel.Content = customer.بطاقة;
                EmpAddressLabel.Content = customer.عنوان;
                EmpRkmkwmyLabel.Content = customer.رقم_قومى;
                var dates = new DateTime(DateTime.Now.Year, DateTime.Now.Month , 1);
                try
                {
                     dates = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1);
                }
                catch (Exception)
                {

                     dates = new DateTime(DateTime.Now.Year+1, DateTime.Now.Month , 1);
                }
               
                var datesf = new DateTime(DateTime.Now.Year, DateTime.Now.Month , 1);
               List <حسابات_موظف>   ds = db.حسابات_الموظف.Where(x => x.كودموظف == data.kodemwzf && x.تاريخ < dates && x.تاريخ >=datesf).ToList();
               // List<فواتير> element = db.فواتير.Where(y => y.كودعميل == customer.كودعميل).ToList();
                foreach (var item in ds) 
                {
                    emp8yabDatas.Add(new حسابات_موظف{ تاريخ = item.تاريخ , ساعةحضور = item.ساعةحضور , دقيقةحضور = item.دقيقةحضور , ساعةانصراف = item.ساعةانصراف , دقيقةانصراف = item.دقيقةانصراف , ملاحظات = item.ملاحظات , سلف = item.سلف , غياب = item.غياب});
                    slf += item.سلف;
                }
                TotalmoneyLabel.Content = slf;
                Emp8yabDataGrid.ItemsSource = emp8yabDatas;   
            }
        }

        private void Emp8yabDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void sglYwmyatBtn_Click(object sender, RoutedEventArgs e)
        {
            data.randomVal= int.Parse(kodEMPLabel.Content.ToString());
            EmpK4f7sab page = new EmpK4f7sab();
            page.ShowDialog();
        }

        private void sgel7dorBtn_Click(object sender, RoutedEventArgs e)
        {
            data.randomVal = int.Parse(kodEMPLabel.Content.ToString());
            mwzfenkf48yabPage page = new mwzfenkf48yabPage();
            page.ShowDialog();
        }
    }
}
