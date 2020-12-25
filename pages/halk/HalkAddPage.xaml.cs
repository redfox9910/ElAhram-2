using ElAhram.Models;
using ElAhram.ViewmModels.halkTab;
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
    /// Interaction logic for HalkAddPage.xaml
    /// </summary>
    public partial class HalkAddPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        private List<هالك> HalkData = new List<هالك>();
        private Int16 x ;
        public HalkAddPage()
        {
            InitializeComponent();
        }

        private void halkAddBtn_Click(object sender, RoutedEventArgs e)
        {
          
            var found = dataContext.هالك.Where(x => x.شهر == int.Parse(this.halkAddMoncombo.Text) && x.سنة == int.Parse(this.halkAddYearcombo.Text)).Any();
            if (found == true)
            {
                var halk = dataContext.هالك.Where(x => x.شهر == int.Parse(this.halkAddMoncombo.Text) && x.سنة == int.Parse(this.halkAddYearcombo.Text)).FirstOrDefault();
                if (halksadaText.Text.ToString() == null)
                {
                    halksadaText.Text = "0";
                }
                
                if (halkMtbo3Text.Text.ToString() == null)
                {
                    halkMtbo3Text.Text = "0";
                }
                if (decimal.Parse(halksadaText.Text.ToString()) + decimal.Parse(halkMtbo3Text.Text.ToString()) <= decimal.Parse(halktotalText.Text.ToString()))
                {
                    halk.سادة = decimal.Parse(halksadaText.Text.ToString());
                    halk.مطبوع = decimal.Parse(halkMtbo3Text.Text.ToString());
                    dataContext.SaveChanges();
                    DialogResult = true;
                    this.Close();
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("اجمالى الهالك السادة و المطبوع اكبر من اجمالى الهالك لهذا الشهر ", "توزيع هالك", MessageBoxButton.OK, MessageBoxImage.Error);
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
            halktotalText.IsReadOnly = true;
            halkAddMoncombo.SelectedIndex = 0;
            halkAddYearcombo.SelectedIndex = 0;
          var elment =  dataContext.هالك.Where(x => x.شهر == int.Parse(halkAddMoncombo.Text) && x.سنة == int.Parse(halkAddYearcombo.Text)).FirstOrDefault();
            halktotalText.Text = elment.اجمالى.ToString();
            halksadaText.Text = elment.سادة.ToString();
            halkMtbo3Text.Text = elment.مطبوع.ToString();
            HalkData = dataContext.هالك.ToList();
          
        }

        private void halkAddMoncombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var x1 = halkAddMoncombo.SelectedItem as ComboBoxItem;
            var x2 = halkAddYearcombo.SelectedItem as ComboBoxItem;
            if (HalkData.Where(y=>y.شهر == int.Parse(x1.Content.ToString()) && y.سنة == int.Parse(x2.Content.ToString())).Any())
            {
                var elment = HalkData.Where(y => y.شهر == int.Parse(x1.Content.ToString()) && y.سنة == int.Parse(x2.Content.ToString())).FirstOrDefault();
                halktotalText.Text = elment.اجمالى.ToString();
                halksadaText.Text = elment.سادة.ToString();
                halkMtbo3Text.Text = elment.مطبوع.ToString();
            }
            else
            {
                
                if (x== 2)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("لا يوجد بيانات هالك لهذا الشهر", "توزيع هالك", MessageBoxButton.OK, MessageBoxImage.Error);
                    halktotalText.Text = "";
                    halksadaText.Text =  "";
                    halkMtbo3Text.Text = "";

                }
                else
                {

                    x++;
                }
               
                    
               
               
            }
        }
    }
}
