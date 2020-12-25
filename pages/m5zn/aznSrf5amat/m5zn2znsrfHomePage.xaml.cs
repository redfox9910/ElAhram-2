using ElAhram.ViewmModels.M5ZNTAB;
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

namespace ElAhram.pages.m5zn.aznSrf5amat
{
    /// <summary>
    /// Interaction logic for m5zn2znsrfHomePage.xaml
    /// </summary>
    public partial class m5zn2znsrfHomePage : Window
    {
        public m5zn2znsrfHomePage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refDatagrid();
        }
        void refDatagrid()
        {
            using (var db = new Models.DataContext())
            {

                var datas = db.اذون_صرف.ToList(); 
                List<M5zn2znsrfDataGVM> m5zn2zonData = new List<M5zn2znsrfDataGVM>();
                foreach (var item in datas)
                {
                    var element = db.منتجات.Where(z => z.type == 'خ' && z.كودالخامة == item.كودالخامة ).FirstOrDefault();
                    //   int count = db.منتجات.Where(y => y.type == 'خ' && y.كودالنوع == item.كودالنوع).Distinct().Count();
                    m5zn2zonData.Add(new M5zn2znsrfDataGVM {كود = item.كود , الخامة = element.الخامة ,الكمية = item.الكمية,تاريخ = item.تاريخ , ملاحظات = item.ملاحظات});

                }
                m5zn2zonDataG.ItemsSource = null;
                m5zn2zonDataG.ItemsSource = m5zn2zonData;
                m5zn2zonDataG.Items.Refresh();

            }

        }

        private void Add2znBtn_Click(object sender, RoutedEventArgs e)
        {
            m5zn2znsrfAddPage page = new m5zn2znsrfAddPage();
            bool? result = page.ShowDialog();
            if (result == true)
            {
                refDatagrid();
            }
         }

        private void Edit2znBtn_Click(object sender, RoutedEventArgs e)
        {
            var rows = this.m5zn2zonDataG.SelectedItem as M5zn2znsrfDataGVM;
            data.randomVal = rows.كود;
            m5zn2znsrfEditPage page = new m5zn2znsrfEditPage();
            bool? y = page.ShowDialog();
            if (y == true)
            {
                refDatagrid();
            }
        }

        private void Delete2znBtn_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("هل تريد مسح اذن الصرف ؟", "مسح اذن صرف", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            Xceed.Wpf.Toolkit.MessageBox.Show("يرجى العلم انه عند مسح الاذن سوف يتم اعادة الخامة المصروفة الى المخزن الخاص بيها ", "مسح اذن صرف", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            result = Xceed.Wpf.Toolkit.MessageBox.Show("هل  ما زالت تريد مسح اذن الصرف ؟", "مسح اذن صرف", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    var rows = this.m5zn2zonDataG.SelectedItem as M5zn2znsrfDataGVM;
                    using (var db = new Models.DataContext())
                    {

                        var element = db.اذون_صرف.Where(x=>x.كود == rows.كود).FirstOrDefault();
                        var data = db.منتجات.Where(x => x.كودالخامة == element.كودالخامة && x.type == 'خ' ).FirstOrDefault() ;
                        data.الكمية += element.الكمية;
                        db.Entry(element).State = EntityState.Deleted;

                        db.SaveChanges();
                        refDatagrid();
                        Xceed.Wpf.Toolkit.MessageBox.Show("تم مسح الاذن", "مسح اذن صرف", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);


                    }
                    break;
                case MessageBoxResult.No:

                    break;

            }
        }
    }
}
