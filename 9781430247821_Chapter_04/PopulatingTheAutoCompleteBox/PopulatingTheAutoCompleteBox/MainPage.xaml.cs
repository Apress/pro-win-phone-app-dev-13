using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PopulatingTheAutoCompleteBox.Resources;

namespace PopulatingTheAutoCompleteBox
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            autoCompleteBox1.ItemsSource = new AppointmentDays();
            autoCompleteBox1.ValueMemberPath = "Day";
        }


    }
}