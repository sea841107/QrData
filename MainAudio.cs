using Android.Media;
using Android.Speech.Tts;

namespace QrData
{
    public class MainAudio
    {
        TextToSpeech textToSpeech;

        public MainAudio()
        {
            textToSpeech = new TextToSpeech(MainActivity.Instance, MainActivity.Instance, "com.android.google.tts");
        }

        public void PlaySound(Variable.ResultStruct result)
        {
            int soundId;
            switch (result.Type)
            {
                case Variable.ResultType.ScanSuccess:
                    soundId = Resource.Raw.correct;
                    break;
                case Variable.ResultType.ScanFailed:
                case Variable.ResultType.UuidExist:
                case Variable.ResultType.BuyerIdEmpty:
                case Variable.ResultType.BuyerIdNotMatch:
                case Variable.ResultType.TaxExceed500:
                case Variable.ResultType.TaxOffsetExceed2:
                    soundId = Resource.Raw.wrong;
                    break;
                default:
                    return;
            }
            MediaPlayer player = MediaPlayer.Create(MainActivity.Instance, soundId);
            player.Start();
        }

        public void SetLanguage(Java.Util.Locale locale)
        {
            textToSpeech.SetLanguage(locale);
        }

        public void Speak(string message)
        {
            textToSpeech.Speak(message, QueueMode.Flush, null, null);
        }
    }
}