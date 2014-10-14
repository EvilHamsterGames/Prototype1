using UnityEngine;
using System.Collections;

public class Minion : MonoBehaviour {

    public enum MINIONTYPE
    {
        MINIONTYPE_LIGHT,
        MINIONTYPE_MEDIUM,
        MINIONTYPE_HEAVY,
        MINIONTYPE_COUNT
    };

    public enum TEAM
    {
        TEAM_PLAYER,
        TEAM_ENEMY,
        TEAM_COUNT
    };

    public const uint LightMinionHP = 1;
    public const uint MediumMinionHP = 2;
    public const uint HeavyMinionHP = 3;
    public const float LightMinionSpeed = 0.25f;
    public const float MediumMinionSpeed = 90;
    public const float HeavyMinionSpeed = 80;
    public GameObject destination;

    private MINIONTYPE type;
    private TEAM team;
    private uint hP;
    private float speed;

	// Use this for initialization
	void Start () {
        team = TEAM.TEAM_PLAYER;
        type = MINIONTYPE.MINIONTYPE_LIGHT;
        //SetDestination(GameObject.Find("Waypoint B"));
        hP = LightMinionHP;
        speed = LightMinionSpeed;
        renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {

        Move();

	}

    public void SetType(MINIONTYPE a_type)
    {
        type = a_type;
    }

    public void SetTeam(TEAM a_team)
    {
        team = a_team;
    }

    public void SetDestination(GameObject a_destination)
    {
        destination = a_destination;
    }

    public void SetHP(uint a_HP)
    {
        hP = a_HP;
    }

    public void SetSpeed(float a_speed)
    {
        speed = a_speed;
    }

    public MINIONTYPE GetType()
    {
        return type;
    }

    public TEAM GetTeam()
    {
        return team;
    }

    public GameObject GetDestination()
    {
        return destination;
    }

    public uint GetHP()
    {
        return hP;
    }

    public float GetSpeed()
    {
        return speed;
    }

    //Takes damage and returns true if still alive. False if dead.
    public bool TakeDamage(uint a_damage)
    {
        if (hP > a_damage)
        {
            hP = hP - a_damage;
            return true;
        }
        else
        {
            hP = 0;
            return false;
        }
    }

    //Pathfinding
    public void Move()
    {
        float degreesToRad = Mathf.PI / 180;
        float polarAngle = 0;
        float xDiff = destination.transform.position.x - transform.position.x;
        float yDiff = destination.transform.position.y - transform.position.y;

        if (Mathf.Sqrt(Mathf.Pow(xDiff, 2) + Mathf.Pow(yDiff, 2)) < speed)
        {
            transform.Translate(xDiff, yDiff, 0);
        }
        else
        {
            if (destination.transform.position.x > transform.position.x)
            {
                if (destination.transform.position.y >= transform.position.y)
                {
                    //First quadrant or boundary of first and fourth quadrants
                    polarAngle = Mathf.Atan((destination.transform.position.y - transform.position.y) / (destination.transform.position.x - transform.position.x));
                }
                else
                {
                    //Fourth quadrant
                    polarAngle = (360 * degreesToRad) + (Mathf.Atan((destination.transform.position.y - transform.position.y) / (destination.transform.position.x - transform.position.x)));
                }
            }
            else if (destination.transform.position.x < transform.position.x)
            {
                //Second or third quadrant or boundary of second and third quadrants
                polarAngle = (180 * degreesToRad) + (Mathf.Atan((destination.transform.position.y - transform.position.y) / (destination.transform.position.x - transform.position.x)));
            }
            else
            {
                if (destination.transform.position.y > transform.position.y)
                {
                    //Boundary of first and second quadrants
                    polarAngle = (90 * degreesToRad);
                }
                else if (destination.transform.position.y < transform.position.y)
                {
                    //Boundary of third and fourth quadrants
                    polarAngle = (270 * degreesToRad);
                }
            }
            transform.Translate(speed * Mathf.Cos(polarAngle), speed * Mathf.Sin(polarAngle), 0);
            //Debug.Log(polarAngle * 180 / Mathf.PI);
        }
    }
}