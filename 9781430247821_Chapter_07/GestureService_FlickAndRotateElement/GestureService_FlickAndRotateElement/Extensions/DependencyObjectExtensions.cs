using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace GestureService_FlickAndRotateElement.Extensions
{
    // extension methods for DependencyObject
    public static class DependencyObjectExtensions
    {
        // given a DependencyObject, climb up the visual tree looking for the first instance of T
        public static T Ancestor<T>(this DependencyObject originalSource) where T : DependencyObject
        {
            if (originalSource is T)
            {
                return originalSource as T; 
            }
            DependencyObject element = VisualTreeHelper.GetParent(originalSource) as DependencyObject;
            while (element != null)
            {
                if (element is T)
                    return element as T;
                element = VisualTreeHelper.GetParent(element) as DependencyObject;
            }
            return null;
        }

        // given a DependencyObject, return all children (at all levels) of T
        public static IEnumerable<T> Descendants<T>(this DependencyObject element) where T : DependencyObject
        {
            List<T> descendants = new List<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                var childElement = VisualTreeHelper.GetChild(element, i) as DependencyObject;
                if (childElement is T)
                {
                    descendants.Add(childElement as T);
                }
                // we found child elements of type T, no need to spelunk further
                if (descendants.Count == 0)
                {
                    descendants.AddRange(childElement.Descendants<T>());
                }
            }
            return descendants;
        }

        // animate a list of property/value pairs using a hard-coded easing 
        public static void Animate(this DependencyObject target, Dictionary<string, double> dictionary, int duration = 500)
        {
            Storyboard storyBoard = new Storyboard()
            {
                Duration = new Duration(new System.TimeSpan(0, 0, 0, 0, duration)),
            };

            foreach (var item in dictionary)
            {
                DoubleAnimation animation = new DoubleAnimation()
                {
                    EasingFunction = new QuinticEase() { EasingMode = EasingMode.EaseOut },
                    To = item.Value
                };
                Storyboard.SetTarget(animation, target);
                Storyboard.SetTargetProperty(animation, new PropertyPath(item.Key));
                storyBoard.Children.Add(animation);
            }

            storyBoard.Begin();
        }
    }
}
