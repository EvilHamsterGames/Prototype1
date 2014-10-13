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
}
