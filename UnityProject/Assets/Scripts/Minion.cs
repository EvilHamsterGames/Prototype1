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
    public const float LightMinionSpeed = 50;
    public const float MediumMinionSpeed = 45;
    public const float HeavyMinionSpeed = 40;
    public Waypoint destination;

    private MINIONTYPE type;
    private TEAM team;
    private uint hP;
    private float speed;

	// Use this for initialization
	void Start () {
        team = TEAM.TEAM_PLAYER;
        type = MINIONTYPE.MINIONTYPE_LIGHT;
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

    public void SetDestination(Waypoint a_destination)
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

    public Waypoint GetDestination()
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
        float xDiff = destination.GetX() - GetX();
        float yDiff = destination.GetY() - GetY();

        if (Mathf.Sqrt(Mathf.Pow(xDiff, 2) + Mathf.Pow(yDiff, 2)) < speed * Time.deltaTime)
        {
            transform.Translate(xDiff, yDiff, 0);
            destination = destination.GetNextPlayerPoint();
        }
        else
        {
            if (destination.GetX() > GetX())
            {
                if (destination.GetY() >= GetY())
                {
                    //First quadrant or boundary of first and fourth quadrants
                    polarAngle = Mathf.Atan(yDiff / xDiff);
                }
                else
                {
                    //Fourth quadrant
                    polarAngle = (360 * degreesToRad) + Mathf.Atan(yDiff / xDiff);
                }
            }
            else if (destination.GetX() < GetX())
            {
                //Second or third quadrant or boundary of second and third quadrants
                polarAngle = (180 * degreesToRad) + Mathf.Atan(yDiff / xDiff);
            }
            else
            {
                if (destination.GetY() > GetY())
                {
                    //Boundary of first and second quadrants
                    polarAngle = (90 * degreesToRad);
                }
                else if (destination.GetY() < GetY())
                {
                    //Boundary of third and fourth quadrants
                    polarAngle = (270 * degreesToRad);
                }
            }
            float xMovement = speed * Mathf.Cos(polarAngle) * Time.deltaTime;
            float yMovement = speed * Mathf.Sin(polarAngle) * Time.deltaTime;
            transform.Translate(xMovement, yMovement, 0);
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public float GetX()
    {
        return transform.position.x;
    }

    public float GetY()
    {
        return transform.position.y;
    }

    public float GetZ()
    {
        return transform.position.z;
    }
}