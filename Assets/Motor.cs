using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour 
{
	Transform tr;
	public static float speed=1;
	public static float resistance = 1.75f;


	// Use this for initialization
	void Start () 
	{
		tr = GetComponent<Transform> ();



	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (PathManager.circuitcomplete == false) 
		{
			speed = 0;
		}
		tr.GetChild (3).RotateAround(tr.position,Vector3.up,speed);



	
	}
}
