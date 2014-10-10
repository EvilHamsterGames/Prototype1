using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	enum Participants
	{
		PLAYER,
		ENEMY
	};

	//Gameplay variables
	//These can be set from the unity editor for easy access
	public int startingHP = 100;
	public int startingGold = 100;
	public int goldCap = 1000;
	public int goldTickAmount = 5;
	public float goldTickTime = 3f;

	//These can't be set in editor and update throughout the game
	private int playerGold;
	private int enemyGold;
	private int playerHP;
	private int enemyHP;
	private float timer;

	// Use this for initialization
	void Start () 
	{
		playerGold = startingGold;
		enemyGold = startingGold;

		playerHP = startingHP;
		enemyHP = startingHP;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		//3 Second timer for adding gold
		if(timer >= goldTickTime)
		{
			playerGold += goldTickAmount;
			enemyGold += goldTickAmount;

			timer = 0;
			//Debug.Log("Added " + goldTickAmount + " gold to players");
		}
	}

	void DamageParticipant(Participants targetPlayer, int amount)
	{
		if(targetPlayer == Participants.PLAYER)
		{
			if (playerHP - amount > 0) 
			{
				playerHP -= amount;
			} 
			else 
			{
				GameOver(Participants.ENEMY);	
			}
		}
		else if(targetPlayer == Participants.ENEMY)
		{
			if (enemyHP - amount > 0) 
			{
				enemyHP -= amount;
			} 
			else 
			{
				GameOver(Participants.PLAYER);	
			}
		}
	}

	void AddGold(Participants targetPlayer, int amount)
	{
		if (targetPlayer == Participants.PLAYER) 
		{
			if (playerGold + amount > goldCap)
				playerGold = goldCap;
			else
				playerGold += amount;
				
		} 
		else if (targetPlayer == Participants.ENEMY) 
		{
			if (enemyGold + amount > goldCap)
				enemyGold = goldCap;
			else
				enemyGold += amount;
		} 
	}
	
	void SubtractGold(Participants targetPlayer, int amount)
	{
		if (targetPlayer == Participants.PLAYER) 
		{
			if (playerGold - amount < 0)
				playerGold = 0;
			else
				playerGold -= amount;
			
		} 
		else if (targetPlayer == Participants.ENEMY) 
		{
			if (enemyGold - amount < 0)
				enemyGold = 0;
			else
				enemyGold -= amount;
		} 
	}

	void GameOver(Participants winner)
	{
		//TODO code for the end of the game 
		//(Notifications for interface and ending score and perhaps transition back to main menu)
		// Could pass in tag for winner or just check the hp inside this method to see who won
		// UserInterface.DisplayGameOver(); Something like that...lel
	}
}
