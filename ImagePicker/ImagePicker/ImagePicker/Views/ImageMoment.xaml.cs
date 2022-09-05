using ImagePicker.Interface;
using NativeMedia;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImagePicker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageMoment : ContentPage
    {       
        public string UserMoment;
        public string UserMomentImage;
        public string pickphotopath;
        public string takephotopath;

        public ImageMoment()
        {
            InitializeComponent();
            CrossMedia.Current.Initialize();

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (CrossMedia.Current.IsPickPhotoSupported)
                {
                    var photo = await CrossMedia.Current.PickPhotoAsync();
                    pickphotopath = photo.Path;
                    if (photo != null)
                    {
                        UserImage.Source = ImageSource.FromStream(()=>photo.GetStream());
                        PickPhoto(pickphotopath);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void PickPhoto(string pickphotopath)
        {
            UserMomentImage = pickphotopath;
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {

                if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
                {
                    try
                    {                       
                        var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                        {
                           Directory = "ImagePicker",
                           SaveToAlbum = true,
                        });
                        if (file != null)
                        {
                            takephotopath = file.Path;
                            TakePhoto(takephotopath);
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                  
                }

            
        }

        private void TakePhoto(string takephotopath)
        {
            UserMomentImage = takephotopath;
        }

        //private void Moment_Unfocused(object sender, FocusEventArgs e)
        //{
        //    UserMoment = Moment.Text;
        //}
        private void Moment_Completed(object sender, EventArgs e)
        {
            UserMoment = Moment.Text;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            AppMoment(UserMoment, UserMomentImage);

        }

        private void AppMoment(string userMoment, string userMomentImage)
        {
            try
            {
                DependencyService.Get<IShare>().Share(userMoment, userMomentImage);
            }
            catch (Exception ex)
            {

            }
        }      
    }
}