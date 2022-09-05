using ImagePicker.Interface;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImagePicker.Camera))]
namespace ImagePicker
{
    public class Camera : ICamera
    {
        private IMedia _camera;
        public Camera()
        {
            _camera = CrossMedia.Current;
            _camera.Initialize();
        }
        public bool IsPickPhotoSupported => _camera.IsPickPhotoSupported;

        public Task<MediaFile> PickPhotoAsync()
        {
            return _camera.PickPhotoAsync();
        }
    }
}
