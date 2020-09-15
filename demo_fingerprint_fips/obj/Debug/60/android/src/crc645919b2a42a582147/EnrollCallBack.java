package crc645919b2a42a582147;


public class EnrollCallBack
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.rscja.deviceapi.FingerprintWithFIPS.EnrollCallBack
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_messageInfo:(Ljava/lang/String;)V:GetMessageInfo_Ljava_lang_String_Handler:Com.Rscja.Deviceapi.FingerprintWithFIPS/IEnrollCallBackInvoker, DeviceAPI\n" +
			"n_onComplete:(Z[BII)V:GetOnComplete_ZarrayBIIHandler:Com.Rscja.Deviceapi.FingerprintWithFIPS/IEnrollCallBackInvoker, DeviceAPI\n" +
			"";
		mono.android.Runtime.register ("demo_fingerprint_fips.EnrollCallBack, demo_fingerprint_fips", EnrollCallBack.class, __md_methods);
	}


	public EnrollCallBack ()
	{
		super ();
		if (getClass () == EnrollCallBack.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.EnrollCallBack, demo_fingerprint_fips", "", this, new java.lang.Object[] {  });
	}

	public EnrollCallBack (crc645919b2a42a582147.Acquisition p0)
	{
		super ();
		if (getClass () == EnrollCallBack.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.EnrollCallBack, demo_fingerprint_fips", "demo_fingerprint_fips.Acquisition, demo_fingerprint_fips", this, new java.lang.Object[] { p0 });
	}


	public void messageInfo (java.lang.String p0)
	{
		n_messageInfo (p0);
	}

	private native void n_messageInfo (java.lang.String p0);


	public void onComplete (boolean p0, byte[] p1, int p2, int p3)
	{
		n_onComplete (p0, p1, p2, p3);
	}

	private native void n_onComplete (boolean p0, byte[] p1, int p2, int p3);

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
