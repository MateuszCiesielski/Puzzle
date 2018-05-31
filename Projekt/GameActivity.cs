using Android.App;
using Android.Widget;
using Android.OS;
using static Android.Views.View;
using Android.Views;
using System.Collections.Generic;
using System;
using Android.Hardware;
using Android.Views.Animations;

namespace Projekt
{
    [Activity(Label = "Projekt", MainLauncher = false)]
    public class GameActivity : Activity, IOnTouchListener, ISensorEventListener
    {
        private ImageView imageView;
        private List<ImageViewsAndCoords> imageViews = new List<ImageViewsAndCoords>();
        private float deltaX;
        private float deltaY;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Image1Game);

            // Accelerometer sensor registration
            var sensorManager = GetSystemService(SensorService) as SensorManager;
            var sensor = sensorManager.GetDefaultSensor(SensorType.Accelerometer);
            sensorManager.RegisterListener(this, sensor, SensorDelay.Game);

            // Shake Button Event
            Button shakeButton = FindViewById<Button>(Resource.Id.shakeButton);
            shakeButton.Click += (o, e) => { Shuffle(); };

            // Solve Button Event
            Button solveButton = FindViewById<Button>(Resource.Id.solveButton);
            solveButton.Click += (o, e) => { Solve(); };
        }

        public override void OnWindowFocusChanged(Boolean hasFocus)
        {
            base.OnWindowFocusChanged(hasFocus);

            SetCoordsAndTouchListener(); // can't get coordinates of views in OnCreate method
        }

        public bool OnTouch(View v, MotionEvent e) // moving views
        {
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    deltaX = v.GetX() - e.RawX;
                    deltaY = v.GetY() - e.RawY;
                    break;
                case MotionEventActions.Move:
                    v.Animate().X(e.RawX + deltaX).Y(e.RawY + deltaY).SetDuration(0).Start();
                    break;
                case MotionEventActions.Up:
                    Assist(v);
                    if (IsSuccess()) Toast.MakeText(this, "YOU WIN!!!", ToastLength.Long).Show();
                    break;
            }
            return true;
        }

        public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
        {
        }

        public void OnSensorChanged(SensorEvent e) // Shaking
        {
           // if (e.Sensor.Type == SensorType.Accelerometer) Shuffle();
        }

        private void Assist(View v)
        {
            foreach (var im in imageViews)
            {
                if ((Math.Abs(v.GetX() - im.X) < 50) && (Math.Abs(v.GetY() - im.Y) < 50))
                {
                    v.SetX(im.X);
                    v.SetY(im.Y);
                }
            }
        }

        private bool IsSuccess()
        {
            foreach (var im in imageViews)
            {
                if (!im.IsCoordOk()) return false;
            }
            return true;
        }

        private void Shuffle()
        {
            Random rnd = new Random();
            foreach (var im in imageViews)
            {
                float x, y, randX, randY;
                x = im.ImageView.GetX();
                y = im.ImageView.GetY();
                randX = (float)(rnd.NextDouble() * 300.0);
                randY = (float)(rnd.NextDouble() * 300.0);
                im.ImageView.Animate().X(randX).Y(randY).SetDuration(1500).Start();
            }
        }

        private void Solve()
        {
            foreach (var im in imageViews)
            {
                im.ImageView.Animate().X(im.X).Y(im.Y).SetDuration(1500).Start();
            }
        }

        private void SetCoordsAndTouchListener() // setting touch listener to views and generate instances of view classes
        {
            imageView = FindViewById<ImageView>(Resource.Id.im1);
            imageView.SetOnTouchListener(this);
            imageViews.Add(new ImageViewsAndCoords(imageView, imageView.GetX(), imageView.GetY()));
            imageView = FindViewById<ImageView>(Resource.Id.im2);
            imageView.SetOnTouchListener(this);
            imageViews.Add(new ImageViewsAndCoords(imageView, imageView.GetX(), imageView.GetY()));
            imageView = FindViewById<ImageView>(Resource.Id.im3);
            imageView.SetOnTouchListener(this);
            imageViews.Add(new ImageViewsAndCoords(imageView, imageView.GetX(), imageView.GetY()));
            imageView = FindViewById<ImageView>(Resource.Id.im4);
            imageView.SetOnTouchListener(this);
            imageViews.Add(new ImageViewsAndCoords(imageView, imageView.GetX(), imageView.GetY()));
            imageView = FindViewById<ImageView>(Resource.Id.im5);
            imageView.SetOnTouchListener(this);
            imageViews.Add(new ImageViewsAndCoords(imageView, imageView.GetX(), imageView.GetY()));
            imageView = FindViewById<ImageView>(Resource.Id.im6);
            imageView.SetOnTouchListener(this);
            imageViews.Add(new ImageViewsAndCoords(imageView, imageView.GetX(), imageView.GetY()));
            imageView = FindViewById<ImageView>(Resource.Id.im7);
            imageView.SetOnTouchListener(this);
            imageViews.Add(new ImageViewsAndCoords(imageView, imageView.GetX(), imageView.GetY()));
            imageView = FindViewById<ImageView>(Resource.Id.im8);
            imageView.SetOnTouchListener(this);
            imageViews.Add(new ImageViewsAndCoords(imageView, imageView.GetX(), imageView.GetY()));
            imageView = FindViewById<ImageView>(Resource.Id.im9);
            imageView.SetOnTouchListener(this);
            imageViews.Add(new ImageViewsAndCoords(imageView, imageView.GetX(), imageView.GetY()));
            imageView = FindViewById<ImageView>(Resource.Id.im10);
            imageView.SetOnTouchListener(this);
            imageViews.Add(new ImageViewsAndCoords(imageView, imageView.GetX(), imageView.GetY()));
            imageView = FindViewById<ImageView>(Resource.Id.im11);
            imageView.SetOnTouchListener(this);
            imageViews.Add(new ImageViewsAndCoords(imageView, imageView.GetX(), imageView.GetY()));
            imageView = FindViewById<ImageView>(Resource.Id.im12);
            imageView.SetOnTouchListener(this);
            imageViews.Add(new ImageViewsAndCoords(imageView, imageView.GetX(), imageView.GetY()));
            imageView = FindViewById<ImageView>(Resource.Id.im13);
            imageView.SetOnTouchListener(this);
            imageViews.Add(new ImageViewsAndCoords(imageView, imageView.GetX(), imageView.GetY()));
            imageView = FindViewById<ImageView>(Resource.Id.im14);
            imageView.SetOnTouchListener(this);
            imageViews.Add(new ImageViewsAndCoords(imageView, imageView.GetX(), imageView.GetY()));
            imageView = FindViewById<ImageView>(Resource.Id.im15);
            imageView.SetOnTouchListener(this);
            imageViews.Add(new ImageViewsAndCoords(imageView, imageView.GetX(), imageView.GetY()));
        }
    }
}