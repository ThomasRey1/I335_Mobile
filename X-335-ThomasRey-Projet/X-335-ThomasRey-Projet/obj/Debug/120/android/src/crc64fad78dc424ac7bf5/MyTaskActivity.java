package crc64fad78dc424ac7bf5;


public class MyTaskActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("X_335_ThomasRey_Projet.MyTaskActivity, X-335-ThomasRey-Projet", MyTaskActivity.class, __md_methods);
	}


	public MyTaskActivity ()
	{
		super ();
		if (getClass () == MyTaskActivity.class) {
			mono.android.TypeManager.Activate ("X_335_ThomasRey_Projet.MyTaskActivity, X-335-ThomasRey-Projet", "", this, new java.lang.Object[] {  });
		}
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
