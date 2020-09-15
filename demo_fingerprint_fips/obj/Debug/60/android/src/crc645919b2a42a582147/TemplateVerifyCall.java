package crc645919b2a42a582147;


public class TemplateVerifyCall
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.rscja.deviceapi.FingerprintWithFIPS.TemplateVerifyCallBack
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_messageInfo:(Ljava/lang/String;)V:GetMessageInfo_Ljava_lang_String_Handler:Com.Rscja.Deviceapi.FingerprintWithFIPS/ITemplateVerifyCallBackInvoker, DeviceAPI\n" +
			"n_onComplete:(ZI)V:GetOnComplete_ZIHandler:Com.Rscja.Deviceapi.FingerprintWithFIPS/ITemplateVerifyCallBackInvoker, DeviceAPI\n" +
			"";
		mono.android.Runtime.register ("demo_fingerprint_fips.TemplateVerifyCall, demo_fingerprint_fips", TemplateVerifyCall.class, __md_methods);
	}


	public TemplateVerifyCall ()
	{
		super ();
		if (getClass () == TemplateVerifyCall.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.TemplateVerifyCall, demo_fingerprint_fips", "", this, new java.lang.Object[] {  });
	}

	public TemplateVerifyCall (crc645919b2a42a582147.Verify p0)
	{
		super ();
		if (getClass () == TemplateVerifyCall.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.TemplateVerifyCall, demo_fingerprint_fips", "demo_fingerprint_fips.Verify, demo_fingerprint_fips", this, new java.lang.Object[] { p0 });
	}


	public void messageInfo (java.lang.String p0)
	{
		n_messageInfo (p0);
	}

	private native void n_messageInfo (java.lang.String p0);


	public void onComplete (boolean p0, int p1)
	{
		n_onComplete (p0, p1);
	}

	private native void n_onComplete (boolean p0, int p1);

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
