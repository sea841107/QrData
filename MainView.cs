using Android.App;
using Android.Widget;
using Android.Content;

namespace QrData
{
    public class MainView
    {
        AlertDialog.Builder dialog;
        ListView listView;
        QrDataAdapter adapter;
        public MainView()
        {
            SetupUI();
            SetupListView();
            SetupDialog();
        }

        public void ShowMessage(Variable.ResultType type)
        {
            dialog = new AlertDialog.Builder(MainActivity.Instance);
            dialog.SetTitle("注意");
            dialog.SetPositiveButton("OK", (sender, args) => { });
            string str;
            switch (type)
            {
                case Variable.ResultType.Success:
                    str = "掃描成功！";
                    break;
                case Variable.ResultType.Delete:
                    str = "確定要清空此資料？";
                    break;
                case Variable.ResultType.UuidExist:
                    str = "此發票已掃描過！";
                    break;
                case Variable.ResultType.BuyerIdUnvalid:
                    str = "請輸入長度8位的有效統編！";
                    break;
                case Variable.ResultType.BuyerIdEmpty:
                    str = "此發票無統編！";
                    break;
                case Variable.ResultType.BuyerIdNotMatch:
                    str = "此發票的統編與輸入的統編不一樣！";
                    break;
                case Variable.ResultType.TaxExceed500:
                    str = "此發票稅額超過500元！";
                    break;
                case Variable.ResultType.TaxOffsetExceed2:
                    str = "累計稅額與總計稅額差超過2元！";
                    break;
                default:
                    str = "測試用訊息！";
                    break;
            }
            //if (type == Variable.ResultType.Success)
            //{
            //    Toast.MakeText(MainActivity.Instance, str, ToastLength.Short).Show();
            //}
            //else
            //{
            //    dialog.SetMessage(str);
            //    dialog.Show();
            //}
            Toast.MakeText(MainActivity.Instance, str, ToastLength.Short).Show();
        }

        void SetupUI()
        {
            Button scanButton = MainActivity.Instance.FindViewById<Button>(Resource.Id.scanButton);
            EditText idEditText = MainActivity.Instance.FindViewById<EditText>(Resource.Id.buyerIdText);
            scanButton.Click += (sender, e) =>
            {
                if (idEditText.Text == "" || idEditText.Text.Length != 8)
                {
                    ShowMessage(Variable.ResultType.BuyerIdUnvalid);
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
            listView.ItemLongClick += (sender, e) =>
            {
                ShowMessage(Variable.ResultType.Delete);
            };
        }

        void SetupDialog()
        {
            dialog = new AlertDialog.Builder(MainActivity.Instance);
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
