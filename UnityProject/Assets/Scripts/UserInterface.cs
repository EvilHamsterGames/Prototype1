using UnityEngine;
using System.Collections;

public class UserInterface : MonoBehaviour {

	GameManager manager;

	// Use this for initialization
	void Start () 
	{
		manager = this.GetComponent ("GameManager") as GameManager;
		manager.SpawnMinion (GameManager.Participants.PLAYER);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnGUI()
	{
		//Testing interface - will be redone for final game
		GUI.Label (new Rect(Screen.width / 2 - 32.5f, 10, 65, 25), "Gold: " + manager.GetGold());
		GUI.Label (new Rect(Screen.width - 110, 10, 105, 25), "Player HP: " + manager.GetHP (GameManager.Participants.PLAYER));
		GUI.Label (new Rect(Screen.width - 110, 40, 105, 25), "Enemy HP: " + manager.GetHP (GameManager.Participants.ENEMY));
		if (GUI.Button (new Rect (Screen.width / 2 - 60, 40, 120, 25), "Spawn a minion!")) 
		{
			manager.SpawnMinion (GameManager.Participants.PLAYER);
		}
	}
}
