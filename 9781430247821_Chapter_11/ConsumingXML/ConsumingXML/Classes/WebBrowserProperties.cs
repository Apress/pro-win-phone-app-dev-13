using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Phone.Controls;

namespace ConsumingXML.Classes
{
    public class WebBrowserProperties
    {
        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached(
           "Html",
           typeof(string),
           typeof(WebBrowserProperties),
           new PropertyMetadata(HtmlChangeCallback)
        );

        public static void SetHtml(UIElement element, string value)
        {
            element.SetValue(HtmlProperty, value);
        }

        public static string GetHtml(UIElement element)
        {
            return (string)element.GetValue(HtmlProperty);
        }

        public static void HtmlChangeCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is WebBrowser)
            {
                (d as WebBrowser).NavigateToString(e.NewValue.ToString());
            }
        }
    }
}
