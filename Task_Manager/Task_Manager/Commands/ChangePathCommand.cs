using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System;
using Task_Manager.Models;
using Task_Manager.ViewModels;
using Task = System.Threading.Tasks.Task;
using System.Linq;

public class ChangePathCommand : ICommand
{
    private readonly MainViewVM _viewModel;
    private bool _timerElapsed;

    public ChangePathCommand(MainViewVM viewModel)
    {
        _viewModel = viewModel;
        _timerElapsed = false;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        if (_viewModel.SelectedTDL == null) return;

        // Save the current selected TDL
        var selectedTDL = _viewModel.SelectedTDL;

        // Check if selectedTDL is part of ItemsCollection
        var tdlCollection = GetTDLCollection(selectedTDL);
        if (tdlCollection != _viewModel.Data.ItemsCollection)
        {
            // Ask user if they want to move the TDL to the ItemsCollection
            var result = MessageBox.Show("The selected TDL is not part of the ItemsCollection. Do you want to move it there?", "Change Path", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _viewModel.Data.ItemsCollection.Add(selectedTDL);
                tdlCollection.Remove(selectedTDL);
                _viewModel.NotifyPropertyChanged("ItemsCollection");
                return;
            }
            else if (result == MessageBoxResult.Cancel)
            {
                return;
            }
        }

        // Get the name of the destination TDL from the user
        var destinationTDLName = GetDestinationTDLName();

        // Find the destination TDL
        var destinationTDL = FindTDLByName(destinationTDLName);
        
        if (destinationTDL != null)
        {
            // Check if selectedTDL is already in destinationTDL's SubCollection
            if (destinationTDL.SubCollection.Contains(selectedTDL))
            {
                MessageBox.Show("The TDL is already a subtask of the destination TDL.", "Change Path Error");
                return;
            }

            // Remove selectedTDL from its current location
            tdlCollection.Remove(selectedTDL);

            // Add selectedTDL to the destinationTDL's SubCollection
            destinationTDL.SubCollection.Add(selectedTDL);

            _viewModel.NotifyPropertyChanged("ItemsCollection");
        }

        _timerElapsed = false;
    }
    private string GetDestinationTDLName()
    {
        var prompt = "Enter the name of the destination TDL:";
        var title = "Change Path";
        var defaultResponse = "";
        return Microsoft.VisualBasic.Interaction.InputBox(prompt, title, defaultResponse);
    }

    private TDL FindTDLByName(string name)
    {
        // Search for the TDL in the ItemsCollection
        var tdl = _viewModel.Data.ItemsCollection.FirstOrDefault(x => x.Name == name);

        if (tdl == null)
        {
            // Search for the TDL in the SubCollections
            foreach (var item in _viewModel.Data.ItemsCollection)
            {
                tdl = SearchSubCollections(item.SubCollection, name);
                if (tdl != null) break;
            }
        }

        return tdl;
    }

    private TDL SearchSubCollections(ObservableCollection<TDL> subCollection, string name)
    {
        foreach (var item in subCollection)
        {
            if (item.Name == name)
            {
                return item;
            }

            var result = SearchSubCollections(item.SubCollection, name);
            if (result != null) return result;
        }

        return null;
    }

    private ObservableCollection<TDL> GetTDLCollection(TDL tdl)
    {
        // Check if selectedTDL is in the ItemsCollection
        if (_viewModel.Data.ItemsCollection.Contains(tdl))
        {
            return _viewModel.Data.ItemsCollection;
        }

        // Search all SubCollections
        foreach (var item in _viewModel.Data.ItemsCollection)
        {
            var result = SearchSubCollections(item.SubCollection, tdl);
            if (result != null) return result;
        }

        return null;
    }

    private ObservableCollection<TDL> SearchSubCollections(ObservableCollection<TDL> subCollection, TDL tdl)
    {
        // Check if selectedTDL is in the SubCollection
        if (subCollection.Contains(tdl))
        {
            return subCollection;
        }

        // Search all SubCollections
        foreach (var item in subCollection)
        {
            var result = SearchSubCollections(item.SubCollection, tdl);
            if (result != null) return result;
        }

        return null;
    }

    public event EventHandler CanExecuteChanged;
}
