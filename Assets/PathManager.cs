using UnityEngine;
using System.Collections;

public class PathManager : MonoBehaviour 
{
	public bool IsPartOfPath;
	public int PathNumber;
	public string RopeEnd1;
	public string RopeEnd2;
	public int OriginalPathNumber;
	public int RopeVoltage1;
	public int RopeVoltage2;

	public static bool batteryisconnectedtomotor = false;
	public static bool motorisconnectedtoammeter = false;
	public static bool ammeterisconnectedtoresistor = false;
	public static bool resistorisconnectedtobattery = false;
	public static bool circuitcomplete=false;

	public static bool voltmeterisconnectedtomotor=false;

	// Use this for initialization
	void Start () 
	{
		IsPartOfPath = false;
		OriginalPathNumber = transform.GetSiblingIndex ();
		PathNumber = OriginalPathNumber;
		RopeEnd1 = null;
		RopeEnd2 = null;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
