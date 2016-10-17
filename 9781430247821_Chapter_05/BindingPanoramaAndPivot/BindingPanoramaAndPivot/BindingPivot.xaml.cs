using Microsoft.Phone.Controls;

namespace BindingPanoramaAndPivot
{
    public partial class BindingPivot : PhoneApplicationPage
    {
        public BindingPivot()
        {
            InitializeComponent();
            Pivot1.DataContext = new MyData();
        }
    }
}