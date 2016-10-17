using System;
using System.Collections.ObjectModel;
using System.Linq;
using LocalDatabase.Classes;
using Microsoft.Phone.Controls;


namespace LocalDatabase
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private JuiceDataContext _context;
        private ObservableCollection<Juice> _juices;

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // create the DataContext to manage database
            _context = new JuiceDataContext(JuiceDataContext.ConnectionString);

            // create observable collection to display in UI
            _juices = new ObservableCollection<Juice>(
                _context.Juices);
            JuiceListBox.ItemsSource = _juices;
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            // cleanup after the DataContext
            _context.Dispose();
            _context = null;

            base.OnNavigatedFrom(e);
        }

        private void AddClick(object sender, EventArgs e)
        {
            // avoid added the same name twice
            bool juiceExists = _juices
                .Any(j => j.Name.Equals(JuiceNameTextBox.Text));

            if (!juiceExists)
            {
                // create the object
                var juice = new Juice()
                {
                    Name = JuiceNameTextBox.Text,
                };
                // place the object in pending insert state
                _context.Juices.InsertOnSubmit(juice);
                // commit the changes to the database
                _context.SubmitChanges();

                // sync object to the observable collection
                _juices.Add(juice);
                JuiceNameTextBox.Text = String.Empty;
            }
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            if (JuiceListBox.SelectedItem != null)
            {
                // get the selected object
                var juice = JuiceListBox.SelectedItem as Juice;

                if (!_context.Juices.Any(j => j.Equals(juice)))
                {
                    // associate the object with the context
                    _context.Juices.Attach(juice);
                }

                // place in pending delete state
                _context.Juices.DeleteOnSubmit(juice);
                // commit the changes to the database
                _context.SubmitChanges();

                // sync object to the observable collection
                _juices.Remove(juice);
            }
        }
    }
}