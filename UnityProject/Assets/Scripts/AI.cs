using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    GameManager manager;

    static float timer = 0.0f;
    public float tickTime = 5.0f;
    public int randomSeed = 255;

    public Waypoint switchOne;
    public Waypoint switchTwo;
    public Waypoint switchThree;

    //Variable that stores random number dictating AI's choices
    private int spawnChoice;
    private int trackChoice;

	// Use this for initialization
	void Start () 
    {
        manager = this.GetComponent("GameManager") as GameManager;
        Random.seed = randomSeed;
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;
        spawnChoice = Random.Range(0, 3);
        trackChoice = Random.Range(0, 2);

        if (timer < tickTime)
            return;

        switch (spawnChoice)
        {
            case 0:
                manager.SpawnMinion(GameManager.Participants.ENEMY, Minion.MINIONTYPE.MINIONTYPE_LIGHT);
                timer = 0.0f;
                break;
            case 1:
                manager.SpawnMinion(GameManager.Participants.ENEMY, Minion.MINIONTYPE.MINIONTYPE_MEDIUM);
                timer = 0.0f;
                break;
            case 2:
                manager.SpawnMinion(GameManager.Participants.ENEMY, Minion.MINIONTYPE.MINIONTYPE_HEAVY);
                timer = 0.0f;
                break;
            case 3:
                Debug.Log("AI did nothing this tick");
                timer = 0.0f;
                break;
        }

        switch (trackChoice)
        {
            case 0:
                switchOne.ToggleEnemyTrack();
                break;
            case 1:
                switchTwo.ToggleEnemyTrack();
                break;
            case 2:
                switchThree.ToggleEnemyTrack();
                break;
        }

	}
}
