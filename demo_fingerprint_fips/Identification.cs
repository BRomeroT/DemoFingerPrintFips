using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Rscja.Deviceapi;
using Java.Lang;
using Android.Media;

namespace demo_fingerprint_fips
{
    [Activity(Label = "Identification")]
    public class Identification : Fragment
    {
        //  private static final String TAG = "IdentificationFragment";
        public Button btnIdent;
        public ScrollView scroll;
        Button PowerOn;
        Button Stop;
        public TextView tvInfo;
        public TextView tvID;
        TextView tvVersion;
        public string oldMsg = "";
        Handler handler = new Handler();
        public SoundPool soundPool;
        int soundPoolId1, soundPoolId2;
        private MainActivity mContext;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.identification, container, false);

            Stop = view.FindViewById<Button>(Resource.Id.Stop);
            btnIdent = view.FindViewById<Button>(Resource.Id.btnIdent);
            tvInfo = view.FindViewById<TextView>(Resource.Id.tvInfo);
            tvID = view.FindViewById<TextView>(Resource.Id.tvID);
            scroll = view.FindViewById<ScrollView>(Resource.Id.scroll);
            init();
            return view;
        }
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            mContext = (MainActivity)Activity;


            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId1 = soundPool.Load(mContext, Resource.Drawable.barcodebeep, 1);
            soundPoolId2 = soundPool.Load(mContext, Resource.Drawable.serror, 1);
        }

        public void Sound(int i)
        {
            //第一个参数为id
            //第二个和第三个参数为左右声道的音量控制
            //第四个参数为优先级，由于只有这一个声音，因此优先级在这里并不重要

            //第五个参数为是否循环播放，0为不循环，-1为循环
            //
            //最后一个参数为播放比率，从0.5到2，一般为1，表示正常播放。
            if (i == 1)
                soundPool.Play(soundPoolId1, 1, 1, 0, 0, 1);
            else if (i == 2)
                soundPool.Play(soundPoolId2, 1, 1, 0, 0, 1);
            else { }


        }
        private void init()
        {

            Stop.Click += new EventHandler(delegate
            {
            });
            btnIdent.Click += new EventHandler(delegate
            {
                if (!PubClass.FIPS.IsPowerOn)
                {
                    Toast.MakeText(mContext, "The fingerprints did not run powered on!", ToastLength.Short).Show();
                    return;
                }
                btnIdent.Enabled = false;
                tvInfo.Text = "";
                tvID.Text = "";
                PubClass.FIPS.StartIdentification();
                PubClass.FIPS.SetIdentificationCallBack(new IdentificationCall(this));
            });
            //PubClass.FIPS.SetIdentificationCallBack(new IdentificationCall(this));
        
        }

        public void scrollToBottom(View scroll, View inner)
        {

            Handler mHandler = new Handler();
            new Handler().Post(() =>
            {
                if (scroll == null || inner == null)
                {
                    return;
                }
                int offset = inner.MeasuredHeight - scroll.Height;
                if (offset < 0)
                {
                    offset = 0;
                }
                scroll.ScrollTo(0, offset);
            });
        }


        private void a()
        {
            throw new NotImplementedException();
        }

        public override void OnResume()
        {
            base.OnResume();

        }
        public override void OnPause()
        {
            base.OnPause();
            if (PubClass.FIPS != null)
                PubClass.FIPS.StopIdentification();
            tvInfo.Text = "";
        }
        public override void OnStop()
        {
            base.OnStop();

        }


    }

    public class IdentificationCall : Java.Lang.Object, FingerprintWithFIPS.IIdentificationCallBack
    {
        private Identification identification;

        public IdentificationCall(Identification identification)
        {
            this.identification = identification;
        }



        public void MessageInfo(string p0)
        {
            if (!identification.oldMsg.Equals(p0))
            {
                StringBuffer stringBuffer = new StringBuffer();
                stringBuffer.Append(p0);
                stringBuffer.Append(".\r\n");
                stringBuffer.Append(identification.tvInfo.Text);
                identification.tvInfo.Text = stringBuffer.ToString();
                identification.oldMsg = p0;

                identification.scrollToBottom(identification.scroll, identification.tvInfo);
            }
        }

        public void OnComplete(bool p0, int p1, int p2)
        {
            // Log.i(TAG, "failuerCode=" + failuerCode);
            if (p0)
            {
                identification.tvID.Text = "fingerprintID=" + p1;

                identification.Sound(1);
            }
            else
            {

                identification.Sound(2);
            }
            identification.btnIdent.Enabled = true;
        }
    }
}