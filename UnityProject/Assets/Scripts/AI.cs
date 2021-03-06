﻿using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    GameManager manager;

    static float timer = 0.0f;

    public float trackChangeTimeMin = 0;
    public float trackChangeTimeMax = 0;

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
