using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;
using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
namespace EUniversity
{
    [Activity(Label = "EUniversity", Icon = "@drawable/splash")]
    public class MainActivity : Activity
    {
        ImageView imgProgrammer;
        ImageView imgUniversity;
        ImageView imgGeneralMajor;
        ImageView imgSchoolBranch;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            AppCenter.Start("873782ef-af58-439d-af68-b7a10962aa3b",
                   typeof(Analytics), typeof(Crashes));
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Home);
            //var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //SetActionBar(toolbar);
            //ActionBar.Title = "EUniversity";
            imgProgrammer = FindViewById<ImageView>(Resource.Id.imgProgrammer);
            imgGeneralMajor= FindViewById<ImageView>(Resource.Id.imgGeneralMajor);
            imgSchoolBranch= FindViewById<ImageView>(Resource.Id.imgProvinceBranch);
            imgUniversity= FindViewById<ImageView>(Resource.Id.imgUniversity);
            imgProgrammer.Click += ImgPrograme_Click;
            imgUniversity.Click += ImgUniversity_Click;
            imgSchoolBranch.Click += ImgSchoolBranch_Click;
            imgGeneralMajor.Click += ImgGeneralMajor_Click;
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }
        private void ImgPrograme_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainClickAbout));
            this.StartActivity(intent);
        }
        private void ImgGeneralMajor_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SchoolMajor));
            this.StartActivity(intent);
        }
        private void ImgSchoolBranch_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainProvinceBranch));
            this.StartActivity(intent);
        }
        private void ImgUniversity_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainUniversity));
            this.StartActivity(intent);
        }
    }
}

