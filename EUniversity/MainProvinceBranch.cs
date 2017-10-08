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

namespace EUniversity
{
    [Activity(Label = "MainProvinceBranch")]
    public class MainProvinceBranch : Activity
    {
        ListView ListProvinceBranch;
        ArrayAdapter<string> ListAdapter;
        string[] items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProvinceBranch );
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "គ្រឹះស្ថានឧត្ដមសិក្សាតាមខេត្ត";
            ListProvinceBranch= FindViewById<ListView>(Resource.Id.listPrvinceBranch);
            ListProvinceBranch.ItemClick += OnItem_click;
            items = new string[] { "ខេត្តព្រៃវែង", "ខេត្តកំពង់ចាម", "ខេត្តសៀមរាប", "ខេត្តព្រះសីហនុ", "ខេត្តបាត់ដំបង", "ខេត្តតាកែវ", "ខេត្តរតនះគិរី", "ខេត្តកំពង់ធំ", "ខេត្តបន្ទាយមានជ័យ", "ខេត្តស្ទឹងត្រែង", "ខេត្តកំពត", "ខេត្តកំពង់ស្ពឺ" };
            ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
            ListProvinceBranch.Adapter = ListAdapter;
        }
        private void OnItem_click(object sender, AdapterView.ItemClickEventArgs e)
        {
            var University = items[e.Position].Trim();
            if (University == "ខេត្តកំពង់ចាម")
            {
                Intent Act = new Intent(this, typeof(KampongCham));
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