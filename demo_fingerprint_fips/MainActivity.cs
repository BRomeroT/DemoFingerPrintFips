using Android.App;
using System;
using Android.OS;
using Com.Rscja.Deviceapi;

using Android.Content;

using Android.Renderscripts;
using Android.Widget;
using Android.Views;
using Android;
using Android.Util;
using System.Threading;

namespace demo_fingerprint_fips
{
    [Activity(Label = "demo_fingerprint_fips", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ActionBar actionbar;
        public Identification ident;
        public Acquisition acqu;
        public Grab grab;
        public Verify verify;
       // public FingerprintWithFIPS mFingerprint;
        TabHost tabhost = null;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            PubClass.FIPS=FingerprintWithFIPS.Instance;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                

                //读写内存权限
                if (ApplicationContext.CheckSelfPermission(
                        Manifest.Permission.AccessCoarseLocation) != Android.Content.PM.Permission.Granted)
                {

                    // 请求权限
                    RequestPermissions(new String[] { Manifest.Permission.AccessCoarseLocation },
                                    1);
                }


                if (ApplicationContext.CheckSelfPermission(Manifest.Permission.ReadExternalStorage) != Android.Content.PM.Permission.Granted
                    || ApplicationContext.CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != Android.Content.PM.Permission.Granted
                    )
                {

                    RequestPermissions(new String[] {
                        Manifest.Permission.WriteExternalStorage,
                        Manifest.Permission.ReadExternalStorage}, 1);
                    return;
                }
                else
                {
                    // 上面已经写好的拨号方法

                }

            }
            else
            {
                //这个说明系统版本在6.0之下，不需要动态获取权限。

            }

            InitView();


            new init14443(this).Execute();
        }
        void InitView()
        {

            ident = new Identification(); ;
            acqu = new Acquisition();
            grab = new Grab();
            verify = new Verify();

            actionbar = ActionBar;
            // 设置标签导航模式
            actionbar.NavigationMode = ActionBarNavigationMode.Tabs;

            ActionBar.Tab tab1 = ActionBar.NewTab();
            tab1.SetText("Identification");
            tab1.TabSelected += (sender, e) => {
                // Do something when tab is selected
                e.FragmentTransaction.Replace(Android.Resource.Id.Content,ident);
            };
            ActionBar.Tab tab2 = ActionBar.NewTab();
            tab2.SetText("Verify");
            tab2.TabSelected += (sender, e) =>
            {
                // Do something when tab is selected  
                e.FragmentTransaction.Replace(Android.Resource.Id.Content, verify);
            };

            ActionBar.Tab tab3 = ActionBar.NewTab();
            tab3.SetText("Acquisition");
            tab3.TabSelected += (sender, e) =>
            {
                // Do something when tab is selected  
                e.FragmentTransaction.Replace(Android.Resource.Id.Content, acqu);
            };

            ActionBar.Tab tab4 = ActionBar.NewTab();
            tab4.SetText("Grab");
            tab4.TabSelected += (sender, e) =>
            {
                // Do something when tab is selected  
                e.FragmentTransaction.Replace(Android.Resource.Id.Content, grab);
            };
            actionbar.AddTab(tab1);
            actionbar.AddTab(tab2);
            actionbar.AddTab(tab3);
            actionbar.AddTab(tab4);

            //	tabhost = FindViewById<TabHost> (Resource.Id.tabhost);// .tabHost1);
            //CreateTab(typeof(Identification), "Identification", "Identification", Resource.Drawable.Icon);
            //CreateTab(typeof(Verify), "Verify", "Verify", Resource.Drawable.Icon);
            //CreateTab(typeof(Acquisition), "Acquisition", "Acquisition", Resource.Drawable.Icon);
            ////CreateTab(typeof(Desfire), "Desfire", "Desfire", Resource.Drawable.Icon);
            //CreateTab(typeof(Grab), "Grab", "Grab", Resource.Drawable.Icon);

        }

        private void CreateTab(System.Type activityType, string tag, string label, int drawableId)
        {
            //var intent = new Intent(this, activityType);

            //intent.AddFlags(ActivityFlags.NewTask);

            //var spec = TabHost.NewTabSpec(tag);
            //var drawableIcon = Resources.GetDrawable(drawableId);
            //spec.SetIndicator(label, drawableIcon);
            //spec.SetContent(intent);

            //TabHost.AddTab(spec);
        }

        protected override void OnResume()
        {
            base.OnResume();
         
        }
        protected override void OnPause()
        {
            base.OnPause();
            //if (PubClass.FIPS != null)
            //{
            //    PubClass.FIPS.Free();
            //}
        }
        protected override void OnStop()
        {
            base.OnStop();

        }
        protected override void OnDestroy()
        {
            try
            {
              
               
               
                if(PubClass.FIPS!=null)
                {
                    PubClass.FIPS.Free();
                }
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            }
            catch (Java.Lang.Exception ex)
            {
                Log.Info("ex", ex.Message);
              //  ex.PrintStackTrace();
            }
            base.OnDestroy();

        }


        public override bool OnKeyDown(Keycode code, KeyEvent e)
        {
            if (code == Keycode.F9)
            {
                //Scan ();
                return true;
            }
            return base.OnKeyDown(code, e);
        }
        public override bool OnKeyUp(Keycode code, KeyEvent e)
        {
            if (code == Keycode.F9)
            {

                return true;
            }
            return base.OnKeyUp(code, e);
        }


        public class init14443 : AsyncTask
        {

            MainActivity mContext;
            ProgressDialog pro;
            public init14443(MainActivity m)
            {
                mContext = m;
            }

            protected override void OnPreExecute()
            {
                base.OnPreExecute();
                pro = new ProgressDialog(mContext);
                pro.SetProgressStyle(ProgressDialogStyle.Spinner);
                pro.SetMessage(" Init...");
                pro.Show();

            }
            #region implemented abstract members of AsyncTask

            protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
            {
                Log.Debug("11", "start");
                bool res = PubClass.FIPS.Init();
            
                Thread.Sleep(5000);
                if (res)
                {//throw new NotImplementedException ();
                 //mContext.StartScanThread ();
                 // PubClass.FIPS = mContext.mFingerprint;
                    
               
                   
                
                

                  
                    return "OK";
                }
                return "";
            }

            #endregion
            protected override void OnPostExecute(Java.Lang.Object obj)
            {
                if (obj.ToString() != "OK")
                {
                    Toast.MakeText(mContext, "init failuer", ToastLength.Short).Show();
                }
                else
                    Toast.MakeText(mContext, "init OK", ToastLength.Short).Show();
                pro.Cancel();
            }

        }
    }
}

