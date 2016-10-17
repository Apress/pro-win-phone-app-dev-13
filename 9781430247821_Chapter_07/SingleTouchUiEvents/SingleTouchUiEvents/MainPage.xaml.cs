using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;
using SingleTouchUiEvents.Classes;

namespace SingleTouchUiEvents
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private Deck _deck = new Deck();

        // respond to the face down card tap
        private void FaceDownCard_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // get a new random card
            Card card = _deck.Deal();
            // get an image for the new card
            Image cardImage = GetCardImage(card);

            // set the cards position relative to the face down card
            var margin = FaceDownCard.Margin.Left;
            cardImage.Margin = new Thickness(margin + 50, margin - 50, 0, 0);
            Canvas.SetTop(cardImage, Canvas.GetTop(FaceDownCard));
            Canvas.SetLeft(cardImage, Canvas.GetLeft(FaceDownCard));

            // add the card to the layout
            ContentPanel.Children.Add(cardImage);

            // if done dealing all cards, hide the face-down card
            if (_deck.Count == 1)
            {
                FaceDownCard.Visibility = System.Windows.Visibility.Collapsed;
            }
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
                Height = FaceDownCard.Height
            };
            return cardImage;
        }

// when the dimensions are available, place the card at the bottom of the page
private void PageLoaded(object sender, System.Windows.RoutedEventArgs e)
{
    Canvas.SetTop(FaceDownCard, ContentPanel.ActualHeight -
        (FaceDownCard.Height + FaceDownCard.Margin.Bottom + FaceDownCard.Margin.Top));
}
    }
}