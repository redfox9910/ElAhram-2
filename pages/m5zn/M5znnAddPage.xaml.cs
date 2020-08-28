using ElAhram.Models;
using ElAhram.ViewmModels.M5ZNTAB;
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

namespace ElAhram.pages.m5zn
{
    /// <summary>
    /// Interaction logic for M5znnAddPage.xaml
    /// </summary>
    public partial class M5znnAddPage : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public M5znnAddPage()
        {
            InitializeComponent();
        }

        private void m5znAddMntag_Click(object sender, RoutedEventArgs e)
        {
            int id = dataContext.منتجات.Max(x => x.كودالخامة)+1;
            char typex;
            ComboBoxItem typeItem = (ComboBoxItem)m5znNo3elmntg.SelectedItem;
            string value = typeItem.Content.ToString();
            if (value == "خامة")
            {
                typex = 'خ';
            }
            else
            {
                typex = 'م';
            }
            dataContext.منتجات.Add(new المنتجات { كودالخامة = id,الخامة=m5zn2smmntg.Text, الكمية=0,type=typex});
            dataContext.SaveChanges();
            programTabs programTabs = new programTabs(dataContext);
            this.Close();
           // programTabs.;
            //programTabs.ptabs.SelectedIndex = 1;


            List<M5znDGrid> m5zndata = new List<M5znDGrid>();
            foreach (var item in dataContext.منتجات)
            {
                m5zndata.Add(new M5znDGrid { كودالخامة = item.كودالخامة, الخامة = item.الخامة, الكمية = item.الكمية });

            }
            // m5zndata = dataContext.منتجات.ToList();
            programTabs.m5znDataGrid.ItemsSource = null;
            programTabs.m5znDataGrid.Items.Clear();
            programTabs.m5znDataGrid.ItemsSource = m5zndata;
            programTabs.m5znDataGrid.Items.Refresh();
            programTabs.ptabs.SelectedIndex = 1;
            programTabs.ptabs.Items.Refresh();
            programTabs.ptabs.UpdateLayout();
            
            // programTabs.m5znDataGrid.

        }
    }
}
