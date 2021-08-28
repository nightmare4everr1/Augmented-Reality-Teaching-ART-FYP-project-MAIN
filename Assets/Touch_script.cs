using UnityEngine;
using System.Collections;
using UnityEngine.UI;




public class Touch_script : MonoBehaviour
{
	public int text_height=15;
	public static bool flag;
	public static float speed = 0.5f ;
	public static float rotspeed=0.1f;
	Text Active_Selection;
	Text Mobile_Debug;
	Text mytext;
	Text Help_Box;
	public static string name;
	Transform TAR;
	Transform tr1;
	Transform tr2;
	Rigidbody rb1;
	Rigidbody rb2;
	int ropeindex;
	Transform WorldText_Position;
	TextMesh WorldText;
	Text myDebug;
	Transform WorldTextLineOrigin;
	LineRenderer myline;
	Transform OtherObject;




	// Use this for initialization
	void Start () 
	{
		myline = GameObject.Find ("WORLDTEXT").GetComponent<LineRenderer> ();

		WorldTextLineOrigin = GameObject.Find ("WORLDTEXT_LINEORIGIN").GetComponent<Transform> ();
		myDebug = GameObject.Find ("myDebug").GetComponent<Text> ();
		WorldText_Position = GameObject.Find ("WORLDTEXT").GetComponent<Transform> ();
		WorldText = GameObject.Find ("WORLDTEXT").GetComponent<TextMesh> ();
		Active_Selection = GameObject.Find ("Active_Selection").GetComponent<Text> ();
		Mobile_Debug = GameObject.Find ("Mobile_Debug").GetComponent<Text> ();
		Help_Box = GameObject.Find ("Help_Box").GetComponent<Text> ();
		name = "No Selection" ;
		Active_Selection.text = "No Selection";
		flag = false;


	}

	void OnlyMakeHingeTopStatic()
	{
		tr1 = GameObject.Find ("RopeList").transform.GetChild (ropeindex).GetChild (0);//tr1 is set as top
		tr2 = GameObject.Find ("RopeList").transform.GetChild (ropeindex).GetChild (8);//tr2 is set as bottom

		rb1 = tr1.GetComponent<Rigidbody>();
		rb2 = tr2.GetComponent<Rigidbody> ();

		RopeInteraction r1 = tr1.GetComponent<RopeInteraction> ();
		RopeInteraction2 r2 = tr2.GetComponent<RopeInteraction2> ();

		if (r1.RopeAttached1 == null&&r2.RopeAttached2==null) 
		{
			rb2.isKinematic = false;
			rb2.useGravity = true;

		}


		rb1.isKinematic = true;
		rb1.useGravity = false;



	}

	void OnlyMakeHingeBottomStatic()
	{
		tr1 = GameObject.Find ("RopeList").transform.GetChild (ropeindex).GetChild (0);//tr1 is set as top
		tr2 = GameObject.Find ("RopeList").transform.GetChild (ropeindex).GetChild (8);//tr2 is set as bottom
	
		rb1 = tr1.GetComponent<Rigidbody>();
		rb2 = tr2.GetComponent<Rigidbody> ();

		RopeInteraction r1 = tr1.GetComponent<RopeInteraction> ();
		RopeInteraction2 r2 = tr2.GetComponent<RopeInteraction2> ();

		if (r2.RopeAttached2 == null && r1.RopeAttached1==null) 
		{
			rb1.isKinematic = false;
			rb1.useGravity = true;
			
		}


		rb2.isKinematic = true;
		rb2.useGravity = false;


	}

