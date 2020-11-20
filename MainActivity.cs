using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace QrData
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        MainView mainView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
            SetContentView(Resource.Layout.main);
            mainView = new MainView(this);
            Button scanButton = FindViewById<Button>(Resource.Id.scanButton);
            EditText idEditText = FindViewById<EditText>(Resource.Id.buyerIdText);
            scanButton.Click += (sender, e) =>
            {
                if (idEditText.Text == "" || idEditText.Text.Length != 8)
                {
                    mainView.ShowMessage((int)Variable.ResultType.BuyerIdUnvalid);
                }
                else
                {
                    Variable.CurBuyerId = idEditText.Text;
                    var intentCameraATY = new Intent(this, typeof(CameraATY));
                    StartActivityForResult(intentCameraATY, (int)Variable.RequestCode.Camera);
                }
                
            };
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);
            if (resultCode == Result.Ok)
            {
                var data = intent.GetBundleExtra("ResultType");
                switch (requestCode)
                {
                    case (int)Variable.RequestCode.Camera:
                        mainView.ShowMessage((int)data);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
