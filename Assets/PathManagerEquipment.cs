using UnityEngine;
using System.Collections;

public class PathManagerEquipment : MonoBehaviour 
{
	public bool positive_terminal_connected;
	public bool negative_terminal_connected;

	public string positive_terminal_wire_attached;
	public string negative_terminal_wire_attached;

	public string positive_terminal_wire_attached2;
	public string negative_terminal_wire_attached2;

	public int PathNumber;
	// Use this for initialization
	void Start () 
	{
		
		positive_terminal_connected = false;
		negative_terminal_connected = false;
		positive_terminal_wire_attached = Random.value.ToString();
		negative_terminal_wire_attached = Random.value.ToString();
		positive_terminal_wire_attached2 = Random.value.ToString();
		negative_terminal_wire_attached2 = Random.value.ToString();

		Debug.Log (Random.value);
		PathNumber = 666;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
