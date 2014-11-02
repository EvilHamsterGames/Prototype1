using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

/*    GameManager manager;

    static float timer = 0.0f;
    public float tickTime = 5.0f;
    public int randomSeed = 255;

    public TrackButton buttonOne;
    public TrackButton buttonTwo;
    public TrackButton buttonThree;
    public TrackButton buttonFour;

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
        trackChoice = Random.Range(0, 3);

        if (timer < tickTime)
            return;

        switch (spawnChoice)
        {
            case 0:
                Debug.Log("Light");
                manager.SpawnMinion(GameManager.Participants.ENEMY, Minion.MINIONTYPE.MINIONTYPE_LIGHT);
                timer = 0.0f;
                break;
            case 1:
                Debug.Log("Medium");
                manager.SpawnMinion(GameManager.Participants.ENEMY, Minion.MINIONTYPE.MINIONTYPE_MEDIUM);
                timer = 0.0f;
                break;
            case 2:
                Debug.Log("Heavy");
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
                buttonOne.ActivateTrackButton();
                break;
            case 1:
                buttonTwo.ActivateTrackButton();
                break;
            case 2:
                buttonThree.ActivateTrackButton();
                break;
            case 3:
                buttonFour.ActivateTrackButton();
                break;
        }

	}*/

    GameManager manager;

    static float timer = 0.0f;

    const float trackChangeTimeMin = 3.0f;
    const float trackChangeTimeMax = 8.0f;

    public TrackButton buttonOne;
    public TrackButton buttonTwo;
    public TrackButton buttonThree;
    public TrackButton buttonFour;

    float minionSpawnType;
    float trackChangeTime;

    // Use this for initialization
    void Start()
    {
        manager = this.GetComponent("GameManager") as GameManager;
        minionSpawnType = Random.Range(0, 3);
        trackChangeTime = Random.Range(trackChangeTimeMin, trackChangeTimeMax);

        if ((int)Random.Range(0, 2) == 1)
        {
            buttonOne.ActivateTrackButton();
        }
        if ((int)Random.Range(0, 2) == 1)
        {
            buttonTwo.ActivateTrackButton();
        }
        if ((int)Random.Range(0, 2) == 1)
        {
            buttonThree.ActivateTrackButton();
        }
        if ((int)Random.Range(0, 2) == 1)
        {
            buttonFour.ActivateTrackButton();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        bool minionSpawned = false;
        switch ((int)minionSpawnType)
        {
            case 0:
                if (manager.SpawnMinion(GameManager.Participants.ENEMY, Minion.MINIONTYPE.MINIONTYPE_LIGHT))
                {
                    minionSpawned = true;
                }
                break;
            case 1:
                if (manager.SpawnMinion(GameManager.Participants.ENEMY, Minion.MINIONTYPE.MINIONTYPE_MEDIUM))
                {
                    minionSpawned = true;
                }
                break;
            default:
                if (manager.SpawnMinion(GameManager.Participants.ENEMY, Minion.MINIONTYPE.MINIONTYPE_HEAVY))
                {
                    minionSpawned = true;
                }
                break;
        }

        if (minionSpawned == true)
        {
            minionSpawnType = Random.Range(0, 3);
        }

        if (timer >= trackChangeTime)
        {
            if ((int)Random.Range(0, 2) == 1)
            {
                buttonOne.ActivateTrackButton();
            }
            if ((int)Random.Range(0, 2) == 1)
            {
                buttonTwo.ActivateTrackButton();
            }
            if ((int)Random.Range(0, 2) == 1)
            {
                buttonThree.ActivateTrackButton();
            }
            if ((int)Random.Range(0, 2) == 1)
            {
                buttonFour.ActivateTrackButton();
            }
            timer = 0;
            trackChangeTime = Random.Range(trackChangeTimeMin, trackChangeTimeMax);
        }
    }
}
