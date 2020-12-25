using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ElAhram.Models;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using ElAhram.ViewmModels._5zna;

namespace ElAhram.pages._5zna
{
    /// <summary>
    /// Interaction logic for SglT7welatPage.xaml
    /// </summary>
    public partial class SglT7welatPage : Window
    {
        public SglT7welatPage()
        {
            InitializeComponent();
        }

        static List<sglatT7welatDataGVM> sglatDatas = new List<sglatT7welatDataGVM>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            using (var db = new Models.DataContext())
            {
                var elements = db.تحويلات.ToList();
                List<sglatT7welatDataGVM> k4f7sabsglatData = new List<sglatT7welatDataGVM>();
                foreach (var item in elements)
                {
                    if (item.نوع =='ح')
                    {
                        k4f7sabsglatData.Add(new sglatT7welatDataGVM { id = item.id, تاريخ = item.تاريخ, قيمة = item.قيمة ,نوع = "تحويل الى الحساب البنكى" });
                    }
                    else
                    {
                        k4f7sabsglatData.Add(new sglatT7welatDataGVM { id = item.id, تاريخ = item.تاريخ, قيمة = item.قيمة, نوع = "تحويل الى الخزنة" });
                    }
                   
                   
                }
                sglatT7welatDataG.ItemsSource = k4f7sabsglatData;
                sglatDatas = k4f7sabsglatData.ToList();
               
            }
        }

        private void datefromDateP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datefromDateP.SelectedDate == null)
            {
                sglatT7welatDataG.ItemsSource = null;
                sglatT7welatDataG.ItemsSource = sglatDatas.Where(x => x.تاريخ < dateToDateP.SelectedDate.Value.AddDays(1)).ToList();
            }
            else if (dateToDateP.SelectedDate == null)
            {
                sglatT7welatDataG.ItemsSource = null;
                sglatT7welatDataG.ItemsSource = sglatDatas.Where(x => x.تاريخ >= datefromDateP.SelectedDate).ToList();
            }
            else
            {
                sglatT7welatDataG.ItemsSource = null;
                sglatT7welatDataG.ItemsSource = sglatDatas.Where(x => x.تاريخ >= datefromDateP.SelectedDate && x.تاريخ < dateToDateP.SelectedDate.Value.AddDays(1)).ToList();
            }
            sglatT7welatDataG.Items.Refresh();

        }
    }
}
