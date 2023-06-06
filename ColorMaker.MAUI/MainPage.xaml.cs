using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;

namespace ColorMaker.MAUI
{
    public partial class MainPage : ContentPage
    {
        bool isRandom;
        string hexValue;
        public MainPage()
        {
            InitializeComponent();
        }

        private void sliderRed_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRandom)
            {
                var red = sliderRed.Value;
                var green = sliderGreen.Value;
                var blue = sliderBlue.Value;

                Color color = Color.FromRgb(red, green, blue);

                SetColor(color);
            }
        }

        private void SetColor(Color color)
        {
            Debug.WriteLine(color.ToString());
            btnRandom.BackgroundColor = color;
            Container.BackgroundColor = color;
            hexValue = color.ToHex();
            lblHex.Text = hexValue;
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {

            isRandom = true;

            var random = new Random();
            var color = Color.FromRgb(
                random.Next(0, 256),
                random.Next(0, 256),
                random.Next(0, 256));

            SetColor(color);

            sliderRed.Value = color.Red;
            sliderGreen.Value = color.Green;
            sliderBlue.Value = color.Blue;

            isRandom = false;

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);
            var toast = Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);

            await toast.Show();
        }
    }
}