using ElAhram.Models;
using ElAhram.pages._3ml2;
using ElAhram.pages._5zna;
using ElAhram.pages.amr4r2;
using ElAhram.pages.amrt48el;
using ElAhram.pages.Emp;
using ElAhram.pages.fwater;
using ElAhram.pages.halk;
using ElAhram.pages.m5zn;
using ElAhram.pages.m5zn._2nwa35amat;
using ElAhram.pages.m5zn.aznSrf5amat;
using ElAhram.pages.mwrden;
using ElAhram.pages.mwzfen;
using ElAhram.pages.password;
using ElAhram.pages.ywmyat;
using ElAhram.ViewmModels;
using ElAhram.ViewmModels._3ml2Tab;
using ElAhram.ViewmModels.Amr4r2;
using ElAhram.ViewmModels.amrT48el;
using ElAhram.ViewmModels.EmpTab;
using ElAhram.ViewmModels.fwter;
using ElAhram.ViewmModels.halkTab;
using ElAhram.ViewmModels.M5ZNTAB;
using ElAhram.ViewmModels.mwrden;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ElAhram
{
    /// <summary>
    /// Interaction logic for programTabs.xaml
    /// </summary>
    public partial class programTabs : Window
    {
        private readonly DataContext dataContext = new Models.DataContext();
        public ObservableCollection<string> ItemList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private static char m5znNo3DataG;
        public programTabs(DataContext Db)
        {
            InitializeComponent();
            if (dataContext.حالات_يوميات.Count() !=5)
            {
                dataContext.حالات_يوميات.Add(new حالات_اليوميات { حالة = "وارد" });
                dataContext.حالات_يوميات.Add(new حالات_اليوميات { حالة = "مصاريف" });
                dataContext.حالات_يوميات.Add(new حالات_اليوميات { حالة = "سلف " });
                dataContext.حالات_يوميات.Add(new حالات_اليوميات { حالة = "مرتبات " });
                dataContext.حالات_يوميات.Add(new حالات_اليوميات { حالة = "تحويلات" });
            }
            ref5zna();
        }
        /* public programTabs()
         {
             InitializeComponent();
             var x = dataContext.خزنة.FirstOrDefault();
             cash.Content = x.نقدى;
         }  */

        private void btnSelectedTab_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Selected tab: " + (ptabs.SelectedItem as TabItem).Header + "\n index " + (ptabs.SelectedItem as TabItem).TabIndex);
        }

        private void btnSelectedTab_home(object sender, RoutedEventArgs e)
        {
            ptabs.SelectedIndex = 5;
        }

        private void ptabs_Loaded(object sender, RoutedEventArgs e)
        {
            List<M5znDGrid> m5zndata = new List<M5znDGrid>();
            foreach (var item in dataContext.منتجات)
            {
                m5zndata.Add(new M5znDGrid { كودالخامة = item.كودالخامة, الخامة = item.الخامة, الكمية = item.الكمية });

            }
            // m5zndata = dataContext.منتجات.ToList();
            this.m5znDataGrid.ItemsSource = m5zndata;

        }

        // مخزن
        private void addM5znBtn_Click(object sender, RoutedEventArgs e)
        {
            M5znnAddPage m5ZnaddPage = new M5znnAddPage();
            m5ZnaddPage.Owner = this;
            bool? result = m5ZnaddPage.ShowDialog();
            if (result == true)
            {
                List<M5znDGrid> m5zndata = new List<M5znDGrid>();
                foreach (var item in dataContext.منتجات.Where(y=> y.type == data.no3MntgMdaf))
                {
                    m5zndata.Add(new M5znDGrid { كودالخامة = item.كودالخامة, الخامة = item.الخامة, الكمية = item.الكمية });

                }
                // m5zndata = dataContext.منتجات.ToList();
               
                this.m5znDataGrid.ItemsSource = null;
                this.m5znDataGrid.Items.Clear();
                this.m5znDataGrid.ItemsSource = m5zndata;
                this.m5znDataGrid.Items.Refresh();
               
            }
        }


        private void EditM5znBtn_Click(object sender, RoutedEventArgs e)
        {
            m5znEditPage m5ZneditPage = new m5znEditPage();
            bool? result = m5ZneditPage.ShowDialog();
            if (result == true)
            {
                refm5zndataG();
            }
        }


        private void DeleteM5znBtn_Click(object sender, RoutedEventArgs e)
        {
            M5znDeletePage m5ZneditPage = new M5znDeletePage();
            bool? result = m5ZneditPage.ShowDialog();
            if (result == true)
            {
                refm5zndataG();
            }
        }
        private void refm5zndataG()
        {
            List<M5znDGrid> m5zndata = new List<M5znDGrid>();
            using (var db = new Models.DataContext())
            {
                foreach (var item in db.منتجات.Where(x => x.type == 'خ' ))
                {
                    m5zndata.Add(new M5znDGrid { كودالخامة = item.كودالخامة, الخامة = item.الخامة, الكمية = item.الكمية });

                }
               
                m5zn2znsrfBtn.Visibility = Visibility.Visible;
                m5zn2nwa35amatBtn.Visibility = Visibility.Visible;
               
                this.m5znDataGrid.ItemsSource = null;
                this.m5znDataGrid.Items.Clear();
                this.m5znDataGrid.ItemsSource = m5zndata;
                this.m5znDataGrid.Items.Refresh();
                m5znNo3DataG = '5';

            }
        }
       
        private void m5znHeader_Clicked(object sender, MouseButtonEventArgs e)
        {
            password Page = new password();
            bool? result = Page.ShowDialog();
            if (result == true)
            {
                using (var db = new Models.DataContext())
                {
                    var data = db.خزنة.FirstOrDefault();


                    cash.Content = data.نقدى;
                    mden.Content = data.مدين;
                    d2n.Content = data.دائن;
                    total.Content = data.اجمالى;
                    cash4ekat.Content = data.شيكات;
                    cash7sab.Content = data.حساب;

                }
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("الرجاء ادخال كلمة المرور لتتمكن من الوصول الى هذه النافذة ", "كلمة مرور", MessageBoxButton.OK, MessageBoxImage.Error);
               Home page = new Home();
                page.Show();
                this.Close();
            }
        }

        private void m5znDataGrid_Loaded(object sender, RoutedEventArgs e)
        {

            refm5zndataG();
        }

        private void m5zn5amatBtn_Click(object sender, RoutedEventArgs e)
        {
            if (m5znNo3DataG != '5')
            {
                refm5zndataG();
            }
            

        }

        private void m5znmntgatBtn_Click(object sender, RoutedEventArgs e)
        {
            if (m5znNo3DataG != 'm')
            {

            
            List<M5znDGrid> m5zndata = new List<M5znDGrid>();
            using (var db = new Models.DataContext())
            {
                foreach (var item in db.منتجات.Where(x => x.type == 'م' ))
                {
                    m5zndata.Add(new M5znDGrid { كودالخامة = item.كودالخامة, الخامة = item.الخامة, الكمية = item.الكمية });

                }
                
                m5zn2znsrfBtn.Visibility = Visibility.Hidden;
                m5zn2nwa35amatBtn.Visibility = Visibility.Hidden;
                this.m5znDataGrid.ItemsSource = null;
                this.m5znDataGrid.Items.Clear();
                this.m5znDataGrid.ItemsSource = m5zndata;
                this.m5znDataGrid.Items.Refresh();
                m5znNo3DataG = 'm';

            }
            }
        }


        private void aml2combobox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            AmrT48elaml2combobox.IsDropDownOpen = true;
        }

        public string Search3ml2Text
        {
            get => Search3ml2Text;
            set
            {
                if (Search3ml2Text == value) return;
                Search3ml2Text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Search3ml2Text)));
            }
        }


       


        private void amrt48elDate_Loaded(object sender, RoutedEventArgs e)
        {
            this.amrt48elDate.Content = DateTime.Now.ToString("dd/MM/yyyy");
        }

        

        private void empAddBtn_Click(object sender, RoutedEventArgs e)
        {
            EmpAddPage empAddPage = new EmpAddPage();
            bool? result = empAddPage.ShowDialog();
            if (result == true)
            {
                refEmpdataG();
            }

        }

       


        private void Empdatagrid_Loaded(object sender, RoutedEventArgs e)
        {
            refEmpdataG();
        }




        private void _3ml2Datagrid_Loaded(object sender, RoutedEventArgs e)
        {
            ref3ml2dataG();

        }


        private void aml2AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Aml2AddPage Aml2AddPage = new Aml2AddPage();
            bool? result = Aml2AddPage.ShowDialog();
            if (result == true)
            {
                ref3ml2dataG();
            }

        }


        private void halkDate_Loaded(object sender, RoutedEventArgs e)
        {
            this.halkDate.Content = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void halkAddBtn_Click(object sender, RoutedEventArgs e)
        {
            HalkAddPage halkAddPage = new HalkAddPage();
            bool? result = halkAddPage.ShowDialog();
            if (result == true)
            {
                refhalkdataG();
            }
        }


        private void halkDatagrid_Loaded(object sender, RoutedEventArgs e)
        {
            refhalkdataG();
        }


        private void mwrdenDatagrid_Loaded(object sender, RoutedEventArgs e)
        {
            refmwrdendataG();
        }


        private void mwrdenAddBtn_Click(object sender, RoutedEventArgs e)
        {
            mwrdenAddPage mwrdenAddPage = new mwrdenAddPage();
            bool? result = mwrdenAddPage.ShowDialog();
            if (result == true)
            {
                refmwrdendataG();
            }
        }
        // امر التشغيل 
        private void _2mrt48el_Loaded(object sender, RoutedEventArgs e)
        {

            List<String> names = new List<string>();


            using (var db = new Models.DataContext())
            {
                foreach (var item in db.عملاء.Where(x => x.نوع == 'ع'))

                {

                    this.AmrT48elaml2combobox.Items.Add(item.اسم);
                }
                if (db.فواتير.Where(x => x.نوع_فاتورة == 'ب').Count() == 0)
                {
                    amrt48elkodTextBox.Content = 1;
                }
                else
                {
                    amrt48elkodTextBox.Content = int.Parse(db.فواتير.Where(x => x.نوع_فاتورة == 'ب').Max(x => x.رقم).ToString()) + 1;
                }
            }
            this.AmrT48elaml2combobox.IsEditable = true;
            this.AmrT48elaml2combobox.IsTextSearchEnabled = true;


        }
        private void amrt48elDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<amrt48elDataGVM> amrt48eldata = new List<amrt48elDataGVM>();

            this.amrt48elDataGrid.ItemsSource = null;
            this.amrt48elDataGrid.Items.Clear();
                                                   
            this.amrt48elDataGrid.ItemsSource = amrt48eldata;

        }

        private void addmntgatBtn_Click(object sender, RoutedEventArgs e)
        {
            amrt48el3ml2Page mwrdenAddPage = new amrt48el3ml2Page();
            var list = (IList)this.amrt48elDataGrid.ItemsSource;
            mwrdenAddPage.ShowDialog();
            var mntg = new amrt48elDataGVM { رقم = amrt48elDataGrid.Items.Count + 1, اسم = data.mntg2mrt48el, كميةمنتج = 0 };
            list.Add(mntg);
        }

        private void amrt48elDataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            amrt48el3ml2Page amrt48El3Ml2 = new amrt48el3ml2Page();
            //data.amrt48ElDatas = (IList)this.amrt48elDataGrid.ItemsSource;
            bool? result = amrt48El3Ml2.ShowDialog();
            //List<amrt48elDataGVM> mntg = new List<amrt48elDataGVM>();

            //  mntg.Add(  new amrt48elDataGVM { رقم = amrt48elDataGrid.Items.Count + 1, اسم = data.mntg2mrt48el, كمية = 0 });
            //this.amrt48elDataGrid.ItemsSource = mntg;
            if (result == true)
            {
                data.amrt48ElDatas.Add(new amrt48elDataGVM { رقم = amrt48elDataGrid.Items.Count + 1, اسم = data.mntg2mrt48el, كميةمنتج = 0,كميةخامة=0 });

                //data.amrt48ElDatas.Add(mntg);
                this.amrt48elDataGrid.ItemsSource = null;
                this.amrt48elDataGrid.Items.Clear();
                this.amrt48elDataGrid.ItemsSource = data.amrt48ElDatas;
               // this.amrt48elDataGrid.amrt48elDG  m5aznDGcombo.ItemsSource = dataContext.مخزن.Select(s => s.المخزن).ToList();
                amrt48elDataGrid.Items.Refresh();
            }

            else
            {
                this.amrt48elDataGrid.ItemsSource = null;
                this.amrt48elDataGrid.Items.Clear();
                this.amrt48elDataGrid.ItemsSource = data.amrt48ElDatas;
            }
        }

        

        private void amrt48el2dafa_Click(object sender, RoutedEventArgs e)
        {
            ////data.amrt48ElDatas =   (List <amrt48elDataGVM>) this.amrt48elDataGrid.Items;

            //foreach (var item in this.amrt48elDataGrid.Items)
            //{
            //    var x = item;
            //}
            var s = amrt48elDataGrid.Items[1];
            foreach (var item in amrt48elDataGrid.Items)
            {
                var z = item;

            }
            foreach (var item in amrt48elDataGrid.Columns)
            {
                var z = item;

            }
            using (var db = new Models.DataContext())
            {
                فواتير element = new فواتير();
                امرتشغيل dataX = new امرتشغيل();
                //ComboBoxItem typeItem = (ComboBoxItem)AmrT48elaml2combobox.SelectedItem;
                //  try
                {



                    var y = AmrT48elaml2combobox.Text;
                    //string value = typeItem.Content.ToString();

                    element.تاريخ_تشغيل = DateTime.ParseExact(this.amrt48elDate.Content.ToString(), "dd/MM/yyyy", null); 
                    element.رقم = int.Parse(this.amrt48elkodTextBox.Content.ToString());

                    element.كودعميل = Convert.ToInt32(db.عملاء.Where(x => x.اسم == y).Select(x => x.كودعميل).FirstOrDefault());
                    element.نوع_فاتورة = 'ب';
                    element.فاتورة = 'n';
                    db.فواتير.Add(element);
                    db.SaveChanges();
                  
                    foreach (var item in data.amrt48ElDatas)
                    {
                        dataX.رقم = element.رقم;
                        dataX.كودالخامة = db.منتجات.Where(x => x.الخامة == item.اسم).Select(y => y.كودالخامة).FirstOrDefault();
                        dataX.كمية = item.كميةمنتج;
                        dataX.اوميا = item.اوميا;
                        dataX.بيور = item.بيور;
                        dataX.سمك = item.سمك;
                        dataX.مقاس_تقطيع = item.مقاس_تقطيع;
                        dataX.مقاس_طباعة = item.مقاس_طباعة;
                        dataX.نوع_فاتورة = 'ب';
                        dataX.كميةخامة = item.كميةخامة.ToString();
                        dataX.type = 'م';
                        db.امرتشغيل.Add(dataX);

                        dataX = new امرتشغيل(); 
                    }

                    db.SaveChanges();
                    this.amrt48elkodTextBox.Content = db.فواتير.Max(y=>y.رقم) + 1;
                    AmrT48elaml2combobox.Text = null;
                    this.amrt48elDataGrid.ItemsSource = null;
                    this.amrt48elDataGrid.Items.Clear();
                    data.amrt48ElDatas.Clear();
                    this.amrt48elDataGrid.ItemsSource = data.amrt48ElDatas;
                }
                //        catch (Exception)
                {

                    //         MessageBox.Show("املاء الفراغات","خطاء فى عمليه الادخال ",MessageBoxButton.OK,MessageBoxImage.Error);
                }

            }
        }

        private void Amrt48elHeader_Clicked(object sender, MouseButtonEventArgs e)
        {
            this.AmrT48elaml2combobox.Items.Clear();

            using (var db = new Models.DataContext())
            {
                foreach (var item in db.عملاء.Where(x => x.نوع == 'ع'))

                {

                    this.AmrT48elaml2combobox.Items.Add(item.اسم);
                }
            }
            this.AmrT48elaml2combobox.IsEditable = true;
            this.AmrT48elaml2combobox.IsTextSearchEnabled = true;
        }
        private void amrT48elListBtn_Click(object sender, RoutedEventArgs e)
        {
            Amrt48elListPage amrt48elListPage = new Amrt48elListPage();
            amrt48elListPage.ShowDialog();
        }



        private void refmwrdendataG()
        {
            List<mwrdenDataGVM> mwrdendata = new List<mwrdenDataGVM>();
            using (var db = new Models.DataContext())
            {


                foreach (var item in db.عملاء.Where(x => x.نوع == 'م'))
                {
                    mwrdendata.Add(new mwrdenDataGVM { كودعميل = item.كودعميل, اسم = item.اسم, رقم = item.رقم, عنوان = item.عنوان, ايمال = item.email, حساب = item.حساب });

                }

                this.mwrdenDatagrid.ItemsSource = null;
                this.mwrdenDatagrid.Items.Clear();
                this.mwrdenDatagrid.ItemsSource = mwrdendata;
                this.mwrdenDatagrid.Items.Refresh();
            }
        }

        private void refhalkdataG()
        {
            List<HalkDataGVM> aml2data = new List<HalkDataGVM>();
            using (var db = new Models.DataContext())
            {


                foreach (var item in db.هالك)
                {

                    bool blance=(item.اجمالى == (item.سادة + item.مطبوع)) ?  true: false;
                    decimal def = (item.اجمالى != (item.سادة + item.مطبوع)) ? (item.اجمالى - (item.سادة + item.مطبوع)) : 0;
                    aml2data.Add(new HalkDataGVM { شهر = item.شهر, سنة = item.سنة, اجمالى = item.اجمالى,سادة = item.سادة, مطبوع = item.مطبوع ,غيرمصنف = def , متوازن = blance});

                }

                this.halkDatagrid.ItemsSource = null;
                this.halkDatagrid.Items.Clear();
                this.halkDatagrid.ItemsSource = aml2data;
                this.halkDatagrid.Items.Refresh();
            }
        }



        private void ref3ml2dataG()
        {
            List<aml2DataGVM> aml2data = new List<aml2DataGVM>();
            using (var db = new Models.DataContext())
            {


                foreach (var item in db.عملاء.Where(x => x.نوع == 'ع'))
                {
                    aml2data.Add(new aml2DataGVM { كودعميل = item.كودعميل, اسم = item.اسم, رقم = item.رقم, عنوان = item.عنوان, ايمال = item.email, حساب = item.حساب });

                }

                this._3ml2Datagrid.ItemsSource = null;
                this._3ml2Datagrid.Items.Clear();
                this._3ml2Datagrid.ItemsSource = aml2data;
                this._3ml2Datagrid.Items.Refresh();
            }
        }


        private void refEmpdataG()
        {
            List<EmpDataGVM> empdata = new List<EmpDataGVM>();
            using (var db = new Models.DataContext())
            {


                foreach (var item in db.موظف)
                {
                    empdata.Add(new EmpDataGVM { كودموظف = item.كودموظف, اسم = item.اسم, رقم = item.رقم, عنوان = item.عنوان, بطاقة = item.بطاقة, قومى = item.رقم_قومى });

                }

                this.Empdatagrid.ItemsSource = null;
                this.Empdatagrid.Items.Clear();
                this.Empdatagrid.ItemsSource = empdata;
                this.Empdatagrid.Items.Refresh();
            }
        }
      

        private void fwterHeader_Clicked(object sender, MouseButtonEventArgs e)
        {
            this.fwteraml2combobox.Items.Clear();

            using (var db = new Models.DataContext())
            {
                foreach (var item in db.عملاء.Where(x => x.نوع == 'ع'))

                {

                    this.fwteraml2combobox.Items.Add(item.اسم);
                }
            }
            this.fwteraml2combobox.IsEditable = true;
            this.fwteraml2combobox.IsTextSearchEnabled = true;
        }

        private void fwteraml2combobox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            fwteraml2combobox.IsDropDownOpen = true;
        }

        private void fwterRkmFtoraBtn_Click(object sender, RoutedEventArgs e)
        {
            
            // fwterDataGrid.ItemsSource = data.bnodDatas;
            using (var db = new Models.DataContext())
            {
                data.asm3mel = fwteraml2combobox.Text;
                fwaterListPage page = new fwaterListPage();

                double wzn = 0.0;
              bool? result =  page.ShowDialog();

                if (result == true)
                {
                    try
                    {


                        data.bnodDatas.Clear();
                        data.amrt48ElDatas.Clear();
                        fwterDate.Content = "";
                        fwterTslemDate.SelectedDate = null;
                        fwterRkmFtoraBtn.Content = "";
                        fwteraml2combobox.Text = "";
                        Total7sab.Content = null;
                        TotalWzn.Content = null;
                        totalFatoraLabel.Content = "0";
                        data.totalftora = 0;
                        fwterDataGrid.Items.Clear();
                        fwterDataGrid.Items.Refresh();



                    }
                    catch (Exception)
                    {


                    }
               

                fwterRkmFtoraBtn.Content = data.rkmftora;
                fwteraml2combobox.SelectedValue = db.عملاء.Where(x => x.كودعميل == db.فواتير.Where(y => y.رقم == data.rkmftora).Select(y => y.كودعميل).FirstOrDefault()).Select(x => x.اسم).FirstOrDefault();
                fwterDate.Content = db.فواتير.Where(x => x.رقم == data.rkmftora).Select(y => y.تاريخ_تشغيل).FirstOrDefault().ToString("dd/MM/yyyy");
                var items = db.امرتشغيل.Where(x => x.رقم == data.rkmftora).ToList();
                foreach (var item in items)
                {
                    data.bnodDatas.Add(new bnodFatora { المنتج = db.منتجات.Where(y => y.كودالخامة == item.كودالخامة && y.type == 'م').Select(y => y.الخامة).FirstOrDefault(), كمية = item.كمية, سعر_الوحدة = 0, الاجمالى = 0,كميةخامةالمستهلكة = item.كميةخامة });
                    wzn += item.كمية;
                }
                fwterDataGrid.ItemsSource = data.bnodDatas;
                fwterDataGrid.Items.Refresh();
                Total7sab.Content = db.عملاء.Where(x => x.كودعميل == db.فواتير.Where(y => y.رقم == data.rkmftora).Select(y => y.كودعميل).FirstOrDefault()).Select(x => x.حساب).FirstOrDefault();
                TotalWzn.Content = wzn;

                }

            }


        }

        private void fwter_Loaded(object sender, RoutedEventArgs e)
        {

            List<String> names = new List<string>();

           

            using (var db = new Models.DataContext())
            {
                foreach (var item in db.عملاء.Where(x => x.نوع == 'ع'))

                {

                    this.fwteraml2combobox.Items.Add(item.اسم);
                }

               
            }
            this.fwteraml2combobox.IsEditable = true;
            this.fwteraml2combobox.IsTextSearchEnabled = true;

        }

        private void fwterDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            var rows = this.fwterDataGrid.SelectedItem as bnodFatora;
            data.totalftora -= rows.الاجمالى;
            //data.bnodDatas = fwterDataGrid.Items as List<bnodFatora>; 
        }

        private void fwterDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                this.fwterDataGrid.CommitEdit();
                this.fwterDataGrid.Items.Refresh(); ;
            }));
  

        }
     
        private void fwterDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

            var row1 = this.fwterDataGrid.SelectedItem as bnodFatora;
            string name = row1.المنتج;
            double s3r = row1.سعر_الوحدة;
            double wzn = row1.كمية;
            double total = row1.الاجمالى;
         
            data.totalftora -= row1.الاجمالى;
          //  var y = e.Row.DataContext;
          //  var sd = e.Row;
            (sender as DataGrid).RowEditEnding -= fwterDataGrid_RowEditEnding;
            (sender as DataGrid).CommitEdit();
            (sender as DataGrid).Items.Refresh();
            (sender as DataGrid).RowEditEnding += fwterDataGrid_RowEditEnding;
            // rowBeingEdited.EndEdit();
            // DataRowView rowView = e.Row.Item as DataRowView;
            //foreach (var item in fwterDataGrid.Items)
            //{
            //    var y = item;

            //}
            row1 = null;
            row1 = this.fwterDataGrid.SelectedItem as bnodFatora;
            if (row1.المنتج!= name)
            {
                row1.المنتج = name;
            }
            if (row1.الاجمالى != total)
            {
                row1.الاجمالى = total;
            }
            if (row1.سعر_الوحدة != s3r)
            {
                row1.الاجمالى = row1.سعر_الوحدة * row1.كمية;
            }
            if (row1.كمية != wzn)
            {
                TotalWzn.Content = double.Parse(TotalWzn.Content.ToString()) + row1.كمية - wzn;
                row1.الاجمالى = row1.سعر_الوحدة * row1.كمية;
            }
           
          
            data.totalftora += row1.الاجمالى;
            row1 = null;
            totalFatoraLabel.Content = data.totalftora;
            TotalNew7sab.Content = (data.totalftora + double.Parse(Total7sab.Content.ToString())).ToString();
        }

        private void addFwterBtn_Click(object sender, RoutedEventArgs e)
        {
            بنود_الفاتورة bnd = new بنود_الفاتورة();
            using (var db = new Models.DataContext())
            {
                فواتير element = db.فواتير.Where(z => z.رقم == int.Parse(fwterRkmFtoraBtn.Content.ToString()) && z.نوع_فاتورة == 'ب').FirstOrDefault();
                امرتشغيل amr = new امرتشغيل();
                هالك hlk = new هالك();
                if (db.هالك.Where(z => z.شهر == element.تاريخ_تشغيل.Month && z.سنة == element.تاريخ_تشغيل.Year).Any())
                {
                    hlk = db.هالك.Where(z => z.شهر == element.تاريخ_تشغيل.Month && z.سنة == element.تاريخ_تشغيل.Year).FirstOrDefault();
                }
                else
                {
                    db.هالك.Add(new هالك {شهر = element.تاريخ_تشغيل.Month , سنة = element.تاريخ_تشغيل.Year ,اجمالى = 0 ,سادة = 0 , مطبوع =0});
                    db.SaveChanges();
                    hlk = db.هالك.Where(z => z.شهر == element.تاريخ_تشغيل.Month && z.سنة == element.تاريخ_تشغيل.Year).FirstOrDefault();
                }
                
                try
                {
                    element.تاريخ_تسليم = (DateTime)fwterTslemDate.SelectedDate;
                }
                catch (Exception)
                {
                    element.تاريخ_تسليم = DateTime.Now;


                }
                element.اجمالى_نقدى = decimal.Parse(totalFatoraLabel.Content.ToString());
                element.اجمالى_حساب = decimal.Parse(Total7sab.Content.ToString()) + element.اجمالى_نقدى;
                element.اجمالى_وزن = double.Parse(TotalWzn.Content.ToString());
                element.فاتورة = 'y';
                عميل emp = db.عملاء.Where(x => x.كودعميل == element.كودعميل).FirstOrDefault();
                emp.حساب += element.اجمالى_نقدى;
                int k = 1;
                foreach (var item in data.bnodDatas)
                {
                    bnd.number = k;
                    bnd.كودالمنتج = db.منتجات.Where(x => x.الخامة == item.المنتج && x.type == 'م').Select(y => y.كودالخامة).FirstOrDefault();
                    bnd.رقم = element.رقم;
                    bnd.كمية = item.كمية;
                    bnd.نوع_فاتورة = 'ب';
                    bnd.سعر_الوحدة = item.سعر_الوحدة;
                    bnd.الاجمالى = item.الاجمالى;
                    bnd.type = 'م';
                    amr = db.امرتشغيل.Where(z => z.كودالخامة == bnd.كودالمنتج && z.رقم == bnd.رقم && z.نوع_فاتورة == 'ب').FirstOrDefault();
                    amr.كميةخامة = item.كميةخامةالمستهلكة;
                    amr.كمية = item.كمية;
                    hlk.اجمالى += decimal.Parse(amr.كميةخامة )- decimal.Parse( amr.كمية.ToString())   ;
                    db.بنودفاتورة.Add(bnd);
                    db.SaveChanges();
                    k++;
                }
                var dates = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                var datesf = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day );
                try
                {
                     datesf = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);
                }
                catch (Exception)
                {

                     datesf = new DateTime(DateTime.Now.Year, DateTime.Now.Month+1, 1);
                }
                
                if (db.يوميات.Where(x => x.تاريخ >= dates && x.تاريخ < datesf).Any())
                {

                    db.يوميات.Add(new يوميات { كود = (db.يوميات.Where(x => x.تاريخ >= dates && x.تاريخ < datesf).Max(x => x.كود) + 1), تاريخ = DateTime.Today, مبلغ = 0, ملاحظات = "  فاتورة رقم  : " +element.رقم  + "  /  " + "اجمالى الفاتورة  : " + element.اجمالى_نقدى + "  /  " + "اجمالى الحساب : " + element.اجمالى_حساب, كودصاحب = element.كودعميل, كودحالة = db.حالات_يوميات.Where(y => y.حالة == "وارد").Select(y => y.كودحالة).FirstOrDefault(), flag = 'ع' });
                    
                }
                else
                {
                    db.يوميات.Add(new يوميات { كود = 1, تاريخ = DateTime.Today, مبلغ = 0, ملاحظات = "  فاتورة رقم  : " + element.رقم + "  /  " + "اجمالى الفاتورة  : " + element.اجمالى_نقدى + "  /  " + "اجمالى الحساب : " + element.اجمالى_حساب, كودصاحب = element.كودعميل, كودحالة = db.حالات_يوميات.Where(y => y.حالة == "وارد").Select(y => y.كودحالة).FirstOrDefault(), flag = 'ع' });
                   
                }

                
                db.SaveChanges();
            }
            
            data.bnodDatas.Clear();
            data.amrt48ElDatas.Clear();
            fwterDate.Content = "";
            fwterTslemDate.SelectedDate = null;
            fwterRkmFtoraBtn.Content = "";
            fwteraml2combobox.Text = "";
            fwterDataGrid.ItemsSource = null;
            Total7sab.Content = null;
            TotalNew7sab.Content = null;
            TotalWzn.Content = null;
            totalFatoraLabel.Content = null;
            data.totalftora = 0;
            fwterDataGrid.ItemsSource = data.bnodDatas;

        }


        // امر شراء 

        private void amr4r2Header_Clicked(object sender, MouseButtonEventArgs e)
        {
            this.Amr4e2aml2combobox.Items.Clear();

            using (var db = new Models.DataContext())
            {
                foreach (var item in db.عملاء.Where(x => x.نوع == 'م'))

                {

                    this.Amr4e2aml2combobox.Items.Add(item.اسم);
                }
            }
            this.Amr4e2aml2combobox.IsEditable = true;
            this.Amr4e2aml2combobox.IsTextSearchEnabled = true;
        }
        private void Amr4e2aml2combobox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Amr4e2aml2combobox.IsDropDownOpen = true;
        }
        private void amrsr2Date_Loaded(object sender, RoutedEventArgs e)
        {
            this.amr4r2Date.Content = DateTime.Now.ToString("dd/MM/yyyy");
        }


        private void amr4r2DataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            amr4r25matList amrt48El3Ml2 = new amr4r25matList();

            using (var db = new Models.DataContext())
            {
                try
                {
                    if (Amr4e2aml2combobox.Text != "")
                    {
                        amr4r2Total7sab.Content = db.عملاء.Where(x => x.اسم == Amr4e2aml2combobox.Text).Select(x => x.حساب).FirstOrDefault();
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("الرجاء ادخال اسم العميل", "خطاء فى اسم العميل ", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
               
                
            }

            bool? result = amrt48El3Ml2.ShowDialog();
           
            if (result == true)
            {
                data.amr4r2Datas.Add(new amr4r2DataGVM { رقم = amr4r2DataGrid.Items.Count + 1, الخامة = data.amr4r25ama, الكمية = 0 });
                
                this.amr4r2DataGrid.ItemsSource = null;
                this.amr4r2DataGrid.Items.Clear();
                this.amr4r2DataGrid.ItemsSource = data.amr4r2Datas;
            }

            else
            {
                
            }
        }
        private void amr4r2DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<amr4r2DataGVM> amrt48eldata = new List<amr4r2DataGVM>();

            this.amr4r2DataGrid.ItemsSource = null;
            this.amr4r2DataGrid.Items.Clear();

            this.amr4r2DataGrid.ItemsSource = amrt48eldata;

        }

        private void amr4r2dafaBtn_Click(object sender, RoutedEventArgs e)
        {

            using (var db = new Models.DataContext())
            {
                فواتير element = new فواتير();
                بنود_الفاتورة bnd = new بنود_الفاتورة();
                //ComboBoxItem typeItem = (ComboBoxItem)AmrT48elaml2combobox.SelectedItem;
                  try
                {



                    var y = Amr4e2aml2combobox.Text;
                    //string value = typeItem.Content.ToString();

                    element.تاريخ_تسليم = DateTime.Now ;
                    element.رقم = int.Parse(this.amr4r2kodLb.Text.ToString());

                    element.كودعميل = Convert.ToInt32(db.عملاء.Where(x => x.اسم == y).Select(x => x.كودعميل).FirstOrDefault());
                    element.نوع_فاتورة = 'ش';
                    element.فاتورة = 'y';
                    element.اجمالى_نقدى = decimal.Parse(Totalftora.Text);
                    element.اجمالى_حساب = element.اجمالى_نقدى + decimal.Parse(amr4r2Total7sab.Content.ToString());
                    element.اجمالى_وزن = double.Parse(amr4r2Totalwzn.Content.ToString());
                    db.فواتير.Add(element);
                    عميل emp = db.عملاء.Where(x => x.كودعميل == element.كودعميل).FirstOrDefault();
                    emp.حساب += element.اجمالى_نقدى;

                    foreach (var item in data.amr4r2Datas)
                    {

                        bnd.كودالمنتج = db.منتجات.Where(x => x.الخامة == item.الخامة && x.type == 'خ').Select(y => y.كودالخامة).FirstOrDefault();
                        bnd.رقم = element.رقم;
                        bnd.كمية = item.الكمية;
                        bnd.نوع_فاتورة = 'ش';
                        bnd.سعر_الوحدة = 0;
                        bnd.الاجمالى = 0;
                        bnd.type = 'خ';
                        db.بنودفاتورة.Add(bnd);
                        db.SaveChanges();


                    }


                    
                }
                        catch (Exception)
                {

                            MessageBox.Show("املاء الفراغات","خطاء فى عمليه الادخال ",MessageBoxButton.OK,MessageBoxImage.Error);
                }


                var dates = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                var datesf = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                try
                {
                    datesf = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);
                }
                catch (Exception)
                {

                    datesf = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1);
                }
                if (db.يوميات.Where(x => x.تاريخ >= dates && x.تاريخ < datesf).Any())
                {

                    db.يوميات.Add(new يوميات { كود = (db.يوميات.Where(x => x.تاريخ >= dates && x.تاريخ < datesf).Max(x => x.كود) + 1), تاريخ = DateTime.Today, مبلغ = 0, ملاحظات = "  امر شراء رقم  : " + element.رقم + "  /  " + "اجمالى الفاتورة  : " + element.اجمالى_نقدى + "  /  " + "اجمالى الحساب : " + element.اجمالى_حساب, كودصاحب = element.كودعميل, كودحالة = db.حالات_يوميات.Where(y => y.حالة == "مصاريف").Select(y => y.كودحالة).FirstOrDefault(), flag = 'م' });

                }
                else
                {
                    db.يوميات.Add(new يوميات { كود = 1, تاريخ = DateTime.Today, مبلغ = 0, ملاحظات = " امر شراء رقم  : " + element.رقم + "  /  " + "اجمالى الفاتورة  : " + element.اجمالى_نقدى + "  /  " + "اجمالى الحساب : " + element.اجمالى_حساب, كودصاحب = element.كودعميل, كودحالة = db.حالات_يوميات.Where(y => y.حالة == "مصاريف").Select(y => y.كودحالة).FirstOrDefault(), flag = 'م' });

                }


            }
            amr4r2Date.Content = DateTime.Now.ToString("dd/MM/yyyy");
            amr4r2kodLb.Text = null;
            Amr4e2aml2combobox.Text = "";
            amr4r2DataGrid.ItemsSource = null;
            amr4r2DataGrid.Items.Clear();
            Totalftora.Text = null;
            amr4r2Totalwzn.Content = null;
            amr4r2Total7sab.Content = null;
            
            data.amr4r2Datas.Clear();
            this.amrt48elDataGrid.ItemsSource = data.amr4r2Datas;


        }



        private void amr4r2DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                this.amr4r2DataGrid.CommitEdit();
                this.amr4r2DataGrid.Items.Refresh(); ;
            }));


        }


        private void amr4r2DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

            var row1 = this.amr4r2DataGrid.SelectedItem as amr4r2DataGVM;
            string name = row1.الخامة;
            
            double wzn = row1.الكمية;
            
            
            (sender as DataGrid).RowEditEnding -= amr4r2DataGrid_RowEditEnding;
            (sender as DataGrid).CommitEdit();
            (sender as DataGrid).Items.Refresh();
            (sender as DataGrid).RowEditEnding += amr4r2DataGrid_RowEditEnding;
            
            var rows = this.amr4r2DataGrid.SelectedItem as amr4r2DataGVM;
            if (rows.الخامة != name)
            {
                rows.الخامة = name;
            }
           
            if (rows.الكمية != wzn)
            {
                amr4r2Totalwzn.Content = double.Parse(amr4r2Totalwzn.Content.ToString()) + rows.الكمية - wzn;
               
            }
            
          
        }

        private void amr4r2_Loaded(object sender, RoutedEventArgs e)
        {
            this.Amr4e2aml2combobox.Items.Clear();

            using (var db = new Models.DataContext())
            {
                foreach (var item in db.عملاء.Where(x => x.نوع == 'م'))

                {

                    this.Amr4e2aml2combobox.Items.Add(item.اسم);
                }
            }
            this.Amr4e2aml2combobox.IsEditable = true;
            this.Amr4e2aml2combobox.IsTextSearchEnabled = true;
        }

       
       

        private void amr4r2ListBTN_Click(object sender, RoutedEventArgs e)
        {
            amr4r2ListPage page = new amr4r2ListPage();
            page.ShowDialog();

        }

        

       

        private void _3ml2Datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           

            var rows = this._3ml2Datagrid.SelectedItem as aml2DataGVM;
                if (rows == null)
                {
                    return;
                }
            data.asmmwzf = rows.اسم;
            aml2DetailsPage page = new aml2DetailsPage();
             page.ShowDialog();
           
                ref3ml2dataG();
           

        }

        // موردين 

        private void mwrdenDatagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var rows = this.mwrdenDatagrid.SelectedItem as mwrdenDataGVM;

            if (rows == null)
            {
                return;
            }
            data.asmmwzf = rows.اسم;
            mwrdenDetailsPage page = new mwrdenDetailsPage();
            page.ShowDialog();

        }
             // خزنة
        private void shekatTabListBtn_Click(object sender, RoutedEventArgs e)
        {
            shekatListPage shekatList = new shekatListPage();
            shekatList.ShowDialog();
            ref5zna();

        }


        private void ref5zna()
        {


            using (var db = new Models.DataContext())
            {
                الخزنة data = db.خزنة.FirstOrDefault();
                if (data == null)
                {

                    db.خزنة.Add(new الخزنة { اجمالى = 0, حساب = 0, دائن = 0, شيكات = 0, مدين = 0, نقدى = 0, رقم = '1',password="123" });
                    db.SaveChanges();

                }
                data = db.خزنة.FirstOrDefault();


                cash.Content = data.نقدى;
                mden.Content = data.مدين;
                d2n.Content = data.دائن;
                total.Content = data.اجمالى;
                cash4ekat.Content = data.شيكات;
                cash7sab.Content = data.حساب;
            }
        }

        private void t7welatDa5lya_Click(object sender, RoutedEventArgs e)
        {
            t7welNkdyPage page = new t7welNkdyPage();
            bool? x = page.ShowDialog();
            if (x == true)
            {
                ref5zna();
            }

        }



        private void mwzfen8yabBtn_Click(object sender, RoutedEventArgs e)
        {
            password Page = new password();
            bool? result = Page.ShowDialog();
            if (result == true) {
                mwzfen8yabPage mwzfen8Yab = new mwzfen8yabPage();
            mwzfen8Yab.ShowDialog();
        }  else { 
                Xceed.Wpf.Toolkit.MessageBox.Show("الرجاء ادخال كلمة المرور لتتمكن من الوصول الى هذه النافذة ", "كلمة مرور", MessageBoxButton.OK, MessageBoxImage.Error);
              //    Home page = new Home();
              //  page.Show();         
                this.Close();
        }

}

        private void Empdatagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var rows = this.Empdatagrid.SelectedItem as EmpDataGVM;
            if (rows == null)
            {
                return;
            }
            data.kodemwzf = rows.كودموظف;
            EmpDetilsPage page = new EmpDetilsPage();
            page.ShowDialog();
        }

        private void AddywmyaBTN_Click(object sender, RoutedEventArgs e)
        {
            password Page = new password();
            bool? result = Page.ShowDialog();
            if (result == true)
            {
                addywmya page = new addywmya();
                page.ShowDialog();
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("الرجاء ادخال كلمة المرور لتتمكن من الوصول الى هذه النافذة ", "كلمة مرور", MessageBoxButton.OK, MessageBoxImage.Error);
              //  Home page = new Home();
              //  page.Show();
                this.Close();
            }
        }

        private void sglYwmyatBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            
            sglywmyat page = new sglywmyat();
            page.ShowDialog();
            }
            catch (Exception)
            {

                
            }
        }

        private void t7welatDa5lyaSglBtn_Click(object sender, RoutedEventArgs e)
        {
            SglT7welatPage page = new SglT7welatPage();
            page.ShowDialog();
        }

        private void halkDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            halkDeletePage page = new halkDeletePage();
            page.ShowDialog();
        }

        private void m5zn2nwa35amatBtn_Click(object sender, RoutedEventArgs e)
        {
            m5zn2nw35amatHomePage page = new m5zn2nw35amatHomePage();
            page.ShowDialog();
        }

        private void m5zn2znsrfBtn_Click(object sender, RoutedEventArgs e)
        {
            m5zn2znsrfHomePage page = new m5zn2znsrfHomePage();
            page.ShowDialog();
        }

        private void fwterListPageBtn_Click(object sender, RoutedEventArgs e)
        {
            FWaterListP fwater48elListPage = new FWaterListP();
            fwater48elListPage.ShowDialog();
        }


















        /*   public void tr()
{
fwterDataGrid.Items.Refresh();
foreach (var item in fwterDataGrid.Items)
{
var y = item;

}



}   */


    }


    public static class data { 
    
           public static string mntg2mrt48el { get; set; }
        public static string amr4r25ama{ get; set; }
        public static List<amrt48elDataGVM> amrt48ElDatas = new List<amrt48elDataGVM>();
        public static List<bnodFatora> bnodDatas = new List<bnodFatora>();
        public static List<amr4r2DataGVM> amr4r2Datas = new List<amr4r2DataGVM>();
        public static shekatDataGVM shekelement = new shekatDataGVM();
        public static int rkmftora { get; set; }
        public static int kodemwzf { get; set; }
        public static int k4f7sabId { get; set; }
        public static char no3MntgMdaf { get; set; }
        public static int randomVal { get; set; }
        public static string asm3mel { get; set; }
        public static string asmmwzf { get; set; }

        public static double totalftora = 0; 
    }
}                   
