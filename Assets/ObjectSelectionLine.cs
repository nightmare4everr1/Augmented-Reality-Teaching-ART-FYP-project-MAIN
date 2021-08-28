using UnityEngine;
using System.Collections;

public class ObjectSelectionLine : MonoBehaviour 
{
	Transform tr1;
	Transform tr2;
	LineRenderer myline;


	// Use this for initialization
	void Start () 
	{
		myline=GetComponent<LineRenderer> ();
		tr1 = GetComponent<Transform> ();
		tr2 = GameObject.Find ("WORLDTEXT_LINEORIGIN").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		myline.SetPosition (0, tr1.position);
		myline.SetPosition (1, tr2.position);
	}
}