	void MoveSelectedObject(string direction)
	{
		if (name.StartsWith ("RopeList")) 
		{
			ropeindex = int.Parse(name.Substring (name.Length - 1, 1));

			if (name.Contains ("top")) 
			{
				TAR = GameObject.Find ("RopeList").transform.GetChild (ropeindex).GetChild (0);
				TAR.gameObject.GetComponent<Renderer>().material.color = Color.blue;
				OnlyMakeHingeTopStatic ();
			}
			if (name.Contains ("bottom")) 
			{
				TAR = GameObject.Find ("RopeList").transform.GetChild (ropeindex).GetChild (8);
				TAR.gameObject.GetComponent<Renderer>().material.color = Color.blue;
				OnlyMakeHingeBottomStatic ();
			}

		}
		else
		TAR = GameObject.Find (name).transform;
		

		if (direction=="right" && TAR.name!="Contacts")
			TAR.position = TAR.position + new Vector3 (speed, 0f, 0f);
		if (direction=="left" && TAR.name!="Contacts")
			TAR.position = TAR.position + new Vector3 (-speed, 0f, 0f);
		
		if (direction=="front" )
			TAR.position = TAR.position + new Vector3 (0f, 0f, -speed);
		if (direction=="back" )
			TAR.position = TAR.position + new Vector3 (0f, 0f, speed);
		if (direction=="down" && TAR.name!="Contacts" && TAR.name.Contains("Hinge"))
			TAR.position = TAR.position + new Vector3 (0f, -speed*0.25f, 0f);
		if (direction=="up" && TAR.name!="Contacts" && TAR.name.Contains("Hinge"))
			TAR.position = TAR.position + new Vector3 (0f, speed*0.25f, 0f);

		if (direction == "rotateright" && TAR.name != "Contacts" && TAR.name.Contains ("Hinge") == false) 
		{
			TAR.RotateAround (Vector3.up, rotspeed);
		}
		if (direction == "rotateleft" && TAR.name != "Contacts" && TAR.name.Contains ("Hinge") == false) 
		{
			TAR.RotateAround (Vector3.up, -rotspeed);
		}

	}

	bool RayHitInvalidObject(string name)
	{
		if (name.Contains ("Plane"))
		{
			return true;
		} 
		else 
		{
			return false;
		}
	}

	void UpdateHelpBox()
	{
		
		if (OtherObject != null) 
		{
			WorldTextLineOrigin.position = OtherObject.position;
			WorldText_Position.position = OtherObject.position + new Vector3 (0, text_height, 0);
		}
		if (flag == false) 
		{
			if(Active_Selection.text.Contains("Rope"))
			{
				
				Help_Box.text = "Do you want to pick Wire?"; 
				WorldText.text = Help_Box.text;
				myline.enabled = true;
			}
			else
			{
				if (Active_Selection.text.Contains ("No ")) 
				{
					Help_Box.text = "You have not selected anything";
					WorldText.text = "";
					myline.enabled = false;
				}
					
				else 
				{
					Help_Box.text = "Do you want to pick " + Active_Selection.text+"?";
					WorldText.text = Help_Box.text;
					myline.enabled = true;
				}

			}

		} 
		else 
		{
			if(Active_Selection.text.Contains("Rope"))
			{
				Help_Box.text = "You have currently picked Wire"; 

				WorldText.text = Help_Box.text;
				myline.enabled = true;
			}
			else
			{
				Help_Box.text = "You have currently Picked " + Mobile_Debug.text;
				WorldText.text = Help_Box.text;
				myline.enabled = true;
			}

		}
		
	}

