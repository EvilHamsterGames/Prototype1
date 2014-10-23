using UnityEngine;
using System.Collections;

public class TimeTrialModeButton : MonoBehaviour {

    public GUITexture image;
    public Texture2D Button;
    public Texture2D Button_Down;

    public void OnMouseEnter() {

    	image.texture = Button_Down;
    	
    }

    public void OnMouseExit() {

    	image.texture = Button;
	
    }

    public void OnMouseDown() {

        GameSettings.SetMode(GameSettings.Mode.TIME_TRIAL);
    	Application.LoadLevel("Game");
    }

}
