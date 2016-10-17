using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Animation;

namespace ShakeGestures.Extensions
{
    public static class DependencyObjectExtensions
    {
        public static void Animate(this DependencyObject target, Dictionary<string, double> dictionary,
            int duration = 500)
        {
            Storyboard storyBoard = new Storyboard();

            foreach (var item in dictionary)
            {
                DoubleAnimation animation = new DoubleAnimation()
                {
                    EasingFunction = new QuinticEase() { EasingMode = EasingMode.EaseOut },
                    Duration = new Duration(new System.TimeSpan(0, 0, 0, 0, duration)),
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
