﻿using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace InvatamSaCalculam.Client.LandingPages.Helpers
{
    [ValueConversion(typeof(System.Drawing.Image), typeof(System.Windows.Media.ImageSource))]
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture)
        {
            // empty images are empty…
            if (value == null) { return null; }

            var image = (System.Drawing.Image)value;
            // Winforms Image we want to get the WPF Image from…
            var bitmap = new System.Windows.Media.Imaging.BitmapImage();
            bitmap.BeginInit();
            MemoryStream memoryStream = new MemoryStream();
            // Save to a memory stream…
            image.Save(memoryStream, image.RawFormat);
            // Rewind the stream…
            memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
            bitmap.StreamSource = memoryStream;
            bitmap.EndInit();
            return bitmap;
        }

        public object ConvertBack(object value, Type targetType,
        object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
