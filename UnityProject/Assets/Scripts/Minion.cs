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
    public Vector3 circleCentre;

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

    uint GetQuadrant(float a_x, float a_y)
    {
        //First quadrant
        if ((a_x >= 0) && (a_y >= 0))
        {
            return 1;
        }
        //Second quadrant
        else if ((a_x <= 0) && (a_y >= 0))
        {
            return 2;
        }
        //Third quadrant
        else if ((a_x <= 0) && (a_y <= 0))
        {
            return 3;
        }
        //Fourth quadrant
        else
        {
            return 4;
        }
    }

    //Pathfinding
    public void Move()
    {
        float degreesToRad = Mathf.PI / 180;
        float polarAngle = 0;
        float xDiff = destination.GetX() - GetX();
        float yDiff = destination.GetY() - GetY();

        //Destination is within movement speed. Set position to destination
        if (Mathf.Sqrt(Mathf.Pow(xDiff, 2) + Mathf.Pow(yDiff, 2)) < speed * Time.deltaTime)
        {
            transform.Translate(xDiff, yDiff, 0);
            destination = destination.GetNextPlayerPoint();
        }
        //Move in direct line towards destination
        else if (circleCentre == null)
        {
            switch (GetQuadrant(xDiff, yDiff))
            {
                case 1:
                    polarAngle = Mathf.Atan(yDiff / xDiff);
                    break;
                case 2:
                    polarAngle = (180 * degreesToRad) + Mathf.Atan(yDiff / xDiff);
                    break;
                case 3:
                    polarAngle = (180 * degreesToRad) + Mathf.Atan(yDiff / xDiff);
                    break;
                default:
                    polarAngle = (360 * degreesToRad) + Mathf.Atan(yDiff / xDiff);
                    break;
            }
            float xMovement = speed * Mathf.Cos(polarAngle) * Time.deltaTime;
            float yMovement = speed * Mathf.Sin(polarAngle) * Time.deltaTime;
            transform.Translate(xMovement, yMovement, 0);
        }
        //Move toward destination along circular curve
        else
        {
            xDiff = GetX() - circleCentre.x;
            yDiff = GetY() - circleCentre.y;
            float radius = Mathf.Sqrt(Mathf.Pow(xDiff, 2) + Mathf.Pow(yDiff, 2));

            //Calculate current polar angle
            switch (GetQuadrant(xDiff, yDiff))
            {
                case 1:
                    polarAngle = Mathf.Atan(yDiff / xDiff);
                    break;
                case 2:
                    polarAngle = (180 * degreesToRad) + Mathf.Atan(yDiff / xDiff);
                    break;
                case 3:
                    polarAngle = (180 * degreesToRad) + Mathf.Atan(yDiff / xDiff);
                    break;
                default:
                    polarAngle = (360 * degreesToRad) + Mathf.Atan(yDiff / xDiff);
                    break;
            }
            //Add change in polar angle moving along circular path
            //James just making a bugfix here to get the game running
            //You can't modify the components of a transform position directly it seems instead
            //you have to copy it to a temp Vector2, make your changes and then copy it back in.
            //I've modified the code here which should work, we'll discuss it further at tommorows meeting :P
            Vector3 temp;
            temp = transform.position;

            polarAngle = polarAngle + (speed * Time.deltaTime / radius);
            temp.x = radius * Mathf.Cos(polarAngle);

            transform.position = temp;
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