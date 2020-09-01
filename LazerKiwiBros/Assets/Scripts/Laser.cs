using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float range = 1000f;
   
    public float damage = 50f;
    
    public LineRenderer line;
   
    public bool fireLaser = false;

    public GameObject Player;
    
    public GameObject beamPoint;
    
    public int damageToGive;

    private Vector3 origin;

    private Vector3 endPoint;

    private Vector3 mousePos;

    private Vector3 rayHitPos;
    private float rayHitDistance;


    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        line.enabled = false;
    }
    void Update()
    {       
        //Button Input to Shoot Laser
        if (Input.GetMouseButton(0))
        {
            //Draw Laser
            line.enabled = true;

            //Call Raycast Function

           
            LaserCol();
            
            Debug.Log("Firing Laser/Gun");

            //Laser Position
            origin = Player.transform.position + Player.transform.forward * 0.5f * Player.transform.lossyScale.z;

            if(rayHitDistance < range)
            {
                endPoint = rayHitPos;
            }
            else
            {
                endPoint = origin + Player.transform.forward * range;
            }
            

            line.SetPosition(0, origin);

            line.SetPosition(1, endPoint);
        }
        

        if (Input.GetMouseButtonUp(0))
        {
            line.enabled = false;
        }
    }


    void LaserCol()
    {
        var ray = new Ray(transform.position, transform.forward);
        var beamPoint = (transform.position + Vector3.up);
        Vector3 dir = endPoint - origin;
        dir.Normalize();

        RaycastHit hit;

        if (Physics.Raycast(origin, dir, out hit, range))
        {
            //Damage Enemy Health
            if (hit.collider.gameObject.tag == "Enemy")
            {
                if (hit.collider.gameObject.GetComponent<EnemyHealth>())
                {
                    //endPoint = hit.point;
                    hit.collider.gameObject.GetComponent<EnemyHealth>().HurtEnemy(damageToGive);
                    Debug.Log(hit.transform.name);
                }
            }

            if (hit.collider)
            {
                //endPoint = hit.point;
                Debug.Log(hit.collider.gameObject.name);
            }

            rayHitDistance = hit.distance;
            rayHitPos = hit.point;
        }
    }
   
}
