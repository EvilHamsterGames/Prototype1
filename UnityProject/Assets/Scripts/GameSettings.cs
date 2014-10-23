using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {

    public enum Mode
    {
        SURVIVAL,
        TIME_TRIAL
    };

    private static Mode currentMode;

    public static void SetMode(Mode newMode)
    {
        currentMode = newMode;
    }

    public static Mode GetMode()
    {
        return currentMode;
    }
}
