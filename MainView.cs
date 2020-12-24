using System;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Views.InputMethods;

namespace QrData
{
    public class MainView
    {
        ListView listView;
        QrDataAdapter adapter;
        Toast toast;
        public MainView()
        {
            SetupUI();
            SetupListView();
        }

        public void ShowMessage(Variable.ResultStruct result)
        {
            var messageType = Variable.MessageType.Toast;
            var lengthType = ToastLength.Short;
            var textColor = Color.White;
            var bgColor = Color.DarkGray;
            bool shouldSpeak = false;
            Func<object> dialogPositive = null;
            Func<object> dialogNagative = null;
            string message;
            switch (result.Type)
            {
                case Variable.ResultType.LeaveApp:
                    message = "確定離開？\n (離開後將會清空資料)";
                    messageType = Variable.MessageType.Dialog;
                    dialogPositive = () =>
                    {
                        MainActivity.Instance.Finish();
                        Environment.Exit(0);
                        return null;
                    };
                    dialogNagative = () =>
                    {
                        return null;
                    };
                    break;
                case Variable.ResultType.ScanSuccess:
                    message = result.Value;
                    lengthType = ToastLength.Long;
                    bgColor = Color.SeaGreen;
                    shouldSpeak = true;
                    break;
                case Variable.ResultType.Clear:
                    message = "確定要清空此筆資料？";
                    messageType = Variable.MessageType.Dialog;
                    dialogPositive = () =>
                    {
                        var resultStruct = MainData.ClearData(result.Value);
                        UpdateListView();
                        ShowMessage(resultStruct);
                        return null;
                    };
                    dialogNagative = () =>
                    {
                        return null;
                    };
                    break;
                case Variable.ResultType.ClearAll:
                    message = "確定要清空全部資料？";
                    messageType = Variable.MessageType.Dialog;
                    dialogPositive = () =>
                    {
                        var resultStruct = MainData.ClearAllData();
                        UpdateListView();
                        ShowMessage(resultStruct);
                        return null;
                    };
                    dialogNagative = () =>
                    {
                        return null;
                    };
                    break;
                case Variable.ResultType.ClearSuccess:
                    message = "刪除成功";
                    break;
                case Variable.ResultType.ClearFailed:
                    message = "刪除失敗";
                    break;
                case Variable.ResultType.ClearBeforeEdit:
                    message = "請先清空資料";
                    break;
                case Variable.ResultType.UuidExist:
                    message = "已掃描過";
                    lengthType = ToastLength.Long;
                    textColor = Color.Black;
                    bgColor = Color.LightYellow;
                    shouldSpeak = true;
                    break;
                case Variable.ResultType.BuyerIdUnvalid:
                    message = "無效統編";
                    break;
                case Variable.ResultType.BuyerIdEmpty:
                    message = "沒有統編";
                    lengthType = ToastLength.Long;
                    bgColor = Color.Black;
                    shouldSpeak = true;
                    break;
                case Variable.ResultType.BuyerIdNotMatch:
                    message = "統編不同";
                    lengthType = ToastLength.Long;
                    bgColor = Color.LightSkyBlue;
                    shouldSpeak = true;
                    break;
                case Variable.ResultType.TaxExceed500:
                    message = "500元以上";
                    lengthType = ToastLength.Long;
                    bgColor = Color.Purple;
                    shouldSpeak = true;
                    break;
                case Variable.ResultType.TaxBelow500:
                    message = "500元以下";
                    lengthType = ToastLength.Long;
                    bgColor = Color.Purple;
                    shouldSpeak = true;
                    break;
                case Variable.ResultType.TaxOffsetExceed2:
                    message = result.Value + "\n超過2元";
                    lengthType = ToastLength.Long;
                    bgColor = Color.Red;
                    shouldSpeak = true;
                    break;
                default:
                    message = result.Value;
                    break;
            }
            switch (messageType)
            {
                case Variable.MessageType.Toast:
                    ShowToast(message, lengthType, textColor, bgColor, shouldSpeak);
                    break;
                case Variable.MessageType.Dialog:
                    ShowDialog(message, dialogPositive, dialogNagative);
                    break;
                default:
                    break;
            }
        }

        public void ShowToast(string message, ToastLength length, Color textColor, Color bgColor, bool shouldSpeak)
        {
            if (toast != null) toast.Cancel();
            toast = Toast.MakeText(MainActivity.Instance, message, length);
            ViewGroup group = (ViewGroup)toast.View;
            TextView text = (TextView)group.GetChildAt(0);
            text.SetTextColor(textColor);
            text.TextSize = length == ToastLength.Short ? 30 : 40;
            text.Gravity = GravityFlags.CenterHorizontal;
            toast.View.Background.SetColorFilter(bgColor, PorterDuff.Mode.SrcIn);
            toast.SetGravity(GravityFlags.Center, 0, 0);
            toast.Show();
            if (shouldSpeak) MainActivity.Instance.OnSpeak(message);
        }

