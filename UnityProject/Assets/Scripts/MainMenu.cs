using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{

	//Menu container size and positional information
	private const float menuWidth = 120.0f;
	private const float menuHeight = 120.0f;

	private float menuPosX = Screen.width/2 - menuWidth/2;
	private float menuPosY = Screen.height/2 - menuHeight/2;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		//Container for menu buttons
		GUI.Box (new Rect(menuPosX, menuPosY, menuWidth , menuHeight), "Minion Mash");

		//menu Buttons
		if(GUI.Button (new Rect(menuPosX + 10, menuPosY + 25, 100, 20), "Survival"))
		{
			//Application.LoadLevel();
		}

		if(GUI.Button (new Rect(menuPosX + 10, menuPosY + 55, 100, 20), "Time Attack"))
		{
			//Application.LoadLevel();
		}

		if(GUI.Button (new Rect(menuPosX + 10, menuPosY + 85, 80, 20), "Exit"))
		{
			Application.Quit();
		}
	}
}
