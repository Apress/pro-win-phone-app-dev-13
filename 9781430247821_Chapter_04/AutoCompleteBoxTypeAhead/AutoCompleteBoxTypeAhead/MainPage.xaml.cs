using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AutoCompleteBoxTypeAhead.Resources;

namespace AutoCompleteBoxTypeAhead
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            autoCompleteBox1.ItemsSource = new List<string>() 
            { 
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" 
            };
            autoCompleteBox1.IsTextCompletionEnabled = true; 

        }

     
    }
}