        public void ShowDialog(string message, Func<object> positive, Func<object> nagative)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.Instance);
            builder.SetTitle("注意");
            builder.SetPositiveButton("確定", (sender, args) =>
            {
                positive();
                builder.Dispose();
            });
            if (nagative != null)
            {
                builder.SetNegativeButton("返回", (sender, args) =>
                {
                    nagative();
                    builder.Dispose();
                });
            }
            builder.SetMessage(message);
            var dialog = builder.Show();
            TextView messageText = (TextView)dialog.FindViewById(Android.Resource.Id.Message);
            messageText.TextSize = 20;
        }

        public void ShowChooseFontSize()
        {
            string[] items = new string[3] { "大", "中", "小" };
            AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.Instance);
            builder.SetTitle("選擇字體大小");
            builder.SetSingleChoiceItems(items, 3, MainActivity.Instance.OnClickFontSize);
            builder.SetPositiveButton("確定", (sender, args) =>
            {
                Variable.CurFontSize = Variable.TempFontSize;
                builder.Dispose();
            });
            builder.SetNegativeButton("返回", (sender, args) =>
            {
                builder.Dispose();
            });
            builder.Show();
        }

        void SetupUI()
        {
            Button scanButton = MainActivity.Instance.FindViewById<Button>(Resource.Id.scanButton);
            Button clearButton = MainActivity.Instance.FindViewById<Button>(Resource.Id.clearButton);
            EditText idEditText = MainActivity.Instance.FindViewById<EditText>(Resource.Id.buyerIdText);
            CheckBox tax500CheckBox = MainActivity.Instance.FindViewById<CheckBox>(Resource.Id.tax500CheckBox);
            scanButton.Click += (sender, args) =>
            {
                if (Variable.CheckIdValid(idEditText.Text))
                {
                    Variable.CurQrCode = "";
                    Variable.CurBuyerId = idEditText.Text;
                    Intent intent = new Intent(MainActivity.Instance, typeof(CameraATY));
                    MainActivity.Instance.StartActivityForResult(intent, (int)Variable.RequestCode.Camera);
                }
                else
                {
                    ShowMessage(new Variable.ResultStruct(Variable.ResultType.BuyerIdUnvalid, null));
                }

            };
            clearButton.Click += (sender, args) =>
            {
                ShowMessage(new Variable.ResultStruct(Variable.ResultType.ClearAll, null));
            };
            idEditText.LongClick += (sender, args) =>
            {
                if (MainData.BuyerDic.Count > 0)
                {
                    ShowMessage(new Variable.ResultStruct(Variable.ResultType.ClearBeforeEdit, null));
                    InputMethodManager imm = (InputMethodManager)MainActivity.Instance.GetSystemService(Context.InputMethodService);
                    imm.HideSoftInputFromWindow(idEditText.WindowToken, 0);
                }
            };
            idEditText.Click += (sender, args) =>
            {
                if (MainData.BuyerDic.Count > 0)
                {
                    ShowMessage(new Variable.ResultStruct(Variable.ResultType.ClearBeforeEdit, null));
                    InputMethodManager imm = (InputMethodManager)MainActivity.Instance.GetSystemService(Context.InputMethodService);
                    imm.HideSoftInputFromWindow(idEditText.WindowToken, 0);
                }
            };
            tax500CheckBox.Click += (sender, args) =>
            {
                if (MainData.BuyerDic.Count > 0)
                {
                    ShowMessage(new Variable.ResultStruct(Variable.ResultType.ClearBeforeEdit, null));
                    tax500CheckBox.Checked = !tax500CheckBox.Checked;
                }
                else
                    Variable.Tax500Mode = tax500CheckBox.Checked;
            };
        }

        void SetupListView()
        {
            adapter = new QrDataAdapter(MainActivity.Instance, Resource.Id.text);
            listView = (ListView)MainActivity.Instance.FindViewById(Resource.Id.listView);
            listView.Adapter = adapter;
            listView.ItemLongClick += (sender, args) =>
            {
                string id = args.View.Id.ToString();
                ShowMessage(new Variable.ResultStruct(Variable.ResultType.Clear, id));
            };
        }

        public void UpdateListView()
        {
            adapter.Clear();
            var allData = MainData.GetAllData();
            if (allData != null)
            {
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
