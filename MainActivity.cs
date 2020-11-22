using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;


namespace QrData
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        MainView mainView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main);
            mainView = new MainView(this);
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
                if ((int)data == (int)Variable.ResultType.Success)
                {
                    mainView.UpdateListView();
                }
            }
        }
    }
}
