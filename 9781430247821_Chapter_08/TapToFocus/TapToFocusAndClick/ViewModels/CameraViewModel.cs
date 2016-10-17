using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Microsoft.Devices;
using Microsoft.Xna.Framework.Media;

namespace TapToFocus.ViewModels
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

        private bool _isFocusing = false;
        public bool IsFocusing
        {
            get
            {
                return _isFocusing;
            }
            set
            {
                _isFocusing = value;
                NotifyPropertyChanged("IsFocusing");
            }
        }

        public CameraViewModel()
        {
            _camera = new PhotoCamera();
            _camera.Initialized += camera_Initialized;
            _camera.CaptureImageAvailable += camera_CaptureImageAvailable;
            _camera.CaptureStarted += _camera_CaptureStarted;
            _camera.CaptureCompleted += _camera_CaptureCompleted;
            _camera.AutoFocusCompleted += _camera_AutoFocusCompleted;
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
            _camera.AutoFocusCompleted -= _camera_AutoFocusCompleted;
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
                var resolution = new Size(2048, 1536);
                if (_camera.AvailableResolutions.Contains(resolution))
                {
                    _camera.Resolution = resolution;
                }
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

        public void Focus()
        {
            if ((_camera.IsFocusSupported) && (!_isCapturing))
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    this.IsFocusing = true;
                });
                _camera.Focus();
            }
        }

        void _camera_AutoFocusCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                this.IsFocusing = false;
            });
        }

        public void FocusAtPoint(double x, double y)
        {
            if ((_camera.IsFocusAtPointSupported) && (!_isCapturing))
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    this.IsFocusing = true;
                });
                _camera.FocusAtPoint(x, y);
            }
        }
    }
}
