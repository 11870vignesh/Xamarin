﻿using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImagePicker.Interface
{
    public interface ICamera
    {
        bool IsPickPhotoSupported { get; }
        Task<MediaFile> PickPhotoAsync();

    }
}
