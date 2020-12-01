using System;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Graphics;

namespace QrData
{
    public class QrDataAdapter : ArrayAdapter
    {
        public QrDataAdapter(Context context, int textViewResourceId) : base(context, textViewResourceId)
        {
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            string[] item = (string[])GetItem(position);
            if (convertView == null)
            {
                convertView = LayoutInflater.From(Context).Inflate(Resource.Layout.data, parent, false);
            }
            TextView year = (TextView)convertView.FindViewById(Resource.Id.yearText);
            TextView month = (TextView)convertView.FindViewById(Resource.Id.monthText);
            TextView amount = (TextView)convertView.FindViewById(Resource.Id.amountValue);
            TextView total = (TextView)convertView.FindViewById(Resource.Id.totalValue);
            TextView unTaxed = (TextView)convertView.FindViewById(Resource.Id.unTaxedValue);
            TextView tax = (TextView)convertView.FindViewById(Resource.Id.taxValue);
            convertView.Id = Convert.ToInt32(item[0]);
            convertView.SetBackgroundColor(position % 2 == 0 ? Color.LightGoldenrodYellow : Color.LightCyan);
            year.Text = item[0].Substring(0, 3) + "年";
            month.Text = item[0][3..] + "月";
            amount.Text = item[1];
            total.Text = item[2];
            unTaxed.Text = item[3];
            tax.Text = item[4];
            if (item[5] == "True")
                convertView.SetBackgroundColor(Color.PaleVioletRed);
            return convertView;
        }
    }
}