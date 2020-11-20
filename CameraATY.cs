using Android;
using Android.App;
using Android.OS;
using Android.Content.PM;
using Android.Views;
using Android.Graphics;
using Android.Util;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Content;
using Android.Gms.Vision;
using Android.Gms.Vision.Barcodes;
using static Android.Gms.Vision.Detector;
using static Android.Support.V4.App.ActivityCompat;

namespace QrData
{
    [Activity(Label = "CameraATY", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.KeyboardHidden, WindowSoftInputMode = SoftInput.AdjustPan, ScreenOrientation = ScreenOrientation.Portrait)]
    public class CameraATY : Activity, ISurfaceHolderCallback, IOnRequestPermissionsResultCallback, IProcessor
    {
        SurfaceView surfaceView;
        CameraSource cameraSource;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.camera);
            var permissions = new string[] { Manifest.Permission.Camera };
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) != (int)Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, permissions, (int)Variable.RequestCode.Camera);
            }
            DisplayMetrics displayMetrics = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetMetrics(displayMetrics);
            int width = displayMetrics.WidthPixels;
            int height = displayMetrics.HeightPixels;
            BarcodeDetector barcodeDetector = new BarcodeDetector.Builder(this).SetBarcodeFormats(BarcodeFormat.QrCode).Build();
            cameraSource = new CameraSource.Builder(this, barcodeDetector).SetRequestedPreviewSize(width, height).SetFacing(CameraFacing.Back).SetAutoFocusEnabled(true).Build();
            surfaceView = (SurfaceView)FindViewById(Resource.Id.surfaceView);
            surfaceView.Holder.AddCallback(this);
            barcodeDetector.SetProcessor(this);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            switch (requestCode)
            {
                case (int)Variable.RequestCode.Camera:
                    if (grantResults.Length > 0 && grantResults[0] == Permission.Denied)
                    {
                        var intent = new Intent(this, typeof(MainActivity));
                        SetResult(Result.Canceled, intent);
                        Finish();
                    }
                    return;
                default:
                    break;
            }
        }

        public void ReceiveDetections(Detections detections)
        {
            SparseArray qrcodes = detections.DetectedItems;
            if (qrcodes.Size() == 2)
            {
                var QRCode0 = ((Barcode)qrcodes.ValueAt(0)).RawValue;
                var QRCode1 = ((Barcode)qrcodes.ValueAt(1)).RawValue;
                var realData = QRCode0[0] == '*' ? QRCode1 : QRCode0;
                var result = MainData.SetData(realData);
                var intent = new Intent(this, typeof(MainActivity));
                intent.PutExtra("ResultType", (int)result);
                SetResult(Result.Ok, intent);
                //Finish();
            }
        }

        public void Release()
        {
        }

        public void SurfaceChanged(ISurfaceHolder holder, [GeneratedEnum] Format format, int width, int height)
        {
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) == (int)Permission.Granted)
                cameraSource.Start(surfaceView.Holder);
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            cameraSource.Stop();
        }
    }
}