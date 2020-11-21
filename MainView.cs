using Android.App;
using Android.Widget;

namespace QrData
{
    public class MainView
    {
        MainActivity activity;
        AlertDialog.Builder dialog;
        public MainView(MainActivity activity)
        {
            this.activity = activity;
            dialog = new AlertDialog.Builder(activity);
            dialog.SetTitle("注意");
            dialog.SetPositiveButton("OK", (sender, args) => {});
            //Xamarin.Forms.Application.Current.MainPage.DisplayAlert("My Alert", "My message.", "OK");
        }

        public void ShowMessage(int type)
        {
            string str;
            switch (type)
            {
                case (int)Variable.ResultType.Success:
                    str = "掃描成功！";
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
    }
}
