using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    GameManager manager;

    static float timer;
    public float tickTime = 2;

    //Variable that stores random number dictating AI's choices
    private int decision;

	// Use this for initialization
	void Start () 
    {
        manager = this.GetComponent("GameManager") as GameManager;
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;
        decision = Random.Range(0, 3);

        if(timer < tickTime)

        switch (decision)
        {

        }

	}
}
