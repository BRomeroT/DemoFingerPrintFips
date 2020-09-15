package crc645919b2a42a582147;


public class MainActivity_init14443
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPreExecute:()V:GetOnPreExecuteHandler\n" +
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("demo_fingerprint_fips.MainActivity+init14443, demo_fingerprint_fips", MainActivity_init14443.class, __md_methods);
	}


	public MainActivity_init14443 ()
	{
		super ();
		if (getClass () == MainActivity_init14443.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.MainActivity+init14443, demo_fingerprint_fips", "", this, new java.lang.Object[] {  });
	}

	public MainActivity_init14443 (crc645919b2a42a582147.MainActivity p0)
	{
		super ();
		if (getClass () == MainActivity_init14443.class)
			mono.android.TypeManager.Activate ("demo_fingerprint_fips.MainActivity+init14443, demo_fingerprint_fips", "demo_fingerprint_fips.MainActivity, demo_fingerprint_fips", this, new java.lang.Object[] { p0 });
	}


	public void onPreExecute ()
	{
		n_onPreExecute ();
	}

	private native void n_onPreExecute ();


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);

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
