using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Buttoncommands : MonoBehaviour {

	Text Mobile_Debug;
	Text Active_Selection;

	public GameObject obj;
	public GameObject Rope_Prefab;
	public GameObject Rope_List;
	public static int counter=0;



	// Use this for initialization

	void Start () 
	{


		Mobile_Debug = GameObject.Find ("Mobile_Debug").GetComponent<Text> ();
		Active_Selection = GameObject.Find ("Active_Selection").GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TOGGLE_SELECTION_MODE()
	{
		if (Active_Selection.text.Contains ("No "))
			return;
		if (Touch_script.flag == false)
		{
			
			Image mybuttonimage = GameObject.Find ("Toggle Selection mode").GetComponent<Image> ();
			mybuttonimage.color = Color.green;
			Touch_script.flag = true;
			Touch_script.name = Active_Selection.text;
			Mobile_Debug.text = Touch_script.name;
		} 
		else 
		{
			Image mybuttonimage = GameObject.Find ("Toggle Selection mode").GetComponent<Image> ();
			mybuttonimage.color = Color.white;
			Touch_script.flag = false;
			
		}
			
		
	}

	public void MAKE_TARGET_ACTIVE_SELECTION()
	{
		
	}

	public void CREATE_ROPE()	
	{
		obj = Instantiate (Rope_Prefab,new Vector3(counter,40,0), Quaternion.identity) as GameObject;
		int i = 0;
		for(i=0;i<9;i=i+1)
		{
			obj.transform.GetChild (i).position = new Vector3 (counter, 5, -i*3);
		}

		obj.transform.GetChild(0).GetComponent<Renderer> ().material.color = Color.gray;
		obj.transform.GetChild(8).GetComponent<Renderer> ().material.color = Color.gray;


		obj.transform.parent = Rope_List.transform;

		counter=counter+3;
	}
	public void CHANGESWIPE_SPEED(float newspeed)
	{
		
		Touch_script.speed = newspeed;
		Touch_script.rotspeed = newspeed / 5;
		Debug.Log (Touch_script.speed);
	}
}
