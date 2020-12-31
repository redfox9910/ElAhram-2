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

namespace ElAhram.pages.Emp
{
    /// <summary>
    /// Interaction logic for EmpAddPage.xaml
    /// </summary>
    public partial class EmpAddPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public EmpAddPage()
        {
            InitializeComponent();
        }

        private void EmpAddMntag_Click(object sender, RoutedEventArgs e)
        {
            
            dataContext.موظف.Add(new موظف {  اسم= this.emp2smText.Text, رقم = this.empMobText.Text, عنوان= this.emp3nwanText.Text,بطاقة= this.empBtakaText.Text,رقم_قومى= this.empRkmkwmyText.Text,حالةالعمل = 'ي'});
            dataContext.SaveChanges();
            DialogResult = true;
            this.Close();
        }
    }
}
