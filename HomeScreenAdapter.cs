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

            MyViewHolder holder;

            View view = convertView;

            Button buttonPlus;
            Button buttonMinu;
            EditText editTextOrderQty;
            

            if (view == null) // no view to re-use, create new
            {
                holder = new MyViewHolder();

                //Fragment
                //LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                //view = inflater.Inflate(Resource.Layout.CustomView, null);
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);

                //이 상태가 안전함.
                //##
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
                //##


                holder.BarcodeLabel = view.FindViewById<TextView>(Resource.Id.BarcodeLabel);
                holder.ProdName = view.FindViewById<TextView>(Resource.Id.ProdName);
                holder.OrderQty = view.FindViewById<EditText>(Resource.Id.OrderQty);
                //holder.ButtonPlus = view.FindViewById<Button>(Resource.Id.buttonPlus);
                //holder.ButtonMinus= view.FindViewById<Button>(Resource.Id.buttonMinus);
                holder.rowNum = position;

                view.Tag = holder;
            }
            else
            {
                holder = view.Tag as MyViewHolder;
                holder.rowNum = position;
            }

            holder.BarcodeLabel.Text = item.BarcodeLabel;
            holder.ProdName.Text = item.ProdName;
            holder.OrderQty.Text = item.OrderQty;

            //holder.ButtonPlus.Click += (object sender, EventArgs e) =>
            //{
            //    holder.OrderQty.Text = (Convert.ToInt32(holder.OrderQty.Text.Trim()) + 1).ToString();
            //};

            //holder.ButtonMinus.Click += (object sender, EventArgs e) =>
            //{
            //    holder.OrderQty.Text = (Convert.ToInt32(holder.OrderQty.Text.Trim()) - 1).ToString();
            //};

            MyTextWatcher watcher = new MyTextWatcher(holder, items);
            holder.OrderQty.AddTextChangedListener(watcher);



            //holder.BarcodeLabel.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            //{
            //    items[holder.rowNum].BarcodeLabel = e.Text.ToString();
            //};

            //holder.ProdName.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            //{
            //    items[holder.rowNum].ProdName = e.Text.ToString();
            //};


            return view;
        }
    }
}