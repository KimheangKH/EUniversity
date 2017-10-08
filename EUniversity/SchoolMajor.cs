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
    [Activity(Label = "SchoolMajor")]
    public class SchoolMajor : Activity
    {
        ExpandableListAdapter listAdapter;
        ExpandableListView expListView;
        List<string> listDataHeader;
        Dictionary<string, List<string>> listDataChild;
        int previousGroup = -1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SchoolMajor);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "មុខជំនាញទូទៅរបស់គ្រឹះស្ថាន";
            expListView = FindViewById<ExpandableListView>(Resource.Id.lvExp);
            
            // Prepare list data
            FnGetListData();

            //Bind list
            listAdapter = new ExpandableListAdapter(this, listDataHeader, listDataChild);
            expListView.SetAdapter(listAdapter);
           
            FnClickEvents();
            expListView.ChildClick += OnChild_Click;
        }
        private void OnChild_Click(object sender,ExpandableListView.ChildClickEventArgs e)
        {
            var keys = listDataHeader[e.GroupPosition];
            var listValue = listDataChild[keys];
            var child = listValue[e.ChildPosition].Trim();
            if (child == listValue[4])// not right all
            {
                Intent intent = new Intent(this,typeof(SD));
                this.StartActivity(intent);
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
        void FnClickEvents()// child click event
        {
            //Listening to child item selection
            //expListView.ChildClick += delegate (object sender, ExpandableListView.ChildClickEventArgs e) {
            //    Toast.MakeText(this, "child clicked", ToastLength.Short).Show();
            //};

            //Listening to group expand
            //modified so that on selection of one group other opened group has been closed
            expListView.GroupExpand += delegate (object sender, ExpandableListView.GroupExpandEventArgs e) {

                if (e.GroupPosition != previousGroup)
                    expListView.CollapseGroup(previousGroup);
                previousGroup = e.GroupPosition;
            };

            //Listening to group collapse
            expListView.GroupCollapse += delegate (object sender, ExpandableListView.GroupCollapseEventArgs e) {
                //Toast.MakeText(this, "group collapsed", ToastLength.Short).Show();
            };

        }
        void FnGetListData()
        {
            listDataHeader = new List<string>();
            listDataChild = new Dictionary<string, List<string>>();

            // Adding child data
            listDataHeader.Add("កុំព្យូទ័រវិទ្យា");
            listDataHeader.Add("វិស្វកម្មអគ្គសនី នឹង អេឡិចត្រូនិច");
            listDataHeader.Add("ស្ថាបត្យកម្ម នឹង នគរូបនីយកម្ម");
            listDataHeader.Add("វិស្វកម្មសំណង់ស៊ីវិល");
            listDataHeader.Add("និតីសាស្រ្ត");
            listDataHeader.Add("អង់គ្លេស");
            listDataHeader.Add("គ្រប់គ្រងបដសណ្ឋារកិច្ច នឹង ទេសចរណ៍");
            listDataHeader.Add("សេដ្ឋកិច្ច");
            listDataHeader.Add("គណិតវិទ្យា");
            listDataHeader.Add("វិស្វកម្មជីវសាស្រ្ត");
            listDataHeader.Add("ទេសចរណ៍");
            listDataHeader.Add("ជីវសាស្រ្ត");
            // Adding child data
            var lstCS = new List<string>();
            lstCS.Add("វិទ្យាសាស្រ្តកុំព្យូទ័រ");
            lstCS.Add("គ្រប់គ្រងប្រព័ន្ធពត៌មានវិទ្យា");
            lstCS.Add("វិស្វកម្មបណ្ដាញកុំព្យូទ័រ នឹង សុវត្ថិភាព");
            lstCS.Add("រចនាប្រព័ន្ធផ្សព្វផ្សាយ នឹង គេហទំព័រ");
            lstCS.Add("អភិវឌ្ឈន៍កម្មវិធី​​");     
            var lstEC = new List<string>();
            lstEC.Add("Field Theory");
            lstEC.Add("Logic Design");
            lstEC.Add("Analog electronics");
            lstEC.Add("Network analysis");
            lstEC.Add("Micro controller");
            lstEC.Add("Signals and system");
            var lstMech = new List<string>();
            lstMech.Add("Instrumentation technology");
            lstMech.Add("Dynamics of machinnes");
            lstMech.Add("Energy engineering");
            lstMech.Add("Design of machine");
            lstMech.Add("Turbo machine");
            lstMech.Add("Energy conversion");
            // Header, Child data
            listDataChild.Add(listDataHeader[0], lstCS);
            listDataChild.Add(listDataHeader[1], lstEC);
            listDataChild.Add(listDataHeader[2], lstMech);
        }
    }
}
