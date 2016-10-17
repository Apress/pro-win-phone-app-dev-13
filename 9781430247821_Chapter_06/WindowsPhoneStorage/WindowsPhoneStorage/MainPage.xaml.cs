using System;
using System.IO;
using System.Windows;
using Microsoft.Phone.Controls;
using Windows.Storage;

namespace WindowsPhoneStorage
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SaveButton_Click_1(object sender, EventArgs e)
        {
            // get the instance of the local folder
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            // create a file in the local folder
            StorageFile localFile = await localFolder.CreateFileAsync("MyData", CreationCollisionOption.ReplaceExisting);

            // open the file for writing and write to the file
            using (Stream stream = await localFile.OpenStreamForWriteAsync())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    await writer.WriteAsync(DataTextBox.Text);
                }
            }

        }

        private async void LoadButton_Click_1(object sender, EventArgs e)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            try
            {
                StorageFile localFile = await localFolder.GetFileAsync("MyData"); ;
                Stream stream = await localFile.OpenStreamForReadAsync();
                using (StreamReader reader = new StreamReader(stream))
                {
                    DataTextBox.Text = await reader.ReadToEndAsync();
                }
            }
            catch (FileNotFoundException ex)
            {
                // handle file not found condition based on your requirements
            }
        }

    }
}