using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

    public enum DIRECTION
    {
        DIRECTION_LEFT,
        DIRECTION_RIGHT,
        DIRECTION_COUNT
    };

    public enum CURVE_DIRECTION
    {
        CURVE_DIRECTION_CLOCKWISE,
        CURVE_DIRECTION_ANTICLOCKWISE,
        CURVE_DIRECTION_COUNT
    };

    public enum CURVE_TYPE
    {
        CURVE_TYPE_LINEAR,
        CURVE_TYPE_UPPER,
        CURVE_TYPE_LOWER,
        CURVE_TYPE_COUNT
    };

    public Waypoint playerLeftWaypoint;
    public CURVE_TYPE playerLeftCurveType;
    public CURVE_DIRECTION playerLeftCurveDirection;
    public float playerLeftRadius;

    public Waypoint playerRightWaypoint;
    public CURVE_TYPE playerRightCurveType;
    public CURVE_DIRECTION playerRightCurveDirection;
    public float playerRightRadius;

    public Waypoint enemyLeftWaypoint;
    public CURVE_TYPE enemyLeftCurveType;
    public CURVE_DIRECTION enemyLeftCurveDirection;
    public float enemyLeftRadius;

    public Waypoint enemyRightWaypoint;
    public CURVE_TYPE enemyRightCurveType;
    public CURVE_DIRECTION enemyRightCurveDirection;
    public float enemyRightRadius;

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

    public CURVE_TYPE GetNextPlayerCurveType()
    {
        if (playerTrackDirection == DIRECTION.DIRECTION_LEFT)
        {
            return playerLeftCurveType;
        }
        else
        {
            return playerRightCurveType;
        }
    }

    public CURVE_TYPE GetNextEnemyCurveType()
    {
        if (enemyTrackDirection == DIRECTION.DIRECTION_LEFT)
        {
            return enemyLeftCurveType;
        }
        else
        {
            return enemyRightCurveType;
        }
    }

    public CURVE_DIRECTION GetNextPlayerCurveDirection()
    {
        if (playerTrackDirection == DIRECTION.DIRECTION_LEFT)
        {
            return playerLeftCurveDirection;
        }
        else
        {
            return playerRightCurveDirection;
        }
    }

    public CURVE_DIRECTION GetNextEnemyCurveDirection()
    {
        if (enemyTrackDirection == DIRECTION.DIRECTION_LEFT)
        {
            return enemyLeftCurveDirection;
        }
        else
        {
            return enemyRightCurveDirection;
        }
    }

    float GetNextPlayerRadius()
    {
        if (playerTrackDirection == DIRECTION.DIRECTION_LEFT)
        {
            return playerLeftRadius;
        }
        else
        {
            return playerRightRadius;
        }
    }

    float GetNextEnemyRadius()
    {
        if (enemyTrackDirection == DIRECTION.DIRECTION_LEFT)
        {
            return enemyLeftRadius;
        }
        else
        {
            return enemyRightRadius;
        }
    }

    public Vector3 GetNextPlayerCircleCentre()
    {

        //Get radius of circle
        float r = GetNextPlayerRadius();

        //Find distance between this waypoint and destination
        float q = Mathf.Sqrt(Mathf.Pow(GetNextPlayerPoint().GetX() - GetX(), 2) + Mathf.Pow(GetNextPlayerPoint().GetY() - GetY(), 2));

        //Find x and y components of midway point between this waypoint and destination
        float x3 = (GetNextPlayerPoint().GetX() + GetX()) / 2;
        float y3 = (GetNextPlayerPoint().GetY() + GetY()) / 2;

        float circleX;
        float circleY;

        if (GetNextPlayerCurveType() == CURVE_TYPE.CURVE_TYPE_UPPER)
        {
            //Get x coordinate of circle centre
            circleX = x3 + (Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow((q / 2), 2)) * (GetY() - GetNextPlayerPoint().GetY()) / q);
            //Get y coordinate of circle centre
            circleY = y3 + (Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow((q / 2), 2)) * (GetNextPlayerPoint().GetX() - GetX()) / q);
        }
        else
        {
            //Get x coordinate of circle centre
            circleX = x3 - (Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow((q / 2), 2)) * (GetY() - GetNextPlayerPoint().GetY()) / q);
            //Get y coordinate of circle centre
            circleY = y3 - (Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow((q / 2), 2)) * (GetNextPlayerPoint().GetX() - GetX()) / q);
        }

        Vector3 circleCentre;
        circleCentre.x = circleX;
        circleCentre.y = circleY;
        circleCentre.z = 0;

        return circleCentre;
    }

    public Vector3 GetNextEnemyCircleCentre()
    {

        //Get radius of circle
        float r = GetNextEnemyRadius();

        //Find distance between this waypoint and destination
        float q = Mathf.Sqrt(Mathf.Pow(GetNextEnemyPoint().GetX() - GetX(), 2) + Mathf.Pow(GetNextEnemyPoint().GetY() - GetY(), 2));

        //Find x and y components of midway point between this waypoint and destination
        float x3 = (GetNextEnemyPoint().GetX() + GetX()) / 2;
        float y3 = (GetNextEnemyPoint().GetY() + GetY()) / 2;

        float circleX;
        float circleY;

        if (GetNextEnemyCurveType() == CURVE_TYPE.CURVE_TYPE_UPPER)
        {
            //Get x coordinate of circle centre
            circleX = x3 + (Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow((q / 2), 2)) * (GetY() - GetNextEnemyPoint().GetY()) / q);
            //Get y coordinate of circle centre
            circleY = y3 + (Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow((q / 2), 2)) * (GetNextEnemyPoint().GetX() - GetX()) / q);
        }
        else
        {
            //Get x coordinate of circle centre
            circleX = x3 - (Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow((q / 2), 2)) * (GetY() - GetNextEnemyPoint().GetY()) / q);
            //Get y coordinate of circle centre
            circleY = y3 - (Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow((q / 2), 2)) * (GetNextEnemyPoint().GetX() - GetX()) / q);
        }

        Vector3 circleCentre;
        circleCentre.x = circleX;
        circleCentre.y = circleY;
        circleCentre.z = 0;

        return circleCentre;
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
