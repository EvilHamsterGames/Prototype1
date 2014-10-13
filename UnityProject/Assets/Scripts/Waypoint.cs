using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

    enum DIRECTION
    {
        DIRECTION_LEFT,
        DIRECTION_RIGHT,
        DIRECTION_COUNT
    };

    private Waypoint playerLeftWaypoint;
    private Waypoint playerRightWaypoint;
    private Waypoint enemyLeftWaypoint;
    private Waypoint enemyRightWaypoint;
    private DIRECTION playerTrackDirection;
    private DIRECTION enemyTrackDirection;

	// Use this for initialization
	void Start ()
    {
        playerLeftWaypoint = null;
        playerRightWaypoint = null;
        enemyLeftWaypoint = null;
        enemyRightWaypoint = null;
        playerTrackDirection = DIRECTION.DIRECTION_LEFT;
        enemyTrackDirection = DIRECTION.DIRECTION_RIGHT;
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    void SetPlayerLeftPoint(Waypoint a_playerLeftWaypoint)
    {
        playerLeftWaypoint = a_playerLeftWaypoint;
    }

    void SetPlayerRightPoint(Waypoint a_playerRightWaypoint)
    {
        playerRightWaypoint = a_playerRightWaypoint;
    }

    void SetEnemyLeftPoint(Waypoint a_enemyLeftWaypoint)
    {
        enemyLeftWaypoint = a_enemyLeftWaypoint;
    }

    void SetEnemyRightPoint(Waypoint a_enemyRightWaypoint)
    {
        enemyRightWaypoint = a_enemyRightWaypoint;
    }

    void TogglePlayerTrack()
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

    void ToggleEnemyTrack()
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

    Waypoint GetNextPlayerPoint()
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

    Waypoint GetNextEnemyPoint()
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

    Vector3 GetPosition()
    {
        return transform.position;
    }

    float GetX()
    {
        return transform.position.x;
    }

    float getY()
    {
        return transform.position.y;
    }

    float GetZ()
    {
        return transform.position.z;
    }
}
