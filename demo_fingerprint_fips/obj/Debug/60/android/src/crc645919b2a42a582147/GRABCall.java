package crc645919b2a42a582147;


public class GRABCall
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.rscja.deviceapi.FingerprintWithFIPS.GRABCallBack
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_messageInfo:(Ljava/lang/String;)V:GetMessageInfo_Ljava_lang_String_Handler:Com.Rscja.Deviceapi.FingerprintWithFIPS/IGRABCallBackInvoker, DeviceAPI\n" +
			"n_onComplete:(Z[BI)V:GetOnComplete_ZarrayBIHandler:Com.Rscja.Deviceapi.FingerprintWithFIPS/IGRABCallBackInvoker, DeviceAPI\n" +
			"n_progress:(I)V:GetProgress_IHandler:Com.Rscja.Deviceapi.FingerprintWithFIPS/IGRABCallBackInvoker, DeviceAPI\n" +
			"";
		mono.android.Runtime.register ("demo_fingerprint_fips.GRABCall, demo_fingerprint_fips", GRABCall.class, __md_methods);
	}


	public GRABCall ()
	{
		super ();
		if (getClass () == GRABCall.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.GRABCall, demo_fingerprint_fips", "", this, new java.lang.Object[] {  });
	}

	public GRABCall (crc645919b2a42a582147.Grab p0)
	{
		super ();
		if (getClass () == GRABCall.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.GRABCall, demo_fingerprint_fips", "demo_fingerprint_fips.Grab, demo_fingerprint_fips", this, new java.lang.Object[] { p0 });
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


	public void progress (int p0)
	{
		n_progress (p0);
	}

	private native void n_progress (int p0);

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
