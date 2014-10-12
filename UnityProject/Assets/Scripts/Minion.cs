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
    private Vector3 position;
    private Waypoint origin;
    private Waypoint destination;
    private uint hP;
    private float speed;

	// Use this for initialization
	void Start () {
        type = MINIONTYPE.MINIONTYPE_LIGHT;
        team = TEAM.TEAM_PLAYER;
        position = transform.position;
        origin = null;
        destination = null;
        hP = LightMinionHP;
        speed = LightMinionSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetType(MINIONTYPE a_type)
    {
        type = a_type;
    }

    void SetTeam(TEAM a_team)
    {
        team = a_team;
    }

    void SetPosition(Vector3 a_position)
    {
        position = a_position;
    }

    void SetOrigin(Waypoint a_origin)
    {
        origin = a_origin;
    }

    void SetDestination(Waypoint a_destination)
    {
        destination = a_destination;
    }

    void SetHP(uint a_HP)
    {
        hP = a_HP;
    }

    void SetSpeed(float a_speed)
    {
        speed = a_speed;
    }

    MINIONTYPE GetType()
    {
        return type;
    }

    TEAM GetTeam()
    {
        return team;
    }

    Vector3 GetPosition()
    {
        return position;
    }

    Waypoint GetOrigin()
    {
        return origin;
    }

    Waypoint GetDestination()
    {
        return destination;
    }

    uint GetHP()
    {
        return hP;
    }

    float GetSpeed()
    {
        return speed;
    }
}
