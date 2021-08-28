using UnityEngine;
using System.Collections;

public class Ammeter : MonoBehaviour 
{
	Transform tr;
	Transform tr2;
	Transform tr3;
	Vector3 v;
	public float needlerotation = 0f;






	// Use this for initialization
	void Start () 
	{

		tr = GetComponent<Transform> ();
		tr2 = tr.GetChild (5).GetComponent<Transform> ();
		tr3 = tr.GetChild (6).GetComponent <Transform> ();
		v = tr3.position - tr2.position;


		tr.GetChild (1).RotateAround (tr2.position, v, -40);
		//sets needle to zero

		//tr.GetChild (1).RotateAround (tr2.position, v, 85);
		//^85 value makes needle travel whole scale from 0-10,
	
	}

	public void SetNeedlePosition (float current)
	{
		tr.GetChild (1).RotateAround (tr2.position, v, -needlerotation);

		needlerotation = current * 8.5f;
		tr.GetChild (1).RotateAround (tr2.position, v, needlerotation);
	}


	// Update is called once per frame
	void Update () 
	{
		



	}


}
