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

namespace ElAhram.pages.ywmyat
{
    /// <summary>
    /// Interaction logic for addywmya.xaml
    /// </summary>
    public partial class addywmya : Window
    {
        public addywmya()
        {
            InitializeComponent();
        }

        private void s7bywmyacombox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            s7bywmyacombox.IsDropDownOpen = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                foreach (var item in db.حالات_يوميات.ToList())

                {

                    this.ywmyacombo.Items.Add(item.حالة);
                }
                if (db.يوميات.Any())
                {
                    rkmywmyaText.Text = db.يوميات.Max(x => x.كود).ToString();
                }
                else
                {
                    rkmywmyaText.Text = "1";
                }
            }
            this.s7bywmyacombox.IsEditable = true;
            this.s7bywmyacombox.IsTextSearchEnabled = true;
        }

        private void nkdyelywmyaText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
