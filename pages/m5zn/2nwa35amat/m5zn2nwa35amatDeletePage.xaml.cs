using ElAhram.Models;
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

namespace ElAhram.pages.m5zn._2nwa35amat
{
    /// <summary>
    /// Interaction logic for m5zn2nwa35amatDeletePage.xaml
    /// </summary>
    public partial class m5zn2nwa35amatDeletePage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public m5zn2nwa35amatDeletePage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var data = dataContext.انواع_خامات.Select(x => x.النوع).ToList();
            No3deleteCombobox.ItemsSource = data;
            No3deleteCombobox.SelectedIndex = 0;
        }

        private void No3DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int No3ID = dataContext.انواع_خامات.Where(x => x.النوع == No3deleteCombobox.SelectedItem.ToString()).Select(x => x.كودالنوع).FirstOrDefault();
            MessageBoxResult boxResult;
            if (dataContext.منتجات.Where(x => x.كودالنوع == No3ID).Any())
            {
                boxResult = Xceed.Wpf.Toolkit.MessageBox.Show("هذا النوع يحتوى على خامات هل تريد حذفه ؟  !", "حذف مخزن", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (boxResult == MessageBoxResult.Yes)
                {
                    boxResult = Xceed.Wpf.Toolkit.MessageBox.Show("يؤجى العلم ان الخامات التابعة لهذا النوع لن يكون لها اى نوع \nولكن مازلات مجودة و يمكن التعديل ل اضافة نوع جديد لها \nتاكيد مسح المنتج ؟   !", "حذف مخزن", MessageBoxButton.YesNo, MessageBoxImage.Information);
                }
             }
            else
            {
                boxResult = Xceed.Wpf.Toolkit.MessageBox.Show("هذا النوع فارغ هل تريد حذفه؟", "حذف مخزن", MessageBoxButton.YesNo, MessageBoxImage.Information);
            }
            if (boxResult == MessageBoxResult.Yes)
            {
                انواع_الخامات m5zn = dataContext.انواع_خامات.Where(x => x.كودالنوع == No3ID).FirstOrDefault();
                dataContext.Entry(m5zn).State = EntityState.Deleted;
                dataContext.SaveChanges();
                DialogResult = true;
                this.Close();
            }

        }
    }
}
