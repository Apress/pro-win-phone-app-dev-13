using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows;
using System.Xml.Serialization;
using Microsoft.Phone.Controls;

namespace XMLSerializer
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //SerializeWith_XmlSerializer();
            //SerializeWith_DataContractSerializer();
            SerializeWith_DataContractJsonSerializer();
        }

        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            //DeserializeWith_XmlSerializer();
            //DeserializeWith_DataContractSerializer();
            DeserializeWith_DataContractJsonSerializer();
        }

        #region DataContractJsonSerializer

        private void SerializeWith_DataContractJsonSerializer()
        {
            Person person = new Person()
            {
                FirstName = FirstNameTextbox.Text,
                LastName = LastNameTextbox.Text
            };

            // serialize the object to Json form
            var serializer = new DataContractJsonSerializer(typeof(Person));
            var stream = new MemoryStream();
            serializer.WriteObject(stream, person);

            // write the Json out to a textbox
            stream.Position = 0;
            var reader = new StreamReader(stream);
            SerializedTextBox.Text = reader.ReadToEnd();
            stream.Dispose(); 
        }

        private void DeserializeWith_DataContractJsonSerializer()
        {
            var serializer = new DataContractJsonSerializer(typeof(Person));
            // re-hydrate the Person object from the Json text
            // place the XML text into a stream
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(SerializedTextBox.Text));
            // deserialize the stream containing JSON to the Person object
            var person = serializer.ReadObject(stream) as Person;
            // Display the reconstituded object in the text boxes
            FirstNameTextbox.Text = person.FirstName;
            LastNameTextbox.Text = person.LastName;
            stream.Dispose(); 
        }


        #endregion

        #region DataContractSerializer
        private void SerializeWith_DataContractSerializer()
        {
            // Create the Person object with user data
            var person =
                new ContractPerson()
                {
                    FirstName = FirstNameTextbox.Text,
                    LastName = LastNameTextbox.Text
                };

            // create an DataContractSerializer( for the Person type
            var serializer = new DataContractSerializer(typeof(ContractPerson));
            // serialize the Person object to XML stored in a stream
            var stream = new MemoryStream();
            serializer.WriteObject(stream, person);
            // extract the XML and display in the textbox
            stream.Position = 0;
            var reader = new StreamReader(stream);
            SerializedTextBox.Text = reader.ReadToEnd();
        }

        private void DeserializeWith_DataContractSerializer()
        {
            // create the DataContractSerializer for the Person type
            var serializer = new DataContractSerializer(typeof(ContractPerson));
            // place the XML text into a stream
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(SerializedTextBox.Text));
            // deserialize the stream containing XML to the Person object
            var person = serializer.ReadObject(stream) as ContractPerson;
            // Display the reconstituded object in the text boxes
            FirstNameTextbox.Text = person.FirstName;
            LastNameTextbox.Text = person.LastName;
        }

        #endregion

        #region XmlSerializer
        private void SerializeWith_XmlSerializer()
        {
            // Create the Person object with user data
            var person =
                new Person()
                {
                    FirstName = FirstNameTextbox.Text,
                    LastName = LastNameTextbox.Text
                };

            // create an XmlSerializer for the Person type
            var serializer = new XmlSerializer(typeof(Person));
            // serialize the Person object to XML stored in a stream
            var stream = new MemoryStream();
            serializer.Serialize(stream, person);
            // extract the XML and display in the textbox
            stream.Position = 0;
            var reader = new StreamReader(stream);
            SerializedTextBox.Text = reader.ReadToEnd();
        }

        private void DeserializeWith_XmlSerializer()
        {
            // create the XmlSerializer for the Person type
            var serializer = new XmlSerializer(typeof(Person));
            // place the XML text into a stream
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(SerializedTextBox.Text));
            // deserialize the stream containing XML to the Person object
            var person = serializer.Deserialize(stream) as Person;
            // Display the reconstituded object in the text boxes
            FirstNameTextbox.Text = person.FirstName;
            LastNameTextbox.Text = person.LastName;
        }
        #endregion
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    [DataContract]
    public class ContractPerson
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
}