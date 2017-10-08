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
using EUniversity.Models;
namespace EUniversity
{
    [Activity(Label = "MainUniversity")]
    public class MainUniversity : Activity
    {
        ListView ListUniversity;
        ArrayAdapter<string> ListAdapter;
        string[] items;
        protected override void OnCreate(Bundle bundle)
        {
            SetContentView(Resource.Layout.University);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "គ្រឹះស្ថានឧត្ដមសិក្សា";
            base.OnCreate(bundle);
            ListUniversity  = FindViewById<ListView>(Resource.Id.listUniversity);
            ListUniversity.ItemClick += OnItem_click;
            items = new string[] { "សាកលវិទ្យាល័យន័រតុន", "សាកលវិទ្យាល័យពុទ្ធិសាស្រ្ត", "សាកលវិទ្យាល័យភូមិន្នភ្នំពេញ", "សាកលវិទ្យាល័យបែលធី​ អន្តរជាតិ", "សាកលវិទ្យាល័យជាតិគ្រប់គ្រង", "សាកលវិទ្យាល័យមេគង្គកម្ពុជា", "សាកលវិទ្យាល័យបញ្ញាសាស្រ្តកម្ពុជា", "សាកលវិទ្យាល័យបៀលប្រាយ", "សាកលវិទ្យាល័យអាស៊ីអ៊ឺរ៉ុប", "សាកលវិទ្យាល័យចេនឡា", "សាកលវិទ្យាល័យឯកទេសនៃកម្ពុជា", "សាកលវិទ្យាល័យធនធានមនុស្ស" };
            ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
            ListUniversity.Adapter = ListAdapter;
            //University.Add(School);
        }


        private void OnItem_click(object sender, AdapterView.ItemClickEventArgs e)
        {
            var University=items[e.Position].Trim() ;
            if (University== "សាកលវិទ្យាល័យន័រតុន")
            {
                Intent Act = new Intent(this,typeof(NU));
                this.StartActivity(Act);
            }
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