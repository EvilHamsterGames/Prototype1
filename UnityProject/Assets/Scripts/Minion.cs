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

    public enum MOVEMENT_TYPE
    {
        MOVEMENT_TYPE_LINEAR,
        MOVEMENT_TYPE_CLOCKWISE,
        MOVEMENT_TYPE_ANTICLOCKWISE,
        MOVEMENT_TYPE_COUNT
    };

    public const uint LightMinionHP = 1;
    public const uint MediumMinionHP = 2;
    public const uint HeavyMinionHP = 3;
    public const float LightMinionSpeed = 50;
    public const float MediumMinionSpeed = 45;
    public const float HeavyMinionSpeed = 40;
    public Waypoint destination;
    
    private Vector3 circleCentre;
    private MOVEMENT_TYPE movementType;
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
        if ((a_x > 0) && (a_y > 0))
        {
            return 1;
        }
        //Second quadrant
        else if ((a_x < 0) && (a_y > 0))
        {
            return 2;
        }
        //Third quadrant
        else if ((a_x < 0) && (a_y < 0))
        {
            return 3;
        }
        //Fourth quadrant
        else if ((a_x > 0) && (a_y < 0))
        {
            return 4;
        }
        //Between two quadrants
        else
        {
            return 5;
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
            if (team == TEAM.TEAM_PLAYER)
            {
                destination = destination.GetNextPlayerPoint();
                movementType = destination.GetNextPlayerMovementType();
                if (movementType != MOVEMENT_TYPE.MOVEMENT_TYPE_LINEAR)
                {
                    circleCentre = destination.GetNextPlayerCircleCentre();
                }
            }
            else
            {
                destination = destination.GetNextEnemyPoint();
                movementType = destination.GetNextEnemyMovementType();
                if (movementType != MOVEMENT_TYPE.MOVEMENT_TYPE_LINEAR)
                {
                    circleCentre = destination.GetNextEnemyCircleCentre();
                }
            }
        }
        else {
            if (movementType == MOVEMENT_TYPE.MOVEMENT_TYPE_LINEAR)
            {
                //Move in direct line towards destination
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
                    case 4:
                        polarAngle = (360 * degreesToRad) + Mathf.Atan(yDiff / xDiff);
                        break;
                    default:
                        if (xDiff == 0)
                        {
                            if (yDiff > 0)
                            {
                                polarAngle = 90 * degreesToRad;
                            }
                            else if (yDiff < 0)
                            {
                                polarAngle = 270 * degreesToRad;
                            }
                            else
                            {
                                //Target is at object's current location
                                polarAngle = -1;
                            }
                        }
                        else if (yDiff == 0)
                        {
                            if (xDiff > 0)
                            {
                                polarAngle = 0;
                            }
                            else
                            {
                                polarAngle = 180 * degreesToRad;
                            }
                        }
                        break;
                }
                if (polarAngle != -1)
                {
                    float xMovement = speed * Mathf.Cos(polarAngle) * Time.deltaTime;
                    float yMovement = speed * Mathf.Sin(polarAngle) * Time.deltaTime;
                    transform.Translate(xMovement, yMovement, 0);
                }
            }
            else
            {
                //Move toward destination along circular curve
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
                    case 4:
                        polarAngle = (360 * degreesToRad) + Mathf.Atan(yDiff / xDiff);
                        break;
                    default:
                        if (xDiff == 0)
                        {
                            if (yDiff > 0)
                            {
                                polarAngle = 90 * degreesToRad;
                            }
                            else if (yDiff < 0)
                            {
                                polarAngle = 270 * degreesToRad;
                            }
                            else
                            {
                                //Target is at object's current location
                                polarAngle = -1;
                            }
                        }
                        else if (yDiff == 0)
                        {
                            if (xDiff > 0)
                            {
                                polarAngle = 0;
                            }
                            else
                            {
                                polarAngle = 180 * degreesToRad;
                            }
                        }
                        break;
                }
                //Add change in polar angle moving along circular path
                //James just making a bugfix here to get the game running
                //You can't modify the components of a transform position directly it seems instead
                //you have to copy it to a temp Vector2, make your changes and then copy it back in.
                //I've modified the code here which should work, we'll discuss it further at tommorows meeting :P
                Vector3 temp;
                temp = transform.position;

                //Clockwise rotation
                if (movementType == MOVEMENT_TYPE.MOVEMENT_TYPE_CLOCKWISE)
                {
                    polarAngle = polarAngle - (speed * Time.deltaTime / radius);
                }
                //Anticlockwise rotation
                else
                {
                    polarAngle = polarAngle + (speed * Time.deltaTime / radius);
                }
                temp.x = circleCentre.x + (radius * Mathf.Cos(polarAngle));
                temp.y = circleCentre.y + (radius * Mathf.Sin(polarAngle));
                transform.position = temp;
            }
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