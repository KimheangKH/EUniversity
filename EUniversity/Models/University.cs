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
    class University: Java.Lang.Object
    {
        public int ID { get; set; }
        public string[] items { get; set; }
        
    }
}
