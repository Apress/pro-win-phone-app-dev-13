using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MakeImageIntoUserControl
{
    public partial class BaristaControl : UserControl
    {
        public BaristaControl()
        {
            InitializeComponent();
        }

        private void LayoutRoot_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Barista barista = (sender as FrameworkElement).DataContext as Barista;
            barista.MakeSuggestion();
        }
    }
}
