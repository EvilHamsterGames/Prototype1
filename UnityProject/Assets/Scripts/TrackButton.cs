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
        if (GUI.Button(new Rect(Screen.width / 2 - 60, 40, 120, 25), "Switch Track"))
        {
            track.TogglePlayerTrack();
        }
    }
}
