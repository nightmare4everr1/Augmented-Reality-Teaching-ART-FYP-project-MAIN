using UnityEngine;
using System.Collections;
using Vuforia;
using UnityEngine.UI;

public class  buttonScript : MonoBehaviour, IVirtualButtonEventHandler 
{
	private GameObject buttonObject;

	public GameObject obj;
	public GameObject Rope_Prefab;
	public GameObject Rope_List;
	public static int counter;
	public AudioSource ropesound;

	// Use this for initialization
	void Start () 
	{
		ropesound = GetComponent<AudioSource> ();
		buttonObject = GameObject.Find ("actionButton");
		buttonObject.GetComponent<VirtualButtonAbstractBehaviour> ().RegisterEventHandler (this);


	}







	public void OnButtonPressed(VirtualButtonAbstractBehaviour x)
	{
		ropesound.Stop();
		ropesound.Play();
		obj = Instantiate (Rope_Prefab,new Vector3(counter,40,0), Quaternion.identity) as GameObject;
		int i = 0;
		for(i=0;i<9;i=i+1)
		{
			obj.transform.GetChild (i).position = new Vector3 (counter, 5, -i*3);
		}
		
		obj.transform.GetChild(0).GetComponent<Renderer> ().material.color = Color.gray;
		obj.transform.GetChild(8).GetComponent<Renderer> ().material.color = Color.gray;
		
		
		obj.transform.parent = Rope_List.transform;
		
		counter=counter+3;

		if (counter > 3 * 5)
			counter = 0;

	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour x)
	{
		
	}
}