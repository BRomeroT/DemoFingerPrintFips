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
using Android.Media;
using Java.Lang;

namespace demo_fingerprint_fips
{
    [Activity(Label = "Acquisition")]
    public class Acquisition : Fragment
    {
        MainActivity mContext;
        public int RESULT_STATUS_SUCCESS = 0;//成功
        public int RESULT_STATUS_CANCEL = -2;//取消
        public int RESULT_STATUS_FAILURE = -1;//失败
        public int RESULT_STATUS_NO_MATCH = -3;//指纹不匹配
        private static string TAG = "AcquisitionFragment";
        public SoundPool soundPool;
        int soundPoolId1, soundPoolId2;
   
        public Button btnEnroll;
        Button EnrollStop;
        public Button btnPtCapture;
        Button btnPtCaptureStop;
        public TextView tvInfo, tvVersion;
        Button btnCleanAll;
        Button btnGetCount;
        Handler handler;
        ScrollView scroll;
        byte[] buff = new byte[1];
        int id = -1;
        string oldMsg = "";
        public int tId = 100;
        


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
          Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.acquisition, container, false);

           

            scroll = view.FindViewById<ScrollView>(Resource.Id.scroll);//.findViewById(R.id.scroll);
            btnEnroll = view.FindViewById<Button>(Resource.Id.btnEnroll);
            btnCleanAll = view.FindViewById<Button>(Resource.Id.btnCleanAll);
            btnGetCount = view.FindViewById<Button>(Resource.Id.btnGetCount);
            EnrollStop = view.FindViewById<Button>(Resource.Id.btnEnrollStop);
            btnPtCapture = view.FindViewById<Button>(Resource.Id.btnPtCapture);
            btnPtCaptureStop = view.FindViewById<Button>(Resource.Id.btnPtCaptureStop);

            tvInfo = view.FindViewById<TextView>(Resource.Id.tvInfo);
            tvVersion = view.FindViewById<TextView>(Resource.Id.tvVersion);

            init();
            handler = new UIHand(this);

