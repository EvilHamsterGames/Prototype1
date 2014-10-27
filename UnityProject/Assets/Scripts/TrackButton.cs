using UnityEngine;
using System.Collections;

public class TrackButton : MonoBehaviour {

    public Minion.TEAM owner;
    public Waypoint waypoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (owner == Minion.TEAM.TEAM_PLAYER)
        {
            if (waypoint.playerTrackDirection == Waypoint.DIRECTION.DIRECTION_LEFT)
            {
                transform.Rotate(0, 0, 90);
            }
            else
            {
                transform.Rotate(0, 0, -90);
            }
            waypoint.TogglePlayerTrack();
        }
        else
        {
            if (waypoint.enemyTrackDirection == Waypoint.DIRECTION.DIRECTION_LEFT)
            {
                transform.Rotate(Time.deltaTime, 0, -90);
            }
            else
            {
                transform.Rotate(Time.deltaTime, 0, 90);
            }
            waypoint.ToggleEnemyTrack();
        }
    }
}