using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using Android.Speech.Tts;
using Android.Runtime;
using Android.Views;
using Android.Content.PM;
using Java.IO;

namespace QrData
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity, TextToSpeech.IOnInitListener
    {
        public MainActivity() {}
        private static MainActivity instance;
        public static MainActivity Instance { get { return instance; } }

        MainView mainView;
        MainAudio mainAudio;
        TextToSpeech textToSpeech;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main);
            instance = this;
            mainView = new MainView();
            mainAudio = new MainAudio();
            textToSpeech = new TextToSpeech(this, this, "com.google.android.tts");
            new Timer(long.MaxValue, 100).Start();
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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                mainView.ShowChooseFontSize();
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public void OnClickFontSize(object sender, DialogClickEventArgs args)
        {
            Variable.CurFontSize = args.Which;
            Dialog dialog = (Dialog)sender;
            dialog.Dismiss();
            mainView.UpdateListView();
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
            //mainAudio.PlaySound(result);
        }

        public void OnSpeak(string message)
        {
            string realMessage = message.Replace("\n", "");
            textToSpeech.Speak(realMessage, QueueMode.Flush, null, null);
        }

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            if (status == OperationResult.Success)
                textToSpeech.SetLanguage(Java.Util.Locale.Taiwan);
            else if (status == OperationResult.Error)
                textToSpeech.SetLanguage(Java.Util.Locale.Default);
        }

        public void DeleteCache()
        {
            DeleteDir(CacheDir);
            DeleteDir(CodeCacheDir);
            DeleteDir(ExternalCacheDir);
        }

        public void DeleteDir(File dir)
        {
            if (dir != null && dir.IsDirectory)
            {
                string[] children = dir.List();
                for (int i = 0; i < children.Length; i++)
                {
                    File file = new File(dir, children[i]);
                    DeleteDir(file);
                }
                dir.Delete();
            }
            else if (dir != null && dir.IsFile)
            {
                dir.Delete();
            }
        }

        class Timer : CountDownTimer
        {
            int tickCount = 0;
            string tempValue = "";
            public Timer(long millisInFuture, long countDownInterval) : base(millisInFuture, countDownInterval)
            {
            }

            public override void OnTick(long millisUntilFinished)
            {
                if (tempValue != Variable.CurQrCode)
                {
                    tempValue = Variable.CurQrCode;
                    tickCount = 0;
                }
                if (tempValue != "")
                {
                    tickCount++;
                    if (tickCount == 30)
                    {
                        tickCount = 0;
                        Variable.CurQrCode = "";
                    }
                }
            }

            public override void OnFinish()
            {
            }
        }
    }
}
