using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

namespace MakeImageIntoUserControl
{
	public class Barista : INotifyPropertyChanged
	{
		public Barista()
		{
			MakeSuggestion();
		}
	
		private Order _order;
		public Order CurrentOrder
		{
			get { return _order; }
			set
			{
				_order = value;
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("CurrentOrder"));
				}
			}
		}
	
		// Create a new Order with random settings and assign to the 
		// CurrentOrder property
		public void MakeSuggestion()
		{
			var random = new Random();
	
			CurrentOrder = new Order()
						{
							Size = (Sizes)random.Next(9),
							Drink = (Drink)random.Next(7),
							Foam = (Foam)random.Next(2),
							Decaf = random.Next(2) == 1
						};
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}

}