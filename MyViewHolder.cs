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

namespace CustomRowView
{
    public class MyViewHolder : Java.Lang.Object
    {

        //public Button ButtonPlus { get; set; }
        //public Button ButtonMinus { get; set; }
        public TextView BarcodeLabel { get; set; }
        public TextView ProdName { get; set; }
        public EditText OrderQty { get; set; }

        public int rowNum;

    }
}