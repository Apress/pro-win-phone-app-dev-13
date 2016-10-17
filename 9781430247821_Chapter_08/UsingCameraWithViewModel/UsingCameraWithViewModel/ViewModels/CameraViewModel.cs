using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.Devices;
using Microsoft.Xna.Framework.Media;

namespace UsingCameraWithViewModel.ViewModels
{
    public class CameraViewModel : BaseViewModel, IDisposable
    {
        private PhotoCamera _camera;
        private string _captureName;
        private VideoBrush _tempBrush;
        private VideoBrush _preview;
        public VideoBrush Preview
        {
            get
            {
                return _preview;
            }
            private set
            {
                _preview = value;
                NotifyPropertyChanged("Preview");
            }
        }

        public CameraViewModel()
        {
            _camera = new PhotoCamera(CameraType.Primary);
            _camera.Initialized += camera_Initialized;
            _camera.CaptureImageAvailable += camera_CaptureImageAvailable;
            _tempBrush = new VideoBrush();
            _tempBrush.SetSource(_camera);
        }
        public void Dispose()
        {
            _camera.Initialized -= camera_Initialized;
            _camera.CaptureImageAvailable -= camera_CaptureImageAvailable;
            _camera.Dispose();
            _camera = null;
            _tempBrush = null;
            this.Preview = null;
        }

        void camera_Initialized(object sender, CameraOperationCompletedEventArgs e)
        {
            if (e.Succeeded)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    this.Preview = _tempBrush;
                });
            }
        }

        public void Capture(string fileName)
        {
            _captureName = fileName;
            try
            {
                _camera.CaptureImage();
            }
            // ignore images taken too close together
            catch (InvalidOperationException) { }
        }

        void camera_CaptureImageAvailable(object sender, ContentReadyEventArgs e)
        {
            MediaLibrary library = new MediaLibrary();
            new MediaLibrary().SavePictureToCameraRoll(_captureName, e.ImageStream);
        }


    }
}
