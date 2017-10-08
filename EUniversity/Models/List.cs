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

namespace EUniversity.Models
{
    [Activity(Label = "ListActivity")]
    public class ListActivity1 : ListActivity
    {
        
        public string[] items;
        ListView listSchool;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            listSchool = FindViewById<ListView>(Resource.Id.listUniversity );
            items = new string[] { "សាកលវិទ្យាល័យន័រតុន", "សាកលវិទ្យាល័យពុទ្ធិសាស្រ្ត", "សាកលវិទ្យាល័យភូមិន្នភ្នំពេញ", "សាកលវិទ្យាល័យបែលធី​ អន្តរជាតិ", "សាកលវិទ្យាល័យជាតើគ្រប់គ្រង", "សាកលវិទ្យាល័យមេគង្គកម្ពុជា" };
            ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
            
        }
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var t = items[position];
            if (t.Trim() == "សាកលវិទ្យាល័យន័រតុន")
            {
                    
            }
            Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Short).Show();
        }
 
    }
}