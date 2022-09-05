using ImagePicker.Interface;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
[assembly: Dependency(typeof(ImagePicker.MediaService))]

namespace ImagePicker
{
    public class MediaService : IMediaService
    {
        private ICamera _camera;
        public bool IsPickPhotoSupported => _camera.IsPickPhotoSupported;
        public MediaService()
        {
            _camera = DependencyService.Get<ICamera>();
        }
        public Task<MediaFile> PickPhotoAsync()
        {
            if (!IsPickPhotoSupported)
            {
                throw new NotSupportedException("Photo selection not supported on this device.");
            }

            return _camera.PickPhotoAsync();
        }
    }
}
