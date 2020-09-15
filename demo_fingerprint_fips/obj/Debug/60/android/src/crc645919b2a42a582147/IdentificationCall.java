package crc645919b2a42a582147;


public class IdentificationCall
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.rscja.deviceapi.FingerprintWithFIPS.IdentificationCallBack
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_messageInfo:(Ljava/lang/String;)V:GetMessageInfo_Ljava_lang_String_Handler:Com.Rscja.Deviceapi.FingerprintWithFIPS/IIdentificationCallBackInvoker, DeviceAPI\n" +
			"n_onComplete:(ZII)V:GetOnComplete_ZIIHandler:Com.Rscja.Deviceapi.FingerprintWithFIPS/IIdentificationCallBackInvoker, DeviceAPI\n" +
			"";
		mono.android.Runtime.register ("demo_fingerprint_fips.IdentificationCall, demo_fingerprint_fips", IdentificationCall.class, __md_methods);
	}


	public IdentificationCall ()
	{
		super ();
		if (getClass () == IdentificationCall.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.IdentificationCall, demo_fingerprint_fips", "", this, new java.lang.Object[] {  });
	}

	public IdentificationCall (crc645919b2a42a582147.Identification p0)
	{
		super ();
		if (getClass () == IdentificationCall.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.IdentificationCall, demo_fingerprint_fips", "demo_fingerprint_fips.Identification, demo_fingerprint_fips", this, new java.lang.Object[] { p0 });
	}


	public void messageInfo (java.lang.String p0)
	{
		n_messageInfo (p0);
	}

	private native void n_messageInfo (java.lang.String p0);


	public void onComplete (boolean p0, int p1, int p2)
	{
		n_onComplete (p0, p1, p2);
	}

	private native void n_onComplete (boolean p0, int p1, int p2);

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
