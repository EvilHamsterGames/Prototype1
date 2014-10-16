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
        track.TogglePlayerTrack();
    }
}
