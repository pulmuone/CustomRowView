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
using Java.Lang;

namespace CustomRowView
{
    public class TableItem
    {
        public string BarcodeLabel { get; set; }
        public string ProdName { get; set; }
        public string OrderQty { get; set; }
    }
}