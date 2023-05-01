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
using System.Windows.Controls.Primitives;
using Task_Manager.Models;
using Task_Manager.ViewModels;
using Task = Task_Manager.Models.Task;

namespace Task_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private TreeViewVM treeViewVM;
        public MainView()
        {
            InitializeComponent();

            // create instance of TreeViewVM and set as DataContext
            treeViewVM = new TreeViewVM();
            DataContext = treeViewVM;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // get selected TDL from TreeView.SelectedItem
            TDL selectedTDL = (TDL)treeView.SelectedItem;

            // set SelectedTDL property in TreeViewVM
            if (selectedTDL != null)
            {
                treeViewVM.SelectedTDL = selectedTDL;
                treeViewVM.SelectedTDLName = "Viewing '" + selectedTDL.Name + "' to do list.";
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is Task selectedTask)
            {
                treeViewVM.SelectedTask = selectedTask;
            }
        }
    }
}
