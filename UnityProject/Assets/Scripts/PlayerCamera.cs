using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

    public float edgeDistance = 50.0f;
    public float panSpeed = 0.3f;

    public float camZoomInMax = 5.0f;
    public float camZoomOutMax = 15.0f;
    public float camZoomSpeed = 0.3f;

    private Vector3 tempPos;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        tempPos = transform.position;

        if (Input.mousePosition.x <= 0 + edgeDistance || Input.GetKey(KeyCode.LeftArrow))
            tempPos += new Vector3(-1 * panSpeed, 0, 0);

        if (Input.mousePosition.x >= Screen.width - edgeDistance || Input.GetKey(KeyCode.RightArrow))
            tempPos += new Vector3(1 * panSpeed, 0, 0);

        if (Input.mousePosition.y <= 0 + edgeDistance || Input.GetKey(KeyCode.DownArrow))
            tempPos += new Vector3(0, -1 * panSpeed, 0);

        if (Input.mousePosition.y >= Screen.height - edgeDistance || Input.GetKey(KeyCode.UpArrow))
            tempPos += new Vector3(0, 1 * panSpeed, 0);

        //Maybe adding zoom functionality here
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Debug.Log("Mouse Zoomed out");
            if (camera.orthographicSize < camZoomOutMax)
                camera.orthographicSize += camZoomSpeed;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Debug.Log("Mouse Zoomed in");
            if (camera.orthographicSize > camZoomInMax)
                camera.orthographicSize += -camZoomSpeed;
        }
        transform.position = tempPos;
	}
}
