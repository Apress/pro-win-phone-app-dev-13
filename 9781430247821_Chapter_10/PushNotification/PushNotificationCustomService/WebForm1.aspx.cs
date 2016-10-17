using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;

namespace PushNotificationCustomService
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ToastButton_Click(object sender, EventArgs e)
        {
            // create the web request out to the unique Uri 
            // obtained from the MS Push Notification Service
            var request = WebRequest.Create(UriTextBox.Text);
            request.Method = "POST";

            // the format expected by the MS Push Notification Service
            const string messageFormat = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                    "<wp:Notification xmlns:wp=\"WPNotification\">" +
                                    "<wp:Toast>" +
                                    "<wp:Text1>{0}</wp:Text1>" +
                                    "<wp:Text2>{1}</wp:Text2>" +
                                    "<wp:Param>{2}</wp:Param>" +
                                    "</wp:Toast> " +
                                    "</wp:Notification>";


            var message = String.Format(messageFormat, "Bunny Adoption", "Meet Harvey",
                    "/DailyBunny.xaml?NavigatedFrom=Push Toast Notification");

            // convert the xml to an array of bytes
            byte[] bytes = Encoding.Default.GetBytes(message);

            // configure the request to match the content
            request.ContentLength = bytes.Length;
            request.ContentType = "text/xml";
            request.Headers.Add("X-WindowsPhone-Target", "toast");
            request.Headers.Add("X-NotificationClass", "2");

            // make the request
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            var response = request.GetResponse();
            string status = response.Headers["X-NotificationStatus"];
            string channelStatus = response.Headers["X-SubscriptionStatus"];
            string connectionStatus = response.Headers["X-DeviceConnectionStatus"];
            Debug.WriteLine("{0}:{1}:{2}", status, channelStatus, connectionStatus);
        }

        protected void TileButton_Click(object sender, EventArgs e)
        {
            // create the web request out to the unique Uri 
            // obtained from the MS Push Notification Service
            var request = WebRequest.Create(UriTextBox.Text);
            request.Method = "POST";

            // the format expected by the MS Push Notification Service
            const string messageFormat =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                "<wp:Notification xmlns:wp=\"WPNotification\">" +
                "<wp:Tile>" +
                "<wp:BackgroundImage>{0}</wp:BackgroundImage>" +
                "<wp:Count>{1}</wp:Count>" +
                "<wp:Title>{2}</wp:Title>" +
                "<wp:BackBackgroundImage>{3}</wp:BackBackgroundImage>" +
                "<wp:BackContent>{4}</wp:BackContent>" +
                "<wp:BackTitle>{5}</wp:BackTitle>" +
                "</wp:Tile> " +
                "</wp:Notification>";

            var message = String.Format(messageFormat,
                "assets/images/tile.png", "7", "New Adoptions",
                "assets/images/tileback.png", "u haz kibbles?", "waiting adoption");
            Debug.WriteLine(message);

            // convert the xml to an array of bytes
            byte[] bytes = Encoding.Default.GetBytes(message);

            // configure the request to match the content
            request.ContentLength = bytes.Length;
            request.ContentType = "text/xml";
            request.Headers.Add("X-WindowsPhone-Target", "token");
            request.Headers.Add("X-NotificationClass", "1");

            // make the request
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            var response = request.GetResponse();
            string status = response.Headers["X-NotificationStatus"];
            string channelStatus = response.Headers["X-SubscriptionStatus"];
            string connectionStatus = response.Headers["X-DeviceConnectionStatus"];
            Debug.WriteLine("{0}:{1}:{2}", status, channelStatus, connectionStatus);
        }

protected void RawButton_Click(object sender, EventArgs e)
{
    // get an image from the project, make it into a smaller thumbnail
    // and convert it to an array of bytes
    var image = Image.FromFile(Server.MapPath("tile.png"));
    var thumbnail = image.GetThumbnailImage(100, 100, null, (IntPtr)null);
    var imageStream = new MemoryStream();
    thumbnail.Save(imageStream, ImageFormat.Jpeg);
    byte[] bytes = imageStream.ToArray();

    // create the web request out to the unique Uri 
    // obtained from the MS Push Notification Service
    var request = WebRequest.Create(UriTextBox.Text);
    request.Method = "POST";

    // configure the request to match the content
    request.ContentLength = bytes.Length;
    request.ContentType = "image/jpeg";
    request.Headers.Add("X-NotificationClass", "3");

    // make the request
    using (var stream = request.GetRequestStream())
    {
        stream.Write(bytes, 0, bytes.Length);
    }
}
    }
}