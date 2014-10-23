using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    GameManager manager;

    static float timer = 0.0f;
    public float tickTime = 5.0f;
    public int randomSeed = 255;

    //Variable that stores random number dictating AI's choices
    private int decision;

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
        decision = Random.Range(-1, 4);

        if (timer < tickTime)
            return;

        switch (decision)
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

	}
}
