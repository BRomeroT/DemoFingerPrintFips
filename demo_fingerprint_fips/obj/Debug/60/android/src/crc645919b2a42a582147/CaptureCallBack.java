package crc645919b2a42a582147;


public class CaptureCallBack
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.rscja.deviceapi.FingerprintWithFIPS.PtCaptureCallBack
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_messageInfo:(Ljava/lang/String;)V:GetMessageInfo_Ljava_lang_String_Handler:Com.Rscja.Deviceapi.FingerprintWithFIPS/IPtCaptureCallBackInvoker, DeviceAPI\n" +
			"n_onComplete:(Z[BI)V:GetOnComplete_ZarrayBIHandler:Com.Rscja.Deviceapi.FingerprintWithFIPS/IPtCaptureCallBackInvoker, DeviceAPI\n" +
			"";
		mono.android.Runtime.register ("demo_fingerprint_fips.CaptureCallBack, demo_fingerprint_fips", CaptureCallBack.class, __md_methods);
	}


	public CaptureCallBack ()
	{
		super ();
		if (getClass () == CaptureCallBack.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.CaptureCallBack, demo_fingerprint_fips", "", this, new java.lang.Object[] {  });
	}

	public CaptureCallBack (crc645919b2a42a582147.Acquisition p0)
	{
		super ();
		if (getClass () == CaptureCallBack.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.CaptureCallBack, demo_fingerprint_fips", "demo_fingerprint_fips.Acquisition, demo_fingerprint_fips", this, new java.lang.Object[] { p0 });
	}


	public void messageInfo (java.lang.String p0)
	{
		n_messageInfo (p0);
	}

	private native void n_messageInfo (java.lang.String p0);


	public void onComplete (boolean p0, byte[] p1, int p2)
	{
		n_onComplete (p0, p1, p2);
	}

	private native void n_onComplete (boolean p0, byte[] p1, int p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
