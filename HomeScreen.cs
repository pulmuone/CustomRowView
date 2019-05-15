using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Java.Interop;
using Android.Util;

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
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456786", ProdName = "스타벅스 커피", OrderQty = "6" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456787", ProdName = "사이다", OrderQty = "7" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456788", ProdName = "풀무원 녹즙", OrderQty = "8" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456789", ProdName = "아이스크림", OrderQty = "9" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456790", ProdName = "식초", OrderQty = "10" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456791", ProdName = "우유", OrderQty = "11" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456792", ProdName = "바나나", OrderQty = "12" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456793", ProdName = "사과", OrderQty = "13" });


            listView.Adapter = new HomeScreenAdapter(this, tableItems);

            listView.ItemClick += OnListItemClick;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            View view;
            EditText OrderQty;

            //int RowCount = listView.Adapter.Count;
            //for (int i = 0; i < RowCount; i++)
            //{
            //    view = listView.GetChildAt(i);
            //    OrderQty = view.FindViewById<EditText>(Resource.Id.OrderQty);

            //    Console.WriteLine(i.ToString());
            //}

            for (int i = 0; i < tableItems.Count; i++)
            {
                Log.Debug("Result :", string.Format("{0}, {1}", tableItems[i].BarcodeLabel, tableItems[i].OrderQty));
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