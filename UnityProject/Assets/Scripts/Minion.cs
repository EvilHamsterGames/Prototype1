using UnityEngine;
using System.Collections;

public class Minion : MonoBehaviour {

    enum MINIONTYPE
    {
        MINIONTYPE_LIGHT,
        MINIONTYPE_MEDIUM,
        MINIONTYPE_HEAVY,
        MINIONTYPE_COUNT
    };

    enum TEAM
    {
        TEAM_PLAYER,
        TEAM_ENEMY,
        TEAM_COUNT
    };

    public const uint LightMinionHP = 1;
    public const uint MediumMinionHP = 2;
    public const uint HeavyMinionHP = 3;
    public const float LightMinionSpeed = 100;
    public const float MediumMinionSpeed = 90;
    public const float HeavyMinionSpeed = 80;

    private MINIONTYPE type;
    private TEAM team;
    private Vector3 origin;
    private Vector3 destination;
    private uint hP;
    private float speed;

	// Use this for initialization
	void Start () {
        team = TEAM.TEAM_PLAYER;
        type = MINIONTYPE.MINIONTYPE_LIGHT;
        SetOrigin(GameObject.Find("Waypoint A"));
        SetDestination(GameObject.Find("Waypoint B"));
        hP = LightMinionHP;
        speed = LightMinionSpeed;
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


    public void SetOrigin(GameObject a_origin)
    {
        origin = a_origin.transform.position;
    }

    public void SetDestination(GameObject a_destination)
    {
        destination = a_destination.transform.position;
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

    public Vector3 GetOrigin()
    {
        return origin;
    }

    public Vector3 GetDestination()
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
        float xDiff = destination.x - GetX();
        float yDiff = destination.y - GetY();
        float polarAngle = Mathf.Atan(yDiff / xDiff);

        transform.Translate(speed * Mathf.Cos(polarAngle), speed * Mathf.Sin(polarAngle), 0);
    }
}