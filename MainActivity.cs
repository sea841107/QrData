using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Views;
using Java.Lang;

namespace QrData
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        MainView mainView;
        ListView listView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            mainView = new MainView(this);
            SetContentView(Resource.Layout.main);
            SetupButton();
            CreateListView();
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

        void SetupButton()
        {
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

        void CreateListView()
        {
            listView = (ListView)FindViewById(Resource.Id.listView);
            string[] values = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n","o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            List<string> list = new List<string>();
            for (int i = 0; i < values.Length; ++i)
            {
                list.Add(values[i]);
            }
            StableArrayAdapter adapter = new StableArrayAdapter(this, Resource.Layout.text_view_without_line_height, list);
            listView.SetAdapter(adapter);
        }

        class StableArrayAdapter : ArrayAdapter<string>, AdapterView.IOnItemClickListener
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            List<string> list;

            public StableArrayAdapter(Context context, int textViewResourceId, List<string> objects)
                : base(context, textViewResourceId, objects)
            {
                list = objects;
                for (int i = 0; i < objects.Count; ++i)
                {
                    dic.Add(objects[i], i);
                }
            }

            public override long GetItemId(int position)
            {
                string item = GetItem(position);
                return dic.GetValueOrDefault(item);
            }

            void AdapterView.IOnItemClickListener.OnItemClick(AdapterView parent, View view, int position, long id)
            {
                string item = (string)parent.GetItemAtPosition(position);
                Runnable newThread = new Runnable(Run);
                newThread.Run();
                view.Animate().SetDuration(2000).Alpha(0).WithEndAction(newThread);
                void Run()
                {
                    list.Remove(item);
                    NotifyDataSetChanged();
                    view.Alpha = 1;
                }
            }
        }
    }
}
