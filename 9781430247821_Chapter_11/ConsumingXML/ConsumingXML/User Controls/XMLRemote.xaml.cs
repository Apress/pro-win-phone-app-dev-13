using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Controls;
using ConsumingXML.Classes;

// Get your api key starting from http://www.flickr.com/services/apps/create/

namespace ConsumingXML.User_Controls
{
    public partial class XMLRemote : UserControl
    {
        public XMLRemote()
        {
            InitializeComponent();

            UseWebClient();

            //UseHttpWebRequest();
        }

private const string BaseUrl = "http://ycpi.api.flickr.com/services/rest/";
private const string QueryStrings = "?method={0}&api_key={1}&user_id={2}&format=json&nojsoncallback=1";
private const string FlickrMethod = "flickr.people.getPublicPhotos";
private const string YourApiKey = "a304737db3358208d6c64fd65aefdb2f";
private const string LibraryOfCongressKey = "8623220@N02";
private string FlickrPhotosUrl = BaseUrl +
    String.Format(QueryStrings, FlickrMethod, YourApiKey, LibraryOfCongressKey);

private void UseHttpWebRequest()
{
var uri = new Uri(FlickrPhotosUrl);
var request = (HttpWebRequest)WebRequest.Create(uri);
request.BeginGetResponse(new AsyncCallback(HandleRequest), request);
}

private void HandleRequest(IAsyncResult asyncResult)
{
    var request = asyncResult.AsyncState as HttpWebRequest;
    using (var response =
                (HttpWebResponse)request.EndGetResponse(asyncResult))
    {
        string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
        var photos = GetFlickrPhotos(json);
               
        Dispatcher.BeginInvoke(() =>
        {
            FlickrListBox.DataContext = photos;
        });
    }
}

private static List<FlickrPhoto> GetFlickrPhotos(string json)
{
    const string baseUrl =
        "http://farm{0}.staticflickr.com/{1}/{2}_{3}_s.jpg";

    List<FlickrPhoto> FlickrPhotos = null; 
    var serializer = new DataContractJsonSerializer(typeof(RootObject));
    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
    {
        var root = serializer.ReadObject(stream) as RootObject;
        FlickrPhotos = (from photo in root.photos.photo
                        select new FlickrPhoto
                        {
                            Title = photo.title,
                            Uri = new Uri(String.Format(baseUrl,
                                photo.farm, photo.server, photo.id, photo.secret))
                        }).ToList(); 
    }
    return FlickrPhotos;
}

private void UseWebClient()
{
    var uri = new Uri(FlickrPhotosUrl);

    var client = new WebClient();
    client.DownloadStringCompleted += (sender, e) =>
    {
        var photos = GetFlickrPhotos(e.Result);
        Dispatcher.BeginInvoke(() =>
        {
            FlickrListBox.DataContext = photos;
        });
    };
    client.DownloadStringAsync(uri);
}
    }
}
