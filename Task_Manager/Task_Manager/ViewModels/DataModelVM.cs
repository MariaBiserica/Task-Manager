using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using Task_Manager.Models;

namespace Task_Manager.ViewModels
{
    public class DataModelVM
    {
        public ObservableCollection<TDL> ItemsCollection { get; set; }

        //public DataModelVM()
        //{
        //    var dataModel = LoadDataModel();
        //    ItemsCollection = new ObservableCollection<TDL>(dataModel.ItemsCollection);
        //}

        public DataModel LoadDataModel()
        {
            DataModel dataModel;
            XmlSerializer serializer = new XmlSerializer(typeof(DataModel));
            try
            {
                using (var stream = new FileStream("data.xml", FileMode.Open))
                {
                    dataModel = (DataModel)serializer.Deserialize(stream);
                    ItemsCollection = new ObservableCollection<TDL>(dataModel.ItemsCollection);
                }
                MessageBox.Show("Data loaded successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (FileNotFoundException ex)
            {
                dataModel = new DataModel();
            }
            return dataModel;
        }

        public void SaveDataModel()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataModel));
            try
            {
                using (var stream = new FileStream("data.xml", FileMode.Create))
                {
                    serializer.Serialize(stream, new DataModel { ItemsCollection = new ObservableCollection<TDL>(ItemsCollection.ToList()) });
                }
                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"An error occurred while saving data. Error message: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    //var1
        //public ObservableCollection<TDL> ItemsCollection { get; set; }

        //public DataModelVM()
        //{
        //    ItemsCollection = new ObservableCollection<TDL>();
        //    ItemsCollection.Add(new TDL
        //    {
        //        Name = "a",
        //        SubCollection = new ObservableCollection<TDL>()
        //        {
        //            new TDL { Name = "b", SubCollection = new ObservableCollection<TDL>()
        //            {
        //                new TDL() { Name = "d", SubCollection = new ObservableCollection<TDL>() },
        //                new TDL() { Name = "e", SubCollection = new ObservableCollection<TDL>() }
        //            }
        //            },
        //            new TDL { Name = "c", SubCollection = new ObservableCollection<TDL>()
        //            {
        //                new TDL() { Name = "f", SubCollection = new ObservableCollection<TDL>() },
        //                new TDL() { Name = "g", SubCollection = new ObservableCollection<TDL>() }
        //            }
        //            }
        //        }
        //    });
        //    ItemsCollection.Add(new TDL()
        //    {
        //        Name = "h",
        //        SubCollection = new ObservableCollection<TDL>()
        //        {
        //            new TDL { Name = "i", SubCollection = new ObservableCollection<TDL>()
        //            {
        //                new TDL() { Name = "j", SubCollection = new ObservableCollection<TDL>() }
        //            }
        //            }
        //        }
        //    });
        //}

    
    //var2
        //    private readonly DataModel _dataModel;

        //    public ObservableCollection<TDL> ItemsCollection => _dataModel.ItemsCollection;

        //    public DataModelVM(DataModel dataModel)
        //    {
        //        _dataModel = dataModel;
        //    }

        //    public void SaveData(string filePath)
        //    {
        //        try
        //        {
        //            var serializer = new XmlSerializer(typeof(ObservableCollection<TDL>));

        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                serializer.Serialize(stream, ItemsCollection);
        //            }

        //            MessageBox.Show("Data saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        //        }
        //        catch (IOException ex)
        //        {
        //            MessageBox.Show($"An error occurred while saving data. Error message: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }

        //    public void LoadData(string filePath)
        //    {
        //        try
        //        {
        //            var serializer = new XmlSerializer(typeof(ObservableCollection<TDL>));

        //            using (var stream = new FileStream(filePath, FileMode.Open))
        //            {
        //                ItemsCollection = (ObservableCollection<TDL>)serializer.Deserialize(stream);
        //            }

        //            MessageBox.Show("Data loaded successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        //        }
        //        catch (IOException ex)
        //        {
        //            MessageBox.Show($"An error occurred while loading data. Error message: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //}
}
