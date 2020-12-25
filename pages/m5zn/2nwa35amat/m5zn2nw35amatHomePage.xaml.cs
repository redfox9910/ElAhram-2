using ElAhram.ViewmModels.M5ZNTAB;
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

namespace ElAhram.pages.m5zn._2nwa35amat
{
    /// <summary>
    /// Interaction logic for m5zn2nw35amatHomePage.xaml
    /// </summary>
    public partial class m5zn2nw35amatHomePage : Window
    {
        public m5zn2nw35amatHomePage()
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

                var datas = db.انواع_خامات.ToList(); ;
                List<no3MntagDataGVM> no3Mntags = new List<no3MntagDataGVM>();
                foreach (var item in datas)
                {
                    int count = db.منتجات.Where(y => y.type == 'خ' && y.كودالنوع == item.كودالنوع).Distinct().Count();
                    no3Mntags.Add(new no3MntagDataGVM { النوع = item.النوع, عددالخامات = count });

                }
                tpye5matDataG.ItemsSource = null;
                tpye5matDataG.ItemsSource = no3Mntags;
                tpye5matDataG.Items.Refresh();
            }

        }

        private void AddNo3Btn_Click(object sender, RoutedEventArgs e)
        {
            m5zn2nwa35amat page = new m5zn2nwa35amat();
          bool? reslut = page.ShowDialog();
            if (reslut == true)
            {
                refDatagrid();
            }
        }

        private void EditNo3Btn_Click(object sender, RoutedEventArgs e)
        {
            m5zn2nwa35amatEditPage page = new m5zn2nwa35amatEditPage();
            bool? reslut = page.ShowDialog();
            if (reslut == true)
            {
                refDatagrid();
            }
        }

        private void DeleteNo3Btn_Click(object sender, RoutedEventArgs e)
        {
            m5zn2nwa35amatDeletePage page = new m5zn2nwa35amatDeletePage();
            bool? reslut = page.ShowDialog();
            if (reslut == true)
            {
                refDatagrid();
            }
        }
    }
}
