﻿using System;
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
        ListView monthView, detailView;
        MonthAdapter monthAdapter;
        DetailAdapter detailAdapter;
        Toast toast;
        public MainView()
        {
            SetupUI();
            SetupMonthView();
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
                case Variable.ResultType.ClearMonth:
                    string year = result.Value[..3] + "年";
                    string month = result.Value[3..] + "月";
                    message = year + month + "\n確定要清空此筆資料？";
                    messageType = Variable.MessageType.Dialog;
                    dialogPositive = () =>
                    {
                        var resultStruct = MainData.ClearMonthData(result.Value);
                        UpdateMonthView();
                        ShowMessage(resultStruct);
                        return null;
                    };
                    dialogNagative = () =>
                    {
                        return null;
                    };
                    break;
                case Variable.ResultType.ClearDetail:
                    message = "確定要刪除此筆資料？";
                    messageType = Variable.MessageType.Dialog;
                    dialogPositive = () =>
                    {
                        var resultStruct = MainData.ClearDetailData(result.Value);
                        UpdateDetailView();
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
                        UpdateMonthView();
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
                case Variable.ResultType.AddDetail:
                    message = "新增資料";
                    messageType = Variable.MessageType.EditDialog;
                    break;
                case Variable.ResultType.AddSuccess:
                    message = "新增成功";
                    break;
                case Variable.ResultType.AddFailed:
                    message = "新增失敗";
                    break;
                case Variable.ResultType.ModifyDetail:
                    message = "修改資料";
                    messageType = Variable.MessageType.EditDialog;
                    break;
                case Variable.ResultType.ModifySuccess:
                    message = "修改成功";
                    break;
                case Variable.ResultType.ModifyFailed:
                    message = "修改失敗";
                    break;
                case Variable.ResultType.InvalidValue:
                    message = "值不能為空";
                    break;
                case Variable.ResultType.InvalidPriceTax:
                    message = "稅金大於總額";
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
                    message = "稅金" + result.Value;
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
                case Variable.ResultType.TaxEqual0:
                    message = "稅額為0";
                    lengthType = ToastLength.Long;
                    bgColor = Color.Orange;
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
                case Variable.MessageType.EditDialog:
                    ShowEditDialog(message, result.Value);
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

        public void ShowEditDialog(string message, string value)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.Instance);
            builder.SetMessage(message);
            var detailData = MainData.GetDetailData(value);
            LinearLayout.LayoutParams matchParams = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            LinearLayout.LayoutParams wrapParams = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent)
            {
                LeftMargin = 50
            };
            LinearLayout outsideLayout = new LinearLayout(MainActivity.Instance)
            {
                LayoutParameters = matchParams,
                Orientation = Orientation.Vertical
            };
            var fontSize = Variable.CurFontSize switch
            {
                (int)Variable.FontSize.Big => Variable.FontSizeBig,
                (int)Variable.FontSize.Medium => Variable.FontSizeMedium,
                (int)Variable.FontSize.Small => Variable.FontSizeSmall,
                _ => Variable.FontSizeBig,
            };
            var titleArr = new string[2] { "總額", "稅金" };
            var valueArr = new string[2] { "", "" };
            if (value != "")
            {
                // valueArr[0] = detailData.Name;
                valueArr[0] = detailData.Price.ToString();
                valueArr[1] = detailData.Tax.ToString();
            }
            var editTextArr = new EditText[3];
            for (int i = 0; i < titleArr.Length; i++)
            {
                LinearLayout insideLayout = new LinearLayout(MainActivity.Instance)
                {
                    LayoutParameters = matchParams,
                    Orientation = Orientation.Horizontal
                };
                TextView textView = new TextView(MainActivity.Instance)
                {
                    LayoutParameters = wrapParams,
                    Text = titleArr[i],
                    TextSize = fontSize,
                };
                EditText editText = new EditText(MainActivity.Instance)
                {
                    LayoutParameters = wrapParams,
                    Text = valueArr[i],
                    TextSize = fontSize,
                };
                if (i == 0)
                {
                    // 輸入總額時 會自動產生稅金
                    editText.AfterTextChanged += (sender, args) =>
                    {
                        editTextArr[1].Text = Math.Round(Convert.ToInt32(editText.Text) * 0.05).ToString().Split('.')[0];
                    };
                }
                
                textView.SetTextColor(Color.Blue);
                if (i != 0)
                {
                    editText.InputType = Android.Text.InputTypes.ClassNumber | Android.Text.InputTypes.NumberFlagSigned;
                }
                editTextArr[i] = editText;
                insideLayout.AddView(textView);
                insideLayout.AddView(editText);
                outsideLayout.AddView(insideLayout);
            }
            builder.SetPositiveButton("確定", (sender, args) =>
            {
                Variable.ResultStruct resultStruct;
                if (editTextArr[0].Text == "" || editTextArr[1].Text == "")
                {
                    resultStruct = new Variable.ResultStruct(Variable.ResultType.InvalidValue, "");
                }
                else if (Convert.ToInt32(editTextArr[0].Text) < Convert.ToInt32(editTextArr[1].Text))
                {
                    resultStruct = new Variable.ResultStruct(Variable.ResultType.InvalidPriceTax, "");
                }
                else if (value == "")
                {
                    resultStruct = MainData.AddDetailData(Convert.ToInt32(editTextArr[0].Text), Convert.ToInt32(editTextArr[1].Text));
                }
                else
                {
                    resultStruct = MainData.ModifyDetailData(value, editTextArr[0].Text,
                    Convert.ToInt32(editTextArr[1].Text), Convert.ToInt32(editTextArr[2].Text));
                }
                UpdateDetailView();
                ShowMessage(resultStruct);
                builder.Dispose();
            });
            builder.SetNegativeButton("返回", (sender, args) =>
            {
                builder.Dispose();
            });
            builder.SetView(outsideLayout);
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
            builder.Show();
        }

        void SetupUI()
        {
            Button scanButton = MainActivity.Instance.FindViewById<Button>(Resource.Id.scanButton);
            Button clearButton = MainActivity.Instance.FindViewById<Button>(Resource.Id.clearButton);
            EditText idEditText = MainActivity.Instance.FindViewById<EditText>(Resource.Id.buyerIdText);
            CheckBox tax500CheckBox = MainActivity.Instance.FindViewById<CheckBox>(Resource.Id.tax500CheckBox);
            idEditText.Text = Variable.CurBuyerId;
            tax500CheckBox.Checked = Variable.Tax500Mode;
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

        void SetupDetailUI()
        {
            Button backButton = MainActivity.Instance.FindViewById<Button>(Resource.Id.backButton);
            Button addButton = MainActivity.Instance.FindViewById<Button>(Resource.Id.addButton);
            backButton.Click += (sender, args) =>
            {
                MainActivity.Instance.SetContentView(Resource.Layout.main);
                SetupUI();
                SetupMonthView();
                UpdateMonthView();
            };
            addButton.Click += (sender, args) =>
            {
                ShowMessage(new Variable.ResultStruct(Variable.ResultType.AddDetail, ""));
            };
        }

        void SetupMonthView()
        {
            monthAdapter = new MonthAdapter(MainActivity.Instance, Resource.Id.text);
            monthView = (ListView)MainActivity.Instance.FindViewById(Resource.Id.monthView);
            monthView.Adapter = monthAdapter;
            monthView.ItemLongClick += (sender, args) =>
            {
                string id = args.View.Id.ToString();
                ShowMessage(new Variable.ResultStruct(Variable.ResultType.ClearMonth, id));
            };
            monthView.ItemClick += (sender, args) =>
            {
                string id = args.View.Id.ToString();
                MainActivity.Instance.SetContentView(Resource.Layout.detail);
                SetupDetailUI();
                SetupDetailView();
                UpdateDetailView(id);
            };
        }

        void SetupDetailView()
        {
            detailAdapter = new DetailAdapter(MainActivity.Instance, Resource.Id.text);
            detailView = (ListView)MainActivity.Instance.FindViewById(Resource.Id.detailView);
            detailView.Adapter = detailAdapter;
        }

        public void UpdateMonthView()
        {
            monthAdapter.Clear();
            var allMonthData = MainData.GetAllMonthData();
            if (allMonthData != null)
            {
                foreach (var data in allMonthData.OrderBy(obj => obj.Key))
                {
                    string[] dataStr = new string[6];
                    dataStr[0] = data.Key.ToString();
                    dataStr[1] = data.Value.Amount.ToString();
                    dataStr[2] = data.Value.Price.ToString();
                    dataStr[3] = data.Value.UnTaxedPrice.ToString();
                    dataStr[4] = data.Value.Tax.ToString();
                    dataStr[5] = data.Value.ToLimit.ToString();
                    monthAdapter.Add(dataStr);
                }
            }
        }

        public void UpdateDetailView(string month = "")
        {
            if (month == "")
            {
                month = Variable.CurDetailMonth;
                if (month == "")
                {
                    return;
                }
            }
            Variable.CurDetailMonth = month;

            detailAdapter.Clear();
            var detailData = MainData.GetMonthData(month);
            if (detailData != null)
            {
                foreach (var data in detailData.OrderBy(obj => obj.Value.Date))
                {
                    string[] dataStr = new string[6];
                    dataStr[0] = data.Key.ToString();
                    dataStr[1] = data.Value.Name;
                    dataStr[2] = month + data.Value.Date;
                    dataStr[3] = data.Value.Price.ToString();
                    dataStr[4] = data.Value.UnTaxedPrice.ToString();
                    dataStr[5] = data.Value.Tax.ToString();
                    detailAdapter.Add(dataStr);
                }
            }
        }
    }
}
