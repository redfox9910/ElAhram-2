using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using ElAhram.ViewmModels.fwter;

namespace CustomDocumentPaginator
{
    public class MainWindowViewModel : BaseViewModel
    {
      public  string documentTitle { get; set; }
        public fwterDataGVM fwterData { get; set; } //= new fwterDataGVM();
        public string printType{ get; set; }

        public DataGrid gridData { get; set; }
        public MainWindowViewModel(string title)
        {
            /* List<PersonViewModel> people = new List<PersonViewModel>();

             for (int i = 0; i < 10; i++)
             {
                 people.Add(new PersonViewModel("Peter Jones", "High Road to Nowhere", true));
                 people.Add(new PersonViewModel("Scott James", "Low Road to Everywhere", true));
                 people.Add(new PersonViewModel("Michael Marks", "Somewhere in chesterfield", true));
                 people.Add(new PersonViewModel("Rich Blair", "Miserville", false));
                 people.Add(new PersonViewModel("David Smith", "Happy land", true));
                 people.Add(new PersonViewModel("Adam Johnson", "On yer bike", false));
                 people.Add(new PersonViewModel("Rob Hood", "The Manor", true));
             }

             this.People = new ObservableCollection<PersonViewModel>(people); */
            this.documentTitle = title;
            this.PrintCommand = new DelegateCommand(this.PrintGrid);
        }
        public MainWindowViewModel(string title, fwterDataGVM fwterDatae, string type)
        {
            /* List<PersonViewModel> people = new List<PersonViewModel>();

             for (int i = 0; i < 10; i++)
             {
                 people.Add(new PersonViewModel("Peter Jones", "High Road to Nowhere", true));
                 people.Add(new PersonViewModel("Scott James", "Low Road to Everywhere", true));
                 people.Add(new PersonViewModel("Michael Marks", "Somewhere in chesterfield", true));
                 people.Add(new PersonViewModel("Rich Blair", "Miserville", false));
                 people.Add(new PersonViewModel("David Smith", "Happy land", true));
                 people.Add(new PersonViewModel("Adam Johnson", "On yer bike", false));
                 people.Add(new PersonViewModel("Rob Hood", "The Manor", true));
             }

             this.People = new ObservableCollection<PersonViewModel>(people); */
            printType = type;
            this.documentTitle = title;
            fwterData = fwterDatae;
            this.PrintCommand = new DelegateCommand(this.PrintGrid);
        }


        public MainWindowViewModel(DataGrid grid,string title, fwterDataGVM fwterDatae, string type)
        {
            /* List<PersonViewModel> people = new List<PersonViewModel>();

             for (int i = 0; i < 10; i++)
             {
                 people.Add(new PersonViewModel("Peter Jones", "High Road to Nowhere", true));
                 people.Add(new PersonViewModel("Scott James", "Low Road to Everywhere", true));
                 people.Add(new PersonViewModel("Michael Marks", "Somewhere in chesterfield", true));
                 people.Add(new PersonViewModel("Rich Blair", "Miserville", false));
                 people.Add(new PersonViewModel("David Smith", "Happy land", true));
                 people.Add(new PersonViewModel("Adam Johnson", "On yer bike", false));
                 people.Add(new PersonViewModel("Rob Hood", "The Manor", true));
             }

             this.People = new ObservableCollection<PersonViewModel>(people); */

            gridData = grid;
            printType = type;
            this.documentTitle = title;
            fwterData = fwterDatae;
            this.PrintCommand = new DelegateCommand(PrintGridwithout);
        }

        //  public ObservableCollection<PersonViewModel> People { get; set; }

        public ICommand PrintCommand { get; private set; }

        public void PrintGrid(object param)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == false)
                return;


            Size pageSize = new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);

            CustomDataGridDocumentPaginator paginator = new CustomDataGridDocumentPaginator(param as DataGrid, documentTitle, pageSize, new Thickness(30, 20, 30, 20), fwterData, printType);
            printDialog.PrintDocument(paginator, "Grid");
        }



        public void PrintGridwithout(object param)
        {

             param = gridData;
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == false)
                return;


            Size pageSize = new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);

            CustomDataGridDocumentPaginator paginator = new CustomDataGridDocumentPaginator(param as DataGrid, documentTitle, pageSize, new Thickness(30, 20, 30, 20), fwterData, printType);
            printDialog.PrintDocument(paginator, "Grid");
        }

    }
}
