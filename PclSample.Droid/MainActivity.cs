using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Helpers;
using PclSample.Core.Models;
using PclSample.Core.ViewModels;

//using PclSample.Core.Models;
//using PclSample.Core.ViewModels;

namespace PclSample.Droid
{
    [Activity(Label = "PclSample.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    internal class MainActivity : Activity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            await Vm.InitAsync();

            // Get our button from the layout resource,
            // and attach an event to it
            PeopleListView.Adapter = Vm.People.GetAdapter(GetPersonView);
        }

        public ListView PeopleListView => FindViewById<ListView>(Resource.Id.PeopleListView);

        private MainViewModel Vm => Locator.Instance.MainViewModel;

        private View GetPersonView(int position, Person person, View convertView)
        {
            View view = convertView ?? LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);

            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = person.FullName;

            return view;
        }
    }
}

