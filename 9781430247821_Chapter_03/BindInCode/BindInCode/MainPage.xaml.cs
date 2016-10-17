using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Phone.Controls;

namespace BindInCode
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // create a CLR object instance
            BikeType bikeType = new BikeType()
            {
                TypeName = "Touring",
                TypeDescription = "Durable and comfortable bikes for long journeys."
            };

            // create a Binding object
            Binding binding = new Binding()
            {
                Source = bikeType,
                Path = new PropertyPath("TypeName"),
                Mode = BindingMode.OneTime
            };

            // assign the binding object to the FrameworkElement
            BindInCodeTextBox.SetBinding(TextBox.TextProperty, binding);
        }

      }
}