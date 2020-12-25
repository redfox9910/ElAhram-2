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
    /// Interaction logic for m5zn2znsrfEditPage.xaml
    /// </summary>
    public partial class m5zn2znsrfEditPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public m5zn2znsrfEditPage()
        {
            InitializeComponent();
        }

        static Models.اذن_صرف aznsrf;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                 aznsrf = db.اذون_صرف.Where(y=>y.كود == data.randomVal).FirstOrDefault();
               
                name5amaCombo.ItemsSource = db.منتجات.Where(x =>  x.type == 'خ').Select(x => x.الخامة).ToList();
                name5amaCombo.Text = db.منتجات.Where(y => y.كودالخامة == aznsrf.كودالخامة && y.type == 'خ' ).Select(y => y.الخامة).FirstOrDefault();
                kmyaText.Text = aznsrf.الكمية.ToString();
                NotesText.Text = aznsrf.ملاحظات;
                date2znsrf.Content = aznsrf.تاريخ;
                kod2znSrfText.Text = aznsrf.كود.ToString();
                /*  foreach (var item in db.منتجات.Where())

                {

                    this.name5amaCombo.Items.Add(item.اسم);
                }  */
                this.name5amaCombo.IsEditable = true;
                this.name5amaCombo.IsTextSearchEnabled = true;

            }
           

        }
        private void kmyaText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+[.]");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void kmyaText_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (kmyaText.Text == "" || kmyaText.Text == null || kmyaText.Text == "0")
            {
               
                kmyaText.Text = aznsrf.الكمية.ToString();
            }
        }

        private void name5amaCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value;


            if (name5amaCombo.SelectedItem.ToString() == null)
            {
                value = name5amaCombo.Text;
            }
            else
            {
                value = name5amaCombo.SelectedItem.ToString();
            }        
            var mntg = dataContext.منتجات.Where(x => x.الخامة == value && x.type == 'خ' ).FirstOrDefault();

            kmayaLabel.Content = mntg.الكمية;
        }

        private void Edit2znSrfBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                try
                {



                   
                    var element = db.منتجات.Where(x => x.كودالخامة== aznsrf.كودالخامة && x.type == 'خ' ).FirstOrDefault();
                    if (element.الخامة == name5amaCombo.Text)
                    {

                   
                      if (element.الكمية >= double.Parse(kmyaText.Text))
                      {
                         var datax = db.اذون_صرف.Where(x=>x.كود == data.randomVal).FirstOrDefault() ;
                            element.الكمية += datax.الكمية;
                            element.الكمية -= double.Parse(kmyaText.Text);
                            datax.الكمية = double.Parse(kmyaText.Text);
                            datax.ملاحظات = NotesText.Text;
                            
                        db.SaveChanges();
                        DialogResult = true;
                        this.Close();
                      }
                     else
                       {
                        Xceed.Wpf.Toolkit.MessageBox.Show("الكمية المراد صرفها اكثر من الكمية الحالة لهذه الخامة فى المخزن الحالى ", "اذن صرف", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                    }
                    else
                    {
                       var newelement  = db.منتجات.Where(x => x.الخامة == name5amaCombo.Text && x.type == 'خ' ).FirstOrDefault();


                        if (newelement.الكمية >= double.Parse(kmyaText.Text))
                        {
                            var datax = db.اذون_صرف.Where(x => x.كود == data.randomVal).FirstOrDefault();
                            element.الكمية += datax.الكمية;
                            newelement.الكمية -= double.Parse(kmyaText.Text);
                            datax.الكمية = double.Parse(kmyaText.Text);
                            datax.ملاحظات = NotesText.Text;
                            datax.كودالخامة = newelement.كودالخامة;

                            db.SaveChanges();
                            DialogResult = true;
                            this.Close();
                        }
                        else
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("الكمية المراد صرفها اكثر من الكمية الحالة لهذه الخامة فى المخزن الحالى ", "اذن صرف", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                    }
                }
                catch (Exception)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("الرجاء ملئ جميع الخانات اللازمة لأتمام العملية \n الملاحظات اختيارى!!", "اذن صرف", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }

        }
    }
}
