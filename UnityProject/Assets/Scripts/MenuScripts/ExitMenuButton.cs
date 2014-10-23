using UnityEngine;
using System.Collections;

public class ExitMenuButton : MonoBehaviour {

	public GUITexture image;
    public Texture2D Button;
    public Texture2D Button_Down;

    public void OnMouseEnter() {

    	image.texture = Button_Down;

    }

    public void OnMouseExit() {

    	image.texture = Button;

    }

    public void OnMouseDown(){

        Application.Quit();
            
    }
}
