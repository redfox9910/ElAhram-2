using ElAhram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for m5zn2znsrfAddPage.xaml
    /// </summary>
    public partial class m5zn2znsrfAddPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public m5zn2znsrfAddPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            date2znsrf.Content = DateTime.Today.ToString("dd/MM/yyyy");
            using (var db = new Models.DataContext())
            {

                if (db.اذون_صرف.Any())
                {
                    kod2znSrfText.Text = db.اذون_صرف.Max(x => x.كود).ToString();
                }
                else
                {
                    kod2znSrfText.Text = "1";
                }
               
                name5amaCombo.ItemsSource = db.منتجات.Where(x =>  x.type =='خ'  ).Select(x=>x.الخامة).ToList();
            }
            kmyaText.Text = "";
            NotesText.Text = "";
            this.name5amaCombo.IsEditable = true;
            this.name5amaCombo.IsTextSearchEnabled = true;

        }

        private void kmyaText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+[.]");
            e.Handled = regex.IsMatch(e.Text);
        }

        

        private void Add2znSrfBtn_Click(object sender, RoutedEventArgs e)
        {

            using (var db = new Models.DataContext())
            {
                try
                {

               
                
               
                var element = db.منتجات.Where(x => x.الخامة == name5amaCombo.Text && x.type == 'خ').FirstOrDefault();

                if (element.الكمية >= double.Parse(kmyaText.Text))
                {
                       // var data = ;
                    db.اذون_صرف.Add(new اذن_صرف {  كودالخامة = element.كودالخامة, تاريخ = DateTime.Today, الكمية = double.Parse(kmyaText.Text), ملاحظات = NotesText.Text });
                    element.الكمية -= double.Parse(kmyaText.Text);
                    db.SaveChanges();
                        DialogResult = true;
                        this.Close();
                    }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("الكمية المراد صرفها اكثر من الكمية الحالة لهذه الخامة فى المخزن الحالى ", "اذن صرف", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                }
                catch (Exception)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("الرجاء ملئ جميع الخانات اللازمة لأتمام العملية \n الملاحظات اختيارى!!", "اذن صرف", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }

        }

        private void name5amaCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // ComboBoxItem typeItem = (ComboBoxItem).SelectedItem;
             
            if (name5amaCombo.SelectedItem != null)
            {
                string value = name5amaCombo.SelectedItem.ToString();
               
                var element = dataContext.منتجات.Where(x => x.الخامة == value && x.type == 'خ' ).FirstOrDefault();
                kmyaText.Clear();
                
                if (element.الكمية == 0 )
                {
                    kmyaText.Text = "0";
                }
                else
                {
                    kmyaText.Text = element.الكمية.ToString();
                }
                
            }
            else
            {

                name5amaCombo.ItemsSource = null;
                name5amaCombo.Items.Clear();
                name5amaCombo.Text = "";
                name5amaCombo.Items.Refresh();
                kmyaText.Text = "";
            }
             

        }

        private void kmyaText_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (kmyaText.Text == "" || kmyaText.Text== null)
            {
               
                if ( name5amaCombo.Text !="")
                {
                   

                   
                    var element = dataContext.منتجات.Where(x => x.الخامة == name5amaCombo.SelectedItem.ToString() && x.type == 'خ' ).FirstOrDefault();
                    if (element.الكمية == 0)
                    {
                        kmyaText.Text = "0";
                    }
                    else
                    {
                        kmyaText.Text = element.الكمية.ToString();
                    }
                   
                }
                else
                {
                    kmyaText.Text = "";
                }
               
            }
        }
    }
}
