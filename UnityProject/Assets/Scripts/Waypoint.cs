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
    public Minion.MOVEMENT_TYPE playerLeftWaypointMovementType;
    public Vector3 playerLeftCirleCentre;

    public Waypoint playerRightWaypoint;
    public Minion.MOVEMENT_TYPE playerRightWaypointMovementType;
    public Vector3 playerRightCirleCentre;

    public Waypoint enemyLeftWaypoint;
    public Minion.MOVEMENT_TYPE enemyLeftWaypointMovementType;
    public Vector3 enemyLeftCirleCentre;

    public Waypoint enemyRightWaypoint;
    public Minion.MOVEMENT_TYPE enemyRightWaypointMovementType;
    public Vector3 enemyRightCirleCentre;

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

    public Minion.MOVEMENT_TYPE GetNextPlayerMovementType()
    {
        if (playerTrackDirection == DIRECTION.DIRECTION_LEFT)
        {
            return playerLeftWaypointMovementType;
        }
        else
        {
            return playerRightWaypointMovementType;
        }
    }

    public Minion.MOVEMENT_TYPE GetNextEnemyMovementType()
    {
        if (enemyTrackDirection == DIRECTION.DIRECTION_LEFT)
        {
            return enemyLeftWaypointMovementType;
        }
        else
        {
            return enemyRightWaypointMovementType;
        }
    }

    public Vector3 GetNextPlayerCircleCentre()
    {
        if (playerTrackDirection == DIRECTION.DIRECTION_LEFT)
        {
            return playerLeftCirleCentre;
        }
        else
        {
            return playerRightCirleCentre;
        }
    }

    public Vector3 GetNextEnemyCircleCentre()
    {
        if (enemyTrackDirection == DIRECTION.DIRECTION_LEFT)
        {
            return enemyLeftCirleCentre;
        }
        else
        {
            return enemyRightCirleCentre;
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
