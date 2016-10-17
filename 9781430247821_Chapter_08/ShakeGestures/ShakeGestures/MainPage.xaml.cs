using System.Collections.Generic;
using System.Windows.Navigation;
using Microsoft.Devices.Sensors;
using Microsoft.Phone.Controls;
using ShakeGestures.Classes;
using ShakeGestures.Extensions;

namespace ShakeGestures
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private Shake _shake;
        private Answers _answers = new Answers();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (Shake.IsSupported)
            {
                _shake = new Shake() { ReadingThreshhold = 1, CountThreshold = 2 };
                _shake.CurrentValueChanged += _shake_CurrentValueChanged;
                _shake.Start();
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (Shake.IsSupported)
            {
                _shake.Stop();
                _shake.CurrentValueChanged -= _shake_CurrentValueChanged;
                _shake.Dispose();
                _shake = null;

            }
            base.OnNavigatedFrom(e);
        }

        void _shake_CurrentValueChanged(object sender, SensorReadingEventArgs<ShakeReading> e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.AnswerText.Text = _answers.Ask();
                this.AnswerText.Opacity = 0;

                this.AnswerText.Animate(new Dictionary<string, double>()
                {
                    {"Opacity", 1}
                }, 5000);
            });
        }
    }
}