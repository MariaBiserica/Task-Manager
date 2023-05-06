using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Task_Manager.Core;
using Task_Manager.Models;

namespace Task_Manager.ViewModels
{
    public class TaskCategoryVM : ObservableObject
    {
        private static readonly Lazy<TaskCategoryVM> lazyInstance =
        new Lazy<TaskCategoryVM>(() => new TaskCategoryVM());

        public static TaskCategoryVM Instance => lazyInstance.Value;

        public TaskCategoryVM()
        {
            SelectedCategory = "";
            //Categories = new ObservableCollection<TaskCategory>();
            //Categories.Add(TaskCategory.Work);
            //Categories.Add(TaskCategory.School);
            //Categories.Add(TaskCategory.Home);
            //Categories.Add(TaskCategory.Other);
        }

        private static ObservableCollection<TaskCategory> _categories = new ObservableCollection<TaskCategory>()
        {
            TaskCategory.Work,
            TaskCategory.School,
            TaskCategory.Home,
            TaskCategory.Other
        };

        public static ObservableCollection<TaskCategory> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                NotifyStaticPropertyChanged(nameof(Categories));
            }
        }

        //private ObservableCollection<TaskCategory> _categories;
        //public ObservableCollection<TaskCategory> Categories
        //{
        //    get { return _categories; }
        //    set
        //    {
        //        _categories = value;
        //        NotifyPropertyChanged(nameof(Categories));
        //    }
        //}

        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                NotifyPropertyChanged(nameof(SelectedCategory));
            }
        }

        public ICommand AddCategoryCommand => new RelayCommand(AddCategory);
        public ICommand RemoveCategoryCommand => new RelayCommand(RemoveCategory);
        public ICommand ModifyCategoryCommand => new RelayCommand(ModifyCategory);
        public ICommand ViewCategoriesCommand => new RelayCommand(ViewCategories);

        private void AddCategory(object parameter)
        {
            if (parameter is string categoryName)
            {
                TaskCategory newCategory = new TaskCategory(categoryName);
                Categories.Add(newCategory);
                MessageBox.Show("Category added successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void RemoveCategory(object parameter)
        {
            if (parameter is string categoryName)
            {
                TaskCategory categoryToRemove = Categories.FirstOrDefault(c => c.Name == categoryName);
                if (categoryToRemove != null)
                {
                    Categories.Remove(categoryToRemove);
                }
                else
                {
                    MessageBox.Show("There's no such category!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ModifyCategory(object parameter)
        {
            if (parameter is string categoryName)
            {
                TaskCategory categoryToModify = Categories.FirstOrDefault(c => c.Name == categoryName);
                if (categoryToModify != null)
                {
                    categoryToModify.Name = Interaction.InputBox("Enter the new name of the category:", "Modify Category");
                }
                else
                {
                    MessageBox.Show("There's no such category!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ViewCategories(object parameter)
        {
            StringBuilder sb = new StringBuilder();
            foreach (TaskCategory category in Categories)
            {
                sb.AppendLine(category.Name);
            }
            System.Windows.MessageBox.Show(sb.ToString());
        }
    }
}