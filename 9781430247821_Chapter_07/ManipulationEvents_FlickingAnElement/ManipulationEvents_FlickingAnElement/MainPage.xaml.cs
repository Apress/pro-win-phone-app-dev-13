using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using ManipulationEvents_FlickingAnElement.Classes;
using Microsoft.Phone.Controls;

namespace ManipulationEvents_FlickingAnElement
{
    public partial class MainPage : PhoneApplicationPage
    {

        private Deck _deck = new Deck();

        public MainPage()
        {
            InitializeComponent();

            ContentPanel.ManipulationStarted += ContentPanel_ManipulationStarted;
            ContentPanel.ManipulationDelta += ContentPanel_ManipulationDelta;
            ContentPanel.ManipulationCompleted += ContentPanel_ManipulationCompleted;
        }

        void ContentPanel_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            if ((e.ManipulationContainer is Image) &&
                ((e.ManipulationContainer as Image).Name.Equals("FaceDownCard")))
            {
                Card card = _deck.Deal();
                Image cardImage = GetCardImage(card);

                Canvas.SetTop(cardImage, Canvas.GetTop(FaceDownCard));
                Canvas.SetLeft(cardImage, Canvas.GetLeft(FaceDownCard));

                ContentPanel.Children.Add(cardImage);

                if (_deck.Count == 1)
                {
                    FaceDownCard.Visibility = System.Windows.Visibility.Collapsed;
                }

                e.ManipulationContainer = cardImage;
            }
            e.Handled = true;
        }

        void ContentPanel_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            TranslateTransform transform =
                e.ManipulationContainer.RenderTransform as TranslateTransform;
            if (transform != null)
            {
                transform.X += e.DeltaManipulation.Translation.X;
                transform.Y += e.DeltaManipulation.Translation.Y;
            }
            e.Handled = true;
        }

        void ContentPanel_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            // verify that a flick occurred and the element is intended to have inertia.
            if ((e.IsInertial) && (e.ManipulationContainer is Image))
            {
                // get the RenderTransform property added when the card was created during GetCardImage()
                TranslateTransform transform =
                    e.ManipulationContainer.RenderTransform as TranslateTransform;

                // create animations to move the element along X and Y directions
                DoubleAnimation animationX = new DoubleAnimation()
                {
                    EasingFunction = new QuinticEase() { EasingMode = EasingMode.EaseOut },
                    To = transform.X + (e.FinalVelocities.LinearVelocity.X / 10)
                };
                DoubleAnimation animationY = new DoubleAnimation()
                {
                    EasingFunction = new QuinticEase() { EasingMode = EasingMode.EaseOut },
                    To = transform.Y + (e.FinalVelocities.LinearVelocity.Y / 10)
                };

                // create a storyboard as a container for the animation 
                Storyboard storyBoard = new Storyboard()
                {
                    // set the duration for only a quarter of a second
                    Duration = new Duration(new System.TimeSpan(0, 0, 0, 0, 250)),
                };

                // add the animation to the storyboard and hook up the X and Y properties
                // of the Transform to the target, element properties
                storyBoard.Children.Add(animationX);
                Storyboard.SetTarget(animationX, transform);
                Storyboard.SetTargetProperty(animationX, new PropertyPath("X"));

                storyBoard.Children.Add(animationY);
                Storyboard.SetTarget(animationY, transform);
                Storyboard.SetTargetProperty(animationY, new PropertyPath("Y"));

                // animate
                storyBoard.Begin();
            }
            e.Handled = true;
        }

        // get the image path based on the card suit and value
        private Image GetCardImage(Card card)
        {
            const string pathFormat = "/Assets/Cards/{0:d}_{1}.png";
            string path = string.Format(pathFormat, card.CardType, card.SuitType.ToString().ToLower());

            Image cardImage = new Image()
            {
                Source = new BitmapImage(new Uri(path, UriKind.Relative)),
                Width = FaceDownCard.Width,
                Height = FaceDownCard.Height,
                Margin = FaceDownCard.Margin,
                RenderTransform = new TranslateTransform()
            };
            return cardImage;
        }

        private void PageLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Canvas.SetTop(FaceDownCard, ContentPanel.ActualHeight -
                (FaceDownCard.Height + FaceDownCard.Margin.Bottom + FaceDownCard.Margin.Top));
        }
    }
}