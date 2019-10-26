using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
namespace ClientXamarin.Android
{
    [Activity(Label = "ClientXamarin.Android", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
    
            base.OnCreate(savedInstanceState);
    
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new Portable.App());

            AppCenter.Start("4992d493-4d5b-41c9-9132-b8de3c690cf5;", typeof(Analytics), typeof(Crashes));
        }
    }
}