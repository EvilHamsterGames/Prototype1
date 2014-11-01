using UnityEngine;
using System.Collections;

public class UserInterface : MonoBehaviour {

	GameManager manager;

    public bool displayGameOver;

	// Use this for initialization
	void Start () 
	{
		manager = this.GetComponent ("GameManager") as GameManager;
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

        //Light minion
		if (GUI.Button (new Rect (Screen.width / 2 - 100, 40, 100, 25), "Light Minion")) 
		{
			manager.SpawnMinion (GameManager.Participants.PLAYER, Minion.MINIONTYPE.MINIONTYPE_LIGHT);
		}

        //Medium minion
        if (GUI.Button(new Rect(Screen.width / 2 + 10, 40, 90, 25), "Medium Minion"))
        {
            manager.SpawnMinion(GameManager.Participants.PLAYER, Minion.MINIONTYPE.MINIONTYPE_MEDIUM);
        }

        //Heavy minion
        if (GUI.Button(new Rect(Screen.width / 2 + 110, 40, 90, 25), "Heavy Minion"))
        {
            manager.SpawnMinion(GameManager.Participants.PLAYER, Minion.MINIONTYPE.MINIONTYPE_HEAVY);
        }

        if(displayGameOver == true)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200, 100), "GAME OVER");
        }
	}
}
