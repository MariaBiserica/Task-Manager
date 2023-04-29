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

        public DataModel LoadDataModel(string fileName)
        {
            DataModel dataModel;
            XmlSerializer serializer = new XmlSerializer(typeof(DataModel));
            try
            {
                using (var stream = new FileStream(fileName, FileMode.Open))
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

        public void SaveDataModel(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataModel));
            try
            {
                using (var stream = new FileStream(fileName, FileMode.Create))
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
}
