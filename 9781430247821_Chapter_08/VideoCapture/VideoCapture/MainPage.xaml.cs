using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace VideoCapture
{
 

public partial class MainPage : PhoneApplicationPage
{
    private const string path = "capture.mp4";

    private enum CaptureState { Preview, Record, Playback };

    private CaptureSource _captureSource;
    private VideoBrush _videoBrush;
    private FileSink _fileSink;
    private CaptureState _captureState; 

    // Constructor
    public MainPage()
    {
        InitializeComponent();
    }

protected override void OnNavigatedTo(NavigationEventArgs e)
{
    base.OnNavigatedTo(e);

    _captureSource = new CaptureSource();
    // create CaptureSource with default audio and video
    _captureSource.VideoCaptureDevice =
        CaptureDeviceConfiguration.GetDefaultVideoCaptureDevice();
    _captureSource.AudioCaptureDevice =
        CaptureDeviceConfiguration.GetDefaultAudioCaptureDevice();
    // create VideoBrush using CaptureSource as source
    _videoBrush = new VideoBrush();
    _fileSink = new FileSink();
    _fileSink.IsolatedStorageFileName = path;

    this.Tap += new EventHandler<GestureEventArgs>(MainPage_Tap);
    _captureState = CaptureState.Preview;

    RunStateMethod();
}

protected override void OnNavigatedFrom(NavigationEventArgs e)
{
    this.Tap -= new EventHandler<GestureEventArgs>(MainPage_Tap);
    _captureSource = null;
    _videoBrush = null;
    _fileSink = null; 

    base.OnNavigatedFrom(e);
}

void MainPage_Tap(object sender, GestureEventArgs e)
{
    // bump to the next state
    _captureState = _captureState == CaptureState.Playback ?
        _captureState = CaptureState.Preview :
        ((CaptureState)((int)_captureState) + 1);

    RunStateMethod();
}

private void RunStateMethod()
{
    // display the state
    this.PageTitle.Text = _captureState.ToString();

    // run the appropriate method
    switch (_captureState)
    {
        case CaptureState.Preview: { Preview(); break; }
        case CaptureState.Record: { Record(); break; }
        case CaptureState.Playback: { Playback(); break; }
    }
}

private void Preview()
{
    VideoPlayer.Stop();
    VideoPlayer.Source = null;

    // stop any previous captures
    _captureSource.Stop();
    _videoBrush.SetSource(_captureSource);
    // assign the VideoBrush to the background and start the capture
    this.ContentPanel.Background = _videoBrush;
    _captureSource.Start();
}

private void Record()
{
    // stop the CaptureSource so we can 
    // associate it with a FileSink
    _captureSource.Stop();

    // create a file in isolated storage
    // and close without writing to it
    using (IsolatedStorageFile store =
        IsolatedStorageFile.GetUserStoreForApplication())
    {
        store.CreateFile(path).Close();
    }

    // create a FileSink
    // associate it with the isolated storage file name
    // and associate with the CaptureSource                        
    _fileSink.CaptureSource = _captureSource;

    // restart the capture
    _captureSource.Start();
}

private void Playback()
{
    _captureSource.Stop();

    using (IsolatedStorageFile store =
        IsolatedStorageFile.GetUserStoreForApplication())
    {
        IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(path,
                FileMode.Open, FileAccess.Read, store);

        VideoPlayer.SetSource(isoStream);
    }

    VideoPlayer.Play();
}

void VideoPlayer_MediaEnded(object sender, RoutedEventArgs e)
{
    this.PageTitle.Text = "playback ended";
}
}
}