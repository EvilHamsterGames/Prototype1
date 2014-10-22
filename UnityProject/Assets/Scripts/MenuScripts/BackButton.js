#pragma strict
var image: GUITexture;
var Button: Texture2D;
var Button_Down: Texture2D;

function OnMouseEnter() {

	image.texture = Button_Down;
	
}

function OnMouseExit() {

	image.texture = Button;
	
}

function OnMouseDown() {

	Application.LoadLevel("MainMenu");
}
