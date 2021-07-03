using System;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Graphics;

namespace QrData
{
    public class DetailAdapter : ArrayAdapter
    {
        public DetailAdapter(Context context, int textViewResourceId) : base(context, textViewResourceId)
        {
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            string[] item = (string[])GetItem(position);
            if (convertView == null)
            {
                convertView = LayoutInflater.From(Context).Inflate(Resource.Layout.detailData, parent, false);
                SetupButton(convertView);
            }
            TextView name = (TextView)convertView.FindViewById(Resource.Id.nameText);
            TextView date = (TextView)convertView.FindViewById(Resource.Id.dateText);
            TextView price = (TextView)convertView.FindViewById(Resource.Id.priceValue);
            TextView priceTitle = (TextView)convertView.FindViewById(Resource.Id.priceTitle);
            TextView unTaxed = (TextView)convertView.FindViewById(Resource.Id.unTaxedValue);
            TextView unTaxedTitle = (TextView)convertView.FindViewById(Resource.Id.unTaxedTitle);
            TextView tax = (TextView)convertView.FindViewById(Resource.Id.taxValue);
            TextView taxTitle = (TextView)convertView.FindViewById(Resource.Id.taxTitle);
            convertView.TransitionName = item[0];
            convertView.SetBackgroundColor(position % 2 == 0 ? Color.LightGoldenrodYellow : Color.LightCyan);
            name.Text = item[1];
            date.Text = item[2].Substring(3, 2) + "月";
            if (item[2].Length > 5)
            {
                date.Text += item[2].Substring(5, 2) + "日";
            }
            else
            {
                date.Text = "(手動)" + date.Text;
            }
            price.Text = item[3];
            unTaxed.Text = item[4];
            tax.Text = item[5];
            var fontSize = Variable.CurFontSize switch
            {
                (int)Variable.FontSize.Big => Variable.FontSizeBig,
                (int)Variable.FontSize.Medium => Variable.FontSizeMedium,
                (int)Variable.FontSize.Small => Variable.FontSizeSmall,
                _ => Variable.FontSizeBig,
            };
            name.TextSize = fontSize + 13;
            date.TextSize = fontSize + 13;
            price.TextSize = fontSize;
            priceTitle.TextSize = fontSize;
            unTaxed.TextSize = fontSize;
            unTaxedTitle.TextSize = fontSize;
            tax.TextSize = fontSize;
            taxTitle.TextSize = fontSize;
            return convertView;
        }

        void SetupButton(View view)
        {
            Button modifyButton = (Button)view.FindViewById(Resource.Id.modifyButton);
            Button deleteButton = (Button)view.FindViewById(Resource.Id.deleteButton);
            modifyButton.Click += (sender, args) =>
            {
                MainActivity.Instance.ShowMessage(Variable.ResultType.ModifyDetail, view.TransitionName);
            };
            deleteButton.Click += (sender, args) =>
            {
                MainActivity.Instance.ShowMessage(Variable.ResultType.ClearDetail, view.TransitionName);
            };
        }
    }
}