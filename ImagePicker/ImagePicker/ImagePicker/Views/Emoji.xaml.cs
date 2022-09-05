using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace ImagePicker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Emoji : ContentPage
    {
        public Emoji()
        {
            InitializeComponent();
            EmojiLine.X1 = 100;
            EmojiLine.X2 = 100;
            EmojiLine.Y1 = 150;
            EmojiLine.Y2 = 150;
            //EmojiLine.X1 = 50;
            //EmojiLine.X2 = 150;
            //EmojiLine.Y1 = 150;
            //EmojiLine.Y2 = 150;
        }

        private void canvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SkiaSharp.SKImageInfo info = e.Info;
            var surface = e.Surface;
            var canvas = surface.Canvas;

            canvas.Clear();
            SkiaSharp.SKPaint thinLinePaint = new SkiaSharp.SKPaint
            {
                Style = SkiaSharp.SKPaintStyle.Stroke,
                Color = SkiaSharp.SKColors.Blue,
                StrokeWidth = 6
            };
            canvas.DrawLine(0, 0, 50, 50, thinLinePaint);
        }

        private void EmojiSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if(e.NewValue == 100)
            {
                EmojiLine.X1 = 50;
                EmojiLine.X2 = 150;
                EmojiLine.Y1 = 150;
                EmojiLine.Y2 = 150;
            }
            else if(e.NewValue >= 50)
            {
                EmojiLine.X1 = 70;
                EmojiLine.X2 = 120;
                EmojiLine.Y1 = 150;
                EmojiLine.Y2 = 150;
            }
            else
            {
                EmojiLine.X1 = 100;
                EmojiLine.X2 = 100;
                EmojiLine.Y1 = 150;
                EmojiLine.Y2 = 150;
            }
        }
    }
}