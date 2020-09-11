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
using Android.Graphics;
using Android.Media;

namespace demo_fingerprint_fips
{
    [Activity(Label = "Grab")]
    public class Grab : Fragment
    {
        String TAG = "GRABFragment";
        //public static string PATH = Environment
        //        .getExternalStorageDirectory()
        //        + File.separator
        //        + "fingerprint_fips"
        //        + File.separator;
        //string filePath = PATH + "finger.bmp";
        MainActivity mContext;
        public Button btnGRAB, Stop;
        public ImageView iv;
        public TextView tvInfo;
        public TextView tvPro;
    public    ScrollView scroll;
        public string oldMsg = "";
        Handler handler = new Handler();
        public SoundPool soundPool;
        int soundPoolId1, soundPoolId2;
        //protected override void OnCreate(Bundle bundle)
        //{
        //    base.OnCreate(bundle);
        //    SetContentView(Resource.Layout.grabs);
        //    // Create your application here
        //    //  InitView();

           
        //}


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
           Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.grabs, container, false);

          

            btnGRAB = view.FindViewById<Button>(Resource.Id.btnGRAB);
            Stop = view.FindViewById<Button>(Resource.Id.Stop);
          
            iv = view.FindViewById<ImageView>(Resource.Id.iv);
            tvInfo = view.FindViewById<TextView>(Resource.Id.tvInfo);
            tvPro = view.FindViewById<TextView>(Resource.Id.tvPro);
            scroll = view.FindViewById<ScrollView>(Resource.Id.scroll);

            btnGRAB.Click += new EventHandler(delegate
            {
                PubClass.FIPS.StartGRAB();
                btnGRAB.Enabled = false;
            });
            Stop.Click += new EventHandler(delegate
            {
                PubClass.FIPS.StopGRAB();
            });

            PubClass.FIPS.SetGrabCallBack(new GRABCall(this));

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
        public void scrollToBottom(View scroll, View inner)
        {

            Handler mHandler = new Handler();
            new Handler().Post(() => {
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
        public override void OnPause()
        {
            base.OnPause();
            PubClass.FIPS.StopGRAB();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }

    internal class GRABCall : Java.Lang.Object, FingerprintWithFIPS.IGRABCallBack
    {
        private Grab grab;

        public GRABCall(Grab grab)
        {
            this.grab = grab;
        }


        public void MessageInfo(string p0)
        {
            if (!grab.oldMsg.Equals(p0))
            {
                string str1 = grab.tvInfo.Text;
                string strMsg = str1 + p0 + ".\r\n";
                grab.tvInfo.Text = strMsg;
                grab.oldMsg = p0;
                grab.scrollToBottom(grab.scroll, grab.tvInfo);
            }
        }

        public void OnComplete(bool p0, byte[] p1, int p2)
        {
            if (p0)
            {
                if (PubClass.FIPS.GenerateImg(p1, FileUtils.PATH_Grab_img))
                {
                    Bitmap bitmap = BitmapFactory.DecodeFile(FileUtils.PATH_Grab_img);
                    if (bitmap != null)
                    {
                        grab.iv.SetImageBitmap(bitmap);
                        grab.Sound(1);
                    }
                }
            }
            else
            {
                grab.Sound(2);
            }
            grab.btnGRAB.Enabled = true;
        }

        public void Progress(int p0)
        {
            grab.tvPro.Text = p0 + "%";
        }
    }
}