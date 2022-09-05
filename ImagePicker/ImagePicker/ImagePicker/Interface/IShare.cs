using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ImagePicker.Interface
{
    public interface IShare
    {
        void Share(string message, string image);
    }
}
