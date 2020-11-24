using System;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.Content;

namespace QrData
{
    public class MainView
    {
        ListView listView;
        QrDataAdapter adapter;
        public MainView()
        {
            SetupUI();
            SetupListView();
        }

        public void ShowMessage(Variable.ResultType resultType, string value)
        {
            var messageType = Variable.MessageType.Toast;
            Func<object> dialogPositive = null;
            Func<object> dialogNagative = null;
            string message;
            switch (resultType)
            {
                case Variable.ResultType.LeaveApp:
                    message = "確定離開？";
                    messageType = Variable.MessageType.Dialog;
                    dialogPositive = () =>
                    {
                        MainActivity.Instance.FinishAndRemoveTask();
                        return null;
                    };
                    dialogNagative = () =>
                    {
                        return null;
                    };
                    break;
                case Variable.ResultType.Success:
                    message = "掃描成功！";
                    break;
                case Variable.ResultType.Delete:
                    message = "確定要清空此資料？";
                    messageType = Variable.MessageType.Dialog;
                    dialogPositive = () =>
                    {
                        var result = MainData.DeleteData(value);
                        UpdateListView();
                        ShowMessage(result, null);
                        return null;
                    };
                    dialogNagative = () =>
                    {
                        return null;
                    };
                    break;
                case Variable.ResultType.DeleteSuccess:
                    message = "刪除成功！";
                    break;
                case Variable.ResultType.DeleteFailed:
                    message = "刪除失敗！";
                    break;
                case Variable.ResultType.UuidExist:
                    message = "此發票已掃描過！";
                    break;
                case Variable.ResultType.BuyerIdUnvalid:
                    message = "請輸入長度8位的有效統編！";
                    break;
                case Variable.ResultType.BuyerIdEmpty:
                    message = "此發票無統編！";
                    break;
                case Variable.ResultType.BuyerIdNotMatch:
                    message = "此發票的統編與輸入的統編不一樣！";
                    break;
                case Variable.ResultType.TaxExceed500:
                    message = "此發票稅額超過500元！";
                    break;
                case Variable.ResultType.TaxOffsetExceed2:
                    message = "累計稅額與總計稅額差超過2元！";
                    break;
                default:
                    message = "測試用訊息！";
                    break;
            }
            switch (messageType)
            {
                case Variable.MessageType.Toast:
                    ShowToast(message);
                    break;
                case Variable.MessageType.Dialog:
                    ShowDialog(message, dialogPositive, dialogNagative);
                    break;
                default:
                    break;
            }
        }

        public void ShowToast(string message)
        {

            Toast.MakeText(MainActivity.Instance, message, ToastLength.Short).Show();
        }

        public void ShowDialog(string message, Func<object> positive, Func<object> nagative)
        {
            AlertDialog.Builder dialog = new AlertDialog.Builder(MainActivity.Instance);
            dialog.SetTitle("注意");
            dialog.SetPositiveButton("確定", (sender, args) =>
            {
                positive();
                dialog.Dispose();
            });
            if (nagative != null)
            {
                dialog.SetNegativeButton("返回", (sender, args) =>
                {
                    nagative();
                    dialog.Dispose();
                });
            }
            dialog.SetMessage(message);
            dialog.Show();
        }

        void SetupUI()
        {
            Button scanButton = MainActivity.Instance.FindViewById<Button>(Resource.Id.scanButton);
            EditText idEditText = MainActivity.Instance.FindViewById<EditText>(Resource.Id.buyerIdText);
            scanButton.Click += (sender, args) =>
            {
                if (idEditText.Text.Length != 8 || idEditText.Text == "" || idEditText.Text == Variable.EmptyId)
                {
                    ShowMessage(Variable.ResultType.BuyerIdUnvalid, null);
                }
                else
                {
                    Variable.CurBuyerId = idEditText.Text;
                    var intentCameraATY = new Intent(MainActivity.Instance, typeof(CameraATY));
                    MainActivity.Instance.StartActivityForResult(intentCameraATY, (int)Variable.RequestCode.Camera);
                }

            };
        }

        void SetupListView()
        {
            adapter = new QrDataAdapter(MainActivity.Instance, Resource.Id.dateText);
            listView = (ListView)MainActivity.Instance.FindViewById(Resource.Id.listView);
            listView.Adapter = adapter;
            listView.ItemLongClick += (sender, args) =>
            {
                string id = args.View.Id.ToString();
                ShowMessage(Variable.ResultType.Delete, id);
            };
        }

        public void UpdateListView()
        {
            var allData = MainData.GetAllData();
            if (allData != null)
            {
                adapter.Clear();
                foreach (var data in allData.OrderBy(obj => obj.Key))
                {
                    string[] dataStr = new string[6];
                    dataStr[0] = data.Key.ToString();
                    dataStr[1] = data.Value.Amount.ToString();
                    dataStr[2] = data.Value.Price.ToString();
                    dataStr[3] = data.Value.UnTaxedPrice.ToString();
                    dataStr[4] = data.Value.Tax.ToString();
                    dataStr[5] = data.Value.ToLimit.ToString();
                    adapter.Add(dataStr);
                }
            }
        }
    }
}
