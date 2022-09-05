using ImagePicker.Interface;
using ImagePicker.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImagePicker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Emoji();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
