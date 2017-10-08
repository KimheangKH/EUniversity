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
namespace EUniversity.Adapters
{
    class ListAdapter:BaseAdapter
    {
        private Activity activity;
        public List<University> university;
        public ListAdapter (Activity act,List<University> Schoool)
        {
            activity = act;
            university=Schoool;
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return university[position];
        }

        public override long GetItemId(int position)
        {
            return university[position].ID;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.University, parent, false);
            return view;
        }
        public override int Count => university.Count;
    }
    }
