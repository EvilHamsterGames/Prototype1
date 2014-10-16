using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

    public enum DIRECTION
    {
        DIRECTION_LEFT,
        DIRECTION_RIGHT,
        DIRECTION_COUNT
    };

    public Waypoint playerLeftWaypoint;
    public Waypoint playerRightWaypoint;
    public Waypoint enemyLeftWaypoint;
    public Waypoint enemyRightWaypoint;
    public DIRECTION playerTrackDirection;
    public DIRECTION enemyTrackDirection;

	// Use this for initialization
    void Start()
    {

	}
	
	// Update is called once per frame
    void Update()
    {

	}

    public void SetPlayerLeftPoint(Waypoint a_playerLeftWaypoint)
    {
        playerLeftWaypoint = a_playerLeftWaypoint;
    }

    public void SetPlayerRightPoint(Waypoint a_playerRightWaypoint)
    {
        playerRightWaypoint = a_playerRightWaypoint;
    }

    public void SetEnemyLeftPoint(Waypoint a_enemyLeftWaypoint)
    {
        enemyLeftWaypoint = a_enemyLeftWaypoint;
    }

    public void SetEnemyRightPoint(Waypoint a_enemyRightWaypoint)
    {
        enemyRightWaypoint = a_enemyRightWaypoint;
    }

    public void TogglePlayerTrack()
    {
        if (playerTrackDirection == DIRECTION.DIRECTION_LEFT)
        {
            playerTrackDirection = DIRECTION.DIRECTION_RIGHT;
        }
        else
        {
            playerTrackDirection = DIRECTION.DIRECTION_LEFT;
        }
    }

    public void ToggleEnemyTrack()
    {
        if (enemyTrackDirection == DIRECTION.DIRECTION_LEFT)
        {
            enemyTrackDirection = DIRECTION.DIRECTION_RIGHT;
        }
        else
        {
            enemyTrackDirection = DIRECTION.DIRECTION_LEFT;
        }
    }

    public Waypoint GetNextPlayerPoint()
    {
        if (playerTrackDirection == DIRECTION.DIRECTION_LEFT)
        {
            return playerLeftWaypoint;
        }
        else
        {
            return playerRightWaypoint;
        }
    }

    public Waypoint GetNextEnemyPoint()
    {
        if (enemyTrackDirection == DIRECTION.DIRECTION_LEFT)
        {
            return enemyLeftWaypoint;
        }
        else
        {
            return enemyRightWaypoint;
        }
    }
}
