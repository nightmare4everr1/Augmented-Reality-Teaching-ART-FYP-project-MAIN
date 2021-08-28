using UnityEngine;
using System.Collections;

public class RopePhysics : MonoBehaviour 
{

	public int mass ;
	public int drag ;
	public int angulardrag ;
	Transform tr;
	Rigidbody rb1;


	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < 9; i++) 
		{

			tr = GetComponent<Transform> ();

			rb1 = tr.transform.GetChild (i).GetComponent<Rigidbody> ();
			rb1.mass = mass;
			Debug.Log (mass);
			rb1.drag = drag;
			rb1.angularDrag = angulardrag;
			
		}



	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
