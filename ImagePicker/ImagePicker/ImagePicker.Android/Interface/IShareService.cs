using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ImagePicker.Droid.Interface;
using ImagePicker.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static System.Net.Mime.MediaTypeNames;
using static Xamarin.Essentials.Platform;
using Intent = Android.Content.Intent;

[assembly: Dependency(typeof(IShareService))]
namespace ImagePicker.Droid.Interface
{
    public class IShareService : IShare
    {


        //public async void Share(string text)
        //{
        //    try
        //    {
        //        Intent shareIntent = new Intent();
        //        shareIntent.SetAction(Intent.ActionSend);
        //        shareIntent.SetType("text/plain");
        //        shareIntent.PutExtra(Intent.ExtraText, text);
        //        Forms.Context.StartActivity(Intent.CreateChooser(shareIntent, "Share"));
        //    }
        //    catch (Exception ex)
        //    {


        //    }
        public void Share(string message, string image)
        {
            try
            {
                Intent shareIntent = new Intent();
                shareIntent.SetAction(Intent.ActionSend);
                shareIntent.SetType("text/plain");
                shareIntent.PutExtra(Intent.ExtraText, message);
                shareIntent.SetType("image/*");
                shareIntent.AddFlags(ActivityFlags.GrantReadUriPermission);
                var photoFile = new Java.IO.File(image);
                var imageUri = FileProvider.GetUriForFile(Forms.Context, "com.companyname.imagepicker.fileprovider", photoFile);
                shareIntent.PutExtra(Intent.ExtraStream, imageUri);                  
                Forms.Context.StartActivity(Intent.CreateChooser(shareIntent, "Share"));
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
            }

            
        }
    }
}