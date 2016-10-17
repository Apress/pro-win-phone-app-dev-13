using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace Toasts
{
    public partial class DailyBunny : PhoneApplicationPage
    {
        public DailyBunny()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string navigatedFrom;
            if (NavigationContext.QueryString.TryGetValue("NavigatedFrom", out navigatedFrom))
            {
                this.Origin.Text = "Navigated from: " + navigatedFrom;
            }
        }
    }
}