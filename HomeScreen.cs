using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Java.Interop;

namespace CustomRowView {
    [Activity(Label = "CustomRowView", MainLauncher = true, Icon = "@drawable/icon")]
    public class HomeScreen : Activity
    {//, View.IOnClickListener {

        List<TableItem> tableItems = new List<TableItem>();
        ListView listView;

        Button button1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.HomeScreen);
            listView = FindViewById<ListView>(Resource.Id.List);
            button1 = FindViewById<Button>(Resource.Id.button1);

            button1.Click += Button1_Click;

            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456781", ProdName = "신라면", OrderQty = "1" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456782", ProdName = "코카콜라", OrderQty = "2" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456783", ProdName = "풀무원 두부", OrderQty = "3" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456784", ProdName = "대상 두부", OrderQty = "4" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456785", ProdName = "CJ부두", OrderQty = "5" });
            //tableItems.Add(new TableItem() { BarcodeLabel = "8809123456786", ProdName = "스타벅스 커피", OrderQty = "6" });


            listView.Adapter = new HomeScreenAdapter(this, tableItems);

            listView.ItemClick += OnListItemClick;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            View view;
            EditText OrderQty;

            int RowCount = listView.Adapter.Count;
            for (int i = 0; i < RowCount; i++)
            {
                view = listView.GetChildAt(i);
                OrderQty = view.FindViewById<EditText>(Resource.Id.OrderQty);

                Console.WriteLine(i.ToString());
            }


        }

        protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = tableItems[e.Position];
            //Android.Widget.Toast.MakeText(this, t.Heading, Android.Widget.ToastLength.Short).Show();
            //Console.WriteLine("Clicked on " + t.Heading);

            //Console.WriteLine(t.Heading);
            //Console.WriteLine(t.OrderQty);
        }
    }
}