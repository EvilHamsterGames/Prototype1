using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserInterface : MonoBehaviour {

	GameManager manager;

    public bool displayGameOver;
    public GUISkin skin;

	// Use this for initialization
	void Start () 
	{
		manager = this.GetComponent ("GameManager") as GameManager;
	}

	void OnGUI()
	{
        GUI.skin = skin;
        skin.label.alignment = TextAnchor.MiddleCenter;

		//Testing interface - will be redone for final game
		GUI.Label (new Rect(Screen.width / 2 - 50, 10, 100, 25), "Gold: " + manager.GetGold());
		GUI.Label (new Rect(Screen.width - 210, 10, 200, 25), "Player HP: " + manager.GetHP (GameManager.Participants.PLAYER));
		GUI.Label (new Rect(Screen.width - 210, 40, 200, 25), "Enemy HP: " + manager.GetHP (GameManager.Participants.ENEMY));

        //Light minion button
		if (GUI.Button (new Rect (Screen.width / 2 - 180, 45, 120, 25), "Light Minion")) 
			manager.SpawnMinion (GameManager.Participants.PLAYER, Minion.MINIONTYPE.MINIONTYPE_LIGHT);

        //Medium minion button
        if (GUI.Button(new Rect(Screen.width / 2 - 60, 45, 120, 25), "Medium Minion"))
            manager.SpawnMinion(GameManager.Participants.PLAYER, Minion.MINIONTYPE.MINIONTYPE_MEDIUM);

        //Heavy minion button
        if (GUI.Button(new Rect(Screen.width / 2 + 60, 45, 120, 25), "Heavy Minion"))
            manager.SpawnMinion(GameManager.Participants.PLAYER, Minion.MINIONTYPE.MINIONTYPE_HEAVY);

        //Gameover Text
        if(displayGameOver == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "GAME OVER");
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 35, 300, 25), "Return to menu"))
                Application.LoadLevel("MainMenu");
        }
	}
}
