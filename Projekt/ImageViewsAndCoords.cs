using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Projekt
{
    public class ImageViewsAndCoords
    {
        public ImageView ImageView { get; private set; } // view handle
        public float X { get; private set; } // initial coordinates of view
        public float Y { get; private set; }

        public ImageViewsAndCoords(ImageView imageView, float x, float y)
        {
            ImageView = imageView;
            X = x;
            Y = y;
        }

        public bool IsCoordOk() // check if view is on its initial place
        {
            if (ImageView.GetX() != X || ImageView.GetY() != Y) return false;
            return true;
        }
    }
}