using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Accel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Accelerometer.IsMonitoring)
                return;

            Accelerometer.Start(SensorSpeed.Default);
            Accelerometer.ReadingChanged += Acelerometro_ReadingChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Accelerometer.Stop();
            Accelerometer.ReadingChanged -= Acelerometro_ReadingChanged;
        }

        void Acelerometro_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;

            var x = data.Acceleration.X;
            var y = data.Acceleration.Y;
            var z = data.Acceleration.Z;

            Device.BeginInvokeOnMainThread(() =>
            {
                accelerometerLabel.Text = $"X: {x:F2}\nY: {y:F2}\nZ: {z:F2}";
            });
        }
    }
}
