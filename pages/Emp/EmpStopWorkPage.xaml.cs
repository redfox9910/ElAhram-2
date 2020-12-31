using ElAhram.ViewmModels._3ml2Tab;
using ElAhram.ViewmModels.EmpTab;
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
    /// Interaction logic for EmpStopWorkPage.xaml
    /// </summary>
    public partial class EmpStopWorkPage : Window
    {
        public EmpStopWorkPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refdatag();
        }
        private void refdatag()
        {
            List<aml2DataGVM> aml2data = new List<aml2DataGVM>();
            using (var db = new Models.DataContext())
            {


                foreach (var item in db.عملاء.Where(x => x.نوع == 'م'))
                {
                    aml2data.Add(new aml2DataGVM { كودعميل = item.كودعميل, اسم = item.اسم, رقم = item.رقم, عنوان = item.عنوان, ايمال = item.email, حساب = item.حساب });

                }

                this.empstopWDataG.ItemsSource = null;
                this.empstopWDataG.Items.Clear();
                this.empstopWDataG.ItemsSource = aml2data;
                this.empstopWDataG.Items.Refresh();
            }


        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {



            var rows = this.empstopWDataG.SelectedItem as EmpDataGVM;
            if (rows == null)
            {
                return;
            }


            MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("هل تريد اعادة عمل الموظف ؟", "عمل الموظف", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new Models.DataContext())
                {

                    var emp = db.موظف.Where(x => x.كودموظف == rows.كودموظف).FirstOrDefault();
                    emp.حالةالعمل = 'ع';
                    db.SaveChanges();

                }
                refdatag();

            }
           
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var rows = this.empstopWDataG.SelectedItem as EmpDataGVM;
            if (rows == null)
            {
                return;
            }


            MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("هل تريد حذف بينات الموظف نهائيا الموظف ؟", "عمل الموظف", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new Models.DataContext())
                {

                    var emp = db.موظف.Where(x => x.كودموظف == rows.كودموظف).FirstOrDefault();
                    db.Entry(emp).State= EntityState.Deleted; 
                    db.SaveChanges();

                }

                refdatag();
            }

           
        }
    }
}
