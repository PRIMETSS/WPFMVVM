using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPFMVVM.ViewModels.Commands;

namespace WPFMVVM.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        // Name to add to the Names List
        private string _nameToAdd;
        public string NameToAdd
        {
            get => _nameToAdd;
            set => SetProperty(ref _nameToAdd, value);
        }

        // List of string Names
        private ObservableCollection<string> _namesList;
        public ObservableCollection<string> NamesList
        {
            get => _namesList;
            set => SetProperty(ref _namesList, value);
        }

        public MainPageViewModel()
        {
            _namesList = new ObservableCollection<string>();
            _addNameCommand = new DelegateCommand(OnAddName);
        }


        // Commands
        private readonly DelegateCommand _addNameCommand;
        public ICommand AddNameCommand => _addNameCommand;

        private void OnAddName(object commandParameter)
        {
            NamesList.Add($"CommandParameter: {(string)commandParameter.ToString()}");
        }
    }
}
