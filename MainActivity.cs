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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main);
            instance = this;
            mainView = new MainView();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);
        }

        public override void OnBackPressed()
        {
            mainView.ShowMessage(Variable.ResultType.LeaveApp, null);
        }

        public void OnResult(Variable.ResultType type)
        {
            mainView.ShowMessage(type, null);
            if (type == Variable.ResultType.Success || type == Variable.ResultType.TaxOffsetExceed2)
            {
                mainView.UpdateListView();
            }
        }
    }
}
