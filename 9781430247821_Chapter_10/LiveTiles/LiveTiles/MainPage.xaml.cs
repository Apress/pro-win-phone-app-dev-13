using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LiveTiles.Resources;
using System.Windows.Media;

namespace LiveTiles
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //        <!--<TemplateIconic>
        //    <SmallImageURI IsRelative="true" IsResource="false">Assets\Tiles\surfer_small.jpg</SmallImageURI>
        //    <Count>6</Count>
        //    <IconImageURI IsRelative="true" IsResource="false">Assets\Tiles\surfer_small.jpg</IconImageURI>
        //    <Title>Surf Sites</Title>
        //    <Message>Pleasure Point wind 11 to 13 mph</Message>
        //    <HasLarge>True</HasLarge>
        //</TemplateIconic>-->

        private void IconButton_Click_1(object sender, EventArgs e)
        {
            Uri uri = new Uri("/IconTarget.xaml", UriKind.Relative);

            var tileData = new IconicTileData()
            {
                Title = "Surf Sites",
                SmallIconImage = new Uri("Assets/Tiles/IconicTileSmall.png", UriKind.Relative),
                IconImage = new Uri("Assets/Tiles/IconicTileMediumLarge.png", UriKind.Relative),
                Count = 6,
                // BackgroundColor is a System.Windows.Media.Color
                BackgroundColor = Color.FromArgb(255, 90, 117, 148), // or Colors.Blue, 
                WideContent1 = "This is very wide large content that is likely to exceed the width of the tile.",
                WideContent2 = "LargeContent2",
                WideContent3 = "LargeContent3",
            };

            var tile = ShellTile.ActiveTiles.FirstOrDefault(t => t.NavigationUri.Equals(uri));
            if (tile == null)
            {
                ShellTile.Create(uri, tileData, true);
            }
            else
            {
                tile.Update(tileData);
            };
        }

        //<SmallImageURI IsRelative="true" IsResource="false">Assets\Tiles\iStock_000004630599XSmall.jpg</SmallImageURI>
        //<Count>6</Count>
        //<BackgroundImageURI IsRelative="true" IsResource="false">Assets\Tiles\iStock_000004630599XSmall.jpg</BackgroundImageURI>
        //<Title>Surf Sites</Title>
        //<BackContent>Pleasure Point wind 11 to 13 mph</BackContent>
        //<BackBackgroundImageURI IsRelative="true" IsResource="false">Assets\Tiles\iStock_000012945007XSmall.jpg</BackBackgroundImageURI>
        //<BackTitle>Surf Advisories</BackTitle>
        //<LargeBackgroundImageURI IsRelative="true" IsResource="false">Assets\Tiles\iStock_000004630599XSmall.jpg</LargeBackgroundImageURI>
        //<LargeBackContent>High surf, poor visibility</LargeBackContent>
        //<LargeBackBackgroundImageURI IsRelative="true" IsResource="false">Assets\Tiles\iStock_000012945007XSmall.jpg</LargeBackBackgroundImageURI>
        //<DeviceLockImageURI IsRelative="true" IsResource="false"></DeviceLockImageURI>
        //<HasLarge>True</HasLarge>


        private void FlipButton_Click_1(object sender, EventArgs e)
        {
            Uri uri = new Uri("/FlipTarget.xaml", UriKind.Relative);

            var tileData = new FlipTileData()
            {
                Title = "Surf Sites",
                SmallBackgroundImage = new Uri("Assets/Tiles/iStock_000004630599XSmall.jpg", UriKind.Relative),
                BackgroundImage = new Uri("Assets/Tiles/iStock_000004630599XSmall.jpg", UriKind.Relative),
                Count = 6,
                BackContent = "Pleasure Point wind 11 to 13 mph",
                BackBackgroundImage = new Uri("Assets/Tiles/iStock_000012945007XSmall.jpg", UriKind.Relative),
                BackTitle = "Surf Advisories",
                WideBackContent = "High surf, poor visibility",
                WideBackgroundImage = new Uri("Assets/Tiles/iStock_000004630599XSmall.jpg", UriKind.Relative),
                WideBackBackgroundImage = new Uri("Assets/Tiles/iStock_000012945007XSmall.jpg", UriKind.Relative)
            };

            var tile = ShellTile.ActiveTiles.FirstOrDefault(t => t.NavigationUri.Equals(uri));
            if (tile == null)
            {
                ShellTile.Create(uri, tileData, true);
            }
            else
            {
                tile.Update(tileData);
            };
        }

        //<!--<TemplateCycle>
        //    <SmallImageURI IsRelative="true" IsResource="false">Assets\Tiles\iStock_000002999571XSmall.jpg</SmallImageURI>
        //    <Title>Surf Sites</Title>
        //    <Photo01ImageURI IsRelative="true" IsResource="false">Assets\Tiles\iStock_000002999571XSmall.jpg</Photo01ImageURI>
        //    <Photo02ImageURI IsRelative="true" IsResource="false">Assets\Tiles\iStock_000004630599XSmall.jpg</Photo02ImageURI>
        //    <Photo03ImageURI IsRelative="true" IsResource="false">Assets\Tiles\iStock_000005268101XSmall.jpg</Photo03ImageURI>
        //    <Photo04ImageURI IsRelative="true" IsResource="false">Assets\Tiles\iStock_000012945007XSmall.jpg</Photo04ImageURI>
        //    <Photo05ImageURI IsRelative="true" IsResource="false">Assets\Tiles\iStock_000014745608XSmall.jpg</Photo05ImageURI>
        //    <Photo06ImageURI IsRelative="true" IsResource="false">Assets\Tiles\iStock_000016850786XSmall.jpg</Photo06ImageURI>
        //    <Photo07ImageURI IsRelative="true" IsResource="false">
        //    </Photo07ImageURI>
        //    <Photo08ImageURI IsRelative="true" IsResource="false">
        //    </Photo08ImageURI>
        //    <Photo09ImageURI IsRelative="true" IsResource="false">
        //    </Photo09ImageURI>
        //    <Count>6</Count>
        //    <HasLarge>True</HasLarge>
        //    <DeviceLockImageURI IsRelative="true" IsResource="false"></DeviceLockImageURI>
        //</TemplateCycle>-->

        private void CycleButton_Click_1(object sender, EventArgs e)
        {
            Uri uri = new Uri("/CycleTarget.xaml", UriKind.Relative);

            var tileData = new CycleTileData()
            {
                Title = "Surf Sites",
                SmallBackgroundImage = new Uri("Assets/Tiles/iStock_000004630599XSmall.jpg", UriKind.Relative),
                Count = 6,
                CycleImages = new List<Uri>() 
                {
                        new Uri("Assets/Tiles/iStock_000002999571XSmall.jpg", UriKind.Relative),
                        new Uri("Assets/Tiles/iStock_000004630599XSmall.jpg", UriKind.Relative),
                        new Uri("Assets/Tiles/iStock_000005268101XSmall.jpg", UriKind.Relative),
                        new Uri("Assets/Tiles/iStock_000012945007XSmall.jpg", UriKind.Relative),
                        new Uri("Assets/Tiles/iStock_000014745608XSmall.jpg", UriKind.Relative),
                        new Uri("Assets/Tiles/iStock_000016850786XSmall.jpg", UriKind.Relative)
                }
            };

            ShellTile.Create(uri, tileData, true);

            var tile = ShellTile.ActiveTiles.FirstOrDefault(t => t.NavigationUri.Equals(uri));
            if (tile == null)
            {
                ShellTile.Create(uri, tileData, true);
            }
            else
            {
                tile.Update(tileData);
            };
        }
    }
}