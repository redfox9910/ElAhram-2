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

namespace ElAhram.pages.amrt48el
{
    /// <summary>
    /// Interaction logic for amrt48el3ml2Page.xaml
    /// </summary>
    public partial class amrt48el3ml2Page : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public amrt48el3ml2Page()
        {
            InitializeComponent();
            this.a5tyrmntgCombobox.IsEditable = true;
            this.a5tyrmntgCombobox.IsTextSearchEnabled = true;
        }

        private void a5tyrmntgCombobox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            a5tyrmntgCombobox.IsDropDownOpen = true;
        }

        private void a5tyrmntgPage_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                var data = db.منتجات.Where(x => x.type == 'م').Select(x => x.الخامة).ToList();
                a5tyrmntgCombobox.ItemsSource = data;
                a5tyrmntgCombobox.SelectedIndex = 0;
            }
        }

        private void a5tyrmntgBtn_Click(object sender, RoutedEventArgs e)
        {
            data.mntg2mrt48el = this.a5tyrmntgCombobox.Text;
            if (data.mntg2mrt48el == "")
            {
                DialogResult = false;
            }
            else
            {
                DialogResult = true;
            }
            this.Close();
        }

        private void amrt48el3ml2PageClosingBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
