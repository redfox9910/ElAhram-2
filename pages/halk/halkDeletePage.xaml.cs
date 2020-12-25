using ElAhram.Models;
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

namespace ElAhram.pages.halk
{
    /// <summary>
    /// Interaction logic for halkDeletePage.xaml
    /// </summary>
    public partial class halkDeletePage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        private List<هالك> HalkData = new List<هالك>();
        private Int16 x;
        public halkDeletePage()
        {
            InitializeComponent();
        }
        private void halkAddBtn_Click(object sender, RoutedEventArgs e)
        {

            var found = dataContext.هالك.Where(x => x.شهر == int.Parse(this.halkAddMoncombo.Text) && x.سنة == int.Parse(this.halkAddYearcombo.Text)).Any();
            if (found == true)
            {
                var halk = dataContext.هالك.Where(x => x.شهر == int.Parse(this.halkAddMoncombo.Text) && x.سنة == int.Parse(this.halkAddYearcombo.Text)).FirstOrDefault();
                if (halktotalText.Content.ToString() == null)
                {
                    halktotalText.Content = "0";
                }

               
                if (halk.اجمالى >= decimal.Parse(halk5smText.Text.ToString()))
                {
                    halk.اجمالى -= decimal.Parse(halk5smText.Text.ToString());
                    if (halk.سادة + halk.مطبوع > halk.اجمالى)
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("اجمالى الهالك اصبح اقل من الهالك السادة و المطبوع لهذا الشهر \nالرجاء تعديل كميه الهالك السادة و المطبوع ثم حذف من الاجمالى", "توزيع هالك", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    dataContext.SaveChanges();
                    DialogResult = true;
                    this.Close();
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("اجمالى الهالك اقل من الكمية المعطه ", "حذف", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                //  dataContext.هالك.Add(new هالك { شهر = int.Parse(this.halkAddMoncombo.Text), سنة = int.Parse(this.halkAddYearcombo.Text), سادة = decimal.Parse(halksadaText.Text.ToString()),مطبوع= decimal.Parse(halkMtbo3Text.Text.ToString()) });
                Xceed.Wpf.Toolkit.MessageBox.Show("لا يوجد بيانات هالك لهذا الشهر", "توزيع هالك", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        private void halkaddPage1_Loaded(object sender, RoutedEventArgs e)
        {
            x = 0; // flag to start for selection change 
           // halktotalText.IsReadOnly = true;
            halkAddMoncombo.SelectedIndex = 0;
            halkAddYearcombo.SelectedIndex = 0;
            var elment = dataContext.هالك.Where(x => x.شهر == int.Parse(halkAddMoncombo.Text) && x.سنة == int.Parse(halkAddYearcombo.Text)).FirstOrDefault();
            halktotalText.Content = elment.اجمالى.ToString();
           
            HalkData = dataContext.هالك.ToList();

        }

        private void halkAddMoncombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var x1 = halkAddMoncombo.SelectedItem as ComboBoxItem;
            var x2 = halkAddYearcombo.SelectedItem as ComboBoxItem;
            if (HalkData.Where(y => y.شهر == int.Parse(x1.Content.ToString()) && y.سنة == int.Parse(x2.Content.ToString())).Any())
            {
                var elment = HalkData.Where(y => y.شهر == int.Parse(x1.Content.ToString()) && y.سنة == int.Parse(x2.Content.ToString())).FirstOrDefault();
                halktotalText.Content = elment.اجمالى.ToString();
               
            }
            else
            {

                if (x == 2)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("لا يوجد بيانات هالك لهذا الشهر", "توزيع هالك", MessageBoxButton.OK, MessageBoxImage.Error);
                    halktotalText.Content = "";
                   

                }
                else
                {

                    x++;
                }




            }
        }
    }
}
