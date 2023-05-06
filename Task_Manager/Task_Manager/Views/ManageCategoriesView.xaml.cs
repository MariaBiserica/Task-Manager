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
using System.Windows.Shapes;
using Task_Manager.Models;
using Task_Manager.ViewModels;

namespace Task_Manager.Views
{
    /// <summary>
    /// Interaction logic for ManageCategoriesView.xaml
    /// </summary>
    public partial class ManageCategoriesView : Window
    {
        private TaskCategoryVM taskCategory;
        public ManageCategoriesView()
        {
            InitializeComponent();

            // create instance of TaskCategoryVM and set as DataContext
            taskCategory = new TaskCategoryVM();
            DataContext = taskCategory;
        }
    }
}
