using UnityEngine;
using System.Collections;

public class ResistorScript : MonoBehaviour 
{
	Transform contacts_tr;
	public static float resistance;

	Ammeter ammeter_script;
	VoltmeterScript voltmeter_script;

	TextMesh ammeter_value;

	// Use this for initialization
	void Start () 
	{
		ammeter_value = GameObject.Find ("Ammeter Value").GetComponent<TextMesh> ();
		ammeter_script = GameObject.Find ("Ammeter").GetComponent<Ammeter> ();
		voltmeter_script = GameObject.Find ("Voltmeter").GetComponent<VoltmeterScript> ();
		resistance = 0;
		contacts_tr = GameObject.Find ("Resistor").transform.GetChild (0).GetComponent<Transform> ();
		contacts_tr.localPosition = new Vector3 (0f, 28.02296f, -12.5f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		float pos = contacts_tr.localPosition.z;

		if (pos < -12.5f) 
		{
			contacts_tr.localPosition = new Vector3(0f , 28.02296f, -12.5f);
		}
		if (pos > 12.5f) 
		{
			contacts_tr.localPosition = new Vector3(0f , 28.02296f, 12.5f);
		}


		resistance = 0.3f*(12.5f + contacts_tr.localPosition.z)+0.25f;

		if (PathManager.circuitcomplete == true) 
		{ 
			
			float R_equivalent = resistance + Motor.resistance;
			float voltage_total = Battery.voltage;
			float current = voltage_total / R_equivalent;

			Motor.speed = current * 5f;
			ammeter_script.SetNeedlePosition (current);
			ammeter_value.text = current.ToString();
		} 
		else 
		{
			ammeter_value.text = null;
			ammeter_script.SetNeedlePosition (0);
			voltmeter_script.SetNeedlePosition (0);
		}

		if (PathManager.circuitcomplete == true && PathManager.voltmeterisconnectedtomotor == true)
		{
			float R_equivalent = resistance + Motor.resistance;
			float voltage_total = Battery.voltage;
			float current = voltage_total / R_equivalent;

			float Voltage_motor = current * Motor.resistance;
			voltmeter_script.SetNeedlePosition (Voltage_motor);

		}
		if (PathManager.circuitcomplete == true && PathManager.voltmeterisconnectedtomotor == false) 
		{
			voltmeter_script.SetNeedlePosition (0);
		}



	}
}
