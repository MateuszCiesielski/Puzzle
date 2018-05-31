using Android.App;
using Android.Widget;
using Android.OS;

namespace Projekt
{
    [Activity(Label = "Projekt", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var newGameButton = FindViewById<Button>(Resource.Id.newGameButton);
            var closeGameButton = FindViewById<Button>(Resource.Id.closeGameButton);

            newGameButton.Click += (o, e) => { StartActivity(typeof(GameActivity)); };
            closeGameButton.Click += (o, e) => { Finish(); };
        }
    }
}