	void UpdateWorldTextPosition(string name)
	{
		if (name.Contains ("No ")) 
		{
			return;
		}

		if (name.StartsWith ("RopeList")) 
		{
			ropeindex = int.Parse(name.Substring (name.Length - 1, 1));

			if (name.Contains ("top")) 
			{
				OtherObject = GameObject.Find ("RopeList").transform.GetChild (ropeindex).GetChild (0).GetComponent<Transform>();
				WorldText_Position.position = OtherObject.position+ new Vector3(0,text_height,0);
				WorldTextLineOrigin.position = OtherObject.position;
			}
			if (name.Contains ("bottom")) 
			{
				OtherObject = GameObject.Find ("RopeList").transform.GetChild (ropeindex).GetChild (8).GetComponent<Transform>();
				WorldText_Position.position = OtherObject.position+new Vector3(0,text_height,0);
				WorldTextLineOrigin.position = OtherObject.position;
			}

		}
		else
		{
			OtherObject = GameObject.Find (name).GetComponent<Transform> ();
			WorldText_Position.position = OtherObject.position+new Vector3(0,text_height,0);
			WorldTextLineOrigin.position = OtherObject.position;
		}
			

	}
	// Update is called once per frame
	void Update ()
	{
		UpdateHelpBox ();
		


		

			
			
		if (flag == true) //then objects can move from swipe gesture
		{
			if (Input.touchCount > 0 && (Input.GetTouch(0).position.y/Screen.height<0.65)) 
			{
				
				if (Input.GetTouch(0).deltaPosition.x > 0) 
				{
					//right swipe

					MoveSelectedObject("right");
				}
				if (Input.GetTouch (0).deltaPosition.x < 0) 
				{
					//left swipe
					MoveSelectedObject("left");
				}
				if (Input.GetTouch (0).deltaPosition.y < 0) 
				{
					//down swipe
					MoveSelectedObject("front");
				}
				if (Input.GetTouch (0).deltaPosition.y > 0) 
				{
					//up swipe
					MoveSelectedObject("back");
				}
				if (Input.GetTouch (1).deltaPosition.y < 0) 
				{
					//down swipe
					MoveSelectedObject("down");
				}
				if (Input.GetTouch (1).deltaPosition.y > 0) 
				{
					//up swipe
					MoveSelectedObject("up");
				}

				if (Input.GetTouch (1).deltaPosition.x > 0) 
				{
					MoveSelectedObject ("rotateright");
				}
				if (Input.GetTouch (1).deltaPosition.x < 0) 
				{
					MoveSelectedObject ("rotateleft");
				}

			}
		}

		/*
		Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit2;

		if (Physics.Raycast (ray2,out hit2, 1000)) 
		{


			//Destroy (hit.transform.gameObject);
			//print(hit.collider.name);
			if (hit2.collider.name == "Hinge_top" || hit2.collider.name == "Hinge_bottom") 
			{
				Active_Selection.text = "RopeList " + "Rope(Clone) "+ hit2.collider.name +" "+ hit2.collider.transform.parent.GetSiblingIndex ();
			}



		}
		*/


		if (Input.touchCount > 0) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;

			if (Physics.Raycast (ray,out hit, 1000)) 
			{


				if (hit.collider.name == "Hinge_top" || hit.collider.name == "Hinge_bottom") 
				{
					if (hit.collider.name == "Hinge_top" && hit.collider.GetComponent<Renderer>().material.color!=Color.red) 
					{
						hit.collider.GetComponent<Renderer>().material.color = Color.blue;
						if(hit.collider.transform.parent.GetChild(8).GetComponent<Renderer>().material.color!=Color.red)
							hit.collider.transform.parent.GetChild (8).GetComponent<Renderer> ().material.color = Color.gray;
					}
					if (hit.collider.name == "Hinge_bottom" && hit.collider.GetComponent<Renderer>().material.color!=Color.red) 
					{
						hit.collider.GetComponent<Renderer>().material.color = Color.blue;
						if(hit.collider.transform.parent.GetChild(0).GetComponent<Renderer>().material.color!=Color.red)
							hit.collider.transform.parent.GetChild (0).GetComponent<Renderer> ().material.color = Color.gray;
					}



					Active_Selection.text = "RopeList " + "Rope(Clone) " + hit.collider.name + " " + hit.collider.transform.parent.GetSiblingIndex ();
					UpdateWorldTextPosition (Active_Selection.text);
				}
				else 
				{
					if (RayHitInvalidObject (hit.collider.name) == false) 
					{
						UpdateWorldTextPosition (hit.collider.name);
						Active_Selection.text = hit.collider.name;
					}

				}

			}


		}


			
	}
}
