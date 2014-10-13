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
    void Start()
    {
        playerLeftWaypoint = null;
        playerRightWaypoint = null;
        enemyLeftWaypoint = null;
        enemyRightWaypoint = null;
        playerTrackDirection = DIRECTION.DIRECTION_LEFT;
        enemyTrackDirection = DIRECTION.DIRECTION_RIGHT;
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

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public float GetX()
    {
        return transform.position.x;
    }

    public float GetY()
    {
        return transform.position.y;
    }

    public float GetZ()
    {
        return transform.position.z;
    }
}
