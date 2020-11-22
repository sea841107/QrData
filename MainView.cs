using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.Views;
using Android.Content;
using Java.Lang;

namespace QrData
{
    public class MainView
    {
        MainActivity activity;
        AlertDialog.Builder dialog;
        ListView listView;
        QrDataAdapter adapter;
        public MainView(MainActivity activity)
        {
            this.activity = activity;
            SetupUI();
            SetupListView();
            SetupDialog();
        }

        public void ShowMessage(int type)
        {
            string str;
            switch (type)
            {
                case (int)Variable.ResultType.Success:
                    str = "掃描成功！";
                    break;
                case (int)Variable.ResultType.Delete:
                    str = "確定要清空此資料？";
                    break;
                case (int)Variable.ResultType.UuidExist:
                    str = "此發票已掃描過！";
                    break;
                case (int)Variable.ResultType.BuyerIdUnvalid:
                    str = "請輸入長度8位的統編！";
                    break;
                case (int)Variable.ResultType.BuyerIdEmpty:
                    str = "此發票無統編！";
                    break;
                case (int)Variable.ResultType.BuyerIdNotMatch:
                    str = "此發票的統編與輸入的統編不一樣！";
                    break;
                case (int)Variable.ResultType.TaxExceed500:
                    str = "此發票稅額超過500元！";
                    break;
                case (int)Variable.ResultType.TaxOffsetExceed2:
                    str = "累計稅額與總計稅額差超過2元！";
                    break;
                default:
                    str = "測試用訊息！";
                    break;
            }
            if (type == (int)Variable.ResultType.Success)
            {
                Toast.MakeText(activity, str, ToastLength.Short).Show();
            }
            else
            {
                dialog.SetMessage(str);
                dialog.Show();
            }
        }

        void SetupUI()
        {
            Button scanButton = activity.FindViewById<Button>(Resource.Id.scanButton);
            EditText idEditText = activity.FindViewById<EditText>(Resource.Id.buyerIdText);
            scanButton.Click += (sender, e) =>
            {
                if (idEditText.Text == "" || idEditText.Text.Length != 8)
                {
                    ShowMessage((int)Variable.ResultType.BuyerIdUnvalid);
                }
                else
                {
                    Variable.CurBuyerId = idEditText.Text;
                    var intentCameraATY = new Intent(activity, typeof(CameraATY));
                    activity.StartActivityForResult(intentCameraATY, (int)Variable.RequestCode.Camera);
                }

            };
        }

        void SetupListView()
        {
            adapter = new QrDataAdapter(activity, Resource.Id.dateText);
            listView = (ListView)activity.FindViewById(Resource.Id.listView);
            listView.Adapter = adapter;
            listView.ItemLongClick += (sender, e) =>
            {
                ShowMessage((int)Variable.ResultType.Delete);
            };
        }

        void SetupDialog()
        {
            dialog = new AlertDialog.Builder(activity);
            dialog.SetTitle("注意");
            dialog.SetPositiveButton("OK", (sender, args) => { });
        }

        public void UpdateListView()
        {
            var allData = MainData.GetAllData();
            if (allData != null)
            {
                adapter.Clear();
                foreach (var data in allData)
                {
                    string[] dataStr = new string[5];
                    dataStr[0] = data.Key.ToString();
                    dataStr[1] = data.Value.Amount.ToString();
                    dataStr[2] = data.Value.Price.ToString();
                    dataStr[3] = data.Value.UnTaxedPrice.ToString();
                    dataStr[4] = data.Value.Tax.ToString();
                    adapter.Add(dataStr);

                }
            }
        }
    }
}
