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

    void OnGUI()
    {
        float width = 120;
        float height = 25;

        if (GUI.Button(new Rect(track.GetX(), track.GetY() + 40, width, height), "Switch Track"))
        {
            track.TogglePlayerTrack();
        }

    }
}
