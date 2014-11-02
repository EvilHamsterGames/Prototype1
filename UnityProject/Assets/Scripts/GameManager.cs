using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public enum Participants
	{
		PLAYER,
		ENEMY
	};

	//Gameplay variables
	//These can be set from the unity editor for easy access
    public int startingHP;
    public int startingGold;

    public int goldCap;
    public int goldTickAmount;
    public float goldTickTime;

    public int lightMinionCost;
    public int mediumMinionCost;
    public int heavyMinionCost;

	public Waypoint playerSpawn;
	public Waypoint enemySpawn;
	public GameObject minionPrefab;

    public Sprite spritePlayerLight;
    public Sprite spritePlayerMedium;
    public Sprite spritePlayerHeavy;
    public Sprite spriteEnemyLight;
    public Sprite spriteEnemyMedium;
    public Sprite spriteEnemyHeavy;

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

	public int GetGold()
	{
		return playerGold;
	}

	public int GetHP(Participants targetPlayer)
	{
		if(targetPlayer == Participants.PLAYER)
			return playerHP;
		else
			return enemyHP;
	}

	public void DamageParticipant(Participants targetPlayer, int amount)
	{
		if(targetPlayer == Participants.PLAYER)
		{
			if (playerHP - amount > 0) 
			{
				playerHP -= amount;
			} 
			else 
			{
                playerHP = 0;
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
                enemyHP = 0;
				GameOver(Participants.PLAYER);	
			}
		}
	}

	public void AddGold(Participants targetPlayer, int amount)
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
	
	public void SubtractGold(Participants targetPlayer, int amount)
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

    /*
	public void SpawnMinion(Participants player, Minion.MINIONTYPE type)
	{
        //Storing the spawned minions game object
        GameObject go;
        Minion spawnedMinion;
        SpriteRenderer spawnedSprite;

		if(player == Participants.PLAYER)
        {

            //Gold check
            if(type == Minion.MINIONTYPE.MINIONTYPE_LIGHT)
            {
                if (lightMinionCost > playerGold)
                    return;
            }
            else if(type == Minion.MINIONTYPE.MINIONTYPE_MEDIUM)
            {
                if (mediumMinionCost > playerGold)
                    return;
            }
            else if (type == Minion.MINIONTYPE.MINIONTYPE_HEAVY)
            {
                if (heavyMinionCost > playerGold)
                    return;
            }

            go = Instantiate(minionPrefab, playerSpawn.transform.position, Quaternion.identity) as GameObject;
            spawnedMinion = go.GetComponent<Minion>();
            spawnedSprite = go.GetComponent<SpriteRenderer>();

            if(type == Minion.MINIONTYPE.MINIONTYPE_LIGHT)
            {
                SubtractGold(Participants.PLAYER, lightMinionCost);
                spawnedMinion.SetHP(Minion.lightMinionHP);
                spawnedMinion.SetSpeed(Minion.lightMinionSpeed);
                spawnedMinion.SetTeam(Minion.TEAM.TEAM_PLAYER);
                spawnedMinion.SetMinionType(Minion.MINIONTYPE.MINIONTYPE_LIGHT);
                spawnedMinion.SetDestination(playerSpawn);
                spawnedSprite.sprite = spritePlayerLight;
            }
            else if(type == Minion.MINIONTYPE.MINIONTYPE_MEDIUM)
            {
                SubtractGold(Participants.PLAYER, mediumMinionCost);
                spawnedMinion.SetHP(Minion.mediumMinionHP);
                spawnedMinion.SetSpeed(Minion.mediumMinionSpeed);
                spawnedMinion.SetTeam(Minion.TEAM.TEAM_PLAYER);
                spawnedMinion.SetMinionType(Minion.MINIONTYPE.MINIONTYPE_MEDIUM);
                spawnedMinion.SetDestination(playerSpawn);
                spawnedSprite.sprite = spritePlayerMedium;
            }
            else if(type == Minion.MINIONTYPE.MINIONTYPE_HEAVY)
            {
                SubtractGold(Participants.PLAYER, heavyMinionCost);
                spawnedMinion.SetHP(Minion.heavyMinionHP);
                spawnedMinion.SetSpeed(Minion.heavyMinionSpeed);
                spawnedMinion.SetTeam(Minion.TEAM.TEAM_PLAYER);
                spawnedMinion.SetMinionType(Minion.MINIONTYPE.MINIONTYPE_HEAVY);
                spawnedMinion.SetDestination(playerSpawn);
                spawnedSprite.sprite = spritePlayerHeavy;
            }
        }
        else if (player == Participants.ENEMY)
        {
            //Gold check
            if (type == Minion.MINIONTYPE.MINIONTYPE_LIGHT)
            {
                if (lightMinionCost > enemyGold)
                    return;
            }
            else if (type == Minion.MINIONTYPE.MINIONTYPE_MEDIUM)
            {
                if (mediumMinionCost > enemyGold)
                    return;
            }
            else if (type == Minion.MINIONTYPE.MINIONTYPE_HEAVY)
            {
                if (heavyMinionCost > enemyGold)
                    return;
            }

            go = Instantiate(minionPrefab, enemySpawn.transform.position, Quaternion.identity) as GameObject;
            spawnedMinion = go.GetComponent<Minion>();
            spawnedSprite = go.GetComponent<SpriteRenderer>();

            if (type == Minion.MINIONTYPE.MINIONTYPE_LIGHT)
            {
                SubtractGold(Participants.ENEMY, lightMinionCost);
                spawnedMinion.SetHP(Minion.lightMinionHP);
                spawnedMinion.SetSpeed(Minion.lightMinionSpeed);
                spawnedMinion.SetTeam(Minion.TEAM.TEAM_ENEMY);
                spawnedMinion.SetMinionType(Minion.MINIONTYPE.MINIONTYPE_LIGHT);
                spawnedMinion.SetDestination(enemySpawn);
                spawnedSprite.sprite = spriteEnemyLight;
            }
            else if (type == Minion.MINIONTYPE.MINIONTYPE_MEDIUM)
            {
                SubtractGold(Participants.ENEMY, mediumMinionCost);
                spawnedMinion.SetHP(Minion.mediumMinionHP);
                spawnedMinion.SetSpeed(Minion.mediumMinionSpeed);
                spawnedMinion.SetTeam(Minion.TEAM.TEAM_ENEMY);
                spawnedMinion.SetMinionType(Minion.MINIONTYPE.MINIONTYPE_MEDIUM);
                spawnedMinion.SetDestination(enemySpawn);
                spawnedSprite.sprite = spriteEnemyMedium;
            }
            else if (type == Minion.MINIONTYPE.MINIONTYPE_HEAVY)
            {
                SubtractGold(Participants.ENEMY, heavyMinionCost);
                spawnedMinion.SetHP(Minion.heavyMinionHP);
                spawnedMinion.SetSpeed(Minion.heavyMinionSpeed);
                spawnedMinion.SetTeam(Minion.TEAM.TEAM_ENEMY);
                spawnedMinion.SetMinionType(Minion.MINIONTYPE.MINIONTYPE_HEAVY);
                spawnedMinion.SetDestination(enemySpawn);
                spawnedSprite.sprite = spriteEnemyHeavy;
            }
        }
	}
     */

    public bool SpawnMinion(Participants player, Minion.MINIONTYPE type)
    {
        //Storing the spawned minions game object
        GameObject go;
        Minion spawnedMinion;
        SpriteRenderer spawnedSprite;

        if (player == Participants.PLAYER)
        {

            //Gold check
            if (type == Minion.MINIONTYPE.MINIONTYPE_LIGHT)
            {
                if (lightMinionCost > playerGold)
                    return false;
            }
            else if (type == Minion.MINIONTYPE.MINIONTYPE_MEDIUM)
            {
                if (mediumMinionCost > playerGold)
                    return false;
            }
            else if (type == Minion.MINIONTYPE.MINIONTYPE_HEAVY)
            {
                if (heavyMinionCost > playerGold)
                    return false;
            }

            go = Instantiate(minionPrefab, playerSpawn.transform.position, Quaternion.identity) as GameObject;
            spawnedMinion = go.GetComponent<Minion>();
            spawnedSprite = go.GetComponent<SpriteRenderer>();

            if (type == Minion.MINIONTYPE.MINIONTYPE_LIGHT)
            {
                SubtractGold(Participants.PLAYER, lightMinionCost);
                spawnedMinion.SetHP(Minion.lightMinionHP);
                spawnedMinion.SetSpeed(Minion.lightMinionSpeed);
                spawnedMinion.SetTeam(Minion.TEAM.TEAM_PLAYER);
                spawnedMinion.SetMinionType(Minion.MINIONTYPE.MINIONTYPE_LIGHT);
                spawnedMinion.SetDestination(playerSpawn);
                spawnedSprite.sprite = spritePlayerLight;
            }
            else if (type == Minion.MINIONTYPE.MINIONTYPE_MEDIUM)
            {
                SubtractGold(Participants.PLAYER, mediumMinionCost);
                spawnedMinion.SetHP(Minion.mediumMinionHP);
                spawnedMinion.SetSpeed(Minion.mediumMinionSpeed);
                spawnedMinion.SetTeam(Minion.TEAM.TEAM_PLAYER);
                spawnedMinion.SetMinionType(Minion.MINIONTYPE.MINIONTYPE_MEDIUM);
                spawnedMinion.SetDestination(playerSpawn);
                spawnedSprite.sprite = spritePlayerMedium;
            }
            else if (type == Minion.MINIONTYPE.MINIONTYPE_HEAVY)
            {
                SubtractGold(Participants.PLAYER, heavyMinionCost);
                spawnedMinion.SetHP(Minion.heavyMinionHP);
                spawnedMinion.SetSpeed(Minion.heavyMinionSpeed);
                spawnedMinion.SetTeam(Minion.TEAM.TEAM_PLAYER);
                spawnedMinion.SetMinionType(Minion.MINIONTYPE.MINIONTYPE_HEAVY);
                spawnedMinion.SetDestination(playerSpawn);
                spawnedSprite.sprite = spritePlayerHeavy;
            }
        }
        else if (player == Participants.ENEMY)
        {
            //Gold check
            if (type == Minion.MINIONTYPE.MINIONTYPE_LIGHT)
            {
                if (lightMinionCost > enemyGold)
                    return false;
            }
            else if (type == Minion.MINIONTYPE.MINIONTYPE_MEDIUM)
            {
                if (mediumMinionCost > enemyGold)
                    return false;
            }
            else if (type == Minion.MINIONTYPE.MINIONTYPE_HEAVY)
            {
                if (heavyMinionCost > enemyGold)
                    return false;
            }

            go = Instantiate(minionPrefab, enemySpawn.transform.position, Quaternion.identity) as GameObject;
            spawnedMinion = go.GetComponent<Minion>();
            spawnedSprite = go.GetComponent<SpriteRenderer>();

            if (type == Minion.MINIONTYPE.MINIONTYPE_LIGHT)
            {
                SubtractGold(Participants.ENEMY, lightMinionCost);
                spawnedMinion.SetHP(Minion.lightMinionHP);
                spawnedMinion.SetSpeed(Minion.lightMinionSpeed);
                spawnedMinion.SetTeam(Minion.TEAM.TEAM_ENEMY);
                spawnedMinion.SetMinionType(Minion.MINIONTYPE.MINIONTYPE_LIGHT);
                spawnedMinion.SetDestination(enemySpawn);
                spawnedSprite.sprite = spriteEnemyLight;
            }
            else if (type == Minion.MINIONTYPE.MINIONTYPE_MEDIUM)
            {
                SubtractGold(Participants.ENEMY, mediumMinionCost);
                spawnedMinion.SetHP(Minion.mediumMinionHP);
                spawnedMinion.SetSpeed(Minion.mediumMinionSpeed);
                spawnedMinion.SetTeam(Minion.TEAM.TEAM_ENEMY);
                spawnedMinion.SetMinionType(Minion.MINIONTYPE.MINIONTYPE_MEDIUM);
                spawnedMinion.SetDestination(enemySpawn);
                spawnedSprite.sprite = spriteEnemyMedium;
            }
            else if (type == Minion.MINIONTYPE.MINIONTYPE_HEAVY)
            {
                SubtractGold(Participants.ENEMY, heavyMinionCost);
                spawnedMinion.SetHP(Minion.heavyMinionHP);
                spawnedMinion.SetSpeed(Minion.heavyMinionSpeed);
                spawnedMinion.SetTeam(Minion.TEAM.TEAM_ENEMY);
                spawnedMinion.SetMinionType(Minion.MINIONTYPE.MINIONTYPE_HEAVY);
                spawnedMinion.SetDestination(enemySpawn);
                spawnedSprite.sprite = spriteEnemyHeavy;
            }
        }
        return true;
    }

	void GameOver(Participants winner)
	{
        UserInterface gui = GetComponent<UserInterface>();
        gui.displayGameOver = true;
	}
}
