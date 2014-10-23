using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {

    public enum Mode
    {
        SURVIVAL,
        TIME_TRIAL
    };

    private static Mode currentMode;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void SetMode(Mode newMode)
    {
        currentMode = newMode;
    }

    public static Mode GetMode()
    {
        return currentMode;
    }
}
