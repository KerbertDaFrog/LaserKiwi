using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float range = 1000f;
   
    public float damage = 50f;
    
    public LineRenderer lr;
   
    public bool fireLaser = false;
    
    public GameObject Player;
    
    public GameObject beamPoint;
    
    public int damageToGive;

    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        lr.enabled = false;
    }
    void Update()
    {
        
        
        //Button Input to Shoot Laser
        if (Input.GetMouseButtonDown(0))
        {
            lr.enabled = true;
            FireLaser();
            Debug.Log("Firing Laser/Gun");
            lr.SetPosition()
        }
        

        if (Input.GetMouseButtonUp(0))
        {
            lr.enabled = false;
        }
    }


    void FireLaser()
    {
        var ray = new Ray(transform.position, transform.forward);
        var beamPoint = (transform.position + Vector3.up);
        var direction = (transform.position + Vector3.up) - (transform.position + Vector3.up);

        RaycastHit hit;

        if (Physics.Raycast(beamPoint, direction, out hit, range))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<EnemyHealth>().HurtEnemy(damageToGive);
                Destroy(gameObject);
                Debug.Log(hit.transform.name);
            }
            else
            {

            }
        }
    }
   
}
