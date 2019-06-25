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

namespace WPFMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModels.MainPageViewModel mainPageViewModel;

        public MainWindow()
        {
            // Initalise ViewModel
            mainPageViewModel = new ViewModels.MainPageViewModel();
            mainPageViewModel.NameToAdd = "before";
            mainPageViewModel.NamesList.Add("Added via Constructor");

            // Assign Model to Windows Data Context
            DataContext = mainPageViewModel;

            InitializeComponent();

            // Test to see if OnPropertyChanged() is fired when proerty value changed in viewmodel
            mainPageViewModel.NameToAdd = "after";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Using Model associated with MainWindow Object           
            mainPageViewModel.NamesList.Add($"ViaButtonClick: {mainPageViewModel.NameToAdd}");

            // Trial of using Window.Resources as initialising ViewModel here makes intellisense work better in XAML?
            ViewModels.MainPageViewModel model = (ViewModels.MainPageViewModel)Resources["model"];           
            model.NamesList.Add($"ViaResourceViewModel: {model.NameToAdd}");
        }
    }
}
