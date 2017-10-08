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
using Com.Joanzapata.Pdfview;

namespace EUniversity
{
    [Activity(Label = "NU")]
    public class NU : Activity
    {
        PDFView PdfNU;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Norton);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            PdfNU = FindViewById<PDFView>(Resource.Id.PdfNU);
            PdfNU.FromAsset("Test.pdf").Load();
            SetActionBar(toolbar);
            ActionBar.Title = "សាកលវិទ្យាល័យន័រតុន";
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
            //    ToastLength.Short).Show();
            var itemId = item.ItemId;
            switch (itemId)
            {
                case Resource.Id.menu_about:
                    {
                        Intent intent = new Intent(this, typeof(MainClickAbout));
                        this.StartActivity(intent);
                        break;
                    }


                case Resource.Id.nav_ProvinceSchool:
                    {
                        Intent intent = new Intent(this, typeof(MainProvinceBranch));
                        this.StartActivity(intent);
                        break;
                    }

                case Resource.Id.nav_SkillInfo:
                    {
                        Intent intent = new Intent(this, typeof(SchoolMajor));
                        this.StartActivity(intent);
                        break;
                    }

                case Resource.Id.nav_School:
                    {
                        Intent intent = new Intent(this, typeof(MainUniversity));
                        this.StartActivity(intent);
                        break;
                    }
               
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}