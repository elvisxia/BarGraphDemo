using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using MikePhil.Charting.Data;
using MikePhil.Charting.Charts;
using static Android.Views.ViewGroup;

namespace BarGraphDemo
{
    [Activity(Label = "BarGraphDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            BarChart barChart = new BarChart(this);
            barChart.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            var flag =new string[] { "First Bar,Second Bar","93,93.15" };
            //--this is response
            string[] strDate = flag[0].ToString().Split(',');
            string[] strValues = flag[1].ToString().Split(',');

            List<BarEntry> entries = new List<BarEntry>();

            for (int i = 0; i < strValues.Length; i++)
            {
                entries.Add(new BarEntry(float.Parse(strValues[i]), i));
            }

            BarDataSet dataset = new BarDataSet(entries, "");

            dataset.ValueTextSize = 15.0f;

            List<string> labels = new List<string>();

            for (int i = 0; i < strDate.Length; i++)
            {
                labels.Add(strDate[i].ToString());
            }

            BarData data = new BarData(labels, dataset);
            barChart.Data = data;
            barChart.SetDescription("");

            barChart.NotifyDataSetChanged();
            barChart.Invalidate();
            var root = FindViewById<LinearLayout>(Resource.Id.root);
            root.AddView(barChart);
        }
    }
}

