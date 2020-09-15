package crc645919b2a42a582147;


public class Acquisition_UIHand
	extends android.os.Handler
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_handleMessage:(Landroid/os/Message;)V:GetHandleMessage_Landroid_os_Message_Handler\n" +
			"";
		mono.android.Runtime.register ("demo_fingerprint_fips.Acquisition+UIHand, demo_fingerprint_fips", Acquisition_UIHand.class, __md_methods);
	}


	public Acquisition_UIHand ()
	{
		super ();
		if (getClass () == Acquisition_UIHand.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.Acquisition+UIHand, demo_fingerprint_fips", "", this, new java.lang.Object[] {  });
	}


	public Acquisition_UIHand (android.os.Handler.Callback p0)
	{
		super (p0);
		if (getClass () == Acquisition_UIHand.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.Acquisition+UIHand, demo_fingerprint_fips", "Android.OS.Handler+ICallback, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public Acquisition_UIHand (android.os.Looper p0)
	{
		super (p0);
		if (getClass () == Acquisition_UIHand.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.Acquisition+UIHand, demo_fingerprint_fips", "Android.OS.Looper, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public Acquisition_UIHand (android.os.Looper p0, android.os.Handler.Callback p1)
	{
		super (p0, p1);
		if (getClass () == Acquisition_UIHand.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.Acquisition+UIHand, demo_fingerprint_fips", "Android.OS.Looper, Mono.Android:Android.OS.Handler+ICallback, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}

	public Acquisition_UIHand (crc645919b2a42a582147.Acquisition p0)
	{
		super ();
		if (getClass () == Acquisition_UIHand.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.Acquisition+UIHand, demo_fingerprint_fips", "demo_fingerprint_fips.Acquisition, demo_fingerprint_fips", this, new java.lang.Object[] { p0 });
	}


	public void handleMessage (android.os.Message p0)
	{
		n_handleMessage (p0);
	}

	private native void n_handleMessage (android.os.Message p0);

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
