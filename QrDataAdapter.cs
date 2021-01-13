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
            TextView amountTitle = (TextView)convertView.FindViewById(Resource.Id.amountTitle);
            TextView total = (TextView)convertView.FindViewById(Resource.Id.totalValue);
            TextView totalTitle = (TextView)convertView.FindViewById(Resource.Id.totalTitle);
            TextView unTaxed = (TextView)convertView.FindViewById(Resource.Id.unTaxedValue);
            TextView unTaxedTitle = (TextView)convertView.FindViewById(Resource.Id.unTaxedTitle);
            TextView tax = (TextView)convertView.FindViewById(Resource.Id.taxValue);
            TextView taxTitle = (TextView)convertView.FindViewById(Resource.Id.taxTitle);
            convertView.Id = Convert.ToInt32(item[0]);
            convertView.SetBackgroundColor(position % 2 == 0 ? Color.LightGoldenrodYellow : Color.LightCyan);
            year.Text = item[0].Substring(0, 3) + "年";
            month.Text = item[0][3..] + "月";
            amount.Text = item[1];
            total.Text = "";
            totalTitle.Text = "";
            unTaxed.Text = item[3];
            tax.Text = item[4];
            if (item[5] == "True")
                convertView.SetBackgroundColor(Color.LightPink);
            var fontSize = Variable.CurFontSize switch
            {
                (int)Variable.FontSize.Big => Variable.FontSizeBig,
                (int)Variable.FontSize.Medium => Variable.FontSizeMedium,
                (int)Variable.FontSize.Small => Variable.FontSizeSmall,
                _ => Variable.FontSizeBig,
            };
            year.TextSize = fontSize;
            month.TextSize = fontSize;
            amount.TextSize = fontSize;
            amountTitle.TextSize = fontSize;
            total.TextSize = fontSize;
            totalTitle.TextSize = fontSize;
            unTaxed.TextSize = fontSize;
            unTaxedTitle.TextSize = fontSize;
            tax.TextSize = fontSize;
            taxTitle.TextSize = fontSize;
            return convertView;
        }
    }
}