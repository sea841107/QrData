using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;

namespace QrData
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public MainActivity() {}
        private static MainActivity instance;
        public static MainActivity Instance { get { return instance; } }

        MainView mainView;
        MainAudio mainAudio;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main);
            instance = this;
            mainView = new MainView();
            mainAudio = new MainAudio();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);
            if (intent != null && intent.HasExtra("Error"))
            {
                string error = intent.GetStringExtra("Error");
                mainView.ShowMessage(new Variable.ResultStruct(Variable.ResultType.Default, error));
            }
        }

        public override void OnBackPressed()
        {
            mainView.ShowMessage(new Variable.ResultStruct(Variable.ResultType.LeaveApp, null));
        }

        public void OnResult(Variable.ResultStruct result)
        {
            mainView.ShowMessage(result);
            if (result.Type == Variable.ResultType.ScanSuccess || result.Type == Variable.ResultType.TaxOffsetExceed2)
            {
                mainView.UpdateListView();
            }
            mainAudio.PlaySound(result);
        }
    }
}
