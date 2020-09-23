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

namespace ElAhram.pages.amr4r2
{
    /// <summary>
    /// Interaction logic for amr4r25matList.xaml
    /// </summary>
    public partial class amr4r25matList : Window
    {
        public amr4r25matList()
        {
            InitializeComponent();
            this.a5tyr5amaCombobox.IsEditable = true;
            this.a5tyr5amaCombobox.IsTextSearchEnabled = true;
        }

        private void a5tyr5amaPage_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Models.DataContext())
            {
                var data = db.منتجات.Where(x => x.type == 'خ').Select(x => x.الخامة).ToList();
                a5tyr5amaCombobox.ItemsSource = data;
                a5tyr5amaCombobox.SelectedIndex = 0;
            }
        }

        private void a5tyr5amaCombobox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            a5tyr5amaCombobox.IsDropDownOpen = true;
        }

        private void a5tyr5amaPageClosingBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void a5tyr5amaBtn_Click(object sender, RoutedEventArgs e)
        {
            data.amr4r25ama = this.a5tyr5amaCombobox.Text;
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
    }
}