            return view;
        }

        private class UIHand : Handler
        {
            private Acquisition acquisition;

            public UIHand(Acquisition acquisition)
            {
                this.acquisition = acquisition;
            }

            public override void HandleMessage(Message msg)
            {

                if (acquisition.tvInfo.Text.Length > 500)
                    acquisition.tvInfo.Text = "";
                    acquisition.tvInfo.Text = msg.Obj+" ";              

            }
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

           
            if (PubClass.FIPS.IsPowerOn)
            {
                FingerprintWithFIPS.FingerprintInfo info = PubClass.FIPS.PTInfo;
                tvVersion.Text = "version:" + info.Versions + "  ID:" + info.Id;
            }
            btnEnroll.Click += new EventHandler(delegate
            {
                buff = null;
                id = -1;
                tvInfo.Text = "";
                PubClass.FIPS.StartIdentification();//采集之前先判断指纹是否存在
                PubClass.FIPS.SetIdentificationCallBack(new IdentificationBack(this));
                //PubClass.FIPS.StartEnroll();
                btnEnroll.Enabled = false;
              
            });

          
            btnCleanAll.Click += new EventHandler(delegate
            {
                int result = PubClass.FIPS.DeleteAllFingers();
                FileUtils.ClearFile();
                Toast.MakeText(mContext, "CleanAll：" + result,ToastLength.Short).Show();
            });
            btnGetCount.Click += new EventHandler(delegate
            {
                int Count = PubClass.FIPS.FingersCount;
                //  pro.SetMessage("总数：" + Count.ToString());
                Toast.MakeText(mContext, "总数：" + Count.ToString(), ToastLength.Short).Show();
                // new GetCountTask(this).Execute();
            });
            EnrollStop.Click += new EventHandler(delegate
            {
                btnEnroll.Enabled = true;
                PubClass.FIPS.StopEnroll();
            });
            btnPtCapture.Click += new EventHandler(delegate
            {
                btnPtCapture.Enabled = false;
                PubClass.FIPS.StartPtCapture();
                PubClass.FIPS.SetPtCaptureCallBack(new CaptureCallBack(mContext.acqu));
            });
            btnPtCaptureStop.Click += new EventHandler(delegate
            {
                btnPtCaptureStop.Enabled = true;
                PubClass.FIPS.StopPtCapture();
            });

          
            // PubClass.morpho.SetPtEnrollCallBack(new EnrollCallBack(this));
            //PubClass.FIPS.SetEnrollCallBack(new EnrollCallBack(this));
            //// PubClass.morpho.SetPtEnrollCallBack(new EnrollCallBack(this));


            //PubClass.FIPS.SetIdentificationCallBack(new IdentificationBack(this));
            //// PubClass.morpho.SetPtEnrollCallBack(new EnrollCallBack(this));
            //PubClass.FIPS.SetPtCaptureCallBack(new CaptureCallBack(this));
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
                scroll.ScrollTo(0, inner.MeasuredHeight-10);//offset
            });
        }

        ProgressDialog mypDialog = null;
        public void showProgressDialog()
        {
            if (mypDialog == null)
            {
                mypDialog = new ProgressDialog(mContext);
            }
            mypDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            mypDialog.SetMessage("wait...");
            mypDialog.SetCancelable(false);
            mypDialog.SetCanceledOnTouchOutside(false);
            mypDialog.Show();
        }
        public void setMsg(string msg)
        {
            if (!oldMsg.Equals(msg))
            {
           
                string str1 = tvInfo.Text.ToString();
               string strMsg = msg + ".\r\n"+ str1 ;

               // tvInfo.Text = strMsg;
                oldMsg = msg;
                Message msgaa = handler.ObtainMessage();
                msgaa.Obj = strMsg;
                handler.SendMessage(msgaa);
                //scrollToBottom(scroll,tvInfo);
            }
        }

        public override void OnResume()
        {
            base.OnPause();
            tvInfo.Text = "";
            PubClass.FIPS.StopEnroll();
        }


        public override void OnDestroy()
        {
            base.OnDestroy();
        }

    }

   

    class GetCountTask : AsyncTask
    {
        Acquisition mContext;
        ProgressDialog pro;
        public GetCountTask(Acquisition m)
        {
            mContext = m;
        }

        protected override void OnPreExecute()
        {
            base.OnPreExecute();

            pro = new ProgressDialog(mContext.Context);
            pro.SetCancelable(false);
            pro.SetProgressStyle(ProgressDialogStyle.Spinner);
            pro.SetMessage("wait...");
            pro.SetCanceledOnTouchOutside(false);
            pro.Show();

        }
        #region implemented abstract members of AsyncTask

        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            int Count = PubClass.FIPS.FingersCount;
            //  pro.SetMessage("总数：" + Count.ToString());
            Toast.MakeText(mContext.Context, "总数："+Count.ToString(), ToastLength.Short).Show();
          //  mContext.tvInfo.Text = "总数：" + Count.ToString();
            // PublishProgress(Count);
            try
            {
                Thread.Sleep(1500);
            }
            catch (InterruptedException e)
            {
               // e.printStackTrace();
            }
            return true;
        }

        #endregion
        protected override void OnPostExecute(Java.Lang.Object obj)
        {
            base.OnPostExecute(obj.ToString());
           
            pro.Cancel();
        }
    }

    public class EnrollCallBack : Java.Lang.Object, FingerprintWithFIPS.IEnrollCallBack
    {
        private Acquisition acquisition;

        public EnrollCallBack(Acquisition acquisition)
        {
            this.acquisition = acquisition;
        }


         void FingerprintWithFIPS.IEnrollCallBack.MessageInfo(string p0)
        {
            acquisition.tvInfo.Text = p0;// + "\r\n" + acquisition.tvInfo.Text;
            // Log.Info(iff.TAG, "msg---->" + p0);

          //  acquisition.setMsg(p0);
        }


        //public void onComplete(boolean result, byte[] bytes, int id,int failuerCode)
         void FingerprintWithFIPS.IEnrollCallBack.OnComplete(bool p0, byte[] p1, int p2, int p3)
        {
            if (p0)
            {
                string strMsg = "FingerprintID:" + p2;
                acquisition.tvInfo.Text = strMsg;//.setMsg(strMsg);
                string fileName = "FingerprintID_" + p2 + ".txt";

                FileUtils.WritFile(fileName, Com.Rscja.Utility.StringUtility.Bytes2HexString(p1));//.bytes2HexString2(p1, p1.Length));
                acquisition.Sound(1);


            }
            else
            {
                acquisition.Sound(2);
            }
            acquisition.btnEnroll.Enabled = true;
        }
    }


    public class IdentificationBack : Java.Lang.Object, FingerprintWithFIPS.IIdentificationCallBack
    {
        private Acquisition acquisition;

        public IdentificationBack(Acquisition acquisition)
        {
            this.acquisition = acquisition;
        }


        public void MessageInfo(string p0)
        {
            acquisition.tvInfo.Text = p0;// + "\r\n" + acquisition.tvInfo.Text;
            // Log.Info(iff.TAG, "msg---->" + p0);

          //  acquisition.setMsg(p0);
        }


        //public void onComplete(boolean result, int id,int failuerCode)
        public void OnComplete(bool p0, byte[] p1, int p2, int p3)
        {
            // Log.i(TAG, "failuerCode=" + failuerCode);

        }

        public void OnComplete(bool p0, int p1, int p2)
        {
            if (p0)
            {
                acquisition.setMsg("Fingerprint ID:" + p1);
            }
            else
            {
                if (p2 == acquisition.RESULT_STATUS_NO_MATCH)
                { //指纹不存在
                    PubClass.FIPS.StartEnroll();
                    PubClass.FIPS.SetEnrollCallBack(new EnrollCallBack(acquisition));
                    return;
                }
            }
            acquisition.Sound(2);
            acquisition.btnEnroll.Enabled = true;
        }
    }

    public class CaptureCallBack : Java.Lang.Object, FingerprintWithFIPS.IPtCaptureCallBack
    {
        private Acquisition acquisition;
        public CaptureCallBack(Acquisition acquisition)
        {
            this.acquisition = acquisition;
        }
        public void MessageInfo(string p0)
        {
            acquisition.tvInfo.Text = p0;// + "\r\n" + acquisition.tvInfo.Text;
            // Log.Info(iff.TAG, "msg---->" + p0);

           // acquisition.setMsg(p0);
        }
        //public void onComplete(boolean result, int id,int failuerCode)
        public void OnComplete(bool p0, byte[] p1, int p2)
        {
            //Log.i(TAG, "failuerCode=" + failuerCode);
            if (p0)
            {
                acquisition.Sound(1);
                string fileName = "FingerprintID_" + (acquisition.tId++) + ".txt";
                FileUtils.WritFile(fileName, FileUtils.bytes2HexString2(p1, p1.Length));
                acquisition.setMsg(fileName);
            }
            else
            {
                acquisition.Sound(2);
            }
            acquisition.btnPtCapture.Enabled = true;
        }
    }

}