using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RopeInteraction2 : MonoBehaviour 
{
	Transform battery_tr;
	Transform motor_tr;
	Transform ammeter_tr;
	Transform resistor_tr;
	Transform voltmeter_tr;

	PathManagerEquipment batteryPE;
	PathManagerEquipment motorPE;
	PathManagerEquipment ammeterPE;
	PathManagerEquipment resistorPE;
	PathManagerEquipment voltmeterPE;

	Ammeter ammeter_script;


	public string RopeAttached2;
	PathManager pathmanager;
	RopeInteraction r1;
	PathManagerEquipment pathmanagerequipment;
	ParticleSystem ps;
	AudioSource attach_wire;
	AudioSource circuitstarts_sound;



	// Use this for initialization
	void Start () 
	{
		
		circuitstarts_sound = GameObject.Find ("Sound_CircuitStarts").GetComponent<AudioSource> ();
		attach_wire =GameObject.Find("Sound_AttachWire").GetComponent<AudioSource> ();
		battery_tr = GameObject.Find ("Battery").GetComponent<Transform> ();
		motor_tr = GameObject.Find ("Motor").GetComponent<Transform> ();
		ammeter_tr = GameObject.Find ("Ammeter").GetComponent<Transform> ();
		resistor_tr = GameObject.Find ("Resistor").GetComponent<Transform> ();
		voltmeter_tr = GameObject.Find ("Voltmeter").GetComponent<Transform> ();

		batteryPE = battery_tr.transform.GetComponent<PathManagerEquipment> ();
		motorPE = motor_tr.transform.GetComponent<PathManagerEquipment> ();
		ammeterPE = ammeter_tr.transform.GetComponent<PathManagerEquipment> ();
		resistorPE = resistor_tr.transform.GetComponent<PathManagerEquipment> ();
		voltmeterPE = voltmeter_tr.transform.GetComponent<PathManagerEquipment> ();

		ammeter_script = ammeter_tr.transform.GetComponent<Ammeter> ();


		RopeAttached2 = null;
		pathmanager = transform.parent.GetComponent<PathManager> ();
		r1 = transform.parent.GetChild (0).GetComponent<RopeInteraction> ();
		ps = GetComponent<ParticleSystem> ();

	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	/*
	bool IsCircuitComplete(Collider other)
	{
		string RopeAttached1 = r1.RopeAttached1;


		if (PathManager.batteryisconnectedtomotor && PathManager.motorisconnectedtoammeter && PathManager.ammeterisconnectedtoresistor && PathManager.resistorisconnectedtobattery) 
		{
			return true;
		} 


		if (RopeAttached1 == null || RopeAttached2 == null)
			return false;

		if(RopeAttached1.Contains("Battery_P") && RopeAttached2.Contains("Motor_N") || RopeAttached2.Contains("Battery_P")&& RopeAttached1.Contains("Motor_N"))
		{
			PathManager.batteryisconnectedtomotor = true;
			Debug.Log ("step1");
		}

		if(RopeAttached1.Contains("Motor_P") && RopeAttached2.Contains("A_Negative") || RopeAttached2.Contains("Motor_P") && RopeAttached1.Contains("A_Negative"))
		{
			PathManager.motorisconnectedtoammeter = true;
			Debug.Log ("step2");
		}
		if (RopeAttached1.Contains ("A_Positive") && RopeAttached2.Contains ("R_Negative") || RopeAttached2.Contains ("A_Positive") && RopeAttached1.Contains ("R_Negative"))
		{
			PathManager.ammeterisconnectedtoresistor = true;
			Debug.Log ("step3");
		}
		if (RopeAttached1.Contains ("R_Positive") && RopeAttached2.Contains ("Battery_N") || RopeAttached2.Contains ("R_Positive") && RopeAttached1.Contains ("Battery_N"))
		{
			PathManager.resistorisconnectedtobattery = true;
			Debug.Log ("step4");
		}
		if (RopeAttached1.Contains ("V_Positive") && RopeAttached2.Contains ("Motor_N") || RopeAttached2.Contains ("V_Positive") && RopeAttached1.Contains ("Motor_N")) 
		{
			PathManager.voltmeterisconnectedtomotor = true;
			Debug.Log ("Voltmeter Attached");
		}
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////
		if(RopeAttached1.Contains("Battery_N") && RopeAttached2.Contains("Motor_P") || RopeAttached2.Contains("Battery_Negative")&& RopeAttached1.Contains("Motor_P"))
		{
			PathManager.batteryisconnectedtomotor = true;
			Debug.Log ("step1");
		}

		if(RopeAttached1.Contains("Motor_N") && RopeAttached2.Contains("A_Positive") || RopeAttached2.Contains("Motor_N") && RopeAttached1.Contains("A_Positive"))
		{
			PathManager.motorisconnectedtoammeter = true;
			Debug.Log ("step2");
		}
		if (RopeAttached1.Contains ("A_Negative") && RopeAttached2.Contains ("R_Positive") || RopeAttached2.Contains ("A_Negative") && RopeAttached1.Contains ("R_Positive"))
		{
			PathManager.ammeterisconnectedtoresistor = true;
			Debug.Log ("step3");
		}
		if (RopeAttached1.Contains ("R_Negative") && RopeAttached2.Contains ("Battery_Positive") || RopeAttached2.Contains ("R_Negative") && RopeAttached1.Contains ("Battery_P"))
		{
			PathManager.resistorisconnectedtobattery = true;
			Debug.Log ("step4");
		}
		if (RopeAttached1.Contains ("V_Negative") && RopeAttached2.Contains ("Motor_P") || RopeAttached2.Contains ("V_Negative") && RopeAttached1.Contains ("Motor_P")) 
		{
			PathManager.voltmeterisconnectedtomotor = true;
			Debug.Log ("Voltmeter Attached");
		}

		Debug.Log ("RopeInteraction2");
		Debug.Log ("batteryisconnectedtomotor " + PathManager.batteryisconnectedtomotor);
		Debug.Log ("motorisconnectedtoammeter " + PathManager.motorisconnectedtoammeter);
		Debug.Log ("ammeterisconnectedtoresistor " + PathManager.ammeterisconnectedtoresistor);
		Debug.Log ("resistorisconnectedtobattery " + PathManager.resistorisconnectedtobattery);
		Debug.Log ("voltmeterisconnectedtobattery " + PathManager.voltmeterisconnectedtomotor);
		if (PathManager.batteryisconnectedtomotor && PathManager.motorisconnectedtoammeter && PathManager.ammeterisconnectedtoresistor && PathManager.resistorisconnectedtobattery) 
		{
			Debug.Log ("Final");
			return true;
		} 
		return false;

	}


	void BreakCircuitConnections(Collider other)
	{

		Transform battery = GameObject.Find ("Battery").GetComponent<Transform> ();
		Transform motor = GameObject.Find ("Motor").GetComponent<Transform> ();
		Transform ammeter = GameObject.Find ("Ammeter").GetComponent<Transform> ();
		Transform resistor = GameObject.Find ("Resistor").GetComponent<Transform> ();

		PathManagerEquipment batteryPE = battery.transform.GetComponent<PathManagerEquipment> ();
		PathManagerEquipment motorPE = motor.transform.GetComponent<PathManagerEquipment> ();
		PathManagerEquipment ammeterPE = ammeter.transform.GetComponent<PathManagerEquipment> ();
		PathManagerEquipment resistorPE = resistor.transform.GetComponent<PathManagerEquipment> ();

		if ((batteryPE.positive_terminal_connected == false || motorPE.negative_terminal_connected==false) && (batteryPE.negative_terminal_connected==false || motorPE.positive_terminal_connected==false)) 
		{
			PathManager.batteryisconnectedtomotor = false;
		}
		if ((motorPE.positive_terminal_connected == false || ammeterPE.negative_terminal_connected == false) && (motorPE.negative_terminal_connected == false || ammeterPE.positive_terminal_connected == false)) 
		{
			PathManager.motorisconnectedtoammeter = false;
		}
		if ((ammeterPE.positive_terminal_connected == false || resistorPE.negative_terminal_connected == false)&&(ammeterPE.negative_terminal_connected == false || resistorPE.positive_terminal_connected == false)) 
		{
			PathManager.ammeterisconnectedtoresistor = false;
		}
		if ((resistorPE.positive_terminal_connected == false || batteryPE.negative_terminal_connected == false)&&(resistorPE.negative_terminal_connected == false || batteryPE.positive_terminal_connected == false)) 
		{
			PathManager.resistorisconnectedtobattery = false;
		}
		if ((voltmeterPE.positive_terminal_connected == false || motorPE.negative_terminal_connected == false) && (voltmeterPE.negative_terminal_connected == false || motorPE.positive_terminal_connected == false)) 
		{
			PathManager.voltmeterisconnectedtomotor = false;
		}

		Debug.Log ("RopeInteraction2_Exit");
		Debug.Log ("batteryisconnectedtomotor " + PathManager.batteryisconnectedtomotor);
		Debug.Log ("motorisconnectedtoammeter " + PathManager.motorisconnectedtoammeter);
		Debug.Log ("ammeterisconnectedtoresistor " + PathManager.ammeterisconnectedtoresistor);
		Debug.Log ("resistorisconnectedtobattery " + PathManager.resistorisconnectedtobattery);
		Debug.Log ("voltmeterisconnectedtobattery " + PathManager.voltmeterisconnectedtomotor);
		if (IsCircuitComplete(other) == false) 
		{
			Debug.Log ("CIRCUIT BROKEN");
			PathManager.circuitcomplete = false;


		}



	}
	*/


	bool IsCircuitComplete_new (Collider other)
	{
		string RopeAttached1 = r1.RopeAttached1;

		if (PathManager.batteryisconnectedtomotor && PathManager.motorisconnectedtoammeter && PathManager.ammeterisconnectedtoresistor && PathManager.resistorisconnectedtobattery) 
		{
			if (RopeAttached1 != null || RopeAttached2 != null) 
			{
				if (voltmeterPE.positive_terminal_wire_attached==motorPE.negative_terminal_wire_attached2 && voltmeterPE.negative_terminal_wire_attached==motorPE.positive_terminal_wire_attached2)
				{
					Debug.Log ("Voltmeter Attached");
					PathManager.voltmeterisconnectedtomotor = true;
				}
			}
			return true;
		} 
		if (RopeAttached1 == null || RopeAttached2 == null)
			return false;

		if (batteryPE.positive_terminal_wire_attached==motorPE.negative_terminal_wire_attached || batteryPE.negative_terminal_wire_attached==motorPE.positive_terminal_wire_attached)
		{
			Debug.Log ("new step1");
			PathManager.batteryisconnectedtomotor = true;
		}
		if (motorPE.positive_terminal_wire_attached==ammeterPE.negative_terminal_wire_attached || motorPE.negative_terminal_wire_attached==ammeterPE.positive_terminal_wire_attached)
		{
			Debug.Log ("new step2");
			PathManager.motorisconnectedtoammeter = true;
		}
		if (ammeterPE.positive_terminal_wire_attached==resistorPE.negative_terminal_wire_attached || ammeterPE.negative_terminal_wire_attached==resistorPE.positive_terminal_wire_attached)
		{
			Debug.Log ("new step3");
			PathManager.ammeterisconnectedtoresistor = true;
		}
		if (resistorPE.positive_terminal_wire_attached==batteryPE.negative_terminal_wire_attached || resistorPE.negative_terminal_wire_attached==batteryPE.positive_terminal_wire_attached)
		{
			Debug.Log ("new step4");
			PathManager.resistorisconnectedtobattery = true;
		}
		///{2 wires PROBLEM)
		if (voltmeterPE.positive_terminal_wire_attached==motorPE.negative_terminal_wire_attached2 && voltmeterPE.negative_terminal_wire_attached==motorPE.positive_terminal_wire_attached2)
		{
			Debug.Log ("Voltmeter Attached");
			PathManager.voltmeterisconnectedtomotor = true;
		}
		Text myDebug = GameObject.Find ("myDebug").GetComponent<Text> ();

		myDebug.text = (PathManager.batteryisconnectedtomotor +" "+ PathManager.motorisconnectedtoammeter +" "+ PathManager.ammeterisconnectedtoresistor +" "+ PathManager.resistorisconnectedtobattery +" "+ PathManager.circuitcomplete);
		Debug.Log ("RopeInteraction");
		Debug.Log ("batteryisconnectedtomotor " + PathManager.batteryisconnectedtomotor);
		Debug.Log ("motorisconnectedtoammeter " + PathManager.motorisconnectedtoammeter);
		Debug.Log ("ammeterisconnectedtoresistor " + PathManager.ammeterisconnectedtoresistor);
		Debug.Log ("resistorisconnectedtobattery " + PathManager.resistorisconnectedtobattery);
		Debug.Log ("voltmeterisconnectedtobattery " + PathManager.voltmeterisconnectedtomotor);
		Debug.Log ("Volt_P = " + voltmeterPE.positive_terminal_wire_attached + " Motor_N2 = " + motorPE.negative_terminal_wire_attached2 + " Volt_N = " + voltmeterPE.negative_terminal_wire_attached + " Motor_P2 = " + motorPE.positive_terminal_wire_attached2);
		if (PathManager.batteryisconnectedtomotor && PathManager.motorisconnectedtoammeter && PathManager.ammeterisconnectedtoresistor && PathManager.resistorisconnectedtobattery) 
		{
			Debug.Log ("Final");
			return true;
		} 
		return false;

	}

	void BreakCircuitConnections_new(Collider other)
	{

		if (batteryPE.positive_terminal_wire_attached != motorPE.negative_terminal_wire_attached && batteryPE.negative_terminal_wire_attached != motorPE.positive_terminal_wire_attached) 
		{
			PathManager.batteryisconnectedtomotor = false;
		}
		if (motorPE.positive_terminal_wire_attached != ammeterPE.negative_terminal_wire_attached && motorPE.negative_terminal_wire_attached != ammeterPE.positive_terminal_wire_attached) 
		{
			PathManager.motorisconnectedtoammeter = false;
		}
		if (ammeterPE.positive_terminal_wire_attached != resistorPE.negative_terminal_wire_attached && ammeterPE.negative_terminal_wire_attached != resistorPE.positive_terminal_wire_attached) 
		{
			PathManager.ammeterisconnectedtoresistor = false;
		}
		if (resistorPE.positive_terminal_wire_attached != batteryPE.negative_terminal_wire_attached && resistorPE.negative_terminal_wire_attached != batteryPE.positive_terminal_wire_attached) 
		{
			PathManager.resistorisconnectedtobattery = false;
		}
		if (voltmeterPE.positive_terminal_wire_attached != motorPE.negative_terminal_wire_attached2 || voltmeterPE.negative_terminal_wire_attached != motorPE.positive_terminal_wire_attached2) 
		{
			PathManager.voltmeterisconnectedtomotor = false;
		}
		Text myDebug = GameObject.Find ("myDebug").GetComponent<Text> ();

		myDebug.text = (PathManager.batteryisconnectedtomotor +" "+ PathManager.motorisconnectedtoammeter +" "+ PathManager.ammeterisconnectedtoresistor +" "+ PathManager.resistorisconnectedtobattery +" "+ PathManager.circuitcomplete);
		Debug.Log ("RopeInteraction_Exit_new");
		Debug.Log ("batteryisconnectedtomotor " + PathManager.batteryisconnectedtomotor);
		Debug.Log ("motorisconnectedtoammeter " + PathManager.motorisconnectedtoammeter);
		Debug.Log ("ammeterisconnectedtoresistor " + PathManager.ammeterisconnectedtoresistor);
		Debug.Log ("resistorisconnectedtobattery " + PathManager.resistorisconnectedtobattery);
		Debug.Log ("voltmeterisconnectedtobattery " + PathManager.voltmeterisconnectedtomotor);
		Debug.Log ("Volt_P = " + voltmeterPE.positive_terminal_wire_attached + " Motor_N2 = " + motorPE.negative_terminal_wire_attached2 + " Volt_N = " + voltmeterPE.negative_terminal_wire_attached + " Motor_P2 = " + motorPE.positive_terminal_wire_attached2);
		if (IsCircuitComplete_new(other) == false) 
		{
			Debug.Log ("CIRCUIT BROKEN");
			PathManager.circuitcomplete = false;


		}
	}


	bool IsRopeTouchingBadObjects(Collider other)
	{
		if (other.gameObject.name.Contains("Positive")==false && other.gameObject.name.Contains("Negative")==false || other.gameObject.name.Contains("Hinge")) 
		{
			return true;
		} 
		else 
		{
			/*
			PathManagerEquipment PE = other.gameObject.transform.parent.GetComponent<PathManagerEquipment> ();
			if(other.gameObject.name.Contains("Positive") && PE.positive_terminal_wire_attached.Contains("rope") && PE.positive_terminal_wire_attached2.Contains("rope"))
			{
				return true;
			}
			if(other.gameObject.name.Contains("Negative") && PE.negative_terminal_wire_attached.Contains("rope") && PE.negative_terminal_wire_attached2.Contains("rope"))
			{
				return true;
			}*/

			return false;
		}


	}

	void ChangeColorAndAssignTerminals2(Collider other)
	{
		PathManagerEquipment PE = other.gameObject.transform.parent.GetComponent<PathManagerEquipment> ();

		Debug.Log ("Hello1");

		if (other.gameObject.name.Contains ("Motor"))
		{
			if (other.gameObject.name.Contains ("Positive")) 
			{
				if (PE.positive_terminal_wire_attached.Contains ("rope") && PE.positive_terminal_wire_attached2.Contains ("rope"))
				{
					Debug.Log ("Cant Attach more than 2 to Motor Positive");
					return;
				}
			} 
			else 
			{
				if (PE.negative_terminal_wire_attached.Contains ("rope") && PE.negative_terminal_wire_attached2.Contains ("rope"))
				{
					Debug.Log ("Cant Attach more than 2 to Motor Negative");
					return;
				}
			}
		} 
		else 
		{
			if (other.gameObject.name.Contains ("Positive")) 
			{
				if (PE.positive_terminal_wire_attached.Contains ("rope"))
				{
					Debug.Log ("Cant Attach more than 1 to normal positive equipment");
					return;
				}
			} 
			else 
			{
				if (PE.negative_terminal_wire_attached.Contains ("rope"))
				{
					Debug.Log ("Cant Attach more than 1 to normal negative equipment");
					return;
				}
			}

		}





		string RopeAttached2 = r1.RopeAttached1;
		pathmanagerequipment = other.gameObject.transform.parent.GetComponent<PathManagerEquipment> ();
		if (other.gameObject.name.Contains ("Positive")) 
		{
			pathmanagerequipment.positive_terminal_connected = true;
			gameObject.GetComponent<Renderer>().material.color = Color.red;

			if (RopeAttached2 == null) 
			{
				if(other.gameObject.name.Contains("Motor"))
				{
					if (pathmanagerequipment.positive_terminal_wire_attached.Contains ("rope") == false) 
					{
						pathmanagerequipment.positive_terminal_wire_attached = "rope" + this.gameObject.transform.parent.GetSiblingIndex ();
					} 
					else 
					{
						pathmanagerequipment.positive_terminal_wire_attached2 = "rope" + this.gameObject.transform.parent.GetSiblingIndex ();
					}

				}
				else
				{ 
					pathmanagerequipment.positive_terminal_wire_attached = "rope" + this.gameObject.transform.parent.GetSiblingIndex ();
				}

			} 
			else
			{
				if (RopeAttached2.Contains ("V_"))
				{

					if (pathmanagerequipment.positive_terminal_wire_attached2.Contains ("rope")) 
					{
						string swaptemp = pathmanagerequipment.positive_terminal_wire_attached;
						string swaptemp2 = pathmanagerequipment.positive_terminal_wire_attached2;
						pathmanagerequipment.positive_terminal_wire_attached2 = swaptemp;
						pathmanagerequipment.positive_terminal_wire_attached = swaptemp2;

						pathmanagerequipment.positive_terminal_wire_attached = "rope" + this.gameObject.transform.parent.GetSiblingIndex ();
					} 
					else 
					{
						pathmanagerequipment.positive_terminal_wire_attached2= "rope" + this.gameObject.transform.parent.GetSiblingIndex ();
					}
				} 

				if (RopeAttached2.Contains ("Motor")) 
				{
					string myname = "rope" + this.gameObject.transform.parent.GetSiblingIndex ();
					if (other.gameObject.name.Contains ("V_")) 
					{
						
						PathManagerEquipment otherobject = GameObject.Find (RopeAttached2).transform.parent.GetComponent<PathManagerEquipment> ();
						if (otherobject.negative_terminal_wire_attached2.Contains(myname)==false)
						{
							string swaptemp = otherobject.negative_terminal_wire_attached;
							string swaptemp2 = otherobject.negative_terminal_wire_attached2;
							otherobject.negative_terminal_wire_attached2 = swaptemp;
							otherobject.negative_terminal_wire_attached = swaptemp2;
						}


					}
					pathmanagerequipment.positive_terminal_wire_attached = myname;
				}
				if (RopeAttached2.Contains ("Motor") == false && RopeAttached2.Contains ("V_") == false) 
				{
					pathmanagerequipment.positive_terminal_wire_attached = "rope" + this.gameObject.transform.parent.GetSiblingIndex ();
				}
			}
		}
		if (other.gameObject.name.Contains ("Negative")) 
		{
			pathmanagerequipment.negative_terminal_connected = true;
			gameObject.GetComponent<Renderer>().material.color = Color.black;

			if (RopeAttached2 == null) 
			{
				if(other.gameObject.name.Contains("Motor"))
				{
					if (pathmanagerequipment.negative_terminal_wire_attached.Contains ("rope") == false) 
					{
						pathmanagerequipment.negative_terminal_wire_attached = "rope" + this.gameObject.transform.parent.GetSiblingIndex ();
					} 
					else 
					{
						pathmanagerequipment.negative_terminal_wire_attached2 = "rope" + this.gameObject.transform.parent.GetSiblingIndex ();
					}

				}
				else
				{ 
					pathmanagerequipment.negative_terminal_wire_attached = "rope" + this.gameObject.transform.parent.GetSiblingIndex ();
				}

			} 
			else
			{
				if (RopeAttached2.Contains ("V_"))
				{

					if (pathmanagerequipment.negative_terminal_wire_attached2.Contains ("rope")) 
					{
						string swaptemp = pathmanagerequipment.negative_terminal_wire_attached;
						string swaptemp2 = pathmanagerequipment.negative_terminal_wire_attached2;
						pathmanagerequipment.negative_terminal_wire_attached2 = swaptemp;
						pathmanagerequipment.negative_terminal_wire_attached = swaptemp2;

						pathmanagerequipment.negative_terminal_wire_attached = "rope" + this.gameObject.transform.parent.GetSiblingIndex ();
					} 
					else 
					{
						pathmanagerequipment.negative_terminal_wire_attached2= "rope" + this.gameObject.transform.parent.GetSiblingIndex ();
					}
				} 

				if (RopeAttached2.Contains ("Motor")) 
				{
					string myname = "rope" + this.gameObject.transform.parent.GetSiblingIndex ();
					if (other.gameObject.name.Contains ("V_")) 
					{
						
						PathManagerEquipment otherobject = GameObject.Find (RopeAttached2).transform.parent.GetComponent<PathManagerEquipment> ();
						if (otherobject.positive_terminal_wire_attached2.Contains(myname)==false)
						{
							string swaptemp = otherobject.positive_terminal_wire_attached;
							string swaptemp2 = otherobject.positive_terminal_wire_attached2;
							otherobject.positive_terminal_wire_attached2 = swaptemp;
							otherobject.positive_terminal_wire_attached = swaptemp2;
						}


					}
					pathmanagerequipment.negative_terminal_wire_attached = myname;
				}
				if (RopeAttached2.Contains ("Motor") == false && RopeAttached2.Contains ("V_") == false) 
				{
					pathmanagerequipment.negative_terminal_wire_attached = "rope" + this.gameObject.transform.parent.GetSiblingIndex ();
				}
			}
		}


	}
	void OnTriggerEnter(Collider other)
	{
		if (IsRopeTouchingBadObjects(other) == true)
			return;
		if (r1.RopeAttached1 != null) 
		{
			if (r1.RopeAttached1.Contains ("Positive") && other.gameObject.name.Contains ("Positive")) 
			{
				Debug.Log ("Error: Cant attach positive terminal to another positive terminal");
				return;
			}
			if (r1.RopeAttached1.Contains ("Negative") && other.gameObject.name.Contains ("Negative")) 
			{
				Debug.Log ("Error: Cant attach negative terminal to another negative terminal");
				return;
			}
		}

		ChangeColorAndAssignTerminals2 (other);
		ps.Play ();
		RopeAttached2 = other.gameObject.name;
		pathmanager.RopeEnd2 = other.gameObject.name;

		attach_wire.Stop();
		attach_wire.Play ();

		if (r1.RopeAttached1 == null) 
		{
			Text Mobile_Debug;
			Mobile_Debug = GameObject.Find ("Mobile_Debug").GetComponent<Text> ();
			Mobile_Debug.text = "RopeList " + "Rope(Clone) " + "Hinge_top" + " " + this.transform.parent.GetSiblingIndex ();
			Touch_script.name = Mobile_Debug.text;	
		} 
		else 
		{
			Text Mobile_Debug;
			Text Active_Selection;
			Mobile_Debug = GameObject.Find ("Mobile_Debug").GetComponent<Text> ();
			Active_Selection = GameObject.Find ("Active_Selection").GetComponent<Text> ();
			Mobile_Debug.text = "No Selection";
			Touch_script.name = "No Selection";
			Active_Selection.text = "No Selection";
			Touch_script.flag = false;
			Image mybuttonimage = GameObject.Find ("Toggle Selection mode").GetComponent<Image> ();
			mybuttonimage.color = Color.white;
		}





		/*
		pathmanagerequipment = other.gameObject.transform.parent.GetComponent<PathManagerEquipment> ();
		if (other.gameObject.name.Contains("Positive"))
		{
			pathmanagerequipment.positive_terminal_connected = true;
			gameObject.GetComponent<Renderer>().material.color = Color.red;

			if (pathmanagerequipment.positive_terminal_wire_attached.Contains("rope")) 
			{
				pathmanagerequipment.positive_terminal_wire_attached2 = "rope"+this.gameObject.transform.parent.GetSiblingIndex ();
			}
			else 
			{
				pathmanagerequipment.positive_terminal_wire_attached = "rope"+this.gameObject.transform.parent.GetSiblingIndex ();
			}		
		}
		if (other.gameObject.name.Contains ("Negative")) 
		{
			pathmanagerequipment.negative_terminal_connected = true;
			gameObject.GetComponent<Renderer>().material.color = Color.black;
			if (pathmanagerequipment.negative_terminal_wire_attached.Contains("rope")) 
			{
				pathmanagerequipment.negative_terminal_wire_attached2 = "rope"+this.gameObject.transform.parent.GetSiblingIndex ();
			}
			else 
			{
				pathmanagerequipment.negative_terminal_wire_attached = "rope"+this.gameObject.transform.parent.GetSiblingIndex ();
			}
		
		}
		*/
		if (pathmanagerequipment.PathNumber == 666) 
		{
			pathmanagerequipment.PathNumber = pathmanager.PathNumber;
		} 
		else 
		{
			pathmanager.PathNumber = pathmanagerequipment.PathNumber;
		}


		pathmanager.IsPartOfPath = true;

		if (IsCircuitComplete_new(other) == true) 
		{
			circuitstarts_sound.Stop ();
			circuitstarts_sound.Play ();
			Debug.Log ("CIRCUIT COMPLETETETETETETETE");
			PathManager.circuitcomplete = true;

		}


	}

	void OnTriggerExit(Collider other)
	{
		
		if (IsRopeTouchingBadObjects(other) == true)
			return;

		pathmanagerequipment = other.gameObject.transform.parent.GetComponent<PathManagerEquipment> ();

		string myname = "rope" + this.gameObject.transform.parent.GetSiblingIndex ();
		pathmanagerequipment = other.gameObject.transform.parent.GetComponent<PathManagerEquipment> ();
		if (other.gameObject.name.Contains ("Positive")) 
		{
			if (pathmanagerequipment.positive_terminal_wire_attached.Contains (myname)) 
			{
				pathmanagerequipment.positive_terminal_wire_attached = Random.value.ToString ();
			} 
			else 
			{
				pathmanagerequipment.positive_terminal_wire_attached2 = Random.value.ToString ();
			}
		}
		if (other.gameObject.name.Contains ("Negative")) 
		{
			if (pathmanagerequipment.negative_terminal_wire_attached.Contains (myname)) 
			{
				pathmanagerequipment.negative_terminal_wire_attached = Random.value.ToString ();
			} 
			else 
			{
				pathmanagerequipment.negative_terminal_wire_attached2 = Random.value.ToString ();
			}
		}

		RopeAttached2 = null;
		pathmanager.RopeEnd2 = null;
		ps.Play ();
		gameObject.GetComponent<Renderer> ().material.color = Color.gray;


		if (RopeAttached2 == null && r1.RopeAttached1 == null) 
		{
			pathmanager.IsPartOfPath = false;
			pathmanager.PathNumber = pathmanager.OriginalPathNumber;
		}
		if (r1.RopeAttached1 != null) 
		{
			if (r1.RopeAttached1.Contains ("Battery") == false) 
			{
				//ropes that 'break' off without having a direct battery connection are given seperate paths
				//this ensures that only the first rope that touches the battery is used as reference
				pathmanager.PathNumber = pathmanager.OriginalPathNumber;
			}
		}

		//equipment terminals are nulled when wire disconnects
		pathmanagerequipment = other.gameObject.transform.parent.GetComponent<PathManagerEquipment> ();

		if (pathmanagerequipment.positive_terminal_connected==false && pathmanagerequipment.negative_terminal_connected==false)
		{
			pathmanagerequipment.PathNumber = 666;
		}
		BreakCircuitConnections_new (other);
	}

}
