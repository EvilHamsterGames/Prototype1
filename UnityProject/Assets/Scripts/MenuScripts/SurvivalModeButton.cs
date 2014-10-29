using UnityEngine;
using System.Collections;

public class SurvivalModeButton : MonoBehaviour {

	public AudioClip sound;
    public GUITexture image;
    public Texture2D Button;
    public Texture2D Button_Down;

    public void OnMouseEnter() 
    {
    	
		audio.PlayOneShot(sound);
    	image.texture = Button_Down;
	
    }

    public void OnMouseExit() 
    {

    	image.texture = Button;
    	
    }

    public void OnMouseDown() 
    {
        GameSettings.SetMode(GameSettings.Mode.SURVIVAL);
    	Application.LoadLevel("Game");
    }   

}
