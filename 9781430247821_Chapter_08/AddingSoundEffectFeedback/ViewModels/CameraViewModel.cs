using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.Devices;
using Microsoft.Xna.Framework.Media;

namespace AddingSoundEffectFeedback.ViewModels
{
    public class CameraViewModel : BaseViewModel, IDisposable
    {
        private PhotoCamera _camera;
        private string _captureName;
        private VideoBrush _tempBrush;
        private VideoBrush _preview;

        private SoundEffects _effects;
        private MediaLibrary _mediaLibrary;

        private bool _isCapturing;

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
            _camera = new PhotoCamera();
            _camera.Initialized += camera_Initialized;
            _camera.CaptureImageAvailable += camera_CaptureImageAvailable;
            _camera.CaptureStarted += _camera_CaptureStarted;
            _camera.CaptureCompleted += _camera_CaptureCompleted;
            _tempBrush = new VideoBrush();
            _tempBrush.SetSource(_camera);

            _effects = new SoundEffects();
            _mediaLibrary = new MediaLibrary();
        }

        public void Dispose()
        {
            _effects = null;
            _mediaLibrary = null;

            _camera.Initialized -= camera_Initialized;
            _camera.CaptureImageAvailable -= camera_CaptureImageAvailable;
            _camera.CaptureStarted -= _camera_CaptureStarted;
            _camera.CaptureCompleted -= _camera_CaptureCompleted;
            _camera.Dispose();
            _camera = null;
            _tempBrush = null;
            this.Preview = null;
        }

        void _camera_CaptureCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            _isCapturing = false;
        }

        void _camera_CaptureStarted(object sender, EventArgs e)
        {
            _isCapturing = true;
        }

        void camera_Initialized(object sender, CameraOperationCompletedEventArgs e)
        {
            if (e.Succeeded)
            {
                _camera.Resolution = new Size(2048, 1536);
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    this.Preview = _tempBrush;
                });
            }
            else
            {
                _effects.Play(EffectTypes.Error);
            }
        }

        public void Capture(string fileName)
        {
            if (!_isCapturing)
            {
                _captureName = fileName;
                _camera.CaptureImage();
                _effects.Play(EffectTypes.Click);
            }
            else
            {
                _effects.Play(EffectTypes.Error);
            }
        }

        void camera_CaptureImageAvailable(object sender, ContentReadyEventArgs e)
        {
            e.ImageStream.Position = 0;
            _mediaLibrary.SavePictureToCameraRoll(_captureName, e.ImageStream);
            e.ImageStream.Close();
        }
    }
}
