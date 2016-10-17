using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using Windows.Storage;

namespace SerializationToLocalStorage
{
    public static class ApplicationExtensions
    {
        public static void Save<T>(this Application application, T obj)
        {
            string fileName = typeof(T).Name + ".xml"; 
            using (var stream = ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(fileName,
                CreationCollisionOption.ReplaceExisting).Result)
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, obj);
            }
        }

        public static async Task<T> Load<T>(this Application application)
        {
            T obj = default(T);
            string fileName = typeof(T).Name + ".xml"; 
            try
            {
                var localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                using (var stream = await localFile.OpenStreamForReadAsync())
                {
                    if (stream.Length > 0)
                    {
                        var serializer = new XmlSerializer(typeof(T));
                        obj = (T)serializer.Deserialize(stream);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine(fileName + " not found");
            }
            return obj;
        }
    }
}
