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

namespace MakeImageIntoUserControl
{
	public class Order
	{
		public Sizes Size { get; set; }
		public Drink Drink { get; set; }
		public Foam Foam { get; set; }
		public bool Decaf { get; set; }
	
		public string Description
		{
			get { return String.Format("{0} {1}, {2} foam", Size, Drink, Foam); }
		}
	}
}