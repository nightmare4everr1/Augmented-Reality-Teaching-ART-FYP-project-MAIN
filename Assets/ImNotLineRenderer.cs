using UnityEngine;
using System.Collections;

public class ImNotLineRenderer : MonoBehaviour {

	Transform tr1;
	/*
	Transform tr2;
	Transform tr3;
	Transform tr4;
	Transform tr5;
	Transform tr6;
	Transform tr7;
	Transform tr8;
	Transform tr9;
	*/

	LineRenderer myline;

	// Use this for initialization
	void Start () 
	{
		myline = GetComponent<LineRenderer> ();
		/*tr1 = GameObject.Find ("Hinge_top").GetComponent<Transform> ();
		tr2 = GameObject.Find ("Rope1").GetComponent<Transform> ();
		tr3 = GameObject.Find ("Rope2").GetComponent<Transform> ();
		tr4 = GameObject.Find ("Rope3").GetComponent<Transform> ();
		tr5 = GameObject.Find ("Rope4").GetComponent<Transform> ();
		tr6 = GameObject.Find ("Rope5").GetComponent<Transform> ();
		tr7 = GameObject.Find ("Rope6").GetComponent<Transform> ();
		tr8 = GameObject.Find ("Rope7").GetComponent<Transform> ();
		tr9 = GameObject.Find ("Hinge_bottom").GetComponent<Transform> ();
		*/

		tr1 = GetComponent<Transform> ();


	
	}
	
	// Update is called once per frame
	void Update () 
	{
		myline.SetPosition (0, tr1.GetChild(0).transform.position);
		myline.SetPosition (1, tr1.GetChild(1).transform.position);
		myline.SetPosition (2, tr1.GetChild(2).transform.position);
		myline.SetPosition (3, tr1.GetChild(3).transform.position);
		myline.SetPosition (4, tr1.GetChild(4).transform.position);
		myline.SetPosition (5, tr1.GetChild(5).transform.position);
		myline.SetPosition (6, tr1.GetChild(6).transform.position);
		myline.SetPosition (7, tr1.GetChild(7).transform.position);
		myline.SetPosition (8, tr1.GetChild(8).transform.position);
	
	}
}
