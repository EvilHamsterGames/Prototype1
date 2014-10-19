using UnityEngine;
using System.Collections;

public class TrackButton : MonoBehaviour {

    public Waypoint track;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (track.playerTrackDirection == Waypoint.DIRECTION.DIRECTION_LEFT)
        {
            transform.Rotate(Time.deltaTime, 0, 90);
        }
        else
        {
            transform.Rotate(Time.deltaTime, 0, -90);
        }
        track.TogglePlayerTrack();
    }
}
