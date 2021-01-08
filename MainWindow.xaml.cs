using ElAhram.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfInitApp.Services;
using WpfInitApp.Models;

namespace ElAhram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private readonly ISampleService sampleService;
        private readonly AppSettings settings;
        private readonly DataContext dataContext = new Models.DataContext();

        public MainWindow(ISampleService sampleService,
            IOptions<AppSettings> settings,DataContext dataContext)
        {
           
            this.sampleService = sampleService;
            this.settings = settings.Value;
            this.dataContext = dataContext;
            InitializeComponent();

          

        }
        public MainWindow()
        {
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            using (var db = new Models.DataContext())
            {

                try
            {

                    var user = db.user.FirstOrDefault();
                    if (userbox.Text == user.name && passbox.Password == user.password)
                    {
                        Home h = new Home();
                        h.Show();
                        this.Hide();
                    }
                    else
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("اسم المستخدم او كلمة المرور خطاء", "تسجيل الدخول", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
               
            }
            catch (Exception)
            {

               db.user.Add(new User { name = "fox", password = "99" });
                    db.SaveChanges();
            }
            }

        }
    }
}
