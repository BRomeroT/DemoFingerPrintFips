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
using Com.Rscja.Utility;
using Android.Media;

namespace demo_fingerprint_fips
{
    [Activity(Label = "Verify")]
    public class Verify : Fragment
    {
        //  private static final String TAG = "TemplateVerify";
        public Button btnIdent;
        Button btnStop;
        ListView lsTemplate;
        public SoundPool soundPool;
        int soundPoolId1, soundPoolId2;
        TextView tvTip;
        public TextView tvInfoMsg;
        public ScrollView scroll;
        private List<IDictionary<string, object>> hashMap;
        public string oldMsg = "";
        string path;
        Handler handler = new Handler();
        private MainActivity mContext;

        //protected override void OnCreate(Bundle bundle)
        //{
        //    base.OnCreate(bundle);
        //    SetContentView(Resource.Layout.Verify);
        //    // Create your application here

        //    soundPool = new SoundPool(10, Stream.Music, 0);
        //    soundPoolId1 = soundPool.Load(this.ApplicationContext, Resource.Drawable.barcodebeep, 1);
        //    soundPoolId2 = soundPool.Load(this.ApplicationContext, Resource.Drawable.serror, 1);

        //    init();
        //}

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
          Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Verify, container, false);

           


            tvTip = view.FindViewById<TextView>(Resource.Id.tvTip);
            tvInfoMsg = view.FindViewById<TextView>(Resource.Id.tvInfoMsg);
            btnIdent = view.FindViewById<Button>(Resource.Id.btnIdent);
            btnStop = view.FindViewById<Button>(Resource.Id.btnStop);
            scroll = view.FindViewById<ScrollView>(Resource.Id.scroll2);
            lsTemplate = view.FindViewById<ListView>(Resource.Id.lsTemplate);
          
          
               
            return view;
        }
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            mContext = (MainActivity)Activity;
            soundPool = new SoundPool(10, Stream.Music, 0);
            soundPoolId1 = soundPool.Load(mContext, Resource.Drawable.barcodebeep, 1);
            soundPoolId2 = soundPool.Load(mContext, Resource.Drawable.serror, 1);


            hashMap = new List<IDictionary<string, object>>();

            SimpleAdapter adapter = new SimpleAdapter(mContext, hashMap, Resource.Layout.listitem,
                new String[] { "fname", "fpath" },
                new int[] { Resource.Id.list_name, Resource.Id.list_path });
            lsTemplate.Adapter = adapter;
            init();

           
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


            btnStop.Click += new EventHandler(delegate
            {
                PubClass.FIPS.StopTemplateVerify();
            });
            btnIdent.Click += new EventHandler(delegate
            {
                if (!PubClass.FIPS.IsPowerOn)
                {
                    Toast.MakeText(mContext, "The fingerprints did not run on!", ToastLength.Short).Show();
                    return;
                }
                tvInfoMsg.Text = "";
                if (path == null || path.Length < 0)
                    return;
                string temp = FileUtils.ReadFile(path);
                if (temp != "")
                {
                    byte[] templateData = StringUtility.HexStringToBytes(temp);
                    if (templateData != null && templateData.Length > 0)
                    {
                        char[] template_data = new char[templateData.Length];
                        for (int k = 0; k < templateData.Length; k++)
                        {
                            template_data[k] = (char)templateData[k];
                        }
                        PubClass.FIPS.StartTemplateVerify(template_data);
                        PubClass.FIPS.SetTemplateVerifyCallBack(new TemplateVerifyCall(mContext.verify));
                        btnIdent.Enabled = false;
                    }
                }
            });
            tvTip.Text = FileUtils.PATH;
            lsTemplate.VerticalScrollBarEnabled = true;//.setVerticalScrollBarEnabled(true);
            initListTemplate();

            //  lsTemplate.ItemClick = new EventHandler<AdapterView.ItemClickEventArgs>(new dd());
            //lsTemplate.setOnItemClickListener(new AdapterView.OnItemClickListener(){
            //@Override
            //public void onItemClick(AdapterView<?> arg0, View arg1, int arg2, long arg3)
            //{
            //    //获得选中项的HashMap对象
            //    String key = (String)lsTemplate.getItemAtPosition(arg2);
            //    path = hashMap.get(key);

            //}


            this.lsTemplate.ItemClick += new EventHandler<AdapterView.ItemClickEventArgs>(ListView_ItemClick);



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
        void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
          
         //   string keyss = (string)lsTemplate.GetItemAtPosition(e.Position);
      
          
            TextView c = (TextView)e.View.FindViewById(Resource.Id.list_name);
            TextView p = (TextView)e.View.FindViewById(Resource.Id.list_path);
            string n = c.Text;
            path = c.Text;
          
        }
        private void initListTemplate()
        {
            hashMap = FileUtils.ReadFileName();

            JavaDictionary<string, object> map = new JavaDictionary<string, object>();
          
            if (hashMap.Count > 0)
            {
                SimpleAdapter adapter = new SimpleAdapter(mContext, hashMap, Resource.Layout.listitem,
                    new String[] { "fname","fpath" },
                    new int[] { Resource.Id.list_name,Resource.Id.list_path });
                //  adapter = new ArrayAdapter<String>(getActivity(), Resource.Layout.listitem, Resource.Id.list_item, hashMap);
                lsTemplate.SetAdapter(adapter);
            }
        }





    }

    internal class TemplateVerifyCall : Java.Lang.Object, FingerprintWithFIPS.ITemplateVerifyCallBack
    {
        private Verify verify;

        public TemplateVerifyCall(Verify verify)
        {
            this.verify = verify;
        }

        public void MessageInfo(string p0)
        {
            if (!verify.oldMsg.Equals(p0))
            {
                string str1 = verify.tvInfoMsg.Text.ToString();
                string strMsg = str1 + p0 + ".\r\n";
                verify.tvInfoMsg.Text = strMsg;
                verify.oldMsg = p0;
                verify.scrollToBottom(verify.scroll, verify.tvInfoMsg);
            }
        }

        public void OnComplete(bool p0, int p1)
        {
            verify.btnIdent.Enabled = true;
            if (p0)
            {
                verify.Sound(1);
            }
            else
            {
                verify.Sound(2);
            }
        }
    }
}
