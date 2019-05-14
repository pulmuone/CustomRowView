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
    public class HomeScreenAdapter : BaseAdapter<TableItem>
    {
        List<TableItem> items;
        Activity context;
        public HomeScreenAdapter(Activity context, List<TableItem> items) : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override TableItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            View view = convertView;
            Button buttonPlus;
            Button buttonMinu;
            EditText editTextOrderQty;
            

            if (view == null) // no view to re-use, create new
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);

                view.FindViewById<TextView>(Resource.Id.BarcodeLabel).Text = item.BarcodeLabel;
                view.FindViewById<TextView>(Resource.Id.ProdName).Text = item.ProdName;
                view.FindViewById<EditText>(Resource.Id.OrderQty).Text = item.OrderQty;

                editTextOrderQty = view.FindViewById<EditText>(Resource.Id.OrderQty);

                buttonPlus = view.FindViewById<Button>(Resource.Id.buttonPlus);
                buttonPlus.Click += (object sender, EventArgs e) =>
                {
                    editTextOrderQty.Text = (Convert.ToInt32(editTextOrderQty.Text.Trim()) + 1).ToString();
                };


                buttonMinu = view.FindViewById<Button>(Resource.Id.buttonMinus);
                buttonMinu.Click += (object sender, EventArgs e) =>
                {
                    editTextOrderQty.Text = (Convert.ToInt32(editTextOrderQty.Text.Trim()) - 1) <= 0 ? "0" : (Convert.ToInt32(editTextOrderQty.Text.Trim()) - 1).ToString();
                };

                editTextOrderQty.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
                {
                    Console.WriteLine(e.Text);
                    item.OrderQty = e.Text.ToString();
                };

            }

            return view;
        }
    }
}