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
    /// Interaction logic for HalkAddPage.xaml
    /// </summary>
    public partial class HalkAddPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
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
               
                halk.سادة += decimal.Parse(halksadaText.Text.ToString());
                halk.مطبوع += decimal.Parse(halkMtbo3Text.Text.ToString());
            }
            else
            {
               dataContext.هالك.Add(new هالك { شهر = int.Parse(this.halkAddMoncombo.Text), سنة = int.Parse(this.halkAddYearcombo.Text), سادة = decimal.Parse(halksadaText.Text.ToString()),مطبوع= decimal.Parse(halkMtbo3Text.Text.ToString()) });
               
            }

            dataContext.SaveChanges();
            DialogResult = true;
            this.Close();
        }

        private void halkaddPage1_Loaded(object sender, RoutedEventArgs e)
        {
            halkAddMoncombo.SelectedIndex = 0;
            halkAddYearcombo.SelectedIndex = 0;
            halksadaText.Text = "0";
            halkMtbo3Text.Text = "0";
        }
    }
}
