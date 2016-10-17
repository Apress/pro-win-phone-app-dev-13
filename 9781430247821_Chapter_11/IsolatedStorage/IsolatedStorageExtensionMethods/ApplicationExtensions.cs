using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Xml.Serialization;

namespace IsolatedStorageExtensionMethods
{
    public static class ApplicationExtensions
    {
        public static void Save<T>(this Application application, T obj)
        {
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                string path = typeof(T).Name + ".xml";
                using (IsolatedStorageFileStream stream =
                new IsolatedStorageFileStream(path, FileMode.Create, FileAccess.Write, store))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(stream, obj);
                }
            }
        }

        public static T Load<T>(this Application application) where T : new()
        {
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                string path = typeof(T).Name + ".xml";
                if (store.FileExists(path))
                {
                    using (IsolatedStorageFileStream stream =
                    new IsolatedStorageFileStream(path, FileMode.Open, FileAccess.Read, store))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        return (T)serializer.Deserialize(stream);
                    }
                }
                else
                {
                    return new T();
                }
            }
        }
    }
}
