using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework.Media;

namespace GestureService_FlickAndRotateElement.ViewModels
{
    public class PictureViewModel
    {
        public ImageSource PictureSource { get; set; }
    }

    public class PicturesViewModel
    {
        public List<PictureViewModel> Pictures { get; set; }

        public PicturesViewModel()
        {
            Pictures = new List<PictureViewModel>();

            foreach (var picture in new MediaLibrary().Pictures)
            {
                if (picture.Album.Name.Equals("Surfing"))
                {
                    BitmapImage bi = new BitmapImage();
                    bi.SetSource(picture.GetImage());
                    Pictures.Add(new PictureViewModel() { PictureSource = bi });
                }
            }
        }
    }
}
