using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> PatrolPoints = new List<GameObject>();
    [SerializeField]
    private GameObject Player = null;
    [SerializeField]
    public GameObject Canvas = null;
    [SerializeField]
    private float PointDistance = 0;
    [SerializeField]
    private float VisionConeAngle = 0;
    

    private NavMeshAgent Agent;
    private GameObject CurrentPatrolPoint;
    private int PointIndex;
    private State MyState;

    public enum State
    {
        PATROL,
        CHASE
    }

    // Start is called before the first frame update
    void Start()
    {
        MyState = State.PATROL;
        Canvas.SetActive(false);
        Agent = GetComponent<NavMeshAgent>();
        Agent.SetDestination(PatrolPoints[0].transform.position);
        CurrentPatrolPoint = PatrolPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        switch (MyState)
        {
            case State.PATROL:
                DoPatrol();
                break;
            case State.CHASE:
                DoChase();
                break;
        }

        var guardEyePosition = transform.position + Vector3.up;
        var playerPosition = Player.transform.position + Vector3.up;
        var direction = (Player.transform.position + Vector3.up) - (transform.position + Vector3.up);
        var spotted = false;
        RaycastHit hit;

        if (Physics.Raycast(guardEyePosition, direction, out hit, float.PositiveInfinity ))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                if (Vector3.Angle(transform.forward, direction) <VisionConeAngle)
                {
                    spotted = true;
                }                
            }          
            else
            {
                playerPosition = hit.point;
            }
        }

        if (spotted)
        {
            Canvas.SetActive(true);
            MyState = State.CHASE;
        }
        else
        {
            MyState = State.PATROL;
            Agent.SetDestination(CurrentPatrolPoint.transform.position);
        }
        Canvas.SetActive(spotted);

        if (spotted)
        {
            Debug.DrawLine(guardEyePosition, playerPosition, Color.red);
        }
        else
        {
            Debug.DrawLine(guardEyePosition, playerPosition, Color.blue);
        }
        
    }

    private void DoPatrol()
    {
        if (Agent.remainingDistance < PointDistance)
        {
            PointIndex = (PointIndex + 1) % PatrolPoints.Count;
            CurrentPatrolPoint = PatrolPoints[PointIndex];
        }
    }

    private void DoChase()
    {
        Agent.SetDestination(Player.transform.position);
    }
}
